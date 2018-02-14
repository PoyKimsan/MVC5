namespace Vehicle_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makesupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Makes", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Makes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
