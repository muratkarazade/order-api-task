using ECO.Domain.Entities;
using ECO.Persistence.ConfigurationMap.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.ConfigurationMap
{
    public class OrderMap : BaseMap<Order,int>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.OrderDesi).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.OrderCarrierCost).IsRequired();
            builder.Property(x => x.CarrierId).IsRequired();

            builder.HasOne(x => x.Carrier)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CarrierId);
        }
    }
}
