namespace MVCBlogFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        AuthorID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        URL = c.String(),
                        Likes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Posts", new[] { "AuthorID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Posts");
            DropTable("dbo.Authors");
        }
    }
}
