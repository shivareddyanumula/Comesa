<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DependentAllowance.aspx.cs" Inherits="DependentAllowance" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function CloseAndRedirect(sender, args) {
            GetRadWindow().BrowserWindow.location.href = '../Masters/frm_PayItemDefine.aspx';        //Redirect to new url
            GetRadWindow().close();       //closes the window
        }
        function GetRadWindow()   //Get reference to window
        {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>
            <%--<telerik:RadWindow runat="server" ID="rwcontrols" VisibleOnPageLoad="true" Width="700px" Height="450px" Behaviors="Close">
                <ContentTemplate>--%>
            <table align="center">
                <tr>
                    <td>
                        <div>
                            <table align="center">
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lbl_Allowance" runat="server" Text="Allowance" Style="font-weight: 700"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td align="left">
                                                    <asp:Label ID="Label" runat="server" Visible="False" meta:resourcekey="lblFromPeriodId"></asp:Label>
                                                    <asp:Label ID="lbl_FromPeriod" runat="server" Text="Financial Period" meta:resourcekey="lblFromPeriodId"></asp:Label>
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="rcmb_FromPeriod" runat="server" MarkFirstMatch="true"
                                                        AutoPostBack="true" OnSelectedIndexChanged="rcmb_FromPeriod_SelectedIndexChanged"
                                                        MaxHeight="200" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td></td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="RG_Allowance" runat="server" AutoGenerateColumns="False"
                                            GridLines="None" Skin="WebBlue" Visible="false" AllowPaging="false"
                                            PageSize="10" AllowFilteringByColumn="true"
                                            OnNeedDataSource="RG_Allowance_NeedDataSource">
                                            <MasterTableView>

                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="Sl_No" UniqueName="Sl_No" HeaderText="S.NO"
                                                        Visible="true">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_ID" UniqueName="EMPLOYEEGRADE_ID"
                                                        HeaderText="Grade " meta:resourcekey="EMPLOYEEGRADE_ID" Visible="false">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_CODE" UniqueName="EMPLOYEEGRADE_CODE"
                                                        HeaderText="Grade" meta:resourcekey="EMPLOYEEGRADE_CODE">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Allowance($) Per Dependent" AllowFiltering="false">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="rntbDependent" runat="server" Text='<%# Eval("Dependent") %>'>
                                                            </telerik:RadNumericTextBox>
                                                            <asp:Label runat="server" ID="lblGradeID" Text='<%# Eval("EMPLOYEEGRADE_ID") %>' Visible="false">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="No. of Dependents Eligible" AllowFiltering="false">
                                                        <ItemTemplate>
                                                            <telerik:RadNumericTextBox ID="rntbEligible" runat="server" MaxLength="10" Text='<%# Eval("Eligible") %>'>
                                                                <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                            </telerik:RadNumericTextBox>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btn_submit" runat="server" Text="Save" Visible="false"
                                            OnClick="btnSave_Click" UseSubmitBehavior="false" ValidationGroup="Part" /><%--btn_submit_Click--%>
                                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="false" OnClick="btn_Cancel_Click" />
                                        <asp:ValidationSummary ID="vs_TrainerProf" runat="server" ShowMessageBox="True" ShowSummary="False"
                                            ValidationGroup="Part" />
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </td>
                </tr>
            </table>
            <%--   </ContentTemplate>
        </telerik:RadWindow>--%>
        </div>
    </form>
</body>
</html>