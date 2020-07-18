using Domain.Core;

namespace Domain.Palestras.Palestrantes
{
    public class Palestrante : EntityBase
    {
        internal PalestranteId Id { get; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Palestrante(string nome, string descricao)
        {
            Id = new PalestranteId();
            Nome = nome;
            Descricao = descricao;
        }

        #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized UnusedMember.Local
        private Palestrante() // Constructor pro EF
        {
        }
        #pragma warning restore 8618
    }
}
