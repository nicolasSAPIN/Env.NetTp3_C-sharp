namespace WEBTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        IdBook = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        NbPages = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        IdUser = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.IdBook)
                .ForeignKey("dbo.User", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IdUser = c.Long(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                        CurrentBook_IdBook = c.Long(),
                        CurrentRole_IdRole = c.Long(),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("dbo.Book", t => t.CurrentBook_IdBook)
                .ForeignKey("dbo.Role", t => t.CurrentRole_IdRole)
                .Index(t => t.CurrentBook_IdBook)
                .Index(t => t.CurrentRole_IdRole);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        IdRole = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdRole);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        User_IdUser = c.Long(nullable: false),
                        Role_IdRole = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_IdUser, t.Role_IdRole })
                .ForeignKey("dbo.User", t => t.User_IdUser, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_IdRole, cascadeDelete: true)
                .Index(t => t.User_IdUser)
                .Index(t => t.Role_IdRole);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "IdUser", "dbo.User");
            DropForeignKey("dbo.UserRole", "Role_IdRole", "dbo.Role");
            DropForeignKey("dbo.UserRole", "User_IdUser", "dbo.User");
            DropForeignKey("dbo.User", "CurrentRole_IdRole", "dbo.Role");
            DropForeignKey("dbo.User", "CurrentBook_IdBook", "dbo.Book");
            DropIndex("dbo.UserRole", new[] { "Role_IdRole" });
            DropIndex("dbo.UserRole", new[] { "User_IdUser" });
            DropIndex("dbo.User", new[] { "CurrentRole_IdRole" });
            DropIndex("dbo.User", new[] { "CurrentBook_IdBook" });
            DropIndex("dbo.Book", new[] { "IdUser" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Book");
        }
    }
}
