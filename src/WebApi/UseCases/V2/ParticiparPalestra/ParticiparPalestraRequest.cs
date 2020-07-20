using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.V2.ParticiparPalestra
{
    public sealed class ParticiparPalestraRequest
    {
        [Required]
        public Guid FuncionarioId { get; set; }

        public ParticiparPalestraRequest(Guid funcionarioId)
        {
            FuncionarioId = funcionarioId;
        }
    }
}
