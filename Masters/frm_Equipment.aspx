<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Equipment.aspx.cs" Inherits="Masters_frm_Equipment" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cphEquipmentCreation" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript"></script>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_EquipmentCreation" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_EquipmentHeading" runat="server" Text="Equipment" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxManagerProxy ID="RAM_EquipmentCreation" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="Rg_EquipmentCreation">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManagerProxy>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="600px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_DPT_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Equipment" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_Equipment_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EQUIPMENT_NAME" UniqueName="EQUIPMENT_NAME"
                                                    AllowFiltering="true" HeaderText="Name"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDateTimeColumn FilterControlWidth="100px" DataField="EQUIPMENT_EXPIRYDATE" UniqueName="EQUIPMENT_EXPIRYDATE" DataFormatString="{0:dd/MM/yyyy}"
                                                    AllowFiltering="true" HeaderText="Expiry date" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridBoundColumn DataField="EQUIPMENT_BUSINESSUNITNAME" UniqueName="EQUIPMENT_BUSINESSUNITNAME"
                                                    AllowFiltering="true" HeaderText="Business Unit" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EQUIPMENT_DIRECTORATE" UniqueName="EQUIPMENT_DIRECTORATE"
                                                    AllowFiltering="true" HeaderText="Directorate" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EQUIPMENT_DEPARTMENT" UniqueName="EQUIPMENT_DEPARTMENT"
                                                    AllowFiltering="true" HeaderText="Department" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EQUIPMENT_SUBDEPARTMENT" UniqueName="EQUIPMENT_SUBDEPARTMENT"
                                                    AllowFiltering="true" HeaderText="Sub Department" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EQUIPMENT_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command"
                                                        CommandArgument='<%# Eval("EQUIPMENT_ID") %>'
                                                        meta:resourceKey="lnk_Add">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                        <%--<table align="center">
                            <tr>
                                <td align="center">
                                    <asp:UpdatePanel ID="updPanel1" runat="server">
                                        <ContentTemplate>
                                            <table align="center">
                                                <tr align="center">
                                                    <td align="center" colspan="3">
                                                        <asp:Label ID="lblheader" runat="server" Text="Import Department Details" Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="~/Masters/Importsheets/Import_Department.xlsx" runat="server" id="A2">Download
                                                            Department Details Template</a>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="fu_department" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_import" runat="server" Text="Import" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_import" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Activity_ADDView" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lbl_EquipmentID" runat="server" Visible="False"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Empreg_BU" runat="server" meta:resourcekey="lbl_Empreg_BU" Text="Business Unit"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_EmpReg_BU" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_EmpReg_BU_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmpReg_BU" runat="server" ErrorMessage="Please Select Business Unit"
                                        ControlToValidate="rcmb_EmpReg_BU" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Directorate" AutoPostBack="true" runat="server" Skin="WebBlue" MaxLength="40" Filter="Contains"
                                        EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_Directorate" runat="server" ControlToValidate="rad_Directorate"
                                        InitialValue="Select" ErrorMessage="Please Select Directorate" ValidationGroup="Controls">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Department" runat="server" Skin="WebBlue" MaxLength="40" AutoPostBack="True" Filter="Contains"
                                        EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rad_Department_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_Department" ControlToValidate="rad_Department"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Department"
                                        InitialValue="Select">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_SubDepartment" runat="server" Text="Sub Department"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_SubDepartment" runat="server" Filter="Contains"
                                        EnableEmbeddedSkins="false" OnSelectedIndexChanged="rad_SubDepartment_SelectedIndexChanged"
                                        AutoPostBack="true" MaxLength="50" TabIndex="2">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_SubDepartment" runat="server" ControlToValidate="rad_SubDepartment"
                                        InitialValue="Select" ErrorMessage="Please Select Sub Department" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>--%>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EquipmentName" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rad_EquipmentName" runat="server" Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_EquipmentName" runat="server" ControlToValidate="rad_EquipmentName"
                                        ErrorMessage="Please Enter Name" Text="*" ValidationGroup="Controls" ForeColor="Red"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ExpiryDate" runat="server" Text="Expiry Date"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_ExpiryDate" runat="server"
                                        Skin="WebBlue">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ExpiryDate" runat="server" ControlToValidate="rdtp_ExpiryDate"
                                        ErrorMessage="Please Select Expiry Date" Text="*" ValidationGroup="Controls" ForeColor="Red"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IsActive" runat="server" Text="IsActive:"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="rad_IsActive" runat="server"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <br />
                                    <asp:Button ID="BTN_SAVE" runat="server" Text="Save" OnClick="BTN_SAVE_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="BTN_SAVE_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vsEquipment" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>