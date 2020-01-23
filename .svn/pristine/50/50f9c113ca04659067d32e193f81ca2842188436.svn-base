<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frmProject.aspx.cs" Inherits="Masters_frmProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblProjectHeader" runat="server" Text="Projects-Funding Source" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmpProject" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="RpvGrid" runat="server" Selected="True">
                        <asp:UpdatePanel ID="upPanel" runat="server">
                            <ContentTemplate>
                                <table align="center" width="70%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rgProject" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="rgProject_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="PROJECT_ID" UniqueName="PROJECT_ID" HeaderText="ID"
                                                            meta:resourcekey="PROJECT_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PROJECT_CODE" UniqueName="PROJECT_CODE" HeaderText="Code"
                                                            meta:resourcekey="PROJECT_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PROJECT_NAME" UniqueName="PROJECT_NAME" HeaderText="Name"
                                                            meta:resourcekey="PROJECT_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PROJECT_STARTDATE" UniqueName="PROJECT_STARTDATE" HeaderText="Start Date"
                                                            meta:resourcekey="PROJECT_STARTDATE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="PROJECT_ENDDATE" UniqueName="PROJECT_ENDDATE" HeaderText="End Date"
                                                            meta:resourcekey="PROJECT_ENDDATE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("PROJECT_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                            UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourceKey="lnk_Add" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" />
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <%--<asp:PostBackTrigger  ControlID="btn_Imp_Businessunit"/>--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RpvDetails" runat="server">
                        <table align="center" width="35%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBusinesUnit" runat="server" Text="Business Unit" meta:resourcekey="lblBusinesUnit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmbBusinessUnit" runat="server"
                                        Skin="WebBlue" MaxLength="100" Filter="Contains">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="rfvBusinessUnit" ControlToValidate="rcmbBusinessUnit"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please select Business unit" InitialValue="Select"
                                        meta:resourcekey="rfvBusinessUnit">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ProjectID" runat="server" Visible="False" meta:resourcekey="lbl_ProjectID"></asp:Label>
                                    <asp:Label ID="lbl_ProjectCode" runat="server" Text="Code" meta:resourcekey="lbl_ProjectCode"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ProjectCode" runat="server"
                                        Skin="WebBlue" MaxLength="100" TabIndex="1">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfvProjectCode" ControlToValidate="rtxt_ProjectCode"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Code"
                                        meta:resourcekey="rfvProjectCode">*</asp:RequiredFieldValidator>

                                    <%--<asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_ProjectCode" ErrorMessage="Enter only Alphabets for Proect Code"
                                        ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_ProjectName" runat="server" Text="Name" meta:resourcekey="lbl_ProjectName"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_ProjectName" runat="server"
                                        Skin="WebBlue" MaxLength="100" TabIndex="2">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfvProjectName" ControlToValidate="rtxt_ProjectName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter  Name"
                                        meta:resourcekey="rfvProjectName">*</asp:RequiredFieldValidator>

                                    <%--<asp:RegularExpressionValidator ID="reProjectName" runat="server" ControlToValidate="rtxt_ProjectName" ErrorMessage="Enter only Alphabets for Proect Name"
                                        ValidationExpression="^[a-zA-Z0-9\s]+$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblProjectDesc" runat="server" Text="Description" meta:resourcekey="lblProjectDesc"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxtProjectDesc" runat="server"
                                        Skin="WebBlue" MaxLength="100" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date" meta:resourcekey="lblStartDate"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdpStartDate" runat="server"
                                        Skin="WebBlue" MaxLength="100" TabIndex="2" OnSelectedDateChanged="rdpStartDate_SelectedDateChanged" AutoPostBack="true">
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="rfvStartDate" ControlToValidate="rdpStartDate"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please select Start Date"
                                        meta:resourcekey="rfvStartDate">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEndDate" runat="server" Text="End Date" meta:resourcekey="lblEndDate"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdpEndDate" runat="server"
                                        Skin="WebBlue" MaxLength="100" TabIndex="2">
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="rfvEndDate" ControlToValidate="rdpEndDate"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please select End Date"
                                        meta:resourcekey="rfvEndDate">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text="Status" meta:resourcekey="lblStatus"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcmbStatus" runat="server"
                                        Skin="WebBlue">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="0" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="3"
                                        Text="Update" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="3"
                                        Text="Save" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="4"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_Country" runat="server" ShowMessageBox="True" ShowSummary="False"
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