namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFeatureModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Features", "isChecked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Features", "isChecked", c => c.Boolean(nullable: false));
        }
    }
}
