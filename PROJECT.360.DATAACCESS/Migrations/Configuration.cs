namespace PROJECT._360.DATAACCESS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PROJECT._360.DATAACCESS.Context.Project360Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(PROJECT._360.DATAACCESS.Context.Project360Context context)
        {

        }
    }
}
