namespace CargoManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargomanagerdb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoOrders", "PickupLocation", c => c.String(nullable: false));
            AddColumn("dbo.CargoOrders", "DropLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CargoOrders", "DropLocation");
            DropColumn("dbo.CargoOrders", "PickupLocation");
        }
    }
}
