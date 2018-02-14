namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertData1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VehicleFeatures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleFeatures",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        vehicleId = c.Int(nullable: false),
                        FeatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
