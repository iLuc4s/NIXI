namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiaryEntries", "ToddlerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiaryEntries", "ToddlerId", c => c.String());
        }
    }
}
