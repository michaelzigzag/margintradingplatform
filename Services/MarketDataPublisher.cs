using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

public class MarketDataPublisher : IMarketDataPublisher
{
    private readonly string _hostname;
    private readonly string _queueName;

    public MarketDataPublisher(string hostname, string queueName)
    {
        _hostname = hostname;
        _queueName = queueName;
    }

    public void Publish(PriceBar priceBar)
    {
        var factory = new ConnectionFactory() { HostName = _hostname };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(priceBar);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
        }
    }
}