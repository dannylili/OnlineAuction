using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Spring.Context.Support;
using Spring.Web.Mvc;
using Spring.Context;

namespace OnlineAuction.Web.Models
{
    /// <summary>
    /// http://www.cnblogs.com/GoodHelper/archive/2009/11/19/SpringNet_Nhibernate_AspNetMvc.html
    /// 我们知道，对Controller依赖注入需要新建一个ControllerFactory。我们实现System.Web.Mvc.IControllerFactory接口即可。实际上就是替换现有的ControllerFactory，
    /// 让Spring.NET容器管理Controller。包含Spring.NET容器配置的Controller使用新建的ControllerFactory，没有包含Spring.NET容器配置的Controller使用原有的DefaultControllerFactory。
    /// </summary>
    public class OnlineControllerFactory : IControllerFactory
    {
        /// <summary>
        /// 第一次就调用ReleaseController()方法，将defalutf实例化
        /// </summary>
        private static DefaultControllerFactory defalutf = null;

        #region 接口实现

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            /// 取得Spring的对象
            WebApplicationContext ctx = ContextRegistry.GetContext() as WebApplicationContext;
            string controller = controllerName + "Controller";

            /// <c>查找是否配置该Controller</c>如果没有将Controller配置到Spring中去的话，在这儿就检测不到controllerName,所以调用else来实例化Controller，但同时Controller的属性不会被实例化
            ///file://~/Configuration/Controllers.xml
            if (ctx.ContainsObject(controller))
            {
                object controllerf = ctx.GetObject(controller);
                return (IController)controllerf;

            }
            else
            {
                if (defalutf == null)
                {
                    defalutf = new DefaultControllerFactory();
                }

                // 如果Controller没有配置到Spring的xml文件中，调用这句开始实例化想要的Controller，可以给Controller添加断点跟踪
                return defalutf.CreateController(requestContext, controllerName);
            }
        }

        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            //get spring context
            IApplicationContext ctx = ContextRegistry.GetContext();
            if (!ctx.ContainsObject(controller.GetType().Name))
            {
                if (defalutf == null)
                {
                    defalutf = new DefaultControllerFactory();
                }

                defalutf.ReleaseController(controller);
            }
        }

        #endregion
    }
}