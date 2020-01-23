<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsAppraisalnew.aspx.cs" Inherits="PMS_frm_PmsAppraisalnew" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <%-- <telerik:RadFormDecorator ID="RadFormDec1" runat="server" DecoratedControls="GridFormDetailsViews"
        EnableRoundedCorners="true" />--%>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Appr" runat="server" Text="My Self Appraisal" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td>
                            <telerik:RadMultiPage ID="Rm_Appraisal_PAGE" runat="server" SelectedIndex="0" meta:resourcekey="Rm_Appraisal_PAGEResource1">
                                <telerik:RadPageView ID="Rp_Appraisal_VIEWDETAILS" runat="server" Selected="True"
                                    meta:resourcekey="Rp_Appraisal_VIEWDETAILSResource1">
                                    <table align="center">
                                        <tr>
                                            <td colspan="3" align="center"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" AutoPostBack="True" Width="200px"
                                                    MarkFirstMatch="true" Filter="Contains">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" ControlToValidate="rcmb_EmployeeType"
                                                    runat="server" ValidationGroup="Controls5" ErrorMessage="Please Select Employee"
                                                    InitialValue="Select" meta:resourcekey="rfv_rcmb_EmployeeTypeResource1">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_RpMgr" runat="server" Text="Reporting Manager" meta:resourcekey="lbl_RpMgrResource1"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadTextBox ID="rtxt_RpMgr" runat="server" MaxLength="40" meta:resourcekey="rtxt_RpMgrResource1">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LBL_AppraisalCycle" runat="server" Text="Appraisal Cycle"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <%-- <telerik:RadTextBox ID="rtxt_AppraisalCycle" runat="server" MaxLength="40" >
                                                </telerik:RadTextBox>--%>
                                                <telerik:RadComboBox ID="rtxt_AppraisalCycle" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                    MaxHeight="120px" AutoPostBack="True" OnSelectedIndexChanged="rtxt_AppraisalCycle_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                                <asp:Label ID="lbl_type_text" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lbl_rolekra" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbl_GpMgr" runat="server" Text="Group Manager"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_GpMgr" runat="server" MaxLength="40" meta:resourcekey="rtxt_GpMgrResource1">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Role" runat="server" Text="Role"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadTextBox ID="rtxt_Role" runat="server" MaxLength="40" meta:resourcekey="rtxt_RoleResource1">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbl_Appraisal_Date" runat="server" Text="Appraisal Date"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtp_DATEofAppraisal" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>
                                            <%--<td>
                                                <asp:Label ID="lbl_Project" runat="server" Text="Project"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Project" runat="server" MaxLength="40" meta:resourcekey="rtxt_ProjectResource1">
                                                </telerik:RadTextBox>
                                            </td>--%>
                                            <td>
                                                <asp:Label ID="lbl_Apprais_id" runat="server" Text="Appraisal Cycle" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td>
                                                <asp:Label ID="lbl_Appraisal_Date" runat="server" Text="Appraisal Date"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadDatePicker ID="rdtp_DATEofAppraisal" runat="server">
                                                </telerik:RadDatePicker>
                                            </td>--%>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td align="left"></td>
                                        </tr>
                                        <tr>
                                            <asp:Label ID="lbl_final" Visible="false" runat="server"></asp:Label>
                                        </tr>
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="Controls5" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                                    </table>
                                    <table align="center">
                                        <tr>
                                            <td align="center">
                                                <telerik:RadGrid ID="RG_SelfAppraisal" runat="server" AutoGenerateColumns="False"
                                                    ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true"
                                                    GridLines="None" AllowFilteringByColumn="False" Width="700px">
                                                    <MasterTableView>
                                                        <Columns>
                                                            <%-- <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" UniqueName="Check">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                                            Text="Check All" />
                                                                    </HeaderTemplate>
                                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                                                        
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </telerik:GridTemplateColumn>--%>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_ROLEKRA_ID" runat="server" Text='<%# Eval("ROLEKRA_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_FINAL" runat="server" Text='<%# Eval("FINAL") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_FIXED" runat="server" Text='<%# Eval("FIXED") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_EMP_FIXED" runat="server" Text='<%# Eval("EMP_FIXED") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Type" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_type" runat="server" Text='<%# Eval("A") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Type">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("B") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>

                                                            <telerik:GridBoundColumn HeaderText="Name" DataField="NAME">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Objective" DataField="Objective_ID" Visible="False">
                                                            </telerik:GridBoundColumn>

                                                            <%-- <telerik:GridTemplateColumn HeaderText="Rating" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                       <telerik:RadRating ID="rdrtg_rating" runat="server" ItemCount="5" Precision="Exact"
                                                                       Value='<%# Convert.ToDouble(Eval("TARGET_ACHIEVED")) %>' />
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>  --%>
                                                            <%--<telerik:GridTemplateColumn HeaderText="Comments" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                       <telerik:RadTextBox ID="rtxt_comments" runat="server" TextMode="MultiLine" Text='<%# Eval("EMP_COMMENTS") %>' MaxLength="100"></telerik:RadTextBox>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>  --%>
                                                            <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit" ItemStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("ROLEKRA_ID") %>'
                                                                        CommandName='<%# Eval("A") %>' meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td align="center">
                                           <asp:Button ID="btn_Submit" runat="server" Text="Submit" 
                                                    onclick="btn_Submit_Click" />
                                           <asp:Button ID="btn_Finalise" runat="server" Text="Finalize" 
                                                    onclick="btn_Finalise_Click" />
                                             <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" 
                                                    onclick="btn_Cancel_Click" />      
                                            </td>
                                            </tr>--%>
                                    </table>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RP_Appraisal_Detail" runat="server" Selected="True">
                                    <table align="center">
                                        <tr>
                                            <td align="center" colspan="4">
                                                <b>Details</b>
                                            </td>
                                        </tr>
                                        <tr id="tr_Kraname" runat="server" visible="false">
                                            <td>
                                                <asp:Label ID="lbltype_detail" runat="server" Text="KRA Name"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbltype_detail_text" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr id="TR_OBJ_NAME" runat="server" visible="false">
                                            <td>
                                                <asp:Label ID="lbl_rolekra_detail" runat="server" Text="Objective Name"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_rolekra_detail_text" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr id="TR1" runat="server" visible="false">
                                            <td>
                                                <asp:Label ID="lbl_types" runat="server" Text="Type"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_tydet" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr id="TR2" runat="server" visible="false">
                                            <td>
                                                <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblnamedt" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_rtng_detail" runat="server" Text="Rating"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <%--<telerik:RadRating ID="rtng_detail" runat="server" ItemCount="5" Precision="Exact" ValidationGroup="Controls"></telerik:RadRating>--%>
                                                <telerik:RadNumericTextBox ID="rtng_detail" runat="server" MaxLength="4" MaxValue="5"
                                                    MinValue="0" SkinID="1" Width="50px">
                                                </telerik:RadNumericTextBox><asp:Label ID="LBL_OJID" runat="server" Text="Label" Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtng_detail" runat="server" Text="*" ControlToValidate="rtng_detail"
                                                    ErrorMessage="Please Enter Rating" ValidationGroup="Controls">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Comments_detail" runat="server" Text="Comments"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Comments_detail" runat="server" Height="200px" TextMode="MultiLine"
                                                    SkinID="1" Width="800px" ValidationGroup="Controls">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_Comments_detail" runat="server" Text="*"
                                                    ErrorMessage="Please Enter Comments" ControlToValidate="rtxt_Comments_detail"
                                                    ValidationGroup="Controls">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Button ID="btn_Submit_Detail" runat="server" Text="Submit" ValidationGroup="Controls"
                                                    CausesValidation="true" OnClick="btn_Submit_Detail_Click" />
                                                <asp:Button ID="btn_Finalise_Detail" runat="server" Text="Finalize" CausesValidation="true"
                                                    ValidationGroup="Controls" OnClick="btn_Finalise_Detail_Click" />
                                                <asp:Button ID="btn_Cancel_Detail" runat="server" Text="Cancel" OnClick="btn_Cancel_Detail_Click" />
                                                <asp:ValidationSummary ID="vs_SelfAppraisal" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="Controls" />
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>