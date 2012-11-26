<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="Scripts/jquery-1.5.1.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $("#bd>div:not(:first)").hide();
            $("#tab td").mouseover(function () {
                var index = $("#tab td").index(this);
                $("#bd>div").eq(index).show().siblings().hide();
            });
            $("#bd a").click(function () {
                var link = $("<td><a href='http://www.baidu.com'>百dddd</a></td>");
                var links = $("<div><a href='http://www.baidu.com'>sdfsdfsd</a></div>");
                $("#tab").append(link);  //向id为tab下面追加link
                $("#bd").append(links); //向id为bd下面追加links
            });
        });
    </script>
    <style type="text/css">
        #tab li.on
        {
            background: #3CF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr id="tab">
            <td>
                <a href="http://www.baidu.com">百度</a>
            </td>
            <td>
                <a href="http://www.cnblogs.com">博客园</a>
            </td>
            <td>
                <a href="http://www.hao123.com">好123</a>
            </td>
            <td>
                <a href="http://www.163.com">163</a>
            </td>
        </tr>
    </table>
    <div id="bd">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            ssssssss
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#Eval("StationName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            asfa
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#Eval("StationName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            azsac
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#Eval("StationName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            azsac
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a href="#">
                                <%#Eval("StationName")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Business" HeaderText="Business" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Certificate" HeaderText="Certificate" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Business" HeaderText="Business" />
                    <asp:BoundField DataField="Business" HeaderText="Business" />
                    <asp:BoundField DataField="Business" HeaderText="Business" />
                    <asp:BoundField DataField="Business" HeaderText="Business" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Certificate" HeaderText="Certificate" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Business" HeaderText="Business" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Certificate" HeaderText="Certificate" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
