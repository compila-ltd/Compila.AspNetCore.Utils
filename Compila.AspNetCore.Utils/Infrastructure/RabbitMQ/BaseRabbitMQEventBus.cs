using System.Text.Json;

using RabbitMQ.Client;

namespace Compila.AspNetCore.Utils.Infrastructure.RabbitMQ
{
    internal class BaseRabbitMQEventBus
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;
        private readonly RabbitMQEventBusOptions _options;

        public BaseRabbitMQEventBus(IRabbitMQConnection rabbitMQConnection, RabbitMQEventBusOptions options)
        {
            _rabbitMQConnection = rabbitMQConnection;
            _options = options;
        }

        public virtual async Task PublishAsync(BaseEvent @event)
        {
            using var channel = await _rabbitMQConnection.Connection.CreateChannelAsync();

            var body = JsonSerializer.SerializeToUtf8Bytes(@event, @event.GetType());
            await channel.BasicPublishAsync<BasicProperties>(
                exchange: _options.ExchangeName,
                routingKey: _options.RoutingKey ?? string.Empty,
                mandatory: _options.Mandatory,
                basicProperties: new(),
                body: body,
                cancellationToken: default);
        }
    }
}


