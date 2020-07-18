using System;

namespace Domain.Core
{
    #pragma warning disable CA1032 // Implement standard exception constructors
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; }
        public string Details { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = BrokenRule.Message;
        }

        public override string ToString() => $"{BrokenRule.GetType().Name}: {BrokenRule.Message}";
    }
    #pragma warning restore CA1032 // Implement standard exception constructors
}
