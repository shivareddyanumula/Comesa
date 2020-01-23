<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_HrCreation.aspx.cs" Inherits="PMS_frm_HrCreation" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                <asp:Label ID="lbl_Addhr" runat="server" Text="Add Hr To Business Unit" Style="font-weight: 700">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <telerik:RadMultiPage ID="RMP_Addhr" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_All" runat="server">
                        <telerik:RadGrid ID="RG_Addhr" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            AllowSorting="true" OnNeedDataSource="RG_Addhr_NeedDataSource">
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="S.No" DataField="ROWNO" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Businessunit" DataField="BUSINESSUNIT_CODE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Contacting Person" DataField="PMS_HRCREATION_HRMAILID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" Text="Edit" OnCommand="lnk_Edit_Command"
                                                CommandArgument='<%# Eval("ROWNO") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="lnk_Add" runat="server" Text="Add" OnCommand="lnk_Add_Command">
                                        </asp:LinkButton>
                                    </div>
                                </CommandItemTemplate>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_Details" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_dummy" runat="server" Visible="false">
                                    </asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td align="center">
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_Businessunit"
                                        ErrorMessage="Please select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center"></td>
                                <td align="right">
                                    <asp:Label ID="lbl_Hrmail" runat="server" Text="Hr Email-Id">
                                    </asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_Hrmailid" runat="server">
                                    </telerik:RadTextBox>
                                    <asp:RegularExpressionValidator ID="rev_Hrmail" runat="server" ErrorMessage="Not a Valid Email"
                                        Text="*" ControlToValidate="rtxt_Hrmailid" ValidationGroup="Controls" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    </asp:RegularExpressionValidator>
                                </td>
                                <td align="center">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rtxt_Hrmailid"
                                        ErrorMessage="Please Enter Hr Mail" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:ValidationSummary ID="vs_Hrcreation" ShowSummary="False" ValidationGroup="Controls"
                                        runat="server" ShowMessageBox="true" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                                <td>
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Controls" CausesValidation="true"
                                        OnClick="btn_Save_Click" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls"
                                        CausesValidation="true" OnClick="btn_update_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CausesValidation="false"
                                        OnClick="btn_Cancel_Click" />
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>