using System.Text;
using Azure.Messaging.ServiceBus;
using Mango.Services.EmailAPI.Models.Dto;
using Mango.Services.EmailAPI.Services;
using Newtonsoft.Json;

namespace Mango.Services.EmailAPI.Messaging;

public class AzureServiceBusConsumer : IAzureServiceBusConsumer
{
    private readonly string sbusCnStrForEmailQueue;
    private readonly string sbusCnStrForRegUserQueue;
    
    private readonly string emailCartQueue;
    private readonly string registerUserQueue;
    private readonly IConfiguration _configuration;
    private readonly EmailService _emailService; // it is not interface, but singleton implementation
    
    private readonly ServiceBusProcessor _emailCartProcessor;
    private readonly ServiceBusProcessor _registerUserProcessor;

    public AzureServiceBusConsumer(IConfiguration configuration, EmailService emailService)
    {
        _configuration = configuration;
        _emailService = emailService;
        
        var secretConfig = new ConfigurationBuilder().AddUserSecrets<AzureServiceBusConsumer>().Build();
        sbusCnStrForEmailQueue = secretConfig.GetSection("MessageBus")["MangoWebConnectionString_emailshoppingcart"];
        sbusCnStrForRegUserQueue = secretConfig.GetSection("MessageBus")["MangoWebConnectionString_registeruser"];
        
        // I'll not save in the appsettings, I'll save in .NET secrets
        // patel: // _configuration.GetValue<string>("ServiceBusConnectionString");

        emailCartQueue = _configuration.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue");
        registerUserQueue = _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue");
        
        var client = new ServiceBusClient(sbusCnStrForEmailQueue);
        _emailCartProcessor = client.CreateProcessor(emailCartQueue);
        
        var registerQueueClient = new ServiceBusClient(sbusCnStrForRegUserQueue);
        _registerUserProcessor = registerQueueClient.CreateProcessor(registerUserQueue);
    }

    public async Task Start()
    {
        _emailCartProcessor.ProcessMessageAsync += OnEmailCartRequestReceived;
        _emailCartProcessor.ProcessErrorAsync += ErrorHandler;
        await _emailCartProcessor.StartProcessingAsync();
        
        _registerUserProcessor.ProcessMessageAsync += OnUserRegisterRequestReceived;
        _registerUserProcessor.ProcessErrorAsync += ErrorHandler;
        await _registerUserProcessor.StartProcessingAsync();
    }

    private async Task OnUserRegisterRequestReceived(ProcessMessageEventArgs arg)
    {
        // this is where we receive the register user message
        var message = arg.Message;
        var body = Encoding.UTF8.GetString(message.Body);
        string usersEmail = JsonConvert.DeserializeObject<string>(body);

        try
        {
            await _emailService.RegisterUserAndLog(usersEmail);
            
            await arg.CompleteMessageAsync(arg.Message);
            // Hey, this message is processed and you can remove it from your queue
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task Stop()
    {
        _emailCartProcessor.StopProcessingAsync();
        _emailCartProcessor.DisposeAsync();
        
        _registerUserProcessor.StopProcessingAsync();
        _registerUserProcessor.DisposeAsync();
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
            await _emailService.EmailCartAndLog(objMessage);
            
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