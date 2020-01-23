<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Smhr_HRA.aspx.cs" Inherits="PMS_frm_Smhr_HRA" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Smhr_HRA.aspx.cs" Inherits="PMS_frm_Smhr_HRA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">

    <script language="javascript">
     function confirm_Period() {
         if (confirm("Are you sure you want to Confirm the Feedback?. After Giving you cannot change.") == true)
             return true;
         else
             return false;
     }
    </script>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_SMHR_HRA" runat="server" Font-Bold ="true"  Text="HRA Exemption Calculation"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td align="left">
                            <asp:Label ID="LBL_BUSINESSUNIT" runat="server" Text="Business&nbsp;Unit  :"></asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox  ID="rcm_bu_type" AutoPostBack="true" MarkFirstMatch="true"
                                runat="server" OnSelectedIndexChanged="rcm_bu_type_SelectedIndexChanged" Filter="Contains">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcm_bu" runat="server" ControlToValidate="rcm_bu_type"
                                ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                  
                    <%--<tr>
                        <td align="left">
                            <asp:Label ID="lbl_payitem" runat="server" Text="Recurring Payitem  :"></asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox  ID="rcm_Recur_payitem" AutoPostBack="true"
                                runat="server">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_recur_payitem" runat="server" ControlToValidate="rcm_Recur_payitem"
                                ErrorMessage="Please select Recurring Payitem" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td>
                            <asp:Label ID="lbl_ExcessPayitems" runat="server" Text="Select PayItems  :"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadListBox ID="rlb_ExcessPayitems" runat="server" CheckBoxes="true" 
                                Height="100px" Width="200px">
                            </telerik:RadListBox>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>--%>
                         <tr id="tr_prd" runat ="server">
                         <td>
                                <asp:Label ID="lbl_Period" runat="server" Text="Financial Period"></asp:Label>
                          </td>
                            <td>
                                 <telerik:RadComboBox ID="ddl_Period" runat="server"  AutoPostBack="true" MarkFirstMatch="true" 
                                     onselectedindexchanged="ddl_Period_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                            </td>
                      
                    <td>
                        <asp:RequiredFieldValidator ID="RFV_Period" runat="server" ControlToValidate="ddl_Period"
                            ErrorMessage="Please Select Financial Period" InitialValue="Select" SetFocusOnError="True" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lbl_TaxExemptedelements" runat="server" Text="Tax Exempted Master  :"></asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox  ID="rcm_TaxExemptedelements" runat="server" 
                                MarkFirstMatch="true" AutoPostBack="true" Filter="Contains">                               
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_TaxExemptedelements" runat="server" ControlToValidate="rcm_TaxExemptedelements"
                                ErrorMessage="Please Select Tax Exempted Master" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                  
                    <caption>
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button ID="btn_view" runat="server" OnClick="btn_view_Click" Text="View" ValidationGroup="Controls" />
                            </td>
                        </tr>
                    </caption>
                   
                </table>
                <br />
                <br />
                <table align="center">
                    <tr>
                        <td colspan="3">
                            <telerik:RadGrid ID="Rg_EmployeeTaxHra" runat="server" AutoGenerateColumns="False"
                                GridLines="None" Skin="WebBlue" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                                <MasterTableView CommandItemDisplay="Top">
                                    <Columns>
                                     <telerik:GridTemplateColumn HeaderText="Check All">
                                         <HeaderTemplate>
                                           <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged" Text="Check All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk_Select"></asp:CheckBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Employee Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LBL_EMP_ID" runat="server" Text='<%# Eval("EMPSALDTLS_EMPID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <%--<telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_select" runat="server"/>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>--%>
                                        <telerik:GridBoundColumn DataField="EMP_NAME" UniqueName="EMP_NAME" HeaderText="Employee Name"
                                            AllowFiltering="false">
                                         <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Own Property">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_ownedprop" runat="server" AutoPostBack="true" OnCheckedChanged="chk_ownedprop_checkedchange" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="40 or 50 % Of Basic">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TXT_40ofbasic" runat="server" ReadOnly="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Actual HRA">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TXT_hra" runat="server" ReadOnly="true" Text='<%# Eval("employeehra") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Rent Paid">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="rnt_TXT_ACTUALRENT"  runat="server" AutoPostBack="true"  MinValue="0" MaxLength="12"
                                                  OnTextChanged="rnt_TXT_ACTUALRENT_textchanged">
                                                     
                                                </telerik:RadNumericTextBox>
                                                  
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                     <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Rent Paid In Excess Of 10% Of Basic ">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="TXT_EXCESSAMOUNT10" Text='<%# Eval("EXCESS10") %>' runat="server"
                                                    ReadOnly="true" >
                                                    
                                                  
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                         <telerik:GridTemplateColumn HeaderText="Only 10% Basic">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_excess" runat ="server" Text='<%# Eval("EXCESS10") %>'   visible="true"  />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                                                                    
                                          
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Exempted HRA">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TXT_EXCESSAMOUNTL" runat="server" ReadOnly="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Limit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TXT_Limit" runat="server" ReadOnly="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Employee Grade">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <CommandItemTemplate>
                                        <div align="right">
                                        </div>
                                    </CommandItemTemplate>
                                </MasterTableView>
                                <PagerStyle AlwaysVisible="True" />
                                <FilterMenu >
                                </FilterMenu>
                                <HeaderContextMenu >
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btn_calculate" runat="server" Text="Calculate" OnClick="btn_calculate_Click" />
                            <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                            <asp:Button ID="btn_Finalise" runat="server" Text="Finalise" 
                                 onclick="btn_Finalise_Click" />
                            <asp:ValidationSummary ID="vs_SMHR_HRA" runat="server" ShowMessageBox="True" ShowSummary="False"
                                ValidationGroup="Controls" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
