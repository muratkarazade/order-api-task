using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Dto.Carrier
{
    public class CreateCarrierDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int PlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }
        public int MaxDesi { get; set; }
        public int MinDesi { get; set; }
        public decimal CarrierCost { get; set; }

    }
}
