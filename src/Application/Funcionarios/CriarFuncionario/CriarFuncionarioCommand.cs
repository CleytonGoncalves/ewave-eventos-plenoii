using Domain.SharedKernel;
using MediatR;

namespace Application.Funcionarios.CriarFuncionario
{
    public sealed class CriarFuncionarioCommand : IRequest<FuncionarioDto>
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Email? SuperiorEmail { get; private set; }

        public CriarFuncionarioCommand(string nome, Email email, Email? superiorEmail)
        {
            Nome = nome;
            Email = email;
            SuperiorEmail = superiorEmail;
        }
    }
}
