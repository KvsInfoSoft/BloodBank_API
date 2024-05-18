using BloodBank_DBConfiguration.ConnectionServices;
using BloodBank_Interfaces.InterfacesResources;

namespace BloodBank_Api.Configuration
{
    public static class ServicesConfiguration
    {
        public static void ConfigureRepositeries(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IADOConnectionRepository, AdoConnectionReositery>();
           

        }

    }
}
