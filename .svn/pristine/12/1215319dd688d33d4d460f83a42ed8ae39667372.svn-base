<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmempidentification.aspx.cs" Inherits="HR_frmempidentification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <%--added by Joseph--%>
    <telerik:RadScriptBlock ID="Rsb_Scripts" runat="server">

        <script language="javascript" type="text/javascript">
            function checkboxClick(control) 
            {
                if (control.checked == true) 
                {
                    if (!confirm('Do you want to make this Bank as Default for this Employee')) 
                    {
                        control.checked = false;
                    }
                }
            }
        </script>

        <%--Completed--%>
    </telerik:RadScriptBlock>
    <telerik:RadAjaxManagerProxy ID="RAM_EMPIDEN" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_Identification">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Add">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Correct">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <table style="width: 60%;" align="center">
        <tr>
            <td>
                <telerik:RadMultiPage ID="RMP_Identification" runat="server" Width="990px" Height="490px"
                    ScrollBars="Auto">
                    <telerik:RadPageView ID="RPV_Identification" runat="server">
                        <table style="width: 70%;" align="center">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl_Header" runat="server" meta:resourcekey="lbl_Header"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <telerik:RadGrid  ID="RG_Identification" runat="server" AutoGenerateColumns="False"
                                         Skin="WebBlue"  Width="98%" OnNeedDataSource="RG_Identification_NeedDataSource"
                                        GridLines="None" AllowPaging="true" AllowFilteringByColumn="True">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EMPBNKDTLS_ID" HeaderText="ID" UniqueName="EMPBNKDTLS_ID"
                                                    Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUNIT" HeaderText="BUSINESS UNIT" UniqueName="BUNIT">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EMPNAME" HeaderText="EMPLOYEE NAME" UniqueName="EMPNAME">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" HeaderText="BANK NAME" UniqueName="HR_MASTER_CODE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSUNTBANK_ACCOUNTNO" HeaderText="ACCOUNT NUMBER"
                                                    UniqueName="BUSUNTBANK_ACCOUNTNO">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="BUSUNTBANK_ISACTIVE" HeaderText="ACTIVE" UniqueName="BUSUNTBANK_ISACTIVE">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="False" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EMPBNKDTLS_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit </asp:LinkButton></ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                    UpdateImageUrl="Update.gif">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_Add" OnClick="lnk_Add_Click"
                                                        Text="Add"></asp:LinkButton></div>
                                            </CommandItemTemplate>
                                        </MasterTableView><PagerStyle AlwaysVisible="true" />
                                        <FilterMenu  Skin="WebBlue" >
                                        </FilterMenu>
                                        <HeaderContextMenu  Skin="WebBlue" >
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RPF_IdentificationDet" runat="server">
                        <table align="center">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lbl_Details" runat="server" meta:resourcekey="lbl_Details"></asp:Label>
                                </td>
                            </tr>
                            <caption>
                                <br />
                                <br />
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox  ID="rcmb_BusinessUnit" runat="server" AutoPostBack="True"  Skin="WebBlue" 
                                            OnSelectedIndexChanged="rcmb_BusinessUnit_SelectedIndexChanged" MarkFirstMatch="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Employee" runat="server" meta:resourcekey="lbl_Employee"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox  ID="rcmb_Employee" runat="server"  Skin="WebBlue" MarkFirstMatch="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_Employee" runat="server" ControlToValidate="rcmb_Employee"
                                            meta:resourcekey="rfv_Employee" Text="*" ValidationGroup="Controls" InitialValue="Select"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_BankName" runat="server" meta:resourcekey="lbl_BankName"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmb_Bank" runat="server" onselectedindexchanged="rcmb_Bank_SelectedIndexChanged"
                                             AutoPostBack="True" MarkFirstMatch="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_BankName" runat="server" ControlToValidate="rcmb_Bank"
                                            meta:resourcekey="rfv_BankName" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_BranchName" runat="server" meta:resourcekey="lbl_BranchName"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcmb_Branch" runat="server" MarkFirstMatch="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_BranchName" runat="server" ControlToValidate="rcmb_Branch"
                                            meta:resourcekey="rfv_BranchName" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_AccountNo" runat="server" meta:resourcekey="lbl_AccountNo"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox  ID="rtxt_AccountNo" runat="server"  Skin="WebBlue" 
                                            MaxLength="16">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfv_AccountNo" runat="server" ControlToValidate="rtxt_AccountNo"
                                            meta:resourcekey="rfv_AccountNo" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr id = "tr1" runat ="server">
                                    <td>
                                        <asp:Label ID="lbl_Address" runat="server" meta:resourcekey="lbl_Address"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox  ID="rtxt_Address" runat="server"  Skin="WebBlue" 
                                            LabelCssClass="" MaxLength="100">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <%--<asp:RequiredFieldValidator ID="rfv_Address" runat="server" ControlToValidate="rtxt_Address"
                                            meta:resourcekey="rfv_Address" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_SwiftCode" runat="server" meta:resourcekey="lbl_SwiftCode"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>&nbsp;
                                    </td>
                                    <td>
                                        <telerik:RadTextBox  ID="rtxt_SwiftCode" runat="server"  Skin="WebBlue" 
                                            LabelCssClass="" MaxLength="12">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_Active" runat="server" meta:resourcekey="lbl_Active"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>&#160;
                                    </td>
                                    <td>
                                        <telerik:RadComboBox  ID="rcmb_Active" runat="server"  Skin="WebBlue" MarkFirstMatch="true">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="Active" Value="1" />
                                                <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chk_Active" runat="server" Visible="false" />
                                    </td>
                                </tr>
                                <tr runat="server" id="default1">
                                    <td>
                                        <asp:Label ID="lbl_Default" runat="server" meta:resourcekey="lbl_Default"></asp:Label>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chk_Default" runat="server" onclick="checkboxClick(this)" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btn_Add" runat="server" meta:resourcekey="btn_Add" OnClick="btn_Add_Click"
                                            ValidationGroup="Controls" /><asp:Button ID="btn_Correct" runat="server" meta:resourcekey="btn_Correct"
                                                OnClick="btn_Correct_Click" ValidationGroup="Controls" /><asp:Button ID="btn_Cancel"
                                                    runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" />
                                    </td>
                                    <td align="center">
                                    </td>
                                </tr>
                            </caption>
                        </table>
                        <br />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vs_Identification" runat="server" ShowMessageBox="true"
        ShowSummary="false" ValidationGroup="Controls" />
</asp:Content>
