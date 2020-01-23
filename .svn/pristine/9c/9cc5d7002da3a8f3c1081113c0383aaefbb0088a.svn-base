<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_JobOffers.aspx.cs" Inherits="Recruitment_frm_JobOffers" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">  
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript">
        function ShowPop(url, JobID) {
            var win = window.radopen('../Reportss/JobofferReport.aspx?ApplicantId=' + url + '&JobId=' + JobID, "RadWindow1");
            win.center();
            win.add_close(OnClientCloseHandler);
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }

        function OnClientCloseHandler() {
            window.location.href = "frm_JobOffers.aspx";
        }
    </script>

    <%--<script type="text/javascript">

         function OpenWindow() {
             var wnd = window.radopen("frm_recruit_offerletter.aspx", "RadWindow1");
             wnd.center();
             wnd.set_modla(true);
             //  wnd.setSize(600, 500);
             wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
             
         }
    
    </script>--%>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_PhaseDefinitionHeader" runat="server" Text="Job Offer" Font-Bold="True"></asp:Label>
            </td>
            <td></td>
        </tr>

        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_Joboffers" runat="server">
                    <telerik:RadPageView ID="RP_Joboffers" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_Joboffers" runat="server" AutoGenerateColumns="false" AllowPaging="true" GridLines="None"
                                        AllowFilteringByColumn="true" OnNeedDataSource="RG_Joboffers_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="JOBOFFRS ID" DataField="JOBOFFRS_ID" Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="JOBOFFRS REQID" DataField="JOBOFFRS_REQCODE"
                                                    Visible="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Applicant" DataField="EMPNAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDateTimeColumn HeaderText="Offered Date" DataField="JOBOFFRS_OFFERDATE" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridNumericColumn HeaderText="Salary Offered" DataField="JOBOFFRS_OFFERSAL" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <telerik:GridDateTimeColumn HeaderText="Join Date" DataField="JOBOFFRS_JOINDATE" FilterControlWidth="100px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Command" CommandArgument='<%#Eval("JOBOFFRS_ID") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
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
                    <telerik:RadPageView ID="RP_JobofferDetails" runat="server" Width="100%">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="false"></asp:Label>
                                    <asp:Label ID="lbl_JobRequistion" runat="server" Text="Resource Requistion"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCMB_JobRequistion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RCMB_JobRequistion_SelectedIndexChanged"
                                        MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Jobrequisition" Text="*" InitialValue="Select"
                                        ControlToValidate="RCMB_JobRequistion" ValidationGroup="Controls" runat="server"
                                        ErrorMessage="Please Select Resource Requsition"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JobRequistionDescription" runat="server" Text="Resource Requistion Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_JobRequistionDescription" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Dateofcreation" runat="server" Text="Date of Creation"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_Dateofcreation" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_RasiedBy" runat="server" Text="Raised By"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_RasiedBy" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Businessunit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_Businessunit" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Directorate
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_Directorate" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>Department
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_Department" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Designation
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_Designation" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>Scale
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_Scale" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Offersalary" runat="server" Text="Offered Salary"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_OfferSalary" runat="server" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbl_Offerdate" runat="server" Text="Offered Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <%-- <telerik:RadTextBox ID="RDP_Offerdate" runat="server" Enabled="false">
                                    </telerik:RadTextBox>--%>
                                    <telerik:RadDatePicker ID="RDP_Offerdate" runat="server" Skin="WebBlue" Width="205px" Enabled="false">
                                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <%--<asp:RequiredFieldValidator ID="RFV_offerdate" Text="*" ControlToValidate="RDP_Offerdate"
                                        ValidationGroup="Controls" runat="server" ErrorMessage="Enter Offerdate"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Applicant" runat="server" Text="Applicant"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCMB_Applicant" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RCMB_Applicant_SelectedIndexChanged"
                                        MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblApcode" runat="server" Visible="False"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RFV_Applicant" Text="*" InitialValue="Select" ControlToValidate="RCMB_Applicant"
                                        ValidationGroup="Controls" runat="server" ErrorMessage="Please Select Applicant"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ApplicantName" runat="server" Text="Applicant Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="RTB_ApplicantName" runat="server" Width="250px" Enabled="false">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_SalaryStructure" runat="server" Text="Salary Structure"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCB_SalaryStructure" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Salarystructure" Text="*" ControlToValidate="RCB_SalaryStructure"
                                        ValidationGroup="Controls" InitialValue="Select" runat="server" ErrorMessage="Please Select SalaryStructure"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_leavestructure" runat="server" Text="Leave Structure"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RCMB_leavestructure" runat="server" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_leavestructure" Text="*" ControlToValidate="RCMB_leavestructure"
                                        ValidationGroup="Controls" runat="server" ErrorMessage="Please Select Salary Structure"
                                        InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_JoinDate" runat="server" Text="Join Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="RDP_JoinDate" runat="server">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_Joindate" Text="*" ControlToValidate="RDP_JoinDate"
                                        ValidationGroup="Controls" runat="server" ErrorMessage="Please Enter JoinDate"></asp:RequiredFieldValidator>
                                </td>
                                <%-- <td style="height: 18px">
                        <asp:HyperLink ID="HLink" runat="server" ForeColor="MidnightBlue" Width="162px" onclick="OpenWindow()"
                            Style="cursor: pointer">Generate Offer Letter</asp:HyperLink></td>--%>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click"
                                        ValidationGroup="Controls" />&nbsp;
                                    <asp:Button ID="btn_Update" runat="server" OnClick="btn_Submit_Click" Text="Update"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="VS_JoboffersSummary" runat="server" ValidationGroup="Controls"
                            ShowMessageBox="True" ShowSummary="False" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>