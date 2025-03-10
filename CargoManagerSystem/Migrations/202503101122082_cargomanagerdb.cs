namespace CargoManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargomanagerdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoOrders", "PickupDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CargoOrders", "EstimatedDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cities", "PickupDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "PickupDate");
            DropColumn("dbo.CargoOrders", "EstimatedDeliveryDate");
            DropColumn("dbo.CargoOrders", "PickupDate");
        }
    }
}
