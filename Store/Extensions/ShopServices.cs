using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Server.Extensions
{
    public class ShopServices
    {
        public string GetUserEmail(string accessToken)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jsonToken = handler.ReadToken(accessToken);
            JwtSecurityToken tokenS = jsonToken as JwtSecurityToken;
            string userEmail = tokenS.Claims.ToArray()[2].Value;
            return userEmail;
        }
    }
}
