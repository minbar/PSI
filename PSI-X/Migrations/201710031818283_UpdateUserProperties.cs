namespace PSI_X.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.UserPoints", "CompanyId");
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.UserPoints", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String());
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
