using ECO.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Commands.Orders.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, CommandBaseResponse>
    {
        private readonly IOrderService _orderService;

        public DeleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CommandBaseResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderById(request.Id);
            if (order == null)
            {
                return new CommandBaseResponse { Success = false, Message = "Sipariş bulunamadı." };
            }

            var result = await _orderService.DeleteOrder(order);
            return new CommandBaseResponse { Success = result.Success, Message = result.Message };
        }
    }
}
