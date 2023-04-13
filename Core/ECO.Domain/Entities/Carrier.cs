using ECO.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entities
{
    public class Carrier : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int PlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }

        public  CarrierConfiguration CarrierConfiguration { get; set; }
        public  ICollection<Order> Orders { get; set; }
        public  ICollection<CarrierReport> CarrierReports { get; set; }
    }
}
