<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_FinaliseData.aspx.cs" Inherits="frm_FinaliseData" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td align="center"><b>
                        <asp:Label ID="lblEMPLOYEENAME" runat="server" Text="Final Data"></asp:Label></b>
                    </td>
                </tr>


                <tr>
                    <td>
                        <telerik:RadGrid ID="Rg_Details" runat="server" AutoGenerateColumns="False"
                            GridLines="None" Skin="WebBlue">
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Emp Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmp_id" runat="server" Text='<%# Eval("LP_EMP_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEMPLOYEENAME" runat="server" Text='<%# Eval("EMPLOYEENAME")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Total Carry Forward">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalCF" runat="server" Text='<%# Eval("CARRY_FORWARD_LEAVES")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Total Encash">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotEncash" runat="server" Text='<%# Eval("ENCASH_LEAVES")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Total Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotEncash" runat="server" Text='<%# Eval("AMOUNT")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                </Columns>

                                <PagerStyle AlwaysVisible="True" />
                            </MasterTableView>
                            <HeaderContextMenu>
                            </HeaderContextMenu>
                            <PagerStyle AlwaysVisible="true" />
                            <FilterMenu>
                            </FilterMenu>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="Btn_Cancel" runat="server" meta:resourcekey="Btn_Cancel"
                            OnClick="Btn_Cancel_Click" Text="Cancel" ValidationGroup="Controls"
                            Visible="True" Width="80px" />
                    </td>
                </tr>

            </table>

        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    </form>
</body>
</html>