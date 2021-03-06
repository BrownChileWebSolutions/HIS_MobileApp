﻿using HIS_MobileApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HIS_MobileApp.Services;

namespace HIS_MobileApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true; 
        }
        void Application_Error(object sender, EventArgs e)
        {           
            HttpUnhandledException httpUnhandledException =
               new HttpUnhandledException(Server.GetLastError().Message, Server.GetLastError());
            EmailService.SendMail(httpUnhandledException.GetHtmlErrorMessage());
        }
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Creating bundle for your css files
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css"));

            //Creating bundle for your js files
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-2.1.1.min.js",
            "~/Scripts/html5shiv.js",
            "~/Scripts/respond.min.js",
            "~/Scripts/bootstrap.min.js"            
            ));
        }
    }
}