using Harmic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harmic.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly BanHangHoaQuaContext _context;
        public CategoryViewComponent(BanHangHoaQuaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Lấy lên danh sách các Menu từ cơ sở dữ liệu
            var items = _context.TbCategories.OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }

    }
}
