using Harmic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harmic.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        BanHangHoaQuaContext _context;
        public BlogViewComponent(BanHangHoaQuaContext context) {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs.Where(m => (bool)m.IsActive == true).ToList();
            return await Task.FromResult(View(items));
        }

    }
}
