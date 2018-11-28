namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixingwhatwhasbroken : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DiaryEntries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DiaryEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToddlerId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
