namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitailVehicleModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakeId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleModels");
        }
    }
}
