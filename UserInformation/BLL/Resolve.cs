using Castle.Windsor;
using Castle.Windsor.Installer;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public static class Resolver
    {
        public static WindsorContainer Resolve()
        {
            // application starts...
            var container = new WindsorContainer();

            // adds and configures all components using WindsorInstallers from executing assembly
            container.Install(FromAssembly.This());

            // instantiate and configure root component and all its dependencies and their dependencies and...
            container.Resolve<IBusinessLogic>();
            container.Resolve<IDataAccess>();
       

            return container;
        }
        public static IBusinessLogic Business()
        {
            IDataAccess data = new DataAccess();
            IBusinessLogic business = new BusinessLogic(data);

            return business;
        }

    }
}
