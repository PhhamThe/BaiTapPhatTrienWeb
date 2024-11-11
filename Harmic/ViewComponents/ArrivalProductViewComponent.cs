using Harmic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harmic.ViewComponents
{
    public class ArrivalProductViewComponent : ViewComponent
    {
        private readonly BanHangHoaQuaContext _context;
        public ArrivalProductViewComponent(BanHangHoaQuaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var items = _context.TbProducts.OrderBy(m => (bool)m.IsNew==true).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
