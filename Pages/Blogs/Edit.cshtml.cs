using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBLog.Data;
using MyBLog.Models;
using System.Reflection.Metadata;

namespace MyBLog.Pages.Blogs
{
    public class EditModel : PageModel
    {

        private readonly BlogDbContext db;
        public EditModel(BlogDbContext _db)
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
            blog.Name = Blog.Name;
            blog.Description = Blog.Description;
            db.Update(blog);
            db.SaveChanges();
            return Redirect("/Blogs/Index");
        }
    }
}
