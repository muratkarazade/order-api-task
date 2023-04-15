using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Abstractions.Services
{
    public interface ICarrierReportService
    {
        Task<IResult> CreateCarrierReport(CarrierReport carrierReport);
        Task<IResult> UpdateCarrierReport(CarrierReport carrierReport);
        Task<IDataResult<List<CarrierReport>>> GetAllCarrierReport();
        Task<IResult> DeleteCarrierReport(int id);
        Task<CarrierReport> GetCarrierReportById(int id);
    }
}
