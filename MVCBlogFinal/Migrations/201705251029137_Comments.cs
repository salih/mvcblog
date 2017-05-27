namespace MVCBlogFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "Comment_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Comment_Id");
            AddForeignKey("dbo.Posts", "Comment_Id", "dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Posts", new[] { "Comment_Id" });
            DropColumn("dbo.Posts", "Comment_Id");
            DropTable("dbo.Comments");
        }
    }
}
