using RenkliRuyalarOteli.BL.Abstract;
using RenkliRuyalarOteli.BL.Concrete;

namespace RenkliRuyalarOteli.WebMvcUI.Extensions
{
    public static class MyExtensions
    {
        public static IServiceCollection AddRenkliRuyalarManager(this IServiceCollection services)
        {
            services.AddScoped<IKullaniciManager, KullaniciManager>();
            services.AddScoped<IMusteriManager, MusteriManager>();
            services.AddScoped<IOdaManager, OdaManager>();
            services.AddScoped<IOdaFiyatManager, OdaFiyatManager>();
            services.AddScoped<IRezervasyonManager, RezervasyonManager>();
            services.AddScoped<IRezarvasyonDetayManager, RezervasyonDetayManager>();
            services.AddScoped<IRoleManager, RoleManager>();

            return services;
        }
    }
}
