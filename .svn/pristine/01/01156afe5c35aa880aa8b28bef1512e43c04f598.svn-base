<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_SaveTrgfeedbackquestion.aspx.cs" Inherits="Training_frm_SaveTrgfeedbackquestion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_SaveTrgFeedback_PAGE" runat="server" SelectedIndex="0"
                    ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_SaveTrgFeedback_VIEWMAIN" runat="server" Selected="True">
                        <table>
                            <tr>
                                <td align="center">
                                    <center>
                                        <b>Save Feedback </b>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LBL_DATE" runat="server" Text="Date :">
                 
                 
                                    </asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_strtdate" runat="server" DateInput-EmptyMessage="Date"
                                        AutoPostBack="true" OnSelectedDateChanged="rdtp_strtdate_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_starttime" runat="server" Text="StartTime :">
                 
                 
                                    </asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="rtp_starttime" runat="server" AutoPostBack="true" Enabled="false">
                                    </telerik:RadTimePicker>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_endtime" runat="server" Text="EndTime :">
                 
                 
                                    </asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="rtp_endtime" runat="server" AutoPostBack="true" Enabled="false">
                                    </telerik:RadTimePicker>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Lbl_Trg" runat="server" Text="Training Module :">
                 
                 
                                    </asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcmb_Trg" runat="server" AutoPostBack="true" Filter="Contains"
                                        OnSelectedIndexChanged="Rcmb_Trg_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee :">
                 
                 
                                    </asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="Rcm_Employee" runat="server" AutoPostBack="true" Filter="Contains"
                                        OnSelectedIndexChanged="Rcm_Employee_SelectedIndexChanged" MarkFirstMatch="true">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            
                               <tr id="skil_id" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_skills1" runat="server" Text="Skills"></asp:Label>
                                </td>
                                <td align="right">
                                    :
                                </td>
                                <td>
                                    <telerik:RadListBox ID="rlb_skills1" runat="server" CheckBoxes="true" Height="100px"
                                        Width="200px">
                                    </telerik:RadListBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr runat="server" id="expertise_id">
                                <td>
                                    Existing Expertise :
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Expert" runat="server" Text="lblexpeert" Enabled="false"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" id="CHGEXPERTID">
                                <td>
                                    Change Expertise :
                                </td>
                                <td>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcm_changeExpertise" runat="server" AutoPostBack="false" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Value="0" Text="Select" runat="server" />
                                            <telerik:RadComboBoxItem Value="1" Text="Beginner" runat="server" />
                                            <telerik:RadComboBoxItem Value="2" Text="Intermediate" runat="server" />
                                            <telerik:RadComboBoxItem Value="3" Text="Expert" runat="server" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                               
                            </tr>
                            <tr id="nogradeid" runat="server" visible="false">
                            <td>
                         <asp:Label ID="lbl_nograde" runat="server" Text="Nograde"></asp:Label>
                            </td>
                            <td>
                            :
                            </td>
                            <td>
                            <asp:CheckBox ID="chk_nograde" runat="server" />
                            </td>
                            </tr>
                            
                        </table>
                        <table align="center" width="100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_SaveTrgFeedback" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" Skin="WebBlue" AllowFilteringByColumn="True">
                                        <MasterTableView>
                                            <Columns>
                                                <%-- <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_ID" UniqueName="FEEDBACKQUESTS_ID"
                                                    HeaderText="FEEDBAKQUESTS_ID" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="False" DataField="FEEDBACKQUESTS_ID"
                                                    HeaderText="FEEDBACKQUESTS_ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_feedbk_id" runat="server" Text='<%# Eval("FEEDBACKQUESTS_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" DataField="FEEDBACKQUESTS_QUESTION"
                                                    HeaderText="Question">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_feedbk_question" runat="server" Text='<%# Eval("FEEDBACKQUESTS_QUESTION") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%-- <telerik:GridBoundColumn DataField="FEEDBACKQUESTS_QUESTION" UniqueName="FEEDBACKQUESTS_QUESTION"
                                                    HeaderText="Question" AllowFiltering="False">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <%-- <telerik:GridBoundColumn DataField="FEEDBACKQUES_OPTION1" UniqueName="FEEDBACKQUES_OPTION1" HeaderText="OPTION1">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="False" DataField="FEEDBACKQUESTS_OPTION1"
                                                    HeaderText="Option1">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rd_feedbkoption1" runat="server" Text='<%# Eval("FEEDBACKQUESTS_OPTION1") %>'
                                                            GroupName="select" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" DataField="FEEDBACKQUESTS_OPTION2"
                                                    HeaderText="Option2">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rd_feedbkoption2" runat="server" Text='<%# Eval("FEEDBACKQUESTS_OPTION2") %>'
                                                            GroupName="select" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" DataField="FEEDBACKQUESTS_OPTION3"
                                                    HeaderText="Option3">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rd_feedbkoption3" runat="server" Text='<%# Eval("FEEDBACKQUESTS_OPTION3") %>'
                                                            GroupName="select" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" DataField="FEEDBACKQUESTS_OPTION4"
                                                    HeaderText="Option4">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rd_feedbkoption4" runat="server" Text='<%# Eval("FEEDBACKQUESTS_OPTION4") %>'
                                                            GroupName="select" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu>
                                        </FilterMenu>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <asp:Button ID="btn_save_trgfeedbacques" runat="server" Text="Save" ValidationGroup="Controls43"
                                        OnClick="btn_save_trgfeedbacques_Click" />
                                </td>
                                <td>
                                    <asp:ValidationSummary ID="vs_PROJECT" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls43" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
