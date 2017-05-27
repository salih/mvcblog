namespace MVCBlogFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Content");
        }
    }
}
