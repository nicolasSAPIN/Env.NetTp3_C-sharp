namespace WEBTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWEBTPMigr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Firstname", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Firstname", c => c.String(nullable: false));
        }
    }
}
