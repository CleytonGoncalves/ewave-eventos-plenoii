using System;
using System.Threading.Tasks;
using Application.Funcionarios;
using Application.Palestras.BuscarDetalhesPalestra;
using Domain.Palestras.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.UseCases.V2.BuscarDetalhesPalestra
{
    [ApiVersion("2.0")]
    public class PalestraController : ApiControllerBase
    {
        [HttpGet("{palestraId:Guid}/detalhes")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult<FuncionarioDto>> BuscarDetalhesPalestra([FromServices] IMediator mediator,
            Guid palestraId)
        {
            var result = await mediator.Send(new BuscarDetalhesPalestraQuery(new PalestraId(palestraId)));

            return Ok(result);
        }
    }
}
