using ECO.Application.Abstractions.Services;
using ECO.Application.Repositories.Order;
using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }
        public async Task<IResult> CreateOrder(Order order)
        {
            try
            {
                var added = await _orderWriteRepository.AddAsync(order);
                if (added)
                {
                    await _orderWriteRepository.SaveAsync();
                    return new Result(true, "Sipariş başarıyla oluşturuldu.");
                }
                else
                {
                    return new Result(false, "Sipariş oluşturulamadı.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Sipariş oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateOrder(Order order)
        {
            try
            {
                var updated = _orderWriteRepository.Update(order);
                if (updated)
                {
                    await _orderWriteRepository.SaveAsync();
                    return new Result(true, "Sipariş başarıyla güncellendi.");
                }
                else
                {
                    return new Result(false, "Sipariş güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Sipariş güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Order>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderReadRepository.GetAll().ToListAsync();
                return new DataResult<List<Order>>( orders,true, "Siparişler başarıyla alındı.");
            }
            catch (Exception ex)
            {
                return new DataResult<List<Order>>( null, false, $"Siparişler alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteOrder(Order order)
        {
            try
            {
                var removed = _orderWriteRepository.Remove(order);
                if (removed)
                {
                    await _orderWriteRepository.SaveAsync();
                    return new Result(true, "Sipariş başarıyla silindi.");
                }
                else
                {
                    return new Result(false, "Sipariş silinemedi.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Sipariş silinirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderReadRepository.GetByIdAsync(id);
        }
    }
}
