using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Vehifleet.API.Security
{
    public class JwtManager : IJwtManager
    {
        private readonly JwtOptions jwtOptions;

        public JwtManager(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
        }

        public string GenerateJwt()
        {
            throw new NotImplementedException();
        }

        public string GenerateToken()
        {
            var claims = new List<Claim>();

            var token = new JwtSecurityToken(jwtOptions.Issuer,
                                             jwtOptions.Audience,
                                             claims,
                                             jwtOptions.NotBefore,
                                             jwtOptions.Expiration,
                                             jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public async Task<string> GenerateToken(string userName, ClaimsIdentity identity)
        //{
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, userName),
        //        new Claim(JwtRegisteredClaimNames.Jti, await jwtOptions.JtiGenerator()),
        //        new Claim(JwtRegisteredClaimNames.Iat, ConvertToUnixEpochTime(jwtOptions.IssuedAt).ToString(),
        //                  ClaimValueTypes.Integer64),
        //        identity.FindFirst("rol"),
        //        identity.FindFirst("id")
        //    };
        //
        //    var jwtToken = new JwtSecurityToken(jwtOptions.Issuer,
        //                                        jwtOptions.Audience,
        //                                        claims,
        //                                        jwtOptions.NotBefore,
        //                                        jwtOptions.Expiration,
        //                                        jwtOptions.SigningCredentials);
        //
        //    return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        //}

        public ClaimsIdentity GenerateClaimsIdentity(string userName, string id)
        {
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim("id", id),
                new Claim("rol", "api_access")
            });
        }

        public async Task<string> GenerateJwt(ClaimsIdentity identity,
                                              string userName,
                                              JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                //auth_token = await GenerateToken(userName, identity),
                expires_in = (int) jwtOptions.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }

        private static long ConvertToUnixEpochTime(DateTime date)
        {
            return (long) Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                                    .TotalSeconds);
        }
    }
}