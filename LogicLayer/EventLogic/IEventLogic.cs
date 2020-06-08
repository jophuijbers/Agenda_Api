using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EventLogic
{
    public interface IEventLogic
    {
        //DateTime StringToDateTime(string datetime);
        Task<Event> PostEvent(Event @event);
    }
}
