using System.Text;
using Newtonsoft.Json;
using osu.NET.Internal;
using osu.NET.Models;
using osu.NET.Models.Chat;

namespace osu.NET;

public partial class OsuApiClient
{
    // API docs: https://osu.ppy.sh/docs/index.html#chat

    /// <summary>
    /// Request periodically to reset chat activity timeout. Also returns an updated list of recent silences.
    /// <br/>
    /// See <a href="https://osu.ppy.sh/docs/index.html#public-channels-and-activity-timeout">Public channels and activity timeout</a>
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#chat-keepalive"/>
    /// </summary>
    /// <param name="historySince">Optional. UserSilences after the specified id to return. This field is preferred and takes precedence over since.</param>
    /// <param name="since">Optional. <see cref="UserSilence"/>s after the specified <c>message_id</c> to return.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>An array of <see cref="UserSilence"/>.</returns>
    [CanReturnApiError()]
    public async Task<ApiResult<UserSilence[]>> ChatKeepAlive(long? historySince = null, long? since = null, CancellationToken? cancellationToken = null)
        => await PostAsync<UserSilence[]>("chat/ack", cancellationToken,
        [
            ("history_since", historySince),
            ("since", since)
        ], json => json["silences"]);

    /// <summary>
    /// Create a new PM channel.
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#create-new-pm"/>
    /// </summary>
    /// <param name="targetId">The ID of the user to start PM with.</param>
    /// <param name="message">The message to send.</param>
    /// <param name="isAction">Whether the message is an action (a command such as <c>/me dances</c>). Default to false.</param>
    /// <param name="uuid">Optional. A client-side message identifier which will be sent back in response and websocket json.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>Information of the new PM channel and message send.</returns>
    public async Task<ApiResult<ChatNewPMResponse>> CreateNewPM(int targetId, string message, bool isAction = false, string? uuid = null,
        CancellationToken? cancellationToken = null)
        => await PostAsync<ChatNewPMResponse>("chat/new", cancellationToken,
        [
            ("target_id", targetId),
            ("message", message),
            ("is_action", isAction),
            ("uuid", uuid)
        ]);

    /// <summary>
    /// Returns chat messages for a specific channel.
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#get-channel-messages"/>
    /// </summary>
    /// <param name="channelId">The ID of the channel to retrieve messages for.</param>
    /// <param name="limit">Optional. The number of messages to return (max of 50).</param>
    /// <param name="since">Optional. Messages after the specified message id will be returned.</param>
    /// <param name="until">Optional. messages up to but not including the specified message id will be returned.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>An array of messages.</returns>
    public async Task<ApiResult<ChatMessage[]>> GetChannelMessages(long channelId, int? limit = null, int? since = null,
        int? until = null, CancellationToken? cancellationToken = null)
        => await GetAsync<ChatMessage[]>($"chat/channels/{channelId}/messages", cancellationToken,
        [
            ("limit", limit),
            ("since", since),
            ("until", until)
        ]);

    /// <summary>
    /// Send a message to a specific channel.
    /// <br/><br/>
    /// API notes:
    /// <list type="bullet">
    /// <item>When sending a message, the last_read_id for the <see cref="ChatChannel"/> is also updated to mark the new message as read.</item>
    /// </list>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#send-message-to-channel"/>
    /// </summary>
    /// <param name="channelId">The ID of the channel to send messages to.</param>
    /// <param name="message">The message to send.</param>
    /// <param name="isAction">Whether the message is an action (a command such as <c>/me dances</c>). Default to false.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>The message send</returns>
    public async Task<ApiResult<ChatMessage>> SendMessageToChannel(long channelId, string message, bool isAction = false,
        CancellationToken? cancellationToken = null)
        => await PostAsync<ChatMessage>($"chat/channels/{channelId}/messages", cancellationToken,
        [
            ("message", message),
            ("is_action", isAction)
        ]);

    /// <summary>
    /// Join a public or multiplayer channel.
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#join-channel"/>
    /// </summary>
    /// <param name="channelId">The ID of the channel to join into.</param>
    /// <param name="userId">The user ID who's going to join the channel.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>The joined <see cref="ChatChannel"/></returns>
    public async Task<ApiResult<ChatChannel>> JoinChannel(long channelId, int userId, CancellationToken? cancellationToken = null)
        => await PutAsync<ChatChannel>($"chat/channels/{channelId}/users/{userId}", cancellationToken);

    /// <summary>
    /// Leave a public channel.
    /// <br/><br/>
    /// API notes:
    /// <list type="bullet">
    /// <item>This endpoint will only allow the leaving of public channels initially.</item>
    /// </list>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#leave-channel"/>
    /// </summary>
    /// <param name="channelId">The ID of the channel to leave.</param>
    /// <param name="userId">The user who's going to leave the channel.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>Nothing.</returns>
    public async Task<ApiResult<EmptyResponse>> LeaveChannel(long channelId, int userId, CancellationToken? cancellationToken = null)
        => await DeleteAsync<EmptyResponse>($"chat/channels/{channelId}/users/{userId}", cancellationToken);

    /// <summary>
    /// Mark Channel as read up to the give message ID.
    /// <br/><br/>
    /// API notes:
    /// <list type="bullet">
    /// <item>
    /// Note that the read marker cannot be moved backwards - i.e. if a channel has been marked as read up to <c>message_id</c> = 12,
    /// you cannot then set it backwards to <c>message_id</c> = 10.
    /// It will be rejected.
    /// </item>
    /// </list>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#mark-channel-as-read"/>
    /// </summary>
    /// <param name="channelId">The ID of the channel to mark as read.</param>
    /// <param name="messageId">The ID of the message to mark as read up to.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>Nothing.</returns>
    public async Task<ApiResult<EmptyResponse>> MarkChannelAsRead(long channelId, long messageId, CancellationToken? cancellationToken = null)
        => await PutAsync<EmptyResponse>($"chat/channels/{channelId}/mark-as-read/{messageId}", cancellationToken);

    /// <summary>
    /// Returns a list of all joinable public channels.
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#get-channel-list"/>
    /// </summary>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>An array of <see cref="ChatChannel"/></returns>
    public async Task<ApiResult<ChatChannel[]>> GetChannelList(CancellationToken? cancellationToken = null)
        => await GetAsync<ChatChannel[]>("chat/channels", cancellationToken);

    /// <summary>
    /// Creates a new PM channel. Rejoins the PM channel if it already exists.
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#create-channel"/>
    /// </summary>
    /// <param name="targetId">Target user id</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>Returns <see cref="ChatChannel"/> with recent_messages attribute; recent_messages is deprecated and should not be used.</returns>
    public async Task<ApiResult<ChatChannel>> CreatePrivateChannel(int targetId, CancellationToken? cancellationToken = null)
        => await PostAsync<ChatChannel>("chat/channels", cancellationToken,
            [
                ("target_id", targetId),
                ("type", "PM")
            ]);

    /// <summary>
    /// Creates a new announcement channel.
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#create-channel"/>
    /// </summary>
    /// <param name="name">The channel name.</param>
    /// <param name="description">The channel description.</param>
    /// <param name="message">Message to send with the announcement.</param>
    /// <param name="targetIds">Target user IDs.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>Returns <see cref="ChatChannel"/> with recent_messages attribute; recent_messages is deprecated and should not be used.</returns>
    public async Task<ApiResult<ChatChannel>> CreateAnnounceChannel(string name, string description, string message, int[] targetIds, CancellationToken? cancellationToken = null)
    {
        var body = new
        {
            channel = new AnnounceChannel { Name = name, Description = description },
            message,
            target_ids = targetIds,
            type = "ANNOUNCE"
        };

        HttpContent content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        return await PostAsync<ChatChannel>("chat/channels", cancellationToken, httpContent: content);
    }

    /// <summary>
    /// Returns a chat channel.
    /// <br/><br/>
    /// API docs:<br/>
    /// <a href="https://osu.ppy.sh/docs/index.html#get-channel"/>
    /// </summary>
    /// <param name="channel">The channel to get.</param>
    /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
    /// <returns>The chat channel</returns>
    public async Task<ApiResult<GetChannelResponse>> GetChannel(long channel, CancellationToken? cancellationToken = null)
        => await GetAsync<GetChannelResponse>($"chat/channels/{channel}", cancellationToken);
}