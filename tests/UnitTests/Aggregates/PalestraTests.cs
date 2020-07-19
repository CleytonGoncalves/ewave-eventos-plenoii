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
            var nome = fixture.Create<string>();
            var email = fixture.Create<Email>();
            var sut = fixture.Create<Palestra>();

            sut.DefinirPalestrante(nome, email);

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
            var fixture = new Fixture();
            var sut = fixture.Create<Palestra>();

            sut.ConfirmarPresencaPalestrante();

            sut.Should().HavePublishedEventOf<PalestraConfirmadaEvent>();
        }

        [Fact]
        public void DefinirPalestranteVazio_DeveGerar_BusinessRuleException()
        {
            var fixture = new Fixture();
            var nomeMenorQuePermitido = Guid.Empty.ToString().Substring(0, PalestranteMinimumLengthRule.MIN_LENGTH - 1);
            var email = fixture.Create<Email>();

            var sut = fixture.Create<Palestra>();

            Action act = () => sut.DefinirPalestrante(nomeMenorQuePermitido, email);

            sut.Should().BreakBusinessRule<PalestranteMinimumLengthRule>(act);
        }
    }
}
