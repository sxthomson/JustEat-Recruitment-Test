using System;
using System.Configuration;
using System.Net;

namespace JustEat.TechTest.WebApi.Configuration
{
    public static class Settings
    {
        public static class RequestHeaders
        {
            public static string Tenant => ConfigurationManager.AppSettings["RequestHeaders.Tenant"];

            public static string Language => ConfigurationManager.AppSettings["RequestHeaders.Language"];

            public static AuthenticationSchemes AuthenticationScheme => (AuthenticationSchemes)Enum.Parse(typeof(AuthenticationSchemes), ConfigurationManager.AppSettings["RequestHeaders.AuthorizationScheme"]);

            public static string AuthorizationToken => ConfigurationManager.AppSettings["RequestHeaders.AuthorizationToken"];

            public static string Host => ConfigurationManager.AppSettings["RequestHeaders.Host"];
        }

        public static class Uri
        {
            public static string RequestUriFormat => ConfigurationManager.AppSettings["Uri.RequestUriFormat"];
        }
    }
}