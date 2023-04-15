using System.Collections.Generic;
using System.Threading.Tasks;
using ECO.Application.Dto.CarrierConfiguration;
using ECO.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using ECO.Application.Features.Commands.CarrierConfiguration.DeleteCarrierConfiguration;
using ECO.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using ECO.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration;
using ECO.Application.Features.Queries.CarrierConfiguration.GetCarrierConfigurationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrierConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarrierConfiguration()
        {
            var query = new GetAllCarrierConfigurationQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrierConfigurationById(int id)
        {
            var query = new GetCarrierConfigurationByIdQueryRequest(id);
            var result = await _mediator.Send(query);
            return result.Success ? Ok(result) : NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrierConfiguration([FromBody] CreateCarrierConfigurationDto carrierConfigurationDto)
        {
            var command = new CreateCarrierConfigurationCommandRequest(carrierConfigurationDto);
            var result = await _mediator.Send(command);
            return result.Success ? CreatedAtAction(nameof(GetCarrierConfigurationById), new { id = result.CarrierConfiguration.Id }, result.Data) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarrierConfiguration(int id, [FromBody] UpdateCarrierConfigurationDto carrierConfigurationDto)
        {
            if (id != carrierConfigurationDto.Id)
            {
                return BadRequest("ID'ler eşleşmiyor.");
            }

            var command = new UpdateCarrierConfigurationCommandRequest(id, carrierConfigurationDto);
            var result = await _mediator.Send(command);
            return result.Success ? NoContent() : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrierConfiguration(int id)
        {
            var command = new DeleteCarrierConfigurationCommandRequest(id);
            var result = await _mediator.Send(command);
            return result.Success ? NoContent() : BadRequest(result.Message);
        }
    }
}
