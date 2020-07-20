using Domain.SharedKernel;

namespace Domain.Funcionarios
{
    public interface IFuncionarioEmailEmUsoChecker
    {
        bool IsEmailEmUso(Email email);
    }
}
