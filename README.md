
[![NuGet Version](https://img.shields.io/nuget/v/Fikret.TCP.svg?style=flat)](https://www.nuget.org/packages/Fikret.TCP/) [![NuGet](https://img.shields.io/nuget/dt/Fikret.TCP.svg)](https://www.nuget.org/packages/Fikret.TCP)
# Fikret.TCP
 A basic TCP Server written in C#.

## Basic Usage:

### Client:

```cs
using Fikret.TCP;

...

FikretTCPClient client = new FikretTCPClient();
client.MessageReceived += MessageReceived;
client.Connect("127.0.0.1", 10039);
client.Send("hi!");

public void MessageReceived(object sender, MessageReceivedEventArgs args)
{
    Console.WriteLine(args.Message);
}
```

### Server:

```cs
using Fikret.TCP;

...

FikretTCPServer server = new FikretTCPServer();
server.MessageReceived += MessageReceived;
server.Start(10039);
server.Send("hello!");

public void MessageReceived(object sender, MessageReceivedEventArgs args)
{
    Console.WriteLine(args.Message);
}
```
