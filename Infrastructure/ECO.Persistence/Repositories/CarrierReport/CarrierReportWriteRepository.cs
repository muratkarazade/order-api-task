using ECO.Application.Repositories.CarrierReport;
using ECO.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.Repositories.CarrierReport
{
    public class CarrierReportWriteRepository : WriteRepository<Domain.Entities.CarrierReport, int>, ICarrierReportWriteRepository
    {
        public CarrierReportWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
