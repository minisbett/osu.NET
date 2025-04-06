<div align="center">

# osu.NET

[![License](https://img.shields.io/badge/License-GPLv3-seagreen?style=flat-square)](https://www.gnu.org/licenses/gpl-3.0)
[![NuGet](https://img.shields.io/nuget/v/osu.NET?color=blue&style=flat-square)](https://www.nuget.org/packages/osu.NET)
[![NuGet](https://img.shields.io/nuget/dt/osu.NET?color=peru&style=flat-square)](https://www.nuget.org/packages/osu.NET)
[![API Coverage](https://img.shields.io/badge/API%20Coverage-79%25-olivedrab?style=flat-square)](#api-coverage)

A modern and well documented API wrapper for the osu! API v2.<br/>
This wrapper <ins>currently only supports public scope endpoints</ins>.<br/>

[Installation](#-installation) • [Getting Started](#-getting-started) • [Contribute](#-contribute) • [API Coverage](#-api-coverage)<br/>
</div>

<div align="center">
<i>Made with ❤️ by minisbett for the osu! community</i>
</div>

### ✨ Features
✔️ **Extensive API documentation** – Detailed documentations, beyond the official API docs  
✔️ **Seamless Integration** – Designed with .NET Generic Host in mind  
✔️ **Easy Error Handling** – Result pattern for API responses with error-handling assistance  
✔️ **Flexible Authentication Flow** – Easy-to-use authorization infrastructure  
✔️ **Actively Maintained** – Contributions welcome!  

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
The API wrapper provides extension methods for registering the `OsuApiClient` as a scoped service. The access tokens are provided via an `IOsuAccessTokenProvider` instance provided on service registration, optionally the API client can be configured too.

Example:
```cs
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<TestService>();
        services.AddOsuApiClient(OsuClientAccessTokenProvider.FromEnvironmentVariables("OSU_ID", "OSU_SECRET"));
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

OsuApiClient client = new(provider, options, null /* ILogger, set to null for stand-alone usage*/);
```
> [!IMPORTANT]
> Since the logging is based on the `Microsoft.Extensions.Logging.ILogger<T>`, a part of the .NET Generic Host, the logger needs to be set to null.

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
> This feature is experimental and the warning can be disabled via `#pragma warning disable OSU001`, or as suggested by your IDE.


## 🌱 Contribute

This library is continuously maintained, and contributions are always welcome. Whether it's improving documentation, adding new features, or updating existing code, every contribution helps keep the project up-to-date and easy-to-use.

**📝 Improve Documentation**  
Some parts of the documentation are still missing. If you encounter some, and you can provide information about it, any contributions filling the gaps are much appreciated!

**🔧 Add or Update API Endpoints**  
Not all endpoints the API provides are implemented. If you require a missing endpoint, feel free to propose it using a [GitHub issue](https://github.com/minisbett/osu.NET/issues) or implement it via a [pull request](https://github.com/minisbett/osu.NET/pulls). Similarily, feel free to contribute if you notice an outdated endpoint, as the osu! API evolves over time.

**🆙 Update API Models**  
If any API models are outdated due to changes in the osu! API, feel free to report it via a [GitHub issue](https://github.com/minisbett/osu.NET/issues) or update them via a [pull request](https://github.com/minisbett/osu.NET/pulls).

**🗣️ Report Issues**  
If something isn't working as expected, open an issue with a detailed description so the problem can be addressed promptly.

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
- ❌ `/beatmapsets/search`
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
- ❌ `/rooms/{room}/playlist/{playlist}/scores`
- ❌ `/rooms/{room}`🔎

#### News 📰
- ✅ `/news`
- ✅ `/news/{news}`
- ✅ `/news/{news}?id`

#### Rankings 🏆
- ✅ `/rankings/kudosu`
- ❌ `/rankings/{mode}/{type}`
- ✅ `/spotlights`

#### Scores 📊
- ✅ `/scores`
- ✅ `/scores/{ruleset}/{score}`🔎
- ✅ `/scores/{score}`🔎
- ✅ `/scores/{score}/download`🔎

#### Users 👤
- ✅ `/users/{user}/kudosu`
- ✅ `/users/{user}/scores/{type}`
- ✅ `/users/{user}/beatmapsets/{type}`
- ✅ `/users/{user}/recent_activity`
- ✅ `/users/{user}/{mode?}`
- ✅ `/users?id[]`
- ✅ `/users/lookup`🔎

#### Wiki 📖
- ✅ `/wiki/{locale}/{path}`

#### Other ⭐

- ✅ `/seasonal-backgrounds`🔎
- ✅ `/tags`🔎