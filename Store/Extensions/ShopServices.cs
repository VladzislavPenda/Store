using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Store.Server.Extensions
{
    public class ShopServices
    {
        public string GetUserEmail(string accessToken)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jsonToken = handler.ReadToken(accessToken);
            JwtSecurityToken tokenS = jsonToken as JwtSecurityToken;
            string userEmail = tokenS.Claims.ToArray()[1].Value;
            return userEmail;
        }
    }
}
