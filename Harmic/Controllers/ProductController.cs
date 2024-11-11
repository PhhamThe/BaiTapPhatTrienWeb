using Harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.Controllers
{
    public class ProductController : Controller
    {
        private readonly BanHangHoaQuaContext _context;
        public ProductController(BanHangHoaQuaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Tạo route để khi bấm vào product sẽ đến trang chi tiết này
        [Route("/Product/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int?id)
        {
            if(id==null )

            {
                return NotFound();
            }
            var product = await _context.TbProducts.Include(i => i.CategoryProduct).FirstOrDefaultAsync(m => m.ProductId == id);
            if(product == null )
            {
                return NotFound();
            }
            ViewBag.ProductReview = _context.TbProductReviews.Where(i => i.ProductId == id && i.IsActive).ToList();
            ViewBag.ProductRelated = _context.TbProducts.Where(i => i.ProductId != id && i.CategoryProductId == product.CategoryProductId).Take(5).OrderByDescending(i => i.ProductId).ToList();
            return View(product);
        }
    }
}
