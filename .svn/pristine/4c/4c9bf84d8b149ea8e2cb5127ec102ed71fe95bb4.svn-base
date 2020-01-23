<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_InspectionIsCompliant.aspx.cs" Inherits="Health_and_Safety_frm_InspectionIsCompliant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <%--<script type="text/javascript">
        var rowCount = 0;
        var chkCount = 0;

        function Validate() {

            var CHK = document.getElementById("<%=rbl_IsCompliant.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            

            for (var i = 0; i < checkbox.length; i++) {
                rowCount++;
                if (checkbox[i].checked) {
                    chkCount++;
                }
            }
            if (rowCount != chkCount) {
                alert("Please select all Check Box item(s)");
                return false;
            }
            return true;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="cphScheduleInspection" ContentPlaceHolderID="cphDefault" runat="Server">
   <script type="text/javascript">
       function OnClientItemsRequesting(sender, eventArgs) {
           var context = eventArgs.get_context();
           context["FilterString"] = eventArgs.get_text();
       }
       function ShowPastDataPop() {
           var win = window.radopen('../Approval/frm_PastInspections.aspx', "rwPastInspectionData");
           win.set_height("500");
           win.set_width("800");
           win.center();
           win.set_modal(true);
           win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
           
       }
    </script>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_ScheduleInspection" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_InspectionIsCompliant" runat="server" Font-Bold="True"
                    Text="Inspections&nbsp;Feedback"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxManagerProxy ID="RAM_ScheduleInspection" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="Rg_ScheduleInspection">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManagerProxy>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Activity_ADDView" runat="server">

                        <asp:UpdatePanel ID="upPast" runat="server">
                            <ContentTemplate>
                                <table width="100%" align="center">
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="lnkPastInsp" runat="server" OnClientClick="ShowPastDataPop(); return false;" Text="View Past History"></asp:LinkButton>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="INSPECTION_AREA_SCHEDULE_ID" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="INSPECTION_AREA_ID" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="AREA_ID" runat="server" Visible="False"></asp:Label>
                                    <br />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InspectedBy" runat="server" Text="Inspected By"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_InspectedBy" runat="server" Skin="WebBlue" HighlightTemplatedItems="True" Filter="Contains"
                                        EmptyMessage="Enter Employee Name" Enabled="false" OnSelectedIndexChanged="rad_InspectedBy_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_InspectionName" runat="server" Text="Inspection Name"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rad_InspectionName" runat="server" MarkFirstMatch="true" OnSelectedIndexChanged="rad_InspectionName_SelectedIndexChanged"
                                        Skin="WebBlue" AutoPostBack="true" EnableEmbeddedSkins="false" MaxHeight="120px" MaxLength="40" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <div id="divControls" runat="server" visible="false">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Date" runat="server" Text="Date&nbsp;<strong>:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From"></asp:Label>
                                    </td>
                                    <td><b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="rdtp_FromDate" runat="server"
                                            Skin="WebBlue" Enabled="false">
                                            <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                ViewSelectorText="x" Enabled="false">
                                            </Calendar>
                                            <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" Enabled="false" />
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_To" runat="server" Text="To&nbsp;<b>:</b>"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="rdtp_ToDate" runat="server"
                                            Skin="WebBlue" Enabled="false">
                                            <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                ViewSelectorText="x" Enabled="false">
                                            </Calendar>
                                            <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" Enabled="false" />
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Time" runat="server" Text="Time&nbsp;<strong>:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From"></asp:Label>
                                    </td>
                                    <td><b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTimePicker ID="rtp_FromTime" AutoPostBack="true" Culture="en-US" runat="server" Width="105px" TabIndex="5" Enabled="false"></telerik:RadTimePicker>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_ToTime" runat="server" Text="To&nbsp;<b>:</b>"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTimePicker ID="rtp_ToTime" AutoPostBack="true" Culture="en-US" runat="server" Width="105px" TabIndex="5" Enabled="false"></telerik:RadTimePicker>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Area" runat="server" Text="Areas To be Inspected"></asp:Label>
                                    </td>
                                    <td><b>:</b>
                                    </td>
                                    <td colspan="4">
                                        <telerik:RadGrid ID="Rg_Areas_To_Inspected" runat="server" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="Rg_Areas_To_Inspected_NeedDataSource"
                                            AllowPaging="True" AllowFilteringByColumn="false" Skin="WebBlue" OnItemDataBound="Rg_Areas_To_Inspected_ItemDataBound">
                                            <MasterTableView CommandItemDisplay="None" EnableNoRecordsTemplate="true">
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="Sl.No" UniqueName="Sl_No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSn" Text="<%# (Container.ItemIndex+1).ToString() %>" runat="server" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="IsCompliant" UniqueName="IsCompliant" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_IsCompliant" Text='<%# Eval("INSPECTION_AREA_ISCOMPLIANT") %>' runat="server"></asp:Label>
                                                            <asp:Label ID="lbl_IA_ID" runat="server" Text='<%# Eval("INSPECTION_AREA_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Choose">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk_Choose" runat="server" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Area Name" UniqueName="Area_Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Area_Id" runat="server" Text='<%# Eval("AREA_ID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbl_AreaName" runat="Server" Text='<%#Eval("AREA_NAME") %>'></asp:Label>
                                                            <asp:RadioButtonList ID="rbl_IsCompliant" RepeatDirection="Horizontal" RepeatColumns="2" runat="server">
                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <asp:RequiredFieldValidator ID="rfv_IsCompliant" runat="server" ControlToValidate="rbl_IsCompliant" ErrorMessage="Please Choose Area Name" Enabled="false" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn UniqueName="Is_Compliant" HeaderText="Is Compliant" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Comments" runat="Server" Text="Comments"></asp:Label>
                                                            <asp:Label ID="lbl_ItemComments" runat="Server" Text='<%# Eval("INSPECTION_AREA_COMMENTS") %>' Visible="false"></asp:Label>
                                                            <telerik:RadTextBox ID="Comments" runat="server" Width="10px" MaxLength="250">
                                                            </telerik:RadTextBox>
                                                            <asp:RequiredFieldValidator ID="rfv_Comments" runat="server" Enabled="false" ControlToValidate="Comments" ErrorMessage="Please Enter Comments" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <NoRecordsTemplate>
                                                    <div>
                                                        There are no records to display
                                                    </div>
                                                </NoRecordsTemplate>
                                            </MasterTableView>
                                            <PagerStyle AlwaysVisible="true" />
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </div>
                            <div id="divNoRecords" runat="server" visible="false">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAreasInspctdBy2" runat="server" Text="Areas To be Inspected"></asp:Label>
                                    </td>
                                    <td><b>:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNoRecords" runat="server" Text="No Records to Display.." Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </div>
                        </table>
                        <table align="center">
                            <tr>
                                <td align="left">
                                    <br />
                                    <asp:Button ID="btn_Submit" runat="server" OnClick="btn_Submit_Click" Text="Submit" ValidationGroup="Controls" Visible="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="Cancel" Visible="false" />
                                    <asp:ValidationSummary ID="vsInspectionIsCompliant" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>