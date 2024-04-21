using AutoMapper;
using KeyNerd.Api;
using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Persistence;
using KeyNerd.Service;
using KeyNerd.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KeyNerd.Test
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependenciesSetup(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext, TestDbContext>(options => options.UseInMemoryDatabase(databaseName: "InMemoryDb"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<IMapper>(x =>
            //{
            //    var profile = new AutoMapperProfile();
            //    var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            //    return new Mapper(configuration);
            //});

            return services;
        }
    }
}
