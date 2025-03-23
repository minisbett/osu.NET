namespace osu.NET;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#events

  /// <summary>
  /// Returns a bundle of events across osu! and the cursor string for fetching further events. One request returns 50 events.
  /// <br/><br/>
  /// API docs:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-events"/>
  /// </summary>
  /// <param name="cursor">Optional. The cursor string for fetching further events.</param>
  /// <param name="sort">Optional. The sorting option for the events.</param>
  /// <param name="cancellationToken">Optional. The cancellation token for aborting the request.</param>
  /// <returns>The bundle with the 50 most recent events across osu!.</returns>
  [CanReturnAPIError()]
  public async Task<ApiResult<EventsBundle>> GetEventsAsync(EventSortType? sort = null, string ? cursor = null,
    CancellationToken? cancellationToken = null)
    => await GetAsync<EventsBundle>("events", cancellationToken,
    [
      ("sort", sort),
      ("cursor_string", cursor)
    ]);
}