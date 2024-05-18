using System.Runtime.InteropServices;
using static BloodBank_DBConfiguration.DatabaseContext.DbInfo;

namespace BloodBank_Api.Configuration
{
    public static class ConfigurationConnection
    {
        public static IServiceCollection AdoConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            //If so many connection needed just add same here.
            var connectionBloodBank = string.Empty;
            var connectionBloodBanklocal = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                connectionBloodBanklocal = configuration.GetConnectionString("E_ChikitsaDbConnStrlocal");
                connectionBloodBank = configuration.GetConnectionString("E_ChikitsaDbConnStr");
            }
            services.AddSingleton(new BloodBankDbInfo(connectionBloodBanklocal));
            services.AddSingleton(new BloodBankDbInfo(connectionBloodBank));


            return services;
        }
    }
}
