namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleModels", "Makes_Id", c => c.Int());
            AddColumn("dbo.Vehicles", "VehicleModels_Id", c => c.Int());
            AlterColumn("dbo.Features", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Makes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Photos", "FileName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Vehicles", "ContactName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Vehicles", "ContactEmail", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Vehicles", "ContactPhone", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Vehicles", "IsRegistered", c => c.Boolean(nullable: false));
            CreateIndex("dbo.VehicleModels", "Makes_Id");
            CreateIndex("dbo.Vehicles", "VehicleModels_Id");
            AddForeignKey("dbo.VehicleModels", "Makes_Id", "dbo.Makes", "Id");
            AddForeignKey("dbo.Vehicles", "VehicleModels_Id", "dbo.VehicleModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleModels_Id", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "Makes_Id", "dbo.Makes");
            DropIndex("dbo.Vehicles", new[] { "VehicleModels_Id" });
            DropIndex("dbo.VehicleModels", new[] { "Makes_Id" });
            AlterColumn("dbo.Vehicles", "IsRegistered", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "ContactPhone", c => c.String());
            AlterColumn("dbo.Vehicles", "ContactEmail", c => c.String());
            AlterColumn("dbo.Vehicles", "ContactName", c => c.String());
            AlterColumn("dbo.Photos", "FileName", c => c.String());
            AlterColumn("dbo.Makes", "Name", c => c.String());
            AlterColumn("dbo.Features", "Name", c => c.String());
            DropColumn("dbo.Vehicles", "VehicleModels_Id");
            DropColumn("dbo.VehicleModels", "Makes_Id");
        }
    }
}
