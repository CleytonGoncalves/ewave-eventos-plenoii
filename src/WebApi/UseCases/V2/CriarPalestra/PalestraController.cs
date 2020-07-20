using System.Threading.Tasks;
using Application.Palestras;
using Application.Palestras.CriarPalestra;
using Domain.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.UseCases.V2.CriarPalestra
{
    [ApiVersion("2.0")]
    public class PalestraController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult<PalestraDto>> CriarPalestra([FromServices] IMediator mediator,
            CriarPalestraRequest request)
        {
            var result = await mediator.Send(new CriarPalestraCommand(request.Tema, request.Titulo,
                request.DataInicial, request.Duracao, request.Local, new Email(request.OrganizadorEmail)));

            return Ok(result);
        }
    }
}
