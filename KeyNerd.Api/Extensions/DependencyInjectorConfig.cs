using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Persistence;
using KeyNerd.Service;
using KeyNerd.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KeyNerd.Api.Extensions
{
    public static class DependencyInjectorConfig
    {
        /// <summary>
        /// Registration of all application dependencies - IoC.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection DependenciesSetup(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")));
            //services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IUserManager, UserManager>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IKeycapService, KeycapService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IStorageService, S3StorageService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>)); ;
            return services;
        }
    }
}
