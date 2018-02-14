namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udpateentityVF : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleFeatures", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.VehicleFeatures", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.VehicleFeatures", new[] { "VehicleId" });
            DropIndex("dbo.VehicleFeatures", new[] { "FeatureId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.VehicleFeatures", "FeatureId");
            CreateIndex("dbo.VehicleFeatures", "VehicleId");
            AddForeignKey("dbo.VehicleFeatures", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleFeatures", "FeatureId", "dbo.Features", "Id", cascadeDelete: true);
        }
    }
}
