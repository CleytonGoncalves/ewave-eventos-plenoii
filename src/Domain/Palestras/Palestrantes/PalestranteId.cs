using System;
using Domain.Core;

namespace Domain.Palestras.Palestrantes
{
    public class PalestranteId : TypedIdBase
    {
        public PalestranteId(Guid value) : base(value)
        {
        }

        public PalestranteId()
        {
        }
    }
}
