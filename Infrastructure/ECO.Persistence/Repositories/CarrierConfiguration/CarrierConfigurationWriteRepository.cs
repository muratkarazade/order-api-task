using ECO.Application.Repositories.CarrierConfiguration;
using ECO.Domain.Entities;
using ECO.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.Repositories.CarrierConfiguration
{
    public class CarrierConfigurationWriteRepository : WriteRepository<Domain.Entities.CarrierConfiguration, int>, ICarrierConfigurationWriteRepository
    {
        public CarrierConfigurationWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
