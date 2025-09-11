﻿using osu.NET.Internal;

namespace osu.NET.Enums;

/// <summary>
/// Represents the sort types for events.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-events"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/EventsController.php"/>
/// </summary>
public enum EventSortType
{
  /// <summary>
  /// Sorts the events by ID in ascending order.
  /// </summary>
  [QueryApiName("id_asc")]
  IdAscending,

  /// <summary>
  /// Sorts the events by ID in descending order.
  /// </summary>
  [QueryApiName("id_desc")]
  IdDescending,
}
