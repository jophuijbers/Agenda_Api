using LogicLayer.Repositorys.EventRepos;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EventLogic
{
    public class EventLogic : IEventLogic
    {
        private readonly IEventRepository _eventRepos;

        public EventLogic(IEventRepository eventRepos)
        {
            _eventRepos = eventRepos;
        }

        public async Task<Event> PostEvent(Event @event)
        {
            //@event.Start = StringToDateTime(@event.StartString);
            //@event.End = StringToDateTime(@event.EndString);

            return await _eventRepos.AddEvent(@event);
        }

        private DateTime StringToDateTime(string datetime)
        {
            var s = datetime.Split("-T:".ToCharArray());
            var i = Array.ConvertAll(s, int.Parse);

            return new DateTime(i[0], i[1], i[2], i[3], i[4], i[5]);
        }
    }
}
