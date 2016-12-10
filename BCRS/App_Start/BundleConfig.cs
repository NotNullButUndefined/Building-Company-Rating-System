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
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Content/styles/itera.css",
                                                                  "~/Content/styles/searchStyles.css",
                                                                   "~/Content/styles/font-awesome.min.css"));
        }
    }
}
