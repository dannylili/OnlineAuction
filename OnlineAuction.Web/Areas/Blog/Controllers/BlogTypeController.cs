using System.Linq;
using System.Web.Mvc;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Model;
using OnlineAuction.Business.Validation;
using OnlineAuction.Web.Extensions;
using OnlineAuction.Common.Const;

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

        public ActionResult Edit(int id)
        {
            var entity = Model.Get(id);
            return View(entity);
        }

        #endregion

        #region HTTP.POST

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Add(BlogType entity)
        {
            // FormCollection form = new FormCollection();

            var result = Model.Save(entity);
            result.AddMessage("add", "add data scucessful");
            TempData[Constants.ViewStatus.TempDataAddFail] = "Alert(" + result.ToJsonResult<ErrorResult>().ToString() + ")";

            if (result.IsValid)
            {
                /// 添加失败，停留在本页面
                return PartialView("Add", entity);
            }
            else
            {
                /// 重新跳转到Index页面去
                return RedirectToAction("Index", "BlogType");
                // return RedirectToAction("Index");
                // 层级关系是：action<<controller<<route

                /// 直接进入到view中，但要传入对应页面的数据
                // return PartialView();
            }

            // result.AddMessage("1", "2");
            // result.AddMessageForInfor("firstName", "Wang");

            // return result.ToJsonResult<ErrorResult>();
            // return PartialView(HttpContext.Application);
            // http://blog.163.com/shizhengxian@126/blog/static/422877822012629114446206/
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Edit(BlogType entity)
        {
            var result = Model.Update(entity);
            if (result.IsValid)
            {
                ViewData[Constants.ViewStatus.TempDataAddFail] = result.ToJsonResult<ErrorResult>();
                return RedirectToAction("Edit");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        #endregion
    }
}
