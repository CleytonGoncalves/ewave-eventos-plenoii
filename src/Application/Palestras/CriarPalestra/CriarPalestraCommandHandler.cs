using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Core.Scheduler;
using Domain.Palestras;
using MediatR;

namespace Application.Palestras.CriarPalestra
{
    public class CriarPalestraCommandHandler : IRequestHandler<CriarPalestraCommand, PalestraDto>
    {
        private readonly IColisaoLocalPalestraChecker _colisaoLocalChecker;
        private readonly IPalestraRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILembreteOrganizadorScheduler _lembreteOrganizadorScheduler;

        public CriarPalestraCommandHandler(IColisaoLocalPalestraChecker colisaoLocalChecker,
            IPalestraRepository repository, IUnitOfWork unitOfWork,
            ILembreteOrganizadorScheduler lembreteOrganizadorScheduler)
        {
            _colisaoLocalChecker = colisaoLocalChecker;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _lembreteOrganizadorScheduler = lembreteOrganizadorScheduler;
        }

        public async Task<PalestraDto> Handle(CriarPalestraCommand request, CancellationToken cancellationToken)
        {
            var palestra = new Palestra(request.Tema, request.Titulo, request.DataInicial,
                request.Duracao, request.Local, request.OrganizadorEmail, _colisaoLocalChecker);

            await _repository.Add(palestra);
            await _unitOfWork.Commit(cancellationToken);

            // Seria dataInicial - 7 dias ou algo assim, mas coloquei daqui a 2 minutos p/ testes
            _lembreteOrganizadorScheduler.Schedule(palestra.Id, DateTimeOffset.Now + TimeSpan.FromMinutes(2));

            return new PalestraDto(palestra.Id.Value);
        }
    }
}
