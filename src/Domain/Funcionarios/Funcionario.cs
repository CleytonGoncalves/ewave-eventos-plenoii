using System;
using Domain.Core;

namespace Domain.Funcionarios
{
    public class Funcionario : EntityBase, IAggregateRoot
    {
        public FuncionarioId Id { get; }

        public string Nome { get; set; }
        public string Email { get; set; }

        public FuncionarioId? Superior { get; set; }
        public bool RequerConfirmacaoSuperior { get; set; }

        public Funcionario(string nome, string email)
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
