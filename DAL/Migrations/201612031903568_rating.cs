namespace BCRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Ratings", new[] { "BuildingId" });
            DropTable("dbo.Ratings");
        }
    }
}
