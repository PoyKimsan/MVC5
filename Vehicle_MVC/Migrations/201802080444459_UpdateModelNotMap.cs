namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelNotMap : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "VehicleModels_Id", "dbo.VehicleModels");
            DropIndex("dbo.Vehicles", new[] { "VehicleModels_Id" });
            DropColumn("dbo.Vehicles", "VehicleModels_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "VehicleModels_Id", c => c.Int());
            CreateIndex("dbo.Vehicles", "VehicleModels_Id");
            AddForeignKey("dbo.Vehicles", "VehicleModels_Id", "dbo.VehicleModels", "Id");
        }
    }
}
