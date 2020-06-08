using DataLayer;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Repositorys.EventRepos
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Event> GetEvent(int? id)
        {
            return await _context.Event.FindAsync(id);
        }

        public async Task<Event> AddEvent(Event @event)
        {
            await _context.Event.AddAsync(@event);
            await _context.SaveChangesAsync();
            return @event;
        }

        public async Task<Event> UpdateEvent(Event @event)
        {
            var _event = _context.Event.Attach(@event);
            _event.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return @event;
        }

        public async void DeleteEvent(Event @event)
        {
            _context.Event.Remove(@event);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEvents(User user)
        {
            return await _context.Event.Where(x => x.User_Id == user.Id).ToListAsync();
        }
    }
}
