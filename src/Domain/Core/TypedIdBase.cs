using System;

namespace Domain.Core
{
    /// <summary>
    /// Base p/ IDs tipados, evitando 'Primitive Obsession' nos IDs
    /// </summary>
    public abstract class TypedIdBase : IEquatable<TypedIdBase>
    {
        public Guid Value { get; }

        /// <summary> Gera um ID com o valor recebido </summary>
        protected TypedIdBase(Guid value)
        {
            Value = value;
        }

        /// <summary> Gera um novo ID </summary>
        protected TypedIdBase()
        {
            Value = Guid.NewGuid();
        }

        public override bool Equals(object? obj) =>
            ! ReferenceEquals(null, obj) && (obj is TypedIdBase other && Equals(other));

        public override int GetHashCode() => Value.GetHashCode();

        public bool Equals(TypedIdBase? other) => Value == other?.Value;

        public static bool operator ==(TypedIdBase? obj1, TypedIdBase? obj2) =>
            obj1?.Equals(obj2) ?? Equals(obj2, null);

        public static bool operator !=(TypedIdBase x, TypedIdBase y) => ! (x == y);
    }
}
