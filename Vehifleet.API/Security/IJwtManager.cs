using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vehifleet.API.Security
{
    public interface IJwtManager
    {
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
        Task<string> GenerateToken(string userName, ClaimsIdentity identity);
        Task<string> GenerateJwt(ClaimsIdentity identity, string userName, JsonSerializerSettings serializerSettings);
    }
}