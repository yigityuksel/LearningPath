namespace OnionArchitecture.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeForPreviousPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPasswordHistories", "CreationDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPasswordHistories", "CreationDateTime");
        }
    }
}
