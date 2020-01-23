<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_TrainingRequest.aspx.cs" Inherits="Training_frm_TrainingRequest" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <%-- <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="coledit">
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_edit" runat="server" Text="Edit" OnCommand="lnk_edit_command"
                                                                CommandArgument='<%# Eval("TR_ID") %>'></asp:LinkButton></div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Training_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Training_VIEWMAIN" runat="server" Selected="True">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <center>
                                        Training Process
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Tarining" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="false" Skin="WebBlue" PageSize="5"
                                        OnNeedDataSource="Rg_Trg_NeedDatasource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="TR_ID" UniqueName="TR_ID" HeaderText="TR_ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TR_TITLE" UniqueName="TR_TITLE" HeaderText="Title">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME" HeaderText="Course Name">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TR_LOCATION" UniqueName="TR_LOCATION" HeaderText="Location">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TR_DESCRIPTION" UniqueName="TR_DESCRIPTION" HeaderText="Description">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TR_STATUS" UniqueName="TR_STATUS" HeaderText="Status">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="coledit">
                                                    <ItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_edit" runat="server" Text="Edit" OnCommand="lnk_edit_command"
                                                                CommandArgument='<%# Eval("TR_ID") %>'></asp:LinkButton></div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_add" runat="server" Text="Add" OnCommand="lnk_Add_Command"></asp:LinkButton></div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    
                    <telerik:RadPageView ID="Rp_Training_VIEWDETAILS" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <telerik:RadTabStrip ID="rdtstrp" runat="server" SelectedIndex="0" ReorderTabsOnSelect="True"
                                        MultiPageID="Rm_Trainingrequest_PAGE1">
                                        <Tabs>
                                            <telerik:RadTab runat="server" Text="TrainingRequest" Selected="True" PageViewID="Rp_Trainingrequest_VIEWMAIN">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" Text="Training" PageViewID="Rp_Training" Enabled="false">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" Text="Resources" PageViewID="Rp_Resources" Enabled="false">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" Text="Trainee" PageViewID="Rp_Trainee" Enabled="false">
                                            </telerik:RadTab>
                                            <telerik:RadTab runat="server" Text="TrainingSchedule" PageViewID="rp_trainingcalender" Enabled="false">
                                            </telerik:RadTab>
                                        </Tabs>
                                    </telerik:RadTabStrip>
                                    <telerik:RadMultiPage ID="Rm_Trainingrequest_PAGE1" runat="server" 
                                        ScrollBars="Auto" SelectedIndex="0">
                                        <telerik:RadPageView ID="Rp_Trainingrequest_VIEWMAIN" runat="server">
                                            <table align="center">
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <center>
                                                            Training Request
                                                        </center>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Course"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_Course" AutoPostBack="true" runat="server" Style="margin-left: 0px"
                                                            Width="200px" onselectedindexchanged="rcmb_Course_SelectedIndexChanged" MarkFirstMatch="true"
                                                            Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="left">
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcmb_Course"
                                                            ErrorMessage="Please Select Course" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                
                                                 <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Course" runat="server" Text="Module"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_CourseType" runat="server" Style="margin-left: 0px"
                                                            Width="200px" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="left">
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_CourseType" runat="server" ControlToValidate="rcmb_CourseType"
                                                            ErrorMessage="Please Select Module" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Title" runat="server" Text="Topic"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadTextBox ID="rtxt_title" runat="server">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_title" runat="server" ControlToValidate="rtxt_title"
                                                            ErrorMessage="Please Enter Topic Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_Tr_Id" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Location" runat="server" Text="Location"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_Location" runat="server" LabelCssClass="" MaxLength="40">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_Location" runat="server" ControlToValidate="rtxt_Location"
                                                            ErrorMessage="Location Cannot Be Empty" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lbl_Description" runat="server" Text="Description"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_Description" runat="server" Height="70px" TextMode="MultiLine"
                                                            Width="80px">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td rowspan="3">
                                                        &#160;&#160;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lbl_Status" runat="server" CssClass="LABELSS" Text="Status"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_Status" runat="server" Width="200px" MarkFirstMatch="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem Value="0" Text="Pending" runat="server" />
                                                                <telerik:RadComboBoxItem Value="1" Text="Approved" runat="server" />
                                                                <telerik:RadComboBoxItem Value="2" Text="Rejected" runat="server" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="left">
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcm_status" runat="server" ControlToValidate="rcmb_Status"
                                                            ErrorMessage="Please Select status" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Trainer" runat="server" Text="Trainer"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcmb_Trainer" runat="server" EnableEmbeddedSkins="false"
                                                            Width="200px">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td align="left">
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcmb_Trainer" runat="server" ControlToValidate="rcmb_Trainer"
                                                            ErrorMessage="Please Select Trainer" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Submit" ValidationGroup="Controls" />
                                                        <asp:Button ID="btn_updatetrgrequest" runat="server" Text="Update" ValidationGroup="Controls"
                                                            OnClick="btn_updatetrgrequest_Click" />
                                                        <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="Cancel" /><asp:ValidationSummary
                                                            ID="vs_Trainer" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="Rp_Training" runat="server" Selected="True">
                                            <table align="center">
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <center>
                                                            Training
                                                        </center>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Training_id" runat="server" Visible="False"></asp:Label><asp:Label
                                                            ID="lbl_TrainingType" runat="server" Text="Modes Of Training :"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <telerik:RadComboBox ID="rcmb_TRGType" runat="server" AutoPostBack="True" Width="200px"
                                                            OnSelectedIndexChanged="rcmb_TRGType_SelectedIndexChanged1" MarkFirstMatch="true">
                                                            <Items>
                                                                <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                                                                <telerik:RadComboBoxItem runat="server" Text="Internal Trainer" Value="1" />
                                                                <telerik:RadComboBoxItem runat="server" Text="External Trainer" Value="2" />
                                                                <telerik:RadComboBoxItem runat="server" Text="External Training" Value="3" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtrgtype" runat="server" ControlToValidate="rcmb_TRGType"
                                                            ErrorMessage="Please Select Training Type" InitialValue="Select" ValidationGroup="Controlstrgtype">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_traing_TRG" runat="server" Text="Training Module :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcm_trg_Traingname" runat="server" AutoPostBack="false"
                                                                Width="200px" MarkFirstMatch="true" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rcm_trg_Traingname" runat="server" ControlToValidate="rcm_trg_Traingname"
                                                                ErrorMessage="Please Select TrainingModule" InitialValue="Select" ValidationGroup="Controlstrginternal">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <td>
                                                        <%-- <asp:ValidationSummary
                                                        ID="vs_trg_type" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controlstrgtype" />--%>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="panel_internal" runat="server">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_BusinessUnitName" runat="server" Text="BusinessUnit :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                                                Width="200px" OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged" Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" runat="server" ControlToValidate="rcmb_BusinessUnitType"
                                                                ErrorMessage="Please Select BusinessUnit" InitialValue="Select" ValidationGroup="Controlstrginternal">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_Employee" runat="server" Text="Trainer :"></asp:Label>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
                                                            &#160;&#160;&#160;
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" AutoPostBack="false" Width="200px" MarkFirstMatch="true"
                                                                 Filter="Contains">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" runat="server" ControlToValidate="rcmb_EmployeeType"
                                                                ErrorMessage="Please Select Employee" InitialValue="Select" ValidationGroup="Controlstrginternal">*</asp:RequiredFieldValidator>
                                                            <asp:Label ID="lbl_trg_internal_trainer" Visible="false" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btn_save_trg_internal" runat="server" Text="Submit" ValidationGroup="Controlstrginternal"
                                                                OnClick="btn_save_trg_internal_click" /><asp:Button ID="btn_update_internal" runat="server"
                                                                    Text="Update" Visible="false" OnClick="btn_update_internal_click" ValidationGroup="Controlstrginternal" /><asp:Button
                                                                        ID="btn_cancel_internal" runat="server" Text="Cancel" OnClick="btn_cancel_internal_click" />
                                                            <asp:ValidationSummary ID="vs_trg_internal" runat="server" ShowMessageBox="True"
                                                                ShowSummary="False" ValidationGroup="Controlstrginternal" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                            </table>
                                            <table align="center">
                                                <asp:Panel ID="panel_external" runat="server">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="LBL_ORGANISATION" runat="server" Text="Organisation :"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_Organisation" runat="server" LabelCssClass="" MaxLength="40">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td>
                                                            &#160;&#160;
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rtxtorganisation" runat="server" ControlToValidate="rtxt_Organisation"
                                                                ErrorMessage="Organisation Cannot Be Empty" ValidationGroup="Controlstrgexte">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_Employees" runat="server" Text="Trainer :"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_Employee" runat="server" LabelCssClass="" MaxLength="40">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td>
                                                            &#160;&#160;
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Employee" runat="server" ControlToValidate="rtxt_Employee"
                                                                ErrorMessage="Employee Cannot Be Empty" ValidationGroup="Controlstrgexte">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_Designation" runat="server" Text="Designation :"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_Designation" runat="server" LabelCssClass="" MaxLength="40">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td>
                                                            &#160;&#160;
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rtxt_Designation" runat="server" ControlToValidate="rtxt_Designation"
                                                                ErrorMessage="Designation Cannot Be Empty" ValidationGroup="Controlstrgexte">*</asp:RequiredFieldValidator>
                                                            <asp:Label ID="lbl_trgexte" Visible="false" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btn_save_trgexte" runat="server" Text="Submit" ValidationGroup="Controlstrgexte"
                                                                OnClick="btn_save_trgexte_click" /><asp:Button ID="btn_update_exter" runat="server"
                                                                    Text="Update" ValidationGroup="Controlstrgexte" Visible="false" OnClick="btn_update_exter_click" /><asp:Button
                                                                        ID="btn_cancel_trgexte" runat="server" Text="Cancel" OnClick="btn_cancel_trgexte_click" />
                                                            <asp:ValidationSummary ID="vs_trg_exte" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                ValidationGroup="Controlstrgexte" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                            </table>
                                            <table align="center">
                                                <asp:Panel ID="pnl_ext1" runat="server">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="LBL_TRGINSTITUTE" runat="server" Text="Training Institute:"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_TrainingInstitute" runat="server" LabelCssClass="" MaxLength="40">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td>
                                                            &#160;&#160;
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_Traininginstitute" runat="server" ControlToValidate="rtxt_TrainingInstitute"
                                                                ErrorMessage="TrainingInstitute Cannot Be Empty" ValidationGroup="Controlstrg">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_address" runat="server" Text="Address :"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_address" runat="server" LabelCssClass="" MaxLength="40"
                                                                TextMode="MultiLine">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td>
                                                            &#160;&#160;
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_addtress" runat="server" ControlToValidate="rtxt_address"
                                                                ErrorMessage="Address Cannot Be Empty" ValidationGroup="Controlstrg">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_PHONENO" runat="server" Text="Phone No :"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <telerik:RadMaskedTextBox ID="rmtxt_phoneno" runat="server" DisplayMask="###-###-####"
                                                                Skin="WebBlue" Mask="(###) ###-####" TextWithLiterals="() -">
                                                            </telerik:RadMaskedTextBox>
                                                        </td>
                                                        <td>
                                                            &#160;&#160;
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_phoneno" runat="server" ControlToValidate="rmtxt_phoneno"
                                                                ErrorMessage="Phone Number Cannot Be Empty" ValidationGroup="Controlstrg">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_ContactPerson" runat="server" Text="Contact Person :"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_contactperson" runat="server" LabelCssClass="" MaxLength="40">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td>
                                                            &#160;&#160;
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_contactperson" runat="server" ControlToValidate="rtxt_contactperson"
                                                                ErrorMessage="Contact Person Cannot Be Empty" ValidationGroup="Controlstrg">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_faculty" runat="server" Text="Trainer :"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtxt_Faculty" runat="server" LabelCssClass="" MaxLength="40">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                        <td>
                                                            &#160;&#160;
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfv_rtxt_faculty" runat="server" ControlToValidate="rtxt_Faculty"
                                                                ErrorMessage="Faculty Cannot Be Empty" ValidationGroup="Controlstrg">*</asp:RequiredFieldValidator>
                                                            <asp:Label ID="lbl_save_trg" Visible="false" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="4">
                                                            <asp:Button ID="btn_save_trg" runat="server" Text="Submit" ValidationGroup="Controlstrg"
                                                                OnClick="btn_save_trg_click" /><asp:Button ID="btn_update_extertrg" runat="server"
                                                                    Text="Update" Visible="false" ValidationGroup="Controlstrg" OnClick="btn_update_extertrg_click" /><asp:Button
                                                                        ID="btn_cancel_trg" runat="server" Text="Cancel" OnClick="btn_cancel_trg_click" /><asp:ValidationSummary
                                                                            ID="vs_trg" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controlstrg" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="Rp_Resources" runat="server" Selected="True">
                                            <table align="center">
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <center>
                                                            Resources
                                                        </center>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_trg_resource" runat="server" Text="Training Module"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcm_resource_trg" runat="server" AutoPostBack="True" Width="200px"
                                                            OnSelectedIndexChanged="rcm_resource_trg_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_resource_trg" runat="server" ControlToValidate="rcm_resource_trg"
                                                            ErrorMessage="Training Module Cannot Be Empty" ValidationGroup="Controlsresource" InitialValue="Select">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_Resource" runat="server" Text="Resource"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcm_resource" runat="server" AutoPostBack="false" Width="200px" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_resource" runat="server" ControlToValidate="rcm_resource"
                                                            ErrorMessage="Resource  Cannot Be Empty" ValidationGroup="Controlsresource"
                                                            InitialValue="Select">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_resourcename" runat="server" Text="Resource Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_Resourcename" runat="server" MaxLength="40">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_resourcename" runat="server" ControlToValidate="rtxt_Resourcename"
                                                            ErrorMessage="Resource Name Cannot Be Empty" ValidationGroup="Controlsresource">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LBL_RESOURCEDESCRIP" runat="server" Text="Resource Description"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="rtxt_ResoDesc" runat="server" LabelCssClass="" MaxLength="40"
                                                            TextMode="MultiLine">
                                                        </telerik:RadTextBox>
                                                    </td>
                                                    <td>
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_ResoDesc" runat="server" ControlToValidate="rtxt_ResoDesc"
                                                            ErrorMessage="Resource Description Cannot Be Empty" ValidationGroup="Controlsresource">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_estimatedqty" runat="server" Text="Resource Quantity"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="RNT_ResourceQty" runat="server" MaxLength="2" NumberFormat-DecimalDigits="0" />
                                                    </td>
                                                    <td>
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="Rfv_Resourceqty" runat="server" ControlToValidate="RNT_ResourceQty"
                                                            ErrorMessage="Resource Quantity Cannot Be Empty" ValidationGroup="Controlsresource">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LBL_ESTIMATEDBUDGET" runat="server" Text="EstimatedBudget"></asp:Label>
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rnt_estbudget" runat="server">
                                                            <NumberFormat DecimalDigits="0" GroupSeparator="." />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        &#160;&#160;
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rnt_estbudget" runat="server" ControlToValidate="rnt_estbudget"
                                                            ErrorMessage="EstimatedBudget Cannot Be Empty" ValidationGroup="Controlsresource">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btn_Add_resource" runat="server" OnClick="btn_Add_resource_Click"
                                                            Text="Add" ValidationGroup="Controlsresource" />
                                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:Button ID="btn_Update_resource" runat="server" OnClick="btn_Update_resource_Click"
                                                            Text="Update" ValidationGroup="Controlsresource" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <telerik:RadGrid ID="Rg_Resource_Grid" runat="server" AutoGenerateColumns="False"
                                                            GridLines="None" AllowPaging="True" Skin="WebBlue" PageSize="5">
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <%-- <telerik:GridBoundColumn DataField="S_No" HeaderText="Id" Visible="true" UniqueName="S_No">
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn DataField="S_No" HeaderText="Id" Visible="false" UniqueName="S_No">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_res_sno" runat="server" Text='<%# Eval("S_No") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <%--  <telerik:GridBoundColumn DataField="Resource_Type" HeaderText="Resource Type" UniqueName="Resource_Type">
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn DataField="RESOURCE_TYPEID" HeaderText="Resource Type"
                                                                        Visible="false" UniqueName="RESOURCE_TYPEID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_res_typee" runat="server" Text='<%# Eval("RESOURCE_TYPEID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="Resource_Name" HeaderText="Resource Name"
                                                                        Visible="true" UniqueName="Resource_Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_res_namee" runat="server" Text='<%# Eval("Resource_Name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <%--  <telerik:GridBoundColumn DataField="Resource_Name" HeaderText="Resource Name" UniqueName="Resource_Name">
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn DataField="Resource_Desc" HeaderText="Resource Description"
                                                                        Visible="true" UniqueName="Resource_Desc">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_res_descee" runat="server" Text='<%# Eval("Resource_Desc") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <%-- <telerik:GridBoundColumn DataField="Resource_Desc" HeaderText="Resource Description"
                                                                        UniqueName="Resource_Desc">
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn DataField="RESOUCE_QTY" HeaderText="Resource Quantity"
                                                                        Visible="true" UniqueName="RESOUCE_QTY">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_res_Quantityee" runat="server" Text='<%# Eval("RESOUCE_QTY") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <%--<telerik:GridBoundColumn DataField="Resource_Quanty" HeaderText="Resource Quantity"
                                                                        UniqueName="Resource_Quanty">
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn DataField="RESOURCE_ESTIMATEDBUDGET" HeaderText="Estimated Budget"
                                                                        Visible="true" UniqueName="RESOURCE_ESTIMATEDBUDGET">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_res_EstBudget" runat="server" Text='<%# Eval("RESOURCE_ESTIMATEDBUDGET") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <%--  <telerik:GridBoundColumn DataField="Resource_EstimatedBudget" HeaderText="Estimated Budget"
                                                                        UniqueName="Resource_EstimatedBudget">
                                                                    </telerik:GridBoundColumn>--%>
                                                                    <telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumnResource2" UniqueName="TemplateColumn">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_edit_res_command" CommandArgument='<%# Eval("S_No") %>'>Edit</asp:LinkButton></ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="center" colspan="4">
                                                        <asp:Button ID="btn_save_resource" runat="server" OnClick="btn_save_resource_Click"
                                                            Text="Submit" />
                                                        <asp:Button ID="btn_update_resou" runat="server" OnClick="btn_update_resou_click"
                                                            Text="Update" Visible="false" />
                                                        <asp:Button ID="btn_cancel_resource" runat="server" OnClick="btn_cancel_resource_Click"
                                                            Text="Cancel" />
                                                        <asp:ValidationSummary ID="vs_resource" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                            ValidationGroup="Controlsresource" />
                                                        <td align="left">
                                                            <asp:Label ID="lbl_res_serail" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="Rp_Trainee" runat="server" Selected="True">
                                            <table align="center">
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <center>
                                                            Trainee
                                                        </center>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_bu_id" runat="server" Text="BusinessUnit :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="rcm_bu_trainee" runat="server" AutoPostBack="true" Width="200px" MarkFirstMatch="true"
                                                            OnSelectedIndexChanged="rcm_bu_trainee_SelectedIndexChanged" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_rcm_bu_trainee" runat="server" ControlToValidate="rcm_bu_trainee"
                                                            ErrorMessage="Please Select BusinessUnit" InitialValue="Select" ValidationGroup="Controlstraineelist">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_trgreq" runat="server" Text="Training Module :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="Rcmb_training" runat="server" AutoPostBack="True" Width="200px" Filter="Contains"
                                                            OnSelectedIndexChanged="Rcmb_training_SelectedIndexChanged" MarkFirstMatch="true">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <telerik:RadListBox runat="server" ID="rdlist_trainee" Height="200px" Width="200px"
                                                                        AllowTransfer="true" EnableDragAndDrop="true" SelectionMode="Multiple" TransferToID="RadListBoxDestination">
                                                                    </telerik:RadListBox>
                                                                    <telerik:RadListBox runat="server" ID="RadListBoxDestination" Height="200px" Width="200px"
                                                                        EmptyMessage="No Items Added" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <%-- <asp:CustomValidator ID="cv_rdlist" runat="server"  
                                        ErrorMessage="You Must Choose At Lease 1" ClientValidationFunction="validateListbox2">  
                                                    </asp:CustomValidator> --%>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_rlistbox" ErrorMessage="Please select item!"
                                                                        ControlToValidate="RadListBoxDestination" ValidationGroup="Controlstraineelist"
                                                                        InitialValue="Select" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Button ID="btn_save_traineelist" runat="server" Text="Submit" ValidationGroup="Controlstraineelist"
                                                            OnClick="btn_save_traineelist_Click" /><asp:Button ID="btn_updatetrainee" runat="server"
                                                                Text="Update" Visible="false" OnClick="btn_updatetrainee_click" ValidationGroup="Controlstraineelist" /><asp:Button
                                                                    ID="btn_cancel_traineelist" runat="server" Text="Cancel" OnClick="btn_cancel_traineelist_Click1" /><asp:ValidationSummary
                                                                        ID="vs_traineelist" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                        ValidationGroup="Controlstraineelist" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="rp_trainingcalender" runat="server" Selected="True">
                                            &nbsp;
                                            <table>
                                                <tr align="center">
                                                    <td align="center" colspan="3">
                                                        <asp:Label ID="lbl_trg_calender" runat="server" Text="Training Module :"></asp:Label>
                                                        <telerik:RadComboBox ID="rcm_trg_calender" runat="server" Width="200px" MarkFirstMatch="true" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="RFV_TRG_CALENDER" runat="server" ControlToValidate="rcm_trg_calender"
                                                            InitialValue="Select" ErrorMessage="Please Select Training Module" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 10%">
                                                        &nbsp;
                                                    </td>
                                                    <td style="width: 100%">
                                                        <asp:Panel ID="Appoint_panel" runat="server" GroupingText="Training Time">
                                                            <table class="style1">
                                                                <tr>
                                                                    <td style="width: 22%">
                                                                        <asp:Label ID="lbl_StartDate" runat="server" Text="Start &nbsp;Date"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 2%">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td style="width: 22%">
                                                                        <telerik:RadDatePicker ID="rdtp_strtdate" runat="server" DateInput-EmptyMessage="Start Date"
                                                                            AutoPostBack="false">
                                                                        </telerik:RadDatePicker>
                                                                        <asp:RequiredFieldValidator ID="rfv_strtdate" runat="server" ControlToValidate="rdtp_strtdate"
                                                                            ErrorMessage="Please Enter Start Date" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td style="width: 5%">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="style2">
                                                                        <asp:Label ID="lbl_Sessions" runat="server" Text="Sessions"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 2%">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td style="width: 22%">
                                                                        <telerik:RadTextBox ID="rtxt_sessions" runat="server" Width="50px" MaxLength="2">
                                                                        </telerik:RadTextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv_rtxt_sessions" runat="server" ControlToValidate="rtxt_sessions"
                                                                            ErrorMessage="Please Enter Sessions" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>
                                                                        <asp:RangeValidator ID="rv_rtxt_sessions" runat="server" ControlToValidate="rtxt_sessions" 
                                                                        ErrorMessage="Enter Only Numeric Sessions Values" ValidationGroup="Controlscalender" Type="Integer" MinimumValue="1" MaximumValue="500">*</asp:RangeValidator>
                                                                    </td>
                                                                    <%-- <td class="style2">
                                                                        &nbsp;
                                                                        <asp:Label ID="lbl_EndDate" runat="server" Text="End  &nbsp;Date"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 2%">
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td style="width: 22%">
                                                                        <telerik:RadDatePicker ID="rdtp_enddate" runat="server" DateInput-EmptyMessage="End Date"
                                                                            AutoPostBack="true" EnableEmbeddedSkins="false" OnSelectedDateChanged="rdtp_enddate_SelectedDateChanged">
                                                                        </telerik:RadDatePicker>
                                                                        <asp:RequiredFieldValidator ID="rfv_enddate" runat="server" ControlToValidate="rdtp_enddate"
                                                                            ErrorMessage="Please Enter End Date" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>
                                                                    </td>--%>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lbl_strttime" runat="server" Text="Start  &nbsp;Time"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTimePicker ID="rtp_starttime" runat="server" DateInput-EmptyMessage="Start Time"
                                                                            AutoPostBack="true" OnSelectedDateChanged="rtp_starttime_SelectedDateChanged">
                                                                        </telerik:RadTimePicker>
                                                                        <asp:RequiredFieldValidator ID="rfv_strttime" runat="server" ControlToValidate="rtp_starttime"
                                                                            ErrorMessage="Please Enter Start Time" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="style2">
                                                                        <asp:Label ID="lbl_endtime" runat="server" Text="End  &nbsp;Time"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTimePicker ID="rtp_endtime" runat="server" AutoPostBack="True" AutoPostBackControl="TimeView"
                                                                            DateInput-EmptyMessage="End Time" OnSelectedDateChanged="rtp_endtime_SelectedDateChanged">
                                                                        </telerik:RadTimePicker>
                                                                        <asp:RequiredFieldValidator ID="rfv_endtime" runat="server" ControlToValidate="rtp_endtime"
                                                                            ErrorMessage="Please Enter End Time" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <%-- <td>
                                                                        <asp:Label ID="lbl_duration" runat="server" Text="Duration &nbsp; In(Minutes)"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>:</b>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadTextBox ID="rtxt_duration" runat="server" EnableEmbeddedSkins="false" ReadOnly="true">
                                                                        </telerik:RadTextBox>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rtp_endtime"
                                                                                ErrorMessage="Please Enter Duration" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>
                                                                        </td>--%>
                                                    
                                                       </tr>
                                                       </table>
                                                       </asp:Panel>
                                                        <asp:Panel ID="panel_Recuer_id" runat="server" GroupingText="Recurrence Pattern">
                    <table align="center">
                        <tr>
                            <td style="width: 20%" valign="top">
                                <asp:RadioButtonList ID="rbtnlist_recuerence_id" runat="server" Width="145px" OnSelectedIndexChanged="rbtnlist_recuerence_id_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="0" Text="D">Daily</asp:ListItem>
                                    <asp:ListItem Value="1" Text="W">Weekly</asp:ListItem>
                                    <asp:ListItem Value="2" Text="M">Monthly</asp:ListItem>
                                    <asp:ListItem Value="3" Text="Y">Yearly</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RFV_rbtnlist_recuerence_id" runat="server" ControlToValidate="rbtnlist_recuerence_id"
                                    ErrorMessage="Please Select Recurrence Pattern" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 2%">
                                &nbsp;
                            </td>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnl_daily" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rd_every_id_daily" runat="server" Text="Every" GroupName="daily" />
                                                            &nbsp;
                                                            <telerik:RadNumericTextBox ID="txt_daily_id" runat="server" Value="1" MaxLength="2"
                                                                Width="30 px" NumberFormat-DecimalDigits="0">
                                                            </telerik:RadNumericTextBox>
                                                            &nbsp;<asp:Label ID="lbl_daily_id" runat="server" Text="Day(s)"></asp:Label>
                                                            <%-- <asp:RequiredFieldValidator ID="rfv_dail_ever" runat="server" ControlToValidate="rd_every_id_daily"
                                                                            ErrorMessage="Please Select" ValidationGroup="Controlscalender">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rd_daily_weekday_id" runat="server" Text="EveryWeek Day" GroupName="daily" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnl_weekly" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_weekly_id" runat="server" Text="Recur Every"></asp:Label>
                                                            &nbsp;<telerik:RadNumericTextBox ID="txt_weekly_id" runat="server" MaxLength="2"
                                                                NumberFormat-DecimalDigits="0" Width="30px" Value="1">
                                                            </telerik:RadNumericTextBox>
                                                            &nbsp;<asp:Label ID="lbl_weekly_id_week" runat="server" Text="Week(s) On"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chk_monday" runat="server" Text="Monday" />
                                                            &nbsp;<asp:CheckBox ID="chk_Tuesday" runat="server" Text="Tuesday" />
                                                            &nbsp;<asp:CheckBox ID="chk_Wednesday" runat="server" Text="Wednesday" />
                                                            <asp:CheckBox ID="chk_Thursday" runat="server" Text="Thursday" />
                                                            <asp:CheckBox ID="chk_Friday" runat="server" Text="Friday" />
                                                            <asp:CheckBox ID="chk_Saturday" runat="server" Text="Saturday" />
                                                            &nbsp;<asp:CheckBox ID="chk_Sunday" runat="server" Text="Sunday" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnl_monthly" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rd_monthly_id" runat="server" Text="Day" GroupName="monthly" />
                                                            &nbsp;<asp:TextBox ID="txt_monthly_id" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                                                            &nbsp;Of Every
                                                            <telerik:RadNumericTextBox ID="txt_monthly_id1" MaxLength="2" runat="server" NumberFormat-DecimalDigits="0"
                                                                Width="30px" Value="1">
                                                            </telerik:RadNumericTextBox>
                                                            &nbsp;month(s)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rd_monthly_id5" runat="server" Text="The" GroupName="monthly" />
                                                            &nbsp;<asp:DropDownList ID="ddl_monthly_id" runat="server" Width="50px">
                                                                <asp:ListItem Value="0" Text="First"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Second"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Third"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Fourth"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="Last"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:DropDownList ID="ddl_monthly_id2" runat="server" Width="100px">
                                                                <asp:ListItem Value="0" Text="Sunday"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Monday"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Tuesday"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Wednesday"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="Thrusday"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="Friday"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Saturday"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;Of Every<asp:TextBox ID="txt_monthly_id3" runat="server" Width="30px" Text="1"
                                                                MaxLength="2"></asp:TextBox>
                                                            Month(s)&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnl_yearly" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rd_yearly_id" runat="server" Text="Every" GroupName="yearly" />
                                                            &nbsp;<asp:DropDownList ID="ddl_yearly_id2" runat="server" Width="80px">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                                                <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                                                <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                                                <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                                                <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                                                <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:TextBox ID="txt_yearly_id" runat="server" MaxLength="2" Width="30px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rd_yearly_id3" runat="server" Text="The" GroupName="yearly" />
                                                            &nbsp;<asp:DropDownList ID="ddl_yearly_id3" runat="server" Width="80px">
                                                                <asp:ListItem Value="0" Text="First"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Second"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Third"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Fourth"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="Last"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddl_yearly_id" runat="server" Width="80px">
                                                                <asp:ListItem Value="0" Text="Sunday"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Monday"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Tuesday"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Wednesday"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="Thrusday"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="Friday"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Saturday"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            Of
                                                            <asp:DropDownList ID="ddl_yearly_id4" runat="server" Width="80px">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                                                <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                                                <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                                                <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                                                <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                                                <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <table align="center">
                <tr>
                 <td align="center" colspan="4">
                <asp:Button ID="btn_save_calender" runat="server" Text="Submit" ValidationGroup="Controlscalender"
                    OnClick="btn_save_calender_Click1" />
                <asp:Button ID="btn_update_calender" runat="server" Text="Update" ValidationGroup="Controlscalender"
                    OnClick="btn_update_calender_Click1" />
                <asp:Button ID="btn_cancel_calender" runat="server" Text="Cancel" OnClick="btn_cancel_calender_Click" /><asp:ValidationSummary
                    ID="vs_calender" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controlscalender" />
            </td>
            </tr>
            </table>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style2">
                                                        <%-- <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                                            ShowSummary="False" ValidationGroup="Controls" />--%>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            </telerik:RadPageView>
                                     </telerik:RadMultiPage>
                                   <%-- </asp:Panel>--%>
                                </td>
                                <%--<td style="width: 10%">
                                    &nbsp;
                                </td>--%>
                            </tr>
                            <tr>
            <td>
                &nbsp;
            </td>
            <td>
               
            </td>
        </tr>
                            <tr>
           
        </tr>
         <%--                   <tr>
            <td>
                &nbsp;
            </td>
        </tr>
                            <tr>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
                            <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
                            <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
                            <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
                            <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>--%>
                          
                        </table>
                     </telerik:RadPageView>
                </telerik:RadMultiPage>
            
           </td>
        </tr>
    </table>
  <%--  &nbsp; </telerik:RadPageView> </telerik:RadMultiPage> </td> </tr> </table> </telerik:RadPageView>
    </telerik:RadMultiPage> </td> </tr> </table>--%>
</asp:Content>
