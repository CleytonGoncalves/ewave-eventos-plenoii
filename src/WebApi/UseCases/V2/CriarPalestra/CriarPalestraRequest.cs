using System;
using System.ComponentModel.DataAnnotations;
using Domain.Palestras.ValueObjects;

namespace WebApi.UseCases.V2.CriarPalestra
{
    public sealed class CriarPalestraRequest
    {
        [Required]
        [MinLength(3)]
        public string Tema { get; set; }

        [Required]
        [MinLength(3)]
        public string Titulo { get; set; }

        [Required]
        public DateTimeOffset DataInicial { get; set; }

        [Required]
        public TimeSpan Duracao { get; set; }

        [Required]
        public Local Local { get; set; }

        [Required]
        [EmailAddress]
        public string OrganizadorEmail { get; set; }

        public CriarPalestraRequest(string tema, string titulo, DateTimeOffset dataInicial, TimeSpan duracao,
            Local local, string organizadorEmail)
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
