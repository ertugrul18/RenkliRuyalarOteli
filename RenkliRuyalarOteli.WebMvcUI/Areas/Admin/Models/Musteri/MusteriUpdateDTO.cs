using RenkliRuyalarOteli.Entities.Entites.Concrete;

namespace RenkliRuyalarOteli.WebMvcUI.Areas.Admin.Models.Musteri
{
    public class MusteriUpdateDTO
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyadi { get; set; }
        public bool Cinsiyet { get; set; }
        public string MusteriTcNo { get; set; }
        public string CepNo { get; set; }

        public Guid KullaniciId { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlari { get; set; }
    }
}
