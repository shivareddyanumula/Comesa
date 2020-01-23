<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_OraclePostings.aspx.cs" MasterPageFile="~/SMHRMaster.master" Inherits="Payroll_frm_OraclePostings" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ShowPop() {
            var win = window.radopen('../Payroll/XML.aspx', "RW_XML");

        }
        win.center();
        win.set_modal(true);


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <br />
    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="lbl_Header" runat="server" Font-Bold Text="Oracle EBS Postings"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4"></td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:LinkButton ID="lnk_Files" runat="server" OnClientClick="ShowPop();">Click Here to View Oracle Posted Files</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server"
                    MarkFirstMatch="true" AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFV_BusinessUnit" runat="server" ControlToValidate="ddl_BusinessUnit"
                    ErrorMessage="Please Select Business Unit" InitialValue="Select" SetFocusOnError="True"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_Period" runat="server" Text="Period"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="ddl_Period" runat="server" AutoPostBack="true" Filter="Contains"
                    MarkFirstMatch="true" OnSelectedIndexChanged="ddl_Period_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFV_Period" runat="server" ControlToValidate="ddl_Period"
                    ErrorMessage="Please Select Period" InitialValue="Select" SetFocusOnError="True" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_PeriodDetails" runat="server" Text="Period Details"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="ddl_PeriodDetails" runat="server" MarkFirstMatch="true" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFV_Period_Elements" runat="server" ControlToValidate="ddl_PeriodDetails"
                    ErrorMessage="Please Select Period Details" InitialValue="Select" SetFocusOnError="True"
                    ValidationGroup="Controls">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr><td>
        <asp:HiddenField runat="server" id="hidden" value="Configuration.ConfigurationSettings.AppSettings["value"]" />
        </td>
           
        </tr>--%>
        <tr>
            <td colspan="4">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Button ID="btn_Submit" runat="server" Text="Search" OnClick="btn_Submit_Click1"
                    ValidationGroup="Controls" />
                &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel"
                    OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:ValidationSummary ID="VS_Summary" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="Controls" />
    <table align="center">
        <tr>
            <td>
                <telerik:RadGrid ID="RG_Details" runat="server" AutoGenerateColumns="False"
                    OnNeedDataSource="RG_Details_NeedDataSource" ShowStatusBar="True" ClientSettings-Scrolling-AllowScroll="true" ClientSettings-Scrolling-UseStaticHeaders="true">
                    <HeaderContextMenu>
                    </HeaderContextMenu>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Element_Name" HeaderText="Element&nbsp;Name">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Element_Classification" HeaderText="Element&nbsp;Classification">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <%--       <telerik:GridBoundColumn DataField="Account_Number" HeaderText="Account&nbsp;No">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn DataField="Credit_Balana" HeaderText="Credit&nbsp;Balance">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Debit_Balana" HeaderText="Debit&nbsp;Balance">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Division_Code" HeaderText="Division&nbsp;Name">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DEPARTMENT_NAME" HeaderText="Department&nbsp;Name">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EMPSALDTLS_APPROVEDDATE" HeaderText="Sal&nbsp;Approved Date">
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <%-- <telerik:GridBoundColumn DataField="MODE_OF_PAY" HeaderText="Mode&nbsp;Of&nbsp;Pay">
                            <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>--%>
                        </Columns>
                    </MasterTableView>
                    <FilterMenu>
                    </FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <br />
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button ID="btn_Generate" runat="server" Text="Generate XML" OnClick="btn_Generate_Click"
                    ValidationGroup="Controls" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>