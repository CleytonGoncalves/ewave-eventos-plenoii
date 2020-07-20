using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain.Palestras;
using MediatR;

namespace Application.Palestras.DefinirPalestrante
{
    public class DefinirPalestranteCommandHandler : IRequestHandler<DefinirPalestranteCommand, PalestraDto>
    {
        private readonly IPalestraRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DefinirPalestranteCommandHandler(IPalestraRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PalestraDto> Handle(DefinirPalestranteCommand request, CancellationToken cancellationToken)
        {
            var palestra = await _repository.GetBy(request.PalestraId, cancellationToken);

            palestra!.DefinirPalestrante(request.Nome, request.Email);

            await _repository.Update(palestra);
            await _unitOfWork.Commit(cancellationToken);

            return new PalestraDto(palestra.Id.Value);
        }
    }
}
