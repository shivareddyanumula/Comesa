<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmEmpPayElmntNullify.aspx.cs" Inherits="HR_frmEmpPayElmntNullify" %>

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
                                    <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Text="Employee Pay Item Reversing"></asp:Label><br />
                                    <br />
                                    <table style="width: 50%">
                                        <tbody>

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPeriod" runat="server" Text="Period"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>: </b>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox Skin="WebBlue" ID="rcbPeriod" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                        MaxHeight="200px" AutoPostBack="True" OnSelectedIndexChanged="rcbPeriod_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="rfvPeriod" runat="server" ControlToValidate="rcbPeriod"
                                                        InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please select Period">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPrdDtl" runat="server" Text="Period Detail"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>: </b>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox Skin="WebBlue" ID="rcbPrdDtl" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                        MaxHeight="200px" AutoPostBack="True" OnSelectedIndexChanged="rcbPrdDtl_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="rfvPrdDtl" runat="server" ControlToValidate="rcbPrdDtl"
                                                        InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please select Period Detail">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblTranID" runat="server" Text="Transaction ID"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>: </b>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox Skin="WebBlue" ID="rcbTranID" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                        MaxHeight="200px" AutoPostBack="True" OnSelectedIndexChanged="rcbTranID_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="rfvTranID" runat="server" ControlToValidate="rcbTranID"
                                                        InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please select Transaction ID">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_Value" runat="server" Visible="False" meta:resourcekey="lbl_Value"></asp:Label>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Employee" runat="server" Text="Employee"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>: </b>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="rcbEmployee" Skin="WebBlue" runat="server" MarkFirstMatch="true"
                                                        MaxHeight="200px" OnSelectedIndexChanged="rcbEmployee_SelectedIndexChanged"
                                                        AutoPostBack="True" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="rfvEmployee" runat="server" ControlToValidate="rcbEmployee"
                                                        InitialValue="Select" Text="*" ValidationGroup="Controls" ErrorMessage="Please select Employee">
                                                    </asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="lbl_SalaryStruct" runat="server" Text="Salary Structure"></asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="rtxt_SalaryStruct" runat="server" Skin="WebBlue" ReadOnly="true" Enabled="false">
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
                                                    <asp:Label ID="lbl_Positions" runat="server" Text="Position"></asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="rtxt_Positions" runat="server" Skin="WebBlue" ReadOnly="true" Enabled="false">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Jobs" runat="server" Text="Job"></asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="rtxt_Jobs" runat="server" Skin="WebBlue" ReadOnly="true" Enabled="false">
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
                                                    <asp:Label ID="lbl_Basic" runat="server" Text="Basic Pay"></asp:Label>
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="rtxt_Basic" runat="server" Skin="WebBlue" ReadOnly="true" Enabled="false">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_Save" runat="server" Text="Update" OnClick="btn_Save_Click"
                                                        ValidationGroup="Controls" Visible="false" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" Visible="false" />
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
                                                <asp:Label ID="lbl_Message" runat="server" Text="(Note: Percentages specified are in corresponding with Basic)" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 98%">
                                                <telerik:RadGrid ID="RG_SalaryStruct" runat="server" AutoGenerateColumns="False" Visible="false"
                                                     GridLines="None" meta:resourcekey="RG_SalaryStruct">
                                                    <MasterTableView>
                                                        <Columns>
                                                            <%--<telerik:GridTemplateColumn HeaderText="Select" meta:resourcekey="GridTemplateColumn"
                                                                UniqueName="TemplateColumn" Visible="false">
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
                                                            </telerik:GridTemplateColumn>--%>
                                                            <telerik:GridTemplateColumn HeaderText="Pay Item" meta:resourcekey="pay" UniqueName="PayItem">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPAYITEMNAME" runat="server" Text='<%# Eval("PAYITEM_PAYITEMNAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Mode" meta:resourcekey="mode" UniqueName="Mode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCALMODE" runat="server" Text='<%# Eval("PAYITEM_CALMODE") %>'></asp:Label>
                                                                    <asp:Label ID="lblEmpSalDtsID" runat="server" Text='<%# Eval("EMPSALDTLS_ID") %>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="PRCS_TYPE" HeaderText="Process Type" UniqueName="PRCS_TYPE">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridTemplateColumn HeaderText="Value" UniqueName="Amount">
                                                                <ItemTemplate>
                                                                    <telerik:RadNumericTextBox ID="rntbAmount" runat="server"
                                                                        Culture="English (United States)" Text='<%# Eval("EMPSALDTLS_AMOUNT") %>'
                                                                        Skin="WebBlue" Width="10%" Style="text-align: left"
                                                                        MaxLength="12" Enabled="false">
                                                                    </telerik:RadNumericTextBox>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>

                                                            <telerik:GridTemplateColumn HeaderText="Reversing Value" UniqueName="ReverseValue">
                                                                <ItemTemplate>
                                                                    <telerik:RadNumericTextBox ID="rntbNullifyAmount" runat="server"
                                                                        Culture="English (United States)" Text='<%# Eval("NULLIFY") %>'
                                                                        Skin="WebBlue" Width="10%" Style="text-align: left"
                                                                        MaxLength="12" MinValue="0" MaxValue='<%# Convert.ToDecimal(Eval("EMPSALDTLS_AMOUNT"))  %>'>
                                                                    </telerik:RadNumericTextBox>
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