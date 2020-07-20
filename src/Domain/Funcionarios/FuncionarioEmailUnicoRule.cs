using Domain.Core;
using Domain.SharedKernel;

namespace Domain.Funcionarios
{
    public class FuncionarioEmailUnicoRule : IBusinessRule
    {
        private readonly IFuncionarioEmailEmUsoChecker _emailEmUsoChecker;
        private readonly Email _email;

        public FuncionarioEmailUnicoRule(IFuncionarioEmailEmUsoChecker emailEmUsoChecker, Email email)
        {
            _emailEmUsoChecker = emailEmUsoChecker;
            _email = email;
        }

        public bool IsBroken() => _emailEmUsoChecker.IsEmailEmUso(_email);

        public string Message => Messages.FuncionarioEmailNotAvailable;
    }
}
