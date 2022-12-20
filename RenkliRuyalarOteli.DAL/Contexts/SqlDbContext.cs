using Microsoft.EntityFrameworkCore;
using RenkliRuyalarOteli.Entities.Entites.Abstract;
using RenkliRuyalarOteli.Entities.Entites.Concrete;
using System.Reflection;

namespace RenkliRuyalarOteli.DAL.Contexts
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Oda> Odalar { get; set; }
        public DbSet<OdaFiyat> OdaFiyatlari { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<RezervasyonDetay> RezervasyonDetaylari { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }

        public DbSet<Role> Roller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;Database=RenkliRuyalarOteli;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatus();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatus()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["Status"] = Status.Active;
                        entry.CurrentValues["CreateDate"] = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues["Status"] = Status.Update;
                        entry.CurrentValues["UpdateDate"] = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["Status"] = Status.Delete;
                        entry.CurrentValues["UpdateDate"] = DateTime.Now;
                        break;


                }
            }
        }
    }
}
