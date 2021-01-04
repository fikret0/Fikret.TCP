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

public void MessageReceived(object sender, MessageReceivedEventArgs args)
{
  Console.WriteLine(args.Message);
}
```
