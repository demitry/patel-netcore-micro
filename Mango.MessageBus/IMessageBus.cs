namespace Mango.MessageBus;

public interface IMessageBus
{
    Task <bool> PublishMessage(object message, string topicQueueName);
}