<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="OnlineAuction.WebTest.WebHelper.Email.SendEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="不调用客户端直接Send" />
    &nbsp;<asp:Button ID="Button2" runat="server" Text="调用客户端发送邮件" 
        onclick="Button2_Click" />
    </form>
</body>
</html>
