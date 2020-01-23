<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Emp_MedicalClaims.aspx.cs" Inherits="Selfservice_frm_Emp_MedicalClaims" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_Heading" runat="server" Text="Employee Medical Claims" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="RG_EmpMedicalClaims" runat="server" AutoGenerateColumns="false"
                        AllowSorting="false" AllowMultiRowSelection="False" Skin="WebBlue" AllowFilteringByColumn="true"
                        GridLines="None" OnNeedDataSource="RG_EmpMedicalClaims_NeedDataSource" Width="98%" AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="true">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Beneficiary Name" DataField="BENFICIARYNAME">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Hospital Name" DataField="SERVICEPROVIDERNAME">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn HeaderText="Amount" DataField="AMOUNT" FilterControlWidth="70px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridNumericColumn>
                                <telerik:GridDateTimeColumn HeaderText="Invoice Date" DataField="INVOICE_DATE" DataFormatString="{0:d}">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridDateTimeColumn>
                                <telerik:GridBoundColumn HeaderText="Expenditure Name" DataField="EXPENDITURE_NAME">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <PagerStyle AlwaysVisible="true" />
                        <GroupingSettings CaseSensitive="false" />
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>