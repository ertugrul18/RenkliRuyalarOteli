using RenkliRuyalarOteli.Entities.Entites.Abstract;

namespace RenkliRuyalarOteli.Entities.Entites.Concrete
{
    public class Role : BaseEntity
    {
        public string? RoleName { get; set; }

        public ICollection<Kullanici>? Kullanicilar { get; set; }

    }
}
