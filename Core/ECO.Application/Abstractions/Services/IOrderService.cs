using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<IResult> CreateOrder(Order order);
        Task<IResult> UpdateOrder(Order order);
        Task<IDataResult<List<Order>>> GetAllOrders();
        Task<IResult> DeleteOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
}
