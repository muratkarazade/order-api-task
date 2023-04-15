using ECO.Application.Features.Commands.Carrier.CreateCarriers;
using ECO.Application.Features.Commands.Carrier.DeleteCarrier;
using ECO.Application.Features.Commands.Carrier.UpdateCarrier;
using ECO.Application.Features.Queries.Carrier.GetAllCarrier;
using ECO.Application.Features.Queries.Carrier.GetCarrierById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllCarrierQueryResponse>> GetAllCarriers()
        {
            var query = new GetAllCarrierQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarrierByIdQueryResponse>> GetCarrierById(int id)
        {
            var query = new GetCarrierByIdQueryRequest { Id = id };
            var result = await _mediator.Send(query);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCarrierCommandResponse>> CreateCarrier([FromBody] CreateCarrierCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(GetCarrierById), new { id = result.Data.Id }, result.Data);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateCarrier([FromBody] UpdateCarrierCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarrier(int id)
        {
            var command = new DeleteCarrierCommandRequest { Id = id };
            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
