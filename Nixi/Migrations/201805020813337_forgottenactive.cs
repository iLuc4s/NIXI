namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forgottenactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgreedDays", "AgreedDayStatus", c => c.Int());
            DropColumn("dbo.AgreedDays", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AgreedDays", "Status", c => c.Int());
            DropColumn("dbo.AgreedDays", "AgreedDayStatus");
        }
    }
}
