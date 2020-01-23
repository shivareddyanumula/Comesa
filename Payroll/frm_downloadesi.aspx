<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_downloadesi.aspx.cs"
    Inherits="Payroll_frm_downloadesi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Down Load Esi Information</title>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center">
            <tr>
                <td colspan="5" align="center">
                    <asp:Label ID="lbl_Header" runat="server" Text="Export To Excel" Style="font-weight: 700">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="center">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>
                    <telerik:RadGrid ID="rg_ESIDownload" runat="server" GridLines="None" OnNeedDataSource="rg_ESIDownload_NeedDataSource"
                        AllowPaging="true" AutoGenerateColumns="false" OnExcelMLExportStylesCreated="rg_ESIDownload_ExcelMLExportStylesCreated1">
                        <ExportSettings FileName="SMHR_ESIDETAILS" />
                        <MasterTableView CommandItemDisplay="None" TableLayout="Fixed">
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Ip Number" DataField="IMPORTCHILD_IPNUMBER">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Ip Name" DataField="IMPORTCHILD_IPNAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Present Days" DataField="IMPORTCHILD_presentdays">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Total Amount" DataField="IMPORTCHILD_TOTALAMOUNT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Reason Code" DataField="ESIIMPORT_REASONCODE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Employee Name" DataField="NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMPLOYEE_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Employee Id" DataField="SMHR_ESI_MASTER_EMPID" Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td colspan="5"></td>
            </tr>
            <tr>
                <td colspan="5" align="center">
                    <asp:Button ID="btn_Export" runat="server" OnClick="btn_Export_Click" Text="Export to Excel" />
                    <asp:Button ID="btn_Exportopdf" runat="server" Text="Export to Pdf" OnClick="btn_Exportopdf_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>