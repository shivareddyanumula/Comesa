<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_AmtTransfertoPensionAct.aspx.cs" Inherits="Pension_frm_AmtTransfertoPensionAct" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Transfer" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_Transfer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkTransferEdit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblHeading" runat="server" Text="Transfer Amount To Provident Fund Account" Font-Bold="true"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="RG_Transfer" runat="server" Skin="WebBlue" GridLines="None"
                                                AutoGenerateColumns="False" OnNeedDataSource="RG_Transfer_NeedDataSource" AllowPaging="True"
                                                AllowFilteringByColumn="True" AllowSorting="True">
                                                <GroupingSettings CaseSensitive="False" />
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="FUNDS_ID" HeaderText="ID"
                                                            meta:resourcekey="FUNDS_ID" UniqueName="FUNDS_ID"
                                                            Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FUNDS_EMPID" HeaderText="FUNDS_EMPID"
                                                            meta:resourcekey="FUNDS_EMPID" UniqueName="FUNDS_EMPID"
                                                            Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FUNDS_EMPCODE" HeaderText="Employee Code"
                                                            meta:resourcekey="FUNDS_EMPCODE" UniqueName="FUNDS_EMPCODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name"
                                                            meta:resourcekey="EMP_NAME" UniqueName="EMP_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                            meta:resourcekey="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridNumericColumn DataField="FUNDS_AMOUNT" HeaderText="Amount Transferred" UniqueName="FUNDS_AMOUNT" FilterControlWidth="100px">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="False"
                                                            meta:resourcekey="GridTemplateColumn" UniqueName="Edit">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkTransferEdit" runat="server"
                                                                    CommandArgument='<%# Eval("FUNDS_ID") %>'
                                                                    OnCommand="lnkTransferEdit_Command">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif"
                                                            InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add"
                                                                OnClick="lnk_Add_Click"> Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" />
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_FORMVIEW" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="40%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" Height="200" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" ControlToValidate="rcmb_BusinessUnit" Text="*" InitialValue="Select" runat="server" ErrorMessage="Please Select Business Unit" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDirectorate" runat="server" Text="Directorate"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Directorate" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Directorate_SelectedIndexChanged" Height="200" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDept" runat="server" Text="Department"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Department" runat="server" MarkFirstMatch="true" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Department_SelectedIndexChanged" Height="200" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Employee" runat="server" MarkFirstMatch="true" Height="200" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" ControlToValidate="rcmb_Employee" runat="server" Text="*" ErrorMessage="Please Select Employee" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAmount" runat="server" Text="Amount to Transfer"></asp:Label>
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rtxt_TransferAmt" MinValue="1" runat="server" Type="Number" MaxLength="10"></telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_TransferAmt" ControlToValidate="rtxt_TransferAmt" runat="server" Text="*" ErrorMessage="Please Enter Amount to Transfer" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <br />
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="Controls" />
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnSubmit_Click" Visible="false" ValidationGroup="Controls" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:ValidationSummary ID="vs_Transfer" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" meta:resourcekey="vg_Master" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <%--<Triggers>
                                <asp:PostBackTrigger ControlID="btnSubmit" />
                                <asp:PostBackTrigger ControlID="btnUpdate" />
                            </Triggers>--%>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>