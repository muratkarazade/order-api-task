using ECO.Application.Dto.Order;
using ECO.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public CreateOrderDto Order { get; set; }

        public CreateOrderCommandRequest(CreateOrderDto order)
        {
            Order = order;
        }
    }
}