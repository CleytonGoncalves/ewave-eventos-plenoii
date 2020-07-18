using System;
using Domain.Core;

namespace Domain.Eventos
{
    public class EventoId : TypedIdBase
    {
        public EventoId(Guid value) : base(value)
        {
        }

        public EventoId()
        {
        }
    }
}
