using Domain.Core;
using Domain.Funcionarios.Events;
using Domain.SharedKernel;

namespace Domain.Funcionarios
{
    public class Funcionario : EntityBase, IAggregateRoot
    {
        public FuncionarioId Id { get; }

        public string Nome { get; set; }
        public Email Email { get; set; }

        public Email? SuperiorEmail { get; set; }
        public bool RequerConfirmacaoSuperior => SuperiorEmail != null;

        public Funcionario(string nome, Email email, Email? superiorEmail,
            IFuncionarioEmailEmUsoChecker emailEmUsoChecker)
        {
            Id = new FuncionarioId();
            Nome = nome;
            Email = email;
            SuperiorEmail = superiorEmail;

            CheckRule(new FuncionarioEmailUnicoRule(emailEmUsoChecker, Email));

            AddDomainEvent(new FuncionarioCriadoEvent(Id));
        }

        #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized UnusedMember.Local
        private Funcionario() // Constructor pro EF
        {
        }
        #pragma warning restore 8618
    }
}
