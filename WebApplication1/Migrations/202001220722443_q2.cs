namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class q2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrdersClients", newName: "OrderClients");
            RenameColumn(table: "dbo.OrderClients", name: "Orders_Id", newName: "Order_Id");
            RenameColumn(table: "dbo.EmployeeOrders", name: "Orders_Id", newName: "Order_Id");
            RenameColumn(table: "dbo.Contracts", name: "Orders_Id", newName: "Order_Id");
            RenameColumn(table: "dbo.ServiceOrders", name: "Orders_Id", newName: "Order_Id");
            RenameIndex(table: "dbo.Contracts", name: "IX_Orders_Id", newName: "IX_Order_Id");
            RenameIndex(table: "dbo.ServiceOrders", name: "IX_Orders_Id", newName: "IX_Order_Id");
            RenameIndex(table: "dbo.OrderClients", name: "IX_Orders_Id", newName: "IX_Order_Id");
            RenameIndex(table: "dbo.EmployeeOrders", name: "IX_Orders_Id", newName: "IX_Order_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EmployeeOrders", name: "IX_Order_Id", newName: "IX_Orders_Id");
            RenameIndex(table: "dbo.OrderClients", name: "IX_Order_Id", newName: "IX_Orders_Id");
            RenameIndex(table: "dbo.ServiceOrders", name: "IX_Order_Id", newName: "IX_Orders_Id");
            RenameIndex(table: "dbo.Contracts", name: "IX_Order_Id", newName: "IX_Orders_Id");
            RenameColumn(table: "dbo.ServiceOrders", name: "Order_Id", newName: "Orders_Id");
            RenameColumn(table: "dbo.Contracts", name: "Order_Id", newName: "Orders_Id");
            RenameColumn(table: "dbo.EmployeeOrders", name: "Order_Id", newName: "Orders_Id");
            RenameColumn(table: "dbo.OrderClients", name: "Order_Id", newName: "Orders_Id");
            RenameTable(name: "dbo.OrderClients", newName: "OrdersClients");
        }
    }
}
