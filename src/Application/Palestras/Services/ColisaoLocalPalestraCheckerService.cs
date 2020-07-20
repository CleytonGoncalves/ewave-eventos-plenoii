using System;
using System.Linq;
using Domain.Palestras;
using Domain.Palestras.ValueObjects;

namespace Application.Palestras.Services
{
    public class ColisaoLocalPalestraChecker : IColisaoLocalPalestraChecker
    {
        private readonly IPalestraRepository _repository;

        public ColisaoLocalPalestraChecker(IPalestraRepository repository)
        {
            _repository = repository;
        }

        public bool IsLocalDisponivelNoHorario(Local local, DateTimeOffset dataInicial,
            DateTimeOffset dataFinal)
        {
            var palestrasNoLocalDuranteHorario = _repository.FindBy(local, dataInicial, dataFinal);

            return ! palestrasNoLocalDuranteHorario.Any();
        }
    }
}
