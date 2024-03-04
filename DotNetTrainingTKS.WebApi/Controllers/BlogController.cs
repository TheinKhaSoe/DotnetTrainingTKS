using DotNetTrainingTKS.WebApi;
using DotNetTrainingTKS.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingTKS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> blogs = _db.Blogs.ToList();
            return Ok(blogs);
        }
        [HttpPost]
        public IActionResult CrateBlog([FromBody]BlogModel blog)
        {
            var obj = _db.Blogs.Add(blog);
            _db.SaveChanges();
            return Ok("Added Successfully");
        }
        [HttpPut]
        public IActionResult UpdateBlog(int id, [FromBody]BlogModel blog)
        {
            var obj = _db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            obj.BlogTitle = blog.BlogTitle;
            obj.BlogAuthor = blog.BlogAuthor;
            obj.BlogContent = blog.BlogContent;
            _db.SaveChanges();
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        public IActionResult DeleteBlog(int id)
        {
            var obj = _db.Blogs.FirstOrDefault(x=>x.BlogId==id);
            _db.Blogs.Remove(obj);
            _db.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }
}
