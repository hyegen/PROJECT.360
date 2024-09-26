namespace PROJECT._360.DATAACCESS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _32 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "DateCreated");
            DropColumn("dbo.Products", "DateModified");
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Users", "DateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DateModified", c => c.DateTime());
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateModified", c => c.DateTime());
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
