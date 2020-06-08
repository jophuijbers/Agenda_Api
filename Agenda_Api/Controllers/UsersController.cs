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
using ModelLayer.ViewModels;
using LogicLayer.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Agenda_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly IAuthLogic _authLogic;

        public UsersController(IUserLogic userLogic, IAuthLogic authLogic)
        {
            _userLogic = userLogic;
            _authLogic = authLogic;
        }

        // api/Users/GetUser
        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<User>> GetUser()
        {
            return await _authLogic.GetUserFromJWT(HttpContext.User.Identity as ClaimsIdentity);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel login)
        {
            var user = await _authLogic.AuthenticateUser(login);

            if (user != null) return Ok(new { token = _authLogic.GenerateJWT(user) });

            return Unauthorized();
        }

        // POST: api/Users/Register
        [HttpPost("[action]")]
        public async Task<ActionResult<User>> Register([FromBody]User user)
        {
            return await _userLogic.Register(user);
        }
        
        // GET: api/Users/IsEmailAvailable?Email=...
        [HttpGet("[action]")]
        public async Task<ActionResult<bool>> IsEmailAvailable(string email)
        {
            return await _userLogic.IsEmailAvailable(email);
        }
    }
}
