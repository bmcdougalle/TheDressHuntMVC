namespace TheDressHunt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dress",
                c => new
                    {
                        DressId = c.Int(nullable: false, identity: true),
                        DressSize = c.String(),
                        Shop_ShopId = c.Int(),
                    })
                .PrimaryKey(t => t.DressId)
                .ForeignKey("dbo.Shop", t => t.Shop_ShopId)
                .Index(t => t.Shop_ShopId);
            
            AddColumn("dbo.Shop", "DressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shop", "DressId");
            AddForeignKey("dbo.Shop", "DressId", "dbo.Dress", "DressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dress", "Shop_ShopId", "dbo.Shop");
            DropForeignKey("dbo.Shop", "DressId", "dbo.Dress");
            DropIndex("dbo.Dress", new[] { "Shop_ShopId" });
            DropIndex("dbo.Shop", new[] { "DressId" });
            DropColumn("dbo.Shop", "DressId");
            DropTable("dbo.Dress");
        }
    }
}
