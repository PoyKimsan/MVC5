namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foriegnkeyMakes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleModels", "Makes_Id", "dbo.Makes");
            DropIndex("dbo.VehicleModels", new[] { "Makes_Id" });
            DropColumn("dbo.VehicleModels", "MakeId");
            RenameColumn(table: "dbo.VehicleModels", name: "Makes_Id", newName: "MakeId");
            AlterColumn("dbo.VehicleModels", "MakeId", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleModels", "MakeId");
            AddForeignKey("dbo.VehicleModels", "MakeId", "dbo.Makes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "MakeId", "dbo.Makes");
            DropIndex("dbo.VehicleModels", new[] { "MakeId" });
            AlterColumn("dbo.VehicleModels", "MakeId", c => c.Int());
            RenameColumn(table: "dbo.VehicleModels", name: "MakeId", newName: "Makes_Id");
            AddColumn("dbo.VehicleModels", "MakeId", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleModels", "Makes_Id");
            AddForeignKey("dbo.VehicleModels", "Makes_Id", "dbo.Makes", "Id");
        }
    }
}
