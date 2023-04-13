using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Repositories.CarrierReport
{
    public interface ICarrierReportWriteRepository : IWriteRepository<Domain.Entities.CarrierReport, int>
    {
    }
}
