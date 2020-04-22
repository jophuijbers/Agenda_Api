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
        public ActionResult<User> GetUser(int? id)
        {
            var user = _userLogic.GetById(id);

            if (user == null) return NotFound();

            return user;
        }

        // POST: api/Users/Login
        [HttpPost("[action]")]
        public ActionResult<User> Login([FromBody]LoginViewModel viewModel)
        {
            var user = _userLogic.Login(viewModel.Email, viewModel.Password);

            if (user == null) return NotFound();

            return user;
        }

        // POST: api/Users/Register
        [HttpPost("[action]")]
        public ActionResult<User> Register([FromBody]User user)
        {
            return _userLogic.Register(user);
        }
        
        // GET: api/Users/IsEmailAvailable?Email=...
        [HttpGet("[action]")]
        public ActionResult<bool> IsEmailAvailable(string email)
        {
            return _userLogic.IsEmailAvailable(email);
        }
    }
}
