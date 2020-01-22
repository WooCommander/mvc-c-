namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class q3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderClients", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderClients", "Client_Id", "dbo.Clients");
            DropIndex("dbo.OrderClients", new[] { "Order_Id" });
            DropIndex("dbo.OrderClients", new[] { "Client_Id" });
            AddColumn("dbo.Clients", "Order_Id", c => c.Int());
            AddColumn("dbo.Orders", "Client_Id", c => c.Int());
            AddColumn("dbo.Orders", "Client_Id1", c => c.Int());
            CreateIndex("dbo.Clients", "Order_Id");
            CreateIndex("dbo.Orders", "Client_Id");
            CreateIndex("dbo.Orders", "Client_Id1");
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Clients", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "Client_Id1", "dbo.Clients", "Id");
            DropTable("dbo.OrderClients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderClients",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Client_Id });
            
            DropForeignKey("dbo.Orders", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "Client_Id1" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropIndex("dbo.Clients", new[] { "Order_Id" });
            DropColumn("dbo.Orders", "Client_Id1");
            DropColumn("dbo.Orders", "Client_Id");
            DropColumn("dbo.Clients", "Order_Id");
            CreateIndex("dbo.OrderClients", "Client_Id");
            CreateIndex("dbo.OrderClients", "Order_Id");
            AddForeignKey("dbo.OrderClients", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderClients", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
