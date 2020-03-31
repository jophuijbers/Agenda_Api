using DataLayer;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Repositorys.UserRepos
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int? id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> Login(string email, string password)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User> Register(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
