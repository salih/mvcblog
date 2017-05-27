using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlogFinal.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Display(Name="Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Title")]

        public string Title { get; set; }
        [Display(Name = "Content")]

        public string Content { get; set; }
        [Display(Name = "Author")]

        public int AuthorID { get; set; }

        public int CategoryID { get; set; }
        public string URL { get; set; }
        [Display(Name = "Total Like")]

        public int Likes { get; set; }

        public virtual Category Category{ get; set; }
        public virtual AuthorInfo Author { get; set; }

        public virtual Comment Comment { get; set; }
    }
}