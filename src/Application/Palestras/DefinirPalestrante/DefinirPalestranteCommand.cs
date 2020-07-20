using Domain.Palestras.ValueObjects;
using Domain.SharedKernel;
using MediatR;

namespace Application.Palestras.DefinirPalestrante
{
    public sealed class DefinirPalestranteCommand : IRequest<PalestraDto>
    {
        public PalestraId PalestraId { get; set; }

        public string Nome { get; private set; }
        public Email Email { get; private set; }

        public DefinirPalestranteCommand(PalestraId palestraId, string nome, Email email)
        {
            PalestraId = palestraId;
            Nome = nome;
            Email = email;
        }
    }
}
