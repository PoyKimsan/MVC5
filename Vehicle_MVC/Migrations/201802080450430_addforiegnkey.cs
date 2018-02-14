namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforiegnkey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Vehicles", "ModelId");
            AddForeignKey("dbo.Vehicles", "ModelId", "dbo.VehicleModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.VehicleModels");
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
        }
    }
}
