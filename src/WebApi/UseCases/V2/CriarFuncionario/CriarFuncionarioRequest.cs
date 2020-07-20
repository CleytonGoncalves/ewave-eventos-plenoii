using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.V2.CriarFuncionario
{
    public sealed class CriarFuncionarioRequest
    {
        [Required]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [EmailAddress]
        public string? SuperiorEmail { get; set; }

        public CriarFuncionarioRequest(string nome, string email, string? superiorEmail)
        {
            Nome = nome;
            Email = email;
            SuperiorEmail = superiorEmail;
        }
    }
}
