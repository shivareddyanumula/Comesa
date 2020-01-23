<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsAppraisalCycle.aspx.cs" Inherits="PMS_frm_PmsAppraisalCycle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="Rsb_Scripts" runat="server">

        <script language="javascript" type="text/javascript">

            function checkboxClick(control) {
                if (control.checked == true) {
                    if (!confirm('Do you want to Change this Appraisal Cycle as Active')) {
                        control.checked = false;
                    }
                }
            }
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Appcycl" runat="server" Text="Appraisal Cycle" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_AppraisalCycle" runat="server">
                    <telerik:RadPageView ID="RP_AppraisalCycle" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Appraisalcycle" runat="server" AutoGenerateColumns="false"
                                        AllowFilteringByColumn="true" AllowPaging="true"
                                        PageSize="5" Skin="WebBlue" OnNeedDataSource="RG_Appraisalcycle_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="AppraisalCycle id" DataField="APPRCYCLE_ID"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Business Unit" DataField="BUSINESSUNIT_CODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Name" DataField="APPRCYCLE_NAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Description" DataField="APPRCYCLE_DESC">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Start Date" DataField="APPCYCLE_STARTDATE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="End Date" DataField="APPCYCLE_ENDDATE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Status" DataField="APPRCYCLE_ISACTIVE" AllowFiltering="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Commnad" CommandArgument='<%# Eval("APPRCYCLE_ID") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rp_appriasalcycledetails" runat="server" Width="100%">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_Det" runat="server" Text="Details" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"
                                                    Text="Business&nbsp;Unit"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="rcmb_BUI" runat="server" Width="50%" MarkFirstMatch="true" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI"
                                                    ErrorMessage="Please select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_ID" runat="server" Text="[lbl_id]" Visible="False" Style="font-family: Arial, Helvetica, sans-serif; font-size: small"></asp:Label>
                                                <asp:Label ID="lbl_AppraisalcycleName" runat="server" Text="Appraisal Cycle Name"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_Appraisalcycle" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_AppraisalCycle" runat="server" ErrorMessage="Please Enter Appraisal Cycle Name"
                                                    ControlToValidate="txt_Appraisalcycle" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_AppraisalDescription" runat="server" Text="Description"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_AppraisalDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_StartDate" runat="server" Text="Start Date"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="RDP_StartDate" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_Startmonth" runat="server" ValidationGroup="Controls"
                                                    ErrorMessage="Please Enter Start Date" ControlToValidate="RDP_StartDate" Text="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_EndDate" runat="server" Text="End Date"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="RDP_EndDate" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_Endmonth" runat="server" ValidationGroup="Controls"
                                                    ErrorMessage="Please Enter End Date" ControlToValidate="RDP_EndDate" Text="*"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cmpv_rdpEndDate" runat="server" ControlToCompare="RDP_StartDate"
                                                    ControlToValidate="RDP_EndDate" ErrorMessage="End Date should be Greater than Start Date"
                                                    Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_IsActive" runat="server" Text="Status"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <%--<asp:CheckBox ID="CB_IsActive" runat="server" onclick="checkboxClick(this)" />--%>
                                                <telerik:RadComboBox ID="rcmb_Status" runat="server" AutoPostBack="true" Skin="WebBlue" MarkFirstMatch="true">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="Active" Value="1" />
                                                        <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_SelfAppraisal" runat="server" Text="Enable Self Appraisal"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chk_SelfAppraisal" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="text-align: center">
                                                <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="Controls"
                                                    Style="font-family: Arial, Helvetica, sans-serif; font-size: small" Width="50px" />&nbsp;
                                                <asp:Button ID="btn_Update" runat="server" Text="Update" ValidationGroup="Controls"
                                                    Style="font-family: Arial, Helvetica, sans-serif; font-size: small" OnClick="btn_Update_Click"
                                                    Width="50px" />&nbsp;
                                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Style="font-family: Arial, Helvetica, sans-serif; font-size: small"
                                                    OnClick="btn_Cancel_Click" Width="50px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:ValidationSummary ID="vs_AppraisalCycleSummary" runat="server" ValidationGroup="Controls"
                                        ShowMessageBox="True" ShowSummary="False" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>