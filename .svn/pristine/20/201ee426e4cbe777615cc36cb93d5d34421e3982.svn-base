<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master"  AutoEventWireup="true" CodeFile="frm_EmpWorkshops.aspx.cs" Inherits="HR_frm_EmpWorkshops" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/BUFilter.ascx" TagPrefix="uc1" TagName="BUFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
     <asp:UpdatePanel ID="updPanel" runat="server">
            <ContentTemplate >
                <br /> <br /> <br />
    <table align="center">        
        <tr>
            <td align="center">
                <asp:Label ID="lbl_CMP" runat="server" Text="Workshops/Seminars Attended" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_EmpWorkshopform" runat="server">
                    <telerik:RadPageView ID="RP_EmpWorkshopformform" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_EmpWorkshopform" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        PageSize="5" Skin="WebBlue" GridLines="None" AllowFilteringByColumn="True" OnNeedDataSource="RG_EmpWorkshopform_NeedDataSource"
                                        meta:resourcekey="RG_cmpformResource1" Width="900px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="EMPWRKSHOPS_ID" DataField="EMPWRKSHOPS_ID" UniqueName="column1"
                                                    Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn HeaderText="EMPLOYEE NAME" DataField="NAME" UniqueName="column12"
                                                    Visible="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="WORKSHOP/SEMINAR NAME" DataField="EMPWRKSHOPS_NAME"
                                                    Visible="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="ORGANISED BY" DataField="EMPWRKSHOPS_ORGBY" UniqueName="column11"
                                                    meta:resourcekey="GridBoundColumnResource11">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="SPONSORED BY" DataField="EMPWRKSHOPS_SPNOSDBY" UniqueName="column"
                                                    meta:resourcekey="GridBoundColumnResource1">
                                                </telerik:GridBoundColumn>       
                                                 <telerik:GridDateTimeColumn HeaderText="WORKSHOP FROM DATE" DataField="EMPWRKSHOPS_FROMDATE" UniqueName="column13" DataFormatString="{0:M/d/yyyy}" FilterControlWidth="100px"
                                                    Visible="true">
                                                </telerik:GridDateTimeColumn>
                                                 <telerik:GridDateTimeColumn HeaderText="WORKSHOP TO DATE" DataField="EMPWRKSHOPS_TODATE" UniqueName="column14" DataFormatString="{0:M/d/yyyy}" FilterControlWidth="100px"
                                                    Visible="true">
                                                </telerik:GridDateTimeColumn>                                                                               
                                              <%--  <telerik:GridBoundColumn HeaderText="Status" DataField="CMP_STATUS" UniqueName="CMP_STATUS"
                                                    meta:resourcekey="GridBoundColumnResource3">
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Commnad" CommandArgument='<%# Eval("EMPWRKSHOPS_ID") %>'
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
                    <telerik:RadPageView ID="RP_EmpWorkshopformview2" runat="server" Width="100%">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_CMPdet" runat="server" Text="" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                        <uc1:BUFilter runat="server" ID="BUFilter1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 154px;">
                                      <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="False" meta:resourcekey="lbl_idResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small"></asp:Label>
                                     <asp:HiddenField ID="HF_ID" runat="server" />
                                    <asp:Label ID="lbl_WrkshpName" runat="server" 
                                        Text="Workshop/Seminar Name"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                  <asp:TextBox ID="txtbx_WrkshpName" runat="server" MaxLength="1000" Width="200px"></asp:TextBox>
                                    <span>
                                           <asp:RequiredFieldValidator ID="rfv_WrkshpName" runat="server" ControlToValidate="txtbx_WrkshpName"
                                        ErrorMessage="Please enter Workshop Name" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>
                                    </span>
                                </td>
                                <td>
                                 <%--   <asp:RequiredFieldValidator ID="rfv_WrkshpName" runat="server" ControlToValidate="txtbx_WrkshpName"
                                        ErrorMessage="Please enter Workshop Name" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>                            
                          <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_Orgby" runat="server" 
                                        Text="Organized By"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                  <asp:TextBox ID="txtbx_Orgby" runat="server" MaxLength="1000" Width="200px"></asp:TextBox>
                                    <span>
                                     <asp:RequiredFieldValidator ID="rfv_Orgby" runat="server" ControlToValidate="txtbx_Orgby"
                                        ErrorMessage="Please enter Organised By" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>
                                    </span>
                                </td>
                                <td>
                                  <%--  <asp:RequiredFieldValidator ID="rfv_Orgby" runat="server" ControlToValidate="txtbx_Orgby"
                                        ErrorMessage="Please enter Organised By" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                             <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_SpnsBy" runat="server" 
                                        Text="Sponsored By"></asp:Label>
                                </td>
                                <td>
                                    :
                                </td>
                                <td align="left">
                                  <asp:TextBox ID="txtbx_SpnsBy" runat="server" MaxLength="1000" Width="200px"></asp:TextBox>
                                    <span>
                                      <asp:RequiredFieldValidator ID="rfv_Spnsby" runat="server" ControlToValidate="txtbx_SpnsBy"
                                        ErrorMessage="Please enter Sponsored By" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>
                                    </span>
                                </td>
                                <td>
                                  <%--  <asp:RequiredFieldValidator ID="rfv_Spnsby" runat="server" ControlToValidate="txtbx_SpnsBy"
                                        ErrorMessage="Please enter Sponsored By" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>--%>
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
                                 <span>
                                      <asp:RequiredFieldValidator ID="rfv_fromdate" runat="server" ControlToValidate="rdtp_fromdate"
                                        ErrorMessage="Select From Date" ValidationGroup="CONTROLS" >*</asp:RequiredFieldValidator>
                                 </span>
                              </td>
                                    <td>
                                    <%--     <asp:RequiredFieldValidator ID="rfv_fromdate" runat="server" ControlToValidate="rdtp_fromdate"
                                        ErrorMessage="Select From Date" ValidationGroup="CONTROLS" >*</asp:RequiredFieldValidator>--%>

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
                                 <span>
                                  <asp:RequiredFieldValidator ID="rfv_todate" runat="server" ControlToValidate="rdtp_todate"
                                        ErrorMessage="Select To Date" ValidationGroup="CONTROLS" Text="*"></asp:RequiredFieldValidator>
                                     <asp:CompareValidator ID="cmpv_todate" runat="server" ErrorMessage="To Date should not be less than From Date" 
                                         ValidationGroup="CONTROLS" ControlToValidate="rdtp_todate" ControlToCompare="rdtp_fromdate" Operator="GreaterThan" Text="*"></asp:CompareValidator>
                                 </span>
                              </td>
                                    <td>
                                        <%-- <asp:RequiredFieldValidator ID="rfv_todate" runat="server" ControlToValidate="rdtp_todate"
                                        ErrorMessage="Select To Date" ValidationGroup="CONTROLS" >*</asp:RequiredFieldValidator>--%>
<%--<asp:CompareValidator ID="cmpv_todate" runat="server" ErrorMessage="To Date should not be less than From Date" ControlToValidate="rdtp_todate" ControlToCompare="rdtp_fromdate" Operator="GreaterThan"></asp:CompareValidator>--%>
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
                                    <span>
                                      <asp:RequiredFieldValidator ID="rfv_outcome" runat="server" ControlToValidate="txtbx_Outcome"
                                        ErrorMessage="Please enter Outcome" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>
                                    </span>
                                </td>
                                <td>
                                  <%--  <asp:RequiredFieldValidator ID="rfv_outcome" runat="server" ControlToValidate="txtbx_Outcome"
                                        ErrorMessage="Please enter Outcome" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>                         
                                <tr>
                                        <td align="left">
                                            <asp:Label ID="lblUpload" runat="server" Text="Participation Certification"></asp:Label>
                                        </td>
                                        <td>
                                            
                                                <asp:Label ID="lbl_bold" runat="server" Text=":"> </asp:Label>
                                        </td>
                                        <td align="left">
                                          <asp:FileUpload ID="FUpload" runat="server"></asp:FileUpload>                                       
                                        </td>
                                        <td>
                                          <%--<asp:Button ID="btn_Upload"  runat="server" Text="Upload" 
                                                onclick="btn_Upload_Click" ValidationGroup="Controls"  />--%>
                                        </td>
                                    </tr>               
                          
                            <tr>
                                <td align="center" colspan="4">
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