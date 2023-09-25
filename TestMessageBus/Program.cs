using Mango.MessageBus;

Console.WriteLine("Hello, World!");

MessageBus bus = new MessageBus();

bus.PublishMessage(new object(), string.Empty);