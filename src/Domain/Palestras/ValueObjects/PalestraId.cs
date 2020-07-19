using System;
using Domain.Core;

namespace Domain.Palestras.ValueObjects
{
    public class PalestraId : TypedIdBase
    {
        public PalestraId(Guid value) : base(value)
        {
        }

        public PalestraId()
        {
        }
    }
}
