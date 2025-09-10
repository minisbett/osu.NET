using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using osu.NET.Authorization;

namespace osu.NET;

/// <summary>
/// Provides extension methods for <see cref="IServiceCollection"/> to register <see cref="OsuApiClient"/> objects.
/// </summary>
public static class ServiceCollectionExtensions
{
  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/> with the specified access token provider in the service collection.
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="accessTokenProvider">An access token provider for the API client.</param>
  public static IServiceCollection AddOsuApiClient(this IServiceCollection services, IOsuAccessTokenProvider accessTokenProvider)
    => services.AddOsuApiClient(_ => accessTokenProvider);

  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/> in the service collection.
  /// <br/><br/>
  /// Notes:
  /// <list type="bullet">
  /// <item>The <paramref name="accessTokenProviderFactory"/> is ran on service registration as the access token provider must be a singleton instance in order to persist authorization data.</item>
  /// </list>
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="accessTokenProviderFactory">A factory for creating an access token provider for the API client.</param>
  public static IServiceCollection AddOsuApiClient(this IServiceCollection services,
    Func<IServiceProvider, IOsuAccessTokenProvider> accessTokenProviderFactory)
  {
    IOsuAccessTokenProvider accessTokenProvider = accessTokenProviderFactory(services.BuildServiceProvider());
    return services.AddScoped(services =>
    {
      return new OsuApiClient(accessTokenProvider, services.GetRequiredService<ILogger<OsuApiClient>>());
    });
  }
}
