namespace PSI_X.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyCodes", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.UserPoints", "UserId", "dbo.Users");
            DropIndex("dbo.CompanyCodes", new[] { "CompanyId" });
            DropIndex("dbo.UserPoints", new[] { "UserId" });
            AddColumn("dbo.CompanyCodes", "CompanyName", c => c.Int(nullable: false));
            AddColumn("dbo.CompanyCodes", "CodeName", c => c.String());
            AddColumn("dbo.UserPoints", "CompanyName", c => c.String());
            AlterColumn("dbo.CompanyCodes", "Code", c => c.String());
            DropColumn("dbo.CompanyCodes", "CompanyId");
            DropColumn("dbo.CompanyCodes", "Name");
            DropColumn("dbo.UserPoints", "NameOfCompany");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPoints", "NameOfCompany", c => c.String());
            AddColumn("dbo.CompanyCodes", "Name", c => c.String());
            AddColumn("dbo.CompanyCodes", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyCodes", "Code", c => c.Int(nullable: false));
            DropColumn("dbo.UserPoints", "CompanyName");
            DropColumn("dbo.CompanyCodes", "CodeName");
            DropColumn("dbo.CompanyCodes", "CompanyName");
            CreateIndex("dbo.UserPoints", "UserId");
            CreateIndex("dbo.CompanyCodes", "CompanyId");
            AddForeignKey("dbo.UserPoints", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompanyCodes", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
