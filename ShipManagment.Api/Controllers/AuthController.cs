using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipManagement.Application.Common;
using ShipManagement.Application.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShipManagment.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthenticateQuery query)
        {
            try
            {
                var result = await _mediator.Send(query); //AuthenticateQueryHandler will be reached after this call.
                return Ok(result);
            }
            catch (ShipManagementException ex) // catch our custom error. If so, we know exactly what happened, we know the error code, the correct message, etc.
            {
                _logger.LogError(ex.Message, ex); //If error log it into the file/Seq/ Db. Here I'm using Serilog file and console to log.

                return StatusCode(ex.ErrorCode); // Then send the status response corresponding to the code sent.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return StatusCode(500); //Here, we don't really know what happened, so it my be related to the server.
            }
        }
    }
}
