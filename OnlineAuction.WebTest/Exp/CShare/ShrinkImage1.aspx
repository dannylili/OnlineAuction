<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShrinkImage1.aspx.cs" Inherits="OnlineAuction.WebTest.Exp.CShare.ShrinkImage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:FileUpload ID="FileUpload1" runat="server" ViewStateMode="Enabled" />
        
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="upload" 
            Width="77px" />
    
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
