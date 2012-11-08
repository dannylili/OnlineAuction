using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace OnlineAuction.Web.Models.Form
{
    public class FormField
    {

    }
}



//public static class HtmlExtensions
//{
//    public static MvcHtmlString FileUpload<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
//    {
//        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
//        string name = ExpressionHelper.GetExpressionText(expression);
//        string fullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
//        if (String.IsNullOrEmpty(fullName))
//        {
//            throw new ArgumentException("name不得為null或空值");
//        }

//        TagBuilder tagBuilder = new TagBuilder("input");
//        tagBuilder.MergeAttributes(htmlAttributes);
//        tagBuilder.MergeAttribute("type", "file");
//        tagBuilder.MergeAttribute("name", fullName, true);
//        tagBuilder.GenerateId(fullName);


//        // If there are any errors for a named field, we add the css attribute.
//        ModelState modelState;
//        if (helper.ViewData.ModelState.TryGetValue(fullName, out modelState))
//        {
//            if (modelState.Errors.Count > 0)
//            {
//                tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
//            }
//        }

//        tagBuilder.MergeAttributes(helper.GetUnobtrusiveValidationAttributes(name, metadata));

//        return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));
//    }
//}