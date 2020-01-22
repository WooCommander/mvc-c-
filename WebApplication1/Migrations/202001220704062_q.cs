namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class q : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        NameCompany = c.String(),
                        Adres = c.String(),
                        Tel = c.Int(nullable: false),
                        City = c.String(),
                        Index = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        NumberOrder = c.Int(nullable: false),
                        NameOrder = c.String(),
                        DateOrder = c.DateTime(nullable: false),
                        IdEmployee = c.Int(nullable: false),
                        IdClient = c.Int(nullable: false),
                        Srok = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOrder = c.Int(nullable: false),
                        SumOrder = c.Int(nullable: false),
                        Orders_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Orders_Id)
                .Index(t => t.Orders_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        Adres = c.String(),
                        Tel = c.Int(nullable: false),
                        NumberOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOrder = c.Int(nullable: false),
                        ServiceCode = c.Int(nullable: false),
                        Orders_Id = c.Int(),
                        Services_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Orders_Id)
                .ForeignKey("dbo.Services", t => t.Services_Id)
                .Index(t => t.Orders_Id)
                .Index(t => t.Services_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSercvice = c.String(),
                        PrceService = c.Int(nullable: false),
                        ServiceCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrdersClients",
                c => new
                    {
                        Orders_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Orders_Id, t.Client_Id })
                .ForeignKey("dbo.Orders", t => t.Orders_Id, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Orders_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.EmployeeOrders",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false),
                        Orders_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.Orders_Id })
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Orders_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.Orders_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceOrders", "Services_Id", "dbo.Services");
            DropForeignKey("dbo.ServiceOrders", "Orders_Id", "dbo.Orders");
            DropForeignKey("dbo.EmployeeOrders", "Orders_Id", "dbo.Orders");
            DropForeignKey("dbo.EmployeeOrders", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Contracts", "Orders_Id", "dbo.Orders");
            DropForeignKey("dbo.OrdersClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.OrdersClients", "Orders_Id", "dbo.Orders");
            DropIndex("dbo.EmployeeOrders", new[] { "Orders_Id" });
            DropIndex("dbo.EmployeeOrders", new[] { "Employee_Id" });
            DropIndex("dbo.OrdersClients", new[] { "Client_Id" });
            DropIndex("dbo.OrdersClients", new[] { "Orders_Id" });
            DropIndex("dbo.ServiceOrders", new[] { "Services_Id" });
            DropIndex("dbo.ServiceOrders", new[] { "Orders_Id" });
            DropIndex("dbo.Contracts", new[] { "Orders_Id" });
            DropTable("dbo.EmployeeOrders");
            DropTable("dbo.OrdersClients");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceOrders");
            DropTable("dbo.Employees");
            DropTable("dbo.Contracts");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}
