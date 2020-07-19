using System;
using Domain.Core;

namespace Domain.SharedKernel
{
    public readonly struct Email : IEquatable<Email>
    {
        private readonly string _value;

        public Email(string value)
        {
            var validEmailRule = new ValidEmailFormatRule(value);
            if (validEmailRule.IsBroken())
                throw new BusinessRuleValidationException(validEmailRule);

            _value = value;
        }

        public override string ToString() => _value;

        public override bool Equals(object? obj) => obj is Email nameObj && Equals(nameObj);

        public override int GetHashCode() => _value.GetHashCode(StringComparison.OrdinalIgnoreCase);

        public static bool operator ==(Email left, Email right) => left.Equals(right);

        public static bool operator !=(Email left, Email right) => !(left == right);

        public bool Equals(Email other) => _value == other._value;
    }
}
