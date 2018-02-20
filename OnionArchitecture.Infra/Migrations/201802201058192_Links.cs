namespace OnionArchitecture.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Links : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Type = c.Short(nullable: false),
                        ExpirationDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "UserId", "dbo.Users");
            DropIndex("dbo.Links", new[] { "UserId" });
            DropTable("dbo.Links");
        }
    }
}
