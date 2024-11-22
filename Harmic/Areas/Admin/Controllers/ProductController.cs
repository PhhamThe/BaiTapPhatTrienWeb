using Harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly BanHangHoaQuaContext _context;

        public ProductController(BanHangHoaQuaContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var model = _context.TbProducts.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["CategoryProductId"] = new SelectList(_context.TbProductCategories, "CategoryProductId", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Title,Alias,CategoryProductId,Description,Detail,Image,Price,PriceSale,Quantity,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsNew,IsBestSeller,UnitInStock,IsActive,Star")] TbProduct product)
        {
            if (ModelState.IsValid)
            {
                product.Alias = Harmic.Utilities.Function.TitleSlugGenerationAlias(product.Alias);
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryProductId"] = new SelectList(_context.TbProductCategories, "CategoryProductId", "CategoryProductId", product.CategoryProductId);
            return View(product);

        }
        public IActionResult Edit(int? id)
        {
            var menu = _context.TbProducts.Where(m => m.ProductId == id).FirstOrDefault();
            return View(menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ProductId,Title,Alias,CategoryProductId,Description,Detail,Image,Price,PriceSale,Quantity,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsNew,IsBestSeller,UnitInStock,IsActive,Star")] TbProduct product)
        {


            if (ModelState.IsValid)
            {
                product.Alias = Harmic.Utilities.Function.TitleSlugGenerationAlias(product.Alias);
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryProductId"] = new SelectList(_context.TbProductCategories, "CategoryProductId", "CategoryProductId", product.CategoryProductId);
            return View(product);
        }

        // GET: Admin/Menus/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var product = _context.TbProducts.Where(m => m.ProductId == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, [Bind("ProductId,Title,Alias,CategoryProductId,Description,Detail,Image,Price,PriceSale,Quantity,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsNew,IsBestSeller,UnitInStock,IsActive,Star")] TbProduct product)
        {


            if (ModelState.IsValid)
            {
                _context.Remove(product.ProductId = id);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
