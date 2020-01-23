<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_ImportEmpcomponents.aspx.cs" Inherits="Masters_frm_vapinp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <asp:UpdatePanel ID="updPanel1" runat="server">
        <ContentTemplate>

            <table align="center">
                <tr>
                    <td colspan="5" align="center">
                        <asp:Label ID="lbl_Heading" runat="server" Text="Employee Components" Font-Bold="true">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server"
                            Style="z-index: 8000">
                        </telerik:RadWindowManager>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Label ID="lbl_Businessunit" runat="server" Text="Businessunit">
                        </asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td align="left">
                        <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged"
                            MarkFirstMatch="true" TabIndex="1" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="rcmb_Businessunit" InitialValue="Select" Text="*" ErrorMessage="select BusinessUnit"
                            ValidationGroup="control"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Label ID="lbl_Financialperiod" runat="server" Text="Financial Period">
                        </asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td align="left">
                        <telerik:RadComboBox ID="rcmb_Financialperiod" runat="server" AutoPostBack="true" MarkFirstMatch="true" TabIndex="2"
                            Visible="true" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="rcmb_Financialperiod" InitialValue="Select" Text="*" ErrorMessage="Select FancialPeriod"
                            ValidationGroup="control"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Upload EmployeeComponent document"></asp:Label>
                    </td>
                    <td>
                        <b>:</b></td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="3" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="FileUpload1" Text="*" ErrorMessage="Select Excel File To Upload"
                            ValidationGroup="control">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="D2" runat="server" tabindex="5"
                        href="~/Masters/Importsheets/EmployeeComponent_template.xlsx">Download Employee Component Template</a> </td>
                </tr>

                <tr>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td align="center" colspan="3">&nbsp;</td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="5"></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td colspan="3">
                        <asp:Button ID="Btn_upload" runat="server" OnClick="Btn_upload_Click" TabIndex="6"
                            Text="Save" ValidationGroup="control" />
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" TabIndex="7" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
                            ValidationGroup="control" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Btn_upload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>