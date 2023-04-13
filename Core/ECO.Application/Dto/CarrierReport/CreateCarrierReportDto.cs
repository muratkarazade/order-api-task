using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Dto.CarrierReport
{
    public class CreateCarrierReportDto
    {
        public decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; }
    }
}
