namespace CargoManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Pricings",
                c => new
                    {
                        PricingId = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        CargoTypeId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PricingId)
                .ForeignKey("dbo.CargoTypes", t => t.CargoTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.CargoTypeId);
            
            AddColumn("dbo.CargoOrders", "CustomerName", c => c.String());
            AddColumn("dbo.CargoOrders", "Destination", c => c.String());
            AddColumn("dbo.CargoOrders", "Status", c => c.String());
            AddColumn("dbo.CargoTypes", "BasePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Cities", "PricePerKm", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pricings", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Pricings", "CargoTypeId", "dbo.CargoTypes");
            DropIndex("dbo.Pricings", new[] { "CargoTypeId" });
            DropIndex("dbo.Pricings", new[] { "CityId" });
            DropColumn("dbo.Cities", "PricePerKm");
            DropColumn("dbo.CargoTypes", "BasePrice");
            DropColumn("dbo.CargoOrders", "Status");
            DropColumn("dbo.CargoOrders", "Destination");
            DropColumn("dbo.CargoOrders", "CustomerName");
            DropTable("dbo.Pricings");
            DropTable("dbo.Administrators");
        }
    }
}
