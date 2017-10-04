namespace PSI_X.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForCompanyCode : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyCodes", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CompanyCodes", new[] { "CompanyId" });
            AddColumn("dbo.Companies", "CompanyCode_Id", c => c.Int());
            CreateIndex("dbo.Companies", "CompanyCode_Id");
            AddForeignKey("dbo.Companies", "CompanyCode_Id", "dbo.CompanyCodes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "CompanyCode_Id", "dbo.CompanyCodes");
            DropIndex("dbo.Companies", new[] { "CompanyCode_Id" });
            DropColumn("dbo.Companies", "CompanyCode_Id");
            CreateIndex("dbo.CompanyCodes", "CompanyId");
            AddForeignKey("dbo.CompanyCodes", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
