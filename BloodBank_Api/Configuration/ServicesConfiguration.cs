using BloodBank_DBConfiguration.ConnectionServices;
using BloodBank_Interfaces.InterfacesResources;
using BloodBank_Repositories.RepositoriesResources;
using BloodBank_Repositories.RepositoriesResources.CollectionRecord;
using BloodBank_Repositories.RepositoriesResources.DonorRecord;
using BloodBank_Repositories.RepositoriesResources.IssueRecord;
using BloodBank_Repositories.RepositoriesResources.StockRecord;

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
            services.AddScoped<IADOConnectionRepository, AdoConnectionReositery>()
            .AddScoped<ILoginInterface, LoginServices>()
            .AddScoped<IDashboardRecord, DashboardServices>()
            .AddScoped<ICollectionRecord, CollectionRecordServices>()
            .AddScoped<IDonorRecord, DonorRecordServices>()
            .AddScoped<IissueRecord, IssueRecordServices>()
            .AddScoped<IStockRecord, StockRecordServices>();


           

        }

    }
}
