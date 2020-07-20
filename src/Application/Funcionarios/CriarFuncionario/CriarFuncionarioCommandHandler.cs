using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain.Funcionarios;
using MediatR;

namespace Application.Funcionarios.CriarFuncionario
{
    public class CriarFuncionarioCommandHandler : IRequestHandler<CriarFuncionarioCommand, FuncionarioDto>
    {
        private readonly IFuncionarioEmailEmUsoChecker _emailEmUsoChecker;
        private readonly IFuncionarioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CriarFuncionarioCommandHandler(IFuncionarioEmailEmUsoChecker emailEmUsoChecker,
            IFuncionarioRepository repository, IUnitOfWork unitOfWork)
        {
            _emailEmUsoChecker = emailEmUsoChecker;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<FuncionarioDto> Handle(CriarFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var funcionario = new Funcionario(request.Nome, request.Email, request.SuperiorEmail, _emailEmUsoChecker);

            await _repository.Add(funcionario);
            await _unitOfWork.Commit(cancellationToken);

            return new FuncionarioDto(funcionario.Id.Value);
        }
    }
}
