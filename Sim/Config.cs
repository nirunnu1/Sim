using System.Data.Entity.Migrations;

namespace Simulations
{
    internal sealed class ConfigurationmyDbContext : DbMigrationsConfiguration<myDbContext>
    {
        public ConfigurationmyDbContext()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(myDbContext context)
        {
        }
    }
}
