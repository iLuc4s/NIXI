namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AP_and_AD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgreedDays", "AgreedPeriodId", c => c.Guid(nullable: false));
            AddColumn("dbo.AgreedPeriods", "Comment", c => c.String());
            AddColumn("dbo.AgreedPeriods", "Activated", c => c.Boolean(nullable: false));
            AddColumn("dbo.AgreedPeriods", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.AgreedPeriods", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgreedPeriods", "CreationDate");
            DropColumn("dbo.AgreedPeriods", "Active");
            DropColumn("dbo.AgreedPeriods", "Activated");
            DropColumn("dbo.AgreedPeriods", "Comment");
            DropColumn("dbo.AgreedDays", "AgreedPeriodId");
        }
    }
}
