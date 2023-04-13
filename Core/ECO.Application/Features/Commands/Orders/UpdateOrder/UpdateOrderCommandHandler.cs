using AutoMapper;
using ECO.Application.Abstractions.Services;
using ECO.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, CommandBaseResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<CommandBaseResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var existingOrder = await _orderService.GetOrderById(request.Id);
            if (existingOrder == null)
            {
                return new CommandBaseResponse { Success = false, Message = "Order not found" };
            }

            _mapper.Map(request.OrderDto, existingOrder);
            var result = await _orderService.UpdateOrder(existingOrder);
            return new CommandBaseResponse { Success = result.Success, Message = result.Message };
        }

    }
}
