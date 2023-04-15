using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Dto.CarrierConfiguration
{
    public class CarrierConfigurationData
    {
        public int MinDesi { get; set; }
        public int MaxDesi { get; set; }
        public decimal CarrierCost { get; set; }
        public decimal PlusDesiCost { get; set; }
        public Domain.Entities.Carrier Carrier { get; set; }
    }
}
