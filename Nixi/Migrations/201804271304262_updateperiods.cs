namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateperiods : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AgreedDays", "ToddlerId");
            CreateIndex("dbo.AgreedPeriods", "ToddlerId");
            AddForeignKey("dbo.AgreedDays", "ToddlerId", "dbo.Toddlers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AgreedPeriods", "ToddlerId", "dbo.Toddlers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgreedPeriods", "ToddlerId", "dbo.Toddlers");
            DropForeignKey("dbo.AgreedDays", "ToddlerId", "dbo.Toddlers");
            DropIndex("dbo.AgreedPeriods", new[] { "ToddlerId" });
            DropIndex("dbo.AgreedDays", new[] { "ToddlerId" });
        }
    }
}
