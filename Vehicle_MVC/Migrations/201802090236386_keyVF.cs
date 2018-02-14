namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keyVF : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.VehicleFeatures", "VehicleId");
            CreateIndex("dbo.VehicleFeatures", "FeatureId");
            AddForeignKey("dbo.VehicleFeatures", "FeatureId", "dbo.Features", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleFeatures", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleFeatures", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleFeatures", "FeatureId", "dbo.Features");
            DropIndex("dbo.VehicleFeatures", new[] { "FeatureId" });
            DropIndex("dbo.VehicleFeatures", new[] { "VehicleId" });
        }
    }
}
