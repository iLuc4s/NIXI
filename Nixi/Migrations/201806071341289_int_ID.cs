namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class int_ID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DiaryEntries");
            AlterColumn("dbo.DiaryEntries", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DiaryEntries", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.DiaryEntries");
            AlterColumn("dbo.DiaryEntries", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DiaryEntries", "Id");
        }
    }
}
