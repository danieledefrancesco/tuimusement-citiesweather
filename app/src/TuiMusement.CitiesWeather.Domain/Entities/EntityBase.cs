using System.Collections.Generic;

namespace TuiMusement.CitiesWeather.Domain.Entities
{
    public abstract class EntityBase<TId>
    {
        protected EntityBase(TId id)
        {
            Id = id;
        }

        public TId Id { get; }

        private sealed class IdEqualityComparer : IEqualityComparer<EntityBase<TId>>
        {
            public bool Equals(EntityBase<TId>? x, EntityBase<TId>? y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                return x.GetType() == y.GetType() && EqualityComparer<TId>.Default.Equals(x.Id, y.Id);
            }

            public int GetHashCode(EntityBase<TId> obj)
            {
                return EqualityComparer<TId>.Default.GetHashCode(obj.Id!);
            }
        }

        public static IEqualityComparer<EntityBase<TId>> IdComparer { get; } = new IdEqualityComparer();

        private bool Equals(EntityBase<TId> other)
        {
            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((EntityBase<TId>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id!);
        }
    }
}