using Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTService
{
    public class JWTConfigurator : IJWTConfigurator
    {
        private readonly IConfiguration _config;
        public JWTConfigurator(IConfiguration config)
        {
            _config = config;
        }
        public string TokenString(string rol, string userName)
        {
            var secret = _config["Tokens:Key"];
            var issuer = _config["Tokens:Issuer"];
            double expToken = Convert.ToDouble(_config["Tokens:ExpToken"]);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, rol)
            };

            var tokeOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expToken),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }
    }
}
