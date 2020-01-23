<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeFile="Login.aspx.cs"
    Inherits="Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="head1">
    <title>:: Smart HR ::</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

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

    <script type="text/javascript">
        function ShowPopForm(url) {
            if (url == "") {
                alert('Please Enter username inorder to recover the password');
                return;
            }
            else {
                var win = window.radopen('Security/ForgotPassword.aspx?NAME=' + url, "RW_ForgotPWD");
                win.center();
                win.set_modal(true);
            }
        }

        function lnk_pass_Click() {
            var win = window.radopen('Security/ChangePassword.aspx', "RW_ChangePWD");
            win.center();
            win.setSize("550", "350");
            wnd.set_status = " ";
            win.set_modal(true);
        }
    </script>

    <script type="text/javascript">
        function ShowPop() {
            var win = window.radopen('Security/frmEmpSkills.aspx', "RadWindow_Skills");
            win.center();
            win.set_height("350");
            win.set_width("500");
            win.add_close(OnClientCloseHandler);
            win.set_modal(true);
        }
        function OnClientCloseHandler() {
            var var2 = document.getElementById("lblSession").value;
            if (var2 == 'true') {
                window.location.href = "Security/frm_Dashboard.aspx";
            }
            else if (var2 == '') {
                window.location.href = "Security/frm_Dashboradmngr.aspx";
            }
            else {

            }
        }
    </script>

    <script type="text/javascript">
        function pressedKey(form, e) {
            var key;
            if (window.event) {
                key = window.event.keyCode;

            }
            else {
                key = e.which;
            }
            if (key == 13) {
                document.getElementById("btnLogin").focus();
            }
        }
    </script>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body style="background-image:url(img/bg-9.jpg)">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="rsmLogin" runat="server"></telerik:RadScriptManager>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            <Windows>
                <telerik:RadWindow ID="RW_ForgotPWD" runat="server" Modal="true" ReloadOnShow="true"
                    KeepInScreenBounds="false" Width="400px" Height="150px" Behaviors="Close">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
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
        <br />
        <br />
        <div>
            <div class="bg">
                <div class="container">
                    <div class="row" style="margin-top: 5%; padding: 15px 0px;">
                        <asp:HiddenField ID="lblSession" runat="server" />
                        <div class="col-md-4 col-md-offset-3 col-md-pull-1 pull-right">
                            <div class="panel panel-default">
                                <div class="panel-heading panel-login">
                                    <h3 class="panel-title text-center ">Login Page</h3>
                                </div>
                                <div class="panel-body">
                                    <fieldset>
                                        <div class="form-group">
                                            <asp:TextBox name="Search" type="text" ID="rtxtUserName" runat="server"
                                                class="form-control formcustom-control" placeholder="User Name" hint="Search.."></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="User Name Cannot be Empty"
                                            ValidationGroup="Controls" ControlToValidate="rtxtUserName" Text="*" meta:resourcekey="rfvUserName"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox name="Search" ID="rtxtPassword" runat="server"
                                                class="form-control formcustom-control" placeholder="Password" TextMode="Password" hint="Search.."></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password cannot be empty"
                                            ValidationGroup="Controls" ControlToValidate="rtxtPassword" Text="*" meta:resourcekey="rfvPassword"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox ID="chk_Remember" runat="server" Font-Bold="True" /><strong style="font-weight: 500"> Keep me Signed In...</strong>
                                                <asp:LinkButton ID="lnk_Forgot" runat="server" Text="Forgot Password" class="buttontext" Style="padding-left: 75px; font-weight: 700"
                                                    Font-Bold="True" Font-Names="Arial" Font-Size="9pt" ForeColor="Black" Font-Underline="true" OnClick="lnk_Forgot_Click"></asp:LinkButton>
                                            </label>
                                        </div>
                                        <asp:Button ID="btnLogin" runat="server" ValidationGroup="Controls" onmouseout="MM_swapImgRestore()" Text="Login"
                                            onmouseover="MM_swapImage('Image7','','images/signin2.png',1)" class="btn btn-lg btn-success btn-block" OnClick="btnLogin_Click" />
                                        <asp:CheckBox ID="chk_Windows" runat="server" AutoPostBack="True" Font-Bold="True"
                                            Font-Names="Arial" Font-Size="9pt" ForeColor="Black" OnCheckedChanged="chk_Windows_CheckedChanged"
                                            Text="Windows Authentication" Visible="False" />
                                    </fieldset>
                                    <asp:ValidationSummary runat="server" ID="vsLogin" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="ui-widget" id="failure" runat="server" visible="false">
                <div class="ui-state-error ui-corner-all" style="padding: 0 .7em;">
                    <p style="width: 333px">
                        <span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span>
                        <strong>
                            <asp:Label ID="lbl_failure" runat="server" Visible="False" Text="Alert:Login Failed. Incorrect User Name/ Password"
                                ForeColor="#CC0000" Font-Size="Small"></asp:Label>
                        </strong>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
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
                        <p class="pull-right">
                            ©
                            <asp:Label ID="lblyear" runat="server" Text="<%# Convert.ToString(DateTime.Now.Year) %>"></asp:Label>. Dhanush Infotech Pvt. Ltd. All Rights Reserved.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
