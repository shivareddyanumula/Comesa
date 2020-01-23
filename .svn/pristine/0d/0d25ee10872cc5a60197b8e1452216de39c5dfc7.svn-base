<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Pms_ViewFeedBack.aspx.cs" Inherits="PMS_frm_Pms_ViewFeedBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
        <div>
            <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="WebBlue" DecoratedControls="All"
                meta:resourcekey="RadFormDecorator1Resource1" />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>

            <center>Feedback Details</center>
            <table align="center">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="RG_ViewFeedBack" runat="server" AutoGenerateColumns="False"
                            AllowSorting="True" AllowMultiRowSelection="False" OnItemDataBound="RG_ViewFeedBack_ItemDataBound" Skin="WebBlue" GridLines="None" ClientSettings-Scrolling-AllowScroll="true"
                            ClientSettings-Scrolling-UseStaticHeaders="true">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="KRA_NAME" HeaderText="KRA NAME" UniqueName="KRA_NAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="false" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Feedback_id" runat="server" Text='<%# Eval("PF_FEEDBACK_ID") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Comments">
                                        <ItemTemplate>
                                            <telerik:RadTextBox ID="rtxt_comments" runat="server" TextMode="MultiLine" Text='<%# Eval("FEEDBACK_COMMENTS") %>'
                                                Enabled="false">
                                            </telerik:RadTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rating">
                                        <ItemTemplate>
                                            <telerik:RadRating ID="lbl_rating1" runat="server" Value='<%# Convert.ToInt32(Eval("FEEDBACK_RATING")) %>' Enabled="false" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_feedbackdate" runat="server" Text='<%# Eval("FEEDBACK_DATE") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>