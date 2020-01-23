<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_AddIncidentsToEmp.aspx.cs" Inherits="Workman_Compensation_frm_AddIncidentsToEmp" %>

<%@ Register Src="~/BUFilter.ascx" TagPrefix="uc1" TagName="BUFilter" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="padding-top: 2%">
        <tr>
            <td align="center">
                <asp:Label ID="lblHeading" runat="server" Font-Bold="True"
                    meta:resourcekey="Incidents" Text="Employee Incidents"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rm_MR_Page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="RP_GRIDVIEW" runat="server" meta:resourcekey="RP_GRIDVIEW" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Incident" runat="server" Skin="WebBlue" GridLines="None"
                                        AutoGenerateColumns="False" OnNeedDataSource="RG_Incident_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="True" AllowSorting="True">
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="INC_ID" HeaderText="Incident ID"
                                                    meta:resourcekey="INC_ID" UniqueName="INC_ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn DataField="INCIDENT_CODE" HeaderText="Incident Code"
                                                    meta:resourcekey="INCIDENT_CODE" UniqueName="INCIDENT_CODE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>


                                                <telerik:GridBoundColumn DataField="INCIDENT_NAME" HeaderText="Incident Name"
                                                    meta:resourcekey="INCIDENT_NAME" UniqueName="INCIDENT_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PLACE_OF_INCIDENT" HeaderText="Place of Incident"
                                                    meta:resourcekey="PLACE_OF_INCIDENT" UniqueName="PLACE_OF_INCIDENT">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="INCIDENT_DATE" HeaderText="Date of Incident" DataFormatString="{0:dd/MM/yyyy hh:mm tt}"
                                                    meta:resourcekey="INCIDENT_DATE" UniqueName="INCIDENT_DATE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridDateTimeColumn DataField="INCIDENT_DATE" HeaderText="Date Of Incident" meta:resourcekey="INCIDENT_DATE" FilterControlWidth="110px"
                                                    SortExpression="INCIDENT_DATE" PickerType="DatePicker"
                                                    DataFormatString="{0:dd/MM/yyyy}">
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name"
                                                    meta:resourcekey="EMP_NAME" UniqueName="EMP_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="INJURY_CAUSE" HeaderText="Cause of Injury"
                                                    meta:resourcekey="INJURY_CAUSE" UniqueName="INJURY_CAUSE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="INJURY_TYPE" HeaderText="Type Of Injury"
                                                    meta:resourcekey="INJURY_TYPE" UniqueName="INJURY_TYPE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SEVERITY" HeaderText="Severity"
                                                    meta:resourcekey="SEVERITY" UniqueName="SEVERITY">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>

                                                <telerik:GridTemplateColumn AllowFiltering="False"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Incident_Edit" runat="server" CommandName="EditRec"
                                                            CommandArgument='<%# Eval("INC_ID") %>'
                                                            meta:resourcekey="lnk_Incident_EditResource1" OnCommand="lnk_IncidentEdit_Command">Edit</asp:LinkButton>
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
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_FORMVIEW" runat="server" meta:resourcekey="RP_FORMVIEW">
                        <table align="center">
                            <tr>
                                <td colspan="3" style="width: 15px;">
                                    <uc1:BUFilter runat="server" ID="BUFilter1" OnBUFilterRadEmployee_SelectedIndexChanged="BUFilter1Emp_SelectedIndexChanged" ShowBusinessUnitSpan="true" ShowEmployeeSpan="true" />
                                    <asp:RequiredFieldValidator ID="rfvBUFilter1Emp" runat="server" ControlToValidate="BUFilter1$RadEmployee"
                                        ErrorMessage="Please Select Employee" ValidationGroup="Controls" Display="None" EnableClientScript="true" InitialValue="Select"
                                        meta:resourcekey="rfvBUFilter1Emp"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvBUFilter1BU" runat="server" ControlToValidate="BUFilter1$RadBusinessUnit"
                                        ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" Display="None" EnableClientScript="true" InitialValue="Select"
                                        meta:resourcekey="rfvBUFilter1BU"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <asp:Panel runat="server" ID="pnlFields" Visible="false">
                                <tr>
                                    <td style="width: 150px">
                                        <asp:Label ID="lblEmployee" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <telerik:RadTextBox ID="RD_txtEmployee" runat="server" Enabled="false" EnableEmbeddedSkins="false" MaxLength="50"
                                            EnableAjaxSkinRendering="False">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <telerik:RadTextBox ID="RD_txtDesignation" Enabled="false" runat="server" EnableEmbeddedSkins="false" MaxLength="50" TabIndex="1"
                                            EnableAjaxSkinRendering="False">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <telerik:RadTextBox ID="RD_txtAge" Enabled="false" runat="server" EnableEmbeddedSkins="false" MaxLength="3" TabIndex="1"
                                            EnableAjaxSkinRendering="False">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="lblSex" runat="server" Text="Sex"></asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <telerik:RadTextBox ID="RD_txtSex" Enabled="false" runat="server" EnableEmbeddedSkins="false" MaxLength="50" TabIndex="1"
                                            EnableAjaxSkinRendering="False">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td>
                                    <asp:Label ID="lblIncident" runat="server" Text="Incident"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="RD_cmbIncident" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RD_cmbIncident_SelectedIndexChanged" EmptyMessage="Select" Filter="Contains"></telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfvRD_cmbIncident" runat="server" ControlToValidate="RD_cmbIncident"
                                        ErrorMessage="Please Select Incident" ValidationGroup="Controls"
                                        meta:resourcekey="rfvRD_cmbIncident" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <%--<tr>
                                <td style="width: 150px;">
                                    <asp:Label ID="lblIncidentCode" runat="server" Text="Incident Code"></asp:Label>
                                    <asp:Label ID="lblIncidentID" runat="server" Text="IncidentID" Visible="false"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="RD_txtIncidentCode" Enabled="false" runat="server" EnableEmbeddedSkins="false" MaxLength="50" TabIndex="1"
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px;">
                                    <asp:Label ID="lblIncidentName" runat="server" Text="Incident Name"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="RD_txtIncidentName" runat="server" EnableEmbeddedSkins="false" MaxLength="50" TabIndex="1"
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfvRD_txtIncidentName" runat="server" ControlToValidate="RD_txtIncidentName"
                                        ErrorMessage="Please Specify Incident Name" ValidationGroup="Controls"
                                        meta:resourcekey="rfvRD_txtIncidentName">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>

                            <tr>
                                <td>
                                    <asp:Label ID="lblPlaceOfIncident" runat="server" Text="Place Of Incident"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="RD_txtPlaceOfIncident" runat="server" Enabled="false" EnableEmbeddedSkins="false" MaxLength="50" TabIndex="1"
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDateTime" runat="server" Text="Date and Time"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadDateTimePicker ID="RD_dtIncidentDtTime" runat="server" MaxLength="50" TabIndex="1" Enabled="false">
                                    </telerik:RadDateTimePicker>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblInjuryCause" runat="server" Text="Cause Of Injury"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="RD_cmbInjuryCause" runat="server" EmptyMessage="Select" Filter="Contains"></telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfvRD_cmbInjuryCause" runat="server" ControlToValidate="RD_cmbInjuryCause"
                                        ErrorMessage="Please Select Cause Of Injury" ValidationGroup="Controls"
                                        meta:resourcekey="rfvRD_cmbInjuryCause" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblInjuryType" runat="server" Text="Type Of Injury"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadComboBox ID="RD_cmbInjuryType" runat="server" EmptyMessage="Select" Filter="Contains"></telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfvRD_cmbInjuryType" runat="server" ControlToValidate="RD_cmbInjuryType"
                                        ErrorMessage="Please Select Type Of Injury" ValidationGroup="Controls"
                                        meta:resourcekey="rfvRD_cmbInjuryType" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSeverity" runat="server" Text="Severity"></asp:Label>
                                </td>
                                <td>:</td>
                                <td colspan="2">
                                    <telerik:RadComboBox ID="RD_cmbSeverity" runat="server" EmptyMessage="Select" Filter="Contains"></telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfvRD_cmbSeverity" runat="server" ControlToValidate="RD_cmbSeverity"
                                        ErrorMessage="Please Select Severity" ValidationGroup="Controls"
                                        meta:resourcekey="rfvRD_cmbSeverity" InitialValue="Select">*</asp:RequiredFieldValidator>
                                    <%-- <telerik:RadTextBox ID="RD_txtSeverity" runat="server" EnableEmbeddedSkins="false" MaxLength="50"
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadTextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="RD_txtRemarks" runat="server" TextMode="MultiLine" EnableEmbeddedSkins="false" MaxLength="50"
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadTextBox>
                                </td>
                                <td style="vertical-align: bottom">
                                    <asp:Button ID="btnAddRemarks" runat="server" OnClick="btnAddRemarks_Click" Text="Add Remarks" Visible="False"
                                        ValidationGroup="Controls" Width="75px"
                                        meta:resourcekey="btnAddRemarks" CausesValidation="False" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lblIncidentID" runat="server" Visible="false"></asp:Label>
                                    <asp:PlaceHolder ID="phRemarks" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnEdit" runat="server" OnClick="btnSave_Click" Text="Update" Visible="False"
                                        ValidationGroup="Controls" Width="61px"
                                        meta:resourcekey="btnEdit" CausesValidation="true" />
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Visible="False"
                                        ValidationGroup="Controls" meta:resourcekey="btnSave" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="5"
                                        OnClick="btnCancel_Click" meta:resourcekey="btnCancel" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:ValidationSummary ID="vsIncidentMaster" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" meta:resourcekey="vsIncidentMaster" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <%-- <telerik:RadPageView ID="RP_Remarks" runat="server" meta:resourcekey="RP_Remarks" Selected="false">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Remarks" runat="server" AutoGenerateColumns="false">
                                        <MasterTableView CommandItemDisplay="Top" DataKeyNames="ID">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="ID" HeaderText="Remarks ID"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="INC_ID" HeaderText="Incident ID"></telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="Remarks">
                                                    <ItemTemplate>
                                                        <telerik:RadTextBox ID="RD_txtIncRemarks" runat="server" TextMode="MultiLine"  Text='<%# Eval("REMARKS") %>'></telerik:RadTextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>--%>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>