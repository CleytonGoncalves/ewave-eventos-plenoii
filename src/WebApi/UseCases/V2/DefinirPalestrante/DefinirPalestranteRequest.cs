using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.V2.DefinirPalestrante
{
    public sealed class DefinirPalestranteRequest
    {
        [Required]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DefinirPalestranteRequest(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
