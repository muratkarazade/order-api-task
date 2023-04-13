using ECO.Application.Abstractions.Services;
using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Orders.GetAllOrder
{
    public class GetAllOrderQueryHandle : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        private readonly IOrderService _orderService;
        public GetAllOrderQueryHandle(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllOrders();
            return new GetAllOrderQueryResponse
            {
                Success = result.Success,
                Message = result.Message,
                Data = result.Data
            };
        }
    }
}

