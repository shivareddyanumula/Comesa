<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_PayRejectHist.aspx.cs"
    Inherits="Payroll_frm_PayRejectHist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <br />
        <br />
        <table align="center">
            <tr>
                <td>
                    <telerik:RadGrid  ID="RG_PayTran" runat="server" AutoGenerateColumns="False"  Skin="WebBlue" 
                        GridLines="None">
                        <HeaderContextMenu  Skin="WebBlue" >
                        </HeaderContextMenu>
                        <MasterTableView>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="EMPLOYEE NAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("EMPNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="CURRENCY">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurrency" runat="server" Text='<%# Eval("EMPSALDTLS_CURR_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="AMOUNT">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("SALARY") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="STATUS">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("EMPSALDTLS_STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif"
                                    CancelImageUrl="Cancel.gif">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu  Skin="WebBlue" >
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
