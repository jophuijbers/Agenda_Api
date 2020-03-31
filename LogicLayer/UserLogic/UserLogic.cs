using LogicLayer.Repositorys.UserRepos;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.UserLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepos;
        public UserLogic(IUserRepository userRepos)
        {
            _userRepos = userRepos;
        }

        public async Task<User> GetById(int? id)
        {
            return await _userRepos.GetById(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepos.GetByEmail(email);
        }

        public async Task<User> Login(string email, string password)
        {
            return await _userRepos.Login(email, password);
        }

        public async Task<User> Register(User user)
        {
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
