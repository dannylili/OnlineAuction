﻿using System.Linq;
using System.Web.Mvc;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Model;
using OnlineAuction.Business.Validation;
using OnlineAuction.Web.Extensions;

namespace OnlineAuction.Web.Areas.Blog.Controllers
{
    public class BlogTypeController : Controller
    {
        #region 属性

        protected IBlogTypeModel Model { get; set; }

        #endregion

        #region Ctr

        public BlogTypeController()
        {

        }

        #endregion

        #region HTTP.PUT

        public ActionResult Index()
        {
            var blogTypes = Model.ListIsActiveAll().ToList();
            return View(blogTypes);
        }

        public ActionResult Add()
        {
            // FormContext for=new 
            var blogType = new BlogType();
            return View(blogType);
        }

        #endregion

        #region HTTP.POST

        [HttpPost]
        public ActionResult Add(BlogType entity)
        {
            // FormCollection form = new FormCollection();
            var result = Model.Save(entity);
            if (result.IsValid)
            {
                /// 添加失败，停留在本页面
                return PartialView("Add", entity);
            }
            else
            {
                return RedirectToAction("Index", "BlogType");
                // return RedirectToAction("Index");
                // 层级关系是：action<<controller<<route
            }

            // result.AddMessage("1", "2");
            // result.AddMessageForInfor("firstName", "Wang");

            // return result.ToJsonResult<ErrorResult>();
            // return PartialView(HttpContext.Application);
            // http://blog.163.com/shizhengxian@126/blog/static/422877822012629114446206/
        }

        #endregion
    }
}
