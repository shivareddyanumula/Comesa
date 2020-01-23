﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PayItemDefine.aspx.cs" Inherits="Masters_frm_PayItemDefine" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <script language="javascript" type="text/javascript">
        function ShowPopForm(val, payItemID) {
            var win = window.radopen("../DependentAllowance.aspx?val=" + val + "&payItemID=" + payItemID, "rwResult");
            win.center();
            win.set_height("600");
            win.set_width("900");
            win.set_modal(true);
            win.set_status = "";
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
        function OnClientCloseWindow(oWnd, args) {
            document.location.href = "../Masters/frm_PayItemDefine.aspx";
        }
    </script>
    <table align="center" width="55%">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_PayItemHeader" runat="server" Text="Pay Item Details" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_PayItem_page" runat="server" SelectedIndex="0" Height="600px"
                    meta:resourcekey="Rm_PayItem_page">
                    <telerik:RadPageView ID="Rp_PayItem_ViewMain" runat="server" meta:resourcekey="Rp_PayItem_ViewMain"
                        Selected="True">
                        <telerik:RadGrid ID="Rg_PayItems" runat="server" AutoGenerateColumns="False" GridLines="None"
                            OnNeedDataSource="Rg_PayItems_NeedDataSource" AllowPaging="True" meta:resourcekey="Rg_PayItems"
                            AllowFilteringByColumn="true" PageSize="10" Height="355px">
                            <%--  <ClientSettings Scrolling-AllowScroll="true"></ClientSettings>--%>
                            <MasterTableView CommandItemDisplay="Top">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="PAYITEM_ID" UniqueName="PAYITEM_ID" HeaderText="ID"
                                        meta:resourcekey="CATEGORY_ID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PAYITEM_PAYITEMNAME" UniqueName="PAYITEM_PAYITEMNAME"
                                        HeaderText="Name" meta:resourcekey="PAYITEM_PAYITEMNAME" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PAYITEM_PAYDESC" UniqueName="PAYITEM_PAYDESC"
                                        HeaderText="Description" meta:resourcekey="PAYITEM_PAYDESC" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PAYITEM_ITEMTYPE_ID" UniqueName="PAYITEM_ITEMTYPE_ID"
                                        HeaderText="Item Type" meta:resourcekey="PAYITEM_ITEMTYPE_ID" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PAYITEM_ITEMMODE_ID" UniqueName="PAYITEM_ITEMMODE_ID"
                                        HeaderText="Item Mode" meta:resourcekey="PAYITEM_ITEMMODE_ID" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Process Type" DataField="PAYITEM_PROCESSTYPE"
                                        AllowFiltering="true">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PAYITEM_ACCOUNTHEAD" UniqueName="PAYITEM_ACCOUNTHEAD"
                                        HeaderText="Account Code" meta:resourcekey="PAYITEM_ACCOUNTHEAD" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridTemplateColumn UniqueName="_PAYITEM_PRIORITY" HeaderText="Priority"
                                        meta:resourcekey="PAYITEM_PRIORITY">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmb_PayitemPriority" runat="server" AutoPostBack="True" DataTextField="PAYITEM_PRIORITY"
                                                DataValueField="PAYITEM_PRIORITY" OnSelectedIndexChanged="cmb_PayitemPriority_SelectedIndexChanged"
                                                meta:resourcekey="cmb_PayitemPriority">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblPayitemID" runat="server" Text='<%# Eval("PAYITEM_ID") %>' Visible="False"
                                                meta:resourcekey="lblPayitemID"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>--%>
                                    <%--<telerik:GridTemplateColumn UniqueName="PAYITEM_PROCESSTYPE" HeaderText="Process Type"
                                        meta:resourcekey="PAYITEM_PROCESSTYPE" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>--%>
                                    <%-- <asp:Label ID="lbl_payitemprocesstype" runat="server" Text='<%# (Convert.ToString(Eval("PAYITEM_PROCESSTYPE")).ToUpper() == "TRUE" ? "Recurring": "Non Recurring") %>'
                                                meta:resourcekey="lbl_payitemprocesstype"></asp:Label>--%>
                                    <%-- <asp:Label ID="lbl_payitemprocesstype" runat="server" Text='<%# Eval("PAYITEM_PROCESSTYPE") %>'
                                                meta:resourcekey="lbl_payitemprocesstype"></asp:Label>--%>
                                    <%-- </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>--%>
                                    <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumn"
                                        AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PAYITEM_ID") %>'
                                                meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColDelete" meta:resourcekey="ColDelete" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_Delete" runat="server" CommandArgument='<%# Eval("PAYITEM_ID") %>'
                                                meta:resourcekey="lnk_Delete" OnCommand="lnk_Delete_Command" OnClientClick="return confirm('Are you sure you want to delete?')">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <CommandItemTemplate>
                                    <div align="right">
                                        <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command" meta:resourcekey="lnk_Add">Add</asp:LinkButton>
                                    </div>
                                </CommandItemTemplate>
                            </MasterTableView>
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="true" SaveScrollPosition="True" />
                            </ClientSettings>
                            <ActiveItemStyle HorizontalAlign="Left" />
                            <PagerStyle AlwaysVisible="True" />
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_PayItem_ViewDetails" runat="server" meta:resourcekey="Rp_PayItem_ViewDetails">
                        <table align="center">
                            <tr>
                                <td colspan="4" align="center" style="font-weight: bold;">
                                    <asp:Label ID="lbl_PayItemID" runat="server" Text="lbl_PayItemID" Visible="False"></asp:Label>
                                    <%--<asp:Label ID="lbl_CategoryDetails" runat="server" Text="Details" meta:resourcekey="lbl_CategoryDetails"></asp:Label>--%>
                                </td>
                                <%--<td align="center" style="font-weight: bold;">
                                    &nbsp;
                                </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PayItemCode" runat="server" meta:resourcekey="lbl_PayItemCode"
                                        Text="Pay Item Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_PayItemCode" runat="server" Skin="WebBlue" MaxLength="100"
                                        TabIndex="1">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_PayItemCode" runat="server" ControlToValidate="rtxt_PayItemCode"
                                        ErrorMessage="Please Enter PayItem Name" ValidationGroup="Controls" meta:resourcekey="rfv_rtxt_PayItemCode">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PayItemDesc" runat="server" meta:resourcekey="lbl_CategoryNeedBankInfo"
                                        Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_PayItemDesc" runat="server" Skin="WebBlue" MaxLength="100"
                                        TabIndex="2">
                                    </telerik:RadTextBox>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PayItemType" runat="server" meta:resourcekey="lbl_CategoryNeedBankInfo"
                                        Text=" Type"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_PayItemType" runat="server" MarkFirstMatch="true" Skin="WebBlue"
                                        MaxHeight="120px" TabIndex="3" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PayItemType" runat="server" ControlToValidate="rcmb_PayItemType"
                                        ErrorMessage="Please Select Type" ValidationGroup="Controls" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CalculationMode" runat="server" meta:resourcekey="lbl_CalculationMode"
                                        Text="Calculation Mode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_PayCalMode" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        TabIndex="4">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="-1" />
                                            <telerik:RadComboBoxItem runat="server" Text="%Age" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Direct" Value="2" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PayCalMode" runat="server" ControlToValidate="rcmb_PayCalMode"
                                        ErrorMessage="Please Select Calculation Mode" Text="*" InitialValue="Select"
                                        ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_PayItemmode" runat="server" meta:resourcekey="lbl_PayItemmode"
                                        Text="Mode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_PayItemMode" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        AutoPostBack="true" OnSelectedIndexChanged="rcmb_PayItemMode_SelectedIndexChanged" Filter="Contains"
                                        TabIndex="5">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_PayItemMode" runat="server" ControlToValidate="rcmb_PayItemMode"
                                        ErrorMessage="Please Select Mode" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr runat="server" id="trLoanInterest" visible="false">
                                <td>
                                    <asp:Label ID="lblLoanInterest" runat="server" Text="Loan Pay Item"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcbLoanInterest" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                        AutoPostBack="true" OnSelectedIndexChanged="rcbLoanInterest_SelectedIndexChanged"
                                        TabIndex="5" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvLoanInterest" runat="server" ControlToValidate="rcbLoanInterest"
                                        ErrorMessage="Please Select Loan Pay Item" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr id="trProcessType" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_ProcessType" runat="server" meta:resourcekey="lbl_ProcessType"
                                        Text="Loan&nbsp;Process&nbsp;Type"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rb_loanprocesstype" runat="server">
                                        <Items>
                                            <%--<telerik:RadComboBoxItem Value="0" Text="Reducing Balance" />
                                            <telerik:RadComboBoxItem Value="1" Text="Increasing Balance" />--%>
                                            <telerik:RadComboBoxItem Value="2" Text="Standard" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rb_loanprocesstype" runat="server" ControlToValidate="rb_loanprocesstype"
                                        ErrorMessage="Loan Process Type is Mandatory" meta:resourcekey="rfv_rb_loanprocesstype"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trInsurance" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lblTaxRelief" runat="server" Text="Tax Relief"></asp:Label>
                                </td>
                                <td>:</td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rtxtTaxRelief" runat="server" Type="Percent" NumberFormat-DecimalDigits="2" MinValue="0" MaxValue="100"></telerik:RadNumericTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr id="ytd" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_YTDType" runat="server" Text="YTD Type"></asp:Label>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_YTDType" runat="server" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="+ Ve" Value="+ Ve" />
                                            <telerik:RadComboBoxItem runat="server" Text="- Ve" Value="- Ve" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>


                            <tr id="tr_project" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_project" runat="server" Text="Project"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <%--<telerik:RadComboBox ID="rcmb_Project" runat="server" MarkFirstMatch="true" MaxHeight="120px" AutoPostBack="true">
                                    </telerik:RadComboBox>--%>

                                    <telerik:RadListBox ID="rlb_Project" runat="server" CheckBoxes="true" Height="130px" Width="200px" AutoPostBack="true">
                                    </telerik:RadListBox>
                                    <asp:Label ID="lbl_projectlist" runat="server" Visible="False"></asp:Label>
                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ProcessingType" runat="server" Text=" Processing Type" meta:resourcekey="lbl_ProcessingType"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbtn_ProcessingType" runat="server" RepeatDirection="Horizontal" TabIndex="6">

                                        <asp:ListItem Text="Non Recurring" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Recurring" Value="1">
                                        </asp:ListItem>

                                    </asp:RadioButtonList>

                                </td>

                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rbtn_ProcessingType" runat="server" ControlToValidate="rbtn_ProcessingType"
                                        ErrorMessage="Please Select Processing Type" ValidationGroup="Controls" meta:resourcekey="rfv_rbtn_ProcessingType">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Istaxable" runat="server" Text="Is Taxable"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_Istaxable" runat="server" TabIndex="7" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Isbenefitable" runat="server" Text="Is Benefitable"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_Benfit" runat="server" TabIndex="8" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Oaincluded" runat="server" Text="Is Included In Gross" ToolTip="Is Other Allowence Included"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_Oaincluded" runat="server" TabIndex="9" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_AffectLop" runat="server" Text="Is Affecting Lop"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_AffectLop" runat="server" TabIndex="10" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_loanval" runat="server" Text=" Is Loan Validation"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_loanval" runat="server" />

                                </td>
                                <td></td>
                            </tr>
                            
                            <tr>
                                <td>
                                    <asp:Label ID="lblISNullify" runat="server" Text=" Is Nullify"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkISNullify" runat="server" />
                                </td>
                                <td></td>
                            </tr>

                        </table>
                        <table align="center">
                            <tr runat="server" id="trConfig" visible="false">
                                <td>
                                    <asp:Label ID="lbl_scale" runat="server" Text="Grade Wise Allowance"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:Button ID="configure" runat="server" OnClick="configure_Click"
                                        Text="Configure" ValidationGroup="Controls" Visible="true" Width="69px" />
                                </td>
                                <td>
                                    <asp:RadioButtonList runat="server" ID="rblConfigure" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Dependent" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Education" Value="1"></asp:ListItem>
                                        <%--<asp:ListItem Text="Medical" Value="2"></asp:ListItem>--%>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr id="payitem" runat="server" visible="true">
                                <td>
                                    <asp:Label ID="lbl_PayItemAcctHead" runat="server" meta:resourcekey="lbl_CategoryNeedBankInfo"
                                        Text="Account Code"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_AccountHead" runat="server" MaxLength="18" TabIndex="11">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_AccountHead" runat="server" ControlToValidate="rtxt_AccountHead"
                                        ErrorMessage="Please Enter Account Code" meta:resourcekey="rfv_rtxt_AccountHead"
                                        Visible="false" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <%-- <asp:RegularExpressionValidator ID="Rgv_rtxt_AccountHead" runat="server" ControlToValidate="rtxt_AccountHead"
                                        Display="Dynamic" Text="*" ValidationExpression="\d{1}-\d{3,4}-\d{2,3}[-\s]{1}\d{7}"
                                        ErrorMessage="Please Enter Voter Code In Correct Format" ValidationGroup="Controls"></asp:RegularExpressionValidator>--%>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_AccountHead"
                                        ErrorMessage="Please Enter Only Numeric Characters" ValidationExpression="^([0-9]|-)*$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                                <td style="width: 100px">
                                    <asp:Label ID="lbl_Example" runat="server" Text="Ex : 0-0001-01-2110112, 0-884-420-7320103,0-884-420-551-0"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVoteName" runat="server" Text="Account Name"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxtVoteName" runat="server" MaxLength="50" TabIndex="12">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxtVoteName" runat="server" ControlToValidate="rtxtVoteName"
                                        ErrorMessage="Please Enter Account Name" ValidationGroup="Controls" Text="*"></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="revrtxtVoteName" runat="server" ControlToValidate="rtxtVoteName" ErrorMessage="Enter only alpha-numeric characters in Vote Name"
                                        Text="*" ValidationGroup="Controls" ValidationExpression="[a-zA-Z0-9-() ]*"></asp:RegularExpressionValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: right">
                                    <asp:Label ID="lbl_Request" runat="server" Style="font-weight: 700; color: #FF0000"
                                        Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Start" runat="server" meta:resourcekey="lbl_Start" Text="Start Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdt_PayItemStartDate" runat="server" TabIndex="12">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rdt_PayItemStartDate" runat="server" ControlToValidate="rdt_PayItemStartDate"
                                        ErrorMessage="Please Specify Start Date" meta:resourcekey="rfv_rdt_PayItemStartDate"
                                        ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_CategoryNeedBankInfo" runat="server" meta:resourcekey="lbl_CategoryNeedBankInfo"
                                        Text="End Date"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdtp_PayItemEnddate" runat="server" TabIndex="13">
                                    </telerik:RadDatePicker>
                                </td>
                                <td>&nbsp;
                                    <asp:CompareValidator ID="cv_dtp_EndDate" runat="server" ControlToCompare="rdt_PayItemStartDate"
                                        ControlToValidate="rdtp_PayItemEnddate" ErrorMessage="End Date date cannot be less than Start Date"
                                        Operator="GreaterThan" ValidationGroup="Controls">*</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr id="accounttype" runat="server" visible="false">
                                <td>
                                    <asp:Label ID="lbl_AcctType" runat="server" Text="Account Type"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_AccountType" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                                        TabIndex="14">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Select" Value="0" />
                                            <telerik:RadComboBoxItem runat="server" Text="Ledger" Value="Ledger" />
                                            <telerik:RadComboBoxItem runat="server" Text="Vendor" Value="Vendor" />
                                            <telerik:RadComboBoxItem runat="server" Text="No Posting" Value="No Posting" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_AccountType" runat="server" ControlToValidate="ddl_AccountType"
                                        Visible="false" InitialValue="Select" ErrorMessage="Please Select Account Type"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="Posting_Profile" style="display: none;">
                                <td>
                                    <asp:Label ID="lbl_Profile" runat="server" Text="Posting Profile"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txt_PostingProfile" runat="server" MaxLength="10" Skin="WebBlue">
                                    </telerik:RadTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_MinimumValue" runat="server" Text="Minimum  Percentage "></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RNT_MinimumValue" runat="server" Skin="WebBlue" Width="125px"
                                        TabIndex="15" MinValue="0.0" MaxValue="100" MaxLength="3">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_MinimumPensionVlaue" runat="server" ControlToValidate="RNT_MinimumValue"
                                        ErrorMessage="Please Specify Minimum Pension Percentage Value" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_printoptions" runat="server" Text="Print Options" meta:resourcekey="lbl_printoptions"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chk_PrintPaySlip" runat="server" meta:resourcekey="chk_PrintPaySlip"
                                        TabIndex="16" Text="Print in Pay Slip" />
                                </td>
                                <td></td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr runat="server" id="trPrint" visible="false">
                                <td>
                                    <table class="style1" style="width: 100%">
                                        <tr>
                                            <td></td>
                                            <td style="text-align: left"></td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chk_Automatic" runat="server" Text="Automatic" meta:resourcekey="chk_Automatic"
                                                    Visible="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chk_PrintinPayRegister" runat="server" meta:resourcekey="chk_PrintinPayRegister"
                                                    Text="Print in Pay register" Visible="False" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chk_IndividualPrint" runat="server" meta:resourcekey="chk_IndividualPrint"
                                                    Text="Individual Print" Visible="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chk_CTC" runat="server" meta:resourcekey="chk_CTC" Text="CTC" Visible="False" />
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btn_Edit" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        TabIndex="17" Text="Update" ValidationGroup="Controls" Visible="False" Width="61px" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        TabIndex="17" Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                        TabIndex="18" Text="Cancel" CausesValidation="False" />
                                </td>
                                <td align="center">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">&nbsp;
                                    <asp:ValidationSummary ID="vg_PayItems" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            width: 115px;
        }
    </style>
</asp:Content>--%>