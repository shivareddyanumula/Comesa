<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_SalaryStructure.aspx.cs" Inherits="Masters_frm_SalaryStructure"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_SalStructure" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_Salary">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Save">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Update">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RG_SalaryStruct">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center" style="width: 60%">
        <tr>
            <td align="center">
                <telerik:RadMultiPage ID="RMP_SalaryStruct" runat="server" Font-Bold="True" SelectedIndex="0"
                    meta:resourcekey="RMP_SalaryStruct">
                    <telerik:RadPageView ID="RP_SalaryStruct_Search" runat="server" meta:resourcekey="RP_SalaryStruct_Search"
                        Selected="True" Height="490px">
                        <br />
                        <table style="width: 80%" align="center">
                            <tr>
                                <td colspan="3">
                                    <center>
                                        <asp:Label ID="lbl_Salary" runat="server" Font-Bold="True" Text="Salary Structure "
                                            meta:resourcekey="lbl_Salary"></asp:Label>
                                    </center>
                                    <asp:Label ID="lbl_ID" runat="server" meta:resourcekey="lbl_ID" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td style="text-align: right"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" align="left">
                                    <telerik:RadGrid ID="RG_Salary" runat="server" Skin="WebBlue" GridLines="None" AutoGenerateColumns="False"
                                        OnNeedDataSource="RG_Salary_NeedDataSource" Width="95%" OnItemCommand="RG_Salary_ItemCommand"
                                        AllowPaging="true" AllowFilteringByColumn="true">
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <PagerStyle AlwaysVisible="true" />
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="SALARYSTRUCT_ID" HeaderText="ID" meta:resourcekey="SALARYSTRUCT_ID"
                                                    UniqueName="SALARYSTRUCT_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SALARYSTRUCT_CODE" HeaderText=" Name"
                                                    meta:resourcekey="SALARYSTRUCT_CODE" UniqueName="SALARYSTRUCT_CODE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SALARYSTRUCT_NAME" HeaderText=" Description"
                                                    meta:resourcekey="SALARYSTRUCT_NAME" UniqueName="SALARYSTRUCT_NAME" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SALARYSTRUCT_STARTDATE" HeaderText="Start Date"
                                                    meta:resourcekey="SALARYSTRUCT_STARTDATE" UniqueName="SALARYSTRUCT_STARTDATE"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SALARYSTRUCT_ENDDATE" HeaderText="End Date" meta:resourcekey="SALARYSTRUCT_ENDDATE"
                                                    UniqueName="SALARYSTRUCT_ENDDATE" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn meta:resourcekey="GridTemplateColumn" UniqueName="Edit" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_SalStructEdit" runat="server" CommandArgument='<%# Eval("SALARYSTRUCT_ID") %>'
                                                            meta:resourcekey="lnk_SalStructEdit" OnCommand="lnk_SalStructEdit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <PagerStyle AlwaysVisible="True" />
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnClick="lnk_Add_Click">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <HeaderContextMenu>
                                        </HeaderContextMenu>
                                        <PagerStyle AlwaysVisible="true" />
                                        <FilterMenu>
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_SalaryStruct_AddUpdate" runat="server">
                        <table align="center" style="width: 60%">
                            <tr>
                                <td>
                                    <table style="width: 60%" align="center">
                                        <tbody>
                                            <tr>
                                                <td colspan="8" align="center">
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Salary Structure "></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" align="center">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Code" runat="server" meta:resourcekey="lbl_Code"></asp:Label>
                                                </td>
                                                <td>:
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="txt_SalCode" runat="server" Skin="WebBlue" MaxLength="50" TabIndex="1">
                                                    </telerik:RadTextBox>
                                                </td>
                                                <td align="left">
                                                    <asp:RequiredFieldValidator ID="rfv_Name" runat="server" ControlToValidate="txt_SalCode"
                                                        ErrorMessage="Please Enter Name" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Name" runat="server" meta:resourcekey="lbl_Name"></asp:Label>
                                                </td>
                                                <td>:
                                                </td>
                                                <td align="left">
                                                    <telerik:RadTextBox ID="txt_SalName" runat="server" Skin="WebBlue" MaxLength="50" TabIndex="2">
                                                        <EmptyMessageStyle Font-Italic="True" />
                                                    </telerik:RadTextBox>
                                                </td>
                                                <%--<td align="left">
                                                    <asp:RequiredFieldValidator ID="rfv_SalName" runat="server" ControlToValidate="txt_SalName"
                                                        meta:resourcekey="rfv_SalName" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_StartDate" runat="server" meta:resourcekey="lbl_StartDate" Text="Start&amp;nbsp;Date"></asp:Label>
                                                </td>
                                                <td>:
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="txt_StartDate" runat="server" Skin="WebBlue" MinDate="1900-01-01" TabIndex="3">
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="left">
                                                    <asp:RequiredFieldValidator ID="rfv_StartDate" runat="server" ControlToValidate="txt_StartDate"
                                                        Text="*" ValidationGroup="Controls" meta:resourcekey="rfv_StartDate" ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_EndDate" runat="server" meta:resourcekey="lbl_EndDate"></asp:Label>
                                                </td>
                                                <td>:
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="txt_EndDate" runat="server" Culture="English (United States)" TabIndex="4"
                                                        Skin="WebBlue" FocusedDate="2009-08-06" MinDate="1900-01-01">
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="left">
                                                    <asp:CompareValidator ID="cv_EndDate" runat="server" ControlToCompare="txt_StartDate"
                                                        ControlToValidate="txt_EndDate" Display="Dynamic" meta:resourcekey="cv_EndDate"
                                                        Operator="GreaterThanEqual" Text="*" Type="Date" ValidationGroup="Controls"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_Type" runat="server" meta:resourcekey="lbl_Type"></asp:Label>
                                                </td>
                                                <td>:
                                                </td>
                                                <td align="left">
                                                    <telerik:RadComboBox ID="rcb_Type" runat="server" Skin="WebBlue" MarkFirstMatch="true" TabIndex="5"
                                                        OnSelectedIndexChanged="rcb_Type_SelectedIndexChanged" Filter="Contains">
                                                    </telerik:RadComboBox>
                                                </td>
                                                <td align="left">
                                                    <asp:RequiredFieldValidator ID="rfv_Type" runat="server" ControlToValidate="rcb_Type"
                                                        InitialValue="Select" meta:resourcekey="rfv_Type" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td align="left">&nbsp;
                                                </td>
                                                <td align="left">&nbsp;
                                                </td>
                                            </tr>
                                            <tr id="trUpdate" runat="server">
                                                <td align="left" colspan="7">
                                                    <asp:Label ID="lbl_Updateall" runat="server" Text="Do You Want to Update These Payitems to All Employee Who Belongs To This Salary Structure"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chk_Updateall" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" align="left" style="text-align: center">
                                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="6"
                                                        Text="Save" ValidationGroup="Controls" />
                                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Update_Click" TabIndex="6"
                                                        Text="Update" ValidationGroup="Controls" />
                                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="7" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <asp:ValidationSummary ID="vs_Salary" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                        ValidationGroup="Controls" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_Message" Text="(Note: Percentages specified are in corresponding with Basic)"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 90%" align="left">
                                                <telerik:RadGrid ID="RG_SalaryStruct" runat="server" AutoGenerateColumns="False"
                                                    Skin="WebBlue" GridLines="None" OnItemCreated="RG_SalaryStruct_ItemCreated"
                                                    meta:resourcekey="RG_SalaryStructResource1" Width="100%">
                                                    <%--onitemcreated="RG_SalaryStruct_ItemCreated"  --%>

                                                    <MasterTableView>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderText="Select" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk_Select" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Code" meta:resourcekey="GridTemplateColumnResource2"
                                                                UniqueName="Code" Visible="False" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPAYITEM_ID" runat="server" meta:resourcekey="lblPAYITEM_IDResource1"
                                                                        Text='<%# Eval("PAYITEM_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Pay Item" meta:resourcekey="GridTemplateColumnResource3"
                                                                UniqueName="PayItem" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPAYITEMNAME" runat="server" meta:resourcekey="lblPAYITEMNAMEResource1"
                                                                        Text='<%# Eval("PAYITEM_PAYITEMNAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Item Type" meta:resourcekey="GridTemplateColumnResource4"
                                                                UniqueName="type" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItemType" runat="server" meta:resourcekey="lblCALMODEResource1"
                                                                        Text='<%# Eval("HR_MASTER_CODE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Mode" meta:resourcekey="GridTemplateColumnResource4"
                                                                UniqueName="Mode" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCALMODE" runat="server" meta:resourcekey="lblCALMODEResource1"
                                                                        Text='<%# Eval("PAYITEM_CALMODE_1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Mode" meta:resourcekey="GridTemplateColumnResource4"
                                                                UniqueName="Mode" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCALMODE_1" runat="server" meta:resourcekey="lblCALMODEResource1"
                                                                        Text='<%# Eval("PAYITEM_CALMODE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Value" meta:resourcekey="GridTemplateColumnResource5"
                                                                UniqueName="Value" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtNumber" runat="server" AutoCompleteType="Disabled" meta:resourcekey="txtNumberResource1"
                                                                        Style="text-align: right" Text='<%# Eval("VALUE") %>' ValidationGroup="Controls"
                                                                        Width="110px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="rfv_Number" runat="server" ControlToValidate="txtNumber"
                                                                        ErrorMessage="Enter only Positive Numerical Values" meta:resourcekey="rfv_NumberResource1"
                                                                        Text="*" ValidationExpression="^[+]?[0-9]*\.?[0-9]+$" ValidationGroup="Controls"></asp:RegularExpressionValidator>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Annual Value" UniqueName="AnnualValue" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtAnnualNumber" runat="server" AutoCompleteType="Disabled" Style="text-align: right"
                                                                        Width="110px" Text='<%# Eval("ANNUAL_VALUE") %>'></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblSSDetID" Text='<%# Eval("PAYITEM_ID") %>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
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
                                    `
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>