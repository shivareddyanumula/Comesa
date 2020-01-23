<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmEmployeeDetails.aspx.cs" Inherits="HR_frmEmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblHeader" runat="server" Text="Employee Search" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBusinessUnit" runat="server" Text="Business Unit"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <telerik:RadComboBox ID="rcmbBusinessUnit" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                    OnSelectedIndexChanged="rcmbBusinessUnit_SelectedIndexChanged" Filter="Contains">
                </telerik:RadComboBox>
            </td>
            <td>
            </td>
        </tr>
        <%--<tr id="trSearch" visible="false">
            <td>
                <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label>
            </td>
            <td>
                <b>:</b>
            </td>
            <td>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
            <td>
            </td>
        </tr>--%>
    </table>
    <br />
    <br />
    <table align="center">
        <tr>
            <td>
                <telerik:RadGrid ID="rgMain" runat="server" AutoGenerateColumns="false" GridLines="None"   
                    OnNeedDataSource="rgMain_NeedDataSource" Width="990px" AllowFilteringByColumn="true"  AllowPaging="true" AllowSorting="true" PageSize="10">
                    <ClientSettings>
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <GroupingSettings CaseSensitive="false" />
                    <PagerStyle AlwaysVisible="true" />
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn DataField="EMP_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_PICTURE" HeaderText="Picture">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                <ItemTemplate>
                                    <asp:Image ID="imgEmp" runat="server" Height="90px" Width="75px" ImageUrl='<%# Eval("EMP_PICTURE") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_EMPCODE" HeaderText="Employee Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpCode" runat="server" Text='<%# Eval("EMP_EMPCODE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMPNAME" HeaderText="Full Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("EMPNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="POSITION" HeaderText="Job Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblJobTitle" runat="server" Text='<%# Eval("POSITION") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_REPORTINGEMPLOYEE" HeaderText="Reporting Manager">
                                <ItemTemplate>
                                    <asp:Label ID="lblReportingManager" runat="server" Text='<%# Eval("EMP_REPORTINGEMPLOYEE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_SKYPEID" HeaderText="Skype Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblSkypeId" runat="server" Text='<%# Eval("EMP_SKYPEID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_EMAILID" HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmailId" runat="server" Text='<%# Eval("EMP_EMAILID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_EXTENSIONNO" HeaderText="Extension">
                                <ItemTemplate>
                                    <asp:Label ID="lblExtension" runat="server" Text='<%# Eval("EMP_EXTENSIONNO") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_MOBILENO" HeaderText="Mobile Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("EMP_MOBILENO") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
