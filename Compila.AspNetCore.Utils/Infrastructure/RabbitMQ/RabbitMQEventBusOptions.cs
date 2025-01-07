namespace Compila.AspNetCore.Utils.Infrastructure.RabbitMQ
{
    public class RabbitMQEventBusOptions
    {
        public string ExchangeName { get; set; } = "";
        public string? RoutingKey { get; set; }
        public bool Mandatory { get; set; }
    }
}
