namespace TheDressHunt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dress",
                c => new
                    {
                        DressId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        DressSize = c.String(),
                    })
                .PrimaryKey(t => t.DressId);
            
            CreateTable(
                "dbo.DressShop",
                c => new
                    {
                        ShopId = c.Int(nullable: false),
                        DressId = c.Int(nullable: false),
                        DressSize = c.String(),
                    })
                .PrimaryKey(t => new { t.ShopId, t.DressId })
                .ForeignKey("dbo.Dress", t => t.DressId, cascadeDelete: true)
                .ForeignKey("dbo.Shop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId)
                .Index(t => t.DressId);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 25),
                        Location = c.String(nullable: false, maxLength: 200),
                        HoursOfOperation = c.String(nullable: false),
                        TypeOfOccasion = c.String(),
                    })
                .PrimaryKey(t => t.ShopId);
            
            CreateTable(
                "dbo.Hunt",
                c => new
                    {
                        HuntId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ShopId = c.Int(),
                        DateofHunt = c.DateTime(nullable: false),
                        TeamId = c.Int(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        TypeOfOccasion = c.String(nullable: false, maxLength: 25),
                        DressType = c.String(nullable: false, maxLength: 25),
                        ColorScheme = c.String(nullable: false, maxLength: 40),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.HuntId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .ForeignKey("dbo.TeamHunt", t => t.TeamId)
                .Index(t => t.ShopId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.TeamHunt",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 500),
                        Content = c.String(nullable: false, maxLength: 500),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        HuntRating = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Location = c.String(),
                        Age = c.Int(),
                        HasHunted = c.Boolean(),
                        HuntId = c.Int(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Hunt", "TeamId", "dbo.TeamHunt");
            DropForeignKey("dbo.Hunt", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.DressShop", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.DressShop", "DressId", "dbo.Dress");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Hunt", new[] { "TeamId" });
            DropIndex("dbo.Hunt", new[] { "ShopId" });
            DropIndex("dbo.DressShop", new[] { "DressId" });
            DropIndex("dbo.DressShop", new[] { "ShopId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Review");
            DropTable("dbo.TeamHunt");
            DropTable("dbo.Hunt");
            DropTable("dbo.Shop");
            DropTable("dbo.DressShop");
            DropTable("dbo.Dress");
        }
    }
}
