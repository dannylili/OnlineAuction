<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" href="js/Jcrop/css/jquery.Jcrop.css" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/Jcrop/js/jquery.Jcrop.js"></script>
    <script type="text/javascript">

    </script>
</head>
<body>
    <form id="AvatarForm" action="">
    <input type="hidden" id="x" name="x" />
    <input type="hidden" id="y" name="y" />
    <input type="hidden" id="w" name="w" />
    <input type="hidden" id="h" name="h" />
    <input type="text" id="TxtX" name="x" />
    <input type="text" id="TxtY" name="y" />
    <input type="text" id="TxtW" name="w" />
    <input type="text" id="TxtH" name="h" />
    <input type="submit" class="input_btn" id="BtnSaveAvatar" value="确定保存" />选取图片后点击保存查看切割后图片
    </form>
    <div>
        <img src="girl.jpg" alt="" id="TestImage" style="float: left" />
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#TestImage').Jcrop({
                onChange: updateCoords,
                onSelect: updateCoords
            });

            $("#BtnSaveAvatar").click(function () {
                $.ajax({
                    url: 'Handler.ashx',
                    data: { 'x': $("#x").val(), 'y': $("#y").val(), 'w': $("#w").val(), 'h': $("#h").val() },
                    datatype: "text/json",
                    type: 'post',
                    success: function (o) { window.location.href = "result.aspx?url=" + o; }
                });
                return false;
            });
        });

        function updateCoords(c) {
            /*-------------------------------[{add:wyg}{data:2012-12-5}{business:页面增加显示左边的4个input}]------------------------------------------*/
            $("#TxtX").val($("#x").val());
            $("#TxtY").val($("#y").val());
            $("#TxtW").val($("#w").val());
            $("#TxtH").val($("#h").val());

            /*----------------------------------------------------------------------------------------------------*/
            $('#x').val(c.x);
            $('#y').val(c.y);
            $('#w').val(c.w);
            $('#h').val(c.h);
        };
    </script>
    <%--Jcrop库的详细使用，请查看  http://deepliquid.com/projects/Jcrop/demos.php?demo=advanced--%>
</body>
</html>
.