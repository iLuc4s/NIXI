namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eentje : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Classes", new[] { "Location_Id" });
            DropColumn("dbo.Classes", "LocationId");
            RenameColumn(table: "dbo.Classes", name: "Location_Id", newName: "LocationId");
            AlterColumn("dbo.Classes", "LocationId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Classes", "LocationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Classes", "LocationId");
            AddForeignKey("dbo.Classes", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "LocationId", "dbo.Locations");
            DropIndex("dbo.Classes", new[] { "LocationId" });
            AlterColumn("dbo.Classes", "LocationId", c => c.Guid());
            AlterColumn("dbo.Classes", "LocationId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Classes", name: "LocationId", newName: "Location_Id");
            AddColumn("dbo.Classes", "LocationId", c => c.String(nullable: false));
            CreateIndex("dbo.Classes", "Location_Id");
            AddForeignKey("dbo.Classes", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
