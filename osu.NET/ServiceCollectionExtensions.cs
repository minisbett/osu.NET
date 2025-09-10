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
  /// Registers a scoped <see cref="OsuApiClient"/> with the specified access token provider instance in the service collection.
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="accessTokenProvider">The access token provider.</param>
  public static IServiceCollection AddOsuApiClient(this IServiceCollection services, IOsuAccessTokenProvider accessTokenProvider)
    => services.AddScoped(services => new OsuApiClient(accessTokenProvider, services.GetRequiredService<ILogger<OsuApiClient>>()));

  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/>. The provided factory creates an instance of the access token provider on client instantiation.
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="providerFactory">The factory for creating an access token provider for the API client.</param>
  public static IServiceCollection AddOsuApiClient(this IServiceCollection services, Func<IServiceProvider, IOsuAccessTokenProvider> providerFactory)
  {
    return services.AddScoped(services =>
    {
      IOsuAccessTokenProvider accessTokenProvider = providerFactory(services);
      return new OsuApiClient(accessTokenProvider, services.GetRequiredService<ILogger<OsuApiClient>>());
    });
  }

  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/>. An access token provider with the specified type is expected to be registered 
  /// </summary>
  public static IServiceCollection AddOsuApiClient<T>(this IServiceCollection services) where T : IOsuAccessTokenProvider
  {
    return services.AddScoped(services =>
    {
      T accessTokenProvider = services.GetRequiredService<T>();
      return new OsuApiClient(accessTokenProvider, services.GetRequiredService<ILogger<OsuApiClient>>());
    });
  }
}
