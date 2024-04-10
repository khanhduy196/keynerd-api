using KeyNerd.Domain.Entities;
using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace KeyNerd.Test.Repository
{
    [TestFixture]
    public class RepositoryTest : BaseTest
    {
        private long id = 0;
        private IRepository<Category> repositoy;

        [OneTimeSetUp]
        public void Setup()
        {
            SetupDependencies();
            repositoy = new Repository<Category>(dbContext);
        }

        [Test, Order(1)]
        public async Task When_I_Add_A_New_Entity_And_Commit_It_The_Record_Inserted_Gets_An_Id()
        {
            var category = new Category() { Name = "Test Category" };
            
            repositoy.Add(category);
            await unitOfWork.CommitAsync();

            id = category.Id;

            Assert.IsTrue(id > 0);
        }

        [Test, Order(2)]
        public async Task When_I_Get_An_Entity_By_Id_Get_The_Entity()
        {
            var expected = await repositoy.GetByIdAsync(id);

            Assert.NotNull(expected);
            Assert.That(expected.Id, Is.EqualTo(id));
            Assert.IsTrue(expected.Name.Equals("Test Category"));
        }

        [Test, Order(3)]
        public async Task When_I_Update_An_Entity_The_Entity_Get_Updated()
        {
            var category = await repositoy.GetByIdAsync(id);
            category.Name = "Test Category Updated";
            repositoy.Update(category);
            await unitOfWork.CommitAsync();

            var expected = await repositoy.GetByIdAsync(id);

            Assert.IsTrue(expected.Name.Equals("Test Category Updated"));
        }

        [Test, Order(4)]
        public async Task When_I_Get_All_Entities_Get_All_Entities()
        {
            repositoy.Add(new Category() { Name = "Test Category 1" });
            repositoy.Add(new Category() { Name = "Test Category 2" });
            await unitOfWork.CommitAsync();

            var expected = await repositoy.GetAllAsync();

            Assert.IsTrue(expected.Count >= 2);
        }


        [Test, Order(5)]
        public async Task When_I_Delete_An_Entity_The_Entity_Get_Deleted()
        {
            var category = await repositoy.GetByIdAsync(id);
            repositoy.Delete(category);
            await unitOfWork.CommitAsync();

            var expected = await repositoy.GetByIdAsync(id);

            Assert.Null(expected);
        }

 
    }
}
