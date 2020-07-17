using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Core;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.Controllers.V2
{
    [ApiVersion("2.0")]
    public class TesteController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(Status200OK)]
        public ActionResult<string> Get()
        {
            return "Testado!";
        }
    }
}
