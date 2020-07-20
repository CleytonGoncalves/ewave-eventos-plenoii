using System;
using System.Linq;
using AutoFixture;
using Domain.Palestras;
using Domain.Palestras.Events;
using Domain.Palestras.Rules;
using Domain.SharedKernel;
using FluentAssertions;
using UnitTests.Core;
using Xunit;

namespace UnitTests.Aggregates.Palestras
{
    public class PalestraTests
    {
        [Fact]
        public void CriarPalestra_DeveGerar_PalestraCriadaEvent()
        {
            // arrange
            var fixture = new Fixture().Customize(new PalestraCustomization());

            // act
            var sut = fixture.Create<Palestra>();

            // assert
            sut.Should().HavePublishedEventOf<PalestraCriadaEvent>();
        }

        [Fact]
        public void DefinirPalestrante_DeveGerar_PalestranteDefinidoEvent()
        {
            // arrange
            var fixture = new Fixture().Customize(new PalestraCustomization());
            var nome = fixture.Create<string>();
            var email = fixture.Create<Email>();
            var sut = fixture.Create<Palestra>();

            // act
            sut.DefinirPalestrante(nome, email);

            // assert
            sut.GetAllDomainEvents().OfType<PalestranteDefinidoEvent>()
                .Should().ContainSingle()
                .And.SatisfyRespectively(x =>
                {
                    x.PalestranteNome.Should().Be(nome);
                    x.PalestranteEmail.Should().Be(email);
                });
        }

        [Fact]
        public void ConfirmarPresencaPalestrante_DeveGerar_PalestraConfirmadaEvent()
        {
            // arrange
            var fixture = new Fixture().Customize(new PalestraCustomization());
            var sut = fixture.Create<Palestra>();

            // act
            sut.ConfirmarPresencaPalestrante();

            // assert
            sut.Should().HavePublishedEventOf<PalestraConfirmadaEvent>();
        }

        [Fact]
        public void DefinirPalestranteVazio_DeveGerar_BusinessRuleException()
        {
            // arrange
            var fixture = new Fixture().Customize(new PalestraCustomization());
            var nomeMenorQuePermitido = Guid.Empty.ToString().Substring(0, PalestranteMinimumLengthRule.MIN_LENGTH - 1);
            var email = fixture.Create<Email>();
            var sut = fixture.Create<Palestra>();

            // act
            Action act = () => sut.DefinirPalestrante(nomeMenorQuePermitido, email);

            // assert
            sut.Should().BreakBusinessRule<PalestranteMinimumLengthRule>(act);
        }
    }
}
