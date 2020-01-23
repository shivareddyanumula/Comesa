<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_PmsAppraisalEmpDetails.aspx.cs" Inherits="PMS_frm_PmsAppraisalEmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function CloseAndRedirect(sender, args, pageUrl) {
            GetRadWindow().BrowserWindow.location.href = '../PMS/frm_PmsMgrAppraisalnew.aspx'; //"'" + pageUrl + "'";
            GetRadWindow().close();
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
    </script>        
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="rsmEmpDetails" runat="server"></telerik:RadScriptManager>
            <table style="width: 80%">
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Label ID="lblHeader" runat="server" Text="Employee Details" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmpFullName" runat="server" Text="Full Name" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbEmpFullName" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrsnlNo" runat="server" Text="Personal No" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbPrsnlNo" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbDOB" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCrntPstn" runat="server" Text="Current Position" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbCrntPstn" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTypEmp" runat="server" Text="Type of Employee" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbTypEmp" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCntExpDate" runat="server" Text="Contract Expiry Date" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbCntExpDate" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPscScale" runat="server" Text="PSC Scale" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbPscScale" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDOC" runat="server" Text="Date of Current Appointment" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbDOC" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDept" runat="server" Text="Department" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbDept" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSection" runat="server" Text="Section" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbSection" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIPPH" runat="server" Text="Immedaite Previous Post Held" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbIPPH" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrsntBasicSal" runat="server" Text="Present Basic Salary" Font-Bold="true"></asp:Label></td>
                    <td><b>:</b></td>
                    <td>
                        <telerik:RadTextBox ID="rtbPrsntBasicSal" runat="server" Width="160px" Enabled="false"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Label ID="lblPreEmpDtls" runat="server" Text="Previous Employment Details :" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <telerik:RadGrid ID="rgEmpDetails" runat="server" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="rgEmpDetails_NeedDataSource"
                            AllowPaging="True" AllowFilteringByColumn="false" Skin="WebBlue">
                            <MasterTableView CommandItemDisplay="None" EnableNoRecordsTemplate="true">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="APPEXP_ID" UniqueName="APPEXP_ID" HeaderText="ID"
                                        meta:resourcekey="APPEXP_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="APPEXP_RELDATE" UniqueName="APPEXP_RELDATE" HeaderText="Dates"
                                        meta:resourcekey="APPEXP_RELDATE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="APPEXP_COMPANY" UniqueName="APPEXP_COMPANY" HeaderText="Name of the Institution"
                                        meta:resourcekey="APPEXP_COMPANY">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <NoRecordsTemplate>
                                    <div>
                                        There are no records to display
                                    </div>
                                </NoRecordsTemplate>
                            </MasterTableView>
                            <PagerStyle AlwaysVisible="true" />
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>