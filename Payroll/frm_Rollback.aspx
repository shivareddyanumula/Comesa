<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Rollback.aspx.cs" Inherits="Payroll_frm_Rollback" Culture="auto"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript" language="javascript">
            function ShowPopForm(url, name) {
                var win = window.radopen('../Payroll/frm_tranDetails.aspx?ID=' + url + '&PDID=' + name, "RW_TranDetails");
                win.center();
                win.set_modal(true);

            }



        </script>

    </telerik:RadScriptBlock>
    <script type="text/javascript" src="../maintainScrollPosition_IE.js"></script>

    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Header" runat="server" meta:resourcekey="lbl_Header" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmp_Rollback" runat="server" Width="1004px" SelectedIndex="0"
                    Height="440px">
                    <telerik:RadPageView ID="rpv_Rollback" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_businessunit" runat="server" meta:resourcekey="lbl_businessunit"
                                        Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_businessunit" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        AutoPostBack="True" Skin="WebBlue" OnSelectedIndexChanged="rcmb_businessunit_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Period" runat="server" meta:resourcekey="lbl_Period"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_Period" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        Skin="WebBlue" OnSelectedIndexChanged="rcb_Period_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PeriodElements" runat="server" meta:resourcekey="lbl_PeriodElements"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_PeriodElements" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        AutoPostBack="True" Skin="WebBlue" OnSelectedIndexChanged="rcb_PeriodElements_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Trasaction" runat="server" meta:resourcekey="lbl_Trasaction"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcb_Transaction" runat="server" MarkFirstMatch="true" AutoPostBack="True"
                                        Skin="WebBlue" OnSelectedIndexChanged="rcb_Transaction_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Transaction" runat="server" Skin="WebBlue" AutoGenerateColumns="false">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TEMP_PAYTRAN_ID" UniqueName="TEMP_PAYTRAN_ID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TEMP_PAYTRAN_NAME" UniqueName="TEMP_PAYTRAN_NAME"
                                                    meta:resourcekey="TEMP_PAYTRAN_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="STATUS" UniqueName="STATUS" meta:resourcekey="STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PERIOD" UniqueName="PERIOD" meta:resourcekey="PERIOD">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn>
                                                    <ItemTemplate>
                                                        <u>
                                                            <asp:LinkButton ID="lnk_Edit" runat="server" Text="View&nbsp;Details" OnCommand="lnk_Edit_Command"
                                                                CommandArgument='<%# Eval("TEMP_PAYTRAN_ID") %>' CommandName='<%# Eval("TEMP_PAYTRAN_NAME") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Rollback" runat="server" meta:resourcekey="btn_Rollback" OnClientClick="return confirm('Are You Sure You Want to RollBack the Payroll Process ?')"
                                        OnClick="btn_Rollback_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>