using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using ModelLayer.Models;
using Microsoft.AspNetCore.Authorization;
using LogicLayer.Authentication;
using System.Security.Claims;
using LogicLayer.Repositorys.EventRepos;
using LogicLayer.EventLogic;

namespace Agenda_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IAuthLogic _authLogic;
        private readonly IEventRepository _eventRepos;
        private readonly IEventLogic _eventLogic;

        public EventsController(IAuthLogic authLogic, IEventRepository eventRepos, IEventLogic eventLogic)
        {
            _authLogic = authLogic;
            _eventRepos = eventRepos;
            _eventLogic = eventLogic;
        }

        // GET: api/Events
        [Authorize]
        [HttpGet("[action]")]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            var user = await _authLogic.GetUserFromJWT(HttpContext.User.Identity as ClaimsIdentity);
            var events = await _eventRepos.GetAllEvents(user);
            return events;
        }

        // GET: api/Events/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Event>> GetEvent(int? id)
        //{
        //    await _authLogic.GetUserFromJWT(HttpContext.User.Identity as ClaimsIdentity);
        //}

        //// PUT: api/Events/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEvent(int? id, Event @event)
        //{
        //    if (id != @event.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(@event).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EventExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Events
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost("[action]")]
        public async Task<ActionResult<Event>> PostEvent([FromBody] Event @event)
        {
            var user = await _authLogic.GetUserFromJWT(HttpContext.User.Identity as ClaimsIdentity);
            @event.User_Id = user.Id;
            return await _eventLogic.PostEvent(@event);
        }

        //// DELETE: api/Events/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Event>> DeleteEvent(int? id)
        //{
        //    var @event = await _context.Event.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Event.Remove(@event);
        //    await _context.SaveChangesAsync();

        //    return @event;
        //}

        //private bool EventExists(int? id)
        //{
        //    return _context.Event.Any(e => e.Id == id);
        //}
    }
}
