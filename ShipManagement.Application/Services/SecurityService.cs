using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShipManagement.Application.Common;
using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly AppSetting _appSetting;

        public SecurityService(IOptions<AppSetting> options)
        {
            _appSetting=options.Value;
        }
        public string CreateToken(Manager user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var claims = new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role,"Admin"),
               };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), //TODO: Remove this and set 7 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token= tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
