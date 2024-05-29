using AutoMapper;
using KeyNerd.Api.Controllers.EndUser;
using KeyNerd.DataTransfer.Requests;
using KeyNerd.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace KeyNerd.Test.Controllers
{
    [TestFixture]
    public class CategoryControllerTest : BaseTest
    {
        private IMapper mapper;
        private ICategoryService service;

        [OneTimeSetUp]
        public void Setup()
        {
            SetupDependencies();
            mapper = serviceProvider.GetService<IMapper>();
            service = serviceProvider.GetService<ICategoryService>();
        }

        [Test]
        public async Task When_I_Call_CreateCategory_With_Valid_Payload_I_Get_Htpp200()
        {
            var controller = new CategoryController(service, mapper);
            var request = new CreateCategoryRequest()
            {
                Name = "New Category"
            };
            var expected = (await controller.Create(request)) as OkResult;

            Assert.NotNull(expected);
            Assert.IsTrue(expected.StatusCode == (int)HttpStatusCode.OK);
        }
    }
}
