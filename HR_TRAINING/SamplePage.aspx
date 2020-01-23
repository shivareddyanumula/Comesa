<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="SamplePage.aspx.cs" Inherits="HR_TRAINING_SamplePage" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <br />
                <br />
                <br />
                <telerik:RadComboBox ID="rcmb_AttDtls_Status" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_AttDtls_Status_SelectedIndexChanged"
                    Skin="WebBlue" MarkFirstMatch="true">
                    <Items>
                        <telerik:RadComboBoxItem Text="Select" Value="0" />
                        <telerik:RadComboBoxItem Text="A" Value="1" />
                        <telerik:RadComboBoxItem Text="B" Value="2" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadGrid ID="Grid1" runat="server" AllowFilteringByColumn="True"
                    AllowPaging="True" AllowSorting="true" OnPageIndexChanged="Grid1_PageIndexChanged"
                    GridLines="None" AutoGenerateColumns="true" PageSize="30"
                    Skin="Telerik" Visible="false" Width="98%">
                    <MasterTableView AutoGenerateColumns="False">
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="ID" DataField="ID" HeaderText="ID"></telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Attendance Status" DataField="ATTENDANCE_STATUS" UniqueName="ATTENDANCE_STATUS">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcmb_AttDtls_Status" runat="server" AppendDataBoundItems="true" Filter="Contains"
                                        DataTextField="Empname" DataValueField="EMP_ID" DataSource='<%#LoadGridEmployees() %>'
                                        Skin="WebBlue" MarkFirstMatch="true">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Attendance Status" DataField="ATTENDANCE_STATUS" UniqueName="ATTENDANCE_STATUS2">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcmb_AttDtls_Status1" runat="server" AppendDataBoundItems="true" DataTextField="Empname" DataValueField="EMP_ID" DataSource='<%#LoadGridEmployees() %>'
                                        Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Select" Value="0" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>

                    <ClientSettings AllowColumnsReorder="True" AllowDragToGroup="True" ReorderColumnsOnClient="True">
                    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Dinesh" />
            </td>
        </tr>
    </table>
</asp:Content>