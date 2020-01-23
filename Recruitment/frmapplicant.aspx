<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frmapplicant.aspx.cs" Inherits="Recruitment_frmapplicant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
   
    <table align="center">
        <tr>
            <td>
                <div style="height: 490px; width: 990px; overflow: auto;">
                    <table align="center" width="80%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblApplicant" runat="server" Font-Bold="True" meta:resourcekey="lblApplicant"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                             <asp:UpdatePanel ID="updPanel1" runat="server">
                    <ContentTemplate>
                            
                                <telerik:RadAjaxPanel ID="RAP_Applicant" runat="server" Width="100%" LoadingPanelID="RLP_Applicant">
                                    <table align="center">
                                        <tr>
                                            <td align="left">
                                                <telerik:RadGrid  ID="RG_Applicant" runat="server" AllowPaging="True"
                                                    AutoGenerateColumns="False" Skin="WebBlue" GridLines="None" OnNeedDataSource="RG_Applicant_NeedDataSource"
                                                    AllowFilteringByColumn="True">
                                                    <MasterTableView CommandItemDisplay="Top">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="Applicant_Id" HeaderText="ID" UniqueName="APPLICANT_ID"
                                                                Visible="False">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Applicant_Code" HeaderText="Applicant Code" UniqueName="APPLICANT_CODE">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Applicant_Firstname" HeaderText="Applicant Name"
                                                                UniqueName="APPLICANT_FIRSTNAME">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Applicant_Dob" HeaderText="Date Of Birth" UniqueName="APPLICANT_DOB">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Applicant_Gender" HeaderText="Gender" UniqueName="APPLICANT_GENDER">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="Applicant_Status" HeaderText="Status" UniqueName="APPLICANT_STATUS">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn UniqueName="Edit" AllowFiltering="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_Applicant_Edit" runat="server" CommandArgument='<%# Eval("APPLICANT_ID") %>'
                                                                        OnCommand="lnk_Applicant_Edit_Command">Edit
                                                                    </asp:LinkButton>
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
                                                                <asp:LinkButton ID="lnk_Add" runat="server" OnClick="lnk_Add_Click" Text="Add"></asp:LinkButton>
                                                            </div>
                                                        </CommandItemTemplate>
                                                    </MasterTableView>
                                                    <HeaderContextMenu Skin="WebBlue">
                                                    </HeaderContextMenu>
                                                    <PagerStyle AlwaysVisible="true" />
                                                    <FilterMenu Skin="WebBlue">
                                                    </FilterMenu>
                                                    <GroupingSettings CaseSensitive="false" />
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                          <tr>
                                        <td>
                                        
                                            &nbsp;</td>
                                        </tr>
                                        <tr>
                                        <td align="center">
                                            
                                            <asp:Label ID="Label1" runat="server" Text="Import Applicant Details:" visible ="false"
                                                Font-Bold="True"></asp:Label>
                                        
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>
                                        
                                      
                                                   
                                                   <table id="import" runat="server" visible="false"  >
                                                   <tr>
                                                   <td>
                                                       <asp:Label ID="Label3" runat="server" Text="Personal Details"></asp:Label>
                                                   </td>
                                                       <td>
                                                          <strong>:</strong></td>
                                                   <td>
                                             <a href="~/Recruitment/Templates/ApplicaPersonalDetails_template.xlsx" runat="server" id="A2">Download  PersonalDetails template</a>
                                                   </td>
                                                       <td>
                                                         <strong>:</strong></td>
                                                   <td>
                                                       <asp:FileUpload ID="Up_aplicntPersonal" runat="server" />
                                                       </td>
                                                   <td>
                                                       <asp:Button ID="btn_Imp_personal" runat="server" Text="Import" 
                                                           onclick="btn_Imp_personal_Click" />
                                                   </td>
                                                   </tr>
                                                   <tr>
                                                   <td>
                                                       <asp:Label ID="Label4" runat="server" Text="Qualification Details"></asp:Label>
                                                   </td>
                                                       <td>
                                                          <strong>:</strong></td>
                                                   <td>
                                                <a href="~/Recruitment/Templates/Qualifications_template.xlsx" runat="server" id="A1">
                                                       DownloadQualificationDetails template</a>
                                                   </td>
                                                       <td>
                                                           <strong>:</strong></td>
                                                   <td>
                                                       <asp:FileUpload ID="FileUp_Qual" runat="server" />
                                                   </td>
                                                   <td>
                                                       <asp:Button ID="btn_imp_qualification" runat="server" Text="Import" onclick="btn_imp_qualification_Click"  
                                                           />
                                                   </td>
                                                   </tr>
                                                   <tr>
                                                   <td>
                                                       <asp:Label ID="Label5" runat="server" Text="Skills Details"></asp:Label>
                                                       </td>
                                                       <td>
                                                     <strong>:</strong></td>
                                                   <td>
                                                  <a href="~/Recruitment/Templates/Skills.xlsx" runat="server" id="A3">Download Skills Details template</a>

                                                    </td>
                                                       <td>
                                                           <strong>:</strong></td>
                                                   <td>
                                                       <asp:FileUpload ID="Uploadskills" runat="server" />
                                                   </td>
                                                   <td>
                                                       <asp:Button ID="btn_Imp_skills" runat="server" Text="Import" 
                                                           onclick="btn_Imp_skills_Click" />
                                                   </td>
                                                   </tr>
                                                   <tr>
                                                   <td>
                                                       <asp:Label ID="Label6" runat="server" Text="Experiance Details"></asp:Label>
                                                   </td>
                                                       <td>
                                                           <strong>:</strong></td>
                                                   <td>
                                                    <a href="~/Recruitment/Templates/ApplicantExperience_Details.xlsx" runat="server" id="A4">Download Experiance Details template</a>
                                                   </td>
                                                       <td>
                                                          <strong>:</strong></td>
                                                   <td>
                                                       <asp:FileUpload ID="FileUp_Exp" runat="server" />
                                                       </td>
                                                   <td>
                                                       <asp:Button ID="btn_Imp_exp" runat="server" Text="Import" onclick="btn_Imp_exp_Click" />
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                   <td>
                                                       <asp:Label ID="Label7" runat="server" Text="Contact Details"></asp:Label>
                                                   </td>
                                                       <td>
                                                          <strong>:</strong></td>
                                                   <td><a ID="A5" runat="server" href="~/Recruitment/Templates/Contacts.xlsx">Download 
                                                       Contact Details template</a></td>
                                                       <td>
                                                           <strong>:</strong></td>
                                                   <td>
                                                       <asp:FileUpload ID="UploadContact" runat="server" />
                                                       </td>
                                                   <td>
                                                       <asp:Button ID="btn_Imp_contacts" runat="server" Text="Import" 
                                                           onclick="btn_Imp_contacts_Click" />
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                   <td>
                                                       <asp:Label ID="Label2" runat="server" Text="Language Details"></asp:Label>
                                                   </td>
                                                       <td>
                                                         <strong>:</strong></td>
                                                   <td><a ID="A6" runat="server" href="~/Recruitment/Templates/Applicantlanguage_template.xlsx">Download 
                                                       Language Details template</a></td>
                                                       <td>
                                                          <strong>:</strong></td>
                                                   <td>
                                                       <asp:FileUpload ID="FileUpload6" runat="server" />
                                                       </td>
                                                   <td>
                                                       <asp:Button ID="btn_language" runat="server" Text="Import" 
                                                           onclick="btn_language_Click" />
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                   <td colspan="6" align="center">
                                              
                                                       <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                                                           Text="Import All Applicant Details at a time:"></asp:Label>
                                              
                                                   </td>
                                                   </tr>
                                                   <tr>
                                                   <td>
                                                   
                                                       <asp:Label ID="Label9" runat="server" Text="Applicant Details"></asp:Label>
                                                   
                                                   </td>
                                                   <td>
                                                   
                                                       <strong>:</strong></td>
                                                       <td>
                                                         <a id="D1" runat="server" href="~/Recruitment/Templates/ApplicantDetails_Template.xlsx">Download Applicant Details Template</a> 

                                                       </td>
                                                       <td><strong>:</strong></td>
                                                       <td>
                                                           <asp:FileUpload ID="Up_aplicant" runat="server" />
                                                       </td>
                                                       <td>
                                                           <asp:Button ID="btn_Imp_aplicant" runat="server" 
                                                               onclick="btn_Imp_aplicant_Click" Text="Import" />
                                                       </td>
                                                   </tr>
                                                   </table>
                                                    
                                            </td>
                                        </tr>
                                      
                                    </table>
                                    <br />
                                </telerik:RadAjaxPanel>
                                </ContentTemplate>
                                 <Triggers>
                        <asp:PostBackTrigger ControlID="btn_Imp_personal" />
                        <asp:PostBackTrigger  ControlID="btn_language"/>
                         <asp:PostBackTrigger  ControlID="btn_imp_qualification"/>
                          <asp:PostBackTrigger  ControlID="btn_Imp_exp"/>
                          <asp:PostBackTrigger ControlID="btn_Imp_Skills" />
                        <asp:PostBackTrigger  ControlID="btn_Imp_Contacts" />
                         <asp:PostBackTrigger ControlID="btn_Imp_aplicant" />
                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
