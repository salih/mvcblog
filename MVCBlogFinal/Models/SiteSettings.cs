using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlogFinal.Models
{
    public class SiteSettings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

        public string About { get; set; }
        public int PostPerPage { get; set; }
    }
}