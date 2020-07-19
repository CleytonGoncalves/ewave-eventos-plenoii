﻿using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Core;
using Domain.Funcionarios.Participacoes;

namespace Domain.Palestras
{
    public class Palestra : EntityBase, IAggregateRoot
    {
        public PalestraId Id { get; }

        public string Tema { get; private set; }
        public string Titulo { get; private set; }
        public DateTimeOffset DataInicial { get; private set; }
        public DateTimeOffset DataFinal { get; private set; }
        public StatusPalestra Status { get; private set; }
        public Local Local { get; private set; }

        public string? Palestrante { get; private set; }

        private readonly ICollection<ParticipacaoId> _participacoes = new List<ParticipacaoId>();
        public IReadOnlyCollection<ParticipacaoId> Participacoes => _participacoes.ToList();

        public Palestra(string tema, string titulo, DateTimeOffset dataInicial, DateTimeOffset dataFinal,
            Local local)
        {
            Id = new PalestraId();
            Tema = tema;
            Titulo = titulo;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Local = local;

            Status = StatusPalestra.Planejado;
        }

        #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized UnusedMember.Local
        private Palestra() // Constructor pro EF
        {
        }
        #pragma warning restore 8618
    }
}
