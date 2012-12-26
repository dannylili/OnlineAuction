﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopMenue.aspx.cs" Inherits="OnlineAuction.Web.TestPage.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        /* Reset */
        .menu, .menu ul, .menu li, .menu a
        {
            margin: 0;
            padding: 0;
            border: none;
            outline: none;
        }
        
        /* Menu */
        .menu
        {
            height: 40px; /*width: 505px;*/
            width: 520px;
            background: #4c4e5a;
            background: -webkit-linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
            background: -moz-linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
            background: -o-linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
            background: -ms-linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
            background: linear-gradient(top, #4c4e5a 0%,#2c2d33 100%);
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
        }
        
        .menu li
        {
            position: relative;
            list-style: none;
            float: left;
            display: block;
            height: 40px;
        }
        
        /* Links */
        
        .menu li a
        {
            display: block;
            padding: 0 14px;
            margin: 6px 0;
            line-height: 28px;
            text-decoration: none;
            border-left: 1px solid #393942;
            border-right: 1px solid #4f5058;
            font-family: Helvetica, Arial, sans-serif;
            font-weight: bold;
            font-size: 13px;
            color: #f3f3f3;
            text-shadow: 1px 1px 1px rgba(0,0,0,.6);
            -webkit-transition: color .2s ease-in-out;
            -moz-transition: color .2s ease-in-out;
            -o-transition: color .2s ease-in-out;
            -ms-transition: color .2s ease-in-out;
            transition: color .2s ease-in-out;
        }
        
        .menu li:first-child a
        {
            border-left: none;
        }
        .menu li:last-child a
        {
            border-right: none;
        }
        
        .menu li:hover > a
        {
            color: #8fde62;
        }
        
        /* Sub Menu */
        .menu ul
        {
            position: absolute;
            top: 40px;
            left: 0;
            opacity: 0;
            background: #1f2024;
            -webkit-border-radius: 0 0 5px 5px;
            -moz-border-radius: 0 0 5px 5px;
            border-radius: 0 0 5px 5px;
            -webkit-transition: opacity .25s ease .1s;
            -moz-transition: opacity .25s ease .1s;
            -o-transition: opacity .25s ease .1s;
            -ms-transition: opacity .25s ease .1s;
            transition: opacity .25s ease .1s;
        }
        
        .menu li:hover > ul
        {
            opacity: 1;
        }
        
        .menu ul li
        {
            height: 0;
            overflow: hidden;
            padding: 0;
            -webkit-transition: height .25s ease .1s;
            -moz-transition: height .25s ease .1s;
            -o-transition: height .25s ease .1s;
            -ms-transition: height .25s ease .1s;
            transition: height .25s ease .1s;
        }
        
        .menu li:hover > ul li
        {
            height: 36px;
            overflow: visible;
            padding: 0;
        }
        
        .menu ul li a
        {
            width: 100px;
            padding: 4px 0 4px 40px;
            margin: 0;
            border: none;
            border-bottom: 1px solid #353539;
        }
        
        .menu ul li:last-child a
        {
            border: none;
        }
        
        /* Icons */
        .menu a.documents
        {
            background: url(../img/docs.png) no-repeat 6px center;
        }
        .menu a.messages
        {
            background: url(../img/bubble.png) no-repeat 6px center;
        }
        .menu a.signout
        {
            background: url(../img/arrow.png) no-repeat 6px center;
        }
    </style>
</head>
<body>
    <div style="width: 530px;">
        <ul class="menu">
            <li><a href="#">首页</a></li>
            <li><a href="#">学子风采</a></li>
            <li><a href="#">名优教师</a>
                <ul>
                    <li><a href="#" class="documents">名优教师</a></li>
                    <li><a href="#" class="messages">教师课堂</a></li>
                </ul>
            </li>
            <li><a href="#">课程</a>
                <ul>
                    <li><a href="#">新开课</a> </li>
                    <li><a href="#" class="messages">课件浏览</a></li>
                    <li><a href="#">免费试听区</a></li>
                    <li><a href="#">今日促销课</a></li>
                    <li><a href="#">按费用选课</a></li>
                </ul>
            </li>
            <li><a href="#">在线学习</a>
                <ul>
                    <li><a href="#" title="">进入我的课堂</a></li>
                    <li><a href="#" title="">在线选课</a></li>
                </ul>
            </li>
            <li><a href="#">UU答疑</a></li>
            <li><a href="#">更多</a>
                <ul>
                    <li><a href="#" title="">资料</a></li>
                    <li><a href="#" title="">工具下载</a></li>
                    <li><a href="#" title="">UU教育搜索平台</a></li>
                </ul>
            </li>
        </ul>
    </div>
</body>
</html>
