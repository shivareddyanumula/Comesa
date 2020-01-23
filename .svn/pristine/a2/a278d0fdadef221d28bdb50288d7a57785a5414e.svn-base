<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Resignation.aspx.cs" Inherits="HR_frm_Resignation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:radajaxmanagerproxy id="RAM_Resignation" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_EmpResg">
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
    </telerik:radajaxmanagerproxy>
    <script language="javascript" type="text/javascript">
        function CheckedChange(objCheckBox) {
            var rdtp_RelievingDate = $find("<%= rdtp_RelievingDate.ClientID %>");
            var TerminationConfirmation;
            if (objCheckBox.checked == true) {

                TerminationConfirmation = confirm('Are you sure you want to Terminate the Employee Immediately?');
            }
            else {
                TerminationConfirmation = alert('Are u sure you want to RollBack the Employee Termination?');
            }

            if (TerminationConfirmation == true) {
                objCheckBox.checked = true;
                dateVar = new Date();
                rdtp_RelievingDate.set_selectedDate(dateVar);
                rdtp_RelievingDate.set_enabled(false);
                return true;
            }
            else {
                objCheckBox.checked = false;
                rdtp_RelievingDate.clear();
                rdtp_RelievingDate.set_enabled(true);
                return true;
            }
        }

        function chkUnchkResgnation(objCheckBox) {
            var rdtp_RelievingDate = $find("<%= rdtp_RelievingDate.ClientID %>");
            var ResgnWithoutApprvl;
            if (objCheckBox.checked == true) {

                ResgnWithoutApprvl = confirm('Are you sure you want to Resign the Employee Without Approval?');
            }
            if (ResgnWithoutApprvl == true) {
                objCheckBox.checked = true;
                return true;
            }
            else {
                objCheckBox.checked = false;
                return true;
            }
        }
    </script>

    <telerik:radwindow id="UserListDialog" runat="server" title="Add record" width="340"
        modal="true" height="160" behaviors="Close" left="580"
        visiblestatusbar="false" autosize="true" openerelementid="<%# hyp_Link.ClientID %>">
        <ContentTemplate>
            <br />
            <br />
            <table align="center">
                <tr>
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Name" ForeColor="Black" />
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadTextBox ID="txt_Asset_Type" runat="server" >
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Resignation Type"
                            ControlToValidate="txt_Asset_Type" Text="*" ValidationGroup="Controls1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Controls1" ShowMessageBox="true" ShowSummary="false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btn_Type_Save" runat="server" Text="Save" OnClick="btn_Type_Save_Click"
                            ValidationGroup="Controls1" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:radwindow>
    <table align="center" style="vertical-align: top;">
        <asp:HiddenField ID="hdncontrol" runat="server" />
        <tr>
            <td align="center">
                <asp:Label ID="lbl_EmpResg" runat="server" Font-Bold="True" meta:resourcekey="lbl_EmpResg"
                    Text=" Employee Resignation"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:radmultipage id="Rm_EmpResg_page" runat="server" height="635px" scrollbars="None"
                    selectedindex="0">
                    <telerik:RadPageView ID="Rp_EmpResg_ViewMain" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid  ID="Rg_EmpResg" runat="server" AutoGenerateColumns="False"
                                        Skin="WebBlue" GridLines="None" AllowPaging="true" OnNeedDataSource="Rg_EmpResg_NeedDataSource"
                                        AllowFilteringByColumn="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMPREG_ID" HeaderText="ID" meta:resourcekey="EMPREG_ID"
                                                    UniqueName="EMPREG_ID" Visible="False">
                                                    
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUNIT" HeaderStyle-HorizontalAlign="Center" HeaderText="Business Unit"
                                                    meta:resourcekey="BUNIT" UniqueName="BUNIT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEE" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Employee" meta:resourcekey="EMPLOYEE" UniqueName="EMPLOYEE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPREG_REGDATE" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Resigned Date" meta:resourcekey="EMPREG_REGDATE" UniqueName="EMPREG_REGDATE">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPREG_REASON" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Reason" meta:resourcekey="EMPREG_REASON" UniqueName="EMPREG_REASON">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPREG_STATUS" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderText="Status" meta:resourcekey="EMPREG_STATUS" UniqueName="EMPREG_STATUS">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE" HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center"/>
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMPREG_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--<telerik:GridTemplateColumn UniqueName="ColDelete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnk_Delete" runat="server" 
                                            CommandArgument='<%# Eval("EMPREG_ID") %>' meta:resourcekey="lnk_Delete" 
                                            OnCommand="lnk_Delete_Command">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                        <PagerStyle AlwaysVisible="true" />
                                        <FilterMenu Skin="WebBlue">
                                        </FilterMenu>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_EmpResg_ViewDetails" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3" style="font-weight: bold;">
                                    <asp:Label ID="lbl_EmpResgDetails" runat="server" meta:resourcekey="lbl_EmpResgDetails"
                                        Text="Details"></asp:Label>
                                </td>
                                <td align="center" style="font-weight: bold;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Empreg_BU" runat="server" meta:resourcekey="lbl_Empreg_BU" Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_EmpReg_BU" runat="server" MarkFirstMatch="true" Filter="Contains"
                                        Skin="WebBlue" AutoPostBack="True" OnSelectedIndexChanged="rcmb_EmpReg_BU_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmpReg_BU" runat="server" ErrorMessage="Please select Business Unit"
                                        ControlToValidate="rcmb_EmpReg_BU" ValidationGroup="Controls" InitialValue="Select" >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                              <tr>
                                <td>
                                    <asp:Label ID="lbl_Directorate" runat="server"  Text="Directorate"></asp:Label>                                   
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Directorate" AutoPostBack="true"  runat="server" Skin="WebBlue" MaxLength="40" Filter="Contains"
                                    EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                 <td>

                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select Directorate"
                                        ControlToValidate="rad_Directorate" ValidationGroup="Controls" InitialValue="Select" >*</asp:RequiredFieldValidator>

                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_Department" runat="server"  Text="Department"></asp:Label>                               
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_Department"  runat="server" Skin="WebBlue" MaxLength="40" AutoPostBack="True" Filter="Contains"
                                    EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rad_Department_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="rad_Department"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Department"  
                                         InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EmpregID" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_Empreg_EmpID" runat="server" meta:resourcekey="lbl_Empreg_EmpID"
                                        Text="Employee"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_EmployeeCode" runat="server"  MaxHeight="120px" 
                                        MarkFirstMatch="true"  AutoPostBack="true"
                                        Skin="WebBlue" Filter="Contains"
                                        onselectedindexchanged="rcmb_EmployeeCode_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeCode" runat="server" ErrorMessage="Please select Employee"
                                        ControlToValidate="rcmb_EmployeeCode" ValidationGroup="Controls" InitialValue="Select" >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ResgDate" runat="server" Text="Applied Date" meta:resourcekey="lbl_ResgDate"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadDatePicker  ID="rdtp_ResignationDate" runat="server"
                                        Skin="WebBlue">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_ResignationDate" runat="server" ErrorMessage="Please Select Applied Date"
                                        ControlToValidate="rdtp_ResignationDate" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_reason" runat="server" Text="Types of Resignation"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadComboBox  ID="rcmb_Reasonresg" runat="server" MarkFirstMatch="true"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:LinkButton ID="hyp_Link" runat="server" Text="Add New" Visible="false"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_Reasonresg" runat="server" ControlToValidate="rcmb_Reasonresg"
                                        ErrorMessage="Please Select Types of Resignation" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>                                              
                              <tr>
                                <td>
                                  
                                </td>
                                   <td>
                                    &nbsp;
                                </td>
                                <td colspan="3">
                                    <asp:CheckBox ID="chk_ImmediateTermination" onclick="return CheckedChange(this);"  runat="server" Text="Relieve Immediately"></asp:CheckBox>
                                    <asp:CheckBox ID="chkResignApproval" onclick="return chkUnchkResgnation(this);"  runat="server" Text="Resign Without Approval"></asp:CheckBox>
                                </td>                             
                             </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_RelievingDate" runat="server" Text="Relieving Request Date"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadDatePicker  ID="rdtp_RelievingDate" runat="server"
                                        Skin="WebBlue">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdtp_RelievingDate" runat="server" ErrorMessage="Please Select Relieving Request Date"
                                        ControlToValidate="rdtp_RelievingDate" ValidationGroup="Controls" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="rcv_rdtp_Resignation" runat="server" ControlToCompare="rdtp_ResignationDate"
                                        ControlToValidate="rdtp_RelievingDate" ErrorMessage="Resignation date cannot be A head of Reliving Date"
                                        Operator="GreaterThanEqual" ValidationGroup="Controls">*</asp:CompareValidator>                           
                               </td>                               
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="lbl_remarks" runat="server" Text="Reason"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <telerik:RadTextBox  ID="rtxt_Remarks" runat="server"
                                        AutoCompleteType="DisplayName" Skin="WebBlue" Height="51px"  MaxLength="200" TextMode="MultiLine"
                                        Width="143px" style="resize:none">
                                    </telerik:RadTextBox>
                                </td>
                                  <td>
                            <asp:RequiredFieldValidator ID="rfv_Reason" runat="server" ErrorMessage="Enter Reason for Resignation"
                            ControlToValidate="rtxt_Remarks" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                            </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btn_ExitInterview" runat="server" OnClick="btn_ExitInterview_Click"  Text="Show ExitInterview" ></asp:LinkButton>
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr> 
                            <div id="pnl_ExitInterview" runat="server" visible="false" >
                            <tr>
                                <td>
                                   
                                    <asp:Label ID="lbl_PrimaryReason" runat="server" Text="What are your primary reasons for leaving?"></asp:Label>
                                </td>
                                       
                                 <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox Skin="WebBlue" MaxLength="500" Width="200px"  ID="txt_PrimaryReason" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                 <td>
                                    <asp:Label ID="lbl_jobSatisfying" runat="server" Text="What did you find most <br/> satisfying about your job?"></asp:Label>
                                </td>
                                    
                                     
                                 <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox Skin="WebBlue" MaxLength="500" Width="200px"  ID="txt_jobSatisfying" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>          
                              <tr>
                                 <td>
                                    <asp:Label ID="lbl_jobfrustrating" runat="server" Text="What did you find most <br/> frustrating about your job?"></asp:Label>
                                </td>
                                 
                                 <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox Skin="WebBlue" MaxLength="500" Width="200px"  ID="txt_jobfrustrating" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
                                </td>
                                  <td></td>
                            </tr>           
                            <tr>
                                 <td>
                                    <asp:Label ID="lbl_ResignationPrevention" runat="server" Text="Is there anything the <br/> company could have <br/> done to prevent you from leaving?"></asp:Label>
                                </td>
                                     
                                 <td>
                                    :
                                </td>
                                <td >
                                    <asp:TextBox Skin="WebBlue" MaxLength="500" Width="200px"  ID="txt_Resignationprevention" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>             
                            <tr>
                                 <td>
                                    <asp:Label ID="lbl_jobsuggestion" runat="server" Text="What suggestions do <br/>you have in terms of<br/> responsibilities, growth and <br/>future prospects associated with <br/>your position in the organization?"></asp:Label>
                                </td>
                                  
                                 <td>
                                    :
                                </td>
                                <td>
                                    <asp:TextBox Skin="WebBlue" MaxLength="500" Width="200px"  ID="txt_jobsuggestion" runat="server" TextMode="MultiLine" style="resize:none"></asp:TextBox>
                                </td>
                                <td></td>
                              </tr> 
                                   
                                   </div>                                                                     
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_WHours" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
            </table>
                    </telerik:RadPageView>
                </telerik:radmultipage>
            </td>
        </tr>
    </table>
</asp:Content>
