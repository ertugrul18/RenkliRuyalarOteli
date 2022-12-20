using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class OdaFiyatController : Controller
    {
        private readonly IOdaFiyatManager odaFiyatManager;

        public OdaFiyatController(IOdaFiyatManager odaFiyatManager)
        {
            this.odaFiyatManager = odaFiyatManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await odaFiyatManager.FindAllAsnyc();
            return View(result);
        }
    }
}
