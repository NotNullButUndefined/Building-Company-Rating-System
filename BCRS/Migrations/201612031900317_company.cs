namespace BCRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class company : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Owner = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner, cascadeDelete: true)
                .Index(t => t.Owner);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "Owner", "dbo.Users");
            DropIndex("dbo.Companies", new[] { "Owner" });
            DropTable("dbo.Companies");
        }
    }
}
