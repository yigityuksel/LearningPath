namespace OnionArchitecture.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Links", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Links", "Type", c => c.Short(nullable: false));
        }
    }
}
