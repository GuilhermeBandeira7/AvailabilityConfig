using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AvailabilityConfig.Context
{
    public class OraclaDbContext: DbContext
    {
        public DbSet<AvailabilityConfig> Configs { get; set; }
        public DbSet<CameraInfo> Cameras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //here I have the configurations required to connect to the desired Oracle database.
            optionsBuilder.UseOracle();
        }
    }
}
