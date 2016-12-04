namespace BCRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class building : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalRating = c.Double(nullable: false),
                        FoundationDate = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buildings", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Buildings", new[] { "CompanyId" });
            DropTable("dbo.Buildings");
        }
    }
}
