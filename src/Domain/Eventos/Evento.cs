﻿using Domain.Core;

namespace Domain.Eventos
{
    public class Evento : EntityBase
    {
        public EventoId Id { get; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusEvento Status { get; set; }

        public Evento(string titulo, string descricao, StatusEvento status)
        {
            Id = new EventoId();
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
        }

        #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized UnusedMember.Local
        private Evento() // Constructor pro EF
        {
        }
        #pragma warning restore 8618
    }
}
