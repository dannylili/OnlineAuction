//using System;
//using System.IO;
//using System.Text.RegularExpressions;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Routing;
//using System.Web.Security;
////using Genuit.Promys.Business;
////using Genuit.Promys.Business.Interfaces;
////using Genuit.Promys.Business.Validation;
////using Genuit.Promys.Common.Const;
////using Genuit.Promys.Common.Exceptions;
////using Genuit.Promys.Common.Interfaces;
////using Genuit.Promys.Injection;
////using Genuit.Promys.MVC.Controllers;
////using Genuit.Promys.MVC.Models.Const;
////using Genuit.Promys.Common.Utils;
////using Genuit.Promys.MVC.Extensions;
////using Genuit.Promys.MVC.Models.Responses;

//namespace Genuit.Promys.MVC.Models
//{
//    public static class WebHelper
//    {
//        public static class Request
//        {
//            public static bool IsGet
//            {
//                get
//                {
//                    return Context.Request.HttpMethod == HttpVerbs.Get.ToString().ToUpper();
//                }
//            }

//            public static bool IsPut
//            {
//                get
//                {
//                    return Context.Request.HttpMethod == HttpVerbs.Put.ToString().ToUpper();
//                }
//            }

//            public static bool IsDelete
//            {
//                get
//                {
//                    return Context.Request.HttpMethod == HttpVerbs.Delete.ToString().ToUpper();
//                }
//            }

//            public static bool IsPost
//            {
//                get
//                {
//                    return Context.Request.HttpMethod == HttpVerbs.Post.ToString().ToUpper();
//                }
//            }

//            public static bool IsAjax
//            {
//                get
//                {
//                    var request = Context.Request;
//                    if (request == null)
//                    {
//                        throw new ArgumentNullException("request");
//                    }
//                    return (
//                               (request["X-Requested-With"] == "XMLHttpRequest") ||
//                               (
//                                   (request.Headers != null) &&
//                                   (request.Headers["X-Requested-With"] == "XMLHttpRequest")
//                               )
//                           );
//                }
//            }

//            public static bool IsMultipartFormData
//            {
//                get
//                {
//                    var request = Context.Request;
//                    if (request == null)
//                    {
//                        throw new ArgumentNullException("request");
//                    }
//                    return (
//                               (
//                                   (request["Content-Type"] != null) &&
//                                   (request["Content-Type"].StartsWith("multipart/form-data"))
//                               ) ||
//                               (
//                                   (request.Headers != null) &&
//                                   (request.Headers["Content-Type"] != null) &&
//                                   (request.Headers["Content-Type"].StartsWith("multipart/form-data"))
//                               )
//                           );
//                }
//            }

//            public static bool IsXml
//            {
//                get
//                {
//                    return Context.Request.ContentType.ToLower().Contains("text/xml");

//                }
//            }

//            public static bool IsJson
//            {
//                get
//                {
//                    return Context.Request.ContentType.ToLower().Contains("application/json");
//                }
//            }

//            public static bool IsApi
//            {
//                get
//                {
//                    return IsJson || IsXml;
//                }
//            }

//            public static string ReadToEnd()
//            {
//                var request = Context.Request;
//                var bytes = request.BinaryRead((int)request.InputStream.Length);
//                request.InputStream.Seek(0, SeekOrigin.Begin);
//                return request.ContentEncoding.GetString(bytes);
//            }
//        }

//        public static class Response
//        {
//            public static void AddSubstatusCode(int code)
//            {
//                Context.Response.Headers.Add("X-Code", code.ToString());
//            }

//            public static void MarkAsAdded()
//            {
//                var response = Context.Response;
//                response.StatusDescription = "Added";
//                response.StatusCode = 201;
//                AddSubstatusCode(1);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsUpdated()
//            {
//                var response = Context.Response;
//                response.StatusCode = 201;
//                response.StatusDescription = "Updated";
//                AddSubstatusCode(2);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsDeleted()
//            {
//                var response = Context.Response;
//                response.StatusCode = 200;
//                response.StatusDescription = "Deleted";
//                AddSubstatusCode(1);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsException()
//            {
//                var response = Context.Response;
//                response.StatusCode = 500;
//                AddSubstatusCode(1);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsValidationError()
//            {
//                var response = Context.Response;
//                response.StatusCode = 500;
//                response.StatusDescription = "Validation Error";
//                AddSubstatusCode(2);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsError()
//            {
//                var response = WebHelper.Context.Response;
//                response.StatusDescription = "Error";
//                response.StatusCode = 500;
//                AddSubstatusCode(3);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsNotAuthenticated()
//            {
//                var response = WebHelper.Context.Response;
//                response.StatusCode = 403;
//                response.StatusDescription = "Not Authenticated";
//                AddSubstatusCode(1);
//                response.TrySkipIisCustomErrors = true;
//                Security.Logout();
//            }

//            public static void MarkAsNotAuthorized()
//            {
//                var response = WebHelper.Context.Response;
//                response.StatusCode = 403;
//                response.StatusDescription = "Not Authorized";
//                AddSubstatusCode(2);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsConcurrencyConflict()
//            {
//                var response = WebHelper.Context.Response;
//                response.StatusDescription = "Concurrency Conflict";
//                response.StatusCode = 409;
//                AddSubstatusCode(1);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsConflictWithActive()
//            {
//                var response = WebHelper.Context.Response;
//                response.StatusDescription = "Conflict With Active";
//                response.StatusCode = 409;
//                AddSubstatusCode(2);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsConflictWithInactive()
//            {
//                var response = WebHelper.Context.Response;
//                response.StatusDescription = "Conflict With Inactive";
//                response.StatusCode = 409;
//                AddSubstatusCode(3);
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsNotFound()
//            {
//                var response = WebHelper.Context.Response;
//                response.StatusDescription = "Not Found";
//                response.StatusCode = 404;
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void MarkAsGone()
//            {
//                var response = WebHelper.Context.Response;
//                response.StatusDescription = "Invalid resource";
//                response.StatusCode = 410;
//                response.TrySkipIisCustomErrors = true;
//            }

//            public static void NotAuthenticated()
//            {
//                if (Request.IsAjax || Request.IsApi)
//                {
//                    MarkAsNotAuthenticated();
//                    WebHelper.Context.Response.Write("Your Session has expired. Please login to continue.".GenericMessage().DynamicSerialize());
//                    WebHelper.Context.ApplicationInstance.CompleteRequest();
//                }
//                else
//                {
//                    WebHelper.Context.Response.Redirect("~/Account/LogOff");
//                }
//            }

//            public static void NotAuthorized()
//            {
//                if (Request.IsAjax || Request.IsApi)
//                {
//                    MarkAsNotAuthorized();
//                    Context.Response.Write("You are not authorized to access this resource.".GenericMessage().DynamicSerialize());
//                    Context.ApplicationInstance.CompleteRequest();
//                }
//                else
//                {
//                    Context.Response.Redirect("~/Error/NotAuthorized");
//                }
//            }
//        }

//        public static class Security
//        {
//            public static void Logout()
//            {
//                Context.Session.Abandon();
//                FormsAuthentication.SignOut();
//            }

//            public static bool CanAccess(int userID, string path)
//            {
//                return FilterNotAccessible(userID, path).Length > 0;
//            }

//            public static string[] FilterNotAccessible(int? userID = null, params string[] paths)
//            {
//                return
//                    Factory.Get<IUnifiedSecurityModel>(Constants.Injection.Tokens.BL.UnifiedSecurityModel).
//                        FilterNotAccessible(userID, paths);
//            }

//            public static bool CanAccess(int userID)
//            {
//                var controllerPath = GetAreaControllerActionPath();

//                return CanAccess(userID, controllerPath);
//            }

//            public static void SetAuthenticationCookie()
//            {
//                var user = ApplicationContext.Current.User;

//                WebHelper.Context.Response.Cookies.Set(
//                    FormsAuthentication.GetAuthCookie(String.Format("{0}|%{1}", user.Token, user.ID), false));
//            }
//        }

//        public static class Mvc
//        {
//            public static IController GetNotFoundController(RouteData routeData, HttpRequestBase request)
//            {
//                Response.MarkAsNotFound();
//                routeData.Values["controller"] = "Error";
//                routeData.Values["action"] = "NotFound";
//                routeData.Values["aspxerrorpath"] = request.Url.OriginalString;
//                return Factory.Get<ErrorController>(UIConstants.Injection.Controller.Tokens.Error);
//            }

//            public static RedirectResult GetNotFoundResult()
//            {
//                return new RedirectResult("~/Error/NotFound/");
//            }

//            public static RedirectResult GetConcurencyErrorResult()
//            {
//                return new RedirectResult("~/Error/Concurency");
//            }

//            public static RedirectResult GetNoLandingPage()
//            {
//                return new RedirectResult("~/Error/NoLanding");
//            }

//            public static void ConcurencyError(ExceptionContext filterContext)
//            {
//                if (Request.IsAjax || Request.IsApi)
//                {
//                    Response.MarkAsConcurrencyConflict();
//                    filterContext.Result =
//                        "A concurency exception has occured while updating data".GenericMessage().ToDynamicResult();
//                }
//                else
//                {
//                    filterContext.Result = GetConcurencyErrorResult();
//                }
//                filterContext.ExceptionHandled = true;
//            }

//            public static RedirectResult GetNotAuthorizedErrorResult()
//            {
//                return new RedirectResult("~/Error/NotAuthorized");
//            }

//            //public static void ResourceGoneError(ExceptionContext filterContext)
//            //{
//            //    if (Request.IsAjax || Request.IsApi)
//            //    {
//            //        Response.MarkAsGone();
//            //        filterContext.Result =
//            //            "Resource has been deleted".GenericMessage().ToDynamicResult();
//            //    }
//            //    else
//            //    {
//            //        filterContext.Result = GetNotFoundResult();
//            //    }
//            //    filterContext.ExceptionHandled = true;
//            //}

//            public static JsonResult EmptyJsonResult
//            {
//                get
//                {
//                    return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
//                }
//            }

//            public static DynamicResult EmptyDynamicResult
//            {
//                get
//                {
//                    return new DynamicResult();
//                }
//            }

//            public static HttpNotAuthorizedResult HttpNotAuthorizedResult
//            {
//                get
//                {
//                    return new HttpNotAuthorizedResult();
//                }
//            }

//            public static HttpResourceGoneResult HttpResourceGoneResult
//            {
//                get
//                {
//                    return new HttpResourceGoneResult();
//                }
//            }

//            public static HttpResourceNotFoundResult HttpResourceNotFoundResult
//            {
//                get
//                {
//                    return new HttpResourceNotFoundResult();
//                }
//            }

//            public static HttpResourceConcurrencyConflictResult HttpResourceConcurrencyConflictResult
//            {
//                get
//                {
//                    return new HttpResourceConcurrencyConflictResult();
//                }
//            }

//            public static HttpResourceConflictWithActiveResult HttpResourceConflictWithActiveResult
//            {
//                get
//                {
//                    return new HttpResourceConflictWithActiveResult();
//                }
//            }

//            public static HttpResourceConflictWithInactiveResult HttpResourceConflictWithInactiveResult
//            {
//                get
//                {
//                    return new HttpResourceConflictWithInactiveResult();
//                }
//            }

//            public static object GetData(ActionResult result)
//            {
//                var wrappedActionResult = result as MessageWrappedActionResult;
//                var realResult = wrappedActionResult != null
//                                     ? wrappedActionResult.ActionResult
//                                     : result;
//                var jsonResult = realResult as JsonResult;
//                var partialViewResult = realResult as PartialViewResult;
//                var viewResult = realResult as ViewResult;
//                var dynamicResult = realResult as DynamicResult;
//                var xmlResult = realResult as XmlResult;

//                object data = null;
//                if (jsonResult != null)
//                {
//                    data = jsonResult.Data;
//                }
//                if (partialViewResult != null)
//                {
//                    data = partialViewResult.ViewData.Model;
//                }
//                if (viewResult != null)
//                {
//                    data = viewResult.ViewData.Model;
//                }
//                if (dynamicResult != null)
//                {
//                    data = dynamicResult.Data;
//                }

//                if (dynamicResult != null)
//                {
//                    data = dynamicResult.Data;
//                }

//                if (xmlResult != null)
//                {
//                    data = xmlResult.Data;
//                }

//                return data;

//            }

//            public static string GetViewName(ActionResult actionResult)
//            {
//                if (actionResult == null)
//                {
//                    return null;
//                }
//                actionResult = MessageWrappedActionResult.Unwrap(actionResult);
//                var viewResultBase = actionResult as ViewResultBase;

//                return viewResultBase != null
//                           ? viewResultBase.ViewName
//                           : null;
//            }

//            public static TempDataDictionary GetTempData(ActionResult actionResult)
//            {
//                if (actionResult == null)
//                {
//                    return null;
//                }
//                actionResult = MessageWrappedActionResult.Unwrap(actionResult);
//                var viewResultBase = actionResult as ViewResultBase;

//                return viewResultBase != null
//                           ? viewResultBase.TempData
//                           : null;
//            }

//            public static ViewDataDictionary GetViewData(ActionResult actionResult)
//            {
//                if (actionResult == null)
//                {
//                    return null;
//                }
//                actionResult = MessageWrappedActionResult.Unwrap(actionResult);
//                var viewResultBase = actionResult as ViewResultBase;

//                return viewResultBase != null
//                           ? viewResultBase.ViewData
//                           : null;
//            }

//            public static bool IsViewResultBase(ActionResult actionResult)
//            {
//                if (actionResult == null)
//                {
//                    return false;
//                }
//                actionResult = MessageWrappedActionResult.Unwrap(actionResult);
//                var type = actionResult.GetType();
//                return type.IsDerivedFrom<ViewResultBase>();
//            }

//            public static bool IsDataResult(ActionResult actionResult)
//            {
//                if (actionResult == null)
//                {
//                    return false;
//                }
//                actionResult = MessageWrappedActionResult.Unwrap(actionResult);
//                var type = actionResult.GetType();
//                return type.IsDerivedFrom<IDataActionResult>() || type.IsDerivedFrom<JsonResult>();
//            }
//        }

//        #region Common

//        public static ExceptionInfo GetErrorMessage(Exception ex)
//        {
//            var isDebug = true;
//            try
//            {
//                isDebug = Factory.Get<ISystemConfiguration>(Constants.Injection.Tokens.Common.SystemConfig).IsDebugMode;
//            }
//            catch
//            {
//            }

//            var result = new ExceptionInfo();
//            result.IsBusinessException = ex.GetType().IsDerivedFrom<PromysBaseException>();
//            result.IsDebug = isDebug;

//            string message;
//            if (isDebug)
//            {
//                message = ex.Message;
//                try
//                {
//                    result.StackTrace = ex.StackTrace;
//                }
//                catch
//                {
//                }
//            }
//            else
//            {
//                message = "An unexpected exception has occured. Please contact your Administrator.";
//            }
//            result.Message = message;
//            return result;
//        }

//        public static IErrorResult GetErrorResult()
//        {
//            return new ErrorResult();
//        }

//        public static string BuildAreaControllerPath(string areaName, string controllerName)
//        {
//            var result = string.IsNullOrWhiteSpace(areaName)
//                             ? string.Format("~/{0}", controllerName)
//                             : string.Format("~/{0}/{1}", areaName, controllerName);
//            return result;
//        }

//        public static string BuildAreaControllerActionPath(string areaControllerPath, string actionName)
//        {
//            var result = string.Format("{0}/{1}", areaControllerPath, actionName);
//            return result;
//        }

//        public static string GetAreaControllerPath()
//        {
//            var areaName = GetAreaName();
//            var controllerName = GetControllerName();
//            var result = BuildAreaControllerPath(areaName, controllerName);
//            return result;
//        }

//        public static string GetAreaControllerActionPath()
//        {
//            var areaControllerPath = GetAreaControllerPath();
//            var actionName = GetActionName();
//            var result = BuildAreaControllerActionPath(areaControllerPath, actionName);
//            return result;
//        }

//        public static string GetAreaName()
//        {
//            return (RouteData.DataTokens["area"] ?? string.Empty).ToString();
//        }

//        public static string GetControllerName()
//        {
//            return (RouteData.Values["controller"] ?? string.Empty).ToString();

//        }

//        public static string GetActionName()
//        {
//            return (RouteData.Values["action"] ?? string.Empty).ToString();
//        }

//        public static HttpContextBase Context
//        {
//            get
//            {
//                return Factory.Get<HttpContextBase>(UIConstants.Injection.HttpContextBase);
//            }
//        }

//        public static RouteData RouteData
//        {
//            get
//            {
//                return RouteTable.Routes.GetRouteData(Context);
//            }
//        }

//        public static RequestContext RequestContext
//        {
//            get
//            {
//                return new RequestContext(Context, RouteData);
//            }
//        }

//        #endregion
//    }
//}
