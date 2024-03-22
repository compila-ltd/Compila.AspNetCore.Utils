namespace Compila.AspNetCore.Utils.Entity
{
    public abstract class TrackingEntity : Entity
    {
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public TrackingEntity() : base()
        {

        }
    }
}
