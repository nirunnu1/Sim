using Simulations.Models;
using System.Data.Entity;

namespace Simulations
{
    public class myDbContext : DbContext
    {
        public myDbContext()
            : base()
        {
            Database.SetInitializer<myDbContext>(new CreateDatabaseIfNotExists<myDbContext>());
            Database.SetInitializer<myDbContext>(new MigrateDatabaseToLatestVersion<myDbContext, ConfigurationmyDbContext>(true));
            Database.Connection.ConnectionString = @"Server=127.0.0.1;Database= test ;User Id = sa ;Password=123456;";
        }
          public DbSet<testProfile> testProfile { get; set; }
          public DbSet<testActivities> testActivities { get; set; }
          public DbSet<testCase> testCase { get; set; }
        public DbSet<SettingCase> SettingCase { get; set; }
    }
}
