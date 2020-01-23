<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="TrainerProfile.aspx.cs" Inherits="HR_TRAINING_TrainerProfile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table width="990px" align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Text="Trainer Profile" Font-Bold="True" meta:resourcekey="lbl_Course"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_CY_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px">
                    <telerik:RadPageView ID="Rp_CY_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Countries" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" AllowPaging="True" AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Trainer_TrainerProfile_ID" UniqueName="Trainer_TrainerProfile_ID"
                                                    HeaderText="ID" meta:resourcekey="Trainer_TrainerProfile_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Trainer_Name" UniqueName="Trainer_Name" HeaderText="Trainer Name"
                                                    meta:resourcekey="Trainer_Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="SERVICEPROVIDER_NAME" UniqueName="SERVICEPROVIDER_NAME"
                                                    HeaderText="Service Provider" meta:resourcekey="SERVICEPROVIDER_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="COURSE_NAME" UniqueName="COURSE_NAME" HeaderText="Course Name"
                                                    meta:resourcekey="COURSE_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Trainer_MoblieNo" UniqueName="Trainer_MoblieNo"
                                                    HeaderText="Mobile No" meta:resourcekey="Trainer_MoblieNo">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS" AllowFiltering="true"
                                                    HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("Trainer_TrainerProfile_ID") %>'
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
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_CY_ViewDetails" runat="server">
                        <br />
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadTabStrip runat="server" ID="rts_TabStrip" BorderColor="Black" SelectedIndex="0"
                                        AutoPostBack="true" MultiPageID="Rm_Course_page" Align="Left" OnTabClick="clck_tab">
                                        <Tabs>
                                            <telerik:RadTab Text="Trainer Profile" BorderColor="Black" PageViewID="Rp_Course_ViewDetails" TabIndex="0">
                                            </telerik:RadTab>
                                            <telerik:RadTab Text="Qualification" PageViewID="rad_Qualifiaction" TabIndex="1">
                                            </telerik:RadTab>
                                        </Tabs>
                                    </telerik:RadTabStrip>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadMultiPage ID="Rm_Course_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                                                    Width="990px">
                                                    <telerik:RadPageView ID="Rp_Course_ViewDetails" runat="server" Selected="true">
                                                        <table align="center">
                                                            <tr>
                                                                <td style="width: 150px">Service Provider
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="rc_ServiceProvider" runat="server" TabIndex="1" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                                    </telerik:RadComboBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ErrorMessage="Please Select Service Provider"
                                                                        InitialValue="Select" ValidationGroup="Part" ControlToValidate="rc_ServiceProvider" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>Course
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="rc_CourseCategory" runat="server" TabIndex="2" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                                    </telerik:RadComboBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ErrorMessage="Please Select Course"
                                                                        InitialValue="Select" ValidationGroup="Part" ControlToValidate="rc_CourseCategory" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>First Name 
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_FirstName" runat="server" EnableEmbeddedSkins="true"
                                                                        MaxLength="100" Height="23px" TextMode="SingleLine" Width="145px" TabIndex="3">
                                                                    </telerik:RadTextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfc_FirstName" ErrorMessage="Please Enter First Name"
                                                                        ValidationGroup="Part" ControlToValidate="txt_FirstName" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>Address 1
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_Address1" runat="server" EnableEmbeddedSkins="true" MaxLength="100" TabIndex="4"
                                                                        Height="35px" TextMode="MultiLine" Width="145px">
                                                                    </telerik:RadTextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_Address1" ErrorMessage="Please Enter Address 1"
                                                                        ValidationGroup="Part" ControlToValidate="txt_Address1" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Middle Name
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_MiddleName" runat="server" EnableEmbeddedSkins="true" TabIndex="5"
                                                                        MaxLength="100" Height="23px" TextMode="SingleLine" Width="145px">
                                                                    </telerik:RadTextBox>
                                                                    <%-- <asp:RequiredFieldValidator runat="server" ID="rfv_MiddleName" ErrorMessage="Please enter Middle Name "
                                                            ValidationGroup="Part" ControlToValidate="txt_MiddleName" Text="*"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td>Address 2
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_Address2" runat="server" EnableEmbeddedSkins="true" MaxLength="100" TabIndex="6"
                                                                        Height="35px" TextMode="MultiLine" Width="145px">
                                                                    </telerik:RadTextBox>
                                                                    <%--<asp:RequiredFieldValidator runat="server" ID="rfv_Address2" ErrorMessage="Please Enter Address 2 "
                                                            ValidationGroup="Part" Text="*" ControlToValidate="txt_Address2"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Last Name
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_LastName" runat="server" EnableEmbeddedSkins="true" MaxLength="100" TabIndex="7"
                                                                        Height="23px" TextMode="SingleLine" Width="145px">
                                                                    </telerik:RadTextBox><asp:RequiredFieldValidator runat="server" ID="rfc_LastName" ErrorMessage=" Please Enter Last Name "
                                                                        ValidationGroup="Part" Text="*" ControlToValidate="txt_LastName"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>Country
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="rc_Country" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rc_Country_SelectedIndexChanged" TabIndex="8" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                                    </telerik:RadComboBox>
                                                                    <asp:RequiredFieldValidator ID="rfv_rc_Country" runat="server" ControlToValidate="rc_Country"
                                                                        meta:resourcekey="rfv_rc_Country" ErrorMessage="Please Select Country " InitialValue="Select"
                                                                        Text="*" ValidationGroup="Part"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Date Of Birth
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="txt_DOB" runat="server" AutoPostBack="true" Skin="WebBlue" TabIndex="9"
                                                                        OnSelectedDateChanged="txt_DOB_SelectedDateChanged" MinDate="1900-01-01">
                                                                    </telerik:RadDatePicker>
                                                                    <asp:RequiredFieldValidator ID="rfv_dob" runat="server" ControlToValidate="txt_DOB"
                                                                        ErrorMessage="Please Enter Valid DOB" Text="*" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                        ValidationGroup="Part"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>County
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="rc_County" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rc_County_SelectedIndexChanged" TabIndex="10"
                                                                        MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                                    </telerik:RadComboBox>
                                                                    <asp:RequiredFieldValidator ID="rfv_rc_County" runat="server" ControlToValidate="rc_County"
                                                                        meta:resourcekey="rfv_rc_County" ErrorMessage="Please Select County " InitialValue="Select"
                                                                        Text="*" ValidationGroup="Part"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Age
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_Age" runat="server" EnableEmbeddedSkins="true" Enabled="false"
                                                                        MaxLength="100" Height="23px" TextMode="SingleLine" Width="145px">
                                                                    </telerik:RadTextBox>
                                                                </td>
                                                                <td>Town
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="rc_Town" runat="server" TabIndex="11" MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                                                    </telerik:RadComboBox>
                                                                    <asp:RequiredFieldValidator ID="rvf_Town" runat="server" ControlToValidate="rc_Country"
                                                                        meta:resourcekey="rvf_Town" ErrorMessage="Please Select Town " InitialValue="Select"
                                                                        Text="*" ValidationGroup="Part"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Mobile No
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadMaskedTextBox ID="txt_mobileNo" runat="server" DisplayMask="###-####-####" TabIndex="12"
                                                                        Skin="WebBlue" Mask="(###) ####-####" TextWithLiterals="() -">
                                                                    </telerik:RadMaskedTextBox><asp:RequiredFieldValidator runat="server" ID="rfv_mobileNo" ErrorMessage="Please Enter Mobile Number"
                                                                        ValidationGroup="Part" ControlToValidate="txt_mobileNo" Text="*"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>Zip Code
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_ZipCode" runat="server" EnableEmbeddedSkins="true" AutoPostBack="true" TabIndex="13"
                                                                        MaxLength="6" Height="23px" TextMode="SingleLine" Width="145px">
                                                                    </telerik:RadTextBox>
                                                                    <%--   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ErrorMessage="Please Enter Zip Code "
                                                            ValidationGroup="Part" ControlToValidate="txt_username"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="txt_ZipCode"
                                                                        ErrorMessage="Enter only Alphanumerics for ZIP Number" ValidationExpression="^[a-zA-Z0-9''-'\s-]{1,12}$"
                                                                        ValidationGroup="Controls"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Telephone No
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadMaskedTextBox ID="txt_LandLineNo" runat="server" Mask="+### ### #######"
                                                                        MaxLength="13" TabIndex="14">
                                                                    </telerik:RadMaskedTextBox><%--<asp:RequiredFieldValidator ID="rfv_lAndline" runat="server" ControlToValidate="txt_LandLineNo"
                                                            ErrorMessage="Please Enter landline Number" ValidationGroup="Part"> *
                                                        </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td style="visibility: hidden;">User Name
                                                                </td>
                                                                <td style="visibility: hidden;">
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_username" runat="server" Height="15px" MaxLength="100"
                                                                        TextMode="SingleLine" Width="145px" Visible="false">
                                                                    </telerik:RadTextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPartNos" runat="server" ControlToValidate="txt_username"
                                                            ErrorMessage="Code Must be entered" ValidationGroup="Part"> 
                                                        </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Email-ID 
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_Email" runat="server" EnableEmbeddedSkins="true" MaxLength="100" TabIndex="15"
                                                                        Height="23px" TextMode="SingleLine" Width="145px">
                                                                    </telerik:RadTextBox>
                                                                    <asp:RegularExpressionValidator ID="rev_EmailID" runat="server" ControlToValidate="txt_Email"
                                                                        ErrorMessage="Please Enter Valid Email ID" Display="Dynamic" ValidationGroup="Part"
                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                    <asp:RequiredFieldValidator ID="rfv_txt_Email" runat="server" ErrorMessage="Please Enter Email ID"
                                                                        Text="*" ValidationGroup="Part" ControlToValidate="txt_Email"
                                                                        Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="visibility: hidden;">Password
                                                                </td>
                                                                <td style="visibility: hidden;">
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_Password" runat="server" MaxLength="100" Height="15px"
                                                                        TextMode="SingleLine" Width="145px" EnableEmbeddedSkins="true" Visible="false">
                                                                    </telerik:RadTextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>IsActive
                                                                </td>
                                                                <td>
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="rad_IsActive" runat="server" Checked="true" TabIndex="16"></asp:CheckBox>
                                                                </td>
                                                                <td style="visibility: hidden;">Confirm Password
                                                                </td>
                                                                <td style="visibility: hidden;">
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_ConfirmPassword" runat="server" EnableEmbeddedSkins="true"
                                                                        MaxLength="100" Height="15px" TextMode="SingleLine" Width="145px" Visible="false">
                                                                    </telerik:RadTextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="visibility: hidden;">Hint Question
                                                                </td>
                                                                <td style="visibility: hidden;">
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="rc_HintQuestion" runat="server" Visible="false" Filter="Contains">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr style="visibility: hidden;">
                                                                <td>Trainer Type
                                                                </td>
                                                                <td style="visibility: hidden;">
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadComboBox ID="rc_TrainerType" runat="server" Visible="false" Filter="Contains">
                                                                    </telerik:RadComboBox>
                                                                </td>
                                                                <td style="visibility: hidden;">Hint Answer 
                                                                </td>
                                                                <td style="visibility: hidden;">
                                                                    <b>:</b>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadTextBox ID="txt_HintAnswer" runat="server" EnableEmbeddedSkins="true"
                                                                        MaxLength="100" Height="15px" TextMode="SingleLine" Width="145px" Visible="false">
                                                                    </telerik:RadTextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" colspan="6">
                                                                    <asp:Button ID="btn_Save" runat="server" Text="Save" ValidationGroup="Part" OnClick="btn_Save_Click"
                                                                        TabIndex="17" Visible="false" />
                                                                    <asp:Button ID="btn_Update" runat="server" ValidationGroup="Part" Text="Update" OnClick="btn_Save_Click" TabIndex="17"
                                                                        Visible="false" />
                                                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" TabIndex="18" />
                                                                    <asp:ValidationSummary ID="vs_TrainerProf" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                                        ValidationGroup="Part" />
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </telerik:RadPageView>
                                                    <telerik:RadPageView ID="rad_Qualifiaction" runat="server">
                                                        <table align="left">
                                                            <tr>
                                                                <td valign="top">
                                                                    <table>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td>Qualification
                                                                            </td>
                                                                            <td align="left">
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="rc_Qualification" runat="server" MarkFirstMatch="true" MaxHeight="150px" Filter="Contains">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="rfv_Qualification" runat="server" ControlToValidate="rc_Qualification"
                                                                                    ErrorMessage="Please Select Qualification" Text="*" InitialValue="Select" ValidationGroup="Part"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td>Institute
                                                                            </td>
                                                                            <td align="left">
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txt_Institute" runat="server" EnableEmbeddedSkins="true"
                                                                                    AutoPostBack="true" MaxLength="100" Height="25px" TextMode="SingleLine" Width="145px">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator runat="server" ID="rfv_Institute" ErrorMessage="Please Enter Institute"
                                                                                    ValidationGroup="Part" ControlToValidate="txt_Institute" Text="*">
                                  *
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td>Year of Pass
                                                                            </td>
                                                                            <td align="left">
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txt_YeaofPass" runat="server" EnableEmbeddedSkins="true"
                                                                                    AutoPostBack="true" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0"
                                                                                    MaxLength="4" Height="25px" TextMode="SingleLine" Width="145px">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator runat="server" ID="rfv_Year" ErrorMessage="Please Enter Year of Pass"
                                                                                    ValidationGroup="Part" ControlToValidate="txt_YeaofPass" Text="*">
                                  *
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td>Percentage
                                                                            </td>
                                                                            <td align="left">
                                                                                <b>:</b>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txt_Percentage" runat="server" EnableEmbeddedSkins="true"
                                                                                    AutoPostBack="true" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0"
                                                                                    MaxLength="2" Height="25px" TextMode="SingleLine" Width="145px">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator runat="server" ID="rfv_Percentage" ErrorMessage="Please Enter Percentage"
                                                                                    ValidationGroup="Part" ControlToValidate="txt_Percentage" Text="*">
                                  *
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="5">
                                                                                <asp:Label ID="ld_ID" runat="server" Text="Label" Visible="false"></asp:Label>

                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>