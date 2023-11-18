using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Rps.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

namespace Rps.DAL
{
    public class RpsDataContext : DbContext
    {
        public RpsDataContext(DbContextOptions<RpsDataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = "rpsdatabase.db",
                ForeignKeys = true,
            };
            var connectionString = connectionStringBuilder.ConnectionString;

            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //Foreach table one DbSet
        public DbSet<Player> Players { get; set; }
        public DbSet<RpsMatch> RpsMatchesPlayed { get; set; }
        public DbSet<Setting> AppSetting { get; set; }
    }
}
