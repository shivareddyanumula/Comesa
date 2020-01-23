<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_InspectionsMaster.aspx.cs" Inherits="Health_and_Safety_frm_InspectionsMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cphInspectionsMaster" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript"></script>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_InspectionsMaster" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_InspectionsMaster" runat="server" Text="Inspections" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxManagerProxy ID="RAM_InspectionsMaster" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="Rg_InspectionsMaster">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManagerProxy>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="1100px" Height="600px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_DPT_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Inspection" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_Inspection_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="INSPECTION_NAME" UniqueName="INSPECTION_NAME"
                                                    AllowFiltering="true" HeaderText="Name"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="INSPECTION_DESCRIPTION" UniqueName="INSPECTION_DESCRIPTION"
                                                    AllowFiltering="true" HeaderText="Description" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                    AllowFiltering="true" HeaderText="Business Unit" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DIRECTORATE_CODE" UniqueName="DIRECTORATE_CODE"
                                                    AllowFiltering="true" HeaderText="Directorate" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DEPARTMENT_NAME" UniqueName="DEPARTMENT_NAME"
                                                    AllowFiltering="true" HeaderText="Department" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_DIV_CODE" UniqueName="SMHR_DIV_CODE"
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
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("INSPECTION_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command"
                                                        CommandArgument='<%# Eval("INSPECTION_ID") %>'
                                                        meta:resourceKey="lnk_Add">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>

                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Activity_ADDView" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lbl_INSPECTIONID" runat="server" Visible="False"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Empreg_BU" runat="server" meta:resourcekey="lbl_Empreg_BU" Text="Business Unit"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_EmpReg_BU" runat="server" AutoPostBack="True" MarkFirstMatch="true" 
                                        Skin="WebBlue" OnSelectedIndexChanged="rcmb_EmpReg_BU_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmpReg_BU" runat="server" ControlToValidate="rcmb_EmpReg_BU" ErrorMessage="Please Select Business Unit" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
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
                                    <telerik:RadComboBox ID="rad_Directorate" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged" 
                                        EnableEmbeddedSkins="false" MaxHeight="120px" MaxLength="40">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_Directorate" runat="server" ErrorMessage="Please Select Directorate"
                                        ControlToValidate="rad_Directorate" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator></td>--%>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Department" AutoPostBack="True" runat="server" Skin="WebBlue" MaxLength="40" Filter="Contains"
                                        EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rad_Department_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="rfv_Department" runat="server" ControlToValidate="rad_Department"
                                        InitialValue="Select" ErrorMessage="Please Select Department" ValidationGroup="Controls">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_SubDepartment" runat="server" Text="Sub Department"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_SubDepartment" runat="server" MaxLength="50" AutoPostBack="true"
                                        EnableEmbeddedSkins="false" TabIndex="2" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InspectionName" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rad_InspectionName" runat="server" Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="req_InspectionName" runat="server" ControlToValidate="rad_InspectionName" ErrorMessage="Please Enter Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InspectionDescription" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rad_Description" runat="server" Skin="WebBlue" MaxLength="200">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="req_InspectionDesc" runat="server" ControlToValidate="rad_Description" ErrorMessage="Please Enter Description" ValidationGroup="Controls">*</asp:RequiredFieldValidator>                                </td>

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
                                    <asp:Button ID="BTN_SAVE" runat="server" Text="Save" OnClick="btn_submit_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_submit_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vsInspections" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>