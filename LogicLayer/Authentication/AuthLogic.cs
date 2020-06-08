using LogicLayer.Repositorys.UserRepos;
using LogicLayer.UserLogic;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Models;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace LogicLayer.Authentication
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepos;
        private readonly IUserLogic _userLogic;

        public AuthLogic(IConfiguration config, IUserRepository userRepos, IUserLogic userLogic)
        {
            _config = config;
            _userRepos = userRepos;
            _userLogic = userLogic;
        }

        public string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }

        public async Task<User> AuthenticateUser(LoginViewModel login)
        {
            var user = await _userRepos.GetByEmail(login.Email);

            if (Crypto.VerifyHashedPassword(user.Password, login.Password))
            {
                return user;
            }
            else user = null;

            return user;
        }

        public async Task<User> GetUserFromJWT(ClaimsIdentity identity)
        {
            IList<Claim> claim = identity.Claims.ToList();
            var email = claim[0].Value;

            return await _userLogic.GetByEmail(email);
        }
    }
}
