namespace Compila.AspNetCore.Utils.Infrastructure.RabbitMQ
{
    public class RabbitMQOptions
    {
        public const string RabbitMqSectionName = "RabbitMq";
        public string? HostName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
