using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vehifleet.API.Security
{
    public interface IJwtManager
    {                        
        string GenerateJwt();
        string GenerateToken();
    }
}