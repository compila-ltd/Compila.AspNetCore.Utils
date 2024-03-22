using System;

namespace Compila.AspNetCore.Utils.Entity
{
    public abstract class Identity : IEquatable<Identity>, IIdentity
    {
        public Identity()
        {
            Id = Guid.NewGuid();
        }

        public Identity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public bool Equals(Identity id)
        {
            if (ReferenceEquals(this, id)) return true;
            if (ReferenceEquals(null, id)) return false;
            return Id.Equals(id.Id);
        }

        public override bool Equals(object anotherObject)
        {
            return Equals(anotherObject as Identity ?? throw new Exception("Object to compare is not of Identity type."));
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }

    public interface IIdentity
    {
        Guid Id { get; set; }
    }
}
