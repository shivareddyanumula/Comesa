﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_ErrorPage.aspx.cs" Inherits="Frm_ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>:: Smart HR ::</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body style="background-image:url(img/bg-9.jpg)">
    <form id="form1" runat="server">
        <header class="logobg">
            <div class="container">
                <div class="row" style="margin-top: 5px; margin-bottom: 5px;">
                    <div class="col-md-3 col-xs-3 ">
                        <img src="img/COMESA_Logo.png" class="img-responsive pull-left center-image ">
                    </div>
                    <div class="col-md-6 col-xs-6">
                        <h2 class="text-center fontstyle">COMMON MARKET FOR EASTERN AND SOUTHERN AFRICA </h2>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <img src="img/smhrlogo3.png" class="img-responsive pull-right center-image image-position" style="margin-top: 10px;">
                    </div>
                </div>
            </div>
        </header>
        <div class="headerbar">
            <div class="container">
                <h4 class="text-center headerbar_font">Human Resource Management System </h4>
            </div>
        </div>
        <div class="bg">
            <div class="container">
                <div class="row" style="margin-top: 20%; padding: 1% 43%;">
                    <asp:Label ID="lbl_Exit" runat="server" Text="You have successfully logged out."></asp:Label>
                    <a href="Login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image2','','images/btn2.png',1)"></a>
                </div>
            </div>
        </div>
        <div class="footerbg">
            <div class="container">
                <div class="row" style="margin-top: 20px;">
                    <div class="col-md-6 col-xs-12">
                        <p style="padding-left: 100px;" class="right-p">Contact Us : For any issues or suggestions you can mail to: smarthrteam@dhanushinfotech.com </p>
                    </div>
                    <div class="col-md-6 col-xs-12">
                        <p class="pull-right">©
                            <asp:Label ID="lblyear" runat="server" Text='<%# DateTime.Now.Year %>'></asp:Label>. Dhanush Infotech Pvt. Ltd. All Rights Reserved.</p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>--%>
<head runat="server">
    <title>:: Smart HR ::</title>
    <link rel="icon" type="image/png" href="Images/SmartHr_arrows.PNG" />
    <link rel="stylesheet" type="text/css" href="Errorcss.css" />
    <script type="text/javascript">
        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }

        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }

        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2) ; i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }
    </script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
   <header class="logobg">
            <div class="container">
                <div class="row" style="margin-top: 5px; margin-bottom: 5px;">
                    <div class="col-md-3 col-xs-3 ">
                        <img src="img/COMESA_Logo.png" class="img-responsive pull-left center-image ">
                    </div>
                    <div class="col-md-6 col-xs-6">
                        <h2 class="text-center fontstyle">COMMON MARKET FOR EASTERN AND SOUTHERN AFRICA </h2>
                    </div>
                    <div class="col-md-3 col-xs-3">
                        <img src="img/smhrlogo3.png" class="img-responsive pull-right center-image image-position" style="margin-top: 10px;">
                    </div>
                </div>
            </div>
        </header>
    <div style="clear: both;"></div>
    <div class="redbg2">
        <div class="toptitle2">
            Human Resource Management System
        </div>
    </div>
    
    <div class="middlebox1">
        <div class="mainpg">
            <div class="box1">
                <div class="box2">
                    <div class="box3">
                        <div class="box4">
                            <img src="../Images/c.jpg" width="93" height="85" />
                        </div>
                        <div class="box5">
                            <div class="hding1">
                                <asp:Label runat="server" ID="lblErrorFound" Text="Error Found" ForeColor="#2D64AC" Font-Bold="true"></asp:Label>
                            </div>
                            <div class="hding2"><b>Application has Encountered an Unexpected Error.<br />
                                Please Login Again</b></div>
                        </div>
                        <div style="clear: both;"></div>
                        <div class="box6">
                            <a href="Login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('images/btn2.png',1)">
                                <img src="images/btn1.png" name="Image2" width="71" height="26" border="0" id="Image2" /></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
        <div class="footerbg">
            <div class="container">
                <div class="row" style="margin-top: 20px;">
                    <div class="col-md-6 col-xs-12">
                        <p style="padding-left: 100px;" class="right-p">Contact Us : For any issues or suggestions you can mail to: smarthrteam@dhanushinfotech.com </p>
                    </div>
                    <div class="col-md-6 col-xs-12">
                        <p class="pull-right">©
                            <asp:Label ID="lblyear" runat="server" Text='<%# DateTime.Now.Year %>'></asp:Label>. Dhanush Infotech Pvt. Ltd. All Rights Reserved.</p>
                    </div>
                </div>
            </div>
        </div>
    <!--footerbox1 end-->
</body>
</html>