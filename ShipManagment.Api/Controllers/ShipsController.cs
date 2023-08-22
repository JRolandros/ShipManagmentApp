using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipManagement.Application.Commands;
using ShipManagement.Application.Common;
using ShipManagement.Application.Dtos;
using ShipManagement.Application.Queries;

namespace ShipManagment.Api.Controllers
{
    [Route("api/ships")]
    [ApiController]
    [Authorize]
    public class ShipsController : ControllerBase
    {
        private readonly ILogger<ShipsController> _logger;
        private readonly IMediator _mediator;

        public ShipsController(ILogger<ShipsController> logger, IMediator mediator)
        {
            _logger= logger;
            _mediator = mediator;
        }


        /// <summary>
        /// This a query. a GetShipsQuery. We can request for all ships using no query parameter or we can filter the query by setting parameters in the URL
        /// </summary>
        /// <param name="query">Set of http query parametter. Each property in GetShipsQuery can be a parameter in the URL independantly.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetShipsQuery? query=null)
        {
            List<ShipDto> result;

            try
            {
                if (query == null)
                    query = new GetShipsQuery(); // the query might always be non null so that it can feet the corresponding handler.

                result = await _mediator.Send(query); // this is a call to the handler. specifically to GetShipsQueryHandler. the handler will handle the query and send back the expected result
            }
            catch (ShipManagementException ex) // catch our custom error. If so, we know exactly what happened, we know the error code, the correct message, etc.
            {
                _logger.LogError(ex.Message,ex); //If error log it into the file/Seq/ Db. Here I'm using Serilog file and console to log.

                return StatusCode(ex.ErrorCode); // Then send the status response corresponding to the code sent.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return StatusCode(500); //Here, we don't really know what happened, so it my be related to the server.
            }

            return Ok(result);
        }


        /// <summary>
        /// This is a command, which a request that aims to change something in the database. This one will go for Update a ship
        /// </summary>
        /// <param name="command">A Command that hold the object we have to update</param>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateShipCommand command)
        {
            try
            {
                var result = await _mediator.Send(command); //UpdateShipCommandHandler will be reached after this call.
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


        /// <summary>
        /// This is a Command tha Add a new ship.
        /// </summary>
        /// <param name="command">The command that has to be handled</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddShipCommand command)
        {
            try
            {
                var result = await _mediator.Send(command); //AddShipCommandHandler will be reached after this call.
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


        /// <summary>
        /// This is a Command tha delete an existing ship.
        /// </summary>
        /// <param name="Id">The Id parameter that will be used to create a delete commad</param>
        /// <returns></returns>

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                DeleteShipCommand command = new DeleteShipCommand { Id = Id };

                var result = await _mediator.Send(command); //DeleteShipCommandHandler will be reached after this call.
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
