<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_JobReqDetails.aspx.cs" Inherits="Recruitment_frm_JobReqDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script language="javascript" type="text/javascript">
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow)
                    oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog         
                else if (window.frameElement.radWindow)
                    oWindow = window.frameElement.radWindow; //IE (and Moz as well)         
                return oWindow;
            }

            function Close() {
                GetRadWindow().Close();
            }  
        </script>

    </telerik:RadScriptBlock>
    <div>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All"
            meta:resourcekey="RadFormDecorator1Resource1" />
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <center> <b>Resource Requisition Details </b></center>
        <br />
        
        <table align="Center">
            <tr>
                <td>
                    <asp:Label ID="lbl_BU" runat="server" Text="Business Unit" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lbl_BU_Value" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lbl_Directorate_Value" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Dept" runat="server" Text="Department" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lbl_Dept_Value" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Desg" runat="server" Text="Position" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lbl_Desg_Value" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Level" runat="server" Text="Scale" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lbl_Level_Value" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_EmpType" runat="server" Text="Employee Type" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lbl_EmpType_Value" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_CTC" runat="server" Text="Salary" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lbl_CTC_Value" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
