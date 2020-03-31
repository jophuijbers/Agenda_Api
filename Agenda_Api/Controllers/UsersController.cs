using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using ModelLayer.Models;
using LogicLayer.UserLogic;
using LogicLayer.Repositorys.UserRepos;
using Agenda_API.ViewModels;

namespace Agenda_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UsersController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: api/Users/id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int? id)
        {
            var user = await _userLogic.GetById(id);

            if (user == null) return NotFound();

            return user;
        }

        // GET: api/Users/Login
        [HttpGet("[action]")]
        public async Task<ActionResult<User>> Login([FromForm]LoginViewModel viewModel)
        {
            var user = await _userLogic.Login(viewModel.Email, viewModel.Password);

            if (user == null) return NotFound();

            return user;
        }

        // POST: api/Users/Register
        [HttpPost("[action]")]
        public async Task<ActionResult<User>> Register([FromForm]User user)
        {
            return await _userLogic.Register(user);
        }
        
        // GET: api/Users/IsEmailAvailable/email
        [HttpGet("[action]/{email}")]
        public async Task<ActionResult<bool>> IsEmailAvailable(string email)
        {
            return await _userLogic.IsEmailAvailable(email);
        }
    }
}
