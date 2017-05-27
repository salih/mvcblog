using System.ComponentModel.DataAnnotations;

namespace MVCBlogFinal.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name="Category Name")]
        public string Name { get; set; }

        public virtual System.Collections.Generic.ICollection<Post> Posts { get; set; }
    }
}