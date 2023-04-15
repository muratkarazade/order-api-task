﻿using ECO.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }
        public int CarrierId { get; set; }
        public  Carrier Carrier { get; set; }
    }
}
