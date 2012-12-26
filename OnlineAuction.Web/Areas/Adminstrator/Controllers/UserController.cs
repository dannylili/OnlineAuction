using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Business.Validation;
using OnlineAuction.Common.Const;
using OnlineAuction.Model;
using OnlineAuction.Web.Extensions;

namespace OnlineAuction.Web.Areas.Adminstrator.Controllers
{
    public class UserController : Controller
    {
        #region 属性

        protected IUserModel Model { get; set; }

        #endregion

        public ActionResult index()
        {
            return View();
        }

        public ActionResult Add()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            item.Add(new SelectListItem() { Text = "Admin", Value = "0" });
            item.Add(new SelectListItem() { Text = "General User", Value = "1" });
            item.Add(new SelectListItem() { Text = "Leran", Value = "2" });
            ViewData["UserTypeList"] = item;

            var user = new User();
            return View(user);
        }

    }
}
