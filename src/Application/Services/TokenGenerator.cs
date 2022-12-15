using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Domain;
using System.Security.Claims;

namespace Application.Services
{
    public class TokenGenerator
    {
        public string Generate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(user),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("JwtSecretAuthTrytter")),
                    SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(2)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private ClaimsIdentity AddClaims(User user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("username", user.Username.ToString()));
            return claims;
           
        }
    }
}
