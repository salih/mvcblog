namespace MVCBlogFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingsGeneral : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc = c.String(),
                        About = c.String(),
                        PostPerPage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SiteSettings");
        }
    }
}
