using System.Web;
using System.Web.Optimization;

namespace FoodOrdering.WEB
{
	public static class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
				"~/Scripts/DataTables/jquery.dataTables.js",
				"~/Scripts/DataTables/dataTables.autoFill.js",
				"~/Scripts/DataTables/dataTables.bootstrap.js",
				"~/Scripts/DataTables/dataTables.buttons.js",
				"~/Scripts/DataTables/dataTables.colReorder.js",
				"~/Scripts/DataTables/dataTables.fixedColumns.js",
				"~/Scripts/DataTables/dataTables.fixedHeader.js",
				"~/Scripts/DataTables/dataTables.keyTable.js",
				"~/Scripts/DataTables/dataTables.responsive.js",
				"~/Scripts/DataTables/dataTables.rowReorder.js",
				"~/Scripts/DataTables/dataTables.scroller.js",
				"~/Scripts/DataTables/dataTables.select.js",
				"~/Scripts/DataTables/autoFill.bootstrap.js",
				"~/Scripts/DataTables/buttons.bootstrap.js",
				"~/Scripts/DataTables/buttons.colVis.js",
				"~/Scripts/DataTables/buttons.flash.js",
				"~/Scripts/DataTables/buttons.html5.js",
				"~/Scripts/DataTables/buttons.print.js",
				"~/Scripts/DataTables/responsive.bootstrap.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/datatables").Include(
					  "~/Content/DataTables/jquery.dataTables.css",
					  "~/Content/DataTables/autoFill.dataTables.css",
					  "~/Content/DataTables/buttons.dataTables.css",
					  "~/Content/DataTables/colReorder.dataTables.css",
					  "~/Content/DataTables/dataTables.bootstrap.css",
					  "~/Content/DataTables/fixedColumns.dataTables.css",
					  "~/Content/DataTables/fixedHeader.dataTables.css",
					  "~/Content/DataTables/keyTable.dataTables.css",
					  "~/Content/DataTables/responsive.dataTables.css",
					  "~/Content/DataTables/rowReorder.dataTables.css",
					  "~/Content/DataTables/scroller.dataTables.css",
					  "~/Content/DataTables/select.dataTables.css"));
		}
	}
}
