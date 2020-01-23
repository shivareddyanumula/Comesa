<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Entertainmentslab.aspx.cs" Inherits="Masters_frm_Entertainmentslab"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="rsbScripts" runat="server">
        <%--added by Joseph--%>

        <script language="javascript" type="text/javascript">
            function ConfirmationDelete() {
                if (confirm("Are You Sure to Delete this Record?")) {
                    return true;
                }
                else {
                    return false;
                }
            }

            function CheckValue() {
                var fromval = document.getElementById('rntxt_FromValue').value;
                var test = document.getElementById('rntxt_ToValue').value;
                if (test > fromval) {
                    return true
                }
                else {
                    alert("From value should be greater than To Value");
                }
            }
        </script>

        <%--//--%>
    </telerik:RadScriptBlock>
    <br />
    <br />
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmp_tax" runat="server" Width="1004px" SelectedIndex="0">
                    <telerik:RadPageView ID="rpw_tax" runat="server">
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lbl_header" runat="server" meta:resourcekey="lbl_header" Font-Bold="True"
                                        Font-Names="Arial" Font-Size="11pt"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ID" runat="server" meta:resourcekey="lbl_ID"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_Serial" runat="server" 
                                        Skin="WebBlue" BackColor="#519DCF" BorderStyle="None" ForeColor="White" 
                                        ReadOnly="True">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_FromValue" runat="server" meta:resourcekey="lbl_FromValue"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="rntxt_FromValue" runat="server"
                                        Skin="WebBlue" NumberFormat-DecimalDigits="2" IncrementSettings-InterceptArrowKeys="true"
                                        IncrementSettings-InterceptMouseWheel="true" IncrementSettings-Step="0" 
                                        MaxLength="12" MinValue="0">
                                        <IncrementSettings Step="0" />
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_FromValue" runat="server" ControlToValidate="rntxt_FromValue"
                                        Display="Dynamic" ErrorMessage="Enter From Value" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ToValue" runat="server" meta:resourcekey="lbl_ToValue"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="rntxt_ToValue" runat="server"
                                        Skin="WebBlue" NumberFormat-DecimalDigits="2" IncrementSettings-InterceptArrowKeys="true"
                                        IncrementSettings-InterceptMouseWheel="true" IncrementSettings-Step="0" 
                                        MaxLength="12" MinValue="0">
                                        <IncrementSettings Step="0" />
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_ToValue0" runat="server" ControlToValidate="rntxt_ToValue"
                                        Display="Dynamic" ErrorMessage="Enter To Value" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Value" runat="server" meta:resourcekey="lbl_Value"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="rntxt_Value" runat="server"
                                        Skin="WebBlue" NumberFormat-DecimalDigits="2" IncrementSettings-InterceptArrowKeys="true"
                                        IncrementSettings-InterceptMouseWheel="true" IncrementSettings-Step="0" 
                                        MaxLength="12" MinValue="0">
                                        <IncrementSettings Step="0" />
                                        <NumberFormat DecimalDigits="2" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_ToValue" runat="server" ControlToValidate="rntxt_ToValue"
                                        Display="Dynamic" ErrorMessage="Enter Value" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Include" runat="server" meta:resourcekey="btn_Include" OnClick="btn_Include_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" Visible="false" ValidationGroup="Controls"
                                        OnClick="btn_Update_Click" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:CompareValidator ID="CmpValidator" runat="server" ControlToCompare="rntxt_FromValue"
                                        ControlToValidate="rntxt_ToValue" ErrorMessage="To value should be greater than From value"
                                        Operator="GreaterThan" Type="Integer"></asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid  ID="RG_TaxSlab" runat="server" Skin="WebBlue"
                                        AutoGenerateColumns="False" GridLines="None">
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("SMHR_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" meta:resourcekey="SMHR_TAXSERIALNO" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_TaxSerial" runat="server" Text='<%# Eval("SMHR_TAXSERIALNO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" meta:resourcekey="SMHR_TAXFROMVALUE" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_TaxFromvalue" runat="server" Text='<%# Eval("SMHR_TAXFROMVALUE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" meta:resourcekey="SMHR_TAXTOVALUE" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_TaxTovalue" runat="server" Text='<%# Eval("SMHR_TAXTOVALUE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" meta:resourcekey="SMHR_TAXVALUE" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Taxvalue" runat="server" Text='<%# Eval("SMHR_TAXVALUE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="Edit" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_ID") %>'
                                                            meta:Resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="DELETE" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Delete" runat="server" CommandArgument='<%# Eval("SMHR_ID") %>'
                                                            meta:Resourcekey="lnk_Delete" OnCommand="lnk_Del_Command">Delete
                                                        </asp:LinkButton>
                                                        <%--OnClick = "confirmationSave()"--%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridButtonColumn CommandName="Del_Rec" ConfirmDialogType="RadWindow" UniqueName="SMHR_ID"
                                        meta:Resourcekey="lnk_Delete" ConfirmText="Are you sure. You want to Delete?"
                                        Text="Delete" ConfirmTitle="Delete Record">
                                    </telerik:GridButtonColumn>--%>
                                            </Columns>
                                        </MasterTableView>
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <asp:ValidationSummary ID="vs_TaxSlab" runat="server" ValidationGroup="Controls"
                    ShowMessageBox="true" ShowSummary="false" />
            </td>
        </tr>
    </table>
</asp:Content>
