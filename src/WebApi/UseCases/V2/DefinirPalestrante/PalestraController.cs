using System;
using System.Threading.Tasks;
using Application.Palestras.DefinirPalestrante;
using Domain.Palestras.ValueObjects;
using Domain.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.UseCases.V2.DefinirPalestrante
{
    [ApiVersion("2.0")]
    public class PalestraController : ApiControllerBase
    {
        [HttpPost("{palestraId:Guid}/palestrante")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult> DefinirPalestrante([FromServices] IMediator mediator,
            [FromRoute] Guid palestraId, DefinirPalestranteRequest request)
        {
            await mediator.Send(new DefinirPalestranteCommand(new PalestraId(palestraId),
                request.Nome, new Email(request.Email)));

            return Ok();
        }
    }
}
