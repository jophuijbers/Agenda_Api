using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace LogicLayer.Repositorys.UserRepos
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<User> Login(string email, string password);
        Task<User> Register(User user);
    }
}
