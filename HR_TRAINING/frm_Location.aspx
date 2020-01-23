<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_Location.aspx.cs" Inherits="HR_TRAINING_frm_Location" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CourseHeader" runat="server" Text="Location" Font-Bold="True" meta:resourcekey="lbl_Course"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_Course_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" Height="490px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_Course_ViewMain" runat="server" Selected="True">
                        <table align="center" width="45%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_Course" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        Skin="WebBlue" OnNeedDataSource="Rg_Course_NeedDataSource" AllowPaging="True"
                                        AllowFilteringByColumn="true">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Location_ID" UniqueName="Location_ID" HeaderText="ID"
                                                    meta:resourcekey="Location_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="Location_Name" UniqueName="Location_Name"
                                                    HeaderText="Location Name" meta:resourcekey="Location_Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Location_ContactPerson" UniqueName="Location_ContactPerson" HeaderText="Contact Person"
                                                    meta:resourcekey="Location_ContactPerson">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Location_ContactNo" UniqueName="Location_ContactNo" HeaderText="Contact No"
                                                    meta:resourcekey="COURSE_DESC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                  <telerik:GridBoundColumn DataField="Location_Status" UniqueName="Location_Status"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("Location_ID") %>'
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
                    <telerik:RadPageView ID="Rp_Course_ViewDetails" runat="server">
                        <table align="center">
                          
                            <tr>
                                <td align="left">
                                     <asp:Label ID="lblLocationId" runat="server" Visible="False" meta:resourcekey="lbl_CourseId"></asp:Label>
                                    <asp:Label ID="lblLocation" runat="server" Text="Location Name" meta:resourcekey="lbl_CC"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                 <td>
                                    <telerik:RadTextBox ID="radLocation" runat="server" Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="radLocation"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Location Name Cannot Be Empty"
                                        meta:resourcekey="rfv_rtxt_CourseName">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="radLocation"
                                        ErrorMessage="Please Enter Only AlphaNumeric Characters" ValidationExpression="^[a-zA-Z0-9\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                   
                                    <asp:Label ID="lbl_StreetName" runat="server" Text="Street Name" meta:resourcekey="lbl_StreetName"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="rtxt_StreetName" runat="server"  Skin="WebBlue" >
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CourseName" ControlToValidate="rtxt_StreetName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Street Name Cannot Be Empty"
                                        meta:resourcekey="rfv_rtxt_CourseName">*</asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="rtxt_StreetName"
                                        ErrorMessage="Please Enter Only AlphaNumeric Characters" ValidationExpression="^[a-zA-Z0-9\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblCountry" runat="server" Text="Country" meta:resourcekey="lblCountry"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                 <td>
                                    <telerik:RadComboBox ID="radCountry" runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="radCountry_SelectedIndexChanged" MarkFirstMatch="true"
                                       MaxHeight="120px" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="radCountry"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Country" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td align="left">
                                    <asp:Label ID="lblCounty" runat="server" Text="District" meta:resourcekey="lblCounty"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                 <td>
                                    <telerik:RadComboBox ID="radCounty" runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="radCounty_SelectedIndexChanged" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="radCounty"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select County" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblTown" runat="server" Text="Town" meta:resourcekey="lblCity"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                 <td>
                                    <telerik:RadComboBox ID="radTown" runat="server" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_CC" runat="server" ControlToValidate="radTown"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Town" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr >
                                <td>                                    
                                    <asp:Label ID="lblContactName" runat="server" Text="Contact Name" meta:resourcekey="lblContactName"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="radContactName" runat="server" Skin="WebBlue" MaxLength="50" >
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="radContactName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Contact Name Cannot Be Empty"
                                        meta:resourcekey="rfv_rtxt_CourseName">*</asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="rev_Code" runat="server" ControlToValidate="radContactName"
                                        ErrorMessage="Please Enter Only AlphaNumeric Characters" ValidationExpression="^[a-zA-Z0-9\s]+$"
                                        ValidationGroup="Controls">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lblEmailID" runat="server" Text="Email-ID" meta:resourcekey="lblEmailID"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="radEmailID" runat="server" Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox></td>
                                 <td>
                                     <asp:RegularExpressionValidator ID="rev_EmailID" runat="server" ControlToValidate="radEmailID" Text="*"
                                                         Display="Dynamic" ValidationGroup="Controls" ErrorMessage="Please Enter Valid Email ID"
                                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rfv_rtxt_EmailID" runat="server" ErrorMessage="Please Enter EmailID"
                                                         Text="*" ValidationGroup="Controls" ControlToValidate="radEmailID"
                                                        Display="Dynamic">
                                                   * </asp:RequiredFieldValidator>                                                                  
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblContactNo" runat="server" Text="Contact Number" meta:resourcekey="lblContactNo"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadMaskedTextBox ID="radContactNo" runat="server" Skin="WebBlue" MaxLength="13" Mask="+### ### #######">
                                    </telerik:RadMaskedTextBox>        
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="radContactNo"
                                        ErrorMessage="Contact No is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator> 
                                  <%--   <asp:RegularExpressionValidator ID="Contactno" runat="server" 
      ControlToValidate="radContactNo" ErrorMessage="Please enter the valid moble no" 
    ValidationExpression="[0-9]{10}" ValidationGroup="Controls"></asp:RegularExpressionValidator>--%>
                                     <%--<asp:RequiredFieldValidator ID="rfv_txt_PhoneNumber" runat="server" ControlToValidate="radContactNo" 
                                        ErrorMessage="Contact No is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>   --%>
                                 </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lblAlternateContact1" runat="server" Text="Alternate Contact Number" meta:resourcekey="lblAlternateContact1"></asp:Label>
                                </td>
                                <td>:
                                </td>
                                <td>
                                    <telerik:RadMaskedTextBox ID="radAlternateContact1" runat="server" Skin="WebBlue" MaxLength="13" Mask="+### ### #######">
                                    </telerik:RadMaskedTextBox>                                                                        
                                </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="radAlternateContact1"
                                        ErrorMessage="Alternate Contact No is Mandatory" ValidationGroup="Controls">*</asp:RequiredFieldValidator>   
                                 </td>
                            </tr>
                           <tr>
                                <td>
                                    <asp:Label ID="lbl_IsActive" runat="server" Text="IsActive"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:CheckBox ID="rad_IsActive" runat="server" Checked="true">
                                    </asp:CheckBox>
                                </td>
                               <td></td>
                              </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Edit" OnClick="btn_Save_Click"
                                        Text="Update" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Save" runat="server" meta:resourcekey="btn_Save" OnClick="btn_Save_Click"
                                        Text="Save" ValidationGroup="Controls" Visible="False" />
                                    <asp:Button ID="btn_Cancel" runat="server" meta:resourcekey="btn_Cancel" OnClick="btn_Cancel_Click"
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

