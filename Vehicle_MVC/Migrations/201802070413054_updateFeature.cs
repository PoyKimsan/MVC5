namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFeature : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "isChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Features", "isChecked");
        }
    }
}
