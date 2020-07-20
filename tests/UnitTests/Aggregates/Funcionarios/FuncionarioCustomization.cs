using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using UnitTests.Core;

namespace UnitTests.Aggregates.Funcionarios
{
    /// <summary> <see cref="CompositeCustomization"/> </summary>
    public class FuncionarioCustomization : ICustomization
    {
        public IEnumerable<ICustomization> Customizations { get; }

        public FuncionarioCustomization(bool isEmailEmUso = false)
        {
            Customizations = new List<ICustomization> {
                new EmailCustomization(),
                new EmailEmUsoCustomization(isEmailEmUso),
                new AutoMoqCustomization()
            };
        }

        public void Customize(IFixture fixture)
        {
            // Corrige erro de possível recursão devido a self-reference por causa de Superior ser do mesmo tipo
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            foreach (var customization in Customizations)
                customization.Customize(fixture);
        }
    }
}
