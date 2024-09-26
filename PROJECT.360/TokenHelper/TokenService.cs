using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace PROJECT._360.TokenHelper
{
    public class TokenService
    {
        private readonly SymmetricSecurityKey _signingKey;
        public TokenService()
        {
            var secret = ConfigurationManager.AppSettings["JwtSecretKey"];
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        }

        public string GenerateToken(string username)
        {
            var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
            var audience = ConfigurationManager.AppSettings["JwtAudience"];
            var jwtExpiryInMinutes = ConfigurationManager.AppSettings["JwtExpiryInMinutes"];

            var parsedJwtExp = Convert.ToDouble(jwtExpiryInMinutes);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                //  expires: DateTime.Now.AddMinutes(30),
                expires: DateTime.Now.AddMinutes(parsedJwtExp),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}