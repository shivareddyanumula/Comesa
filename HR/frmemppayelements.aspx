<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmemppayelements.aspx.cs" Inherits="HR_frmemppayelements" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_PayElements" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rcmb_Employee">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcb_BussinessUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Rg_SalaryStruct">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <script type="text/javascript" src="../maintainScrollPosition_IE.js"></script>
    <table align="center" style="width: 85%" >
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="RMP_SalaryStruct" runat="server" Font-Bold="True" Style="z-index: 10" Width="1014px" 
                     ScrollBars="Auto" SelectedIndex="0">
                    <telerik:RadPageView ID="RP_SalaryStruct_AddUpdate" runat="server" Selected="True">
                        <table align="center" style="width: 100%">
                          
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_SalaryDetails" runat="server" Font-Bold="True" meta:resourcekey="lbl_SalaryDetails"></asp:Label><br />
                                    <br />
                                    <br />
                                    <table style="width: 50%">
                                        <tbody>
                                            <tr>
                                                <td colspan="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_BusUnit" runat="server" meta:resourcekey="lbl_BusUnit"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>: </b>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox Skin="WebBlue" ID="rcb_BussinessUnit" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                        MaxHeight="200px" AutoPostBack="True" OnSelectedIndexChanged="rcb_BussinessUnit_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="rfv_BusinessUnit" runat="server" ControlToValidate="rcb_BussinessUnit"
                                                        InitialValue="Select" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_BusinessUnit"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Value" runat="server" Visible="False" meta:resourcekey="lbl_Value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Employee" runat="server" meta:resourcekey="lbl_Employee"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>: </b>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="rcb_Employee" Skin="WebBlue" runat="server" MarkFirstMatch="true"
                                                        MaxHeight="200px" OnSelectedIndexChanged="rcb_Employee_SelectedIndexChanged"
                                                        AutoPostBack="True" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" ControlToValidate="rcb_Employee"
                                                        InitialValue="Select" Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_Employee"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_SalaryStruct" runat="server" meta:resourcekey="lbl_SalaryStruct"></asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="rtxt_SalaryStruct" runat="server" Skin="WebBlue" ReadOnly="true">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Positions" runat="server" meta:resourcekey="lbl_Positions"></asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="rtxt_Positions" runat="server" Skin="WebBlue" ReadOnly="true">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Jobs" runat="server" meta:resourcekey="lbl_Jobs"></asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="rtxt_Jobs" runat="server" Skin="WebBlue" ReadOnly="true">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Basic" runat="server" meta:resourcekey="lbl_Basic"></asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="rtxt_Basic" runat="server" Skin="WebBlue" ReadOnly="true">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                        ValidationGroup="Controls" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="5">
                                                    <asp:ValidationSummary ID="vs_Salary" runat="server" meta:resourcekey="vs_Salary"
                                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td  align="center">
                                    <table align="center" style="width: 50%">
                                        <tr>
                                            <td style="width: 98%" align="left">
                                                <asp:Label ID="lbl_Message" runat="server" Text="(Note: Percentages specified are in corresponding with Basic)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 98%">
                                                <telerik:RadGrid ID="RG_SalaryStruct" runat="server" AutoGenerateColumns="False" 
                                                     GridLines="None" meta:resourcekey="RG_SalaryStruct" OnItemDataBound="RG_SalaryStruct_ItemDataBound" >
                                                    <MasterTableView>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderText="Select" meta:resourcekey="GridTemplateColumn"
                                                                UniqueName="TemplateColumn">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk_Choose" runat="server"  AutoPostBack="true" OnCheckedChanged="chk_Choose_CheckedChanged1" />
                                                                    <asp:Label ID="lblIsEnabled" runat="server" Visible="false" Text='<%# Eval("IsEnabled") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn meta:resourcekey="code" UniqueName="Code" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPAYITEM_ID" runat="server" Text='<%# Eval("PAYITEM_ID") %>'></asp:Label>
                                                                    <asp:TextBox ID="txtMRPID" runat="server" Text='<%# Eval("MPR_ID") %>' Visible="false"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Pay Item" meta:resourcekey="pay" UniqueName="PayItem">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPAYITEMNAME" runat="server" Text='<%# Eval("PAYITEM_PAYITEMNAME") %>'></asp:Label>
                                                                    <asp:Label ID="lblEmpPayItemID" runat="server" Text='<%# Eval("SMHR_EMP_PAYITEMS_ID") %>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Mode" meta:resourcekey="mode" UniqueName="Mode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCALMODE" runat="server" Text='<%# Eval("PAYITEM_CALMODE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="PRCS_TYPE" HeaderText="Process Type" UniqueName="PRCS_TYPE">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Mode" meta:resourcekey="mode" UniqueName="Mode"
                                                                Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCALMODE_1" runat="server" Text='<%# Eval("PAYITEM_CALMODE_1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                         <telerik:GridTemplateColumn HeaderText="Mode" meta:resourcekey="mode" UniqueName="Mode"
                                                                Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_MinimumPercentageValue" runat="server" Text='<%# Eval("PAYITEM_MINIMUM_PERCENTAGE_VALUE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            
                                                            <telerik:GridTemplateColumn HeaderText="Value" meta:resourcekey="value" UniqueName="Value" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtNumber" runat="server" Style="text-align: right" Text='<%# Eval("VALUE") %>'
                                                                        ValidationGroup="Controls" Width="110px" MaxLength="12"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="rfv_Number" runat="server" ControlToValidate="txtNumber"
                                                                        meta:resourcekey="rfv_Number" Text="*" ValidationExpression="^[-+]?[0-9]*\.?[0-9]+$"
                                                                        ValidationGroup="Controls"></asp:RegularExpressionValidator>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>

                                                            <telerik:GridTemplateColumn HeaderText="Value" UniqueName="Amount">
                                                                <ItemTemplate>
                                                                    <telerik:RadNumericTextBox ID="rntbAmount" runat="server"
                                                                        Culture="English (United States)" Text='<%# Eval("VALUE") %>'
                                                                        Skin="WebBlue" Width="10%" Style="text-align: left" Enabled='<%# Convert.ToBoolean(Eval("IsEnabled"))%>' 
                                                                        MaxLength="12" >
                                                                    </telerik:RadNumericTextBox> <%-- Enabled='<%# Eval("IsEnabled") %>'--%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>

                                                            <telerik:GridTemplateColumn HeaderText="Edit Formula" meta:resourcekey="Formula"
                                                                UniqueName="TemplateColumn4" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_Formula" runat="server" CommandName="Formula" meta:resourcekey="lnk_Formula"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>