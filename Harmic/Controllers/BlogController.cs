using Harmic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harmic.Controllers
{
    public class BlogController : Controller
    {
        private readonly BanHangHoaQuaContext context = new BanHangHoaQuaContext();
        public BlogController(BanHangHoaQuaContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Blog/{Id}.cshtml")]
        public async Task<IActionResult> DetailBlog(int Id)
        {
            var blog = context.TbBlogs.FirstOrDefault(m=>m.BlogId==Id);
            var detail = context.TbBlogComments.Where(m => m.BlogId == Id).ToList();
            ViewBag.detail = detail;
            return View(blog);
        }
    }
}
