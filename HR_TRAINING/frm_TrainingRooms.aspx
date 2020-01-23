<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_TrainingRooms.aspx.cs" Inherits="HR_TRAINING_frm_TrainingRooms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CourseHeader" runat="server" Text="Training Rooms" Font-Bold="True" meta:resourcekey="lbl_Course"></asp:Label>
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
                                                <telerik:GridBoundColumn DataField="ROOMS_ID" UniqueName="ROOMS_ID" HeaderText="ID"
                                                    meta:resourcekey="ROOMS_ID" Visible="False">
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridBoundColumn DataField="ROOMS_NAME" UniqueName="ROOMS_NAME"
                                                    HeaderText="Rooms Name" meta:resourcekey="ROOMS_NAME">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Location_Name" UniqueName="Location_Name" HeaderText="Location Name"
                                                    meta:resourcekey="Location_Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridNumericColumn DataField="ROOMS_STRENGTH" UniqueName="ROOMS_STRENGTH" HeaderText="Room Strength" FilterControlWidth="100px"
                                                    meta:resourcekey="ROOMS_STRENGTH">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                 <telerik:GridBoundColumn DataField="ACTIVE_STATUS" UniqueName="ACTIVE_STATUS"
                                                    AllowFiltering="true" HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="GridTemplateColumnResource1" AllowFiltering="false" >
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("ROOMS_ID") %>'
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
                                     <asp:Label ID="lblTrainingRoomsId" runat="server" Visible="False" meta:resourcekey="lblTrainingRoomsId"></asp:Label>
                                    <asp:Label ID="lblTrainingRooms" runat="server" Text="Room Name" meta:resourcekey="lblTrainingRooms"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                 <td>
                                    <telerik:RadTextBox ID="radRoomName" runat="server" Skin="WebBlue" MaxLength="50">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="radRoomName"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Room Name"
                                        meta:resourcekey="rfv_rtxt_CourseName">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                   
                                    <asp:Label ID="lbl_RoomStrength" runat="server" Text="Room Strength" meta:resourcekey="lbl_RoomStrength"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="radRoomStrength" runat="server"  Skin="WebBlue" MaxLength="3" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" >
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rtxt_CourseName" ControlToValidate="radRoomStrength"
                                        runat="server" ValidationGroup="Controls" ErrorMessage="Please Enter Room Strength"
                                        meta:resourcekey="rfv_rtxt_CourseName">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblLocation" runat="server" Text="Location" meta:resourcekey="lblLocation"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                 <td>
                                    <telerik:RadComboBox ID="radLocation" runat="server" Skin="WebBlue" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="radLocation"
                                        meta:resourcekey="rfv_rcmb_CC" ErrorMessage="Please Select Location" InitialValue="Select"
                                        Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                </td>
                            </tr>                             
                           <tr>
                                <td>
                                    <asp:Label ID="lbl_IsActive" runat="server" Text="IsActive:"></asp:Label>
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


