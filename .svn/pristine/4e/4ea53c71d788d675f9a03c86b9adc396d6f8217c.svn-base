<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="RecordIncident.aspx.cs" Inherits="Grievances_RecordIncident" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<asp:Content ID="cnt_RecordIncident" ContentPlaceHolderID="cphDefault" runat="Server">
    
    <script type="text/javascript">
        function fnJSOnFormSubmit(sender, group) {
            var isGrpOneValid = Page_ClientValidate(group);
            var i;
            for (i = 0; i < Page_Validators.length; i++) {
                ValidatorValidate(Page_Validators[i]); //this forces validation in all groups
            }
            for (i = 0; i < Page_ValidationSummaries.length; i++) {
                summary = Page_ValidationSummaries[i];
                if (isGrpOneValid) {
                    sender.disabled = "disabled";
                    return true;
                }

                if (fnJSDisplaySummary(summary.validationGroup)) {
                    summary.style.display = "";
                }
            }

        }

        function OnClientItemsRequesting(sender, eventArgs) {
            var context = eventArgs.get_context();
            context["FilterString"] = eventArgs.get_text();
        }
        //function ShowPop(empid) {
        //    debugger
        //    var win = window.radopen('../Grievances/frm_lettermail.aspx?empid=' + empid, "RadWindow1");
        //    win.center();
        //    win.set_modal(true);
        //    win.set_title("Terminated Employees");
        //   // win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        //}
        function ShowPop(empid, geiv, type) {
            debugger
            var win = window.radopen('../Grievances/frm_lettermail.aspx?empid=' + empid + '&grevid=' + geiv + '&type=' + type, "RadWindow1");
            win.center();
            win.set_title("Suspend/Terminated Employee Notification");
            win.set_modal(true);
        }

        function UserDeleteConfirmation() {
            return confirm("Are you sure you want to delete this user?");
        }


       

    </script>
    <telerik:RadAjaxManagerProxy ID="RAM_RecordIncident" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_RecordIncident">
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
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>



    <table align="center"  width="1100px">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_RecordIncidentHeader" runat="server" Text="Record Complaint" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="1100px" Height="750px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="70%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_RecordIncident" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_RecordIncident_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_ID" UniqueName="GRIEVANCE_ID" HeaderText="ID"
                                                            meta:resourcekey="GRIEVANCE_ID" Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_ORGANISATION_ID" HeaderText="GRIEVANCE_ORGANISATION_ID" meta:resourcekey="GRIEVANCE_ORGANISATION_ID"
                                                            UniqueName="GRIEVANCE_ORGANISATION_ID" Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_INCIDENTID" UniqueName="GRIEVANCE_INCIDENTID" HeaderText="Complaint ID"
                                                            meta:resourcekey="GRIEVANCE_INCIDENTID">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_REPORTEDBY" UniqueName="GRIEVANCE_REPORTEDBY" HeaderText="GRIEVANCE_REPORTEDBY"
                                                            meta:resourcekey="GRIEVANCE_REPORTEDBY" Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_REPORTEDBYNAME" UniqueName="GRIEVANCE_REPORTEDBYNAME" HeaderText="Complaint By"
                                                            meta:resourcekey="GRIEVANCE_REPORTEDBYNAME">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_REPORTEDON" HeaderText="GRIEVANCE_REPORTEDON" meta:resourcekey="GRIEVANCE_REPORTEDON"
                                                            UniqueName="GRIEVANCE_REPORTEDON" Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_REPORTEDONNAME" HeaderText="Complaint On" meta:resourcekey="GRIEVANCE_REPORTEDONNAME"
                                                            UniqueName="GRIEVANCE_REPORTEDONNAME">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_INCIDENT" UniqueName="GRIEVANCE_INCIDENT" HeaderText="Complaint"
                                                            meta:resourcekey="GRIEVANCE_INCIDENT">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_INCIDENTTYPE_ID" UniqueName="GRIEVANCE_INCIDENTTYPE_ID" HeaderText="GRIEVANCE_INCIDENTTYPE_ID"
                                                            meta:resourcekey="GRIEVANCE_INCIDENTTYPE_ID" Visible="false">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_INCIDENTTYPE" UniqueName="GRIEVANCE_INCIDENTTYPE" HeaderText="Complaint Type"
                                                            meta:resourcekey="GRIEVANCE_INCIDENTTYPE">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_COMMITTEEID" UniqueName="GRIEVANCE_COMMITTEEID" HeaderText="GRIEVANCE_COMMITTEEID"
                                                            meta:resourcekey="GRIEVANCE_COMMITTEEID" Visible="false">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="COMMITTEE_CODE" UniqueName="COMMITTEE_CODE" HeaderText="Committee Name"
                                                            meta:resourcekey="COMMITTEE_CODE">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridDateTimeColumn DataField="GRIEVANCE_REPORTEDDATE" UniqueName="GRIEVANCE_REPORTEDDATE" HeaderText="Reported Date" FilterControlWidth="100px"
                                                            meta:resourcekey="GRIEVANCE_REPORTEDDATE" DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridDateTimeColumn>

                                                        <telerik:GridBoundColumn DataField="GRIEVANCE_INCIDENTDESCRIPTION" UniqueName="GRIEVANCE_INCIDENTDESCRIPTION" HeaderText="Description"
                                                            meta:resourcekey="GRIEVANCE_INCIDENTDESCRIPTION" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false" HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("GRIEVANCE_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" ToolTip="Edit" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridTemplateColumn UniqueName="ColAction" AllowFiltering="false" HeaderText="Take Action">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_TakeAction" runat="server" CommandArgument='<%# Eval("GRIEVANCE_ID") %>'
                                                                    OnCommand="lnk_TakeAction_Command" ToolTip="Edit" meta:resourcekey="lnk_TakeAction">Take Action</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                    </Columns>

                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                            UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" />
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                              <%--  <ClientSettings>
                                                    <ClientEvents OnFilterMenuShowing="gridFilterMenuShowing" />
                                                </ClientSettings>--%>

                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <table>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <%--<asp:Label ID="LBL_COMETID" runat="server" Text="Label" Visible="false"></asp:Label>--%>
                                                        <asp:HiddenField runat="server" ID="HIDN_COMETID" />
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>

                                                    <td></td>
                                                </tr>

                                            </table>

                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <table align="center" width="65%">
                            <%-- <Fieldset title="Reported By" style="font-weight:bold">--%>

                            <tr>
                                <td style="font-weight: bold">Complaint By:
                                </td>
                            </tr>
                            <tr>
                                <td>Search Employee
                                </td>
                                <td>:
                                </td>
                                <td colspan="6">
                                    <telerik:RadComboBox ID="rcmb_ReportedByEmployee" Width="600px" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="OnClientItemsRequesting" OnSelectedIndexChanged="rcmb_ReportedByEmployee_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="RecordIncident.aspx" />
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rcmb_ReportedByEmployee"
                                        ErrorMessage="Please Select Complaint By Employee Name" Text="*" ValidationGroup="Controls" />

                                </td>
                            </tr>
                            <tr>
                              <%--  <td>Employee Name
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedByEmpName" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>--%>
                                <td>Business Unit
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedByBU" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                                <td>Directorate 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedByDirectorate" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                 <td>Position 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedByEmpPosition" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                               
                                 <td>Department 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedByDepartment" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                               
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <hr style="width: 100%" />
                                </td>
                            </tr>
                            <%--</Fieldset>--%>
                            <%--Reported On--%>
                            <tr>
                                <td style="font-weight: bold">Complaint On:
                                </td>
                            </tr>
                            <tr>
                                <td>Search Employee</td>
                                <td>:
                                </td>
                                <td colspan="6">
                                    <telerik:RadComboBox ID="rcmb_ReportedOnEmployee" Width="600px" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                        MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="OnClientItemsRequesting" OnSelectedIndexChanged="rcmb_ReportedOnEmployee_SelectedIndexChanged">
                                        <WebServiceSettings Method="GET_EmployeeBySearchString" Path="RecordIncident.aspx" />
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rcmb_ReportedOnEmployee"
                                        ErrorMessage="Please Select Complaint on Employee Name" Text="*" ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                               <%-- <td>Employee Name
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedOnEmpName" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>--%>
                                <td>Business Unit
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedOnBU" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                                 <td>Directorate 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedOnDirectorate" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>Position 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedOnEmpPosition" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                                
                               <td>Department 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportedOnDepartment" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />

                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <hr style="width: 100%" />
                                </td>
                            </tr>
                            <%--Reporting Manager--%>
                            <tr>
                                <td>Reporting Manager
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ReportingManager" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>

                            </tr>
                            <tr>
                                <td>Complaint ID
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_IncidentID" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>

                            </tr>
                            <tr>
                                <td>Complaint 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Incident" runat="server" OnSelectedIndexChanged="rcmb_Incident_SelectedIndexChanged" AutoPostBack="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem Text="Grievance" Value="GRIEVANCETYPEMASTER" />
                                            <telerik:RadComboBoxItem Text="Discipline" Value="DISCIPLINARYTYPEMASTER" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_Incident" runat="server" ControlToValidate="rcmb_Incident"
                                        meta:resourcekey="rfv_Incident" ErrorMessage="Please Select Complaint" InitialValue="Select" Text="*" ValidationGroup="Controls" />
                                </td>

                            </tr>
                            <tr>
                                <td>Type of Complaint 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_IncidentType" runat="server" Filter="Contains" />
                                    <asp:RequiredFieldValidator ID="rfv_IncidentType" runat="server" InitialValue="Select" ControlToValidate="rcmb_IncidentType"
                                        meta:resourcekey="rfv_IncidentType" ErrorMessage="Please Select Complaint Type" Text="*" ValidationGroup="Controls" />
                                </td>

                            </tr>
                            <tr>
                                <td>Reported Date
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_ReportedDate" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfv_ReportedDate" runat="server" ControlToValidate="rdp_ReportedDate"
                                        meta:resourcekey="rfv_ReportedDate" ErrorMessage="Please Select Reported Date" Text="*" ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                                <td>Description
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Description" runat="server" Height="90" TextMode="MultiLine" />
                                </td>
                            </tr>
                            <tr>
                                <td>Committee Name 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_Committee" runat="server" Filter="Contains" />
                                    <asp:RequiredFieldValidator ID="rfv_Committee" runat="server" InitialValue="Select" ControlToValidate="rcmb_Committee"
                                        meta:resourcekey="rfv_Committee" ErrorMessage="Please Select Committee" Text="*" ValidationGroup="Controls" />
                                </td>

                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" Visible="False" UseSubmitBehavior="false" ValidationGroup="Controls" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" Visible="False" UseSubmitBehavior="false" ValidationGroup="Controls" OnClientClick="fnJSOnFormSubmit(this,'Controls')" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_RecordIncident" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>


                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_TakeAction" runat="server">
                        <table align="center" width="65%">
                            <tr>
                                <td style="font-weight: bold" colspan="3">Incident Information </td>
                            </tr>
                            <tr>
                                <td>Complaint ID
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ActionIncidentID" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>Complaint
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ActionIncident" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>Type of Complaint 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ActionIncidentType" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>Complaint By</td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_cmplantby" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" /></td>


                            </tr>
                            <tr>
                                <td>Complaint On</td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_cmplainton" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" /></td>


                            </tr>
                            <tr id="cmpon_id" runat="server" visible="false">
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="comlainton_empid" runat="server" Visible="false"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td>Reported Date
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ActionReportedDate" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <hr style="width: 100%" />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold" align="center" colspan="5">Action Taken
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_title" runat="server" Width="200px" Text="Disciplinary/Grievance Action" />
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_DisciplinaryGrievanceAction" runat="server" AutoPostBack="true" 
                                        OnSelectedIndexChanged="rcmb_DisciplinaryGrievanceAction_SelectedIndexChanged" Filter="Contains" />
                                    <asp:RequiredFieldValidator ID="rfv_DisciplinaryGrievanceAction" runat="server" ControlToValidate="rcmb_DisciplinaryGrievanceAction" InitialValue="Select"
                                        meta:resourcekey="rfv_DisciplinaryGrievanceAction" ErrorMessage="Please Select Disciplinary/Grievance Action" Text="*" ValidationGroup="ActionControls" />
                                </td>
                            </tr>
                            <tr>
                                <td>Reasons For Action</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="Txt_reason" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Action Date
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_ActionDate" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfv_ActionDate" runat="server" ControlToValidate="rdp_ActionDate"
                                        meta:resourcekey="rfv_ActionDate" ErrorMessage="Please Select Action Date" Text="*" ValidationGroup="ActionControls" />
                                </td>
                            </tr>
                            <tr id="susdfd" runat="server" visible="false">
                                <td>Suspended From Date
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_SuspendedFrom" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfv_SuspendedFrom" runat="server" ControlToValidate="rdp_SuspendedFrom"
                                        meta:resourcekey="rfv_SuspendedFrom" ErrorMessage="Please Select Suspended From Date" Text="*" ValidationGroup="rdp_SuspendedFrom" />
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="rdp_ActionDate" ControlToValidate="rdp_SuspendedFrom"
                                        Display="Dynamic" Operator="GreaterThanEqual" Text="*" Type="Date" ErrorMessage=" Suspended From Date Should not be less than Action  Date "
                                        ValidationGroup="ActionControls"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr id="susdtd" runat="server" visible="false">
                                <td>Suspended To Date 
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdp_SuspendedTo" runat="server" />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="rdp_ActionDate" ControlToValidate="rdp_SuspendedTo"
                                        Display="Dynamic" Operator="GreaterThanEqual" Text="*" Type="Date" ErrorMessage=" Suspended To Date Should not be less than Action  Date "
                                        ValidationGroup="ActionControls"></asp:CompareValidator>
                                    <asp:CompareValidator ID="Cmpv_tdate" runat="server" ControlToCompare="rdp_SuspendedFrom" ControlToValidate="rdp_SuspendedTo"
                                        Display="Dynamic" Operator="GreaterThanEqual" Text="*" Type="Date" ErrorMessage=" Suspended To Date Should not be less than Suspended From Date "
                                        ValidationGroup="ActionControls"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="rfv_SuspendedTo" runat="server" ControlToValidate="rdp_SuspendedTo"
                                        meta:resourcekey="rfv_SuspendedTo" ErrorMessage="Please Select Suspended To Date" Text="*" ValidationGroup="ActionControls" />

                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <hr style="width: 100%" />
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td style="font-weight: bold" align="center" colspan="3">Discussed With</td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold" align="center" colspan="3"></td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table border="0">

                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblCommittee" runat="server" Text="Committee Name :" />
                                                <telerik:RadTextBox ID="rtxt_ActionCommittee" runat="server" Enabled="false" DisabledStyle-ForeColor="Black" DisabledStyle-Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <telerik:RadGrid ID="rg_CommitteeMembers" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                    Skin="WebBlue" OnNeedDataSource="rg_CommitteeMembers_NeedDataSource" AllowPaging="true"
                                                    AllowFilteringByColumn="false">
                                                    <MasterTableView CommandItemDisplay="None">
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderText="Select" UniqueName="Edit" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="COMMITTEEMEMBERID" HeaderText="COMMITTEEMEMBERID" meta:resourcekey="COMMITTEEMEMBERID"
                                                                UniqueName="COMMITTEEMEMBERID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="COMMITTEEMEMBER" HeaderText="Name of the Committee Members" meta:resourcekey="COMMITTEEMEMBER"
                                                                UniqueName="COMMITTEEMEMBER">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Designation" meta:resourcekey="POSITIONS_CODE"
                                                                UniqueName="POSITIONS_CODE">
                                                            </telerik:GridBoundColumn>


                                                        </Columns>

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
                                </td>
                                <td valign="top"></td>
                                <td>

                                    <table border="0">



                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label1" runat="server" Text="Other Members:" />

                                                <telerik:RadComboBox ID="rcmb_OtherMembers" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" EmptyMessage="Enter Employee Name"
                                                    MarkFirstMatch="true" EnableLoadOnDemand="true" AutoPostBack="true" OnClientItemsRequesting="OnClientItemsRequesting">
                                                    <WebServiceSettings Method="GET_EmployeeBySearchString" Path="RecordIncident.aspx" />
                                                </telerik:RadComboBox>
                                                <asp:LinkButton ID="lnk_AddOtherMembers" runat="server" Text="Add" OnClick="lnk_AddOtherMembers_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <telerik:RadGrid ID="rg_OtherMembers" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                    Skin="WebBlue" AllowPaging="false" onrowcommand="gridMembersList_RowCommand"
                                                    AllowFilteringByColumn="false">
                                                    <MasterTableView CommandItemDisplay="None">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="COMMITTEEMEMBERID" HeaderText="COMMITTEEMEMBERID"
                                                                UniqueName="COMMITTEEMEMBERID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="COMMITTEEMEMBER" HeaderText="Name"
                                                                UniqueName="COMMITTEEMEMBER">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Designation"
                                                                UniqueName="POSITIONS_CODE">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Delete" UniqueName="Delete" AllowFiltering="false" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandArgument='<%#Eval("COMMITTEEMEMBERID") %>' CommandName="Delete" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <PagerStyle AlwaysVisible="True" />
                                                    <FilterMenu Skin="WebBlue">
                                                    </FilterMenu>
                                                    <HeaderContextMenu Skin="WebBlue">
                                                    </HeaderContextMenu>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold" align="center" colspan="3">Discussion Date:
                                            
                                                <telerik:RadDatePicker ID="rdp_DiscussionDate" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdp_DiscussionDate"
                                        meta:resourcekey="rfv_DiscussionDate" ErrorMessage="Please Select Discussion Date" Text="*" ValidationGroup="ActionControls" />


                                    <asp:CompareValidator ID="cv_date" runat="server" ControlToCompare="rdp_ActionDate" ControlToValidate="rdp_DiscussionDate"
                                        Display="Dynamic" Operator="LessThanEqual" Text="*" Type="Date" ErrorMessage=" Discussion Date Should not be greater than Action Date "
                                        ValidationGroup="ActionControls"></asp:CompareValidator>


                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold" align="center" colspan="3">
                                    <asp:UpdatePanel ID="upd_Panel_Upload" runat="server">
                                        <ContentTemplate>
                                            Upload Court Ruling: 
                                            <asp:FileUpload ID="upload_CourtRuling" runat="server"></asp:FileUpload>
                                            <asp:RegularExpressionValidator ID="ref_upload_CourtRuling" ControlToValidate="upload_CourtRuling"
                                                ValidationGroup="ActionControls" runat="Server" ErrorMessage="Only doc files are allowed"
                                                Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btn_TakeAction" />
                                            <asp:PostBackTrigger ControlID="Btn_updatetakeactin" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <a id="D1" runat="server" visible="false">Download Document</a>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Button ID="btn_TakeAction" runat="server" meta:resourcekey="btn_TakeAction" OnClick="btn_TakeAction_Click" ValidationGroup="ActionControls"
                                        Text="Save" OnClientClick="fnJSOnFormSubmit(this,'ActionControls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="Btn_letter" runat="server" OnClick="btn_lettermail_Click" Visible="false"
                                        Text="Letter" />

                                    <asp:Button ID="Btn_updatetakeactin" runat="server" OnClick="btn_TakeAction_Click"
                                        Text="Update" UseSubmitBehavior="false" OnClientClick="fnJSOnFormSubmit(this,'ActionControls')" ValidationGroup="ActionControls" />
                                    <asp:Button ID="btn_ActionCancel" runat="server" meta:resourcekey="btn_ActionCancel" OnClick="btn_ActionCancel_Click"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="ActionControls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>

                </telerik:RadMultiPage>
            </td>
            <td></td>
        </tr>

    </table>

</asp:Content>