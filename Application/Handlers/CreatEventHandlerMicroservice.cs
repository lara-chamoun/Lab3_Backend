using System.Text;
using RabbitMQ.Client;

namespace Application.Handlers;


public class CreatEventHandlerMicroservice
{
    public void SendMessageToRabbitMQ(string message, string rabbitMQHostName, string rabbitMQUserName, string rabbitMQPassword, string rabbitMQQueueName)
    {
        var factory = new ConnectionFactory
        {
            HostName = rabbitMQHostName,
            UserName = rabbitMQUserName,
            Password = rabbitMQPassword
        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: rabbitMQQueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            //channel publish - produce
            channel.BasicPublish(exchange: "",
                routingKey: rabbitMQQueueName,
                basicProperties: null,
                body: body);
        }
    }

}