namespace PROJECT._360.DATAACCESS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateModified", c => c.DateTime());
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateModified");
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Products", "DateModified");
            DropColumn("dbo.Products", "DateCreated");
        }
    }
}
