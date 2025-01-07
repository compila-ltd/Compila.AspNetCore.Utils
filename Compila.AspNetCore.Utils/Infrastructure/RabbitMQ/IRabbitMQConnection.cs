using RabbitMQ.Client;

namespace Compila.AspNetCore.Utils.Infrastructure.RabbitMQ
{
    public interface IRabbitMQConnection
    {
        IConnection Connection { get; }
    }
}
