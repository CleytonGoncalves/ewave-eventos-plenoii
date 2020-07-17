using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.Controllers.Core
{
    /// Base class for a versioned API controller
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json", "application/problem+json")]
    [ProducesResponseType(Status500InternalServerError)]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
