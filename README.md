<div align="center">

# osu.NET

[![License](https://img.shields.io/badge/License-LGPLv3-seagreen?style=flat-square)](https://www.gnu.org/licenses/lgpl-3.0)
[![NuGet](https://img.shields.io/nuget/v/osu.NET?color=blue&style=flat-square)](https://www.nuget.org/packages/osu.NET)
[![NuGet](https://img.shields.io/nuget/dt/osu.NET?color=peru&style=flat-square)](https://www.nuget.org/packages/osu.NET)
[![API Coverage](https://img.shields.io/badge/API%20Coverage-77%25-olivedrab?style=flat-square)](#api-coverage)

A modern and well documented API wrapper for the osu! API v2.<br/>
This wrapper <ins>currently only supports public scope endpoints</ins>.<br/>

[Installation](#-installation) • [Getting Started](#-getting-started) • [Contribute](#-contribute) • [API Coverage](#-api-coverage)<br/>
</div>

<div align="center">
<i>Made with ❤️ by minisbett for the osu! community</i>
</div>

### ✨ Features
- An extensive xmldoc-documentation, beyond what the osu! api documentation provides  
- Integrates nicely as a service into the .NET hosting life-cycle   
- Utilizes a result pattern for error-handling in API responses
- An easy-to-use authorization infrastructure, allowing you to make your own token providers  
- Actively maintained, contributions and issues are always welcome!

### 📦 Installation  
osu.NET is available via NuGet:
```sh
# via the dotnet CLI
dotnet add package osu.NET

# via the Package Manager CLI
Install-Package osu.NET
```

## 🚀 Getting Started

This library is primary designed to be integrated with the [.NET Generic Host](https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder), but can also be used [stand-alone](#️-using-osu.NET-stand-alone).

Every API model and every endpoint is well documented, including:
- Documentation of API properties and parameters, beyond what the [osu! API documentation](https://osu.ppy.sh/docs/index.html) provides
- References to the osu! API documentation and [osu-web](https://github.com/ppy/osu-web) source-code
- Information about the API errors to expect on each endpoint

For the authorization flow, there are multiple methods to choose from:
| Authorization Provider    | Authorization Flow | Usage⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ |
| -------- | ------- | ------- |
| `OsuClientAccessTokenProvider`  | Authorization using client ID & secret    | `new(id, secret)`<br/> `.FromEnvironmentVariables(id, secret)` |
| `OsuStaticAccessTokenProvider` | Authorization using a static access token     | `new(accessToken)` |
| `OsuDelegateAccessTokenProvider`    | Authorization using an access token provided via a delegate (eg. for fetching from a database)    | `new(cancellationToken => ...)`

> [!TIP]
> You can also write your own access token provider by inheriting `IOsuAccessTokenProvider`.

### ⚙️ Using osu.NET with the .NET Generic Host
The API wrapper provides extension methods for registering the `OsuApiClient` as a scoped service. The access tokens are provided via an `IOsuAccessTokenProvider` instance provided on service registration. There are more overloads available for different use-cases of authorization, eg. user-specific authorization in web applications.

Example:
```cs
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<TestService>();
        services.AddOsuApiClient(
            OsuClientAccessTokenProvider.FromEnvironmentVariables("OSU_ID", "OSU_SECRET"));
    })
  .Build();
```
The `OsuApiClient` can then be consumed via dependency injection:
```cs
public class TestService(OsuApiClient client) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        ApiResult<UserExtended> result = await client.GetUserAsync("mrekk", cancellationToken);
    }
}
```

### 🏗️ Using osu.NET stand-alone
To use the `OsuApiClient` without the .NET Generic Host, there are some considerations to be made.

In order to get started, you create an instance of the `IOsuAccessTokenProvider` providing the desired authorization flow, and using that you create an instance of the `OsuApiClient`:
```cs
OsuClientAccessTokenProvider provider = OsuClientAccessTokenProvider
    .FromEnvironmentVariables("OSU_ID", "OSU_SECRET");

OsuApiClient client = new(provider, null /* ILogger, set to null for stand-alone usage*/);
```
> [!IMPORTANT]
> Since the logging is based on the `Microsoft.Extensions.Logging.ILogger<T>`, a part of the .NET Hosting platform, the logger needs to be set to null.

## ⚠️ Error Handling

The API endpoint methods return an `ApiResult<T>`, wrapping the data returned from the osu! API (`.Value`) and alternatively providing the API error if one was returned (`.Error`).

The error message provided by the API is interpreted into an `ApiErrorType` for common errors, allowing to handle different errors in individual ways. Furthermore, the `ApiResult<T>` type provides a `Match` method, allowing to match the result for the returned value if the request succeeded, or for the `ApiError` if the requested failed.

> [!NOTE]
> The xmldocs for the API endpoint methods always provide the `ApiErrorType` the endpoints are expected to return, as well as when they do it, so you always know which errors to expect.


Here is an example on how to handle the response of a `GetUserBeatmapScoreAsync` API request:
```cs
ApiResult<UserBeatmapScore> result = await client.GetUserBeatmapScoreAsync(4697929, 7562902);

// You can also return a value inside the result matching lambdas, eg.:
// double? pp = result.Match<double>(value => value?.Score.PP, error => null);
result.Match(
    value => logger.LogInformation("PP: {PP}", value?.Score.PP,
    error => error.Type switch
    {
        ApiErrorType.BeatmapNotFound => logger.LogError("Beatmap not found."),
        ApiErrorType.UserOrScoreNotFound => logger.LogError("User not found or has no score."),
        _ => logger.LogError("{Message}", error.Message)
    })
);
```
> [!TIP]
> osu.NET provides a roslyn code analyzer for assisting with result-matching. If you match a result with the exact syntax above, matching the error directly with a `error.Type switch {...}`, the code analyzer will warn you if you have an unhandled `ApiErrorType` possibly returned by the API endpoint called.
>
> This feature is experimental and currently not shipped with osu.NET. The warning can be disabled via `#pragma warning disable OSU001`, or as suggested by your IDE.

## 🌱 Contribute

The osu! api changes frequently, and as such fixes may be required for the library to work as intended.

Any contributions, whether it's PRs updating API models, adding new endpoints or query parameter, or issues reporting outdated information are always welcome! I (the repository owner) will try my best to update the library as fast as possible, to ensure everything works flawlessly for everyone.

If you have any questions, you can also reach out to me via Discord: `minisbett`

## 📜 API Coverage

Below is a list of all planned and implemented osu! API endpoints. If you'd like to suggest a missing endpoint or add one yourself, feel free to create an issue or pull request.  

> ✅ = Implemented | ❌ = Not Implemented | 🔎 = Undocumented in official docs  

#### Beatmap Packs 🎵
- ✅ `/beatmaps/packs`
- ✅ `/beatmaps/packs/{tag}`

#### Beatmaps 🎼
- ✅ `/beatmaps?id[]`
- ✅ `/beatmaps/lookup?checksum`
- ✅ `/beatmaps/lookup?filename`
- ✅ `/beatmaps/{beatmap}`
- ✅ `/beatmaps/{beatmap}/attributes`
- ✅ `/beatmaps/{beatmap}/scores`
- ✅ `/beatmaps/{beatmap}/scores/users/{user}`
- ✅ `/beatmaps/{beatmap}/scores/users/{user}/all`

#### Discussions 🗨️
- ❌ `/beatmapsets/discussions/posts`
- ❌ `/beatmapsets/discussions/votes`
- ❌ `/beatmapsets/discussions`

#### Beatmap Sets 📦
- ✅ `/beatmapsets/search`🔎
- ✅ `/beatmapsets/lookup`
- ✅ `/beatmapsets/{beatmapset}`
- ❌ `/beatmapsets/events`🔎

#### Changelogs 📜
- ✅ `/changelog`
- ✅ `/changelog/{buildOrStream}`
- ✅ `/changelog/{stream}/{build}`

#### Comments 💬
- ✅ `/comments`
- ✅ `/comments/{comment}`

#### Events 📅
- ✅ `/events`

#### Forums 📝
- ❌ `/forums/topics`
- ❌ `/forums/topics/{topic}`
- ✅ `/forums`
- ✅ `/forums/{forum}`

#### Home 🏠
- ❌ `/search`

#### Matches 🎮
- ✅ `/matches`
- ✅ `/matches/{match}`

#### Multiplayer 🌍
- ❌ `/rooms`
- ❌ `/rooms/{room}`🔎
- ❌ `/rooms/{room}/events`🔎
- ❌ `/rooms/{room}/leaderboard`🔎
- ❌ `/rooms/{room}/playlist/{playlist}/scores`

#### News 📰
- ✅ `/news`
- ✅ `/news/{news}`

#### Rankings 🏆
- ✅ `/rankings/kudosu`
- ✅ `/rankings/{mode}/{type}`
- ✅ `/spotlights`

#### Scores 📊
- ✅ `/scores`
- ✅ `/scores/{ruleset}/{score}`🔎
- ✅ `/scores/{score}`🔎
- ✅ `/scores/{score}/download`🔎

### Teams 🫂
- ❌ `/teams/{team}/{ruleset?}`

#### Users 👤
- ✅ `/users`
- ✅ `/users/lookup`🔎
- ✅ `/users/{user}/kudosu`
- ✅ `/users/{user}/recent_activity`
- ❌ `/users/{user}/beatmaps-passed`
- ✅ `/users/{user}/{mode?}`
- ✅ `/users/{user}/scores/{type}`
- ✅ `/users/{user}/beatmapsets/{type}`

#### Wiki 📖
- ✅ `/wiki/{locale}/{path}`
- ❌ `/suggestions/wiki`🔎

#### Other ⭐

- ✅ `/seasonal-backgrounds`🔎
- ✅ `/tags`🔎
