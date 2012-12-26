using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace OnlineAuction.Web.Extensions
{
    public static partial class HtmlHelperExtension
    {
        /// <summary>
        /// 添加自动搜索功能
        /// </summary>
        /// <typeparam name="TObject">输入对象</typeparam>
        /// <typeparam name="IResult">对象属性类型</typeparam>
        /// <param name="helper">HtmlString</param>
        /// <param name="SearchEntityName">被引用Entity的名称</param>
        /// <param name="exp">Lamdal表达式</param>
        /// <returns></returns>
        public static MvcHtmlString SearchFor<TObject, IResult>(this HtmlHelper helper, string SearchEntityName, Expression<Func<TObject, IResult>> exp)
        {
            TagBuilder tagDiv = new TagBuilder("A");
            tagDiv.GenerateId(exp.Body.Type.Name + "link" + SearchEntityName);

            /*
             * 构造一个Grid显示应用对象或者添加一个引用对象的页面地址
             */
            tagDiv.InnerHtml = "<input type=\"text\"><input type=\"button\" onClick=\"javascript:alert('%>_<%')\" value='Click Me'";
            return MvcHtmlString.Create(tagDiv.ToString());
        }
    }
}

