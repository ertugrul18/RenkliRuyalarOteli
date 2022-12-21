using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RenkliRuyalarOteli.BL.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Concrete;
using RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Musteri;
using System.Security.Claims;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MusteriController : Controller
    {
        private readonly IMusteriManager musteriManager;

        public MusteriController(IMusteriManager musteriManager)
        {
            this.musteriManager = musteriManager;
        }
        public async Task<IActionResult> Index()
        {

            var result = await musteriManager.FindAllAsnyc();
            return View(result);
        }


        ////
        ///

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            var musteri = musteriManager.FindAsync(p => p.Id == Id).Result;
            MusteriUpdateDTO updateDto = new MusteriUpdateDTO
            {
                Id = Id,
                Ad = musteri.Ad,
                Soyadi = musteri.Soyadi,
                Cinsiyet = musteri.Cinsiyet,
                MusteriTcNo = musteri.MusteriTcNo,
                CepNo = musteri.CepNo,

            };
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MusteriUpdateDTO updateDTO)
        {
            var musteri = musteriManager.FindAsync(p => p.Id == updateDTO.Id).Result;
            musteri.Ad = updateDTO.Ad;
            musteri.Soyadi = updateDTO.Soyadi;
            musteri.Cinsiyet = updateDTO.Cinsiyet;
            musteri.MusteriTcNo = updateDTO.MusteriTcNo;
            musteri.CepNo = updateDTO.CepNo;

            musteri.UpdateDate = DateTime.Now;
            musteri.Status = Status.Active;

            var sonuc = await musteriManager.UpdateAsync(musteri);
            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Musteri");
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
            var createDto = new MusteriCreateDTO();
            return View(createDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MusteriCreateDTO createDTO)
        {
            var musteri = new Musteri
            {
                Id = createDTO.Id,
                Ad = createDTO.Ad,
                Soyadi = createDTO.Soyadi,
                Cinsiyet = createDTO.Cinsiyet,
                MusteriTcNo = createDTO.MusteriTcNo,
                CepNo = createDTO.CepNo,
                KullaniciId = Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value),
                CreateDate = DateTime.Now,
                Status = Status.Active
            };
            var sonuc = await musteriManager.CreateAsync(musteri);

            if (sonuc > 0)
            {
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                ModelState.AddModelError("", "Bilinmeyen bir hata olustu. Daha Sonra Tekrar Deneyiniz");

                return View(createDTO);
            }
        }
        //public void Delete(Guid Id)
        //{
        //    Musteri musterii = musteriManager.FindAllAsnyc(p => p.Id == Id);
        //    musteriManager.DeleteAsync(musterii);
        //}
        //public ActionResult Delete(Guid id)
        //{

        //    Musteri SilinecekMusteri = musteriManager.Where().FirstOrDefault();
        //    return View(SilinecekOgrenci);
        //}




    }
}
