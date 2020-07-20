using System;
using AutoFixture;
using Domain.Palestras;
using Domain.Palestras.ValueObjects;

namespace UnitTests.Aggregates.Palestras
{
    public class ColisaoLocalCustomization : ICustomization
    {
        private readonly bool _localDisponivel;

        public ColisaoLocalCustomization(bool localDisponivel)
        {
            _localDisponivel = localDisponivel;
        }

        public void Customize(IFixture fixture) =>
            fixture.Register<IColisaoLocalPalestraChecker>(() => new DummyColisaoLocalChecker(_localDisponivel));
    }

    public class DummyColisaoLocalChecker : IColisaoLocalPalestraChecker
    {
        private readonly bool _isDisponivel;

        public DummyColisaoLocalChecker(bool isDisponivel) => _isDisponivel = isDisponivel;

        public bool IsLocalDisponivelNoHorario(Local local, DateTimeOffset dataInicial, DateTimeOffset dataFinal) =>
            _isDisponivel;
    }
}
