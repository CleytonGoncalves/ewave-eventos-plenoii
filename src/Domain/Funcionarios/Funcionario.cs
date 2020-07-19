using System.Collections.Generic;
using System.Linq;
using Domain.Core;
using Domain.Funcionarios.Participacoes;

namespace Domain.Funcionarios
{
    public class Funcionario : EntityBase, IAggregateRoot
    {
        public FuncionarioId Id { get; }

        public string Nome { get; set; }
        public string Email { get; set; }

        public Funcionario? Superior { get; set; }
        public bool RequerConfirmacaoSuperior { get; set; }

        private readonly ICollection<Participacao> _participacoes = new List<Participacao>();
        public IReadOnlyCollection<Participacao> Participacoes => _participacoes.ToList();

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
