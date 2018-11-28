namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo._ToddlerParent", newName: "ToddlerPersons");
            DropForeignKey("dbo.Siblings", "ToddlerId", "dbo.Toddlers");
            DropForeignKey("dbo.Siblings", "SiblingId", "dbo.Toddlers");
            DropIndex("dbo.Siblings", new[] { "ToddlerId" });
            DropIndex("dbo.Siblings", new[] { "SiblingId" });
            RenameColumn(table: "dbo.ToddlerPersons", name: "ToddlerId", newName: "Toddler_Id");
            RenameColumn(table: "dbo.ToddlerPersons", name: "PersonId", newName: "Person_Id");
            RenameIndex(table: "dbo.ToddlerPersons", name: "IX_ToddlerId", newName: "IX_Toddler_Id");
            RenameIndex(table: "dbo.ToddlerPersons", name: "IX_PersonId", newName: "IX_Person_Id");
            AddColumn("dbo.Toddlers", "Toddler_Id", c => c.Guid());
            CreateIndex("dbo.Toddlers", "Toddler_Id");
            AddForeignKey("dbo.Toddlers", "Toddler_Id", "dbo.Toddlers", "Id");
            DropTable("dbo.Siblings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Siblings",
                c => new
                    {
                        ToddlerId = c.Guid(nullable: false),
                        SiblingId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ToddlerId, t.SiblingId });
            
            DropForeignKey("dbo.Toddlers", "Toddler_Id", "dbo.Toddlers");
            DropIndex("dbo.Toddlers", new[] { "Toddler_Id" });
            DropColumn("dbo.Toddlers", "Toddler_Id");
            RenameIndex(table: "dbo.ToddlerPersons", name: "IX_Person_Id", newName: "IX_PersonId");
            RenameIndex(table: "dbo.ToddlerPersons", name: "IX_Toddler_Id", newName: "IX_ToddlerId");
            RenameColumn(table: "dbo.ToddlerPersons", name: "Person_Id", newName: "PersonId");
            RenameColumn(table: "dbo.ToddlerPersons", name: "Toddler_Id", newName: "ToddlerId");
            CreateIndex("dbo.Siblings", "SiblingId");
            CreateIndex("dbo.Siblings", "ToddlerId");
            AddForeignKey("dbo.Siblings", "SiblingId", "dbo.Toddlers", "Id");
            AddForeignKey("dbo.Siblings", "ToddlerId", "dbo.Toddlers", "Id");
            RenameTable(name: "dbo.ToddlerPersons", newName: "_ToddlerParent");
        }
    }
}
