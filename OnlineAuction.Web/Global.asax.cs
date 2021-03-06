﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;
using OnlineAuction.Web.Models;

namespace OnlineAuction.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        /// <summary>
        /// 当所有HttpModule被HttpApplication首次加载后，每个HttpModule会在自己的Init方法中注册HttpApplication事件实现对HttpRequest请求的拦截。
        /// 当然UrlRoutingModule也不例外。我们反编译一下UrlRoutingModule源码 
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


            /// http://www.cnblogs.com/mecity/archive/2011/06/27/2090657.html
            /// 注册SpringControllerFactory类
            /// DefaultControllerFactory 每次都是根据上下文中的Action字符串反射Controller实例
            /// 可以重写DefaultControllerFactory 利用IOC容器实现Controller实例化工作（提高效率）
            ControllerBuilder.Current.SetControllerFactory(typeof(OnlineControllerFactory));
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError().GetBaseException();
            var httpException = exception as HttpException;

            if (httpException != null && httpException.GetHttpCode() == (int)HttpStatusCode.NotFound)
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", "ErrorController");
                routeData.Values.Add("action", "NotFound");
            }
            else
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", "ErrorController");
                routeData.Values.Add("action", "Error");
                routeData.Values.Add("exceptionInfor", exception.Message);
            }
        }

        #region Srping

        //protected override void RegisterSpringControllerFactory()
        //{
        // 必须是public class MvcApplication : System.Web.HttpApplication，SpringMvcApplication
        //    ControllerBuilder.Current.SetControllerFactory(typeof(ControllerFactory));
        //}

        #endregion

    }
}