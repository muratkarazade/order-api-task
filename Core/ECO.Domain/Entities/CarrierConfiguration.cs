﻿using ECO.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entities
{
    public class CarrierConfiguration : BaseEntity<int>
    {
        public int MaxDesi { get; set; }
        public int MinDesi { get; set;}
        public decimal CarrierCost { get; set; }
        public int CarrierId { get; set; }
        public  Carrier Carrier { get; set; }
    }
}
