using System.Collections.Generic;
using System.Collections;
using System.Web.Mvc;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Business.ViewModel;
using OnlineAuction.Model;
using System.Web.Script.Serialization;

namespace OnlineAuction.Web.Areas.Adminstrator.Controllers
{
    public class PersonController : Controller
    {
        #region 属性

        protected IPersonModel Model { get; set; }

        #endregion

        #region 添加Get方法

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridData(string sidx, string sord, int page, int rows)
        {
            /// 实现Jquery.Grid的属性
            var jsonData = new
            {
                total = 1, // we'll implement later 
                page = page,
                records = 3, // implement later 
                //rows = new[]{
                //              new {id = 1, cell = new[] {"1", "-7", "Is this a good question?"}},
                //              new {id = 2, cell = new[] {"2", "15", "Is this a blatant ripoff?"}},
                //              new {id = 3, cell = new[] {"3", "23", "Why is the sky blue?"}}
                //            }
            };

            IList list = new List<object>();

            var test1 = new { id = "2", name = "name1" };
            var test2 = new { id = "2", name = "name2" };
            var test3 = new { id = "3", name = "name3" };
            var test4 = new { id = "4", name = "name4" };
            list.Add(test1); list.Add(test2); list.Add(test3);list.Add(test4);

            JavaScriptSerializer jsSeri = new JavaScriptSerializer();
            var test = jsSeri.Serialize(list);

            //var persondata = Model.ListIsActiveAll();
            //foreach (var item in persondata)
            //{
            //    var rows = new[] 
            //    {
            //        id = item.ID,
            //        cell = new[]
            //        {
            //            item.ID,
            //            item.Name,
            //            item.Sex,
            //            item.Nickname
            //        },
            //    };
            //    list.Add(test);
            //}

            // return Json(grid, JsonRequestBehavior.AllowGet);
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult TestSearchable()
        {
            var person = new Person();
            return View(person);
        }

        #endregion
    }
}
