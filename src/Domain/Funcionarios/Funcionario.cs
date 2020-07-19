using Domain.Core;
using Domain.SharedKernel;

namespace Domain.Funcionarios
{
    public class Funcionario : EntityBase, IAggregateRoot
    {
        public FuncionarioId Id { get; }

        public string Nome { get; set; }
        public Email Email { get; set; }

        public Funcionario? Superior { get; set; }
        public bool RequerConfirmacaoSuperior { get; set; }

        public Funcionario(string nome, Email email)
        {
            Id = new FuncionarioId();
            Nome = nome;
            Email = email;
        }

        #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized UnusedMember.Local
        private Funcionario() // Constructor pro EF
        {
        }
        #pragma warning restore 8618
    }
}
