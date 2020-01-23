<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_PmsRole.aspx.cs" Inherits="PMS_frm_Role" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .ButtonAsLink {
            background-color: transparent;
            border: none;
            color: blue;
            cursor: pointer;
            text-decoration: underline;
            padding: 0px;
            display: inline;
        }

            .ButtonAsLink span {
                text-decoration: underline;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Roles" runat="server" Text="Roles" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td>
                            <asp:Label ID="lbl_BusinessUnitName" runat="server" Text="BusinessUnit"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_BusinessUnitType" runat="server" MarkFirstMatch="true" Filter="Contains"
                                AutoPostBack="true" OnSelectedIndexChanged="rcmb_BusinessUnitType_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitType" runat="server" ControlToValidate="rcmb_BusinessUnitType"
                                ErrorMessage="Please Select Business Unit" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Position" runat="server" Text="Position"></asp:Label>
                        </td>
                        <td>
                            <b>:</b>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rcmb_Position" runat="server" initialvalue="Select" AutoPostBack="true" Filter="Contains"
                                Skin="WebBlue" Width="125px" MarkFirstMatch="true" MaxHeight="120px" OnSelectedIndexChanged="rcmb_Position_SelectedIndexChanged">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_rcmb_Position" runat="server" ControlToValidate="rcmb_Position" InitialValue="Select"
                                ErrorMessage="Please Select Position" Text="*"
                                ValidationGroup="Controls"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_BU_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto" Visible="false">
                    <telerik:RadPageView ID="Rp_BU_ViewMain" runat="server">
                        <br />
                        <br />
                        <asp:UpdatePanel ID="updApplicant" runat="server">
                            <ContentTemplate>
                                <table style="width: 80%;" align="center">
                                    <tr>
                                        <td align="center">
                                            <telerik:RadTabStrip ID="RTS_Details" runat="server" Skin="WebBlue" MultiPageID="RMP_KRADetails" AutoPostBack="true" CausesValidation="false"
                                                SelectedIndex="0" Align="Center" Width="100%">
                                                <Tabs>
                                                    <telerik:RadTab runat="server" Text="KRA" PageViewID="KRA">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab runat="server" Text="Competencies" PageViewID="Competencies">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab runat="server" Text="Values" PageViewID="Values">
                                                    </telerik:RadTab>
                                                </Tabs>
                                            </telerik:RadTabStrip>

                                            <telerik:RadMultiPage ID="RMP_KRADetails" runat="server" Width="90%" SelectedIndex="0">
                                                <telerik:RadPageView ID="KRA" runat="server">
                                                    <br />
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblKRA" runat="server" Text="KRA"></asp:Label>
                                                            </td>
                                                            <td><b>:</b></td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcmb_KRA" runat="server" AutoPostBack="true" Filter="Contains"></telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_AddKRA" runat="server" Text="Add KRA" OnClick="lnk_AddKRA_Click"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <telerik:RadGrid ID="RG_KRA" runat="server" Width="100%" AllowFilteringByColumn="true" AutoGenerateColumns="False"
                                                                    GridLines="None" AllowPaging="True" Skin="WebBlue" PageSize="5" OnNeedDataSource="RG_KRA_NeedDataSource">
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="ROLEKRA_ID" HeaderText="ROLEKRA_ID" AllowFiltering="false" Visible="false"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="KRA_ID" HeaderText="KRA_ID" AllowFiltering="false" Visible="false"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="KRA_NAME" HeaderText="KRA Name" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Position" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="BusinessUnit" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn AllowFiltering="False">
                                                                                <ItemTemplate>
                                                                                    <div align="right">
                                                                                        <asp:LinkButton ID="lnk_delKRA" runat="server" Text="Delete" CommandArgument='<%# Eval("ROLEKRA_ID") %>'
                                                                                            OnCommand="lnk_delKRA_Command"></asp:LinkButton>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <PagerStyle AlwaysVisible="True" />
                                                                </telerik:RadGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </telerik:RadPageView>

                                                <telerik:RadPageView ID="Competencies" runat="server">
                                                    <br />
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblCompetencies" runat="server" Text="Competencies"></asp:Label>
                                                            </td>
                                                            <td><b>:</b></td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcmb_Competencies" runat="server" AutoPostBack="true" Filter="Contains"></telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_AddCompetencies" runat="server" Text="Add Competencies" OnClick="lnk_AddCompetencies_Click"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <telerik:RadGrid ID="RG_Competencies" runat="server" Skin="WebBlue" GridLines="None" Width="100%"
                                                                    AutoGenerateColumns="False" AllowFilteringByColumn="true" AllowPaging="True" PageSize="5" OnNeedDataSource="RG_Competencies_NeedDataSource">
                                                                    <ClientSettings>
                                                                        <Selecting AllowRowSelect="True" />
                                                                    </ClientSettings>
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="ROLEKRA_ID" HeaderText="ROLEKRA_ID" AllowFiltering="false" Visible="false"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="CMP_ID" HeaderText="CMP_ID" AllowFiltering="false" Visible="false"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="CMP_NAME" HeaderText="Competency Name" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Position" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="BusinessUnit" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn AllowFiltering="False">
                                                                                <ItemTemplate>
                                                                                    <div align="right">
                                                                                        <asp:LinkButton ID="lnk_delCMP" runat="server" Text="Delete" CommandArgument='<%# Eval("ROLEKRA_ID") %>'
                                                                                            OnCommand="lnk_delCMP_Command"></asp:LinkButton>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <FilterMenu Skin="WebBlue">
                                                                    </FilterMenu>
                                                                    <HeaderContextMenu Skin="WebBlue">
                                                                    </HeaderContextMenu>
                                                                </telerik:RadGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </telerik:RadPageView>
                                                <telerik:RadPageView ID="Values" runat="server">
                                                    <br />
                                                    <br />
                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblValues" runat="server" Text="Values"></asp:Label>
                                                            </td>
                                                            <td><b>:</b></td>
                                                            <td>
                                                                <telerik:RadComboBox ID="rcmb_Values" runat="server" AutoPostBack="true" Filter="Contains"></telerik:RadComboBox>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnk_AddValues" runat="server" Text="Add Values" OnClick="lnk_AddValues_Click"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <telerik:RadGrid ID="RG_Values" runat="server" Skin="WebBlue" GridLines="None" Width="100%"
                                                                    AutoGenerateColumns="False" AllowFilteringByColumn="true" AllowPaging="True" PageSize="5" OnNeedDataSource="RG_Values_NeedDataSource">
                                                                    <ClientSettings>
                                                                        <Selecting AllowRowSelect="True" />
                                                                    </ClientSettings>
                                                                    <MasterTableView>
                                                                        <Columns>
                                                                            <telerik:GridBoundColumn DataField="ROLEKRA_ID" HeaderText="ROLEKRA_ID" AllowFiltering="false" Visible="false"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="IDP_ID" HeaderText="IDP_ID" AllowFiltering="false" Visible="false"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="IDP_NAME" HeaderText="Value Name" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="POSITIONS_CODE" HeaderText="Position" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="BusinessUnit" AllowFiltering="true"></telerik:GridBoundColumn>
                                                                            <telerik:GridTemplateColumn AllowFiltering="False">
                                                                                <ItemTemplate>
                                                                                    <div align="right">
                                                                                        <asp:LinkButton ID="lnk_delValue" runat="server" Text="Delete" CommandArgument='<%# Eval("ROLEKRA_ID") %>'
                                                                                            OnCommand="lnk_delValue_Command"></asp:LinkButton>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <FilterMenu Skin="WebBlue">
                                                                    </FilterMenu>
                                                                    <HeaderContextMenu Skin="WebBlue">
                                                                    </HeaderContextMenu>
                                                                </telerik:RadGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </telerik:RadPageView>
                                            </telerik:RadMultiPage>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>