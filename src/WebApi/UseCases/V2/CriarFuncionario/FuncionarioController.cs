using System.Threading.Tasks;
using Application.Funcionarios.CriarFuncionario;
using Application.Palestras;
using Domain.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.UseCases.V2.CriarFuncionario
{
    [ApiVersion("2.0")]
    public class FuncionarioController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult<PalestraDto>> CriarFuncionario([FromServices] IMediator mediator,
            CriarFuncionarioRequest request)
        {
            var result = await mediator.Send(new CriarFuncionarioCommand(request.Nome, new Email(request.Email),
                request.SuperiorEmail != null ? new Email(request.SuperiorEmail) : (Email?) null));

            return Ok(result);
        }
    }
}
