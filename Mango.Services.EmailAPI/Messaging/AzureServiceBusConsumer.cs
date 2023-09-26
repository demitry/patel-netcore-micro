using System.Text;
using Azure.Messaging.ServiceBus;
using Mango.Services.EmailAPI.Models.Dto;
using Newtonsoft.Json;

namespace Mango.Services.EmailAPI.Messaging;

public class AzureServiceBusConsumer : IAzureServiceBusConsumer
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

    public async Task Start()
    {
        _emailCartProcessor.ProcessMessageAsync += OnEmailCartRequestReceived;
        _emailCartProcessor.ProcessErrorAsync += ErrorHandler;

        await _emailCartProcessor.StartProcessingAsync();
    }

    public async Task Stop()
    {
        _emailCartProcessor.StopProcessingAsync();
        _emailCartProcessor.DisposeAsync();
    }
    
    private Task ErrorHandler(ProcessErrorEventArgs arg)
    {
        Console.WriteLine(arg.Exception.ToString());
        return Task.CompletedTask;
    }

    private async Task OnEmailCartRequestReceived(ProcessMessageEventArgs arg)
    {
        // this is where we receive the message
        var message = arg.Message;
        var body = Encoding.UTF8.GetString(message.Body);
        CartDto objMessage = JsonConvert.DeserializeObject<CartDto>(body);

        try
        {
            //TODO: try to log the message
            
            await arg.CompleteMessageAsync(arg.Message);
            // Hey, this message is processed and you can remove it from your queue
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}