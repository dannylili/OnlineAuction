using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAuction.Web.Extensions
{
    /// <summary>
    /// 扩展字段的验证
    /// </summary>
    public static partial class HtmlHelperExtension
    {
        public static MvcHtmlString Validation(this MvcHtmlString helper)
        {
            return helper;
        }
    }
}