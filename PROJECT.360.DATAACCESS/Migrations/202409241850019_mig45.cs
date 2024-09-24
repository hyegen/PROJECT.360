namespace PROJECT._360.DATAACCESS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Phone", c => c.String());
            DropColumn("dbo.Users", "TelNr1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "TelNr1", c => c.String());
            DropColumn("dbo.Users", "Phone");
        }
    }
}
