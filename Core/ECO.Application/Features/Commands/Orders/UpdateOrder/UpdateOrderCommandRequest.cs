using ECO.Application.Dto.Order;
using ECO.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandRequest : IRequest<CommandBaseResponse>
    {
        public int Id { get; set; }
        public UpdateOrderDto OrderDto { get; set; }

        public UpdateOrderCommandRequest(int id, UpdateOrderDto orderDto)
        {
            Id = id;
            OrderDto = orderDto;
        }
    }
}
