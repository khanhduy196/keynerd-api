using AutoMapper;
using KeyNerd.DataTransfer.Requests;
using KeyNerd.Domain.Entities;
using KeyNerd.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KeyNerd.Api.Controllers.EndUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _service.Create(category);
            return Ok();
        }

        #endregion

        #region Events


        #endregion
    }
}
