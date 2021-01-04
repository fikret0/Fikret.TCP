# Fikret.TCP
 A basic TCP Server written in C#.

## Basic Usage:

### Client:

```cs
using Fikret.TCP;

...

FikretTCPClient client = new FikretTCPClient();
client.MessageReceived += MessageReceived;
client.Start(10039);
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
