using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBLog.Data;

namespace MyBLog.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        private readonly BlogDbContext _db;

        public TestController(BlogDbContext db)
        {
            _db = db;
        }

        [Route("api/one")]
        public IActionResult GetUserProfile()
        {
            var user = _db.User
                .Include(u=>u.Profile)
                .ToList();  
            return Ok(user);
        }

        [Route("api/blog")]
        public IActionResult GetBlogs()
        {
            var blogs = _db.Blogs
                .Include(u => u.Posts)
                .ThenInclude(u=>u.Comments)
                .ToList();
            return Ok(blogs);
        }

        [Route("api/post")]
        public IActionResult GetPosts()
        {
            var posts = _db.Posts
                .Include(p=>p.Blog)
                .Include(u=>u.Comments)
                .ToList();
            return Ok(posts);
        }

        [Route("api/tag")]
        public IActionResult GetPostTags()
        {
            var posts = _db.Posts
                .Include(p => p.Blog)
                .Include(p=>p.PostTags)
                .Include(u => u.Comments)
                .ToList();
            return Ok(posts);
        }
    }
}
