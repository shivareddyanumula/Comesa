<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Menus.aspx.cs" Inherits="frm_Menus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1 {
            height: 500px;
            width: 258px;
        }
    </style>
</head>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
<link href="styles.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="people.ico">
<body bgcolor="#f1f1f1">

    <form id="form1" runat="server">
        <table width="1000">
            <div />
        </table>
        <table align="center">
            <tr>

                <%--<td align="center" style="background-image: url('Images/smarthr_new.jpg'); height: 499px; width:613px;" valign="top" >--%>
                <table align="center">
                    <tr>
                        <td>
                            <asp:Button ID="btn_hrpayroll" runat="server" Text="HR & Payroll"
                                OnClick="btn_hrpayroll_Click" Height="50px" Style="margin-right: 1px"
                                Width="194px" />

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_pms" runat="server" Visible="false"
                                Text="Performance Management" OnClick="btn_pms_Click" Height="50px" Style="margin-right: 1px"
                                Width="194px" />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_recruitment" runat="server" Visible="false" Text="Recruitment"
                                OnClick="btn_recruitment_Click" Height="50px" Style="margin-right: 1px"
                                Width="194px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_training" runat="server" Visible="false" Text="Training"
                                OnClick="btn_training_Click" Height="50px" Style="margin-right: 1px"
                                Width="194px" />
                        </td>
                    </tr>

                </table>


            </tr>

        </table>

    </form>
</body>
</html>