using System.ComponentModel.DataAnnotations;

namespace AspBlog.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Content { get; set; } = "";

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";
    }
}
