using System.Web;
using System.Web.Optimization;

namespace GigHub
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/lib").Include(
                        "~/Scripts/jquery/jquery-3.7.1.min.js",
                        "~/Scripts/bootstrap/bootstrap.bundle.min.js",
                        "~/Scripts/bootbox.all.min.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/momentjs/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jqueryval/jquery.validate.min.js",
                        "~/Scripts/jqueryval/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/Content/css")
                .Include("~/Content/bootstrap/bootstrap.min.css",
                      "~/Content/site.min.css",
                      "~/Content/animate.min.css")
                .Include("~/Content/bootstrap/bootstrap-icons.min.css", new CssRewriteUrlTransform()));
        }
    }
}
