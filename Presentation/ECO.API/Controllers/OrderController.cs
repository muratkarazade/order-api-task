using ECO.Application.Dto.Order;
using ECO.Application.Features.Commands.Orders.CreateOrder;
using ECO.Application.Features.Commands.Orders.DeleteOrder;
using ECO.Application.Features.Commands.Orders.UpdateOrder;
using ECO.Application.Features.Queries.Orders.GetAllOrder;
using ECO.Application.Features.Queries.Orders.GetByIdOrder;
using ECO.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            var result = await _mediator.Send(new CreateOrderCommandRequest(orderDto));
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDto orderDto)
        {
            var result = await _mediator.Send(new UpdateOrderCommandRequest(id, orderDto));
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrderQueryRequest());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQueryRequest(id));
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommandRequest(id));
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
