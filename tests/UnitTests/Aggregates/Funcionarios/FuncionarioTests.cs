using System;
using AutoFixture;
using Domain.Core;
using Domain.Funcionarios;
using Domain.Funcionarios.Events;
using Domain.SharedKernel;
using FluentAssertions;
using UnitTests.Core;
using Xunit;

namespace UnitTests.Aggregates.Funcionarios
{
    public class FuncionarioTests
    {
        [Fact]
        public void CriarFuncionario_DeveGerar_FuncionarioCriadoEvent()
        {
            // arrange
            var fixture = new Fixture().Customize(new FuncionarioCustomization());

            // act
            var sut = new Funcionario(fixture.Create<string>(), fixture.Create<Email>(), fixture.Create<Email>(),
                new DummyEmailEmUsoChecker(false));

            // assert
            sut.Should().HavePublishedEventOf<FuncionarioCriadoEvent>();
        }

        [Fact]
        public void CriarFuncionarioComEmailExistente_DeveGerar_BusinessRuleException()
        {
            // arrange
            var fixture = new Fixture().Customize(new FuncionarioCustomization());

            // act
            Func<Funcionario> sut = () => new Funcionario(fixture.Create<string>(), fixture.Create<Email>(),
                fixture.Create<Email>(), new DummyEmailEmUsoChecker(true));

            // assert
            sut.Should().Throw<BusinessRuleValidationException>();
        }
    }
}
