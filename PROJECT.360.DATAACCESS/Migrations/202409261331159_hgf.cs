namespace PROJECT._360.DATAACCESS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hgf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "TestField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "TestField", c => c.String());
        }
    }
}
