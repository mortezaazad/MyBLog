using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBLog.Data;
using MyBLog.Models;

namespace MyBLog.Pages.Blogs;

public class CreateModel : PageModel
{
    private readonly BlogDbContext db;
    public CreateModel(BlogDbContext _db)
    {
        db = _db;
    }
    [BindProperty]
    public Blog Blog { get; set; }
    public IActionResult OnPost(Blog blog)
    {
        db.Blogs.Add(blog);
        db.SaveChanges();
        return Redirect("/Blogs/Index");
    }
}
