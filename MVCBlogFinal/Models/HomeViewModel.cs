using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlogFinal.Models
{
    public class HomeViewModel
    {
        public IPagedList<Post> Posts { get; set; }
    }
}