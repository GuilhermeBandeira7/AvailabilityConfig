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
            optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=RCODAX8-SCAN)(PORT=1521))(CONNECT_DATA=(SERVER = DEDICATED)" +
                "(SERVICE_NAME=RENOVIAS.renoviasconcessionaria.local)));;" +
                "User Id=CAMERASINFO;Password=#1oJH7#3+Ld4_gqZgP1;", b =>
            b.UseOracleSQLCompatibility("11"));
        }
    }
}
