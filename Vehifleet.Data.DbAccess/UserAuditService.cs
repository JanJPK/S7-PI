using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Vehifleet.Data.DbAccess
{
    public class UserAuditService : IUserAuditService
    {
        private readonly string defaultName = "admin";
        public string UserName { get; }

        public UserAuditService(IHttpContextAccessor httpContextAccessor)
        {
            var context = httpContextAccessor.HttpContext;
            if (context != null && context.User.Identity.IsAuthenticated)
            {
                UserName = context.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? defaultName;
            }
            else
            {
                UserName = defaultName;
            }
        }
    }
}