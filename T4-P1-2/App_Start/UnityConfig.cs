using System.Data.Entity;
using System.Web.Http;
using T4_P1_2.Models;
using T4_P1_2.Repositories;
using Unity;
using Unity.WebApi;

namespace T4_P1_2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<DbContext, DataAccessContext>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}