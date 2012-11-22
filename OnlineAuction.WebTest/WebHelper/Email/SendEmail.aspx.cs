using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace OnlineAuction.WebTest.WebHelper.Email
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["sdsf"] = 123;
        }

        protected void Button1_Click(object sender, EventArgs e)
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
            message.To.Add("yonggui.wang@wysnan.com");
            MailAddress fromAddress = new MailAddress("ywang@promys.com", "Yonggui Wang");
            message.From = fromAddress;

            /// 发送邮件相关内容
            message.CC.Clear();
            message.CC.Add("876691449@qq.com");
            message.Body = "<a href=\"http://www.baidu.com\">点击查询内容</a>";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test E-Maile contain";
            message.ReplyTo = maileaddress;
            message.IsBodyHtml = true;



            // http://www.cnblogs.com/maiweibiao/articles/1837821.html
            var smtpHost = "smtp.gmail.com";
            var smtpPort = 587;
            SmtpClient client = new SmtpClient(smtpHost, smtpPort);

            /// 添加发件人验证
            string fromEmailAddress = "ywang@promys.com";

            /// 各个邮箱的验证用户名和密码不一样，Gamil的为
            string smtpUserName = "username@gmail.com";
            string smtpUserPwd = "password";
            if (!string.IsNullOrWhiteSpace(smtpUserName) && !string.IsNullOrWhiteSpace(smtpUserPwd))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpUserName, smtpUserPwd);
            }

            client.Send(message);

        }

        /// <summary>
        /// 通过url来触发打开邮件客户端FireFox或者outlook等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("mailto:wyg_best@163.com?subject='主题'&body=‘{0}’", HttpUtility.UrlEncode("邮件body")));
        }
    }
}