﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="LabCourseSys.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="Js/fuyun001.js" type="text/javascript"></script>
    <script src="js/main.js" type="text/javascript"></script>
    <script src="layer/layer.js" type="text/javascript"></script>
    <link href="css/pageheader.css" rel="stylesheet" type="text/css" />
    <link href="css/AspNetPager.css" rel="stylesheet" type="text/css" />
    <%--  <link href="css/index.css" rel="stylesheet" type="text/css" />--%>

    <title>计算机学院实践教学排课系统</title>
    <style type="text/css">
        body {
            background: url("images/66.jpg");
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <div class="handle_a">
        <div class="head_bg">
            <div class="cl top_h">
                <div class="nov m_l l" id="menu">
                    <ul id='nav'>
                        <li><a class='hover' href='#' name="lab.aspx">实验室管理</a><ul>
                            <li><a class='hover' href='#' name="lab.aspx">实验室管理</a></li>
                        </ul>
                        </li>
                        <li><a class='hover' href='#' name="course.aspx">实验室排课</a><ul>
                            <li><a class='hover' href='#' name="course.aspx">实验室排课</a></li>
                        </ul>
                        </li>
                        <li><a class='hover' href='#'>排课记录管理</a><ul>
                            <li><a class='hover' href='#'>排课记录管理</a></li>
                        </ul>
                        </li>
                        <li><a class='hover' href='#'>系统设置</a><ul>
                            <li><a class='hover' href='#'>系统设置</a></li>
                        </ul>
                        </li>
                    </ul>
                </div>
                <div class="classmenu" id="content">
                </div>
                <div class="park">
                </div>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
        <div id="mainDiv">
        </div>
    </form>
</body>
</html>
