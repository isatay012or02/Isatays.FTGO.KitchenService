using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Isatays.FTGO.KitchenService.Api.Services;

public class RabbitMqListenerService : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;
    private IConfiguration _configuration;

    public RabbitMqListenerService(IConfiguration configuration)
    {
        _configuration = configuration;
        var factory = new ConnectionFactory { Uri = new Uri(_configuration["RabbitMQ:Host"]!) };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: _configuration["RabbitMQ:QueueName"], durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (ch, ea) =>
        {
            var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            var str = ea.Exchange;
            //Debug.WriteLine($"Получено сообщение: {content}");

            _channel.BasicAck(ea.DeliveryTag, false);
        };

        _channel.BasicConsume(_configuration["RabbitMQ:QueueName"], false, consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}
