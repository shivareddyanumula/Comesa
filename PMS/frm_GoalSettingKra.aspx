<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_GoalSettingKra.aspx.cs"
    Inherits="PMS_frm_GoalSettingKra" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

                <script language="javascript" type="text/javascript">
                    function GetRadWindow() {
                        var oWindow = null;
                        if (window.radWindow)
                            oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog         
                        else if (window.frameElement.radWindow)
                            oWindow = window.frameElement.radWindow; //IE (and Moz as well)         
                        return oWindow;
                    }

                    function Close() {
                        GetRadWindow().Close();
                    }
                </script>

            </telerik:RadScriptBlock>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All"
                meta:resourcekey="RadFormDecorator1Resource1" />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <table align="center">
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="RMP_KraDetails" runat="server" Width="100%" meta:resourcekey="RMP_KraDetailsResource1">
                            <telerik:RadPageView ID="RP_KraDetails" runat="server" meta:resourcekey="RP_KraDetailsResource1">
                                <table align="center">
                                    <tr>
                                        <td align="center" colspan="8">Assign KRA's
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="RG_KraDetails" runat="server" AutoGenerateColumns="False" OnNeedDataSource="RG_Kra_NeedDataSource" EnableEmbeddedSkins="false"
                                                PageSize="5" Skin="WebBlue" Width="350px" GridLines="None" meta:resourcekey="RG_KraDetailsResource1">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumnResource3" UniqueName="TemplateColumn">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="Chb_id" runat="server" meta:resourcekey="Chb_idResource1" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn Visible="False" meta:resourcekey="GridTemplateColumnResource4"
                                                            UniqueName="TemplateColumn1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("KRA_ID") %>' meta:resourcekey="lblIDResource1"></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Kra Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("KRA_NAME") %>' meta:resourcekey="lblIDResource1"></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <%--    <telerik:GridBoundColumn HeaderText="NAME" DataField="KRA_NAME" meta:resourcekey="GridBoundColumnResource13"
                                                        UniqueName="KRA_NAME">
                                                    </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn HeaderText="Description" DataField="KRA_DESCRIPTION" meta:resourcekey="GridBoundColumnResource14"
                                                            UniqueName="KRA_DESCRIPTION">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="Measure" DataField="KRA_MEASURE" meta:resourcekey="GridBoundColumnResource15"
                                                            UniqueName="KRA_MEASURE">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btn_Submit_Kra" runat="server" Text="Submit Kra" OnClick="btn_Submit_Kra_Click1"
                                                meta:resourcekey="btn_Submit_KraResource1" />
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>