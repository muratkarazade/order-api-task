using ECO.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entities
{
    public class CarrierReport : BaseEntity<int>
    {
        public decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; }
        public int CarrierId { get; set; }
        public  Carrier Carrier { get; set; }
    }
}
