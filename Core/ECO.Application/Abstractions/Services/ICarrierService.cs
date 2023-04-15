using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Abstractions.Services
{
    public interface ICarrierService
    {
        Task<IResult> CreateCarrier(Carrier carrier);
        Task<IResult> UpdateCarrier(Carrier carrier);
        Task<IDataResult<List<Carrier>>> GetAllCarrier();
        Task<IResult> DeleteCarrier(int id);
        Task<Carrier> GetCarrierById(int id);
        Task<Carrier> GetCarrierByDesi(int desi);
        Task<Carrier> GetClosestCarrierByDesi(int desi);
    }
}
