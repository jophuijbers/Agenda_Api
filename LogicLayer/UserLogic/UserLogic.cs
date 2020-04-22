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

        public User GetById(int? id)
        {
            return _userRepos.GetById(id);
        }

        public User GetByEmail(string email)
        {
            return _userRepos.GetByEmail(email);
        }

        public User Login(string email, string password)
        {
            return _userRepos.Login(email, password);
        }

        public User Register(User user)
        {
            return _userRepos.Register(user);
        }

        public User IsEmailAvailable(string email)
        {
            var user = _userRepos.GetByEmail(email);

            if (user == null) return true;

            return false;
        }
    }
}
