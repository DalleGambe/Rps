using Microsoft.Data.Sqlite;
using Rps.Domain;
using Microsoft.EntityFrameworkCore;

namespace Rps.DAL
{
    public class RpsDataContext : DbContext
    {
        //Foreach table one DbSet so that they are created in the database
        public DbSet<Player> Players { get; set; }
        public DbSet<Robot> Robots { get; set; }
        public DbSet<RpsMatch> RpsMatchesPlayed { get; set; }
        public DbSet<Setting> AppSettings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rpsdatabase.db");
                var connectionStringBuilder = new SqliteConnectionStringBuilder
                {
                    DataSource = dbFilePath,
                    ForeignKeys = true,
                };
                var connectionString = connectionStringBuilder.ConnectionString;

                var connection = new SqliteConnection(connectionString);

                optionsBuilder.UseSqlite(connection);
            }
        }
    }
}
