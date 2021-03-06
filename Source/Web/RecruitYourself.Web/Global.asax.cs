﻿namespace RecruitYourself.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

#pragma warning disable SA1649 // File name must match first type name
    public class MvcApplication : HttpApplication
#pragma warning restore SA1649 // File name must match first type name
    {
        protected void Application_Start()
        {
            ViewEngineConfig.RegisterRazorViewEngine();
            DatabaseConfig.RegisterDatabase();
            AutofacConfig.RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMappingConfig.RegisterAutoMapper();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = this.Server.GetLastError();
            this.Server.ClearError();
            this.Response.Redirect("~/Error/PageNotFound");
        }
    }
}
