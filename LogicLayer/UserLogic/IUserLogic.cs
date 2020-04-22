using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.UserLogic
{
    public interface IUserLogic
    {
        User GetById(int? id);
        User GetByEmail(string email);
        User Login(string email, string password);
        User Register(User user);
        bool IsEmailAvailable(string email);
    }
}
