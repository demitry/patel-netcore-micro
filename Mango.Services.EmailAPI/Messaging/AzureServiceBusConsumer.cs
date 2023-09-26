using Azure.Messaging.ServiceBus;

namespace Mango.Services.EmailAPI.Messaging;

public class AzureServiceBusConsumer
{
    private readonly string serviceBusConnectionString;
    private readonly string emailCartQueue;
    private readonly IConfiguration _configuration;

    private ServiceBusProcessor _emailCartProcessor;

    public AzureServiceBusConsumer(IConfiguration configuration)
    {
        _configuration = configuration;

        var secretConfig = new ConfigurationBuilder().AddUserSecrets<AzureServiceBusConsumer>().Build();
        serviceBusConnectionString = secretConfig.GetSection("MessageBus")["MangoWebConnectionString"];
        // I'll not save in the appsettings, I'll save in .NET secrets
        // patel: // _configuration.GetValue<string>("ServiceBusConnectionString");

        emailCartQueue = _configuration.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue");

        var client = new ServiceBusClient(serviceBusConnectionString);
        _emailCartProcessor = client.CreateProcessor(emailCartQueue);
    }
}