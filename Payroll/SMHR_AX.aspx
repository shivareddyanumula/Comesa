<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMHR_AX.aspx.cs" Inherits="PMS_SMHR_AX" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="SMHR_AX.aspx.cs" Inherits="PMS_SMHR_AX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        function OnAccountType(sender, eventArgs) {
            var item = eventArgs.get_item();
            var Dim3 = document.getElementById('ctl00_cphDefault_rtxt_Dim3_text');
            Dim3.value = item.get_text();
            return;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_AX" runat="server" Text="Axapta Integration"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_AXINTEGRATION_PAGE" runat="server" SelectedIndex="0"
                    ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_AXINTEGRATION_VIEWMAIN" runat="server" Selected="True">
                        <table align="center" width="100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_AXINTEGRATION" runat="server" AutoGenerateColumns="False"
                                        GridLines="None" AllowPaging="True" Skin="WebBlue" OnNeedDataSource="Rg_AXINTEGRATION_NeedDataSource"
                                        PageSize="5" AllowFilteringByColumn="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SMHR_AX_ID" UniqueName="SMHR_AX_ID" HeaderText="ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" UniqueName="BUSINESSUNIT_CODE"
                                                    HeaderText="Business Unit">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_AX_DIM1" UniqueName="SMHR_AX_DIM1" HeaderText="Dim1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_AX_DIM2" UniqueName="SMHR_AX_DIM2" HeaderText="Dim2">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SMHR_AX_DIM3" UniqueName="SMHR_AX_DIM3" HeaderText="Dim3">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("SMHR_AX_ID") %>'
                                                            OnCommand="lnk_edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="True" />
                                        <FilterMenu>
                                        </FilterMenu>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_AXINTEGRATION_VIEWDETAILS" runat="server">
                        <table align="center" width="30%">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_det" runat="server" Text="Details"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BUI" runat="server" AutoPostBack="True" Filter="Contains"
                                        MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_BUI_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI"
                                        ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Id" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_DIM1" runat="server" Text="Dim1"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_DIM1Name" runat="server"
                                        MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_DIM1Name" runat="server" ControlToValidate="rtxt_DIM1Name"
                                        ErrorMessage="Please Enter Dim1" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_rtxt_DIM1Name" runat="server" ControlToValidate="rtxt_DIM1Name" ErrorMessage="Enter only Alphabets for Dim1"
                                        ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Dim2" runat="server" Text="Dim2"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_DIM2Name" runat="server"
                                        MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_DIM2Name" runat="server" ControlToValidate="rtxt_DIM2Name"
                                        ErrorMessage="Please Enter Dim2" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_rtxt_DIM2Name" runat="server" ControlToValidate="rtxt_DIM2Name" ErrorMessage="Enter only Alphabets for Dim2"
                                        ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_dim3" runat="server" Text="Dim3"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_Dim3" runat="server" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_Dim3" runat="server" ControlToValidate="rtxt_Dim3"
                                        ErrorMessage="Please Enter Dim3" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_rtxt_Dim3" runat="server" ControlToValidate="rtxt_Dim3" ErrorMessage="Enter only Alphabets for Dim3"
                                        ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save" ValidationGroup="Controls"
                                        Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click1" Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_PROJECT" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>