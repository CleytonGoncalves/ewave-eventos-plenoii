using System;
using System.Collections.Generic;
using Domain.Core;
using Domain.Palestras.Events;
using Domain.Palestras.Participacoes;
using Domain.Palestras.Rules;
using Domain.Palestras.ValueObjects;
using Domain.SharedKernel;

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

        public Email OrganizadorEmail { get; private set; }

        public string? PalestranteNome { get; private set; }
        public Email? PalestranteEmail { get; private set; }

        public IReadOnlyCollection<Participacao> Participacoes { get; private set; }

        public Palestra(string tema, string titulo, DateTimeOffset dataInicial, TimeSpan duracao, Local local,
            Email organizadorEmail, IColisaoLocalPalestraChecker colisaoLocalChecker)
        {
            Id = new PalestraId();
            Tema = tema;
            Titulo = titulo;
            DataInicial = dataInicial;
            DataFinal = dataInicial + duracao;
            Local = local;
            OrganizadorEmail = organizadorEmail;
            Participacoes = new List<Participacao>();

            CheckRule(new LocalPrecisaEstarDisponivelRule(colisaoLocalChecker, Local, dataInicial, DataFinal));

            Status = StatusPalestra.Planejado;
            AddDomainEvent(new PalestraCriadaEvent(Id));
        }

        public void DefinirPalestrante(string nome, Email email)
        {
            CheckRule(new PalestranteMinimumLengthRule(nome));

            PalestranteNome = nome;
            PalestranteEmail = email;

            AddDomainEvent(new PalestranteDefinidoEvent(Id, PalestranteNome, PalestranteEmail.Value));
        }

        public void ConfirmarPresencaPalestrante()
        {
            Status = StatusPalestra.Confirmado;
            AddDomainEvent(new PalestraConfirmadaEvent(Id));
        }

        #pragma warning disable 8618 // ReSharper disable once NotNullMemberIsNotInitialized UnusedMember.Local
        private Palestra() // Constructor pro EF
        {
        }
        #pragma warning restore 8618
    }
}
