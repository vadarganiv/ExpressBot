### ExpressBot

ExpressBot is a library designed to simplify working with bots in the [eXpress enterprise messenger](https://express.ms/). It allows you to easily host a bot on your specified endpoint and send requests to the CTS server.

With ExpressBot, you can:
- Create bots and manage their events.
- Easily handle incoming commands.
- Quickly integrate the library into your solution.

### Notice

This library is in its alpha version, which means:
- Some features may be missing or not working correctly.
- Bugs might occur.

If you find a bug or have suggestions for improvement, don’t hesitate to let us know! We will address them as time and resources allow.

---

### Installation

Add the library to your project using **NuGet**:
```sh
dotnet add package ExpressBot
```

---

### Example Usage

Here is an example of a simple console application demonstrating the use of ExpressBot:

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ExpressBot;

internal class Program
{
    private static ExpressBotManager clientBot;
    private static ILogger logger;

    public static async Task Main(string[] args)
    {
        // Set up the logger
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information);
        });

        // Create an instance of ExpressBotManager
        clientBot = new ExpressBotManager(
            "your_bot_id",
            "cts_url",
            "host_endpoint",
            "secret_Key",
            loggerFactory
        );

        // Start the bot
        await clientBot.Start();

        // Subscribe to the message received event
        clientBot.MessageRecived += ClientBot_MessageRecived;

        Console.ReadLine();

        // Stop the bot
        await clientBot.Stop();
    }

    private static async void ClientBot_MessageRecived(CommandRequest message)
    {
        // Handle incoming message
        // Add your logic here
    }
}
```

---

### Support and Feedback

If you have any questions, encounter a bug, or have suggestions for improvements, please create an issue on GitHub or contact us.

Thank you for using ExpressBot! 😊

