using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAuction.Model;
using OnlineAuction.Business.Components;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Common.Interfaces;

using Spring.Context;
using Spring.Context.Support;
using OnlineAuction.EF;
namespace OnlineAuction.Web.Areas.Blog.Controllers
{
    public class BlogTypeController : Controller
    {
        protected IBlogTypeModel Model { get; set; }
        public BlogTypeController()
        {
            // Model = new BlogTypeModel();
        }

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
    }
}
