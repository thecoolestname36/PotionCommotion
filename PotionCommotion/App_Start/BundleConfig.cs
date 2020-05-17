using System;
using System.Web.Optimization;

namespace PotionCommotion {
    public class BundleConfig {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-3.4.1.min.js")
            );
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.bundle.min.js")
            );
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/Site.css", new CssRewriteUrlTransform())
            );
            bundles.Add(new ScriptBundle("~/bundles/socket")
                .Include("~/Scripts/Components/ServerCommands.js")
                .Include("~/Scripts/Components/ServerMessage.js")
                .Include("~/Scripts/Components/ClientCommands.js")
                .Include("~/Scripts/Components/ClientMessage.js")
                .Include("~/Scripts/Components/Socket.js")
            );
            bundles.Add(new ScriptBundle("~/viewBundles/default")
				.Include("~/Scripts/Views/Default/Index.js")
			);
            BundleTable.EnableOptimizations = true;

        }
    }
}
