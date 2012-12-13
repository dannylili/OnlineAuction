using System;
using System.Linq;
using System.Web.Mvc;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Business.Validation;
using OnlineAuction.Common.Const;
using OnlineAuction.Model;
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

        public ActionResult Edit(int id, int? testID = null)
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
            // result.AddMessage("add", "add data scucessful");
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
            ErrorResult result = new ErrorResult();
            var verifyData = Model.ListIsActiveAll().Where(t => t.ID != entity.ID && t.BlogShortName == entity.BlogShortName);
            if (verifyData.Any())
            {
                result.AddMessage("blogShortName is replase", entity.BlogShortName);
                return result.ToJsonResult<ErrorResult>();
            }
            // var result = Model.Update(entity);
            result = Model.Update(entity);
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

        [OutputCache]
        [HttpPost]
        public ActionResult AjaxTest()
        {
            if ((Request["X-Requested-With"] == "XMLHttpRequest") || ((Request.Headers != null) && (Request.Headers["X-Requested-With"] == "XMLHttpRequest")))
            {

            }

            var id = Request["testID"];
            ContentResult test = new ContentResult();
            test.Content = "test data";
            // return new JsonResult();
            return test;
        }

        /// <summary>
        /// 根据条件自动过滤
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ActionResult AuoteSearch(string queryParam)
        {
            var listType = from types in Model.ListIsActiveAll().ToList()
                           where types.BlogShortName.Contains(queryParam)
                           select new
                           {
                               value = types.BlogShortName,
                           };
            string[] test = listType.Select(t => t.value).ToArray<string>();

            //  注意调用
            var testResult = Json(new JsonResult { Data = test, JsonRequestBehavior = JsonRequestBehavior.AllowGet });

            /// new JsonResult()和Json的结果不一样
            return Json(test, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            Model.Delete(id);


            // 如果是ajax的ActionLink调用了此方法,则result就显示在了 UpdateTargetId="ajaxPanel"的html元素中
            ContentResult result = new ContentResult();
            result.Content = "<font color='red'>test method</font>";
            return result;
            // return new JsonResult();
        }

        public ActionResult DetelteBlog(int id)
        {
            return JavaScript("alert('delte success!')");
        }

        #endregion

        /// <summary>
        ///  在添加页面测试Autocomplete
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult Autocomplete(string term)
        {
            var items = new[] { "Apple", "Pear", "Banana", "Pineapple", "Peach" };
            var filteredItems = items.Where(item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0);
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        // public ActionResult GetList(string key = null, string value = null)
        // public string GetList(string key = null, string value = null)
        public JsonResult GetList(string key = null, string value = null)
        {
            //return "excute successful";
            // return new RedirectResult("http://www.baidu.com/");

            var list = Model.ListIsActiveAll().ToString(); // 这样返回的结果是sql语句。如果是toList()则返回一个难以处理的值
            return Json(list, JsonRequestBehavior.AllowGet);

        }
    }
}

