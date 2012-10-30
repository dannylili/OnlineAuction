using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAuction.Web.Extensions
{
    /// <summary>
    /// 扩展 HtmlHelper 类
    /// </summary>
    public static partial class HtmlHelperExtensioncs
    {
        /// <summary>
        /// <c>Decimal</c> handles rendering decimal templates.
        /// </summary>
        /// <param name="helper">Helper that will be used to access ViewData.</param>
        /// <param name="display">Determines if edit (false) or display (true) template is used.</param>
        /// <returns>An decimal spinner control with all necessary attributes and validation.</returns>
        public static MvcHtmlString Decimal(this HtmlHelper helper, bool display)
        {
            var field = new TagBuilder("div");
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            //field.AddCssClass("FormField");
            //field.MergeAttribute("data-template", helper.ViewData.ModelMetadata.TemplateHint);
            //field.MergeAttribute("data-options", serializer.Serialize(new DecimalTemplate
            //{
            //    Description =
            //        helper.ViewData.ModelMetadata.
            //        Description,
            //    Display = display,
            //    DisplayName =
            //        helper.ViewData.ModelMetadata.
            //        DisplayName,
            //    Calculations =
            //        helper.ViewData.ModelMetadata.
            //            AdditionalValues.
            //            ContainsKey(
            //                Constants.Form.Metadata.Token.
            //                    RemoteCalculations)
            //            ? (
            //              IEnumerable
            //                  <
            //                  SimplifiedAttributeCalculation
            //                  >)
            //              helper.ViewData.ModelMetadata.
            //                  AdditionalValues[
            //                      Constants.Form.Metadata.
            //                          Token.
            //                          RemoteCalculations]
            //            : new SimplifiedAttributeCalculation
            //                  [] { },
            //    HtmlFieldPrefix =
            //        helper.ViewData.TemplateInfo.
            //        HtmlFieldPrefix,
            //    InitialValue =
            //        helper.ViewData.Model != null
            //            ? helper.ViewData.
            //                  TemplateInfo.
            //                  FormattedModelValue
            //                  .ToString()
            //            : string.Empty,
            //    MaxLength =
            //        helper.ViewData.ModelMetadata.
            //            AdditionalValues.ContainsKey(
            //                Constants.Form.Metadata.Token.
            //                    MaxLength)
            //            ? (int?)
            //              helper.ViewData.ModelMetadata.
            //                  AdditionalValues[
            //                      Constants.Form.Metadata.
            //                          Token.MaxLength]
            //            : null,
            //    Maximum = 2147483647,
            //    Minimum = 0,
            //    Places = 2,
            //    Step = 1,
            //    ReadOnly =
            //        helper.ViewData.ModelMetadata.
            //        IsReadOnly,
            //    TabIndex =
            //        helper.ViewData.ModelMetadata.
            //            AdditionalValues.ContainsKey(
            //                Constants.Form.Metadata.Token.
            //                    ItemTabIndex)
            //            ? (int)
            //              helper.ViewData.ModelMetadata.
            //                  AdditionalValues[
            //                      Constants.Form.Metadata.
            //                          Token.ItemTabIndex]
            //            : 0,
            //    Value = helper.ViewData.Model != null
            //                ? string.Format(
            //                    CultureInfo.CurrentCulture,
            //                    "{0:0.00}",
            //                    helper.ViewData.
            //                        TemplateInfo.
            //                        FormattedModelValue)
            //                : string.Empty,
            //    Validations =
            //        helper.Validation().ToString()
            //}));

            return MvcHtmlString.Create(field.ToString());
        }
    }
}

//using System.Collections.Generic;
//2	 2	
// using System.Linq;
//3	  	
//-using System.Linq.Expressions;
//4	 3	
// using System.Reflection;
//5	 4	
// using System.Web.Mvc;
//6	 5	
// using Genuit.Promys.Business.BusinessRulesEngine.Common;
//...	 ...	
//@@ -8,11 +7,10 @@
//8	 7	
// using Genuit.Promys.Business.Extension;
//9	 8	
// using Genuit.Promys.Business.Interfaces;
//10	 9	
// using Genuit.Promys.Common.Const;
//     10	
//+using Genuit.Promys.Common.Enums;
//11	 11	
// using Genuit.Promys.Injection;
//12	 12	
// using Genuit.Promys.MVC.Models;
//13	 13	
// using Genuit.Promys.MVC.Models.Responses;
//14	  	
//-using Genuit.Promys.Business.Extension;
//15	  	
//-using Genuit.Promys.MVC.Models;
//16	 14	
// using System;
//17	 15	
// using Genuit.Promys.Common.Utils;
//18	 16	
 
//...	 ...	
//@@ -23,60 +21,63 @@ public class IntegrationController : BaseController
//23	 21	
//         public ActionResult Export(string token, string filters)
//24	 22	
//         {
//25	 23	
//             //poco Type
//26	  	
//-            string pocoAssemblyString = "Genuit.Promys.Common";
//27	  	
//-            var pocoClass = Assembly.Load(pocoAssemblyString).CreateInstance(pocoAssemblyString + ".Poco." + token, true);
//     24	
//+            const string assemblyRef = "Genuit.Promys.Common";
//     25	
//+            var type = Type.GetType(String.Format("{0}.Poco.{1}, {0}", assemblyRef, token), true, true);
//28	 26	
 
//29	 27	
//             //businessModel
//30	  	
//-            dynamic model = Factory.ApplicationContext.GetObject(token + "Model");
//     28	
//+            dynamic model = Factory.ApplicationContext.GetObject(String.Format("{0}Model", token));
//31	 29	
 
//32	 30	
//             var result = model.ListGlobal();
//33	 31	
//             var data = result as IQueryable;
//34	 32	
 
//35	  	
//-            //get all attributes
//36	  	
//-            var effectiveAttributePermissionModel = Factory.Get<IEffectiveAttributePermissionModel>(Constants.Injection.Tokens.BL.EffectiveAttributePermissionModel);
//     33	
//+            var attributeInfos = type.GetAttributes();
//     34	
//+            var attributeTokens = attributeInfos.Select(at => at.ToAttributeToken());
//37	 35	
 
//38	  	
//-            var metadataModel = Factory.Get<IMetadataModel>(Constants.Injection.Tokens.BL.MetadataModel);
//39	  	
//-            var idTokenMapping = metadataModel.GetEntityCachedIDTokenMapping(new List<string> { token });
//     36	
//+            var permissionsModel = Factory.Get<IAttributePermissionModel>(Constants.Injection.Tokens.BL.AttributePermissionModel);
//     37	
//+            var accessibleAttributeTokens = permissionsModel.GetAccessible(attributeTokens.AsQueryable(), EntityAction.Export);
//40	 38	
 
//41	  	
//-            int entityId = 0;
//42	  	
//-            if (!idTokenMapping.TryGetValue(token, out entityId))
//43	  	
//-            {
//44	  	
//-                return WebHelper.Mvc.GetNotFoundResult();
//45	  	
//-            }
//46	  	
//-
//47	  	
//-            var attributes = effectiveAttributePermissionModel.GetAccessibleEffectiveAttributePermission(entityId, EntityAction.Export);
//     39	
//+            var accessibleAttributeDict =
//     40	
//+                attributeInfos.Where(pi => accessibleAttributeTokens.Contains(pi.ToAttributeToken())).ToDictionary(
//     41	
//+                    k => k.ToAttributeName(), v => v.PropertyType);
//48	 42	
 
//49	  	
//-            //Filter the invalid column
//50	  	
//-            var pocoClassProperties = pocoClass.GetType().GetProperties().Select(a=>a.Name);
//51	  	
//-            var fullColumns = attributes.Where(a => pocoClassProperties.Contains(a.AttributeToken.Substring(token.Length + 1))).Select(a => a.AttributeToken).Distinct();
//52	  	
//-            var columns = fullColumns.Select(a => a.Substring(token.Length + 1));
//53	  	
//-           
//54	  	
//-            //filter
//55	  	
//-            var atts = pocoClass.GetType().GetAttributes();
//56	  	
//-            var accessibleAttributes = atts.Where(a => fullColumns.Contains(a.ToAttributeToken()));
//57	  	
//-            var dict = accessibleAttributes.ToDictionary(a => a.ToAttributeName(), b => b.PropertyType);
//     43	
//+            var metadataModel = Factory.Get<IMetadataModel>(Constants.Injection.Tokens.BL.MetadataModel);
//     44	
//+            var simplifiedAttributes = metadataModel.ListCachedAttributes(accessibleAttributeTokens);
//58	 45	
 
//59	 46	
//             if (string.IsNullOrEmpty(filters) == false)
//60	 47	
//             {
//61	  	
//-                ICondition filter;
//62	  	
//-                filter = JqGridUtils.ConvertJSonFilter(filters, dict);
//63	  	
//-                data = data.Where(pocoClass.GetType(), filter);
//     48	
//+                var filter = JqGridUtils.ConvertJSonFilter(filters, accessibleAttributeDict);
//     49	
//+                data = data.Where(type, filter);
//64	 50	
//             }
//65	 51	
 
//66	 52	
//             //get data
//67	  	
//-            var sourceParameterExpression = Expression.Parameter(pocoClass.GetType(), "a");
//68	 53	
//             var sourceSelectAttributeBindings = new Dictionary<string, IExpression>();
//69	  	
//-            foreach (var column in columns)
//     54	
//+            foreach (var attribute in simplifiedAttributes)
//70	 55	
//             {
//71	  	
//-                var attributePath = column;
//72	  	
//-                sourceSelectAttributeBindings.Add(column, attributePath.Attribute());
//     56	
//+                var propertyName = attribute.Token.Split(new[] {'.'})[1];
//     57	
//+                if (attribute.AttributeTypeID == (int) AttributeType.ReferenceID ||
//     58	
//+                              attribute.AttributeTypeID == (int) AttributeType.Lookup)
//     59	
//+                {
//     60	
//+                    var navPropertyName = propertyName.Replace("ID", String.Empty);
//     61	
//+                    var navPropertyInfo = type.GetProperty(navPropertyName);
//     62	
//+                    if (navPropertyInfo != null)
//     63	
//+                    {
//     64	
//+                        const string tokenPropertyName = "Token";
//     65	
//+                        if (navPropertyInfo.PropertyType.GetProperty(tokenPropertyName) != null)
//     66	
//+                        {
//     67	
//+                            var parentTokenPath = String.Format("{0}.{1}", navPropertyName, tokenPropertyName);
//     68	
//+                            sourceSelectAttributeBindings.Add(navPropertyName, parentTokenPath.Attribute());
//     69	
//+                            continue;
//     70	
//+                        }
//     71	
//+                    }
//     72	
//+                }
//     73	
//+                sourceSelectAttributeBindings.Add(propertyName, propertyName.Attribute());
//73	 74	
//             }
//74	 75	
 
//75	 76	
//             var dynamicObjectExpression = sourceSelectAttributeBindings.NewDynamic();
//76	 77	
 
//77	 78	
//             var source = data.Select(dynamicObjectExpression).ToList();
//78	 79	
 
//79	  	
//-            return new TsvResult(source, attributes, pocoClass.GetType());
//     80	
//+            return new TsvResult(source, type);
//80	 81	
//         }
//81	 82	
//     }
//82	 83	
// }