using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Abstractions.Services
{
    public interface ICarrierConfigurationService
    {
        Task<IResult> CreateCarrierConfiguration(CarrierConfiguration carrierConfiguration);
        Task<IResult> UpdateCarrierConfiguration(CarrierConfiguration carrierConfiguration);
        Task<IDataResult<List<CarrierConfiguration>>> GetAllCarrierConfiguration();
        Task<IResult> DeleteCarrierConfiguration(int id);
        Task<CarrierConfiguration> GetCarrierConfigurationById(int id);
    }
}
