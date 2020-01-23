<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_PmsApproverAppraisalnew.aspx.cs" Inherits="PMS_frm_PmsApproverAppraisalnew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <%--<telerik:RadFormDecorator ID="RadFormDec1" runat="server" DecoratedControls="GridFormDetailsViews"
        EnableRoundedCorners="true" />--%>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Appr" runat="server" Text="Approver Appraisal" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td>
                            <telerik:RadMultiPage ID="Rm_Appraisal_PAGE" runat="server" SelectedIndex="0" ScrollBars="Auto"
                                meta:resourcekey="Rm_Appraisal_PAGEResource1">
                                <telerik:RadPageView ID="Rp_Appraisal_VIEWDETAILS" runat="server" Selected="True"
                                    meta:resourcekey="Rp_Appraisal_VIEWDETAILSResource1">

                                    <table align="center">
                                        <tr>
                                            <td colspan="3" align="center"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_BU" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcmb_BU" runat="server" MarkFirstMatch="true"
                                                    MaxHeight="120px" AutoPostBack="True" Filter="Contains"
                                                    OnSelectedIndexChanged="rcmb_BU_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_BU" ControlToValidate="rcmb_BU"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Business Unit"
                                                    InitialValue="Select">*</asp:RequiredFieldValidator>
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
                                                <telerik:RadComboBox ID="rtxt_AppraisalCycle" runat="server"
                                                    MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="rtxt_AppraisalCycle_SelectedIndexChanged" Filter="Contains">
                                                </telerik:RadComboBox>
                                                <asp:Label ID="lbl_type_text" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lbl_rolekra" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td></td>

                                            <td>
                                                <asp:Label ID="lbl_RpMgr" runat="server" Text="Reporting Manager" meta:resourcekey="lbl_RpMgrResource1"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadTextBox ID="rtxt_RpMgr" runat="server" MaxLength="40"
                                                    meta:resourcekey="rtxt_RpMgrResource1">
                                                </telerik:RadTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="rcmb_EmployeeType" runat="server" AutoPostBack="True"
                                                    Width="200px" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains"
                                                    OnSelectedIndexChanged="rcmb_EmployeeType_SelectedIndexChanged">
                                                </telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rcmb_EmployeeType" ControlToValidate="rcmb_EmployeeType"
                                                    runat="server" ValidationGroup="Controls" ErrorMessage="Please Select Employee"
                                                    InitialValue="Select" meta:resourcekey="rfv_rcmb_EmployeeTypeResource1">*</asp:RequiredFieldValidator>
                                            </td>

                                            <td>
                                                <asp:Label ID="lbl_GpMgr" runat="server" Text="Group Manager"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_GpMgr" runat="server" MaxLength="40"
                                                    meta:resourcekey="rtxt_GpMgrResource1">
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
                                                <telerik:RadTextBox ID="rtxt_Role" runat="server" MaxLength="40"
                                                    meta:resourcekey="rtxt_RoleResource1">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbl_Project" runat="server" Text="Project"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_Project" runat="server" MaxLength="40"
                                                    meta:resourcekey="rtxt_ProjectResource1">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Apprais_id" runat="server" Text="Appraisal Cycle" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <asp:Label ID="lbl_final" Visible="false" runat="server"></asp:Label>
                                        </tr>
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="Controls" meta:resourcekey="vs_AppraisalDiscussionResource1" />
                                    </table>

                                    <table align="center">
                                        <tr>
                                            <td align="center">
                                                <telerik:RadGrid ID="RG_ApprAppraisal" runat="server" AutoGenerateColumns="False"
                                                    ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true"
                                                    GridLines="None" AllowFilteringByColumn="False" Width="700px">
                                                    <MasterTableView>
                                                        <Columns>
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
                                                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_APPR_FIXED" runat="server" Text='<%# Eval("APPR_FIXED") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Type">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_type" runat="server" Text='<%# Eval("A") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn HeaderText="Name" DataField="NAME">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Weightage" DataField="WEIGHTAGE" AllowFiltering="false">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn HeaderText="Target" DataField="TARGET">
                                                            </telerik:GridBoundColumn>
                                                            <%--<telerik:GridTemplateColumn HeaderText="Employee Rating" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                       <telerik:RadRating ID="rdrtg_rating" runat="server" ItemCount="5"  Enabled="false" Precision="Exact"
                                                                       Value='<%# Convert.ToDouble(Eval("TARGET_ACHIEVED")) %>' />
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>  
                                                                  <telerik:GridTemplateColumn HeaderText="Employee Comments" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                       <telerik:RadTextBox ID="rtxt_comments" runat="server" TextMode="MultiLine" Text='<%# Eval("EMP_COMMENTS") %>' 
                                                                        Enabled="false" MaxLength="100"></telerik:RadTextBox>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>   
                                                                <telerik:GridTemplateColumn HeaderText="Manager Rating" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                       <telerik:RadRating ID="rdrtg_mgr_rating" runat="server" ItemCount="5" Precision="Exact" 
                                                                       Value='<%# Convert.ToDouble(Eval("MGR_RATING")) %>' />
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>  
                                                                  <telerik:GridTemplateColumn HeaderText="Manager Comments" AllowFiltering="false">
                                                                    <ItemTemplate>
                                                                       <telerik:RadTextBox ID="rtxt_mgr_comments" runat="server" TextMode="MultiLine" Text='<%# Eval("MGR_COMMENTS") %>' 
                                                                       MaxLength="100"></telerik:RadTextBox>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>--%>
                                                            <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("ROLEKRA_ID") %>' CommandName='<%# Eval("A") %>'
                                                                        meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--<table align="center">
                                            <tr id="tr_final_rtng" runat="server">
                                            <td>
                                            <asp:Label ID="lbl_finalrtng" runat="server" Text="Final&nbsp;Rating" ></asp:Label>
                                            </td>
                                            <td>
                                            <b>:</b>
                                            </td>
                                            <td>
                                            <telerik:RadRating ID="rdt_final_rtng" runat="server" ItemCount="5"  Enabled="false"  Precision="Exact"></telerik:RadRating>
                                            </td>
                                            </tr>
                                            <tr id="tr_final_comments" runat="server">
                                            <td>
                                            <asp:Label ID="lbl_final_comments" runat="server" Text="Comments"></asp:Label>
                                            </td>
                                            <td>
                                            <b>:</b>
                                            </td>
                                            <td>
                                            <telerik:RadTextBox ID="rtxt_final_comments" runat="server" TextMode="MultiLine"  MaxLength="100"></telerik:RadTextBox>
                                            </td>
                                            </tr>
                                            <tr >
                                            <td align="center" colspan="3">
                                           <asp:Button ID="btn_Approve" runat="server" Text="Approve" 
                                                    onclick="btn_Approve_Click" />    
                                            </td>
                                            </tr>
                                            
                                        </table>--%>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RP_Appraisal_Detail" runat="server" Selected="true">
                                    <table align="center">
                                        <tr>
                                            <td align="center" colspan="4">
                                                <b>Details</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbltype_detail" runat="server" Text="Type"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbltype_detail_text" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_rolekra_detail" runat="server" Text="Name"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_rolekra_detail_text" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_emp_rtng" runat="server" Text="Employee&nbsp;Rating"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadRating ID="rtng_emp_detail" runat="server" ItemCount="5" Precision="Exact" Enabled="false"></telerik:RadRating>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_emp_Comments" runat="server" Text="Employee&nbsp;Comments"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_emp_Comments_Detail" runat="server" Height="200px" TextMode="MultiLine" SkinID="1"
                                                    Width="800px" Enabled="false">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_rtng_mgr_detail" runat="server" Text="Manager&nbsp;Rating"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadRating ID="rtng_mgr_detail" runat="server" ItemCount="5" Precision="Exact" Enabled="false"></telerik:RadRating>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_mgr_Comments_detail" runat="server" Text="Manager&nbsp;Comments"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_mgr_Comments_detail" runat="server" Height="200px" TextMode="MultiLine" SkinID="1"
                                                    Width="800px" Enabled="false">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_appr_rtng_detail" runat="server" Text="Approver&nbsp;Rating"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadRating ID="rtng_appr_Detail" runat="server" ItemCount="5" Precision="Exact"></telerik:RadRating>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_appr_Comments_Detail" runat="server" Text="Approver&nbsp;Comments"></asp:Label>
                                            </td>
                                            <td>
                                                <b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="rtxt_appr_Comments_Detail" runat="server" Height="200px" TextMode="MultiLine" SkinID="1"
                                                    Width="800px" ValidationGroup="Controls">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_rtxt_appr_Comments_Detail" runat="server" Text="*"
                                                    ErrorMessage="Please Enter Approver Comments" ControlToValidate="rtxt_appr_Comments_Detail" ValidationGroup="Controls">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Button ID="btn_Approve_Detail" runat="server" Text="Approve" ValidationGroup="Controls"
                                                    CausesValidation="true" OnClick="btn_Approve_Detail_Click" />
                                                <asp:Button ID="btn_Cancel_Detail" runat="server" Text="Cancel"
                                                    OnClick="btn_Cancel_Detail_Click" />
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