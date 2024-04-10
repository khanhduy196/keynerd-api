using KeyNerd.Domain.Entities;
using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Service;
using KeyNerd.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace KeyNerd.Test.Services
{
    [TestFixture]
    public class CategoryServiceTest : BaseTest
    {
        private ICategoryService service;
        IRepository<Category> repository;

        [OneTimeSetUp]
        public void Setup()
        {
            SetupDependencies();
            repository = serviceProvider.GetService<IRepository<Category>>();
            service = new CategoryService(unitOfWork, repository);
        }

        [Test, Order(1)]
        public async Task When_I_Create_A_New_Category_A_New_Category_Is_Created()
        {
            var category = new Category() { Name = "New category" };
            await service.Create(category);

            Assert.IsTrue(category.Id > 0);
        }
    }
}
