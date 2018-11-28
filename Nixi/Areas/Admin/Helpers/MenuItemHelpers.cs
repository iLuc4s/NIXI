using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Nixi.Areas.Admin.Helpers
{
    public static class MenuItemHelpers
    {
        public static MvcHtmlString SideMenuItem(
        this HtmlHelper helper,
        string text, string action, string controller)
        {
            var routeData = helper.ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];

            if (String.Equals(action, currentAction as string,
                      StringComparison.OrdinalIgnoreCase)
                &&
               String.Equals(controller, currentController as string,
                       StringComparison.OrdinalIgnoreCase))
            {
                return helper.ActionLink(
                    text, action, controller, null,
                    new { @class = "own-sidemenu-item sidebar-actief" }
                    );
            }
            return helper.ActionLink(text, action, controller, null, new { @class = "own-sidemenu-item" });
        }

        public static MvcHtmlString SideMenuItem(
        this HtmlHelper helper,
        string text, string action, string controller, object routeValues)
        {
            var routeData = helper.ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];
            var currentKey = routeData["Key"];
            if (String.Equals(action, currentAction as string,
                      StringComparison.OrdinalIgnoreCase)
                &&
               String.Equals(controller, currentController as string,
                       StringComparison.OrdinalIgnoreCase)
                &&
                String.Equals(routeValues as string, currentKey as string, StringComparison.OrdinalIgnoreCase))

            {
                return helper.ActionLink(
                    text, action, controller, routeValues,
                    new { @class = "own-sidemenu-item sidebar-actief" }
                    );
            }
            return helper.ActionLink(text, action, controller, routeValues, new { @class = "own-sidemenu-item" });
        }

        public static MvcHtmlString AdminMenuItem(
        this HtmlHelper helper,
        string text, string action, string controller)
        {
            var routeData = helper.ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];

            if (String.Equals(action, currentAction as string,
                      StringComparison.OrdinalIgnoreCase)
                &&
               String.Equals(controller, currentController as string,
                       StringComparison.OrdinalIgnoreCase))
            {
                return helper.ActionLink(
                    text, action, controller, null,
                    new { @class = "nav-link active" }
                    );
            }
            return helper.ActionLink(text, action, controller, null, new { @class = "nav-link" });
        }
    }
}