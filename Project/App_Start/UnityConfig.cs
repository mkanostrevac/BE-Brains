using Project.Models;
using Project.Repositories;
using Project.Services;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace Project
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

            container.RegisterType<IGenericRepository<UserModel>, GenericRepository<UserModel>>();
            container.RegisterType<IGenericRepository<CategoryModel>, GenericRepository<CategoryModel>>();

            container.RegisterType<DbContext, DataAccessContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<ICategoriesService, CategoriesService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}