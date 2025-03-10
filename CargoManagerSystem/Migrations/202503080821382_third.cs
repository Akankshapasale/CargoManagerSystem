namespace CargoManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.CargoFares", "Price", "Fare");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.CargoFares", "Fare", "Price");
        }
    }
}
