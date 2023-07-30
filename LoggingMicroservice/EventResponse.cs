using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class EventResponse
{
    private readonly string _queueName;
    private readonly string _rabbitMQHostName;
    private readonly string _rabbitMQUserName;
    private readonly string _rabbitMQPassword;

    public EventResponse(string queueName, string rabbitMQHostName, string rabbitMQUserName, string rabbitMQPassword)
    {
        _queueName = queueName;
        _rabbitMQHostName = rabbitMQHostName;
        _rabbitMQUserName = rabbitMQUserName;
        _rabbitMQPassword = rabbitMQPassword;
    }

    public void Start()
    {
        var factory = new ConnectionFactory
        {
            HostName = _rabbitMQHostName,
            UserName = _rabbitMQUserName,
            Password = _rabbitMQPassword
        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                ProcessLogMessage(message);
            };

            // channel recieve-consume
            channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine($"Log consumer started. Listening to queue: {_queueName}");
            Console.ReadLine(); // Keep the application running
        }
    }

    private void ProcessLogMessage(string message)
    {
        // Process the log message as per your requirement
        // this message value is then added to mongodb
        Console.WriteLine($"Received log: {message}");
       
    }
}
