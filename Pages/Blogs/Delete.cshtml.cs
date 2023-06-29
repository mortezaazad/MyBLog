using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBLog.Data;
using MyBLog.Models;

namespace MyBLog.Pages.Blogs
{
    public class DeleteModel : PageModel
    {

        private readonly BlogDbContext db;
        public DeleteModel(BlogDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public Blog Blog { get; set; }
        public void OnGet(int id)
        {
            Blog = db.Blogs.Find(id);
        }

        public IActionResult OnPost()
        {
            var blog = db.Blogs.Find(Blog.Id);
            if (blog == null)
                return NotFound();
            else
            {
                db.Remove(blog);
                db.SaveChanges();
            }
            return Redirect("/Blogs/Index");
        }
    }
}
