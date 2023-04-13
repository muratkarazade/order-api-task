using ECO.Application.Abstractions.Services;
using ECO.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Orders.GetByIdOrder
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
    {
        private readonly IOrderService _orderService;

        public GetOrderByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderById(request.Id);

            return new GetOrderByIdQueryResponse
            {
                Success = order != null,
                Message = order != null ? "Order found" : "Order not found",
                Data = order
            };
        }
    }
}
