using Application.Boundaries;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TrytterRepository : ITrytterRepository
    {
        private readonly ITrytterContext _context;

        public TrytterRepository(ITrytterContext context)
        {
            _context = context;
        }
        public async void AddPost(string postTitle, string postContent, int userId)
        {
            var post = new Post
            {
                PostContent = postContent,
                PostTitle = postTitle,
                UserId = userId 
            };
            await _context.Posts.AddAsync(post);
            _context.SaveChanges();
        }
        public int GetUserIdByUsername(string username)
        {
            var user = _context.Users.Where(u => u.Username == username).FirstOrDefault();
            return user.UserId;
        }

        public async void AddUser(string username, string password, EModule module, string email, string status)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Module = module,
                Email= email,
                Status = status
            };
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }

        public async void DeletPost(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public async void EditPost(int postId, string postTitle, string postContent)
        {
            var post = GetPostById(postId);
            post.PostContent = postContent;
            post.PostTitle = postTitle;
            _context.SaveChanges(); ;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts;
        }
        public IEnumerable<Post> GetPostsByUser(int userId)
        {
            var posts = _context.Posts.Where(p => p.UserId == userId).ToList();
            return posts;
        }

        public User GetUserByCredentials(string username, string password)
        {
            var user = _context.Users.Where(u => u.Username== username && u.Password == password).FirstOrDefault();
            return user;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }

        public Post GetPostById(int postId)
        {
            return _context.Posts.Where(u => u.PostId == postId).FirstOrDefault();
        }
    }
}
