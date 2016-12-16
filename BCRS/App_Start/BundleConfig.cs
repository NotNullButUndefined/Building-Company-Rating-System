using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BCRS.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle(Constants.StyleBandleHome).Include("~/Content/styles/itera.css",
                                                                           "~/Content/styles/searchStyles.css",
                                                                           "~/Content/styles/font-awesome.min.css",
                                                                           "~/Content/styles/userpage.css",
                                                                           "~/Content/ui-bootstrap-csp.css"));

            bundles.Add(new ScriptBundle(Constants.AngularBundle).Include("~/Scripts/angular.min.js",
                                                                             "~/Scripts/angular-route.min.js",
                                                                             "~/Scripts/angular-animate.min.js",
                                                                             "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js"));


            bundles.Add(new ScriptBundle(Constants.AngularModule).Include("~/Scripts/app.js"));
            bundles.Add(new ScriptBundle(Constants.Account).Include("~/Scripts/Account/Controllers/LoginController.js",
                                                                    "~/Scripts/Account/Factories/LoginFactory.js"));
            bundles.Add(new ScriptBundle(Constants.LoginModalWindow).Include("~/Scripts/ModalWindows/loginFailedController.js"));
        }
    }
}
