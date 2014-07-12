using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ItemStock.Api
{
    public class AppSettings
    {
        public static string TokenPath
        {
            get { return ConfigurationManager.AppSettings["TokenPath"]; }
        }

        public static int TokenLifeTime
        {
            get { return int.Parse(ConfigurationManager.AppSettings["TokenLifeTime"]); }
        }
    }
}