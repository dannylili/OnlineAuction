using System.Collections.Generic;
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
                rows = new[]{
                              new {id = 1, cell = new[] {"1", "-7", "Is this a good question?"}},
                              new {id = 2, cell = new[] {"2", "15", "Is this a blatant ripoff?"}},
                              new {id = 3, cell = new[] {"3", "23", "Why is the sky blue?"}}
                            }
            };

            object[] row = new object[] { };
            var persondata = Model.ListIsActiveAll();
            var grid = new Grid();
            List<GridRowCell> cells = new List<GridRowCell>();
            var cell = new GridRowCell();

            foreach (var item in persondata)
            {
                cell = new GridRowCell
                {
                    Name = item.Name,
                    Width = 20,
                    Align = "left"
                };
                cells.Add(cell);
            }
            List<GridRow> rowList = new List<GridRow>();
            GridRow gridRow = new GridRow() { GridRowCell = cells };
            rowList.Add(gridRow);
            grid.GridRow = rowList;

            JavaScriptSerializer JsSerializer = new JavaScriptSerializer();
            var obj=JsSerializer.Serialize(grid);
            // return Json(jsonData, JsonRequestBehavior.AllowGet);
            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult TestSearchable()
        {
            var person = new Person();
            return View(person);
        }

        #endregion
    }
}
