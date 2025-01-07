namespace Compila.AspNetCore.Utils.Infrastructure.RabbitMQ
{
    public interface IEventBus
    {
        Task PublishAsync(BaseEvent @event);
    }
}
