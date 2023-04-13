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
    public class CarrierReportMap : BaseMap<CarrierReport,int>
    {
        public override void Configure(EntityTypeBuilder<CarrierReport> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CarrierCost).IsRequired();
            builder.Property(x => x.CarrierReportDate).IsRequired();
            builder.Property(x => x.CarrierId).IsRequired();

            builder.HasOne(x => x.Carrier)
                .WithMany(x => x.CarrierReports)
                .HasForeignKey(x => x.CarrierId);
        }
    }
}
