namespace Nixi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheMove : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Street = c.String(),
                        Housenumber = c.String(),
                        Bus = c.String(),
                        Postalcode = c.Int(nullable: false),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgreedDays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ToddlerId = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DayType = c.Int(),
                        Status = c.Int(),
                        PaymentStatus = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgreedPeriods",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ToddlerId = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Monday = c.Int(nullable: false),
                        Tuesday = c.Int(nullable: false),
                        Wednesday = c.Int(nullable: false),
                        Thursday = c.Int(nullable: false),
                        Friday = c.Int(nullable: false),
                        Saturday = c.Int(nullable: false),
                        Sunday = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LocationId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        MaxToddlersEachDay = c.Int(nullable: false),
                        Location_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Address_Id = c.Guid(),
                        Toddler_Id = c.Guid(),
                        Toddler_Id1 = c.Guid(),
                        Class_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Toddlers", t => t.Toddler_Id)
                .ForeignKey("dbo.Toddlers", t => t.Toddler_Id1)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Toddler_Id)
                .Index(t => t.Toddler_Id1)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.Toddlers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DayOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(),
                        Toddler_Id = c.Guid(),
                        Person_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Toddlers", t => t.Toddler_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Toddler_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.CMFiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Doctor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Toddlers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ClosingDays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DayType = c.Int(),
                        LocationId = c.String(),
                        ClassId = c.String(),
                        ClosingDayType = c.Int(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactAssociations",
                c => new
                    {
                        ContactAssociationId = c.Int(nullable: false, identity: true),
                        Contact1Id = c.Guid(nullable: false),
                        Contact2Id = c.Guid(nullable: false),
                        Association = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactAssociationId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgreedPeriods", t => t.AgreedPeriod_Id)
                .ForeignKey("dbo.CMFiles", t => t.CMFile_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.Toddlers", t => t.Toddler_Id)
                .Index(t => t.AgreedPeriod_Id)
                .Index(t => t.CMFile_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Toddler_Id);
            
            CreateTable(
                "dbo.DiaryEntries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ToddlerId = c.String(),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PathToPicture = c.String(nullable: false),
                        Privacy = c.Int(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InvoiceId = c.String(nullable: false),
                        DayType = c.Int(),
                        NormalDays = c.Int(nullable: false),
                        SecondChildDays = c.Int(nullable: false),
                        PriceDay = c.Double(nullable: false),
                        SecondChildPrice = c.Double(nullable: false),
                        SumPrice = c.Double(nullable: false),
                        Invoice_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ToddlerId = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        PayedPrice = c.Double(nullable: false),
                        Payed = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DaycareName = c.String(),
                        AddressId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Locations = c.String(),
                        Classes = c.String(),
                        WeWorkWithHalfDays = c.Boolean(nullable: false),
                        PayWhenIllness = c.Boolean(nullable: false),
                        WeBuyDiapers = c.Boolean(nullable: false),
                        SecondChildDiscount = c.Boolean(nullable: false),
                        SiblingNoGuarantee = c.Boolean(nullable: false),
                        PriceToPaycheck = c.Boolean(nullable: false),
                        DayPrice = c.Double(nullable: false),
                        HalfDayPrice = c.Double(nullable: false),
                        DiaperPrice = c.Double(nullable: false),
                        SecondChildDiscountPrice = c.Double(nullable: false),
                        PriceToPayCheckFactor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Classes", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.InvoiceLines", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.CreateToddlerViewModels", "Toddler_Id", "dbo.Toddlers");
            DropForeignKey("dbo.CreateToddlerViewModels", "Person_Id", "dbo.People");
            DropForeignKey("dbo.CreateToddlerViewModels", "CMFile_Id", "dbo.CMFiles");
            DropForeignKey("dbo.CreateToddlerViewModels", "AgreedPeriod_Id", "dbo.AgreedPeriods");
            DropForeignKey("dbo.People", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Toddlers", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Toddlers", "Toddler_Id", "dbo.Toddlers");
            DropForeignKey("dbo.People", "Toddler_Id1", "dbo.Toddlers");
            DropForeignKey("dbo.People", "Toddler_Id", "dbo.Toddlers");
            DropForeignKey("dbo.CMFiles", "Id", "dbo.Toddlers");
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Locations", new[] { "AddressId" });
            DropIndex("dbo.InvoiceLines", new[] { "Invoice_Id" });
            DropIndex("dbo.CreateToddlerViewModels", new[] { "Toddler_Id" });
            DropIndex("dbo.CreateToddlerViewModels", new[] { "Person_Id" });
            DropIndex("dbo.CreateToddlerViewModels", new[] { "CMFile_Id" });
            DropIndex("dbo.CreateToddlerViewModels", new[] { "AgreedPeriod_Id" });
            DropIndex("dbo.CMFiles", new[] { "Id" });
            DropIndex("dbo.Toddlers", new[] { "Person_Id" });
            DropIndex("dbo.Toddlers", new[] { "Toddler_Id" });
            DropIndex("dbo.People", new[] { "Class_Id" });
            DropIndex("dbo.People", new[] { "Toddler_Id1" });
            DropIndex("dbo.People", new[] { "Toddler_Id" });
            DropIndex("dbo.People", new[] { "Address_Id" });
            DropIndex("dbo.Classes", new[] { "Location_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Settings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Locations");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceLines");
            DropTable("dbo.Images");
            DropTable("dbo.DiaryEntries");
            DropTable("dbo.CreateToddlerViewModels");
            DropTable("dbo.ContactAssociations");
            DropTable("dbo.ClosingDays");
            DropTable("dbo.CMFiles");
            DropTable("dbo.Toddlers");
            DropTable("dbo.People");
            DropTable("dbo.Classes");
            DropTable("dbo.AgreedPeriods");
            DropTable("dbo.AgreedDays");
            DropTable("dbo.Addresses");
        }
    }
}
