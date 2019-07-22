using AssignmentX.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AssignmentX
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IBankAccountRepository, BankAccountRepository>();
            container.RegisterType<ITransactionsRepository, TransactionsRepository>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}