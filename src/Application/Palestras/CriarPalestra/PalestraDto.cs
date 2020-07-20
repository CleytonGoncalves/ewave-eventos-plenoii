using System;

namespace Application.Palestras.CriarPalestra
{
    public sealed class PalestraDto
    {
        public Guid Id { get; }

        public PalestraDto(Guid id)
        {
            Id = id;
        }
    }
}
