using ContestantApplications.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ContestantApplications
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ITestRepository, TestRepository>();
            container.RegisterType<IContestantRepository, ContestantRepository>();
            container.RegisterType<IRatingRepository, RatingRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}