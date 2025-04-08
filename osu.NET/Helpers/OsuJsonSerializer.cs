using Newtonsoft.Json;
using osu.NET.Enums;
using osu.NET.Helpers.Converters;
using osu.NET.Models.Beatmaps.Discussions;
using osu.NET.Models.Events;

namespace osu.NET.Helpers;

/// <summary>
/// Provides the <see cref="JsonSerializerSettings"/> for the <see cref="OsuApiClient"/>.
/// </summary>
internal static class OsuJsonSerializer
{
  public static JsonSerializer Create()
    => JsonSerializer.Create(new()
    {
      //
      // Unifies the parsing of timezones, causing those with a "+00:00" returned from the API to not be converted into the local timezones by NSJ
      //
      DateTimeZoneHandling = DateTimeZoneHandling.Utc,

      Converters = [
        new EnumConverter(),

        //
        // Deserializes UserEvent objects into their correct type based on the UserEventType
        //
        new TypeMappingConverter<Event>(obj =>
        {
          return obj.Type switch
          {
            EventType.Achievement => typeof(AchievementEvent),
            EventType.BeatmapPlaycount => typeof(BeatmapPlaycountEvent),
            EventType.BeatmapsetApprove => typeof(BeatmapsetApproveEvent),
            EventType.BeatmapsetDelete => typeof(BeatmapsetDeleteEvent),
            EventType.BeatmapsetRevive => typeof(BeatmapsetReviveEvent),
            EventType.BeatmapsetUpdate => typeof(BeatmapsetUpdateEvent),
            EventType.BeatmapsetUpload => typeof(BeatmapsetUploadEvent),
            EventType.Rank => typeof(RankEvent),
            EventType.RankLost => typeof(RankLostEvent),
            EventType.UserSupportAgain => typeof(UserSupportAgainEvent),
            EventType.UserSupportFirst => typeof(UserSupportFirstEvent),
            EventType.UserSupportGift => typeof(UserSupportGiftEvent),
            EventType.UsernameChange => typeof(UsernameChangeEvent),
            _ => throw new NotImplementedException($"{nameof(EventType)} '{obj.Type}' is not implemented.")
          };
        }),

        //
        // Deserializes DiscussionPost objects into their correct type based on whether its a system message
        //
        new TypeMappingConverter<DiscussionPost>(obj =>
        {
          return obj.IsSystemMessage switch
          {
            true => typeof(SystemDiscussionPost),
            false => typeof(UserDiscussionPost)
          };
        })
      ]
    });
}