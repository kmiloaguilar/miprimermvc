using System.Web;
using NavigationRoutes;

namespace NavigationRouteFilterExamples
{
    public class AuthenticationFilter : INavigationRouteFilter
    {
        const string LoggedToken = "logged";

        public bool ShouldRemove(System.Web.Routing.Route navigationRoutes)
        {
            if (navigationRoutes.DataTokens.HasFilterToken())
            {
                var filterToken = navigationRoutes.DataTokens.FilterToken();

                var result = HttpContext.Current.User.Identity.IsAuthenticated && filterToken == LoggedToken;
                return result;
            }

            return false;
        }
    }
}