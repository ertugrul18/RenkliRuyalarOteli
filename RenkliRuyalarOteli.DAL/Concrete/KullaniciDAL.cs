using RenkliRuyalarOteli.DAL.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Concrete;

namespace RenkliRuyalarOteli.DAL.Concrete
{
    public class KullaniciDAL : RepositoryBase<Kullanici>, IKullaniciDAL
    {
        public override Task<int> CreateAsync(Kullanici entity)
        {
            return base.CreateAsync(entity);
            
        }
    }
}
