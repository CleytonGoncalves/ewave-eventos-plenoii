using System;
using System.Linq;
using AutoFixture;
using Domain.Palestras;
using Domain.Palestras.Events;
using Domain.Palestras.Rules;
using FluentAssertions;
using UnitTests.Core;
using Xunit;

namespace UnitTests.Aggregates
{
    public class PalestraTests
    {
        [Fact]
        public void CriarPalestra_DeveGerar_PalestraCriadaEvent()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<Palestra>();

            sut.Should().HavePublishedEventOf<PalestraCriadaEvent>();
        }

        [Fact]
        public void DefinirPalestrante_DeveGerar_PalestranteDefinidoEvent()
        {
            var fixture = new Fixture();
            var palestrante = fixture.Create<string>();
            var sut = fixture.Create<Palestra>();

            sut.DefinirPalestrante(palestrante);

            sut.GetAllDomainEvents().OfType<PalestranteDefinidoEvent>()
                .Should().ContainSingle()
                .Which.Palestrante.Should().Be(palestrante);
        }

        [Fact]
        public void ConfirmarPresencaPalestrante_DeveGerar_PalestraConfirmadaEvent()
        {
            var fixture = new Fixture();
            var sut = fixture.Create<Palestra>();

            sut.ConfirmarPresencaPalestrante();

            sut.Should().HavePublishedEventOf<PalestraConfirmadaEvent>();
        }

        [Fact]
        public void DefinirPalestranteVazio_DeveGerar_BusinessRuleException()
        {
            var fixture = new Fixture();
            var sut = fixture.Create<Palestra>();
            string strMenorQueTamanhoMinimo =
                Guid.Empty.ToString().Substring(0, PalestranteMinimumLengthRule.MIN_LENGTH - 1);

            Action act = () => sut.DefinirPalestrante(strMenorQueTamanhoMinimo);

            sut.Should().BreakBusinessRule<PalestranteMinimumLengthRule>(act);
        }
    }
}
