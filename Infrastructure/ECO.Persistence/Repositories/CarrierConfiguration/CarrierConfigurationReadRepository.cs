using ECO.Application.Repositories.CarrierConfiguration;
using ECO.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.Repositories.CarrierConfiguration
{
    public class CarrierConfigurationReadRepository : ReadRepository<Domain.Entities.CarrierConfiguration, int>, ICarrierConfigurationReadRepository
    {
        public CarrierConfigurationReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
