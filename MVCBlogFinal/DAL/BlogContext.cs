using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCBlogFinal.Models;
namespace MVCBlogFinal.DAL
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<AuthorInfo> Authors { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public BlogContext() : base("name=BlogContext")
        {
            Database.SetInitializer<BlogContext>(new CreateDatabaseIfNotExists<BlogContext>());

        }

        public System.Data.Entity.DbSet<MVCBlogFinal.Models.SiteSettings> SiteSettings { get; set; }
    }
}