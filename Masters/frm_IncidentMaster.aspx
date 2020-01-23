<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_IncidentMaster.aspx.cs" Inherits="Masters_frm_IncidentMaster" %>

<%@ Register Src="~/BUFilter.ascx" TagPrefix="uc1" TagName="BUFilter" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="padding-top:2%">
        <tr>
            <td align="center">
                <asp:Label ID="lblHeading" runat="server" Font-Bold="True"
                    meta:resourcekey="Incident" Text="Incident Master"></asp:Label>
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
                                    <telerik:RadGrid ID="RG_IncidentMaster" runat="server" Skin="WebBlue" GridLines="None"
                                        AutoGenerateColumns="False" OnNeedDataSource="RG_IncidentMaster_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="True" AllowSorting="True">
                                        <GroupingSettings CaseSensitive="False" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="INCIDENT_ID" HeaderText="Incident ID"
                                                    meta:resourcekey="INCIDENT_ID" UniqueName="INCIDENT_ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="INCIDENT_CODE" HeaderText="Code"
                                                    meta:resourcekey="INCIDENT_CODE" UniqueName="INCIDENT_CODE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn DataField="INCIDENT_NAME" HeaderText="Name"
                                                    meta:resourcekey="INCIDENT_NAME" UniqueName="INCIDENT_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PLACE_OF_INCIDENT" HeaderText="Place"
                                                    meta:resourcekey="PLACE_OF_INCIDENT" UniqueName="PLACE_OF_INCIDENT">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                              <%--  <telerik:GridBoundColumn DataField="INCIDENT_DATE" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy hh:mm tt}"
                                                    meta:resourcekey="INCIDENT_DATE" UniqueName="INCIDENT_DATE">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>

                                                <telerik:GridDateTimeColumn DataField="INCIDENT_DATE"  meta:resourcekey="INCIDENT_DATE" FilterControlWidth="110px"
                        SortExpression="INCIDENT_DATE" PickerType="DatePicker" HeaderText="Date"
                        DataFormatString="{0:dd/MM/yyyy}">
                    </telerik:GridDateTimeColumn>

                                                <telerik:GridTemplateColumn AllowFiltering="False"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="View">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_IncidentMaster_Edit" runat="server" CommandName="EditRec"
                                                            CommandArgument='<%# Eval("INCIDENT_ID") %>'
                                                            meta:resourcekey="lnk_IncidentMaster_EditResource1" OnCommand="lnk_IncidentMasterEdit_Command">View</asp:LinkButton>
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
                        <table style="padding-top: 2%;" align="center">
                            <tr>
                                <td colspan="3">
                                    <uc1:BUFilter runat="server" ID="BUFilter1" HideEmployee="true" ShowBusinessUnitSpan="true"/>
                                    <asp:RequiredFieldValidator ID="rfvBUFilter1BU" runat="server" ControlToValidate="BUFilter1$RadBusinessUnit"
                                        ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" Display="None" EnableClientScript="true" InitialValue="Select"
                                        meta:resourcekey="rfvBUFilter1BU"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trIncCode" runat="server" visible="false">
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
                                        ErrorMessage="Please Select Incident Name" ValidationGroup="Controls"
                                        meta:resourcekey="rfvRD_txtIncidentName">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPlaceOfIncident" runat="server" Text="Place Of Incident"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadTextBox ID="RD_txtPlaceOfIncident" runat="server" EnableEmbeddedSkins="false" MaxLength="50" TabIndex="1"
                                        EnableAjaxSkinRendering="False">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfvRD_txtPlaceOfIncident" runat="server" ControlToValidate="RD_txtPlaceOfIncident"
                                        ErrorMessage="Please Select Place of Incident" ValidationGroup="Controls"
                                        meta:resourcekey="rfvRD_txtPlaceOfIncident">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDateTime" runat="server" Text="Date and Time"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadDateTimePicker ID="RD_dtIncidentDtTime" runat="server" MaxLength="50" TabIndex="1"
                                        >
                                    </telerik:RadDateTimePicker>
                                    <asp:RequiredFieldValidator ID="rfvRD_dtIncidentDtTime" runat="server" ControlToValidate="RD_dtIncidentDtTime"
                                        ErrorMessage="Please Select Date & Time" ValidationGroup="Controls"
                                        meta:resourcekey="rfvRD_dtIncidentDtTime">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnEdit" runat="server" OnClick="btnSave_Click" Text="Update" Visible="False"
                                        ValidationGroup="Controls" Width="61px"
                                        meta:resourcekey="btnEdit" CausesValidation="False" />
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
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>

