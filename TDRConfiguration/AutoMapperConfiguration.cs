using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TDRDomain.Profiles;

namespace TDRConfiguration
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new MenuProfile());
                mc.AddProfile(new VoteProfile());
                mc.AddProfile(new PeriodProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
