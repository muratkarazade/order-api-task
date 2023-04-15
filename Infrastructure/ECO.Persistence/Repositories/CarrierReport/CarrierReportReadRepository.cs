using ECO.Application.Repositories.CarrierReport;
using ECO.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.Repositories.CarrierReport
{
    public class CarrierReportReadRepository : ReadRepository<Domain.Entities.CarrierReport, int>, ICarrierReportReadRepository
    {
        public CarrierReportReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
