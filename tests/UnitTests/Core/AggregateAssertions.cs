using System;
using System.Linq;
using Domain.Core;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace UnitTests.Core
{
    public class AggregateAssertions : ReferenceTypeAssertions<EntityBase, AggregateAssertions>
    {
        protected override string Identifier => "Aggregate";

        public AggregateAssertions(EntityBase aggregate) : base(aggregate)
        {
        }

        public AndConstraint<AggregateAssertions> HavePublishedEventOf<T>()
        {
            var domainEvent = Subject.GetAllDomainEvents().OfType<T>().FirstOrDefault();

            domainEvent.Should().BeOfType<T>();

            return new AndConstraint<AggregateAssertions>(this);
        }

        public AndConstraint<AggregateAssertions> BreakBusinessRule<TRule>(Action action, string because = "",
            params object[] becauseArgs)
            where TRule : class, IBusinessRule
        {
            action.Should()
                .Throw<BusinessRuleValidationException>(because, becauseArgs)
                .Where(x => x.BrokenRule is TRule);

            return new AndConstraint<AggregateAssertions>(this);
        }
    }
}
