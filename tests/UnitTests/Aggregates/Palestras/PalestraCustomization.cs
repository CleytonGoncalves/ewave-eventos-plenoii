using AutoFixture;
using AutoFixture.AutoMoq;
using UnitTests.Core;

namespace UnitTests.Aggregates.Palestras
{
    public class PalestraCustomization : CompositeCustomization
    {
        public PalestraCustomization(bool isLocalDisponivel = true) : base(new EmailCustomization(),
            new ColisaoLocalCustomization(isLocalDisponivel), new AutoMoqCustomization())
        {
        }
    }
}
