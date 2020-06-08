using ModelLayer.Models;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.UserLogic
{
    public interface IUserLogic
    {
        Task<User> GetByEmail(string email);
        Task<User> Register(User user);
        Task<bool> IsEmailAvailable(string email);
    }
}
