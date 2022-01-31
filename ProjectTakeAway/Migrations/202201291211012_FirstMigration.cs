namespace ProjectTakeAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Long(nullable: false, identity: true),
                        OrderPrice = c.Decimal(precision: 18, scale: 2),
                        CustomerID = c.Long(nullable: false),
                        RestaurantID = c.Long(nullable: false),
                        DateOfPurchase = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Long(nullable: false, identity: true),
                        RestaurantName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailabilityStatus = c.String(),
                        CategoryID = c.Long(),
                        RestaurantID = c.Long(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID)
                .Index(t => t.CategoryID)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Orders", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "RestaurantID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Orders", new[] { "RestaurantID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropTable("dbo.Products");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
