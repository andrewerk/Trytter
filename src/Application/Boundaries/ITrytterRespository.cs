using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Boundaries
{
    public interface ITrytterRepository
    {
        public void AddUser(string username, string password, EModule module, string email, string status);
        public User GetUserById(int userId);
        public User GetUserByCredentials(string username, string password);

        public int GetUserIdByUsername(string username);
        public Post GetPostById(int postId);
        public IEnumerable<Post> GetPosts();
        public IEnumerable<Post> GetPostsByUser(int userId);
        public void AddPost(string postTitle, string postContent, int userId);
        public void DeletPost(int postId);
        public void EditPost(int postId, string postTitle, string postContent);

    }
}
