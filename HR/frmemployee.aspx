<%@ Page Title="Employee" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmemployee.aspx.cs" Inherits="HR_frmemployee" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <style type="text/css">
        div.RadGrid .rgPager .rgAdvPart
        {
            display: none;
        }
    </style>
    
        <table align="center">
            <tr>
                <td>
                    <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                    </telerik:RadWindowManager>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updPanel1" runat="server">
                        <ContentTemplate>
                            <br />
                            <center>
                                <asp:Label ID="lbl_Result" runat="server" Font-Bold="True" BackColor="Yellow" ForeColor="Black"></asp:Label>
                            </center>
                            <telerik:RadMultiPage ID="RMP_Employee" runat="server" Width="990px" 
                                ScrollBars="Auto">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <telerik:RadPageView ID="Search" runat="server" Selected="True">
                                    <br />
                                    <center>
                                        <asp:Label ID="lbl_Employee" runat="server" Font-Bold="True" meta:Resourcekey="lbl_Employee"></asp:Label></center>
                                    <br />
                                    <table align="center">
                                        <tr>
                                            <td>
                                                <telerik:RadGrid ID="RG_Employee" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    Skin="WebBlue" GridLines="None" OnNeedDataSource="RG_Employee_NeedDataSource"
                                                    AllowFilteringByColumn="True" AllowSorting="True">
                                                    <HeaderContextMenu Skin="WebBlue">
                                                    </HeaderContextMenu>
                                                    <PagerStyle AlwaysVisible="true" />
                                                    <MasterTableView CommandItemDisplay="Top">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="EMP_ID" UniqueName="EMP_ID" Visible="False" meta:Resourcekey="EMP_ID">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="BUNIT" UniqueName="BUNIT" meta:Resourcekey="EMP_BUNIT">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EMP_EMPCODE" UniqueName="EMP_EMPCODE" meta:Resourcekey="EMP_EMPCODE">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EMP_STATUS" UniqueName="EMP_STATUS" meta:Resourcekey="EMP_STATUS">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EMPNAME" UniqueName="EMPNAME" meta:Resourcekey="EMPNAME">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Grade">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EMP_EMPLOYEETYPE" UniqueName="EMP_EMPLOYEETYPE" HeaderText="Employee Type">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                       <%--     <telerik:GridBoundColumn DataField="EMP_DOJ" UniqueName="EMP_DOJ" meta:Resourcekey="EMP_DOJ">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>--%>
                                                            <telerik:GridDateTimeColumn DataField="EMP_DOJ" meta:Resourcekey="EMP_DOJ" FilterControlWidth="110px"
                                                             SortExpression="EMP_DOJ" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridDateTimeColumn>
                                                            <%-- <telerik:GridBoundColumn DataField="EMP_DOC" UniqueName="EMP_DOC" meta:Resourcekey="EMP_DOC">
                                                    </telerik:GridBoundColumn>--%>
                                                            <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_Employee_Edit" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                                                        OnCommand="lnk_Employee_Edit_Command" meta:Resourcekey="lnk_Employee_Edit">Edit
                                                                    </asp:LinkButton></ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                        <EditFormSettings>
                                                            <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                                UpdateImageUrl="Update.gif">
                                                            </EditColumn>
                                                        </EditFormSettings>
                                                        <CommandItemTemplate>
                                                            <div align="right">
                                                                <asp:LinkButton ID="lnk_Add" meta:Resourcekey="lnk_Add" runat="server" OnClick="lnk_Add_Click"
                                                                    Text="Add"></asp:LinkButton></div>
                                                        </CommandItemTemplate>
                                                    </MasterTableView><FilterMenu Skin="WebBlue">
                                                    </FilterMenu>
                                                    <GroupingSettings CaseSensitive="false" />
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                               <%-- <table align="center">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td colspan="4">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Converting Applicant To Employee"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &#160;
                                                        </td>
                                                        <td>
                                                            &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; <a id="D1" runat="server"
                                                                href="~/HR/Employee_template.xlsx">Download Employee Details Template</a>
                                                        </td>
                                                        <td>
                                                            <strong>:</strong>
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btn_Imp_Employee" runat="server" OnClick="Btn_Imp_Employee_click"
                                                                Text="Import" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td colspan="4">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Adding Employee Directly "></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="A1" runat="server"
                                                                href="~/HR/DirectEmployee_template.xlsx">Download Employee Details Template</a>
                                                        </td>
                                                        <td>
                                                            <strong>:</strong>
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="Up_directEmp" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btn_Imp_directEmp" runat="server" OnClick="Btn_Imp_directEmp_click"
                                                                Text="Import" />
                                                        </td>
                                                    </tr>
                                                </table>--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </ContentTemplate>
                        <Triggers>
                          <%--  <asp:PostBackTrigger ControlID="btn_Imp_Employee" />
                            <asp:PostBackTrigger ControlID="btn_Imp_directEmp" />--%>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    
    <asp:ValidationSummary ID="vs_Employee" runat="server" ValidationGroup="Controls"
        ShowMessageBox="true" ShowSummary="false" />
    <asp:ValidationSummary ID="vs_skill" runat="server" ValidationGroup="Skill" ShowMessageBox="true"
        ShowSummary="false" />
    <asp:ValidationSummary ID="vs_Qualification" runat="server" ValidationGroup="Qual"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Content>

