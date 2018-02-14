namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertData2 : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.VehicleFeatures");
        }
    }
}
