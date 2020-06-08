using ModelLayer.Models;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Authentication
{
    public interface IAuthLogic
    {
        string GenerateJWT(User user);
        Task<User> AuthenticateUser(LoginViewModel login);
        Task<User> GetUserFromJWT(ClaimsIdentity identity);
    }
}
