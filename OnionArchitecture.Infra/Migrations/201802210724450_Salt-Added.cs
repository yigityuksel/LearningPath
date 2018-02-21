namespace OnionArchitecture.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaltAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Salt", c => c.String(nullable: false));
            AddColumn("dbo.UserPasswordHistories", "Password", c => c.String());
            AddColumn("dbo.UserPasswordHistories", "Salt", c => c.String());
            DropColumn("dbo.UserPasswordHistories", "PreviousPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPasswordHistories", "PreviousPassword", c => c.String());
            DropColumn("dbo.UserPasswordHistories", "Salt");
            DropColumn("dbo.UserPasswordHistories", "Password");
            DropColumn("dbo.User", "Salt");
        }
    }
}
