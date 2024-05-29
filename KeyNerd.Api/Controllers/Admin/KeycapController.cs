using AutoMapper;
using KeyNerd.DataTransfer.Requests;
using KeyNerd.DataTransfer.Responses;
using KeyNerd.Service.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace KeyNerd.Api.Controllers.Admin
{
    [ApiController]
    public class KeycapController : BaseAdminController
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IKeycapService _service;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public KeycapController(IKeycapService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create a keycap
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> Create([FromForm] CreateKeycapRequest request)
        {
            var result = await _service.Create(request);

            return Ok(result.Id); ;
        }

        /// <summary>
        /// Update a keycap
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromForm] UpdateKeycapRequest request)
        {
            await _service.Update(request);

            return Ok();
        }


        /// <summary>
        /// Get a keycap info by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetKeycapByIdResponse>> GetById([FromRoute] long id)
        {
            var keycap = await _service.GetById(id);

            var response = _mapper.Map<GetKeycapByIdResponse>(keycap);

            return Ok(response);
        }

        /// <summary>
        /// Get list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public ActionResult<GetPaginatedListResponse<GetPaginatedKeycapListResponse>> GetList([FromQuery] GetPaginatedListRequest request)
        {
            var list = _service.GetList(request.ItemsPerPage, request.CurrentPage, request.SearchQuery);

            return Ok(_mapper.Map<GetPaginatedListResponse<GetPaginatedKeycapListResponse>>(list));
        }

        /// <summary>
        /// Create a keycap
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);

            return Ok();
        }


        #endregion

        #region Events


        #endregion
    }
}
