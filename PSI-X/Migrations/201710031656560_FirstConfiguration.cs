namespace PSI_X.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        NameOfCompany = c.String(),
                        UserCompanyPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPoints", "UserId", "dbo.Users");
            DropForeignKey("dbo.CompanyCodes", "CompanyId", "dbo.Companies");
            DropIndex("dbo.UserPoints", new[] { "UserId" });
            DropIndex("dbo.CompanyCodes", new[] { "CompanyId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserPoints");
            DropTable("dbo.Companies");
            DropTable("dbo.CompanyCodes");
        }
    }
}
