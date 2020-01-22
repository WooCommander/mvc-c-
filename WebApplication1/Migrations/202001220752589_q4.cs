namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class q4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeOrders", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeOrders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.EmployeeOrders", new[] { "Employee_Id" });
            DropIndex("dbo.EmployeeOrders", new[] { "Order_Id" });
            AddColumn("dbo.Orders", "Employee_Id", c => c.Int());
            AddColumn("dbo.Orders", "Employee_Id1", c => c.Int());
            AddColumn("dbo.Employees", "Order_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Employee_Id");
            CreateIndex("dbo.Orders", "Employee_Id1");
            CreateIndex("dbo.Employees", "Order_Id");
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.Orders", "Employee_Id1", "dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "Order_Id", "dbo.Orders", "Id");
            DropTable("dbo.EmployeeOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeOrders",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_Id, t.Order_Id });
            
            DropForeignKey("dbo.Employees", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id1" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropColumn("dbo.Employees", "Order_Id");
            DropColumn("dbo.Orders", "Employee_Id1");
            DropColumn("dbo.Orders", "Employee_Id");
            CreateIndex("dbo.EmployeeOrders", "Order_Id");
            CreateIndex("dbo.EmployeeOrders", "Employee_Id");
            AddForeignKey("dbo.EmployeeOrders", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeOrders", "Employee_Id", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
