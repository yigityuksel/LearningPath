namespace OnionArchitecture.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPasswordAddStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPasswords", "Status", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPasswords", "Status");
        }
    }
}
