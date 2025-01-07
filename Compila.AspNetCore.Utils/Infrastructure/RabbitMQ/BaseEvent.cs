namespace Compila.AspNetCore.Utils.Infrastructure.RabbitMQ
{
    public record BaseEvent
    {
        public BaseEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
