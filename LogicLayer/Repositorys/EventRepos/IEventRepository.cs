using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Repositorys.EventRepos
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents(User user);
        Task<Event> GetEvent(int? id);
        Task<Event> AddEvent(Event @event);
        Task<Event> UpdateEvent(Event @event);
        void DeleteEvent(Event @event);
    }
}
