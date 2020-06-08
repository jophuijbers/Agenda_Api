using LogicLayer.Repositorys.UserRepos;
using ModelLayer.Models;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace LogicLayer.UserLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepos;

        public UserLogic(IUserRepository userRepos)
        {
            _userRepos = userRepos;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepos.GetByEmail(email);
        }

        public async Task<User> Register(User user)
        {
            user.Password = Crypto.HashPassword(user.Password);
            return await _userRepos.Register(user);
        }

        public async Task<bool> IsEmailAvailable(string email)
        {
            var user = await _userRepos.GetByEmail(email);

            if (user == null) return true;

            return false;
        }
    }
}
