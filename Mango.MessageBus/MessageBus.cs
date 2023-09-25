using System.Text;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Mango.MessageBus;

public class MessageBus : IMessageBus
{  
    public MessageBus()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<MessageBus>().Build();
        connectionString = config.GetSection("MessageBus")["MangoWebConnectionString"];
    }

    private readonly string connectionString;
    public async Task PublishMessage(object message, string topicQueueName)
    {
        await using var client = new ServiceBusClient(connectionString);
        ServiceBusSender sender = client.CreateSender(topicQueueName);
        var jsonMessage = JsonConvert.SerializeObject(message);
        
        ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
        {
            CorrelationId = Guid.NewGuid().ToString()
        };
        
        await sender.SendMessageAsync(finalMessage);
        await client.DisposeAsync();
    }
}