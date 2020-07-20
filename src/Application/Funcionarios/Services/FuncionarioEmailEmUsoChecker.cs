using Domain.Funcionarios;
using Domain.SharedKernel;

namespace Application.Funcionarios.Services
{
    public class FuncionarioEmailEmUsoChecker : IFuncionarioEmailEmUsoChecker
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioEmailEmUsoChecker(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public bool IsEmailEmUso(Email email)
        {
            return _repository.FindBy(email) != null;
        }
    }
}
