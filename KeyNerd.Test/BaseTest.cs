using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeyNerd.Test
{
    public abstract class BaseTest
    {

        #region Members

        protected ServiceProvider serviceProvider;
        protected AppDbContext dbContext;
        protected IUnitOfWork unitOfWork;
        protected IConfiguration configuration;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        #endregion

        #region Methods

        protected void SetupDependencies()
        {
            var services = new ServiceCollection();
            services.DependenciesSetup();

            serviceProvider = services.BuildServiceProvider();
            dbContext = serviceProvider.GetService<AppDbContext>();
            dbContext?.Database?.EnsureCreated();
            unitOfWork = serviceProvider.GetService<IUnitOfWork>();
        }

        #endregion

        #region Events


        #endregion

    }
}
