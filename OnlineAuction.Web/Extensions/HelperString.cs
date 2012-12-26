using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace OnlineAuction.Web.Extensions
{
    public static partial class HtmlHelperExtension
    {
        /// <summary>
        ///  @Html.EditorFor(t=>t.name,"模板名称")或者@Html.Edito方法调用，参数“模板名称”默认的路径是：Views->Shared->EditorTemplates
        ///  该路径下建立String.cshtml调用@Html.String()，系统就会调用这个扩展方法
        /// </summary>
        /// <param name="helpe"></param>
        /// <returns></returns>
        public static MvcHtmlString String(this HtmlHelper helpe)
        {
            StringBuilder strHelpe = new StringBuilder();

            var result = StringTagBuilder(helpe);
            // HtmlHelperExtension.Validation(helpe);
            MvcHtmlString.Create(helpe.ToString()).Validation();

            // return MvcHtmlString.Create(strHelpe.ToString());
            return MvcHtmlString.Create(result.ToString());
        }

        private static TagBuilder StringTagBuilder(HtmlHelper helpe)
        {
            var tag = new TagBuilder("DIV");
            tag.SetInnerText("Calld String extention mthod");
            tag.GenerateId("divExtTxt");
            // tag.InnerHtml = helpe.ViewData.ModelMetadata.DisplayName;
            tag.InnerHtml = "<image src='/Contet/Image/ajax-load.jpg'>";
            tag.AddCssClass("divStyle");
            tag.MergeAttribute("backgroud-color:", "red");
            return tag;
        }
    }
}