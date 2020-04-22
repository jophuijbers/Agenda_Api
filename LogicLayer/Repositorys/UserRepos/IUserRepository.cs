using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;

namespace LogicLayer.Repositorys.UserRepos
{
    public interface IUserRepository
    {
        User GetById(int? id);
        User GetByEmail(string email);
        User Login(string email, string password);
        User Register(User user);
    }
}
