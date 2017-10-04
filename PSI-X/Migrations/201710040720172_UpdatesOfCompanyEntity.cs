namespace PSI_X.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesOfCompanyEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Address", c => c.String());
            AddColumn("dbo.Companies", "TypeOfCompany", c => c.String());
            AddColumn("dbo.UserPoints", "CompanyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPoints", "CompanyId");
            DropColumn("dbo.Companies", "TypeOfCompany");
            DropColumn("dbo.Companies", "Address");
        }
    }
}
