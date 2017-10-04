namespace PSI_X.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "CompanyCode_Code", "dbo.CompanyCodes");
            RenameColumn(table: "dbo.Companies", name: "CompanyCode_Code", newName: "CompanyCode_Id");
            RenameIndex(table: "dbo.Companies", name: "IX_CompanyCode_Code", newName: "IX_CompanyCode_Id");
            DropPrimaryKey("dbo.CompanyCodes");
            AlterColumn("dbo.CompanyCodes", "Code", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyCodes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CompanyCodes", "Id");
            AddForeignKey("dbo.Companies", "CompanyCode_Id", "dbo.CompanyCodes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "CompanyCode_Id", "dbo.CompanyCodes");
            DropPrimaryKey("dbo.CompanyCodes");
            AlterColumn("dbo.CompanyCodes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyCodes", "Code", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CompanyCodes", "Code");
            RenameIndex(table: "dbo.Companies", name: "IX_CompanyCode_Id", newName: "IX_CompanyCode_Code");
            RenameColumn(table: "dbo.Companies", name: "CompanyCode_Id", newName: "CompanyCode_Code");
            AddForeignKey("dbo.Companies", "CompanyCode_Code", "dbo.CompanyCodes", "Code");
        }
    }
}
