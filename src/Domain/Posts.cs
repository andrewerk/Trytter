using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }

    }
}
