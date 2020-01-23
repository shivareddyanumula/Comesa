<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Jobs.aspx.cs" Inherits="Masters_frm_Jobs" Culture="auto" meta:resourcekey="Page"
    UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cnt_Jobs" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Jobs" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_Jobs">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
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
            <telerik:AjaxSetting AjaxControlID="btn_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadWindowManager ID="RWM_JOBPOSTREPLY" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>

    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_JobsHeader" runat="server" Text="Job" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_JB_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" meta:resourcekey="Rm_JB_page">
                    <telerik:RadPageView ID="Rp_JB_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td align="center">

                                    <telerik:RadGrid ID="Rg_Jobs" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_Jobs_NeedDataSource" AllowPaging="True" AllowSorting="true"
                                        meta:resourcekey="Rg_Jobs" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="JOBS_ID" HeaderText="ID" meta:resourcekey="Jobs_ID"
                                                    UniqueName="JOBS_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBS_CODE" HeaderText="Jobs" meta:resourcekey="JOBS_CODE"
                                                    UniqueName="JOBS_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBS_DESC" HeaderText="Desc" meta:resourcekey="JOBS_DESC"
                                                    UniqueName="JOBS_DESC" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBS_STARTDATE" HeaderText="Job Start Date" meta:resourcekey="JOBS_STARTDATE"
                                                    UniqueName="JOBS_STARTDATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="JOBS_ENDDATE" HeaderText="Job End Date" meta:resourcekey="JOBS_ENDDATE"
                                                    UniqueName="JOBS_ENDDATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="Status"
                                                    UniqueName="HR_MASTER_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="JOBS_MINSAL" HeaderText="Min Salary" meta:resourcekey="JOBS_MINSAL"
                                                    UniqueName="JOBS_MINSAL" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JOBS_MAXSAL" HeaderText="Max Salary" meta:resourcekey="JOBS_MAXSAL"
                                                    UniqueName="JOBS_MAXSAL" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumn" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("JOBS_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <GroupingSettings CaseSensitive="false" />
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%-- <table align="center">
                                            <tr>
                                            <td colspan="7"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="7" align="center"> 
                                                    <asp:Label ID="lbl_Jobinfo" runat="server" Text="Import Job Details" 
                                                        style="font-weight: 700"></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_Job" runat="server" Text="Job Details"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>:</b>
                                                </td>
                                                <td>
                                                    <a href="Importsheets/JobTemplate.xlsx" id="Job">Download Job Template</a>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Import" runat="server" Text="Browse Your Data"></asp:Label>
                                                </td>
                                                <td><b>:</b></td>
                                                <td>
                                                    <asp:FileUpload ID="fupld_Job" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_Import" runat="server" Text="Import" 
                                                        onclick="btn_Import_Click" />
                                                </td>
                                            </tr>
                                            </table>--%>
                                </td>
                            </tr>

                        </table>

                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_JB_ViewDetails" runat="server">
                        <table align="center" width="38%">
                            <tr>
                                <td colspan="4" align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobsID" runat="server" Visible="False" meta:resourcekey="lbl_JobsID"></asp:Label>
                                    <asp:Label ID="lbl_JobsCode" runat="server" Text="Job Name" meta:resourcekey="lbl_JobsCode"></asp:Label>
                                </td>
                                <td>
                                    <strong>:</strong>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_JobsCode" runat="server" TabIndex="1"
                                        Skin="WebBlue" LabelCssClass="" meta:resourcekey="rtxt_JobsCode"
                                        MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_JobsCode1" runat="server" ControlToValidate="rtxt_JobsCode"
                                        ErrorMessage="Please Enter Job Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_JobsCode"
                                        ErrorMessage="Please Enter Valid Job Name" ValidationExpression="^[a-zA-Z0-9\s\\()/]+$"
                                        ValidationGroup="Controls" >*</asp:RegularExpressionValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobsDesc" runat="server" Text="Description" meta:resourcekey="lbl_JobsDesc"></asp:Label>
                                </td>
                                <td>
                                    <strong>:</strong>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_JobsDesc" runat="server" TabIndex="2"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <%-- <tr>
                                <td>
                                    <asp:Label ID="lbl_JobsGrade" runat="server" Text="Grade"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_JobsGrade" runat="server" MarkFirstMatch="true"
                                        Skin="WebBlue">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobsMinSalary" runat="server" meta:resourcekey="lbl_JobsMinSalary"
                                        Text="Min Salary"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="rntxt_JobsMinSalary" runat="server"
                                        Skin="WebBlue" meta:resourcekey="rntxt_JobsMinSalary" MaxLength="12" 
                                        MinValue="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_MinSalary" runat="server" Text="*" ControlToValidate="rntxt_JobsMinSalary"
                                        ValidationGroup="Controls" ErrorMessage="Please Enter Minimum Salary"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobsMaxSalary" runat="server" meta:resourcekey="lbl_JobsMaxSalary"
                                        Text="Max Salary"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox  ID="rntxt_JobsMaxSalary" runat="server"
                                        Skin="WebBlue" MaxLength="12" MinValue="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_MaxSalary" runat="server" Text="*" ControlToValidate="rntxt_JobsMaxSalary"
                                        ValidationGroup="Controls" ErrorMessage="Please Enter Maximum Salary"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToCompare="rntxt_JobsMinSalary" ControlToValidate="rntxt_JobsMaxSalary" 
                                        ErrorMessage="Max Salary Should be Greater Than Min Salary" 
                                        Operator="GreaterThan" Type="Integer" ValidationGroup="Controls">*</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobsSkills" runat="server" meta:resourcekey="lbl_JobsSkills" Text="Skills"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td rowspan="5">
                                    <input id="rcmb_JobsSkills_Value" runat="server" type="hidden"> </input>
                                    <telerik:RadListBox  ID="RadListBox1" runat="server" CheckBoxes="true"
                                        Height="120px" Width="200px">
                                    </telerik:RadListBox>
                                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                </td><td>
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
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobsLocations" runat="server" meta:resourcekey="lbl_JobsLocations"
                                        Text="Locations"></asp:Label></td>
                                <td>
                                    <strong>:</strong>
                                </td>
                                <td rowspan="5">
                                    <telerik:RadListBox ID="RadListBox2" runat="server" CheckBoxes="true" TabIndex="3"
                                        Height="100px" Width="200px">
                                    </telerik:RadListBox>
                                    <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label></td>
                                <%--<td>
                                    <asp:RequiredFieldValidator ID="rfv_RadListBox2" runat="server" ControlToValidate="RadListBox2"
                                        ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" meta:resourcekey="rfv_RadListBox2">*</asp:RequiredFieldValidator></td>--%>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>

                            <tr id="stdate" runat="server">
                                <td>
                                    <asp:Label ID="lbl_JobsStartDate" runat="server" meta:resourcekey="lbl_JobsStartDate"
                                        Text="Job Start Date"></asp:Label></td>
                                <td>
                                    <strong>:</strong>
                                </td>


                                <td>
                                    <telerik:RadDatePicker ID="rdtp_JobStartDate" runat="server" TabIndex="4"
                                        Skin="WebBlue" meta:resourcekey="rdtp_JobStartDate">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdtp_JobStartDate"
                                        ErrorMessage="Please Enter Job Start Date" ValidationGroup="Controls">*</asp:RequiredFieldValidator>

                                </td>

                            </tr>
                            <tr id="endate" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_JobsEndDate" runat="server" meta:resourcekey="lbl_JobsEndDate" Visible="false"
                                        Text="End Date"></asp:Label></td>
                                <td></td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_JobsEndDate" runat="server" Visible="false" TabIndex="5"
                                        meta:resourcekey="rdtp_JobsEndDate" Skin="WebBlue">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Status
                                </td>

                                <td><strong>:</strong>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcm_status" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="statuschanged_click" MaxHeight="200px" Filter="Contains"
                                        TabIndex="6">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_STATUS" runat="server" ControlToValidate="Rcm_status" InitialValue="Select"
                                        ErrorMessage="Please Enter Status" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>&nbsp;
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="7"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" TabIndex="7"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="8"
                                        Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="vs_Jobs" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="Controls" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>