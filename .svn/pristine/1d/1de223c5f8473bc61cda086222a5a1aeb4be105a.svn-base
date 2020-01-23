<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_EmployeeType.aspx.cs" Inherits="Masters_frm_EmployeeType" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RAM_EmployeeTypes" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_EmployeeTypes">
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
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_EmployeeTypeHeader" runat="server" Text="Employee Type" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <contenttemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_EmployeeTypes" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_EmployeeTypes_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EMPLOYEETYPE_ID" UniqueName="EMPLOYEETYPE_ID" HeaderText="ID"
                                                            meta:resourcekey="EMPLOYEETYPE_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                         
                                                        <telerik:GridBoundColumn DataField="EmployeeType_CODE" UniqueName="EmployeeType_CODE" HeaderText="Code"
                                                            meta:resourcekey="EmployeeType_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPLOYEETYPE_DESC" UniqueName="EMPLOYEETYPE_DESC" HeaderText="Description"
                                                            meta:resourcekey="EMPLOYEETYPE_DESC">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPLOYEETYPE_PREFIX" UniqueName="EMPLOYEETYPE_PREFIX" HeaderText="Prefix"
                                                            meta:resourcekey="EMPLOYEETYPE_PREFIX">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                          <telerik:GridBoundColumn DataField="EMPLOYEETYPE_SERIALNO" UniqueName="EMPLOYEETYPE_SERIALNO" HeaderText="Serial Number"
                                                            meta:resourcekey="EMPLOYEETYPE_SERIALNO">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMPLOYEETYPE_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                            UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                   
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" />
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                           <%-- <table>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>

                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td><a id="D2" runat="server"
                                                        href="~/Masters/Importsheets/EmployeeType_Template.xlsx">Download EmployeeType Details Template</a> </td>
                                                    <td><strong>:</strong></td>
                                                    <td>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_Imp_Businessunit" runat="server" Text="Import"
                                                            OnClick="Btn_Imp_Businessunit_click" />
                                                    </td>
                                                </tr>
                                            </table>--%>

                                        </td>
                                    </tr>
                                </table>
                            </contenttemplate>
                            <triggers>
                                <%--<asp:PostBackTrigger ControlID="btn_Imp_Businessunit" />--%>
                            </triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <table align="center" width="43%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                            </tr>

                            <tr>
                                <td>
                                    <br />
                                    <asp:Label ID="lbl_EmployeeTypeID" runat="server" Visible="False" meta:resourcekey="lbl_EmployeeTypeID"></asp:Label>
                                    <asp:Label ID="lbl_EmployeeTypeCode" runat="server" Text="Code" meta:resourcekey="lbl_EmployeeTypeCode"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_EmployeeTypeCode" runat="server" Skin="WebBlue" MaxLength="50" Enabled="false" TabIndex="1">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_EmployeeTypeCode" ControlToValidate="rtxt_EmployeeTypeCode"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Code cannot be Empty"
                                        meta:resourcekey="rfv_rtxt_EmployeeTypeCode" Text="*" Forecolor="Red">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_EmployeeTypeCode" ErrorMessage="Enter only Alphabets for EmployeeType Name"
                                        ValidationExpression="^[a-zA-Z''-'\s-]{1,50}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EmployeeTypeDesc" runat="server" Text="Description" meta:resourcekey="lbl_EmployeeTypeDesc"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_EmployeeTypeDesc" runat="server" TabIndex="2"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                    <%--  <asp:RequiredFieldValidator ID="rfv_rtxt_EmployeeTypeName" ControlToValidate="rtxt_EmployeeTypeName"
                                        runat="server" ValidationGroup="Controls" 
                                        ErrorMessage="Name cannot be Empty" 
                                        meta:resourcekey="rfv_rtxt_EmployeeTypeName">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_EmployeeTypePrefix" runat="server" Text="Prefix" meta:resourcekey="lbl_EmployeeTypePrefix"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_EmployeeTypePrefix" runat="server" Skin="WebBlue" MaxLength="100" TabIndex="3">
                                    </telerik:RadTextBox>
                                      <asp:RequiredFieldValidator ID="rfv_rtxt_EmployeeTypePrefix" ControlToValidate="rtxt_EmployeeTypePrefix"
                                        runat="server" ValidationGroup="Controls" 
                                        ErrorMessage="Please Enter Prefix " 
                                        meta:resourcekey="rfv_rtxt_EmployeeTypePrefix" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_EmployeeTypeSerialNo" runat="server"  Text="Serial Number" meta:resourcekey="lbl_EmployeeTypeSerialNo"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_EmployeeTypeSerialNo" runat="server" Enabled="false" Skin="WebBlue" MaxLength="100" TabIndex="4">
                                    </telerik:RadTextBox>
                                      <asp:RequiredFieldValidator ID="rfv_EmployeeTypeSerialNo" ControlToValidate="rtxt_EmployeeTypeSerialNo"
                                        runat="server" ValidationGroup="Controls" 
                                        ErrorMessage="Serial Number cannot be Empty" 
                                        meta:resourcekey="rfv_EmployeeTypeSerialNo" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                        <td>
                                            <asp:Label ID="lbl_EmpTypeAge" runat="server" Text="Age"></asp:Label>
                                        </td>
                                        <td runat="server"><strong>:</strong>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rmtxt_EmpTypeAge" runat="server" Culture="English (United States)"
                                               SkinId="1" DataType="System.Int32" LabelCssClass="" MaxLength="2"
                                                Skin="WebBlue" MinValue="18" MaxValue="99" Width="30px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rmtxt_EmpTypeAge" ControlToValidate="rmtxt_EmpTypeAge" runat="server" Text="*" 
                                                ErrorMessage="Please Enter Minimum Age" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            <telerik:RadNumericTextBox ID="rmtxt_EmpTypeAgeM" runat="server" Culture="English (United States)"
                                                LabelCssClass="" MaxLength="2" meta:resourcekey="rmtxt_BusinessUnitAgeM" Skin="WebBlue"
                                         SkinId="1" Width="30px" MaxValue="99" MinValue="18">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="rfv_rmtxt_EmpTypeAgeM" ControlToValidate="rmtxt_EmpTypeAgeM" runat="server" Text="*" 
                                                ErrorMessage="Please Enter Maximum Age" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="rcv_Age" runat="server" ControlToCompare="rmtxt_EmpTypeAge"
                                                ControlToValidate="rmtxt_EmpTypeAgeM" ErrorMessage="Minimum Age cannot be greater than Maximum Age"
                                                Operator="GreaterThan" ValidationGroup="Controls">*</asp:CompareValidator>
                                        </td>
                                    </tr>
                            <tr>
                               
                                <td align="center" colspan="3">
                                     <br />
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="5"
                                        Text="Update" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="5"
                                        Text="Save" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="6"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_EmployeeType" runat="server" ShowMessageBox="True" ShowSummary="False"
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
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
</asp:Content>--%>

