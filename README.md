# ExpressBot

A .NET 8 library for building bots for the [eXpress enterprise messenger](https://express.ms/).
It provides an HTTP listener for incoming bot commands, a BotX API client, and JSON models
for messages, notifications, chats, and users.

[NuGet package](https://www.nuget.org/packages/ExpressBot) ·
[Source code](https://github.com/vadarganiv/ExpressBot) ·
[Issues](https://github.com/vadarganiv/ExpressBot/issues) ·
[MIT license](https://github.com/vadarganiv/ExpressBot/blob/master/LICENSE.txt)

## Status and requirements

ExpressBot is an early-stage library with an evolving API. Version 0.2.0 includes
source-breaking changes from 0.1.0; review the migration notes below.

- .NET 8 or later.
- An eXpress bot registration, bot ID, secret, and CTS server URL.
- An HTTP listener endpoint reachable by your eXpress deployment.
- `Microsoft.Extensions.Logging.Abstractions` 9.0.0 or later (NuGet dependency).

File upload/download and the smartapp endpoints currently throw `NotImplementedException`.

## Installation

```sh
dotnet add package ExpressBot --version 0.2.0
```

For the console example, also install:

```sh
dotnet add package Microsoft.Extensions.Logging.Console --version 9.0.0
```

## Quick start

Supply `EXPRESS_BOT_ID`, `EXPRESS_CTS_URL`, `EXPRESS_HOST_URL`, and `EXPRESS_SECRET_KEY`
through your environment or secret manager. Use an absolute HTTP(S) listener URL
ending in `/` for `EXPRESS_HOST_URL`. Do not put credentials in source control.

```csharp
using ExpressBot;
using Microsoft.Extensions.Logging;

static string Required(string name) =>
    Environment.GetEnvironmentVariable(name)
    ?? throw new InvalidOperationException($"Set the {name} environment variable.");

using var loggerFactory = LoggerFactory.Create(builder =>
    builder.AddConsole().SetMinimumLevel(LogLevel.Warning));

var bot = new ExpressBotManager(
    Required("EXPRESS_BOT_ID"),
    Required("EXPRESS_CTS_URL"),
    Required("EXPRESS_HOST_URL"),
    Required("EXPRESS_SECRET_KEY"),
    loggerFactory);

// Subscribe before starting the listener. Handle messages in your application.
bot.MessageRecived += message =>
{
    Console.WriteLine("Bot command received.");
};

await bot.Start();
Console.WriteLine("Bot is running. Press Enter to stop.");
Console.ReadLine();
await bot.Stop();
```

`Start()` authorizes the bot against CTS and starts the HTTP listener. Running this
example connects to the configured server. Depending on the operating system,
the listener endpoint may require an appropriate HTTP URL reservation or proxy configuration.

The `MessageRecived` spelling is part of the current API.

## Logging

The example uses `Warning` as its minimum level. Existing HTTP diagnostics can include
authentication signatures, token responses, message payloads, and user data.
Review the destination and access controls of your logs before enabling detailed
logging. Some payload logging is at `Information`, so limiting only `Trace` is not sufficient
to exclude all message contents. This release does not change that logging behavior
from the current source implementation.

## Relationship to ExpressBot.Core

ExpressBot currently contains its own `ExpressBot.Core.*` types inside `ExpressBot.dll`.
It does **not** depend on the separate
[ExpressBot.Core NuGet package](https://www.nuget.org/packages/ExpressBot.Core).
Those APIs have diverged. Installing both packages into one consumer can cause
duplicate-type ambiguity; use ExpressBot on its own for its client and listener.

## Upgrading from 0.1.0 to 0.2.0

Rebuild consumers and review these source-breaking model changes:

- `DirectNotifycation` is now `DirectNotification`.
- `SendDirectNotificationAsync` returns `StatusResponce<SyncIdItem>` instead of
  `StatusResponce`.
- `BubbleOptions` is replaced by `ButtonOptions`; `Bubble` also exposes `Data`.
- `CommandRequest.SyncId` is now `Guid` instead of `string`.
- `CommandData.Data` and `CommandData.Metadata` are now `object`;
  `Notification.Metadata` is `dynamic`. The former `CommandMetadata` and `Metadata`
  classes have been removed.
- `EditEvent.Payload` and `ReplyEvent.Reply` use `Notification`; the former `Payload`
  class has been removed. `DirectNotification` and `EditEvent` derive from `BaseEvent`.

The package now includes this README and links to its public source repository.

## Build and contribute

```sh
dotnet build ExpressBot.sln -c Release
```

Report issues and propose changes in the
[GitHub repository](https://github.com/vadarganiv/ExpressBot).
The library is released under the MIT license.
