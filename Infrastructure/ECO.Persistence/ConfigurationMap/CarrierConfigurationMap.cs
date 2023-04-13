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
    public class CarrierConfigurationMap : BaseMap<CarrierConfiguration,int>
    {
        public override void Configure(EntityTypeBuilder<CarrierConfiguration> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.MaxDesi).IsRequired();
            builder.Property(x => x.MinDesi).IsRequired();
            builder.Property(x => x.CarrierCost).IsRequired();
            builder.Property(x => x.CarrierId).IsRequired();

            builder.HasOne(x => x.Carrier)
                .WithOne(x => x.CarrierConfiguration)
                .HasForeignKey<CarrierConfiguration>(x => x.CarrierId);
        }
    }
}
