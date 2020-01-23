<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Gratuity.aspx.cs" Inherits="Payroll_frm_Gratuity" Title="Untitled Page" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
            function Gratuity_History() {
                var win = window.radopen('../payroll/frm_Previousdtls.aspx', "RW_GratuityHistory");
                win.center();
                win.height = 10;
                win.title = "Gratuity History";
                win.set_modal(true);
            }
        </script>
    </telerik:RadScriptBlock>

    <table class="style2">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Gratuity" runat="server" Style="font-weight: 700"
                    Text="Gratuity Information"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style2">
                    <tr>
                        <td align="right">

                            <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit"></asp:Label>
                        </td>
                        <td style="width: 1%">
                            <b>:</b></td>
                        <td style="width: 49%">
                            <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 49%">
                            <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
                        </td>
                        <td style="width: 1%">
                            <asp:Label ID="LBL_SYMBOL0" runat="server" Text=":" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td style="width: 49%">
                            <telerik:RadDatePicker ID="rdtp_Period" runat="server" Enabled="false">
                                <Calendar ID="Calender1" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                    ViewSelectorText="x">
                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 49%">
                            <asp:Label ID="lbl_Payitems" runat="server" Text="Payitems"></asp:Label>
                        </td>
                        <td style="width: 1%">
                            <asp:Label ID="LBL_SYMBOL1" runat="server" Text=":" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td style="width: 49%">
                            <asp:RadioButtonList ID="rlist_Payitems" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="rlist_Payitems_SelectedIndexChanged"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Text="Gross"></asp:ListItem>
                                <asp:ListItem Text="Payitems"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:CheckBoxList ID="chklst_Payitems" runat="server">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%" align="right">
                            <asp:Button ID="btn_Calculate" runat="server" OnClick="btn_Calculate_Click"
                                Text="Calculate" />
                        </td>
                        <td align="right">&nbsp;</td>
                        <td align="left">
                            <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" />
                            <asp:Button ID="btn_Approve" runat="server" Text="Approve" Visible="False"
                                OnClick="btn_Approve_Click" />
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="False"
                                OnClick="btn_Cancel_Click" />
                            <asp:Button ID="btn_Reject" runat="server" Text="Reject" Visible="False" />
                            <asp:LinkButton ID="lnkbtn_History" runat="server"
                                OnClick="lnkbtn_History_Click">View History</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <telerik:RadGrid ID="rg_Gratuity" runat="server" Skin="WebBlue" Width="762px"
                                AutoGenerateColumns="false">
                                <MasterTableView>
                                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="Chk_All" Text="Check" runat="server" OnCheckedChanged="Chk_All_CheckedChanged" AutoPostBack="true" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chk_Check" runat="server" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridBoundColumn HeaderText="Employee Id" DataField="EMP_ID" Visible="false"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EMP_NAME"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Date of joining" DataField="DOJ"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Department" DataField="DEPARTMENT"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Designation" DataField="DESIGNATION"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Years Of Service" DataField="EXPERIENCE"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Completed date" DataField="COMPLETION_DATE"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Gratuity Amount" DataField="AMOUNT"></telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>