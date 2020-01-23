<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_TrainingCosts.aspx.cs" Inherits="HR_TRAINING_frm_TrainingCosts" Title="Untitled Page" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <telerik:RadAjaxManagerProxy ID="RAM_MedicalBenfitClaim" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_MedicalBenfitClaim">
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
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_scheme" runat="server" Text="Training Costs" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_InteretsQuarters" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_InteretsQuarters_NeedDataSource" 
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="TRAININGCOST_COURSESCHEDULE_ID" UniqueName="TRAININGCOST_COURSESCHEDULE_ID"
                                                            HeaderText="ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="CourseSchedule_Name" UniqueName="CourseSchedule_Name"
                                                            HeaderText="Course Schedule">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridNumericColumn DataField="TRAININGCOST_AMOUNT" UniqueName="TRAININGCOST_AMOUNT" HeaderText="Amount" FilterControlWidth="100px" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>

                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1"
                                                            AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("TRAININGCOST_COURSESCHEDULE_ID") %>'
                                                                    OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
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
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>

                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="40%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_CourseName" runat="server" Text="Course Name"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_CourseName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_CourseName_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfv_CourseName" runat="server" Text="*"
                                                ControlToValidate="rcmb_CourseName" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Course Name"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_CourseSchedule" runat="server" Text="Course Schedule"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_CourseSchedule" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_CourseSchedule_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfv_CourseSchedule" runat="server" Text="*"
                                                ControlToValidate="rcmb_CourseSchedule" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Course Schedule"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <telerik:RadGrid ID="Rg_Costs" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" AllowFilteringByColumn="false" Skin="WebBlue"
                                                Visible="false">
                                                <MasterTableView CommandItemDisplay="None">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="TRAININGCOST_TYPE_ID" UniqueName="TRAININGCOST_TYPE_ID" HeaderText="TRAININGCOST_TYPE_ID"
                                                            Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="TRAININGCOST_TYPE_NAME" UniqueName="TRAININGCOST_TYPE_NAME" AllowFiltering="false"
                                                            HeaderText="Cost Type" meta:resourcekey="TRAININGCOST_TYPE_NAME" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Amount" UniqueName="Amount">
                                                            <ItemTemplate>
                                                                <telerik:RadNumericTextBox ID="txt_Amount" CssClass="setWidth" runat="server"
                                                                    Text='<%# Eval("TRAININGCOST_AMOUNT") %>'
                                                                    ValidationGroup="Controls" MaxLength="7" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0">
                                                                </telerik:RadNumericTextBox>
                                                                <asp:RequiredFieldValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Amount"
                                                                    Text="*" ErrorMessage="Please Enter Amount" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>

                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                ValidationGroup="Controls" Text="Save" Visible="False" />
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Save_Click"
                                                ValidationGroup="Controls" Text="Update" Visible="False" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Save" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
