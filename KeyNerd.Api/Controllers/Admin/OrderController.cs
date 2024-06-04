using AutoMapper;
using KeyNerd.DataTransfer.Requests;
using KeyNerd.DataTransfer.Responses;
using KeyNerd.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KeyNerd.Api.Controllers.Admin
{
    public class OrderController : BaseAdminController
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderRequest request)
        {
            var result = await _service.Create(request);

            return Ok(result.Id); ;
        }

        /// <summary>
        /// Get list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public ActionResult<GetPaginatedListResponse<GetPaginatedOrderListResponse>> GetList([FromQuery] GetPaginatedOrderListRequest request)
        {
            var list = _service.GetList(request.ItemsPerPage, request.CurrentPage, request.SearchQuery, request.Status);

            return Ok(_mapper.Map<GetPaginatedListResponse<GetPaginatedOrderListResponse>>(list));
        }

        [HttpPut("status")]
        public async Task<ActionResult> UpdateStatus([FromBody] UpdateOrderStatus request)
        {
            await _service.UpdateOrderStatus(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            return Ok() ;
        }
    }
}
