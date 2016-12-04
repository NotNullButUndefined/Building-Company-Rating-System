namespace BCRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.BuildingId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "BuildingId" });
            DropTable("dbo.Comments");
        }
    }
}
