<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_EmployeeGrade.aspx.cs" Inherits="Masters_frm_EmployeeGrade" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="cntEmployeeGrade" ContentPlaceHolderID="cphDefault" runat="Server">
     <script type="text/javascript">
         function det() {
             debugger;
             var value = window.confirm("Are you sure you want to Delete?");

             if (value == true) {
                 debugger;
                 return true;
             }
             else {
                 return false;
             }
         }
         </script>
    
    <telerik:RadAjaxManagerProxy ID="RAM_EmployeeGrade" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_EmployeeGrade">
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
                <asp:Label ID="lbl_EmployeeGradeHeader" runat="server" Text="Grade" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="550px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_EmployeeGrade" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" Skin="WebBlue" OnNeedDataSource="Rg_EmployeeGrade_NeedDataSource"
                                                AllowPaging="True" AllowFilteringByColumn="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EmployeeGrade_ID" UniqueName="EmployeeGrade_ID" HeaderText="ID"
                                                            meta:resourcekey="EmployeeGrade_ID" Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="CURRENTPERIODID" HeaderText="CURRENTPERIODID" meta:resourcekey="CURRENTPERIODID"
                                                            UniqueName="CURRENTPERIODID" Visible="False">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="EmployeeGrade_CODE" UniqueName="EmployeeGrade_CODE" HeaderText=" Code"
                                                            meta:resourcekey="EmployeeGrade_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EmployeeGrade_NAME" UniqueName="EmployeeGrade_NAME" HeaderText=" Description"
                                                            meta:resourcekey="EmployeeGrade_NAME">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridNumericColumn DataField="EMPLOYEEGRADE_RANK" UniqueName="EMPLOYEEGRADE_RANK" FilterControlWidth="100px" HeaderText="Grade Rank"
                                                            meta:resourcekey="EMPLOYEEGRADE_RANK" DataFormatString="{0:0.0}">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridNumericColumn>
                                                        <telerik:GridBoundColumn DataField="SLABSTATUS" UniqueName="SLABSTATUS" HeaderText="Slabs Status"
                                                            meta:resourcekey="SLABSTATUS" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false" HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("EmployeeGrade_ID") %>'
                                                                    OnCommand="lnk_Edit_Command" ToolTip="Edit" meta:resourcekey="lnk_Edit">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn UniqueName="ColCopy" AllowFiltering="false" HeaderText="Copy">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Copy" runat="server" CommandArgument='<%# Eval("EmployeeGrade_ID")+","+Eval("CURRENTPERIODID") %>'
                                                                    OnCommand="lnk_Copy_Command" ToolTip="Copy From Previous Year" meta:resourcekey="lnk_Copy">Copy</asp:LinkButton>
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
                                    <tr>
                                        <td>

                                            <table>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>

                                                    <td></td>
                                                </tr>

                                            </table>

                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <table align="center" width="40%">
                            <tr>
                                <td colspan="3" align="center" style="font-weight: bold;"></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EmployeeGradeID" runat="server" Visible="False" meta:resourcekey="lbl_EmployeeGradeID"></asp:Label>
                                    <asp:Label ID="lbl_EmployeeGradeCode" runat="server"  Text=" Code" meta:resourcekey="lbl_EmployeeGradeCode"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_EmployeeGradeCode" runat="server" TabIndex="1"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_EmployeeGradeCode" ControlToValidate="rtxt_EmployeeGradeCode"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Code"
                                        meta:resourcekey="rfv_rtxt_EmployeeGradeCode">*</asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="rev_EmployeeGradeCode" runat="server" ControlToValidate="rtxt_EmployeeGradeCode" ErrorMessage="Enter only Alpha Numerics for Grade Code"
                                        ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,50}$" ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EmployeeGradeName" runat="server"  Text=" Description" meta:resourcekey="lbl_EmployeeGradeDesc"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_EmployeeGradeName" runat="server" TabIndex="2"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                                    <%--  <asp:RequiredFieldValidator ID="rfv_rtxt_EmployeeGradeName" ControlToValidate="rtxt_EmployeeGradeName"
                                        runat="server" ValidationGroup="Controls" 
                                        ErrorMessage="Name cannot be Empty" 
                                        meta:resourcekey="rfv_rtxt_EmployeeGradeName">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_EMPLOYEEGRADE_RANK" runat="server"  Text="Grade Rank" meta:resourcekey="lbl_EMPLOYEEGRADE_RANK"></asp:Label>
                                </td>
                                <td><b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="rtxt_EMPLOYEEGRADE_RANK" runat="server" NumberFormat-DecimalDigits="1" TabIndex="3"   
                                        Skin="WebBlue" MaxLength="50">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfv_EMPLOYEEGRADE_RANK" ControlToValidate="rtxt_EMPLOYEEGRADE_RANK"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Grade Rank "
                                        meta:resourcekey="rfv_rtxt_EmployeeGradeCode" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="rtxt_EMPLOYEEGRADE_RANK" ErrorMessage="Please Enter Decimal Values Only for Grade Rank"
                                        ValidationExpression="^[0-9]*(?:\.[0-9]*)?$" ValidationGroup="Controls" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click" TabIndex="4"
                                        Text="Update" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click" TabIndex="4"
                                        Text="Save" Visible="False" OnClientClick="disableButton(this,'Controls')" UseSubmitBehavior="false" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click" TabIndex="5"
                                        Text="Cancel" />
                                    <asp:ValidationSummary ID="vs_EmployeeGrade" runat="server" ShowMessageBox="True" ShowSummary="False"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <table id="tblSlabs" runat="server" visible="false">
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Label ID="lbl_SalarySlabs" runat="server" Text="Salary Slabs" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" >Financial Period 
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadComboBox ID="rcb_ScalesSlabFromPeriod" runat="server" DataTextField="PERIOD_NAME" DataValueField="PERIOD_ID" TabIndex="6" 
                                                    OnSelectedIndexChanged="rcb_ScalesSlabFromPeriod_SelectedIndexChanged" AutoPostBack="true" Filter="Contains"></telerik:RadComboBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_ScalesSlabFromPeriod" ControlToValidate="rcb_ScalesSlabFromPeriod"
                                                    runat="server" ValidationGroup="Slab" ErrorMessage="Please Select Financial Period" InitialValue="Select"
                                                    meta:resourcekey="rfv_ScalesSlabFromPeriod" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" >Slab Amount
                                            </td>
                                            <td><b>:</b>
                                            </td>
                                            <td>
                                                <telerik:RadNumericTextBox ID="rtxt_SlabAmount" MinValue="0" runat="server" NumberFormat-DecimalDigits="2" TabIndex="7"></telerik:RadNumericTextBox>
                                                <asp:LinkButton ID="btn_AddSlabAmount" runat="server" Text="Add" OnClick="btn_AddSlabAmount_Click" ValidationGroup="Slab" TabIndex="8" />
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfv_SlabAmountGrid" ControlToValidate="rtxt_SlabAmount"
                                                    runat="server" ValidationGroup="Slab" ErrorMessage="Slab Amount cannot be Empty"
                                                    meta:resourcekey="rfv_rtxt_EmployeeGradeCode" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                                <asp:RegularExpressionValidator ID="rev_SlabAmountGrid" runat="server" ControlToValidate="rtxt_SlabAmount" ErrorMessage="Please Enter Valid Slab Amount"
                                                    ValidationExpression="^[0-9]*(?:\.[0-9]*)?$" ValidationGroup="Slab" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                                                <asp:ValidationSummary ID="ValidationSummarySlab" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                    ValidationGroup="Slab" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lbl_SlabMessage" runat="server" ForeColor="#cc0000" Font-Bold="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <telerik:RadGrid ID="rg_SlabGrid" runat="server" AutoGenerateColumns="False" GridLines="None" Width="410px"
                                                    Skin="WebBlue" OnNeedDataSource="rg_SlabGrid_NeedDataSource" AllowPaging="false" OnItemDataBound="rg_SlabGrid_ItemDataBound"
                                                    AllowFilteringByColumn="false">
                                                    <MasterTableView CommandItemDisplay="None">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_SLAB_ID" HeaderText="EMPLOYEEGRADE_SLAB_ID" meta:resourcekey="EMPLOYEEGRADE_SLAB_ID"
                                                                UniqueName="EMPLOYEEGRADE_SLAB_ID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_SLAB_SRNO" HeaderText="Notch" meta:resourcekey="EMPLOYEEGRADE_SLAB_SRNO"
                                                                UniqueName="EMPLOYEEGRADE_SLAB_SRNO">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="CURRENTPERIODID" HeaderText="CURRENTPERIODID" meta:resourcekey="CURRENTPERIODID"
                                                                UniqueName="CURRENTPERIODID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                              <telerik:GridBoundColumn DataField="ISFINALIZED" HeaderText="ISFINALIZED" meta:resourcekey="ISFINALIZED"
                                                                UniqueName="ISFINALIZED" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Slab Amount" UniqueName="Edit" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <telerik:RadNumericTextBox ID="rtxt_SlabAmountGrid" Value='<%#Eval("EMPLOYEEGRADE_SLAB_AMOUNT") %>' runat="server" NumberFormat-DecimalDigits="2"
                                                                        Skin="WebBlue" MaxLength="50">
                                                                    </telerik:RadNumericTextBox>
                                                                    <asp:Label runat="server" ID="lblEmpSlabID" Text='<%# Eval("EMPLOYEEGRADE_SLAB_ID") %>' Visible="false"></asp:Label>
                                                                    <asp:Label runat="server" ID="lblEmpSlabPrdID" Text='<%# Eval("CURRENTPERIODID") %>' Visible="false"></asp:Label>
                                                                    <%--<asp:Label runat="server" ID="Label1" Text="<%# Eval("CURRENTPERIODID") %>" Visible="false"></asp:Label>--%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Delete" UniqueName="Edit" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName='<%# Eval("EMPLOYEEGRADE_SLAB_SRNO") %>'
                                                                        CommandArgument='<%# Eval("EMPLOYEEGRADE_SLAB_ID") %>' OnCommand="lnkDelete_Command" 
                                                                        OnClientClick="return det()" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>

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
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:Button ID="btn_SaveSlabs" runat="server" meta:resourcekey="btn_SaveSlabs" OnClick="btn_SaveSlabs_Click" TabIndex="9"
                                                    Text="Save Slabs" ValidationGroup="SaveSlabs" />
                                                <asp:Button ID="btn_FinalizeSlabs" runat="server" meta:resourcekey="btn_FinalizeSlabs" OnClick="btn_FinalizeSlabs_Click" TabIndex="10"
                                                    Text="Finalize Slabs" UseSubmitBehavior="false" />
                                                <%--<asp:Button ID="btn_" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
                    Text="Cancel" />--%>
                                                <asp:ValidationSummary ID="vs_SaveSlabs" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                    ValidationGroup="SaveSlabs" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                    </telerik:RadPageView>

                    <telerik:RadPageView ID="Rp_CY_CopySlabs" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="40%">
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" >(From) Financial Period 
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcb_FromFinYear" runat="server" DataTextField="PERIOD_NAME" ValidationGroup="CopySlab" TabIndex="11" Filter="Contains"
                                                CausesValidation="false" DataValueField="PERIOD_ID" OnSelectedIndexChanged="rcb_FromFinYear_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_FromFinYear" ControlToValidate="rcb_FromFinYear" InitialValue="Select"
                                                runat="server" ValidationGroup="CopySlab" ErrorMessage="Please Select From Financial Period"
                                                meta:resourcekey="rfv_FromFinYear" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right" >(To) Financial Period 
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcb_ToFinYear" runat="server" DataTextField="PERIOD_NAME" TabIndex="12" Filter="Contains"
                                                ValidationGroup="CopySlab" DataValueField="PERIOD_ID" CausesValidation="false"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_ToFinYear" ControlToValidate="rcb_ToFinYear" InitialValue="Select"
                                                runat="server" ValidationGroup="CopySlab" ErrorMessage="Please Select To Financial Period"
                                                meta:resourcekey="rfv_FromFinYear" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="center" colspan="4">
                                            <br />
                                            <asp:Button ID="btnGenerateSlabs" runat="server" meta:resourcekey="btnGenerateSlabs" OnClick="btnGenerateSlabs_Click" TabIndex="13"
                                                Text="Generate Slabs" UseSubmitBehavior="false"  />
                                            <asp:Button ID="btn_CopySlabCancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_CopySlabCancel_Click" Text="Cancel" TabIndex="14" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table id="tbl_CopySlabTable" runat="server" visible="false">
                                                <tr>
                                                    <td >Slab Amount
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="rtxt_CopySlabAmount" runat="server" NumberFormat-DecimalDigits="2"></telerik:RadNumericTextBox>
                                                        <asp:LinkButton ID="lnk_CopySlabAdd" runat="server" Text="Add" OnClick="lnk_CopySlabAdd_Click" ValidationGroup="Slab" />
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_CopySlabAmount" ControlToValidate="rtxt_CopySlabAmount"
                                                            runat="server" ValidationGroup="Slab" ErrorMessage="Slab Amount cannot be Empty"
                                                            meta:resourcekey="rfv_CopySlabAmount" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        <asp:RegularExpressionValidator ID="rev_CopySlabAmount" runat="server" ControlToValidate="rtxt_CopySlabAmount" ErrorMessage="Please Enter Valid Slab Amount"
                                                            ValidationExpression="^[0-9]*(?:\.[0-9]*)?$" ValidationGroup="Slab" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                            ValidationGroup="Slab" />
                                                    </td>
                                                </tr>
                                                   <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lbl_CopySlabMessage" runat="server" ForeColor="#cc0000" Font-Bold="true" />
                                            </td>
                                        </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <telerik:RadGrid ID="rg_CopySlabGrid" runat="server" AutoGenerateColumns="False" GridLines="None"  Width="410px"
                                                            Skin="WebBlue" OnNeedDataSource="rg_CopySlabGrid_NeedDataSource" AllowPaging="false" OnItemDataBound="rg_CopySlabGrid_ItemDataBound"
                                                            AllowFilteringByColumn="false">
                                                            <MasterTableView CommandItemDisplay="None">
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_SLAB_ID" HeaderText="EMPLOYEEGRADE_SLAB_ID" meta:resourcekey="EMPLOYEEGRADE_SLAB_ID"
                                                                        UniqueName="EMPLOYEEGRADE_SLAB_ID" Visible="False">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="CURRENTPERIODID" HeaderText="CURRENTPERIODID" meta:resourcekey="CURRENTPERIODID"
                                                                UniqueName="CURRENTPERIODID" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                              <telerik:GridBoundColumn DataField="ISFINALIZED" HeaderText="ISFINALIZED" meta:resourcekey="ISFINALIZED"
                                                                UniqueName="ISFINALIZED" Visible="False">
                                                            </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="EMPLOYEEGRADE_SLAB_SRNO" HeaderText="Sr. No." meta:resourcekey="EMPLOYEEGRADE_SLAB_SRNO"
                                                                        UniqueName="EMPLOYEEGRADE_SLAB_SRNO">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridTemplateColumn HeaderText="Slab Amount" UniqueName="Edit" AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <telerik:RadNumericTextBox ID="rtxt_SlabAmountGrid" Value='<%#Eval("EMPLOYEEGRADE_SLAB_AMOUNT") %>' runat="server" NumberFormat-DecimalDigits="2"
                                                                                Skin="WebBlue" MaxLength="50">
                                                                            </telerik:RadNumericTextBox>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn HeaderText="Delete" UniqueName="Edit" AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCopySlabDelete" runat="server" Text="Delete" OnClick="lnkCopySlabDelete_Click" />
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>

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
                                                    <td align="center" colspan="3">
                                                        <br />
                                                        <asp:Button ID="btnCopySaveSlabs" runat="server" meta:resourcekey="btnCopySaveSlabs" OnClick="btnCopySaveSlabs_Click"
                                                            Text="Copy Slabs"  Visible="false" ValidationGroup="CopySlab" />
                                                        <asp:Button ID="btnCopyFinalizeSlabs" runat="server" meta:resourcekey="btnCopyFinalizeSlabs" OnClick="btnCopyFinalizeSlabs_Click"
                                                            Text="Finalize Slabs"  Visible="false" ValidationGroup="CopySlab" />
                                                        
                                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="false"
                                                            ValidationGroup="CopySlab" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>



                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>








        



    </table>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
</asp:Content>--%>

