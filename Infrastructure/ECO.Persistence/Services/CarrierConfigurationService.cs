using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECO.Application.Abstractions.Services;
using ECO.Application.Repositories.CarrierConfiguration;
using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using ECO.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECO.Persistence.Services
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public CarrierConfigurationService(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<IResult> CreateCarrierConfiguration(CarrierConfiguration carrierConfiguration)
        {
            try
            {
                var added = await _carrierConfigurationWriteRepository.AddAsync(carrierConfiguration);
                if (added)
                {
                    await _carrierConfigurationWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı yapılandırması başarıyla oluşturuldu.");
                }
                else
                {
                    return new Result(false, "Taşıyıcı yapılandırması oluşturulamadı.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı yapılandırması oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateCarrierConfiguration(CarrierConfiguration carrierConfiguration)
        {
            try
            {
                var updated = _carrierConfigurationWriteRepository.Update(carrierConfiguration);
                if (updated)
                {
                    await _carrierConfigurationWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı yapılandırması başarıyla güncellendi.");
                }
                else
                {
                    return new Result(false, "Taşıyıcı yapılandırması güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı yapılandırması güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<CarrierConfiguration>>> GetAllCarrierConfiguration()
        {
            try
            {
                var carrierConfigurations = await _carrierConfigurationReadRepository.GetAll().ToListAsync();
                return new DataResult<List<CarrierConfiguration>>(carrierConfigurations, true, "Taşıyıcı yapılandırmaları başarıyla alındı.");
            }
            catch (Exception ex)
            {
                return new DataResult<List<CarrierConfiguration>>(null, false, $"Taşıyıcı yapılandırmaları alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteCarrierConfiguration(int id)
        {
            try
            {
                var carrierConfiguration = await _carrierConfigurationReadRepository.GetByIdAsync(id);
                if (carrierConfiguration == null)
                {
                    return new Result(false, "Taşıyıcı yapılandırması bulunamadı.");
                }

                var removed = _carrierConfigurationWriteRepository.Remove(carrierConfiguration);
                if (removed)
                {
                    await _carrierConfigurationWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı yapılandırması başarıyla silindi.");
                }
                else
                {
                    return new Result(false, "Taşıyıcı yapılandırması silinemedi.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı yapılandırması silinirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<CarrierConfiguration> GetCarrierConfigurationById(int id)
        {
            return await _carrierConfigurationReadRepository.GetByIdAsync(id);
        }
    }
}



