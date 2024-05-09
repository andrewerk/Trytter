using Application.Boundaries;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrytterController : ControllerBase
    {
        private readonly ILogger<TrytterController> _logger;
        private readonly ITrytterRepository _repository;

        public TrytterController(ILogger<TrytterController> logger, ITrytterRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("/users")]
        public IActionResult AddUser([FromBody] UserRequest user)
        {
            _repository.AddUser(user.Username, user.Password, user.Module, user.Email, user.Status);
            return Ok();
        }

        [HttpPost("/user/login")]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            var userFound = _repository.GetUserByCredentials(user.username, user.password);
            var tokenGenerator = new TokenGenerator();
            
            var token = tokenGenerator.Generate(userFound);
            return Ok(token);
        }

        [Authorize]
        [HttpPost("/posts/{userId}")]
        public IActionResult AddPost([FromBody] PostRequest post, [FromRoute] int userId)
        {
            _repository.AddPost(post.PostTitle, post.PostContent, userId);
            return Ok();
        }

        [Authorize]
        [HttpPut("/posts/{postId}")]
        public IActionResult EditPost([FromBody] PostRequest post, [FromRoute] int postId)
        {
            _repository.EditPost(postId, post.PostTitle, post.PostContent);
            return Ok();
        }

        [Authorize]
        [HttpDelete("/posts/{postId}")]
        public IActionResult DeletePost([FromRoute] int postId)
        {
            _repository.DeletPost(postId);
            return NoContent();
        }

        [Authorize]
        [HttpGet("/posts")]
        public IActionResult GetPosts()
        {
            var posts = _repository.GetPosts();
            return Ok(posts);
        }

        [Authorize]
        [HttpGet("/posts/{postId}")]
        public IActionResult GetPostsById(int postId)
        {
            var posts = _repository.GetPostById(postId);
            return Ok(posts);
        }

        [Authorize]
        [HttpGet("/posts/user/{userId}")]
        public IActionResult GetPostByUser(int userId, [FromQuery] bool onlyLastPost)
        {
            var posts = _repository.GetPostsByUser(userId);
            return Ok(posts);
        }

        [Authorize]
        [HttpGet("/posts/search/{username}")]
        public IActionResult GetPostByUser(string username)
        {
            var userId = _repository.GetUserIdByUsername(username);
            var posts = _repository.GetPostsByUser(userId);
            return Ok(posts);
        }

        [Authorize]
        [HttpGet("/posts/search/lastpost/{username}")]
        public IActionResult GetLastPostByUser(string username)
        {
            var userId = _repository.GetUserIdByUsername(username);
            var post = _repository.GetPostsByUser(userId).LastOrDefault();
            return Ok(post);
        }
    }
}