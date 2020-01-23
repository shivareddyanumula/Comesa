<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personal.aspx.cs" Inherits="Selfservice_Personal" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
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

</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <table align="center" cellpadding="3" cellspacing="3">
            <tr>
                <td colspan="6">
                    <asp:Label ID="lbl_EmployeeDetails" runat="server" Text="Personal Details" Style="font-weight: 700;
                        font-size: medium; color: #000000;" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Title" runat="server" Text="Title" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_SuperVisor" runat="server" Text="Supervisor" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblSupervisor" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_FirstName" runat="server" Text="First Name" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblfirstname" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_Grade" runat="server" Text="Grade" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblGrade" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="lbl_MiddleName" runat="server" Text="Middle Name" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td class="style6">
                    <b>:</b>
                </td>
                <td class="style4">
                    <asp:Label ID="lblMiddlename" runat="server" Width="200px"></asp:Label>
                </td>
                <td class="style4">
                    <asp:Label ID="lbl_SalaryStruct" runat="server" Text="Salary Structure" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td class="style4">
                    <b>:</b>
                </td>
                <td class="style4">
                    <asp:Label ID="lblsalarystruct" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_LastName" runat="server" Text="Last Name" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_LeaveStruct" runat="server" Text="Leave Structure" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblLeaveStruct" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_DOB" runat="server" Text="Date of Birth" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_GrossSal" runat="server" Text="Gross Salary" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblGrosssal" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_DOJ" runat="server" Text="Date of Join" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblDOJ" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_BasicPay" runat="server" Text="Basic Pay" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblBasicPay" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Gender" runat="server" Text="Gender" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_Shift" runat="server" Text="Shift" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblShift" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Bussiness Unit" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblBusinessunit" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_NoticePeriod" runat="server" Text="Notice Period" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblNoticeperiod" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_PayMode" runat="server" Text="Payment Mode" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblPaymode" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_EmpStatus" runat="server" Text="EmployeeStatus" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblempstatus" runat="server" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_MaritalStatus" runat="server" Text="MaritalStatus" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblMaritalstatus" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Position" runat="server" Text="Position" CssClass="style2" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblPosition" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Job" runat="server" Text="Job" CssClass="style2" Font-Bold="True"
                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td>
                    <asp:Label ID="lblJob" runat="server" Width="200px"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Address" runat="server" Text="Address" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt"></asp:Label>
                </td>
                <td>
                    <b>:</b>
                </td>
                <td colspan="4">
                    <telerik:RadTextBox ID="txt_Address" runat="server" Width="500px" >
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: right">
                    <asp:Button ID="btn_Update" runat="server" Text="Update Details" OnClick="btn_Update_Click" />
                </td>
            </tr>
        </table>
    </div>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    </form>
</body>
</html>
