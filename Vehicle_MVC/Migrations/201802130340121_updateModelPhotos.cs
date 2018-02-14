namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelPhotos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "FileName", c => c.String(maxLength: 255));
            CreateIndex("dbo.Photos", "VehicleId");
            AddForeignKey("dbo.Photos", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Photos", new[] { "VehicleId" });
            AlterColumn("dbo.Photos", "FileName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
