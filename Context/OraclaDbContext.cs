using Microsoft.EntityFrameworkCore;

namespace AvailabilityConfig.Context
{
    public class OraclaDbContext: DbContext
    {
        public DbSet<Config> Configs { get; set; }
        public DbSet<Camera> Cameras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //here I have the configurations required to connect to the desired Oracle database.
            optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER = DEDICATED)" +
                "(SERVICE_NAME=XEPDB1)));;" +
                "User Id=TESTE;Password=teste;", b =>
            b.UseOracleSQLCompatibility("11"));
        }
    }
}
