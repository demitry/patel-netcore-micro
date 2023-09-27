using System.Text;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Mango.MessageBus;

public class MessageBus : IMessageBus
{
    private Dictionary<string, string> _connections = new ();
    
    public MessageBus()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<MessageBus>().Build();
        
        _connections.Add("emailshoppingcart", config.GetSection("MessageBus")["MangoWebConnectionString_emailshoppingcart"]);
        _connections.Add("registeruser", config.GetSection("MessageBus")["MangoWebConnectionString_registeruser"]);
    }

    public async Task<bool> PublishMessage(object message, string topicQueueName)
    {
        if (string.IsNullOrWhiteSpace(_connections[topicQueueName]))
        {
            return false;
        }
        
        await using var client = new ServiceBusClient(_connections[topicQueueName]);
        ServiceBusSender sender = client.CreateSender(topicQueueName);
        var jsonMessage = JsonConvert.SerializeObject(message);
        
        ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
        {
            CorrelationId = Guid.NewGuid().ToString()
        };
        
        await sender.SendMessageAsync(finalMessage);
        await client.DisposeAsync();
        return true;
    }
}