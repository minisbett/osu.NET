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
  /// Registers a scoped <see cref="OsuApiClient"/> with the specified access token provider instance in the service collection.
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="accessTokenProvider">The access token provider.</param>
  public static IServiceCollection AddOsuApiClient(this IServiceCollection services, IOsuAccessTokenProvider accessTokenProvider)
    => services.AddOsuApiClient(_ => accessTokenProvider);

  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/>. An access token provider with the specified type is expected to be registered.
  /// </summary>
  /// <typeparam name="TProvider">The type of the access token provider.</typeparam>
  public static IServiceCollection AddOsuApiClient<TProvider>(this IServiceCollection services) where TProvider : IOsuAccessTokenProvider
    => services.AddOsuApiClient(services => services.GetRequiredService<TProvider>());

  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/>. The provided factory creates an instance of the access token provider on client instantiation.
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="serviceKey">The key of the <see cref="OsuApiClient"/> service.</param>
  /// <param name="providerFactory">The factory for creating an access token provider for the API client.</param>
  public static IServiceCollection AddKeyedOsuApiClient(this IServiceCollection services, object? serviceKey,
    Func<IServiceProvider, IOsuAccessTokenProvider> providerFactory)
  {
    return services.AddKeyedScoped(serviceKey, (services, _) =>
    {
      IOsuAccessTokenProvider accessTokenProvider = providerFactory(services);
      return new OsuApiClient(accessTokenProvider, services.GetRequiredService<ILogger<OsuApiClient>>());
    });
  }

  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/>. The provided factory creates an instance of the access token provider on client instantiation.
  /// </summary>
  /// <typeparam name="TKey">The type whichs name is used as the key.</typeparam>
  /// <param name="services">The service collection.</param>
  /// <param name="providerFactory">The factory for creating an access token provider for the API client.</param>
  public static IServiceCollection AddKeyedOsuApiClient<TKey>(this IServiceCollection services, Func<IServiceProvider, IOsuAccessTokenProvider> providerFactory)
  {
    return services.AddKeyedScoped(nameof(TKey), (services, _) =>
    {
      IOsuAccessTokenProvider accessTokenProvider = providerFactory(services);
      return new OsuApiClient(accessTokenProvider, services.GetRequiredService<ILogger<OsuApiClient>>());
    });
  }

  /// <summary>
  /// Registers a scoped, keyed <see cref="OsuApiClient"/> with the specified access token provider instance in the service collection.
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="serviceKey">The key of the <see cref="OsuApiClient"/> service.</param>
  /// <param name="accessTokenProvider">The access token provider.</param>
  public static IServiceCollection AddKeyedOsuApiClient(this IServiceCollection services, object? serviceKey, IOsuAccessTokenProvider accessTokenProvider)
    => services.AddKeyedOsuApiClient(serviceKey, _ => accessTokenProvider);

  /// <summary>
  /// Registers a scoped, keyed <see cref="OsuApiClient"/> with the specified access token provider instance in the service collection.
  /// </summary>
  /// <typeparam name="TKey">The type whichs name is used as the key.</typeparam>
  /// <param name="services">The service collection.</param>
  /// <param name="accessTokenProvider">The access token provider.</param>
  public static IServiceCollection AddKeyedOsuApiClient<TKey>(this IServiceCollection services, IOsuAccessTokenProvider accessTokenProvider)
    => services.AddKeyedOsuApiClient(nameof(TKey), accessTokenProvider);

  /// <summary>
  /// Registers a scoped, keyed <see cref="OsuApiClient"/> with the specified access token provider instance in the service collection.
  /// </summary>
  /// <typeparam name="TProvider">The type of the access token provider.</typeparam>
  /// <param name="services">The service collection.</param>
  /// <param name="serviceKey">The key of the <see cref="OsuApiClient"/> service.</param>
  public static IServiceCollection AddKeyedOsuApiClient<TProvider>(this IServiceCollection services, object? serviceKey)
    where TProvider : IOsuAccessTokenProvider
    => services.AddKeyedOsuApiClient(serviceKey, services => services.GetRequiredService<TProvider>());

  /// <summary>
  /// Registers a scoped, keyed <see cref="OsuApiClient"/> with the specified access token provider instance in the service collection.
  /// </summary>
  /// <typeparam name="TKey">The type whichs name is used as the key.</typeparam>
  /// <typeparam name="TProvider">The type of the access token provider.</typeparam>
  /// <param name="services">The service collection.</param>
  /// <param name="accessTokenProvider">The access token provider.</param>
  public static IServiceCollection AddKeyedOsuApiClient<TKey, TProvider>(this IServiceCollection services, IOsuAccessTokenProvider accessTokenProvider)
    where TProvider : IOsuAccessTokenProvider
    => services.AddKeyedOsuApiClient(nameof(TKey), services => services.GetRequiredService<TProvider>());
}
