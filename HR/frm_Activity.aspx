<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Activity.aspx.cs" Inherits="HR_frm_Activity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cphActivityUniformMapping" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript"></script>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_ActivityUniformMapping" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_ActivityUniformMapping" runat="server" Font-Bold="True"
                    Text="Activity"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxManagerProxy ID="RAM_ActivityUniformMapping" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="Rg_ActivityUniformMapping">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManagerProxy>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_DPT_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Actvities" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_Actvities_NeedDataSource">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="DEPARTMENT_ID" UniqueName="DEPARTMENT_ID" HeaderText="ID"
                                                    meta:resourcekey="DEPARTMENT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_ACTIVITY_NAME" UniqueName="SMHR_ACTIVITY_NAME"
                                                    AllowFiltering="true" HeaderText="Name "
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_ACTIVITY_PROTECTIVEUNIFORM_NAME" UniqueName="SMHR_ACTIVITY_PROTECTIVEUNIFORM_NAME"
                                                    AllowFiltering="true" HeaderText="Protective Uniform" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_ACTIVITY_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command"
                                                        CommandArgument='<%# Eval("SMHR_ACTIVITY_ID") %>'
                                                        meta:resourceKey="lnk_Add">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>

                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Activity_ADDView" runat="server">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lbl_ActivityID" runat="server" Visible="False"></asp:Label>

                                    <br />
                                    <br />
                                </td>
                                <td></td>
                            </tr>

                            <tr align="center">
                                <td align="left">
                                    <asp:Label ID="lbl_ActivityName" runat="server" meta:resourcekey="lbl_ActivityName" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rad_Activity" runat="server" Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_Activityname" runat="server" ControlToValidate="rad_Activity"
                                        ErrorMessage="Please Enter Name" Text="*" ValidationGroup="Controls" ForeColor="Red"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_UniformName" runat="server" Text="Protective Uniform" meta:resourcekey="lbl_UniformName"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_UniformName" runat="server" meta:resourcekey="rcmb_UniformName"
                                        MarkFirstMatch="true" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_UniformName" runat="server" ControlToValidate="rcmb_UniformName"
                                        ErrorMessage="Please Select Protective Uniform" Text="*" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                                <%--<td>
                                    
                                </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Description" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rad_Description" runat="server" Skin="WebBlue" MaxLength="200">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_IsActive" runat="server" Text="IsActive:"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="rad_IsActive" runat="server" Enabled="false"></asp:CheckBox>
                                </td>

                            </tr>
                            <tr>
                                <td></td>

                            </tr>


                        </table>
                        <table align="center">
                            <tr>
                                <td align="center" colspan="3">
                                    <br />
                                    <asp:Button ID="BTN_SAVE" runat="server" Text="Save" OnClick="btn_submit_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_submit_Click" ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                    <asp:ValidationSummary ID="vsAcitvity" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>