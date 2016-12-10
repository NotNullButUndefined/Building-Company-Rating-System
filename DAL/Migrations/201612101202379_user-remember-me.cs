namespace BCRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrememberme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RememberMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RememberMe");
        }
    }
}
