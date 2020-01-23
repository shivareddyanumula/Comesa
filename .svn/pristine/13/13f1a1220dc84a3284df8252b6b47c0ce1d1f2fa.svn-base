<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_ResumeShortList.aspx.cs" Inherits="Recruitment_frm_ResumeShortList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_JobRequisition" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_JobRequisition">
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
    <table align="center">
        <tr>
            <td align="center" colspan="8">
                <asp:Label ID="lbl_Heading" runat="server" Text="Resume Short Listing" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <%--<td>
            </td>--%>
            <td>
                <asp:Label ID="lbl_JR" runat="server" Text="Job Requisition"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlJobReqCode" runat="server" EmptyMessage="Choose Job Requisition"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlJobReqCode_SelectedIndexChanged"
                    MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_ddlJobReqCode" ControlToValidate="ddlJobReqCode"
                    runat="server" ValidationGroup="Control" ErrorMessage="Please Select JobRequisition"
                    InitialValue="Select">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="lbl_Creation" runat="server" Text="Date of Creation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="txtDOC" runat="server" Enabled="False">
                </telerik:RadTextBox>
            </td>
            <td></td>
        </tr>
        <%--<tr>
            <td>
            </td>
            <td align="left">
                <asp:Label ID="lbl_JRDesc" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td>
                <telerik:RadTextBox ID="txtDesc" Width="181px" runat="server" Enabled="False" >
                </telerik:RadTextBox>
            </td>
            <td align="left">
                <asp:Label ID="lbl_Creation" runat="server" Text="Date of Creation"></asp:Label>
            </td>
            <td>
                :
            </td>
            <td style="width: 202px">
                <telerik:RadTextBox ID="txtDOC" Width="181px" runat="server" Enabled="False" >
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
        </tr>--%>
        <tr>
            <%--<td>
            </td>--%>
            <td>
                <asp:Label ID="lbl_Expiry" runat="server" Text="Date of Expiry"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="txtDOE" runat="server" Enabled="False">
                </telerik:RadTextBox>
            </td>
            <td></td>
            <td>
                <asp:Label ID="lbl_RaisedBy" runat="server" Text="Raised By"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="txtRaisedBy" runat="server" Enabled="False">
                </telerik:RadTextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <%--<td>
            </td>--%>
            <td>
                <asp:Label ID="lbl_BU" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="txtBU" runat="server" Enabled="False">
                </telerik:RadTextBox>
            </td>
            <td></td>
            <td>
                <asp:Label ID="lbl_Desig" runat="server" Text="Designation"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="txtDesignation" runat="server" Enabled="False">
                </telerik:RadTextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <%--<td>
            </td>--%>
            <td>
                <asp:Label ID="lbl_Openings" runat="server" Text="Target&nbsp;Openings"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="txtPositions" runat="server" Enabled="False">
                </telerik:RadTextBox>
            </td>
            <td></td>
            <td>
                <asp:Label ID="lbl_Years" runat="server" Text="No. Of Years Experience"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadTextBox ID="txtExp" runat="server" Enabled="False">
                </telerik:RadTextBox>
            </td>
            <td>
                <asp:Button ID="btnShortList" runat="server" OnClick="btnShortList_Click" Text="shortList"
                    Visible="false" ValidationGroup="Control" />
                <asp:ValidationSummary ID="vs_RS" runat="server" meta:resourcekey="vs_RS" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="Control" />
            </td>
        </tr>
        <%-- </table>--%>
        <%-- <table>--%>
        <%-- <tr>
                <td style="width: 90px">
                </td>
                <td style="width: 108px">
                </td> Height="100%"
                <td>
                </td>
            </tr>--%>
        <tr>
            <td colspan="8"></td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <telerik:RadTabStrip ID="RTS_ResumeShortList" runat="server" Visible="False" SelectedIndex="1"
                    Orientation="VerticalLeft" MultiPageID="RMP_Applinat" OnTabClick="RTS_ResumeShortList_TabClick">
                    <Tabs>
                        <telerik:RadTab runat="server" PageViewID="Applicant" Text="Applicant" Selected="true">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" PageViewID="ShortListed" Text="ShortListed">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
            <%--<td colspan="7"  >
            <asp:Panel ID="pnl_Applinats" runat ="server" BorderColor ="Black" BorderStyle ="Solid" BorderWidth ="1px" Height ="300px" Width ="100%">
            <table>
            <tr>
            <td colspan ="7"></td>
            
            </tr>
            <tr>
            <td colspan ="7"></td>
            </tr>
            <tr>--%>
            <td colspan="7">
                <telerik:RadMultiPage ID="RMP_Applinat" runat="server" SelectedIndex="1" BorderColor="Black"
                    BorderStyle="Solid" BorderWidth="1px" Width="105%">
                    <telerik:RadPageView ID="Applicant" runat="server" Selected="True" Width="70%">
                        <br />
                        <table align="center">
                            <tr>
                                <td colspan="7" align="center">
                                    <asp:Label ID="lbl_Applicants" runat="server" Text="Applicants" Font-Underline="True"
                                        Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7"></td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <telerik:RadGrid ID="GApplicants" runat="server" AllowPaging="True" GridLines="None"
                                        ShowStatusBar="True" AutoGenerateColumns="False" Width="100%" AllowFilteringByColumn="True"
                                        OnNeedDataSource="rg_needsource" Skin="Office2007" Visible="False" PageSize="5">
                                        <PagerStyle Mode="NumericPages" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="False" Groupable="False" ShowFilterIcon="False"
                                                    UniqueName="TemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkChoose" runat="server" Checked='<%# Eval("RESSHT_ISSHORTLIST") %>'
                                                            Enabled='<%# Eval("RESSHT_ISSHORTLIST").ToString()  == "True" ? false:true %>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumn"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_view" runat="server" OnCommand="lnk_view_Command" CommandArgument='<%# Eval("APPLICANT_ID") %>'
                                                            meta:resourcekey="lnk_view" Text="View"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Applicant Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblJRID" runat="server" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblAppID" runat="server" Text='<%# Eval("APPLICANT_ID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblAppCode" runat="server" Text='<%# Eval("APPLICANT_CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn2" HeaderText="Applicant Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppName" runat="server" Text='<%# Eval("APPLICANTNAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn3" HeaderText="Date of Birth">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("APPLICANT_DOB")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn4" HeaderText="Gender">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("APPLICANT_GENDER") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%-- <telerik:GridTemplateColumn UniqueName="TemplateColumn5" HeaderText = "Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaritalStatus" runat="server" Text='<%# Eval("APPLICANT_STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn5" HeaderText="Marital Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMaritalStatus" runat="server" Text='<%# Eval("APPLICANT_MARITALSTATUS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn6" HeaderText="Nationality">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNationality" runat="server" Text='<%# Eval("APPLICANT_NATIONALITY_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7"></td>
                            </tr>
                        </table>
                        <%--   </asp:Panel>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="ShortListed" runat="server" Selected="True" Width="70%">
                        <br />
                        <table align="center">
                            <tr>
                                <td colspan="7" align="center">
                                    <asp:Label ID="Label1" runat="server" Text="ShortListed Applicants" Font-Underline="True"
                                        Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7"></td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <telerik:RadGrid ID="rg_ShortListed" runat="server" AllowPaging="True" GridLines="None"
                                        ShowStatusBar="True" AutoGenerateColumns="False" Width="100%" AllowFilteringByColumn="True"
                                        OnNeedDataSource="rg_ShortListed_needsource" Skin="Office2007" Visible="False"
                                        PageSize="5">
                                        <PagerStyle Mode="NumericPages" />
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="False" Groupable="False" ShowFilterIcon="False"
                                                    UniqueName="TemplateColumn">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkChoose" runat="server" Checked='<%# Eval("RESSHT_ISSHORTLIST") %>'
                                                            Enabled='<%# Eval("RESSHT_ISSHORTLIST").ToString()  == "True" ? false:true %>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumn"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_viewShortListed" runat="server" OnCommand="lnk_viewShortListed_Command"
                                                            CommandArgument='<%# Eval("APPLICANT_ID") %>' meta:resourcekey="lnk_viewShortListed"
                                                            Text="View"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Applicant Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblJRID" runat="server" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblAppID" runat="server" Text='<%# Eval("APPLICANT_ID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblAppCode" runat="server" Text='<%# Eval("APPLICANT_CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn2" HeaderText="Applicant Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppName" runat="server" Text='<%# Eval("APPLICANTNAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn3" HeaderText="Date of Birth">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("APPLICANT_DOB") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn4" HeaderText="Gender">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("APPLICANT_GENDER") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%-- <telerik:GridTemplateColumn UniqueName="TemplateColumn5" HeaderText = "Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaritalStatus" runat="server" Text='<%# Eval("APPLICANT_STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn5" HeaderText="Marital Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMaritalStatus" runat="server" Text='<%# Eval("APPLICANT_MARITALSTATUS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="TemplateColumn6" HeaderText="Nationality">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNationality" runat="server" Text='<%# Eval("APPLICANT_NATIONALITY_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7"></td>
                            </tr>
                        </table>
                        <%--   </asp:Panel>--%>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
        <tr>
            <td style="width: 90px"></td>
            <td style="width: 108px"></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>