<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_EmpFamDetails_Medical.aspx.cs" Inherits="Medical_frm_EmpFamDetails_Medical" %>

<asp:Content ID="Cnt_MedicalBenifit" ContentPlaceHolderID="cphDefault" runat="Server">
    <br />
    <br />
    <br />
    <telerik:RadAjaxManagerProxy ID="RAM_MedicalBenifit" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_MedicalBenifit">
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
                <asp:Label ID="lbl_MedicalBenifitHeader" runat="server" Text="Family Details" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="590px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="50%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="RG_Employee" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                Skin="WebBlue" GridLines="None" OnNeedDataSource="RG_Employee_NeedDataSource"
                                                AllowFilteringByColumn="True" AllowSorting="True">
                                                <HeaderContextMenu Skin="WebBlue">
                                                </HeaderContextMenu>
                                                <PagerStyle AlwaysVisible="true" />
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="EMP_ID" UniqueName="EMP_ID" Visible="False" meta:Resourcekey="EMP_ID">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUNIT" UniqueName="BUNIT" HeaderText="Business Unit">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_EMPCODE" UniqueName="EMP_EMPCODE" HeaderText="Employee Code">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_STATUS" UniqueName="EMP_STATUS" HeaderText="Employee Status">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMPNAME" UniqueName="EMPNAME" HeaderText="Employee Name">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE" HeaderText="Scale">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EMP_EMPLOYEETYPE" UniqueName="EMP_EMPLOYEETYPE" HeaderText="Employee Type">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <%--<telerik:GridBoundColumn DataField="EMP_DOJ" UniqueName="EMP_DOJ"   HeaderText="Date of Join" DataFormatString="{0:dd/MM/yyyy}">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>--%>

                                                        <telerik:GridDateTimeColumn DataField="EMP_DOJ" meta:Resourcekey="EMP_DOJ" FilterControlWidth="110px" HeaderText="Date of Join"
                                                            SortExpression="EMP_DOJ" PickerType="DatePicker"
                                                            DataFormatString="{0:dd/MM/yyyy}">
                                                        </telerik:GridDateTimeColumn>
                                                        <%-- <telerik:GridBoundColumn DataField="EMP_DOC" UniqueName="EMP_DOC" meta:Resourcekey="EMP_DOC">
                                                    </telerik:GridBoundColumn>--%>
                                                        <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Employee_Edit" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                                                    OnCommand="lnk_Employee_Edit_Command" meta:Resourcekey="lnk_Employee_Edit">Edit
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView><FilterMenu Skin="WebBlue">
                                                </FilterMenu>
                                                <GroupingSettings CaseSensitive="false" />
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
                    <telerik:RadPageView ID="Family" runat="server" meta:resourcekey="Family" Width="800px">
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table style="width: 800px">
                                    <tr>
                                        <td>
                                            <table align="center">
                                                <tr>
                                                    <td>
                                                        <asp:HiddenField ID="HF_EMPID" runat="server" />
                                                        <asp:Label ID="lbl_FSerial" runat="server" Text="Serial" meta:resourcekey="lbl_FSerial"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="txt_FSerial" runat="server" ReadOnly="True" TabIndex="1">
                                                        </telerik:RadTextBox>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="lbl_FRelType" runat="server" Text="Relation&nbsp;Type" meta:resourcekey="lbl_FRelType"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="ddlRelation" runat="server" TabIndex="2" MarkFirstMatch="true" AutoPostBack="True" OnSelectedIndexChanged="ddlRelation_SelectedIndexChanged" Filter="Contains">
                                                        </telerik:RadComboBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Relation" runat="server" Text="*" ControlToValidate="ddlRelation" ErrorMessage="Please Select Relation"
                                                            Display="Dynamic" InitialValue="Select" ValidationGroup="Controls" meta:resourcekey="rfv_Relation"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSurName" runat="server" Text="Surname" meta:resourcekey="lblSurName"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="radSurName" runat="server" TabIndex="3">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="rvf_Fileupload" ControlToValidate="radSurName"
                                                            runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Surname" meta:resourcekey="rfv_rtxt_CourseDesc">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="radSurName"
                                                            ErrorMessage="Please Enter Only Alphabets" ValidationExpression="^[a-zA-Z\s]+$"
                                                            ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="lbl_FName" runat="server" Text="Name" meta:resourcekey="lbl_FName"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="txt_Name" runat="server" TabIndex="3" MaxLength="50">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_Name"
                                                            runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Name"
                                                            meta:resourcekey="rfv_rtxt_CourseDesc">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Name"
                                                            ErrorMessage="Please Enter Only Alphabets" ValidationExpression="^[a-zA-Z\s]+$"
                                                            ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_FDOB" runat="server" meta:resourcekey="lbl_FDOB" Text="DOB :"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="chk_EmergencyCont" runat="server" Text="Emergency&nbsp;Contact" />
                                                        <telerik:RadDatePicker ID="txt_FDOB" runat="server" MinDate="1900-01-01" TabIndex="4" MaxDate='<%#DateTime.Now %>'>
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPhoto" runat="server" Text="Photo"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="FBrowsePhoto" runat="server"></asp:FileUpload>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="FBrowsePhoto"
                                                            runat="Server" ErrorMessage="Only .jpg files are allowed" ValidationGroup="Controls"
                                                            Text="*" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg))$" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblBioData" runat="server" Text="Bio Data"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="FBioData" runat="server"></asp:FileUpload>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="FBioData"
                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only doc files are allowed"
                                                            Text="*" ValidationExpression="^.+\.((pdf)|(doc)|(docx))$" />
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="lblBioMetricData" runat="server" Text="Bio Metric Data"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <b>:</b>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="FBioMetricData" runat="server"></asp:FileUpload>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="FBioMetricData"
                                                            ValidationGroup="Controls" runat="Server" ErrorMessage="Only jpeg files are allowed"
                                                            Text="*" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg))$" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" colspan="6">
                                                        <asp:Button ID="btn_Fam_Add" runat="server" OnClick="btn_Fam_Add_Click" Text="Add" ValidationGroup="Controls"
                                                            TabIndex="5" meta:resourcekey="btn_Fam_Add" UseSubmitBehavior="false" />
                                                        <asp:Button ID="btn_Fam_Correct" runat="server" OnClick="btn_Fam_Correct_Click" Text="Correct" ValidationGroup="Controls"
                                                            TabIndex="5" meta:resourcekey="btn_Fam_Correct" UseSubmitBehavior="false" />
                                                        <asp:Button ID="btn_Fam_Cancel" runat="server" OnClick="btn_Fam_Cancel_Click" Text="Cancel"
                                                            meta:resourcekey="btn_Fam_Cancel" />
                                                        <asp:ValidationSummary ID="vs_Country" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                            ValidationGroup="Controls" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table align="center">
                                                <tr>
                                                    <td>

                                                        <telerik:RadGrid ID="RG_Family" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                            OnItemCommand="RG_Family_ItemCommand" meta:resourcekey="RG_Family">
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="FamID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("EMPFMDTL_ID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn UniqueName="serial" meta:resourcekey="FamSerial" HeaderText="Serial">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Serial" runat="server" Text='<%# Eval("EMPFMDTL_SERIAL") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn UniqueName="ID" Visible="False" meta:resourcekey="Rel_ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("EMPFMDTL_EMPREL_ID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn UniqueName="Relation" meta:resourcekey="FamRelName" HeaderText="Relation">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Relation" runat="server" Text='<%# Eval("EMPFMDTL_EMPREL_NAME") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn UniqueName="Surname" HeaderText="Surname" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Surname" runat="server" Text='<%# Eval("EMPFMDTL_SURNAME") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn UniqueName="Name" HeaderText="Emp Name" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("EMPFMDTL_NAME") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn UniqueName="Name" HeaderText="Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_AccountName" runat="server" Text='<%# Eval("EMPFMDTLACCOUNT_NAME") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn UniqueName="DOB" HeaderText="DOB">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_DOB" runat="server" Text='<%# Eval("EMPFMDTL_RELDOB")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>

                                                                    <telerik:GridTemplateColumn UniqueName="EMPFMDTL_RELEMERGENCY" HeaderText="Emergency&nbsp;Contact">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chk_Emergency" runat="server" Checked='<%# Convert.ToBoolean(Eval("EMPFMDTL_RELEMERGENCY")) %>'
                                                                                Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>

                                                                    <telerik:GridTemplateColumn HeaderText="Photo">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("EMPFMDTL_PHOTO") %>' Width="100px" Height="100px"></asp:Image>
                                                                            <asp:Label ID="lbl_Photo" Text='<%#Eval("EMPFMDTL_PHOTO") %>' runat="server" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn HeaderText="Bio Data">
                                                                        <ItemTemplate>
                                                                            <a id="D2" runat="server" target="_blank" href='<%#Eval("EMPFMDTL_BIODATA") %>'>Download Bio Data</a>
                                                                            <asp:Label ID="lbl_BioData" Text='<%#Eval("EMPFMDTL_BIODATA") %>' Visible="false" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridButtonColumn CommandName="Edit_Rec" UniqueName="column" Text="Edit">
                                                                        <ItemStyle Width="80px" />
                                                                    </telerik:GridButtonColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                            <ClientSettings>
                                                                <Selecting AllowRowSelect="True" />
                                                            </ClientSettings>
                                                        </telerik:RadGrid>

                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Fam_Add" />
                                <asp:PostBackTrigger ControlID="btn_Fam_Correct" />

                            </Triggers>

                        </asp:UpdatePanel>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>