using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class RezervasyonController : Controller
    {
        private readonly IRezervasyonManager rezervasyonManager;

        public RezervasyonController(IRezervasyonManager rezervasyonManager)
        {
            this.rezervasyonManager = rezervasyonManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await rezervasyonManager.FindAllAsnyc();
            return View(result);
        }
    }
}
