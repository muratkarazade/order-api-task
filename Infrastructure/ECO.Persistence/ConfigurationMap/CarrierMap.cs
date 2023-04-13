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
    public class CarrierMap : BaseMap<Carrier,int>
    {
        public override void Configure(EntityTypeBuilder<Carrier> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.PlusDesiCost).IsRequired();
            builder.Property(x => x.CarrierConfigurationId).IsRequired();

            builder.HasOne(x => x.CarrierConfiguration)
                .WithOne(x => x.Carrier)
                .HasForeignKey<Carrier>(x => x.CarrierConfigurationId);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Carrier)
                .HasForeignKey(x => x.CarrierId);

            builder.HasMany(x => x.CarrierReports)
                .WithOne(x => x.Carrier)
                .HasForeignKey(x => x.CarrierId);
        }
    }
}
