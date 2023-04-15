using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Dto.CarrierConfiguration
{
    public class UpdateCarrierConfigurationDto
    {
        public int Id { get; set; }
        public int MaxDesi { get; set; }
        public int MinDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}
