using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemStock.Api
{
    public static class Constants
    {
        public static class Paths
        {
            public static string LoginPath = "/Account/Login";

            public static string LogoutPath = "/Account/Logout";

            public static string AuthorizePath = "/OAuth/Authorize";

            public static string TokenPath = "/Token";
        }

        public class AppSettings
        {
            public static string FacebookAppId = "itemstock:facebookAppId";

            public static string FacebookAppKey = "itemstock:facebookAppKey";
        }

    }
}