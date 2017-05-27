namespace MVCBlogFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateAuthor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Authors", newName: "AuthorInfoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AuthorInfoes", newName: "Authors");
        }
    }
}
