<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="MedicalBenfitClaimAdd.aspx.cs" Inherits="Medical_MedicalBenfitClaimAdd" %>

<%@ Register Src="~/BUFilter.ascx" TagName="BU" TagPrefix="BUFilter" %>
<%@ Register TagPrefix="Telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

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
            <td align="center">
                <asp:Label ID="lbl_MedicalBenfitClaimHeader" runat="server" Text="Medical Benefits Claim" Font-Bold="True"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="100%" ScrollBars="None">
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <table align="center" width="100%">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbl_ClaimType" runat="server" Text="Claim Type" meta:resourcekey="lbl_ClaimType"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="RadClaimType" runat="server" AutoPostBack="True"
                                                EmptyMessage="Select" Enabled="false">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Self" Value="Self" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Family" Value="Family" Selected="true" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfvClaimType" runat="server" Text="*" InitialValue="Select"
                                                ControlToValidate="RadClaimType" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Claim Type"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_Employee" runat="server" MarkFirstMatch="true" AutoPostBack="true" MaxHeight="200"
                                                Filter="Contains" OnSelectedIndexChanged="rcmb_Employee_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_Employee" runat="server" Text="*" InitialValue="Select"
                                                ControlToValidate="rcmb_Employee" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Employee"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblBusinesUnit" runat="server" Text="Busines Unit"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadTextBox ID="rtbBusinesUnit" runat="server" MarkFirstMatch="true"
                                                Enabled="false" Filter="Contains">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblDirectorate" runat="server" Text="Directorate"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadTextBox ID="rtbDirectorate" runat="server" MarkFirstMatch="true"
                                                Enabled="false" Filter="Contains">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadTextBox ID="rtbDepartment" runat="server" MarkFirstMatch="true"
                                                Enabled="false" Filter="Contains">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblFinPeriod" runat="server" Text="Financial Period"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbFinPeriod" runat="server" MarkFirstMatch="true" AutoPostBack="true"
                                                Filter="Contains" OnSelectedIndexChanged="rcbFinPeriod_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfvFinPeriod" runat="server" Text="*" InitialValue="Select"
                                                ControlToValidate="rcbFinPeriod" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Financial Period"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbl_MedicalClaimID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_Scale" runat="server" Text="Grade" meta:resourcekey="lbl_ExpenditureName"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtbEmpGrade" runat="server"
                                                Skin="WebBlue" MaxLength="50" Enabled="false" Filter="Contains">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbl_ServiceProviderName" runat="server" Text="Service Provider Name"
                                                meta:resourcekey="lbl_ServiceProviderName"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="RadServiceProviderName" runat="server" AutoPostBack="true"
                                                EmptyMessage="Select" Skin="WebBlue" MaxLength="50" Filter="Contains"
                                                OnSelectedIndexChanged="RadServiceProviderName_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfv_RadServiceProviderName" runat="server" Text="*" InitialValue="Select"
                                                ControlToValidate="RadServiceProviderName" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Service Provider Name"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trMedicalSvcPrvdr" runat="server" visible="false">
                                        <td align="right">                                            
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="radMedicalServiceProvider" runat="server" Skin="WebBlue" MaxLength="50"
                                                EmptyMessage="Enter Other Service Provider Name">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="rfvMedicalServiceProvider" runat="server" Text="*"
                                                ControlToValidate="radMedicalServiceProvider" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Enter Service Provider Name in the text box"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExpenditureName" runat="server" Text="Expenditure Name" meta:resourcekey="lblExpenditureName"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="radExpenditureName" runat="server" AutoPostBack="true" EmptyMessage="Select" Filter="Contains"
                                                OnSelectedIndexChanged="radExpenditureName_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="rfvExpenditureName" runat="server" Text="*" InitialValue="Select"
                                                ControlToValidate="radExpenditureName" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Select Expenditure Name"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trOtherExpndName" visible="false">
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <telerik:RadTextBox ID="rtbOtherExpndName" runat="server" EmptyMessage="Enter Other Expenditure Name">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="rfvOtherExpndName" runat="server" Text="*"
                                                ControlToValidate="rtbOtherExpndName" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Enter Expenditure Name in the text box"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExpenditureMaxEligibleAmount" runat="server" Text="Max Eligible Amount  (USD)"
                                                meta:resourcekey="lblExpenditureName"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMaxEligibleAmount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAvailableAmounttxt" runat="server" Text="Available Amount  (USD)"
                                                meta:resourcekey="lblExpenditureName"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAvailableAmount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblInvoiceDate" runat="server" Text="Claim Date/Invoice Date" meta:resourcekey="lblInvoiceDate"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdpInvoiceDate" runat="server"></telerik:RadDatePicker>
                                            <asp:RequiredFieldValidator ID="rfvInvoiceDate" runat="server" Text="*"
                                                ControlToValidate="rdpInvoiceDate" ValidationGroup="Controls" Display="Dynamic"
                                                ErrorMessage="Please Enter Claim Date/Invoice Date"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblUpload" runat="server" Text="Upload" meta:resourcekey="lblUpload"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FBrowse" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="labelClmTtlAmnt" runat="server" Text="Total 80% Rule Amount  (USD)"
                                                meta:resourcekey="lblExpenditureName"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblClmTtlAmnt" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="labelClmBalAmnt" runat="server" Text="Balance 80% Rule Amount  (USD)"
                                                meta:resourcekey="lblExpenditureName"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblClmBalAmnt" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <table align="center" width="100%">
                                    <tr>
                                        <td align="center">
                                            <br />
                                            <telerik:RadGrid ID="rgEmpDepndnts" runat="server" AutoGenerateColumns="False" Visible="true"
                                                AllowFilteringByColumn="false" AllowSorting="True" Skin="WebBlue" GridLines="None"
                                                OnNeedDataSource="rgEmpDepndnts_NeedDataSource" AllowPaging="True" PageSize="10"
                                                Style="resize: none">
                                                <GroupingSettings CaseSensitive="False" />
                                                <MasterTableView CommandItemDisplay="None">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EMP_ID" HeaderText="EMP_ID" meta:resourceKey="EMP_ID"
                                                            UniqueName="EMP_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPFMDTL_ID" HeaderText="EMPFMDTL_ID" meta:resourceKey="EMPFMDTL_ID"
                                                            UniqueName="EMPFMDTL_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Beneficiary Name" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:CheckBox runat="server" ID="chk"
                                                                    AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" />
                                                                <asp:Label runat="server" ID="lblBenName" Text='<%# Eval("BENEFICIARY") %>'></asp:Label>
                                                                <asp:Label runat="server" ID="lblFmlyDtlID" Text='<%# Eval("EMPFMDTL_ID") %>' Visible="false"></asp:Label>
                                                                <asp:Label runat="server" ID="lblRelID" Text='<%# Eval("RELATION_ID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <%--<telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name" meta:resourcekey="EMP_NAME"
                                                            UniqueName="EMP_NAME" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BENEFICIARY" HeaderText="Beneficiary Name" meta:resourcekey="BENEFICIARY"
                                                            UniqueName="BENEFICIARY" ItemStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="RELATION" HeaderText="Relation" meta:resourcekey="RELATION"
                                                            UniqueName="RELATION" ItemStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Currency" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <telerik:RadComboBox ID="rcmb_Currency" runat="server" MarkFirstMatch="true" MaxHeight="120px"
                                                                    Filter="Contains" Skin="WebBlue" SkinID="eMedicals" Width="90%" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="rcmb_Currency_SelectedIndexChanged" Enabled="false">
                                                                </telerik:RadComboBox><%-- Text='<%# Eval("EMPFMDTL_ID") %>'--%>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Conversion Amount" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <telerik:RadNumericTextBox ID="rnt_maxcurramt" runat="server" SkinID="EmpExp"
                                                                    Culture="English (United States)" Skin="WebBlue" Enabled="false">
                                                                </telerik:RadNumericTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Claim Amount" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <telerik:RadNumericTextBox ID="radAmount" runat="server" Skin="WebBlue" MaxLength="7" MinValue="0"
                                                                    AutoPostBack="true" SkinID="EmpExp" OnTextChanged="radAmount_TextChanged" Enabled="false">
                                                                </telerik:RadNumericTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Claim Amount(USD)" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <telerik:RadNumericTextBox ID="rnt_CurrencyAmt" runat="server"
                                                                    Culture="English (United States)" MaxLength="9" AutoPostBack="true"
                                                                    MinValue="0" Skin="WebBlue" Enabled="false" SkinID="EmpExp">
                                                                </telerik:RadNumericTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="80% Rule Amount(USD)" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <telerik:RadNumericTextBox ID="rntbRule80" runat="server"
                                                                    Culture="English (United States)" MaxLength="9"
                                                                    MinValue="0" Skin="WebBlue" Enabled="false" SkinID="EmpExp">
                                                                </telerik:RadNumericTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Invoice ID" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <telerik:RadTextBox ID="rtbInvoiceID" runat="server" Skin="WebBlue" MaxLength="8"
                                                                    SkinID="eMedicals" Enabled="false">
                                                                </telerik:RadTextBox>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Button runat="server" ID="btnClaim" Text="Claim" OnClick="btnClaim_Click" Enabled="false" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <ClientSettings>                                                
                                                    <Scrolling AllowScroll="true" FrozenColumnsCount="2" />
                                                    <Resizing AllowColumnResize="true" ResizeGridOnColumnResize="true" AllowRowResize="true" />
                                                </ClientSettings>    
                                                <PagerStyle AlwaysVisible="True" />
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>

                                <table align="center" width="100%">
                                    <tr>
                                        <td align="center" colspan="3">
                                            <br />
                                            <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                                Text="Submit" ValidationGroup="Controls" />
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_Expenditure" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                </table>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Save" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>