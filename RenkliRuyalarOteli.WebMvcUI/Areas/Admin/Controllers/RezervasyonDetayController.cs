using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class RezervasyonDetayController : Controller
    {
        private readonly IRezarvasyonDetayManager rezarvasyonDetayManager;

        public RezervasyonDetayController(IRezarvasyonDetayManager rezarvasyonDetayManager)
        {
            this.rezarvasyonDetayManager = rezarvasyonDetayManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await rezarvasyonDetayManager.FindAllAsnyc();
            return View(result);
        }
    }
}
