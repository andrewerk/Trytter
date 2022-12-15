using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public EModule Module { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}