using System;

namespace Application.Palestras
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
