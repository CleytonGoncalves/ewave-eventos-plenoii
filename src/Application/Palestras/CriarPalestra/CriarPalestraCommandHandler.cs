using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain.Palestras;
using MediatR;

namespace Application.Palestras.CriarPalestra
{
    public class CriarPalestraCommandHandler : IRequestHandler<CriarPalestraCommand, PalestraDto>
    {
        private readonly IColisaoLocalPalestraChecker _colisaoLocalChecker;
        private readonly IPalestraRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CriarPalestraCommandHandler(IColisaoLocalPalestraChecker colisaoLocalChecker,
            IPalestraRepository repository, IUnitOfWork unitOfWork)
        {
            _colisaoLocalChecker = colisaoLocalChecker;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PalestraDto> Handle(CriarPalestraCommand request, CancellationToken cancellationToken)
        {
            var palestra = new Palestra(request.Tema, request.Titulo, request.DataInicial,
                request.Duracao, request.Local, request.OrganizadorEmail, _colisaoLocalChecker);

            await _repository.Add(palestra);
            await _unitOfWork.Commit(cancellationToken);

            return new PalestraDto(palestra.Id.Value);
        }
    }
}
