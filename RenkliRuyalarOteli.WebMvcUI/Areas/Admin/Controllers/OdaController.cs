using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Concrete;
using RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Odalar;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class OdaController : Controller
    {
        private readonly IOdaManager odaManager;

        public OdaController(IOdaManager odaManager)
        {
            this.odaManager = odaManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await odaManager.FindAllAsnyc();
            return View(result);
        }


        public async Task<IActionResult> Kayit()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            var oda = odaManager.FindAsync(p => p.Id == Id).Result;
            OdalarUpdateDTO updateDto = new OdalarUpdateDTO
            {
                Id = Id,
                KisiSayisi = oda.KisiSayisi,
                Durum = oda.Durum,
                KullaniciId = oda.KullaniciId,
                OdaFiyatlari = oda.OdaFiyatlari,
                OdaNo = oda.OdaNo,
                Rezervasyonlari = oda.Rezervasyonlari

            };
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OdalarUpdateDTO updateDTO)
        {
            var oda = odaManager.FindAsync(p => p.Id == updateDTO.Id).Result;
            oda.Durum = updateDTO.Durum;
            oda.KullaniciId = updateDTO.KullaniciId;
            oda.OdaFiyatlari = updateDTO.OdaFiyatlari;
            oda.KisiSayisi = updateDTO.KisiSayisi;
            oda.Rezervasyonlari = updateDTO.Rezervasyonlari;
            oda.OdaNo = updateDTO.OdaNo;


            var sonuc = await odaManager.UpdateAsync(oda);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Oda");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Lutfen Biraz sonra tekrar denbeyiniz");

                return View(updateDTO);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createDto = new OdalarCreateDTO();
            return View(createDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OdalarCreateDTO createDTO)
        {
            var oda = new Oda
            {
                Id = createDTO.Id,
                OdaNo = createDTO.OdaNo,
                Durum = createDTO.Durum,
                KullaniciId = createDTO.KullaniciId,
                Rezervasyonlari = createDTO.Rezervasyonlari,
                OdaFiyatlari = createDTO.OdaFiyatlari,
                KisiSayisi = createDTO.KisiSayisi

            };
            var sonuc = await odaManager.CreateAsync(oda);

            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Oda");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Daha Sonra Tekrar Deneyiniz");

                return View(createDTO);
            }
        }
    }
}

