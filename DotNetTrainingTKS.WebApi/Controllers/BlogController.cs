using DotnetTrainingTKS.ConsoleApp.EFCoreExamples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingTKS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;

        [HttpGet]
        public IActionResult GetBlogs()
        {
            return Ok("GetBlogs");
        }
        [HttpGet]
        public IActionResult CrateBlog()
        {
            return Ok("Create BLog");
        }
        [HttpGet]
        public IActionResult UpdateBlog()
        {
            return Ok("Update Blog");
        }
        [HttpGet]
        public IActionResult DeleteBlog()
        {
            return Ok("Delete Blog");
        }
    }
}
