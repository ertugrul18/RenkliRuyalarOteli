using RenkliRuyalarOteli.Entities.Entites.Concrete;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Odalar
{
    public class OdalarCreateDTO
    {
        public Guid Id { get; set; }
        public string OdaNo { get; set; }
        public byte KisiSayisi { get; set; }
        public bool Durum { get; set; } = true;
        public Guid KullaniciId { get; set; }
        public ICollection<OdaFiyat> OdaFiyatlari { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlari { get; set; }
    }
}
