using Microsoft.Extensions.DependencyInjection;
using TDRData.Repositories;
using TDRData.Repositories.IRepositories;
using TDRDomain.Services;
using TDRDomain.Services.IServices;

namespace TDRConfiguration
{
    public static class DiConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<IPeriodRepository, PeriodRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IPeriodService, PeriodService>();
        }
    }
}
