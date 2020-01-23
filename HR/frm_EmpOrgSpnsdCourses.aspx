<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master"  AutoEventWireup="true" CodeFile="frm_EmpOrgSpnsdCourses.aspx.cs" Inherits="HR_frm_EmpOrgSpnsdCourses" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/BUFilter.ascx" TagPrefix="uc1" TagName="BUFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
      <asp:UpdatePanel ID="updPanel" runat="server">
            <ContentTemplate >
    <table align="center">
          <tr></tr>
         <tr></tr>
         <tr></tr>
         <tr></tr>
         <tr></tr>
         <tr></tr>
         <tr></tr>
         <tr></tr>
         <tr></tr>
         <tr></tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CMP" runat="server" Text="Organization Sponsored Courses" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_EmpOrgSpnsCoursesform" runat="server">
                    <telerik:RadPageView ID="RP_EmpOrgSpnsCoursesform" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_EmpOrgSpnsCoursesform" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        PageSize="5" Skin="WebBlue" GridLines="None" AllowFilteringByColumn="True" OnNeedDataSource="RG_EmpOrgSpnsCoursesform_NeedDataSource"
                                        meta:resourcekey="RG_cmpformResource1" Width="900px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="EMPORGSPNSRCRS_ID" DataField="EMPORGSPNSRCRS_ID" UniqueName="column1"
                                                    Visible="false">
                                                    </telerik:GridBoundColumn>
                                                     <telerik:GridBoundColumn HeaderText="EMPLOYEE NAME" DataField="NAME" UniqueName="column2"
                                                    Visible="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="COURSE NAME" DataField="EMPORGSPNSRCRS_COURSENAME"
                                                    Visible="true">
                                                </telerik:GridBoundColumn>  
                                                   <telerik:GridDateTimeColumn HeaderText="COURSE FROM DATE" DataField="EMPORGSPNSRCRS_FROMDATE" DataFormatString="{0:M/d/yyyy}" FilterControlWidth="100px"
                                                    Visible="true">
                                                </telerik:GridDateTimeColumn>  
                                                   <telerik:GridDateTimeColumn HeaderText="COURSE TO DATE" DataField="EMPORGSPNSRCRS_TODATE" DataFormatString="{0:M/d/yyyy}" FilterControlWidth="100px"
                                                    Visible="true">
                                                </telerik:GridDateTimeColumn>                                                                                                                                    
                                              <%--  <telerik:GridBoundColumn HeaderText="Status" DataField="CMP_STATUS" UniqueName="CMP_STATUS"
                                                    meta:resourcekey="GridBoundColumnResource3">
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Commnad" CommandArgument='<%# Eval("EMPORGSPNSRCRS_ID") %>'
                                                            meta:resourcekey="lnk_EditResource1">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_ADD" runat="server" OnCommand="lnk_Add_Command" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_EmpOrgSpnsCoursesview2" runat="server" Width="100%">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_CMPdet" runat="server" Text="" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td colspan="3">
                                        <uc1:BUFilter runat="server" ID="BUFilter1" ShowBusinessUnitSpan="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left"  style="width: 154px;">
                                      <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="False" meta:resourcekey="lbl_idResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small"></asp:Label>
                                     <asp:HiddenField ID="HF_ID" runat="server" />
                                    <asp:Label ID="lbl_CourseName" runat="server" 
                                        Text="Course Name"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                  <asp:TextBox ID="txtbx_CourseName" runat="server" MaxLength="1000" Width="200px"></asp:TextBox>

                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbx_CourseName"
                                        ErrorMessage="Please enter Course Name" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                 
                                </td>
                            </tr>                          
                          
                             <tr>
                            <td>
                                <asp:Label ID="lbl_frmdate" runat="server" Text="From Date"></asp:Label>
                            </td>
                            <td>
                                :
                            </td>
                             <td>
                                <telerik:RadDatePicker ID="rdtp_fromdate" runat="server" 
                                        Skin="WebBlue" Width="205px" >                                    
                                        <calendar skin="WebBlue" usecolumnheadersasselectors="False" 
                                     userowheadersasselectors="False" viewselectortext="x">
                                        </calendar>                                     
                                        <datepopupbutton hoverimageurl="" imageurl="" />
                                        <dateinput dateformat="M/d/yyyy" displaydateformat="M/d/yyyy">
                                        </dateinput>
                                    </telerik:RadDatePicker>
                                    <asp:RequiredFieldValidator ID="rfv_fromdate" runat="server" ControlToValidate="rdtp_fromdate"
                                        ErrorMessage="Select From Date" ValidationGroup="CONTROLS" >*</asp:RequiredFieldValidator>
                              </td>
                                    <td>
                                      

                                    </td>
                                                     
                            </tr>
                               <tr>
                            <td>
                                <asp:Label ID="lbl_ToDate" runat="server" Text="To Date"></asp:Label>
                            </td>
                            <td>
                                :
                            </td>
                             <td>
                                <telerik:RadDatePicker ID="rdtp_todate" runat="server" 
                                        Skin="WebBlue" Width="205px" >                                    
                                        <calendar skin="WebBlue" usecolumnheadersasselectors="False" 
                                     userowheadersasselectors="False" viewselectortext="x">
                                        </calendar>                                     
                                        <datepopupbutton hoverimageurl="" imageurl="" />
                                        <dateinput dateformat="M/d/yyyy" displaydateformat="M/d/yyyy">
                                        </dateinput>
                                    </telerik:RadDatePicker>
                                   <asp:RequiredFieldValidator ID="rfv_todate" runat="server" ControlToValidate="rdtp_todate"
                                        ErrorMessage="Select To Date" ValidationGroup="CONTROLS" Text="*" ></asp:RequiredFieldValidator>
                                  <asp:CompareValidator ID="cmpv_todate" runat="server" ErrorMessage="To Date should not be less than From Date" ControlToValidate="rdtp_todate" ControlToCompare="rdtp_fromdate" Operator="GreaterThan" ValidationGroup="CONTROLS" Text="*"></asp:CompareValidator> 

                              </td>
                                    <td>
                                     
                                    </td>
                                                     
                            </tr>

                             <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_outcome" runat="server" 
                                        Text="Outcome"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                  <asp:TextBox ID="txtbx_Outcome" runat="server" MaxLength="1000" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv_outcome" runat="server" ControlToValidate="txtbx_Outcome"
                                        ErrorMessage="Please enter Outcome" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                   
                                </td>
                            </tr>                         
                                <tr>
                                        <td align="left">
                                            <asp:Label ID="lblUpload" runat="server" Text="Participation Certification"></asp:Label>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbl_bold" runat="server" Text=":"> </asp:Label></b>
                                        </td>
                                        <td align="left">
                                            <asp:FileUpload ID="FUpload" runat="server" />
                                        </td>
                                        <td>
                                       <%--   <asp:Button ID="btn_Upload"  runat="server" Text="Upload" 
                                                onclick="btn_Upload_Click" ValidationGroup="Controls"  />--%>
                                        </td>
                                    </tr>               
                          
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btn_SAVE" runat="server" Text="Save" OnClick="btn_SAVE_Click1" meta:resourcekey="btn_SAVEResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small" OnClientClick="disableButton(this,'CONTROLS')"
                                       />&nbsp;
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"
                                        ValidationGroup="CONTROLS" meta:resourcekey="btn_UpdateResource1" Style="font-family: Arial, Helvetica, sans-serif;
                                        font-size: small" />&nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click"
                                        meta:resourcekey="btn_CancelResource1" Style="font-family: Arial, Helvetica, sans-serif;
                                        font-size: small" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="vs_CMPSummary" runat="server" ValidationGroup="CONTROLS"
                            ShowMessageBox="True" ShowSummary="False"/>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
                  </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_Save" />
            <asp:PostBackTrigger ControlID="btn_Update" />           
          <%--  <asp:PostBackTrigger ControlID="rg_docs" />--%>
      
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>