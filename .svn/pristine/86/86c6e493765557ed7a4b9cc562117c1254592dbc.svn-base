<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PayrollApproval.aspx.cs" Inherits="Approval_frm_PayrollApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPop(url, ID, BU, prddtl, paytran, Localisation) {
            var win = window.radopen('../Reportss/PreApprovalPayRegisterReport.aspx?PRD=' + url + '&ORG=' + ID + '&BU=' + BU + '&PRDDTL=' + prddtl + '&PAYTRAN=' + paytran + '&Localisation=' + Localisation, "RadWindow1");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);
        }
    </script>
    
    <br />
    <table align="center">
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbl_PeriodApproval" runat="server" meta:resourcekey="lbl_PeriodApproval"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Period" runat="server" meta:resourcekey="lbl_Period"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcb_Period" Skin="WebBlue" runat="server" AutoPostBack="True"  MarkFirstMatch="true" MaxHeight="120px"
                                            OnSelectedIndexChanged="rcb_Period_SelectedIndexChanged" Filter="Contains">
                                        </telerik:RadComboBox>
                                         <asp:RequiredFieldValidator ID="rfv_rcb_Period" runat="server" ControlToValidate="rcb_Period"
                                        InitialValue="Select" ErrorMessage="Please Select Period" Text="*" ValidationGroup="Controls">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_PeriodElements" runat="server" meta:resourcekey="lbl_PeriodElements"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcb_PeriodElements" Skin="WebBlue" runat="server" AutoPostBack="True"  MarkFirstMatch="true" MaxHeight="120px"
                                            OnSelectedIndexChanged="rcb_PeriodElements_SelectedIndexChanged" Filter="Contains">
                                        </telerik:RadComboBox>
                                         <asp:RequiredFieldValidator ID="rfv_rcb_PeriodElements" runat="server" ControlToValidate="rcb_PeriodElements"
                                        InitialValue="Select" ErrorMessage="Please Select Period Elements" Text="*" ValidationGroup="Controls">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_businessunit" runat="server" Text="Business&nbsp;Unit" meta:resourcekey="lbl_businessunit"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmb_businessunit" Skin="WebBlue" runat="server" AutoPostBack="True"  MarkFirstMatch="true" MaxHeight="120px"
                                            OnSelectedIndexChanged="rcmb_businessunit_SelectedIndexChanged" Filter="Contains">
                                        </telerik:RadComboBox>
                                          <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnits" runat="server" ControlToValidate="rcmb_businessunit"
                                        InitialValue="Select" ErrorMessage="Please Select Business Unit" Text="*" ValidationGroup="Controls">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_PayTran" runat="server" meta:resourcekey="lbl_PayTran"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcb_Paytran" Skin="WebBlue" runat="server" AutoPostBack="True"  MarkFirstMatch="true" MaxHeight="120px"
                                            OnSelectedIndexChanged="rcb_Paytran_SelectedIndexChanged" Filter="Contains">
                                        </telerik:RadComboBox>
                                         <asp:RequiredFieldValidator ID="rfv_rcb_Paytran" runat="server" ControlToValidate="rcb_Paytran"
                                        InitialValue="Select" ErrorMessage="Please Select Transaction ID" Text="*" ValidationGroup="Controls">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Button ID="btn_Approve" runat="server" meta:resourcekey="btn_Approve" OnClick="btn_Approve_Click"
                                            Enabled="False" ValidationGroup="Controls" />
                                        <asp:Button ID="btn_Reject" runat="server" meta:resourcekey="btn_Reject" Enabled="False"
                                            OnClick="btn_Reject_Click1"  ValidationGroup="Controls"/>
                                        <asp:Button ID="btn_Cancel" Text="Cancel" runat="server" meta:resourcekey="btn_Cancel"
                                            Enabled="true" OnClick="btn_Cancel_Click" />
                                        <asp:ValidationSummary ID="vs_PayrollApproval" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:LinkButton ID="lnk" runat="server" Text="Pre-Payroll Approval Details" OnClick="lnk_Click" Visible="false"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chk_CheckAll" runat="server" AutoPostBack="True" OnCheckedChanged="chk_CheckAll_CheckedChanged"
                                Text="Check All" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="RG_PayTran" runat="server" AutoGenerateColumns="False" Skin="WebBlue"
                                AllowMultiRowSelection="true">
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_Choose" runat="server" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Employee Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("EMPNAME") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE" HeaderText="Scale">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Salary&nbsp;Structure">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalStruct" runat="server" Text='<%# Eval("SALARYSTRUCT_CODE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Currency">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCurrency" runat="server" Text='<%# Eval("CURR_CODE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Amount" UniqueName="AMOUNT">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("AMOUNT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("EMPSALDTLS_STATUS") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
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
</asp:Content>
