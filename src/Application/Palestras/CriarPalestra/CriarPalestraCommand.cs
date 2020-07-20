using System;
using Domain.Palestras.ValueObjects;
using Domain.SharedKernel;
using MediatR;

namespace Application.Palestras.CriarPalestra
{
    public sealed class CriarPalestraCommand : IRequest<PalestraDto>
    {
        public string Tema { get; private set; }
        public string Titulo { get; private set; }
        public DateTimeOffset DataInicial { get; private set; }
        public TimeSpan Duracao { get; private set; }
        public Local Local { get; private set; }
        public Email OrganizadorEmail { get; private set; }

        public CriarPalestraCommand(string tema, string titulo, DateTimeOffset dataInicial, TimeSpan duracao,
            Local local, Email organizadorEmail)
        {
            Tema = tema;
            Titulo = titulo;
            DataInicial = dataInicial;
            Duracao = duracao;
            Local = local;
            OrganizadorEmail = organizadorEmail;
        }
    }
}
