namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "NameOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "NameOrder", c => c.String());
        }
    }
}
