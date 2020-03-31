using DataLayer;
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

            services.AddScoped<IUserRepository, UserRepository>();

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
