<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_LeaveStructure.aspx.cs" Inherits="Masters_frm_LeaveStructure" Culture="auto"
    meta:resourcekey="Page" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_LeaveStructure" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RPV_Search" runat="server" meta:resourcekey="RPV_Search"
                        Selected="True" Height="490px">
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_Header_Main" Text="Leave Structure" runat="server" Font-Bold="True"
                                        meta:resourcekey="lbl_Header_Main"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <telerik:RadGrid ID="RG_LeaveStructure" runat="server"
                                        AutoGenerateColumns="False" GridLines="None" Skin="WebBlue" AllowPaging="true"
                                        OnNeedDataSource="RG_LeaveStructure_NeedDataSource" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="LEAVESTRUCT_ID" HeaderText="ID" UniqueName="LEAVESTRUCT_ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LEAVESTRUCT_CODE" HeaderText=" Name"
                                                    meta:resourcekey="GridBoundColumnResource2" UniqueName="LEAVESTRUCT_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LEAVESTRUCT_NAME" HeaderText=" Description"
                                                    meta:resourcekey="GridBoundColumnResource3" UniqueName="LEAVESTRUCT_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LEAVESTRUCT_STARTDATE" HeaderText="Start Date"
                                                    meta:resourcekey="GridBoundColumnResource4" UniqueName="LEAVESTRUCT_STARTDATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="LEAVESTRUCT_ENDDATE" HeaderText="End Date" meta:resourcekey="GridBoundColumnResource5"
                                                    UniqueName="LEAVESTRUCT_ENDDATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_SalStructEdit" runat="server" CommandArgument='<%# Eval("LEAVESTRUCT_ID") %>'
                                                            OnCommand="lnk_SalStructEdit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnClick="lnk_Add_Click"
                                                        Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                        <HeaderContextMenu Skin="WebBlue">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPV_AddUpdate" runat="server" Height="100%" Width="100%">
                        <table align="center">
                            <tr>
                                <td colspan="9" align="center">
                                    <strong>
                                        <asp:Label ID="lbl_Header" runat="server" meta:resourcekey="lbl_Header"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <caption>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_LeaveCode" runat="server" meta:resourcekey="lbl_LeaveCode"></asp:Label>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_LeaveCode" runat="server" TabIndex="1"
                                            Skin="WebBlue" LabelCssClass="" MaxLength="50">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_LeaveCode" runat="server" ControlToValidate="rtxt_LeaveCode"
                                            ErrorMessage="Please Enter Name" meta:resourcekey="rfv_LeaveCode" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_Description" runat="server" meta:resourcekey="lbl_Description"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="rtxt_LeaveDesc" runat="server" TabIndex="2"
                                            Skin="WebBlue" MaxLength="50">
                                        </telerik:RadTextBox>
                                    </td>
                                    <%--<td>
                                        <asp:RequiredFieldValidator ID="rfv_LeaveDesc" runat="server" ControlToValidate="rtxt_LeaveDesc"
                                            ErrorMessage="Please Specify Description" meta:resourcekey="rfv_LeaveDesc" Text="*"
                                            ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_StartDate" runat="server" meta:resourcekey="lbl_StartDate"></asp:Label>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="txt_startDate" runat="server" TabIndex="3"
                                            Culture="English (United States)" Skin="WebBlue" MinDate="1900-01-01">
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_StartDate" runat="server" ControlToValidate="txt_startDate"
                                            ErrorMessage="Please Enter StartDate" meta:resourcekey="rfv_StartDate" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_EndDate" runat="server" meta:resourcekey="lbl_EndDate"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="txt_endDate" runat="server" TabIndex="4"
                                            Skin="WebBlue" MinDate="1900-01-01">
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td>
                                        <asp:CompareValidator ID="cv_endDate" runat="server" ControlToCompare="txt_startDate"
                                            ControlToValidate="txt_endDate" Operator="GreaterThan" meta:resourcekey="cv_endDate" ValidationGroup="Controls"
                                            Text="*"></asp:CompareValidator>
                                    </td>
                                </tr>
                            </caption>
                        </table>
                        <br />
                        <table align="center">
                            <tr runat="server" id="trLeaveItem" visible="false">
                                <td>
                                    <asp:Label ID="lbl_LeaveItem" runat="server" meta:resourcekey="lbl_LeaveItem"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddl_LeaveItem" runat="server" MarkFirstMatch="true" TabIndex="5"
                                        Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ddl_LeaveItem" runat="server" ValidationGroup="btn_Include_Group"
                                        ErrorMessage="Please Select Leave Item" Text="*" ControlToValidate="ddl_LeaveItem"
                                        InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_DaysPerYear" runat="server" meta:resourcekey="lbl_DaysPerYear"></asp:Label>
                                </td>
                                <td>&nbsp;<b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_DaysPerYear" runat="server" TabIndex="6"
                                        AutoPostBack="True" Culture="English (United States)" Skin="WebBlue" MaxLength="5"
                                        MaxValue="60" MinValue="0" OnTextChanged="rntxt_DaysPerYear_TextChanged">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_ddl_Period" runat="server" ValidationGroup="btn_Include_Group"
                                        ErrorMessage="Please Specify Days Per Year" Text="*" ControlToValidate="rntxt_DaysPerYear"
                                        InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>&nbsp;
                                </td>
                                <td colspan="4">
                                    <asp:CheckBox ID="chk_holidays" runat="server" meta:resourcekey="chk_holidays" TabIndex="7" />
                                    &nbsp;
                                    <asp:CheckBox ID="chk_HalfDays" runat="server" meta:resourcekey="chk_HalfDays" TabIndex="8" />
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table align="center">
                            <tr runat="server" id="trAccumulate" visible="false">
                                <td>
                                    <asp:CheckBox ID="chk_Accumulate" runat="server" AutoPostBack="True" meta:resourcekey="chk_Accumulate" TabIndex="9"
                                        OnCheckedChanged="chk_Accumulate_CheckedChanged" Style="font-weight: bold" />
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbl_MaxDaysAllow" runat="server" meta:resourcekey="lbl_MaxDaysAllow"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_MaxDaysAllow" runat="server" TabIndex="10"
                                        Enabled="False" Skin="WebBlue" MaxLength="2" MaxValue="100" MinValue="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr runat="server" id="trcarryforward" visible="false">
                                <td>
                                    <asp:CheckBox ID="chk_carryforward" runat="server" AutoPostBack="True" CssClass="style1" TabIndex="11"
                                        meta:resourcekey="chk_carryforward" OnCheckedChanged="chk_carryforward_CheckedChanged"
                                        Style="font-weight: bold" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_MaxDays" runat="server" meta:resourcekey="lbl_MaxDays"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_MaxDays" runat="server" TabIndex="12"
                                        Skin="WebBlue" Enabled="False" MaxLength="2" MaxValue="100" MinValue="0"
                                        LabelCssClass="">
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr runat="server" id="trEncashment" visible="false">
                                <td>
                                    <asp:CheckBox ID="chk_Encashment" runat="server" AutoPostBack="True" ForeColor="Black" TabIndex="13"
                                        meta:resourcekey="chk_Encashment" OnCheckedChanged="chk_Encashment_CheckedChanged"
                                        Style="font-weight: 700" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_MaxEncashable" runat="server" meta:resourcekey="lbl_MaxEncashable"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rntxt_MaxExncashable"
                                        runat="server" Enabled="False" Skin="WebBlue" MaxLength="2" MaxValue="100"
                                        MinValue="0">
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkAutoIncrmntLevs" runat="server" AutoPostBack="True" ForeColor="Black"
                                        Text="Auto Increment Leaves" OnCheckedChanged="chkAutoIncrmntLevs_CheckedChanged"
                                        Style="font-weight: 700" />
                                </td>
                                <td>
                                    <asp:Label ID="lblAutoIncrmntLevs" runat="server" Text="No. of days to Increment"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rtxtAutoIncrmntLevs" runat="server" Enabled="False" Skin="WebBlue" MaxLength="3" MaxValue="10"
                                        MinValue="0.0">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvAutoIncrmntLevs" runat="server" ControlToValidate="rtxtAutoIncrmntLevs" ForeColor="Red" Enabled="false"
                                            ErrorMessage="Please Enter No. of days to Increment" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revAutoIncrmntLevs" runat="server" ValidationGroup="btn_Include_Group" ControlToValidate="rtxtAutoIncrmntLevs"
                                        ValidationExpression="^[0-9]+(\.[05])?$" Text="*" ErrorMessage="Please Enter Valid Days to Increment"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr runat="server" id="trInclude" visible="false">
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Include" runat="server" meta:resourcekey="btn_Include" OnClick="btn_Include_Click" TabIndex="14"
                                        OnClientClick="disableButton(this,'btn_Include_Group')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="15" />
                                </td>
                            </tr>
                        </table>
                        <table align="center" width="100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_LeaveDetails" runat="server" Visible="false"
                                        AutoGenerateColumns="False" Skin="WebBlue" GridLines="None" meta:resourcekey="RG_LeaveDetails"
                                        OnItemCommand="RG_LeaveDetails_ItemCommand" Width="100%">
                                        <ClientSettings>
                                            <Scrolling AllowScroll="True" />
                                        </ClientSettings>
                                        <MasterTableView>
                                            <Columns>
                                                <%--<telerik:GridButtonColumn CommandName="Edititem" meta:resourcekey="GridButtonColumn"
                                                    Text="Edit" UniqueName="Edit">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn CommandName="Del_Rec" meta:resourcekey="GridButtonColumn"
                                                    Text="Delete" UniqueName="Delete" ConfirmText="Are you Sure... You want to Delete"
                                                    ConfirmDialogType="RadWindow" ConfirmTitle="Leave Structure">
                                                </telerik:GridButtonColumn>--%>
                                                <telerik:GridTemplateColumn HeaderText="ID" UniqueName="TemplateColumn" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_ID" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_ID"
                                                            Text='<%# Eval("LEAVESTRUCTDET_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="LEAVETYPEID" meta:resourcekey="LEAVETYPEID"
                                                    UniqueName="TemplateColumn1" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_LEAVETYPE_ID" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_LEAVETYPE_ID"
                                                            Text='<%# Eval("LEAVESTRUCTDET_LEAVETYPE_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Leave&nbsp;Item" meta:resourcekey="LEAVETYPE"
                                                    UniqueName="TemplateColumn2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVETYPE_NAME" runat="server" meta:resourcekey="lbl_LEAVETYPE_NAME"
                                                            Text='<%# Eval("LEAVETYPE_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Holidays" meta:resourcekey="WEEKLYOFF" UniqueName="TemplateColumn3">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_ISWEEKLYOFF" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_ISWEEKLYOFF"
                                                            Text='<%# Eval("LEAVESTRUCTDET_ISWEEKLYOFF") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Allow&nbsp;Half&nbsp;Days" meta:resourcekey="ALLOWHALFDAYS"
                                                    UniqueName="TemplateColumn4">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_ALLOWHALFDAYS" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_ALLOWHALFDAYS"
                                                            Text='<%# Eval("LEAVESTRUCTDET_ALLOWHALFDAYS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Accumulate" meta:resourcekey="ACCUMULATE"
                                                    UniqueName="TemplateColumn5" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_ACCUMULATE" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_ACCUMULATE"
                                                            Text='<%# Eval("LEAVESTRUCTDET_ACCUMULATE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Days&nbsp;Per&nbsp;Year" meta:resourcekey="DAYSPERYEAR"
                                                    UniqueName="TemplateColumn8">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_DAYSPERYEAR" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_DAYSPERYEAR"
                                                            Text='<%# Eval("LEAVESTRUCTDET_DAYSPERYEAR") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Max&nbsp;Days" meta:resourcekey="MAXDAYS"
                                                    UniqueName="TemplateColumn9">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_MAXDAYS" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_MAXDAYS"
                                                            Text='<%# Eval("LEAVESTRUCTDET_MAXDAYS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="CARRYFORWARD" meta:resourcekey="CARRYFORWARD"
                                                    UniqueName="TemplateColumn10" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_CFORWARD" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_CFORWARD"
                                                            Text='<%# Eval("LEAVESTRUCTDET_CFORWARD") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="CFMAXDAYS" meta:resourcekey="CFMAXDAYS" UniqueName="TemplateColumn11"
                                                    Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_CFMAXDAYS" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_CFMAXDAYS"
                                                            Text='<%# Eval("LEAVESTRUCTDET_CFMAXDAYS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="ENCASHMENT" meta:resourcekey="ENCASHMENT"
                                                    UniqueName="TemplateColumn13" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_ENCASHMENT" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_ENCASHMENT"
                                                            Text='<%# Eval("LEAVESTRUCTDET_ENCASHMENT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="MAXENCASHDAYS" meta:resourcekey="MAXENCASHDAYS"
                                                    UniqueName="TemplateColumn14" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_LEAVESTRUCTDET_MAXENCASHDAYS" runat="server" meta:resourcekey="lbl_LEAVESTRUCTDET_MAXENCASHDAYS"
                                                            Text='<%# Eval("LEAVESTRUCTDET_MAXENCASHDAYS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridButtonColumn CommandName="Edititem" meta:resourcekey="GridButtonColumn"
                                                    Text="Edit" UniqueName="Edit">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn CommandName="Del_Rec" meta:resourcekey="GridButtonColumn"
                                                    Text="Delete" UniqueName="Delete" ConfirmText="Are you Sure... You want to Delete"
                                                    ConfirmDialogType="RadWindow" ConfirmTitle="Leave Structure">
                                                </telerik:GridButtonColumn>
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
                        <br />
                        <table align="center">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="16"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Update_Click" TabIndex="16"
                                        ValidationGroup="Controls" />
                                    <asp:Button ID="btnCancel" runat="server" meta:resourcekey="btnCancel" TabIndex="17"
                                        OnClick="btnCancel_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_LeaveStruct" runat="server" ValidationGroup="Controls"
        ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vs_LeaveStruct" />
    <asp:ValidationSummary ID="vs_LeaveStruct1" runat="server" ValidationGroup="btn_Include_Group"
        ShowMessageBox="True" ShowSummary="False" />
</asp:Content>