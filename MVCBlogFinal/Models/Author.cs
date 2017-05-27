using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlogFinal.Models
{
    public class Author : IdentityUser
    {
        public virtual AuthorInfo AuthorInfo { get; set; }
    }
    public class AuthorInfo
    {
        public int ID { get; set; }
        [Display(Name="Author")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class MyDbContext : IdentityDbContext<Author>
    {
        public MyDbContext()
            : base("BlogContext")
        {
        }
        public System.Data.Entity.DbSet<AuthorInfo> AuthorInfo { get; set; }
    }



}