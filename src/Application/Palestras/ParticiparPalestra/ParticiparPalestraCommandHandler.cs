using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain.Funcionarios;
using Domain.Palestras;
using Domain.Palestras.Participacoes;
using MediatR;

namespace Application.Palestras.ParticiparPalestra
{
    public class ParticiparPalestraCommandHandler : IRequestHandler<ParticiparPalestraCommand>
    {
        private readonly IPalestraRepository _palestraRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ParticiparPalestraCommandHandler(IPalestraRepository palestraRepository,
            IFuncionarioRepository funcionarioRepository, IUnitOfWork unitOfWork)
        {
            _palestraRepository = palestraRepository;
            _funcionarioRepository = funcionarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ParticiparPalestraCommand request, CancellationToken cancellationToken)
        {
            var palestra = await _palestraRepository.GetBy(request.PalestraId, cancellationToken);
            var funcionario = await _funcionarioRepository.GetBy(request.FuncionarioId, cancellationToken);

            var status = funcionario.RequerConfirmacaoSuperior
                ? StatusParticipacao.PendenteConfirmacaoSuperior
                : StatusParticipacao.Planejado;

            palestra.AdicionarParticipacao(funcionario.Id, status);

            await _palestraRepository.Update(palestra);
            await _unitOfWork.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
