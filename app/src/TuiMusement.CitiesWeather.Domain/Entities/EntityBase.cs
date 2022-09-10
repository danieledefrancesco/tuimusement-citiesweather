using System.Collections.Generic;

namespace TuiMusement.CitiesWeather.Domain.Entities
{
    public abstract class EntityBase<TID>
    {
        protected EntityBase(TID id)
        {
            Id = id;
        }

        public TID Id { get; }

        private sealed class IdEqualityComparer : IEqualityComparer<EntityBase<TID>>
        {
            public bool Equals(EntityBase<TID> x, EntityBase<TID> y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return EqualityComparer<TID>.Default.Equals(x.Id, y.Id);
            }

            public int GetHashCode(EntityBase<TID> obj)
            {
                return EqualityComparer<TID>.Default.GetHashCode(obj.Id);
            }
        }

        public static IEqualityComparer<EntityBase<TID>> IdComparer { get; } = new IdEqualityComparer();

        protected bool Equals(EntityBase<TID> other)
        {
            return EqualityComparer<TID>.Default.Equals(Id, other.Id);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EntityBase<TID>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TID>.Default.GetHashCode(Id);
        }
    }
}