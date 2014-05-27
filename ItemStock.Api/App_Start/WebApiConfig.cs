﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ItemStock.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.SuppressDefaultHostAuthentication();
            //This will used the HTTP header: "Authorization"      Value: "Bearer 1234123412341234asdfasdfasdfasdf"
            config.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
