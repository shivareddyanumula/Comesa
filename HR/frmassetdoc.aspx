<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmassetdoc.aspx.cs" Inherits="HR_frmassetdoc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <%--<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <telerik:RadAjaxManagerProxy ID="RAM_AssetDOC" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RG_AssetDoc">
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
            <telerik:AjaxSetting AjaxControlID="ddl_Employee">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <asp:UpdatePanel ID="updPanel" runat="server">
        <ContentTemplate>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Add record" Width="340"
                Modal="true" Height="160" Behaviors="Close" Left="580" VisibleStatusbar="false"
                OpenerElementID="<%# hyp_Link.ClientID %>">
                <ContentTemplate>
                    <br />
                    <br />
                    <table align="center">
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Name" ForeColor="Black" />
                            </td>
                            <td>
                                <b>:</b>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txt_Asset_Type" runat="server">
                                </telerik:RadTextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btn_Type_Save" runat="server" Text="Save" OnClick="btn_Type_Save_Click1" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </telerik:RadWindow>
            <table align="center">
                <tr>
                    <td>
                        <telerik:RadMultiPage ID="RMP_AssetDoc" runat="server" SelectedIndex="0">
                            <telerik:RadPageView ID="Search" runat="server" Width="990px" Height="490px">
                                <table align="center">
                                    <tr>
                                        <td colspan="3" align="center">
                                            <asp:Label ID="lbl_Name" runat="server" Style="font-weight: 700"> </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="RG_AssetDoc" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                Skin="WebBlue" GridLines="None" OnNeedDataSource="RG_AssetDoc_NeedDataSource"
                                                Width="100%" AllowFilteringByColumn="True">
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                                <PagerStyle AlwaysVisible="true" />
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EMPASSETDOC_ID" HeaderText="ID" UniqueName="EMPASSETDOC_ID"
                                                            Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Business Unit"
                                                            UniqueName="BUSINESSUNIT_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NAME" HeaderText="Employee Name" UniqueName="NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSETDOC_SERIAL" HeaderText="Serial" UniqueName="EMPASSETDOC_SERIAL"
                                                            Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DEPARTMENT_NAME" HeaderText="Asset Department" UniqueName="DEPARTMENT_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_ASSETDOC_ISSUEDATE" HeaderText="Issue Date" UniqueName="EMP_ASSETDOC_ISSUEDATE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <%--<telerik:GridBoundColumn DataField="Type" HeaderText="Type" UniqueName="Type">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <%-- <telerik:GridBoundColumn DataField="EMP_ASSETDOC_ISSUEDATE" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"
                                                            UniqueName="EMP_ASSETDOC_ISSUEDATE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <%--    <telerik:GridDateTimeColumn DataField="EMP_ASSETDOC_ISSUEDATE" DataFormatString="{0:dd/MM/yyyy}" UniqueName="EMP_ASSETDOC_ISSUEDATE"
                                                            HeaderText="Issue Date" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridDateTimeColumn>--%>
                                                        <telerik:GridBoundColumn DataField="EMPLOYEE_SCALE" UniqueName="EMPLOYEE_SCALE" HeaderText="Employee Grade">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_AssetDoc_Edit" runat="server" CommandArgument='<%# Eval("EMPASSETDOC_ID") %>'
                                                                    OnCommand="lnk_AssetDoc_Edit_Command">Edit </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <%--<telerik:GridTemplateColumn UniqueName="Delete" AllowFiltering="false">
                                                        <itemtemplate>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("EMPASSETDOC_ID") %>'
                                                                    OnCommand="lnk_AssetDoc_Delete_Command">Delete</asp:LinkButton>
                                                            </itemtemplate>
                                                        </telerik:GridTemplateColumn>--%>
                                                    </Columns>
                                                    <EditFormSettings>
                                                        <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" InsertImageUrl="Update.gif"
                                                            UpdateImageUrl="Update.gif">
                                                        </EditColumn>
                                                    </EditFormSettings>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" OnClick="lnk_Add_Click" Text="Add"></asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView><PagerStyle AlwaysVisible="true" />
                                                <FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                                <GroupingSettings CaseSensitive="false" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="AddUpdate" runat="server" Width="990px" Height="790px">
                                <table align="center">
                                    <tr>
                                        <td colspan="3" style="text-align: center">
                                            <asp:Label ID="lbl_DetName" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="text-align: center"></td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_Type" runat="server"></asp:Label>
                                            <asp:HiddenField ID="HF_ID" runat="server" />
                                        </td>
                                        <td></td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="txt_Type" runat="server" Skin="WebBlue">
                                            </telerik:RadTextBox>
                                            <asp:Label ID="lbl_EmployeeName" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_ADType" runat="server" ControlToValidate="txt_Type"
                                                meta:resourcekey="RFV_ADType" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddl_BusinessUnit" runat="server" MarkFirstMatch="true" AutoPostBack="True" MaxHeight="120px"
                                                Skin="WebBlue" OnSelectedIndexChanged="ddl_BusinessUnit_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_ddl_BusinessUnit" runat="server" ControlToValidate="ddl_BusinessUnit"
                                                ErrorMessage="Please Select Business Unit" meta:resourcekey="RFV_ddl_BusinessUnit"
                                                Text="*" ValidationGroup="Controls" InitialValue="Select"> </asp:RequiredFieldValidator>
                                        </td>
                                        <td>&#160;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_Directorate" runat="server" Text="Directorate"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="rad_Directorate" runat="server" MarkFirstMatch="true" AutoPostBack="True" MaxHeight="120px"
                                                Skin="WebBlue" OnSelectedIndexChanged="rad_Directorate_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rad_Directorate" runat="server" ControlToValidate="rad_Directorate"
                                                ErrorMessage="Please Select Directorate" Text="*" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>&#160;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_Department" runat="server" Text="Department"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="rad_Department" runat="server" MarkFirstMatch="true" AutoPostBack="True"
                                                Skin="WebBlue" OnSelectedIndexChanged="rad_Department_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <%--  <td>
                                          <asp:RequiredFieldValidator ID="rfv_Department" runat="server" ControlToValidate="rad_Department"
                                          ErrorMessage="Please Select Department" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>

                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblEmployee" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="ddl_Employee" runat="server" AutoPostBack="True" Skin="WebBlue"
                                                OnSelectedIndexChanged="ddl_Employee_SelectedIndexChanged" MaxHeight="120px"
                                                MarkFirstMatch="true" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Employee" runat="server" ControlToValidate="ddl_Employee"
                                                meta:resourcekey="RFV_Employee" Text="*" ValidationGroup="Controls" InitialValue="Select"> </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="lbl_Serial_tr" visible="false">
                                        <td align="left">
                                            <asp:Label ID="lbl_Serial" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td>&#160;
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="txt_Serial" Skin="WebBlue" runat="server" ReadOnly="True"
                                                Visible="False">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%--    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="txt_Name" Skin="WebBlue" runat="server" AutoCompleteType="Disabled"
                                                MaxLength="50">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Name" runat="server" ControlToValidate="txt_Name"
                                                meta:resourcekey="RFV_Name" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                    <%--    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_Code" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadTextBox ID="txt_Code" runat="server" AutoCompleteType="Disabled" Skin="WebBlue"
                                                MaxLength="50">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Code" runat="server" ControlToValidate="txt_Code"
                                                meta:resourcekey="RFV_Code" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                    <tr id="tr_AssetDepartment" runat="server">
                                        <td align="left">
                                            <asp:Label ID="lbl_AssetDepartment" runat="server" Text="Asset Department"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="rad_AssetDepartment" runat="server" MarkFirstMatch="true" AutoPostBack="True"
                                                Skin="WebBlue" OnSelectedIndexChanged="rad_AssetDepartment_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_AssetDepartment" runat="server" ControlToValidate="rad_AssetDepartment"
                                                ErrorMessage="Please Select Asset Department" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>



                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblType" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <%-- <td align="left">
                                            
                                            <asp:LinkButton ID="hyp_Link" runat="server" Text="Add New" Visible="false"></asp:LinkButton>
                                        </td>--%>
                                        <td>
                                            <telerik:RadComboBox ID="ddlType" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                                Skin="WebBlue" Filter="Contains">
                                            </telerik:RadComboBox>
                                            <%--<telerik:RadListBox ID="RL_Type" runat="server" CheckBoxes="true" Height="100" Skin="WebBlue"
                                                Width="200">
                                            </telerik:RadListBox>--%>
                                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                            <asp:LinkButton ID="hyp_Link" runat="server" Text="Add New" Visible="false"></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Type" runat="server" ControlToValidate="ddlType" InitialValue="Select"
                                                Text="*" ErrorMessage="Please Select Asset" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbl_IssueDate" runat="server" Text="Issue Date"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <telerik:RadDatePicker ID="txt_Date" runat="server" Skin="WebBlue">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_Date" runat="server" ControlToValidate="txt_Date"
                                                meta:resourcekey="RFV_Date" Text="*" ValidationGroup="Controls">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblReturnable" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chk_Returnable" runat="server" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>&nbsp;
                                        </td>
                                        <td align="left">
                                            <%--<telerik:RadTextBox ID="txt_Remarks" Skin="WebBlue" runat="server" AutoCompleteType="Disabled"
                                                MaxLength="500">
                                            </telerik:RadTextBox>--%>
                                            <telerik:RadTextBox ID="txt_Remarks" runat="server" SkinID="eAssests"
                                                MaxLength="500" TextMode="MultiLine" CssClass="eRadTextBox"
                                                Style="resize: none; width: 250px; height: 150px;">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%-- <tr id="Businessunit" runat="server">
                                        <td align="left">
                                            <asp:Label ID="lbl_Bu" runat="server" Text="Business unit"></asp:Label>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbl_bold3" runat="server" Text=":"></asp:Label></b>&nbsp;
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="rcmb_Businessunit" runat="server" AutoPostBack="True" Skin="WebBlue"
                                                Height="22px" MarkFirstMatch="true" OnSelectedIndexChanged="rcmb_Businessunit_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            &#160;
                                        </td>
                                    </tr>--%>
                                    <%-- <tr runat="server" id="lblReceived_tr">
                                        <td align="left">
                                            <asp:Label ID="lblReceived" runat="server" meta:resourcekey="lblReceived"></asp:Label>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbl_bold1" runat="server" Text=":"></asp:Label></b>&nbsp;
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="rcmb_Employee" runat="server" AutoPostBack="True" Skin="WebBlue"
                                                MarkFirstMatch="true">
                                            </telerik:RadComboBox>
                                            <%-- <telerik:RadTextBox  ID="rtxt_Received" runat="server"
                                                AutoCompleteType="Disabled" Skin="WebBlue" Visible="false">                                                
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                                    <%--           <tr runat="server" id="lblReceivedDate_tr">
                                        <td align="left">
                                            <asp:Label ID="lblReceivedDate" runat="server" meta:resourcekey="lblReceivedDate"></asp:Label>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbl_bold2" runat="server" Text=":"></asp:Label></b>&#160;
                                        </td>
                                        <td align="left">
                                            <telerik:RadDatePicker ID="txt_Receiveddate" runat="server" Skin="WebBlue" MinDate="1900-01-01"
                                                Culture="English (United States)">
                                                <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                    ViewSelectorText="x">
                                                </Calendar>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                <DateInput DateFormat="d/M/yyyy" DisplayDateFormat="d/M/yyyy">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:CompareValidator ID="cmp_ReceivedDate" runat="server" ControlToCompare="txt_Date"
                                                ControlToValidate="txt_Receiveddate" Display="Dynamic" meta:resourcekey="cmp_ReceivedDate"
                                                Type="Date" Operator="GreaterThanEqual" Text="*" ValidationGroup="Controls">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr> --%>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblUpload" runat="server" meta:resourcekey="lblUpload"></asp:Label>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbl_bold" runat="server" Text=":"> </asp:Label></b>
                                        </td>
                                        <td align="left">
                                            <asp:FileUpload ID="FUpload" runat="server" />
                                            <%--<asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="FUpload"
                                                ErrorMessage=".doc, .pdf formats are allowed"
                                                ValidationExpression="(.+\.([Dd][Oo][Cc])|.+\.([Pp][Dd][Ff]))" ValidationGroup="Controls"></asp:RegularExpressionValidator>--%>
                                        </td>
                                        <td>
                                            <%--<asp:Button ID="btn_Upload" runat="server" Text="Upload"
                                                OnClick="btn_Upload_Click" ValidationGroup="Controls" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">&#160;
                                        </td>
                                        <td>&#160;&#160;
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnk_Download" runat="server" Visible="False">Click Here to View</asp:LinkButton>
                                        </td>
                                        <td>&#160;
                                        </td>
                                    </tr>
                                    <tr id="trDelete" runat="server" visible="false">
                                        <td align="left">&#160;
                                        </td>
                                        <td>&#160;&#160;
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkDelete" runat="server" Visible="false"
                                                OnClick="lnkDelete_Click">Delete Document</asp:LinkButton>
                                        </td>
                                        <td>&#160;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update" OnClick="btn_Update_Click"
                                                ValidationGroup="Controls" />
                                            <asp:Button ID="btn_Save" runat="server" Text="Add" OnClick="btn_Save_Click"
                                                ValidationGroup="Controls" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" />
                                        </td>
                                        <td align="center">&#160;&#160;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:ValidationSummary ID="VS_EmpAssetDoc" runat="server" ShowMessageBox="True" ShowSummary="false"
                                                ValidationGroup="Controls" />
                                        </td>
                                        <td align="center">&#160;
                                        </td>
                                    </tr>
                                </table>
                                <table align="center">
                                    <tr id="tr_rg_docs" runat="server">
                                        <td>
                                            <asp:HiddenField ID="hdndocsEMPASSET_ID" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnEMPDOCS_ID" runat="server" Value="" />
                                            <telerik:RadGrid ID="rg_docs" runat="server" GridLines="None" Skin="WebBlue"
                                                AutoGenerateColumns="false" OnNeedDataSource="rg_docs_NeedDataSource">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_ID" UniqueName="EMPASSET_ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_ASSETID" UniqueName="EMPASSET_ASSETID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPDOCS_ID" UniqueName="EMPDOCS_ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Name" AllowFiltering="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_ISRETURNABLE" UniqueName="EMPASSET_ISRETURNABLE" HeaderText="Returnable" AllowFiltering="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_REMARKS" UniqueName="EMPASSET_REMARKS" HeaderText="Remarks">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_ISSUEDATE" UniqueName="EMPASSET_ISSUEDATE" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <%--<telerik:GridBoundColumn DataField="EMPDOCS_NAME" UniqueName="EMPDOCS_NAME" HeaderText="Name" AllowFiltering="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="EMPDOCS_UPLOAD" UniqueName="EMPDOCS_UPLOAD" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPDOCS_ASSETDOC_ID" UniqueName="EMPDOCS_ASSETDOC_ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbtn_download" runat="server" Text="DownLoad" CommandName='<%#Eval("EMPDOCS_NAME") %>'
                                                                    OnCommand="lbtn_download_OnCommand" CommandArgument='<%#Eval("EMPDOCS_UPLOAD") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Docs_Edit" runat="server" CommandArgument='<%# Container.ItemIndex %>'
                                                                    OnCommand="lnk_Docs_Edit_Command">Edit </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <%--<telerik:GridTemplateColumn AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbtn_delete" Text="Delete" runat="server" OnCommand="lbtn_delete_OnCommand" CommandName='<%#Eval("EMPDOCS_ID") %>'
                                                                    OnClientClick="return confirm('Are you sure you want to delete?')" CommandArgument='<%#Eval("EMPDOCS_UPLOAD") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>--%>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr id="tr_rg_assets" runat="server" visible="false">
                                        <td>
                                            <asp:HiddenField ID="hdnEMPASSET_ID" runat="server" Value="" />

                                            <telerik:RadGrid ID="rg_Assets" runat="server" GridLines="None" Skin="WebBlue"
                                                AutoGenerateColumns="false">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_ID" UniqueName="EMPASSET_ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_ASSETID" UniqueName="EMPASSET_ASSETID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ASSET_NAME" UniqueName="ASSET_NAME" HeaderText="Asset Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_ISRETURNABLE" UniqueName="EMPASSET_ISRETURNABLE" HeaderText="Returnable" AllowFiltering="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_REMARKS" UniqueName="EMPASSET_REMARKS" HeaderText="Remarks">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPASSET_ISSUEDATE" UniqueName="EMPASSET_ISSUEDATE" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Asset_Edit" runat="server" CommandArgument='<%# Container.ItemIndex %>'
                                                                    OnCommand="lnk_Asset_Edit_Command">Edit </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_Save" />
            <asp:PostBackTrigger ControlID="btn_Update" />
            <asp:PostBackTrigger ControlID="rg_docs" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
