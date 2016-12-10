using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCRS.App_Start
{
    public class ControllersFactoriesConfig 
    {
        public static void RegisterAllControllersFactories()
        {
            RegisterAccountControllerFactory();
        }

        private static void RegisterAccountControllerFactory()
        {
            IControllerFactory factory = new AccountControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}