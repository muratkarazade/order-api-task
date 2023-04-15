using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECO.Application.Abstractions.Services;
using ECO.Application.Repositories.CarrierReport;
using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using ECO.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECO.Persistence.Services
{
    public class CarrierReportService : ICarrierReportService
    {
        private readonly ICarrierReportReadRepository _carrierReportReadRepository;
        private readonly ICarrierReportWriteRepository _carrierReportWriteRepository;

        public CarrierReportService(ICarrierReportReadRepository carrierReportReadRepository, ICarrierReportWriteRepository carrierReportWriteRepository)
        {
            _carrierReportReadRepository = carrierReportReadRepository;
            _carrierReportWriteRepository = carrierReportWriteRepository;
        }

        public async Task<IResult> CreateCarrierReport(CarrierReport carrierReport)
        {
            try
            {
                var added = await _carrierReportWriteRepository.AddAsync(carrierReport);
                if (added)
                {
                    await _carrierReportWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı raporu başarıyla oluşturuldu.");
                }
                else
                {
                    return new Result(false, "Taşıyıcı raporu oluşturulamadı.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı raporu oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateCarrierReport(CarrierReport carrierReport)
        {
            try
            {
                var updated = _carrierReportWriteRepository.Update(carrierReport);
                if (updated)
                {
                    await _carrierReportWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı raporu başarıyla güncellendi.");
                }
                else
                {
                    return new Result(false, "Taşıyıcı raporu güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı raporu güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<CarrierReport>>> GetAllCarrierReport()
        {
            try
            {
                var carrierReports = await _carrierReportReadRepository.GetAll().ToListAsync();
                return new DataResult<List<CarrierReport>>(carrierReports, true, "Taşıyıcı raporları başarıyla alındı.");
            }
            catch (Exception ex)
            {
                return new DataResult<List<CarrierReport>>(null, false, $"Taşıyıcı raporları alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteCarrierReport(int id)
        {
            try
            {
                var carrierReport = await _carrierReportReadRepository.GetByIdAsync(id);
                if (carrierReport == null)
                {
                    return new Result(false, "Taşıyıcı raporu bulunamadı.");
                }

                var removed = _carrierReportWriteRepository.Remove(carrierReport);
                if (removed)
                {
                    await _carrierReportWriteRepository.SaveAsync();
                    return new Result(true, "Taşıyıcı raporu silinemedi.");
                     }
                else
                {
                    return new Result(false, "Taşıyıcı raporu silinemedi.");
                }
            }
            catch (Exception ex)
            {
                return new Result(false, $"Taşıyıcı raporu silinirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<CarrierReport> GetCarrierReportById(int id)
        {
            return await _carrierReportReadRepository.GetByIdAsync(id);
        }      
    }
}