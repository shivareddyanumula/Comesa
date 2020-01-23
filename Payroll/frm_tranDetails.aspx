<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_tranDetails.aspx.cs"
    Inherits="Payroll_frm_tranDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RSM_TranDetails" runat="server">
    </telerik:RadScriptManager>
    <div>
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Label ID="lbl_Header" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnl_trandetails" ScrollBars="Auto" runat="server" Width="550px">
                        <telerik:RadGrid  ID="RG_PayTran" runat="server"  Skin="WebBlue"  AutoGenerateColumns="False"
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
                                    <telerik:GridTemplateColumn HeaderText="EMPLOYEE CODE">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="EMPLOYEE NAME">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("EMPNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="SALARY&nbsp;STRUCTURE">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalStruct" runat="server" Text='<%# Eval("SALARYSTRUCT_CODE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="AMOUNT">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("AMOUNT") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="STATUS">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("EMPSALDTLS_STATUS") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <FilterMenu  Skin="WebBlue" >
                            </FilterMenu>
                        </telerik:RadGrid>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
