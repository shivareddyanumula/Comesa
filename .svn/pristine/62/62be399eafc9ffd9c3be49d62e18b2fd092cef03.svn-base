<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Previousdtls.aspx.cs"
    Inherits="Payroll_frm_Previousdtls" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr>
                    <td align="center" colspan="4">
                        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                        </telerik:RadScriptManager>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="lbl_Gratutity" runat="server" Style="font-weight: 700" Text="History Of Gratuity Recieved "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4"></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Label ID="lbl_Businessunit" runat="server" Text="Business Unit"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcmb_Businessunit" MarkFirstMatch="true" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
                    </td>
                    <td></td>
                    <td>
                        <telerik:RadComboBox ID="rcmb_Period" MarkFirstMatch="true" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rcmb_Period_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center" colspan="3">
                        <telerik:RadGrid ID="RG_grattuity" runat="server" AutoGenerateColumns="False" GridLines="None">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataSetIndex+1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn HeaderText="Employee Id" DataField="EMP_ID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMP_NAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Date Of Join" DataField="EMP_DOJ">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Service" DataField="EXPERIENCE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Amount" DataField="AMOUNT">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
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
        </div>
    </form>
</body>
</html>