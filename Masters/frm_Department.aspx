<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Department.aspx.cs" Inherits="Masters_frm_Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadWindowManager ID="RWM_DEPARTMENT" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManagerProxy ID="RAM_DPT" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Department">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_DepartmentHeader" runat="server" Text="Department" Font-Bold="True"
                    meta:resourcekey="lbl_HolidayCalendarHeader"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_DPT_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Department" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_Department_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="DEPARTMENT_ID" UniqueName="DEPARTMENT_ID" HeaderText="ID"
                                                    meta:resourcekey="DEPARTMENT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="businessunit_code" UniqueName="businessunit_code"
                                                    AllowFiltering="true" HeaderText="Business Unit " meta:resourcekey="businessunit_code"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                   <telerik:GridBoundColumn DataField="DIRECTORATE_NAME" UniqueName="DIRECTORATE_NAME" HeaderText="Directorate ">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DEPARTMENT_NAME" UniqueName="DEPARTMENT_NAME"
                                                    AllowFiltering="true" HeaderText="Name " meta:resourcekey="DEPARTMENT_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DEPARTMENT_DESC" UniqueName="DEPARTMENT_DESC"
                                                    AllowFiltering="true" HeaderText="Description" meta:resourcekey="HOLMST_DESCRIPTION"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DEPARTMENT_ISACTIVE" AllowFiltering="true" UniqueName="DEPARTMENT_ISACTIVE" HeaderText="Status"></telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("DEPARTMENT_ID") %>'
                                                            OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourceKey="lnk_Add">Add</asp:LinkButton>
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
                                                        <asp:Button ID="btn_import" runat="server" Text="Import" OnClick="btn_import_Click" />
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
                    <telerik:RadPageView ID="Rp_Department_ViewDetails" runat="server">
                        <table align="center" width="30%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;">
                                </td>
                                <td align="center" style="font-weight: bold;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_depID" runat="server" meta:resourcekey="lbl_depID" Text="lbl_depID"
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"
                                        Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" AutoPostBack="true" TabIndex="1"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnit" runat="server" ControlToValidate="rcmb_BusinessUnit"
                                        ErrorMessage="Please Select Business Unit" InitialValue="Select" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_rcmb_BusinessUnit">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBusinessUnit_Directorate" runat="server" meta:resourcekey="lblBusinessUnit_Directorate"
                                        Text="Directorate"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_BusinessUnit_Directorate" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" TabIndex="2"
                                        MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit_Directorate" runat="server" ControlToValidate="rcmb_BusinessUnit_Directorate"
                                        ErrorMessage="Please Select Directorate" InitialValue="Select" ValidationGroup="Controls"
                                        meta:resourcekey="rfv_BusinessUnit_Directorate">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" Text="Code"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtbCode" runat="server" Skin="WebBlue" LabelCssClass="" MaxLength="25">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvRtbCode" runat="server" ControlToValidate="rtbCode"
                                        ErrorMessage="Please Specify Code" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_DPname" runat="server" meta:resourcekey="lbl_DPname" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_DName" runat="server" Skin="WebBlue" LabelCssClass="" TextMode="Multiline" TabIndex="3"
                                        MaxLength="100" style="resize:none">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_DName" runat="server" ControlToValidate="rtxt_DName"
                                        ErrorMessage="Please Enter Name" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_HCCode">*</asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_DName"
                                        ErrorMessage="Please Enter Only Alphabets" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="lbl_DPCode" runat="server" meta:resourcekey="lbl_DPCode" Text="Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_DCode" runat="server" Skin="WebBlue" MaxLength="100" TabIndex="4">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                    <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_DCode" runat="server" ControlToValidate="rtxt_DCode"
                                        ErrorMessage="Please Enter Code" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_HCCode">*</asp:RequiredFieldValidator>
                                  
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_DPDesc" runat="server" meta:resourcekey="lbl_DPDesc" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Desc" runat="server" Skin="WebBlue" MaxLength="100" TabIndex="5">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <%--  <asp:CheckBox ID="chk_Active" runat="server" Checked="true" />--%>
                                    <telerik:RadComboBox ID="rcmb_Status" runat="server" AutoPostBack="true" Skin="WebBlue" TabIndex="6"
                                        MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Edit" runat="server" Text="Update" Visible="False" ValidationGroup="Controls" TabIndex="7"
                                        meta:resourcekey="btn_Edit" OnClick="btn_Save_Click1" />
                                    <asp:Button ID="btn_Save" runat="server" Text="Save" Visible="False" ValidationGroup="Controls" TabIndex="7"
                                        meta:resourcekey="btn_Save" OnClick="btn_Save_Click1" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" meta:resourcekey="btn_Cancel" TabIndex="7"
                                        OnClick="btn_Cancel_Click1" />
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:ValidationSummary ID="vs_HolidayCalendar" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Controls" ShowSummary="False" meta:resourcekey="vs_HolidayCalendar" />
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
