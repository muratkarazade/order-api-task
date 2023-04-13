using ECO.Domain.Entities;
using ECO.Persistence.ConfigurationMap;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       

        //Projeye sonradan ekledim localde migration yapabilmek için
        public AppDbContext() : base(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(Configuration.ConnectionString).Options)
        {
        }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CarrierReport> CarrierReports { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarrierMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new CarrierReportMap());
            modelBuilder.ApplyConfiguration(new CarrierConfigurationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
