using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECO.Persistence.Repositories;
using global::ECO.Application.Abstractions.Services;
using global::ECO.Application.Repositories.Carrier;
using global::ECO.Application.Utilities.Result.Common;
using global::ECO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECO.Persistence.Services
{
    public class CarrierService : ICarrierService
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;

        public CarrierService(ICarrierReadRepository carrierReadRepository, ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
        }

        public async Task<IResult> CreateCarrier(Carrier carrier)
        {
            try
            {
                var added = await _carrierWriteRepository.AddAsync(carrier);
                if (added)
                {
                    await _carrierWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı başarıyla oluşturuldu.");
                }
                else
                {
                    return new Result(false, "Taşıyıcı oluşturulamadı.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateCarrier(Carrier carrier)
        {
            try
            {
                var updated = _carrierWriteRepository.Update(carrier);
                if (updated)
                {
                    await _carrierWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı başarıyla güncellendi.");
                }
                else
                {
                    return new Result(false, "Taşıyıcı güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Carrier>>> GetAllCarrier()
        {
            try
            {
                var carriers = await _carrierReadRepository.GetAll().ToListAsync();
                return new DataResult<List<Carrier>>(carriers, true, "Taşıyıcılar başarıyla alındı.");
            }
            catch (Exception ex)
            {
                return new DataResult<List<Carrier>>(null, false, $"Taşıyıcılar alınırken bir hata oluştu: {ex.Message}");
            }
        }

       

        public async Task<Carrier> GetCarrierById(int id)
        {
            return await _carrierReadRepository.GetByIdAsync(id);
        }

        public async Task<IResult> DeleteCarrier(int id)
        {
            try
            {
                var carrier = await _carrierReadRepository.GetByIdAsync(id);
                if (carrier == null)
                {
                    return new Result(false, "Taşıyıcı bulunamadı.");
                }

                var removed = _carrierWriteRepository.Remove(carrier);
                if (removed)
                {
                    await _carrierWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı başarıyla silindi.");
                }
                else
                {
                    return new Result(false, "Taşıyıcı silinemedi.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı silinirken bir hata oluştu: {ex.Message}");
            }
        }

        public Task<Carrier> GetCarrierByDesi(int desi)
        {
            throw new NotImplementedException();
        }

        public Task<Carrier> GetClosestCarrierByDesi(int desi)
        {
            throw new NotImplementedException();
        }
       
    }
} 
