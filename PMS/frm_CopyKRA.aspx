<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_CopyKRA.aspx.cs" Inherits="PMS_frm_CopyKRA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="javascript" type="text/javascript">
        //     function refreshOpener() {
        //         window.opener.location.href = "../PMS/frm_GS.aspx";

        //     }
        window.onunload = refreshParent;
        function refreshParent() {
            var loc = window.opener.location;
            window.opener.location = loc;
    </script>


    <%-- <script language="javascript"  type="text/javascript">
        function refreshOpener() {
            if (opener && !opener.closed) {
                opener.location.reload();
            }
        }
    </script>--%>
</head>
<body onunload="refreshOpener()">
    <form id="form1" runat="server">
        <div>
            <%--<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All"
            />--%>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <center>
                <b>Copy Previous KRA's </b>
            </center>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label ID="lbl_AppCycle" runat="server" Text="From Appraisal Cycle"></asp:Label>
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcmb_AppCycle" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                            AutoPostBack="true" OnSelectedIndexChanged="rcmb_AppCycle_SelectedIndexChanged" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="Rg_CopyKRA" runat="server" AutoGenerateColumns="false" Width="500"
                            GridLines="None" AllowPaging="true" AllowFilteringByColumn="true" AllowSorting="true"
                            OnNeedDataSource="Rg_CopyKRA_NeedDataSource" PageSize="10" PagerStyle-AlwaysVisible="true">
                            <HeaderContextMenu Skin="WebBlue">
                            </HeaderContextMenu>
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Select" HeaderStyle-Width="80px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chk_selectall" runat="server" AutoPostBack="true" OnCheckedChanged="chk_selectall_checkedchanged"
                                                Text="Check All" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chckbtn_Select" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="GSID" HeaderText="ID" UniqueName="GSID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ROLEKRA_ID" HeaderText="ID" UniqueName="ROLEKRA_ID"
                                        Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Name" UniqueName="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_NAME" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Desc" runat="server" Text='<%# Eval("DESC") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Measure" UniqueName="MEasure" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MEasure" runat="server" Text='<%# Eval("Measure") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Weightage" UniqueName="Template1" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Weightage" runat="server" Enabled="false" Text='<%# Eval("WEIGHTAGE") %>'
                                                Width="50px" SkinID="one"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="A" HeaderStyle-HorizontalAlign="Center" HeaderText="Type"
                                        UniqueName="A" HeaderStyle-Width="60px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Target" HeaderText="Target" UniqueName="Target"
                                        Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Timelines" HeaderText="Timelines" UniqueName="Timelines"
                                        Visible="false">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                            <GroupingSettings CaseSensitive="false" />
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td>
                        <asp:Button ID="btn_Copy" runat="server" Text="Copy" OnClick="btn_Copy_Click" Visible="false" />
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>