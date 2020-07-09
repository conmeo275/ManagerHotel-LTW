using System.Web;
using System.Web.Optimization;

namespace QuanLyKhachSan
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            //Admin
            bundles.Add(new StyleBundle("~/Assets/css").Include(
                      "~/Assets/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Assets/vendor/fonts/circular-std/style.css",
                      "~/Assets/libs/css/style.css",
                      "~/Assets/vendor/fonts/fontawesome/css/fontawesome-all.css",
                      "~/Assets/libs/css/CssCustomise.css"));
            bundles.Add(new ScriptBundle("~/bundlesB/jquery").Include(
                        "~/Assets/vendor/jquery/jquery-3.3.1.min.js",
                        "~/Assets/vendor/bootstrap/js/bootstrap.bundle.js",
                        "~/Assets/vendor/slimscroll/jquery.slimscroll.js",
                        "~/Assets/libs/js/main-js.js"));
            //Client
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/styles.css",
                      "~/Content/Site.css"));
            bundles.Add(new ScriptBundle("~/bundlesA/jquery").Include(
                     "~/Content/assets/mail/jqBootstrapValidation.js",
                     "~/Content/assets/mail/contact_me.js",
                     "~/Content/js/scripts.js"));
        }
    }
}
