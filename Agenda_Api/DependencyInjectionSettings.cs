using DataLayer;
using LogicLayer.Authentication;
using LogicLayer.EventLogic;
using LogicLayer.Repositorys.EventRepos;
using LogicLayer.Repositorys.UserRepos;
using LogicLayer.UserLogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_API
{
    public class DependencyInjectionSettings
    {
        public string UseDatabase { get; set; }

        public DependencyInjectionSettings(string useDatabase)
        {
            UseDatabase = useDatabase;
        }

        public void Setup(IServiceCollection services)
        {
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IAuthLogic, AuthLogic>();
            services.AddScoped<IEventLogic, EventLogic>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();

            //if (UseDatabase == "true")
            //{
            //    services.AddScoped<IUserContext, AppDbContext>();
            //}
            //else
            //{
            //   /services.AddScoped<IUserContext, UserMemContext>();
            //}
        }
    }
}
