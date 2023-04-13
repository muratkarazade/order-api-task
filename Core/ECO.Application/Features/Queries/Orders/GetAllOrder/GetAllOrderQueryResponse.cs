using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Features.Queries.Orders.GetAllOrder
{
    public class GetAllOrderQueryResponse : IDataResult<List<Order>>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Order> Data { get; set; }
    }
}
