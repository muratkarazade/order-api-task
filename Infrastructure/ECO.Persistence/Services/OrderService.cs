using ECO.Application.Abstractions.Services;
using ECO.Application.Dto.CarrierConfiguration;
using ECO.Application.Repositories.Carrier;
using ECO.Application.Repositories.CarrierConfiguration;
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
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        public OrderService(IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICarrierReadRepository carrierReadRepository,
            ICarrierWriteRepository carrierWriteRepository,
            ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }


        public async Task<IResult> CreateOrder(Order order)
        {
            try
            {
                var carrierConfigData = await GetCarrierConfigurationData(order.OrderDesi);

                if (carrierConfigData == null)
                {
                    return new Result(false, "Uygun taşıyıcı bulunamadı.");
                }

                if (carrierConfigData.MinDesi <= order.OrderDesi && carrierConfigData.MaxDesi >= order.OrderDesi)
                {
                    order.OrderCarrierCost = carrierConfigData.CarrierCost;
                }
                else
                {
                    var extraDesi = order.OrderDesi - carrierConfigData.MaxDesi;
                    order.OrderCarrierCost = carrierConfigData.CarrierCost + (extraDesi * carrierConfigData.PlusDesiCost);
                }
                order.CarrierId = carrierConfigData.Carrier.Id;
                var added = await _orderWriteRepository.AddAsync(order);
                if (added)
                {
                    await _orderWriteRepository.SaveAsync();
                    return new Result(true, $"Sipariş başarıyla oluşturuldu.");
                }
                else
                {
                    return new Result(false, "Sipariş oluşturulamadı.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Sipariş oluşturulurken bir hata oluştu:/* {ex.Message} - InnerException: {ex.InnerException?.Message}*/");
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

        public Task<Carrier> GetCarrierByDesi(int desi)
        {
            throw new NotImplementedException();
        }

        public Task<Carrier> GetClosestCarrierByDesi(int desi)
        {
            throw new NotImplementedException();
        }



        public async Task<CarrierConfigurationData> GetCarrierConfigurationData(int orderDesi)
        {
            var carrierConfigs = _carrierConfigurationReadRepository.GetAll()
                                        .Include(cc => cc.Carrier);

            // Önce aralıkta kalan kayıtları filtrele ve en düşük maliyetli olanı seç
            var bestCarrierConfig = await carrierConfigs
                .Where(c => c.MinDesi <= orderDesi && c.MaxDesi >= orderDesi)
                .OrderBy(c => c.CarrierCost)
                .FirstOrDefaultAsync();

            // Eğer uygun bir kayıt bulamazsan, siparişin desi değerine en yakın olan kargo firmasını seç
            if (bestCarrierConfig == null)
            {
                bestCarrierConfig = await carrierConfigs
                    .OrderBy(c => Math.Abs(c.MinDesi - orderDesi))
                    .ThenBy(c => Math.Abs(c.MaxDesi - orderDesi))
                    .FirstOrDefaultAsync();
            }

            if (bestCarrierConfig != null)
            {
                return new CarrierConfigurationData
                {
                    MinDesi = bestCarrierConfig.MinDesi,
                    MaxDesi = bestCarrierConfig.MaxDesi,
                    CarrierCost = bestCarrierConfig.CarrierCost,
                    PlusDesiCost = bestCarrierConfig.Carrier.PlusDesiCost,
                    Carrier = bestCarrierConfig.Carrier
                };
            }

            return null;
        }

    }
}
