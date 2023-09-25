VS -> Color Tabs by project selected. Wow

Ctrl + Alt + L - Show Solution Explorer

Rider 

Shift + Shift


### Issue with ports

Message "Failed to bind to address http://localhost:5172."  string
After Windows 10 Update KB4074588, some ports are reserved by Windows and applications cannot bind to these ports. 50067 is in the blocked range.
```
netsh interface ipv4 show excludedportrange protocol=tcp
```

```
netsh interface ipv4 show excludedportrange protocol=tcp
Protocol tcp Port Exclusion Ranges

Start Port    End Port
----------    --------
      5169        5169
      5170        5170
      5172        5172
      5173        5173
      ...
```
So change the ports in Vs Accordingly

rider track current file in solution explorer

the option is called "Always Select Opened File"




### My Secrets

Rider -> Project -> Tools -> .NET User Secrets

```json
{
"MessageBus:MangoWebConnectionString": "Endpoint=sb..."
}
```

observe your secrets:

```
dotnet user-secrets list
```

```cs
using Microsoft.Extensions.Configuration;
...
    // ctor
    public MessageBus()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<MessageBus>().Build();
        connectionString = config.GetSection("MessageBus")["MangoWebConnectionString"];
    }

    public async Task PublishMessage(object message, string topicQueueName)
    {
        await using var client = new ServiceBusClient(connectionString); // So can use your secret!
        ...
    }
```
