using System.Linq;
using System.Web.Mvc;
using OnlineAuction.Business.Interfaces;
using OnlineAuction.Model;

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
            // ContentResult result = new ContentResult();
            Model.Save(entity);
            return (new System.Web.Mvc.JsonResult());
        }
        #endregion
    }
}
