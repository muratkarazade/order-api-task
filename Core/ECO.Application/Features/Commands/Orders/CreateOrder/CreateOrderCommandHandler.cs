using AutoMapper;
using ECO.Application.Abstractions.Services;
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
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderService _orderService;
        readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = _mapper.Map<Order>(request.Order);
            var result = await _orderService.CreateOrder(order);
            if (!result.Success)
            {
                return new CreateOrderCommandResponse { Success = false, Message = result.Message };
            }

            return new CreateOrderCommandResponse { Success = true, Message = result.Message, Data = result };
        }
    }
}
