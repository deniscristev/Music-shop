using System.Web.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include
                ("~/Content/lib/bootstrap/css/bootstrap.min.css",
                 "~/Content/lib/font-awesome/css/font-awesome.min.css",
                // "~/Content/bootstrap.min.css",
                 "~/Content/iconfont.min.css",
                 "~/Content/helper.css",
                 "~/Content/plugins.min.css",
                 "~/Content/style.min.css",
                 "~/Content/css/style.css"
                 ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include
                ("~/Content/lib/jquery/jquery.min.js",
                 "~/Scripts/jquery-3.5.0.min.js",
                 "~/Scripts/jquery.unobtrusive-ajax.min.js",
                 "~/Scripts/popper.min.js",
               //  "~/Scripts/bootstrapp.min.js",
                 "~/Scripts/plugins.min.js",
                 "~/Scripts/main.js",
                 "~/Content/lib/bootstrap/js/bootstrap.min.js",
                 "~/Content/lib/php-mail-form/validate.js",
                 "~/Content/js/main.js"
                 ));
        }
    }
}