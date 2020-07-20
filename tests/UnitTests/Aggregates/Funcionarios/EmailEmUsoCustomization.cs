using AutoFixture;
using Domain.Funcionarios;
using Domain.SharedKernel;

namespace UnitTests.Aggregates.Funcionarios
{
    public class EmailEmUsoCustomization : ICustomization
    {
        private readonly bool _emailEmUso;

        public EmailEmUsoCustomization(bool emailEmUso)
        {
            _emailEmUso = emailEmUso;
        }

        public void Customize(IFixture fixture) =>
            fixture.Register<IFuncionarioEmailEmUsoChecker>(() => new DummyEmailEmUsoChecker(_emailEmUso));
    }

    public class DummyEmailEmUsoChecker : IFuncionarioEmailEmUsoChecker
    {
        private readonly bool _isEmUso;

        public DummyEmailEmUsoChecker(bool isEmUso) => _isEmUso = isEmUso;

        public bool IsEmailEmUso(Email email) => _isEmUso;
    }
}
