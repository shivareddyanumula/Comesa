<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_bonustransaction.aspx.cs" Inherits="frm_bonustransaction" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_Bonus" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="lnk_pastdetails">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtxt_period">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_periodelements">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtxt_businessunit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chk_selectall">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtxt_bonuspercentage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_submit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_approve">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_reject">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btncancelappr">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadScriptBlock ID="rcb_bonushistory" runat="server">

        <script type="text/javascript">
            function Bonus_History() {
                var win = window.radopen('../payroll/bonuspast.aspx', "RW_BonusPast");
                win.center();
                //win.height = 30;
                win.set_modal(true);
            }
        </script>

    </telerik:RadScriptBlock>
    <table align="center">
        <tr>
            <td></td>
            <td>
                <telerik:RadMultiPage ID="rmp_bonus" runat="server" Width="100%" SelectedIndex="0">
                    <telerik:RadPageView ID="rpv_employees" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lbl_header1" runat="server" Text="Selecting Employees For Bonus"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:LinkButton ID="lnk_pastdetails" runat="server" Font-Bold="True" meta:Resourcekey="lnk_pastdetails"
                                        OnClick="lnk_pastdetails_Click" Text="View Past Details"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_businessunit" runat="server" Text="Business Unit"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_colon2" runat="server" Text=":"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rtxt_businessunit" runat="server" MarkFirstMatch="true" AutoPostBack="True" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged"
                                        Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Financial Period
                                </td>
                                <td>
                                    <asp:Label ID="lbl_colon1" runat="server" Text=":"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rtxt_period" runat="server" MarkFirstMatch="true" AutoPostBack="True" OnSelectedIndexChanged="ddl_Period_SelectedIndexChanged"
                                        Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_period" runat="server" Text="Period Elements"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmb_periodelements" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                        OnSelectedIndexChanged="rcmb_periodelements_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_payitemhead" runat="server" Text="Pay Item Head"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_colon3" runat="server" Text=":"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_payitemhead" runat="server" Width="160px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_payitemperiod" runat="server" Text="Pay Item Period"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_colon4" runat="server" Text=":"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_payitemperiod" runat="server" Width="160px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">
                            <tr>
                                <td colspan="4">
                                    <telerik:RadGrid ID="rg_employees" runat="server" AllowFilteringByColumn="False"
                                        AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False" GridLines="None"
                                        Skin="Office2007" Visible="False" Width="900px" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="80px">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                            Text="Check All" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                                        <asp:Label ID="lbl_emp_id" runat="server" Text='<%#Eval("EMP_ID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_empname" runat="server" Text='<%#Eval("Emp_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Department">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_department" runat="server" Text='<%#Eval("DEPARTMENT_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_designation" runat="server" Text='<%#Eval("Employee_POSITIONS_CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade" HeaderStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Attendance" HeaderStyle-Width="70px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_attendance" runat="server" Text='<%#Eval("ATTENDANCE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Bonus Percentage" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_bonuspercentage" runat="server" AutoPostBack="true" EnableEmbeddedSkins="false" Width="60px" SkinID="1" Skin="WebBlue"
                                                            MaxLength="5" Text='<%#Eval("MINIMUM_BONUS_PERCENTAGE") %>' OnTextChanged="rtxt_bonuspercentage13_TextChanged">
                                                        </telerik:RadNumericTextBox>&nbsp;<asp:RangeValidator ID="rgv_rtxt_bonuspercentage" runat="server" ErrorMessage="*"
                                                            Type="Double" MinimumValue='<%#Eval("MINIMUM_BONUS_PERCENTAGE") %>' MaximumValue='<%#Eval("MAXIMUM_BONUS_PERCENTAGE") %>'
                                                            ControlToValidate="rtxt_bonuspercentage">
                                                        </asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:HiddenField ID="hdn_gross" runat="server" />
                                    <asp:Button ID="btn_save" runat="server" OnClick="btnsave_Click" Text="Calculate"
                                        Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpv_bonuscalculation" runat="server">
                        <table>
                            <tr>
                                <td align="center"></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Label ID="ldl_header" runat="server" Text="Bonus Calculation"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="rg_bonuscalculation" runat="server" AllowFilteringByColumn="False"
                                        AllowPaging="false" AllowSorting="True" AutoGenerateColumns="false"
                                        GridLines="None" Width="1100px" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="30px">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chckbtn_Select" runat="server" Checked='<%#Eval("Bonus_Trans_checked") %>' />
                                                        <asp:Label ID="lbl_bonus_id" runat="server" Text='<%#Eval("Bonus_trans_ID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Employee Name" HeaderStyle-Width="120px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_empname" runat="server" Text='<%#Eval("Emp_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Department" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_department" runat="server" Text='<%#Eval("DEPARTMENT_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Designation" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_designation" runat="server" Text='<%#Eval("Employee_POSITIONS_CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade" HeaderStyle-Width="70px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Attendance" HeaderStyle-Width="60px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_attendance" runat="server" Text='<%#Eval("ATTENDANCE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Bonus Percentage" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_bonuspercentage" runat="server" AutoPostBack="true"
                                                            MaxLength="5" OnTextChanged="rtxt_bonuspercentage11_TextChanged" Width="60px" SkinID="1" Skin="WebBlue"
                                                            Text='<%#Eval("Bonus_Percentage") %>'>
                                                        </telerik:RadNumericTextBox>&nbsp;<asp:RangeValidator ID="rgv_rtxt_bonuspercentage" runat="server" ErrorMessage="*"
                                                            Type="Double" MinimumValue='<%#Eval("MINIMUM_BONUS_PERCENTAGE") %>' MaximumValue='<%#Eval("MAXIMUM_BONUS_PERCENTAGE") %>'
                                                            ControlToValidate="rtxt_bonuspercentage">
                                                        </asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Total Value" HeaderStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_bonusvalue" runat="server" Enabled="false"
                                                            Text='<%#Eval("SAL") %>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Bonus Value" HeaderStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_bonus" runat="server" Enabled="false"
                                                            Text='<%#Eval("BONUS_VALUE") %>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="Ex-Gratia" HeaderStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_exgratia" runat="server" Enabled="false"
                                                            Text='<%#Eval("EXGRATIA") %>'>
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <RowIndicatorColumn>
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn>
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btn_submit" runat="server" OnClick="btnsubmit_Click" Text="Submit"
                                        Visible="false" />
                                    <asp:Button ID="btn_cancel" runat="server" OnClick="btncancel_Click" Text="Cancel"
                                        Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpv_bonusapprove" runat="server">
                        <table>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="lbl_header2" runat="server" Text="Approving Bonus"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2"></td>

                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="rg_bonusapprove" runat="server" AllowFilteringByColumn="False"
                                        AllowPaging="false" AutoGenerateColumns="false" AllowSorting="True" GridLines="None"
                                        Width="800px" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="Select" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chckbtn_Select" runat="server" Checked='<%#Eval("Bonus_Trans_checked") %>' />
                                                        <asp:Label ID="lbl_bonus_id" Visible="false" Text='<%#Eval("Bonus_trans_ID") %>'
                                                            runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_empname" runat="server" Text='<%#Eval("Emp_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Department">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_department" runat="server" Text='<%#Eval("DEPARTMENT_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_designation" runat="server" Text='<%#Eval("Employee_POSITIONS_CODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Attendance">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_attendance" runat="server" Text='<%#Eval("ATTENDANCE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Bonus Percentage">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_bonuspercentage" Text='<%#Eval("Bonus_Percentage") %>'
                                                            AutoPostBack="true" OnTextChanged="rtxt_bonuspercentage12_TextChanged" runat="server"
                                                            MaxLength="5">
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RangeValidator ID="rgv_rtxt_bonuspercentage" runat="server" ErrorMessage="*"
                                                            Type="Double" MinimumValue='<%#Eval("MINIMUM_BONUS_PERCENTAGE") %>' MaximumValue='<%#Eval("MAXIMUM_BONUS_PERCENTAGE") %>'
                                                            ControlToValidate="rtxt_bonuspercentage">
                                                        </asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Total Value">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_bonusvalue" Text='<%#Eval("SAL") %>' Enabled="false"
                                                            runat="server">
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Bonus Value">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_bonus" Text='<%#Eval("BONUS_VALUE") %>' Enabled="false"
                                                            runat="server">
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Ex-Gratia">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="rtxt_exgratia" Text='<%#Eval("EXGRATIA") %>' Enabled="false"
                                                            runat="server">
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <RowIndicatorColumn>
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn>
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btn_approve" runat="server" Text="Approve" OnClick="btnapprove_Click"
                                        Visible="false" />
                                    &nbsp;<asp:Button ID="btn_reject" runat="server" Text="Reject" OnClick="btnreject_Click"
                                        Visible="false" />
                                    &nbsp;<asp:Button ID="btncancelappr" runat="server" OnClick="btncancelappr_Click"
                                        Text="Cancel" Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>