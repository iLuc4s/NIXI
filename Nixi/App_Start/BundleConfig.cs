using System.Web;
using System.Web.Optimization;

namespace Nixi
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/scripts/basic").Include(
                        "~/Vendors/jquery/dist/jquery.min.js",
                        "~/Vendors/bootstrap/dist/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/table").Include(
                        "~/Vendors/datatables.net/js/jquery.dataTables.min.js",
                        "~/Vendors/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/Vendors/datatables.net-buttons/js/buttons.colVis.min.js",
                        "~/Vendors/datatables.net-buttons/js/buttons.flash.min.js",
                        "~/Vendors/datatables.net-buttons/js/buttons.html5.min.js",
                        "~/Vendors/datatables.net-buttons/js/buttons.print.min.js",
                        "~/Vendors/datatables.net-buttons/js/dataTables.buttons.min.js",
                        "~/Vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js",
                        "~/Vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js",
                        "~/Vendors/datatables.net-keytable/js/dataTables.keyTable.min.js",
                        "~/Vendors/datatables.net-responsive/js/dataTables.responsive.min.js",
                        "~/Vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js",
                        "~/Vendors/datatables.net-scroller/js/dataTables.scroller.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/scripts/global").Include(
                        "~/Vendors/jquery/dist/jquery.min.js",
                        "~/Vendors/bootstrap/dist/js/bootstrap.min.js",
                        "~/Vendors/fastclick/lib/fastclick.js",
                        "~/Vendors/nprogress/nprogress.js",
                        "~/Vendors/Chart.js/dist/Chart.min.js",
                        "~/Vendors/gauge.js/dist/gauge.min.js",
                        "~/Vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                        "~/Vendors/iCheck/icheck.min.js",
                        "~/Vendors/skycons/skycons.js",
                        "~/Vendors/Flot/jquery.flot.js",
                        "~/Vendors/Flot/jquery.flot.pie.js",
                        "~/Vendors/Flot/jquery.flot.time.js",
                        "~/Vendors/Flot/jquery.flot.stack.js",
                        "~/Vendors/Flot/jquery.flot.resize.js",
                        "~/Vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                        "~/Vendors/flot-spline/js/jquery.flot.spline.min.js",
                        "~/Vendors/flot.curvedlines/curvedLines.js",
                        "~/Vendors/DateJS/build/date.js",
                        "~/Vendors/jqvmap/dist/jquery.vmap.js",
                        "~/Vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                        "~/Vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                        "~/Vendors/moment/min/moment.min.js",
                        "~/Vendors/bootstrap-daterangepicker/daterangepicker.js",
                        "~/Vendors/fullcalendar/dist/fullcalendar.min.js",
                        "~/Vendors/raphael/raphael.min.js",
                        "~/Vendors/morris/morris.min.js",
                        "~/Vendors/echarts/dist/echarts.min.js",
                        "~/Vendors/echarts/map/js/world.js",
                        "~/Vendors/jqvmap/dist/jquery.vmap.js",
                        "~/Vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                        "~/Vendors/jqvmap/dist/maps/jquery.vmap.usa.js",
                        "~/Vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                        "~/Vendors/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js",
                        "~/Vendors/jQuery-Smart-Wizard/js/jquery.smartWizard.js",
                        "~/Vendors/switchery/dist/switchery.min.js",
                        "~/Vendors/select2/dist/js/select2.full.min.js",
                        "~/Vendors/parsleyjs/dist/parsley.min.js",
                        "~/Vendors/autosize/dist/autosize.min.js",
                        "~/Vendors/devbridge-autocomplete/dist/jquery.autocomplete.min.js",
                        "~/Vendors/starrr/dist/starrr.js",
                        "~/Scripts/js/custom.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                      "~/Content/AdminSite.css"));
            bundles.Add(new StyleBundle("~/Content/diarycss").Include(
                      "~/Content/DiarySite.css"));

            bundles.Add(new StyleBundle("~/Content/tablecss").Include(
                      "~/Vendors/datatables.net-bs/css/dataTables.bootstrap.min.css",
                      "~/Vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css",
                      "~/Vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css",
                      "~/Vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css",
                      "~/Vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/vendorscss").Include(
                      "~/Vendors/bootstrap/dist/css/bootstrap.min.css",
                    "~/Vendors/font-awesome/css/font-awesome.min.css",
                    "~/Vendors/nprogress/nprogress.css",
                    "~/Vendors/iCheck/skins/flat/green.css",
                    "~/Vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                    "~/Vendors/jqvmap/dist/jqvmap.min.css",
                    "~/Vendors/jQuery-Smart-Wizard/styles/smart_wizard.css",
                    "~/Vendors/jQuery-Smart-Wizard/styles/smart_wizard_vertical.css",
                    "~/Vendors/bootstrap-daterangepicker/daterangepicker.css",
                    "~/Vendors/fullcalendar/dist/fullcalendar.min.css",
                    "~/Vendors/fullcalendar/dist/fullcalendar.print.css",
                    "~/Content/custom.min.css"));
            bundles.Add(new StyleBundle("~/Content/basicvendorscss").Include(
                      "~/Vendors/bootstrap/dist/css/bootstrap.min.css",
                    "~/Vendors/font-awesome/css/font-awesome.min.css"));
        }
    }
}
