using System;
using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;

#pragma warning disable // Controller apenas de teste
namespace WebApi.UseCases.V1
{
    [ApiVersion("1.0")]
    public class MetaController : ApiControllerBase
    {
        /// <summary> Produz erro 400 - Bad Request </summary>
        [HttpGet("400")]
        [ProducesResponseType(Status400BadRequest)]
        public IActionResult Get400()
        {
            ModelState.AddModelError("field1", "reason for failure1");
            ModelState.AddModelError("field1", "reason for failure2");
            ModelState.AddModelError("field2", "reason for failure1");

            return ValidationProblem();
        }

        /// <summary> Produz erro 401 - Unauthorized </summary>
        [HttpGet("401")]
        [ProducesResponseType(Status401Unauthorized)]
        public IActionResult Get401() => Unauthorized();

        /// <summary> Produz erro 403 - Forbidden </summary>
        [HttpGet("403")]
        [ProducesResponseType(Status403Forbidden)]
        public IActionResult Get403() => Forbid();

        /// <summary> Produz erro 404 - Not Found </summary>
        [HttpGet("404")]
        [ProducesResponseType(Status404NotFound)]
        public IActionResult Get404() => NotFound();

        /// <summary> Produz erro 500 - Internal Server Error </summary>
        [HttpGet("500")]
        [ProducesResponseType(Status500InternalServerError)]
        public IActionResult Get500() => throw new Exception("Erro gerado intencionalmente p/ teste");

        /// <summary> Produz erro de <see cref="IBusinessRule"/> </summary>
        [HttpGet("DomainBusinessRuleError")]
        public IActionResult GetDomainBusinessRuleError() => throw new BusinessRuleValidationException(new TesteBusinessRule());

        private class TesteBusinessRule : IBusinessRule
        {
            public bool IsBroken() => true;
            public string Message => "Erro gerado intencionalmente p/ teste";
        }
    }
}
#pragma warning restore
