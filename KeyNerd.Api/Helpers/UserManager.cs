using KeyNerd.Infrastructure.Security;

namespace KeyNerd.Api.Helpers
{
    public class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor httpContext;

        public UserManager(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

        public string GetCurrentUserName()
        {
            return httpContext.HttpContext?.User?.FindFirst("UserName")?.Value;
        }
    }
}
