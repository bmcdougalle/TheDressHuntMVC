namespace TheDressHunt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUser", "Age", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "HasHunted", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUser", "HasHunted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ApplicationUser", "Age", c => c.Int(nullable: false));
        }
    }
}
