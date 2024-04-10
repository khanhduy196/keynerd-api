using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeyNerd.Api.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class BaseAdminController : ControllerBase
    {
    }
}
