namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedwhatwhasbroken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiaryEntries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ToddlerId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DiaryEntries");
        }
    }
}
