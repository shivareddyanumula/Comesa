<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bonuspast.aspx.cs" Inherits="bonuspast" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </div>
        <br />
        <table align="center">
            <tr>
                <td>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_businessunit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_businessunit" runat="server" OnSelectedIndexChanged="rcmb_businessunit_SelectedIndexChanged"
                                        AutoPostBack="True" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_period" runat="server" Text="Financial Period"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_period" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_period_SelectedIndexChanged"
                                        MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_periodelements" runat="server" Text="Period&nbsp;Elements"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_periodelements" runat="server" AutoPostBack="True" Filter="Contains"
                                        OnSelectedIndexChanged="rcmb_periodelements_SelectedIndexChanged1" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">
                            <tr>
                                <td colspan="2" align="center">
                                    <telerik:RadGrid ID="rg_bonuspast" runat="server" AutoGenerateColumns="False" Width="1000px"
                                        GridLines="None" Visible="false" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SI_NO" UniqueName="SI_NO" HeaderText="S.No" meta:resourcekey="SI_NO">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_empname" runat="server" Text='<%#Eval("Emp_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Department">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_department" runat="server" Text='<%#Eval("DEPARTMENT_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_designation" runat="server" Text='<%#Eval("Employee_POSITIONS_CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Bonus (%)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_bonuspercentage" runat="server" Text='<%#Eval("Bonus_Percentage") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Total Value">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_bonusvalue" runat="server" Text='<%#Eval("SAL") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Bonus Value">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_bonus" runat="server" Text='<%#Eval("BONUS_VALUE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Ex-Gratia">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_exgratia" runat="server" Text='<%#Eval("EXGRATIA") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <RowIndicatorColumn>
                                                <HeaderStyle Width="20px"></HeaderStyle>
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn>
                                                <HeaderStyle Width="20px"></HeaderStyle>
                                            </ExpandCollapseColumn>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadAjaxPanel>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>