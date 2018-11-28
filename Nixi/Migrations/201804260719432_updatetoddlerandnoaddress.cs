namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetoddlerandnoaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Toddlers", "GuaranteePrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Toddlers", "GuaranteePrice");
        }
    }
}
