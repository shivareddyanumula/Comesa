<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_UnAuthorized.aspx.cs" Inherits="frm_UnAuthorized" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: Smart HR ::</title>
    <link rel="icon"
        type="image/png"
        href="Images/SmartHr_arrows.PNG" />
    <link rel="stylesheet" type="text/css" href="Errorcss.css" />

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
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
</head>
<body>
    <form id="form1" runat="server">

        <div class="header">
            <!--header-->

            <div class="hdrtopbg1">
            </div>
            <!--hdrtopbg1 end-->

            <div>
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
                <%--<div class="klogo">
          <img src="images/K-Logo1a.png"  /></div>
        
        <div class="ktitle">
          <img src="images/hdrbg1b.jpg"  /></div>
       	
        <div class="smhrlogo">
        
          <img src="images/smhrlogo2.png"  /></div>--%>
            </div>
            <!--hdrtopbg2 end-->

        </div>
        <!--header end-->

        <div style="clear: both;"></div>

        <div class="redbg2">
            <div class="toptitle2">
                Human Resource Management System
            </div>
        </div>
        <!--redbg2 end-->

        <div class="middlebox1">


            <div class="mainpg">

                <div class="box1">

                    <div class="box2">

                        <div class="box3">

                            <!--box4-->


                            <div class="box5">
                                <!--hding1-->
                                <div class="hding1"></div>
                                <!--hding1-->

                                <div class="hding1"><b>User with Unauthorized Access</b></div>
                                <!--hding1-->

                            </div>
                            <!--box5-->

                            <div style="clear: both;"></div>

                            <div class="box6">
                                <asp:LinkButton ID="lnk_Logout" Width="71" Height="26" border="0" Style="background-image: url(Images/btn1.png)" runat="server" OnClick="lnk_Logout_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image2','','images/btn2.png',1)"></asp:LinkButton>
                                <%--<a href="Login.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image2','','images/btn2.png',1)"><img src="images/btn1.png" name="Image2" width="71" height="26" border="0" id="Image2" /></a>--%>
                            </div>
                            <!--box6-->

                        </div>
                        <!--box3-->

                    </div>
                    <!--box2-->

                </div>
                <!--box1-->

            </div>
            <!--mainpg-->




        </div>
        <!--middlebox1 end-->


        <div class="footerinnerpage1a">





            <div class="footertextbox3">
                Powered by: Dhanush InfoTech Pvt Ltd  
            </div>






            <div class="footertextbox4">
                Smart HR ©
                <asp:Label ID="lblyear" runat="server"></asp:Label>
                All rights reserved
            </div>







        </div>
        <!--footerbox1 end-->
    </form>
</body>
</html>