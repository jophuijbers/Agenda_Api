using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.UserLogic
{
    public interface IUserLogic
    {
        Task<User> GetById(int? id);
        Task<User> GetByEmail(string email);
        Task<User> Login(string email, string password);
        Task<User> Register(User user);
        Task<bool> IsEmailAvailable(string email);
    }
}
