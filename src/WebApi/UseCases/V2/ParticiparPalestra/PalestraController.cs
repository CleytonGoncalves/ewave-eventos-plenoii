using System;
using System.Threading.Tasks;
using Application.Palestras.ParticiparPalestra;
using Domain.Funcionarios;
using Domain.Palestras.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.UseCases.V2.ParticiparPalestra
{
    [ApiVersion("2.0")]
    public class PalestraController : ApiControllerBase
    {
        [HttpPut("{palestraId:Guid}/participar")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult> Participar([FromServices] IMediator mediator,
            [FromRoute] Guid palestraId, ParticiparPalestraRequest request)
        {
            await mediator.Send(new ParticiparPalestraCommand(new PalestraId(palestraId),
                new FuncionarioId(request.FuncionarioId)));

            return Ok();
        }
    }
}
