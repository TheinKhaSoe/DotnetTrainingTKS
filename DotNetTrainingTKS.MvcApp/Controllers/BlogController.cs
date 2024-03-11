using DotNetTrainingTKS.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingTKS.MvcApp.Controllers
{
    //https://localhost:7080/Blog/Index
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController()
        {
            _context = new AppDbContext();
        }

        //https://localhost:7080/Blog/Index
        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _context.Blogs.ToList();
            return View("BlogIndex",lst);
        }

        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x=>x.BlogId == id);
            if(item is null)
            {
                return Redirect("/Blog");
            }
            return View("BlogEdit",item);
        }
    }
}
