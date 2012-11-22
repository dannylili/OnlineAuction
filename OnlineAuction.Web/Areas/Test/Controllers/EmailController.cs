using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace OnlineAuction.Web.Areas.Test.Controllers
{
    /// <summary>
    /// 测试发送邮件的功能，
    /// </summary>
    public class EmailController : Controller
    {
        //
        // GET: /Test/Email/
        public ActionResult Index()
        {
            // var dd = "http://127.0.0.1:801/ReportRepository/Email/";
            // Uri reportUrl;
            // var link=Uri.TryCreate(new Uri(dd), "s", out reportUrl) ? reportUrl.AbsoluteUri : null;
            // new RedirectResult("mailto:wyg@year.com");
            // return string.Empty.ToJsonResult();
            // return new RedirectResult("mailto:wyg@year.com");
            return View();
        }

        /// <summary>
        /// 测试POST方法调用邮件客户端
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EmailClientCall()
        {
            var url = "mailto:wyg_test@test.com?subject='159'";
            return new RedirectResult(url);
        }

        /// <summary>
        /// 测试GET方法调用邮件客户端
        /// </summary>
        /// <returns></returns>
        public ActionResult SendEmail()
        {
            return new RedirectResult("mailto:wyg_test@test.com?subject='159'");
        }

        public ActionResult SendEmail2()
        {
            return JavaScript(string.Format("<script>location.href='{0}'</script>", "mailto:wyg_test@test.com?subject=123.body=159"));
        }

        public ActionResult EmailSend()
        {
            MailAddress maileaddress = new MailAddress("weilai.men@163.com", "Yonggui Wang", System.Text.Encoding.UTF8);
            //maileaddress.Address= "yonggui.wang@wysnan.com";
            // MailAddressCollection maileaddress = new MailAddressCollection();
            // maileaddress.Add("ywang@promys.com");
            // maileaddress.Add("yonggui.wang@wysnan.com");

            MailMessage message = new MailMessage();

            /// 收件人地址
            message.To.Clear();
            message.To.Add(maileaddress);

            // 从web.config中自动取得smtp信息

            /// 发送邮件相关内容
            message.CC.Clear();
            message.CC.Add("876691449@qq.com");
            message.Body = "<a href=\"http://www.baidu.com\">点击查询内容</a>";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test E-Maile contain";
            // message.IsBodyHtml = true;



            // http://www.cnblogs.com/maiweibiao/articles/1837821.html
            
            //var smtpHost = "smtp.gmail.com";
            //var smtpPort = 587;
            SmtpClient client = new SmtpClient();

            /// 添加发件人验证
            // string fromEmailAddress = "ywang@promys.com";

            /// 各个邮箱的验证用户名和密码不一样，Gamil的为
            //string smtpUserName = "username@gmail.com";
            //string smtpUserPwd = "password";
            //if (!string.IsNullOrWhiteSpace(smtpUserName) && !string.IsNullOrWhiteSpace(smtpUserPwd))
            //{
                //client.UseDefaultCredentials = false;
                //client.Credentials = new NetworkCredential(smtpUserName, smtpUserPwd);
            //}

            client.Send(message);

            return JavaScript("alert(\"发送成功\");");
        }
    }
}
