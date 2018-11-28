namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuckedup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreateToddlerViewModels", "AgreedPeriod_Id", "dbo.AgreedPeriods");
            DropForeignKey("dbo.CreateToddlerViewModels", "CMFile_Id", "dbo.CMFiles");
            DropForeignKey("dbo.CreateToddlerViewModels", "Person_Id", "dbo.People");
            DropForeignKey("dbo.CreateToddlerViewModels", "Toddler_Id", "dbo.Toddlers");
            DropIndex("dbo.CreateToddlerViewModels", new[] { "AgreedPeriod_Id" });
            DropIndex("dbo.CreateToddlerViewModels", new[] { "CMFile_Id" });
            DropIndex("dbo.CreateToddlerViewModels", new[] { "Person_Id" });
            DropIndex("dbo.CreateToddlerViewModels", new[] { "Toddler_Id" });
            DropTable("dbo.CreateToddlerViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CreateToddlerViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgreedPeriod_Id = c.Guid(),
                        CMFile_Id = c.Guid(),
                        Person_Id = c.Guid(),
                        Toddler_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CreateToddlerViewModels", "Toddler_Id");
            CreateIndex("dbo.CreateToddlerViewModels", "Person_Id");
            CreateIndex("dbo.CreateToddlerViewModels", "CMFile_Id");
            CreateIndex("dbo.CreateToddlerViewModels", "AgreedPeriod_Id");
            AddForeignKey("dbo.CreateToddlerViewModels", "Toddler_Id", "dbo.Toddlers", "Id");
            AddForeignKey("dbo.CreateToddlerViewModels", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.CreateToddlerViewModels", "CMFile_Id", "dbo.CMFiles", "Id");
            AddForeignKey("dbo.CreateToddlerViewModels", "AgreedPeriod_Id", "dbo.AgreedPeriods", "Id");
        }
    }
}
