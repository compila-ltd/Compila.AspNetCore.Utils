using RabbitMQ.Client;

namespace Compila.AspNetCore.Utils.Infrastructure.RabbitMQ
{
    public class RabbitMQConnection
    {
        private IConnection? _connection;
        private readonly RabbitMQOptions _options;

        public IConnection Connection => _connection!;

        public RabbitMQConnection(RabbitMQOptions options)
        {
            _options = options;

            InitializeConnection().Wait();
        }
        private async Task InitializeConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _options.HostName ?? "",
            };

            if (!string.IsNullOrEmpty(_options.UserName))
            {
                factory.UserName = _options.UserName;
            }

            if (!string.IsNullOrEmpty(_options.Password))
            {
                factory.Password = _options.Password;
            }

            _connection = await factory.CreateConnectionAsync();
        }
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
