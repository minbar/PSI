namespace PSI_X.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpoints_update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserPoints", "NameOfCompany");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPoints", "NameOfCompany", c => c.String());
        }
    }
}
