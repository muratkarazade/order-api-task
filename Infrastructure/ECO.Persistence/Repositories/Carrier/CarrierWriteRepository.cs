using ECO.Application.Repositories;
using ECO.Application.Repositories.Carrier;
using ECO.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.Repositories.Carrier
{
    public class CarrierWriteRepository : WriteRepository<Domain.Entities.Carrier, int>, ICarrierWriteRepository
    {
        public CarrierWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
