namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLastUpdateToV : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "LastUpdate");
        }
    }
}
