using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBLog.Data;
using MyBLog.Models;

namespace MyBLog.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly BlogDbContext db;
        public IndexModel(BlogDbContext _db)
        {
                db= _db;
        }
        public List<Blog> Blogs { get; set; }
        public void OnGet()
        {
            Blogs = db.Blogs.ToList();
        }
    }
}
