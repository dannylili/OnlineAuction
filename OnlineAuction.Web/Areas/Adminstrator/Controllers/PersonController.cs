using System;
using System.Linq;
using System.Web.Mvc;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Business.Validation;
using OnlineAuction.Common.Const;
using OnlineAuction.Model;
using OnlineAuction.Web.Extensions;

namespace OnlineAuction.Web.Areas.Adminstrator.Controllers
{
    public class PersonController : Controller
    {
        #region 属性

        protected IPersonModel Model { get; set; }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

    }
}
