namespace PSI_X.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "CompanyCode_Id", "dbo.CompanyCodes");
            DropIndex("dbo.Companies", new[] { "CompanyCode_Id" });
            DropColumn("dbo.Companies", "CompanyCode_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "CompanyCode_Id", c => c.Int());
            CreateIndex("dbo.Companies", "CompanyCode_Id");
            AddForeignKey("dbo.Companies", "CompanyCode_Id", "dbo.CompanyCodes", "Id");
        }
    }
}
