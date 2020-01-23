<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_IncidentDetails.aspx.cs" Inherits="Workman_Compensation_frm_IncidentDetails" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    </div>
        <table align="center">
            <tr>
                <td></td>
                <td>
                    <telerik:RadGrid ID="RG_Incident" runat="server" Skin="WebBlue" GridLines="None"
                                    AutoGenerateColumns="False" OnNeedDataSource="RG_Incident_NeedDataSource" AllowPaging="True"
                                    AllowFilteringByColumn="True" AllowSorting="True">
                                    <GroupingSettings CaseSensitive="False" />
                                    <MasterTableView CommandItemDisplay="None">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="INC_ID" HeaderText="Incident ID"
                                                meta:resourcekey="INC_ID" UniqueName="INC_ID"
                                                Visible="False">
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridBoundColumn DataField="INCIDENT_CODE" HeaderText="Incident Code"
                                                meta:resourcekey="INCIDENT_CODE" UniqueName="INCIDENT_CODE">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>--%>


                                            <telerik:GridBoundColumn DataField="INCIDENT_NAME" HeaderText="Incident Name"
                                                    meta:resourcekey="INCIDENT_NAME" UniqueName="INCIDENT_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PLACE_OF_INCIDENT" HeaderText="Place of Incident"
                                                meta:resourcekey="PLACE_OF_INCIDENT" UniqueName="PLACE_OF_INCIDENT">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="INCIDENT_DATE" HeaderText="Date of Incident" DataFormatString="{0:g}"
                                                meta:resourcekey="INCIDENT_DATE" UniqueName="INCIDENT_DATE">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name"
                                                    meta:resourcekey="EMP_NAME" UniqueName="EMP_NAME">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>--%>
                                            <telerik:GridBoundColumn DataField="INJURY_CAUSE" HeaderText="Cause of Injury"
                                                meta:resourcekey="INJURY_CAUSE" UniqueName="INJURY_CAUSE">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="INJURY_TYPE" HeaderText="Type Of Injury"
                                                meta:resourcekey="INJURY_TYPE" UniqueName="INJURY_TYPE">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SEVERITY" HeaderText="Severity"
                                                meta:resourcekey="SEVERITY" UniqueName="SEVERITY">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>

                                            <%-- <telerik:GridTemplateColumn AllowFiltering="False"
                                                    meta:resourcekey="GridTemplateColumn" UniqueName="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Incident_Edit" runat="server" CommandName="EditRec"
                                                            CommandArgument='<%# Eval("INC_ID") %>'
                                                            meta:resourcekey="lnk_Incident_EditResource1" OnCommand="lnk_IncidentEdit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                        </Columns>
                                        <%--<EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif"
                                                    InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="LinkButton2" runat="server" meta:resourcekey="lnk_Add"
                                                        OnClick="lnk_Add_Click"> Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>--%>
                                    </MasterTableView>
                                    <PagerStyle AlwaysVisible="True" />
                                    <FilterMenu Skin="WebBlue"></FilterMenu>
                                    <HeaderContextMenu Skin="WebBlue"></HeaderContextMenu>
                                </telerik:RadGrid>
                </td>
            </tr>
        </table>


    </form>
</body>
</html>
