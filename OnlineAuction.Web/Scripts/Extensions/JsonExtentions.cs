using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineAuction.Business.Validation;

namespace OnlineAuction.Web.Extensions
{
    public static class JsonExtentions
    {
        public static JsonResult ToJsonResult<T>(this Object t) where T: ErrorResult
        {
            return (new JsonResult() { Data = t, JsonRequestBehavior = JsonRequestBehavior.AllowGet });
        }
    }
}