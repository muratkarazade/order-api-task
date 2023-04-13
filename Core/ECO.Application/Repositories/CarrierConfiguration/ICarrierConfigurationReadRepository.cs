using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Repositories.CarrierConfiguration
{
    public interface ICarrierConfigurationReadRepository : IReadRepository<Domain.Entities.CarrierConfiguration, int>
    {
    }
}
