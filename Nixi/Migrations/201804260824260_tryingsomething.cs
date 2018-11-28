namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingsomething : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Toddler_Id", "dbo.Toddlers");
            DropForeignKey("dbo.People", "Toddler_Id1", "dbo.Toddlers");
            DropForeignKey("dbo.Toddlers", "Toddler_Id", "dbo.Toddlers");
            DropForeignKey("dbo.Toddlers", "Person_Id", "dbo.People");
            DropForeignKey("dbo.People", "Class_Id", "dbo.Classes");
            DropIndex("dbo.People", new[] { "Toddler_Id" });
            DropIndex("dbo.People", new[] { "Toddler_Id1" });
            DropIndex("dbo.People", new[] { "Class_Id" });
            DropIndex("dbo.Toddlers", new[] { "Toddler_Id" });
            DropIndex("dbo.Toddlers", new[] { "Person_Id" });
            CreateTable(
                "dbo._ToddlerParent",
                c => new
                    {
                        ToddlerId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ToddlerId, t.PersonId })
                .ForeignKey("dbo.Toddlers", t => t.ToddlerId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.ToddlerId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.ToddlerPerson1",
                c => new
                    {
                        Toddler_Id = c.Guid(nullable: false),
                        Person_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Toddler_Id, t.Person_Id })
                .ForeignKey("dbo.Toddlers", t => t.Toddler_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Toddler_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Siblings",
                c => new
                    {
                        ToddlerId = c.Guid(nullable: false),
                        SiblingId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ToddlerId, t.SiblingId })
                .ForeignKey("dbo.Toddlers", t => t.ToddlerId)
                .ForeignKey("dbo.Toddlers", t => t.SiblingId)
                .Index(t => t.ToddlerId)
                .Index(t => t.SiblingId);
            
            CreateTable(
                "dbo.PersonClasses",
                c => new
                    {
                        Person_Id = c.Guid(nullable: false),
                        Class_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Class_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Class_Id);
            
            DropColumn("dbo.People", "Toddler_Id");
            DropColumn("dbo.People", "Toddler_Id1");
            DropColumn("dbo.People", "Class_Id");
            DropColumn("dbo.Toddlers", "Toddler_Id");
            DropColumn("dbo.Toddlers", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Toddlers", "Person_Id", c => c.Guid());
            AddColumn("dbo.Toddlers", "Toddler_Id", c => c.Guid());
            AddColumn("dbo.People", "Class_Id", c => c.Guid());
            AddColumn("dbo.People", "Toddler_Id1", c => c.Guid());
            AddColumn("dbo.People", "Toddler_Id", c => c.Guid());
            DropForeignKey("dbo.PersonClasses", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.PersonClasses", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Siblings", "SiblingId", "dbo.Toddlers");
            DropForeignKey("dbo.Siblings", "ToddlerId", "dbo.Toddlers");
            DropForeignKey("dbo.ToddlerPerson1", "Person_Id", "dbo.People");
            DropForeignKey("dbo.ToddlerPerson1", "Toddler_Id", "dbo.Toddlers");
            DropForeignKey("dbo._ToddlerParent", "PersonId", "dbo.People");
            DropForeignKey("dbo._ToddlerParent", "ToddlerId", "dbo.Toddlers");
            DropIndex("dbo.PersonClasses", new[] { "Class_Id" });
            DropIndex("dbo.PersonClasses", new[] { "Person_Id" });
            DropIndex("dbo.Siblings", new[] { "SiblingId" });
            DropIndex("dbo.Siblings", new[] { "ToddlerId" });
            DropIndex("dbo.ToddlerPerson1", new[] { "Person_Id" });
            DropIndex("dbo.ToddlerPerson1", new[] { "Toddler_Id" });
            DropIndex("dbo._ToddlerParent", new[] { "PersonId" });
            DropIndex("dbo._ToddlerParent", new[] { "ToddlerId" });
            DropTable("dbo.PersonClasses");
            DropTable("dbo.Siblings");
            DropTable("dbo.ToddlerPerson1");
            DropTable("dbo._ToddlerParent");
            CreateIndex("dbo.Toddlers", "Person_Id");
            CreateIndex("dbo.Toddlers", "Toddler_Id");
            CreateIndex("dbo.People", "Class_Id");
            CreateIndex("dbo.People", "Toddler_Id1");
            CreateIndex("dbo.People", "Toddler_Id");
            AddForeignKey("dbo.People", "Class_Id", "dbo.Classes", "Id");
            AddForeignKey("dbo.Toddlers", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Toddlers", "Toddler_Id", "dbo.Toddlers", "Id");
            AddForeignKey("dbo.People", "Toddler_Id1", "dbo.Toddlers", "Id");
            AddForeignKey("dbo.People", "Toddler_Id", "dbo.Toddlers", "Id");
        }
    }
}
