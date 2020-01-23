<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_KRAApprove.aspx.cs" Inherits="PMS_frm_KRAApprove" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All"
                meta:resourcekey="RadFormDecorator1Resource1" />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <table align="center">
                <tr>
                    <td>
                        <telerik:RadGrid ID="RG_kraform" runat="server" AutoGenerateColumns="False"
                            Skin="WebBlue" GridLines="None" AllowFilteringByColumn="True"
                            meta:resourcekey="RG_kraformResource1" Width="700px">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                Text="Check All" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn HeaderText="KRA ID" DataField="KRA_ID"
                                        Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Business Unit" DataField="BUSINESSUNIT_CODE"
                                        Visible="true">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="KRA Name" DataField="KRA_NAME" UniqueName="column"
                                        meta:resourcekey="GridBoundColumnResource1">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Description" DataField="KRA_DESCRIPTION" UniqueName="column1"
                                        meta:resourcekey="GridBoundColumnResource2">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Measure" DataField="KRA_MEASURE" UniqueName="column2"
                                        meta:resourcekey="GridBoundColumnResource3">
                                    </telerik:GridBoundColumn>
                                    <%-- <telerik:GridTemplateColumn HeaderText="Measure" UniqueName="column_measure" AllowFiltering="false">
                                                <ItemTemplate>
                                                <telerik:RadTextBox ID="txt_measure" runat="server" Enabled="false" TextMode="MultiLine" Text='<%# Eval("KRA_MEASURE") %>'></telerik:RadTextBox>
                                                </ItemTemplate>
                                                </telerik:GridTemplateColumn> --%>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr id="tr_btns" runat="server">
                    <td align="center" colspan="3">
                        <asp:Button ID="btn_Approve" runat="server" Text="Approve" OnClick="btn_Approve_Click" />
                        <asp:Button ID="btn_Reject" runat="server" Text="Reject" OnClick="btn_Reject_Click" />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>