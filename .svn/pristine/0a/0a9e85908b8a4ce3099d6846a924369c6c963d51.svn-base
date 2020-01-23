<%@ Page Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_VariablepayComponents.aspx.cs" Inherits="Masters_frm_VariablepayComponents" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
<table align="center">
    
    <tr>
        <td colspan="5"> <telerik:RadWindowManager ID="RWM_POSTREPLY1" runat="server" Style="z-index: 8000">
    </telerik:RadWindowManager>
    </td>        
    </tr>
    
    <tr>
        <td colspan="5" align="center">
            <asp:Label ID="lbl_Header" runat="server" Text="Variable Pay Components" Font-Bold="true">
            </asp:Label>
        </td>
    </tr>
    
    <tr>
        <td colspan="5"></td>
    </tr>
    
    <tr>
        <td colspan="5" align="center">
            <telerik:RadMultiPage ID="RMP_VariablepayComponents" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RPV_AllComponents" runat="server">
                 <asp:UpdatePanel ID="updPanel1" runat="server">
                    <ContentTemplate>
                    
                    <telerik:RadGrid ID="rg_VariablepayComponents" AutoGenerateColumns="false" 
                        runat="server" onneeddatasource="rg_VariablepayComponents_NeedDataSource" AllowFilteringByColumn="true">
                        <MasterTableView CommandItemDisplay="Top">
                            <Columns>
                                
                                <telerik:GridBoundColumn HeaderText="No" DataField="SMHR_VPCOMP_ID" ItemStyle-HorizontalAlign="Left" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn HeaderText="Component Name" DataField="SMHR_VPCOMP_COMPNAME" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn HeaderText="Component Description" DataField="SMHR_VPCOMP_COMPDESC" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn HeaderText="Status" DataField="SMHR_VPCOMP_COMPSTATUS" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_Edit" runat="server" Text="Edit" CommandArgument='<%#Eval("SMHR_VPCOMP_ID") %>' OnCommand="lnk_Edit_Command"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                            </Columns> 
                            <CommandItemTemplate>
                              <div align="right">
                                <asp:LinkButton ID="lnk_Add" runat="server" Text="Add" OnCommand="lnk_Add_Command"></asp:LinkButton>
                              </div>
                            </CommandItemTemplate>
                        </MasterTableView>                        
                    </telerik:RadGrid>
              <table>
                    <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                    <tr>
                    <td> <a id="A1" runat="server" href="~/Masters/Importsheets/VariablePaycomponent.xlsx">Download VariablePay Component
                                                                Template</a> </td>
                    <td><strong>:</strong></td>
                    <td><asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload></td>
                    <td><asp:Button ID="Button1" runat="server" Text="Import" onclick="Button1_Click"></asp:Button></td>
                    </tr>
                    </table>
              
                    
                     </ContentTemplate>
                     <Triggers>
                <asp:PostBackTrigger  ControlID="Button1"/>

                     </Triggers>
                     </asp:UpdatePanel>
                </telerik:RadPageView>
                
                <telerik:RadPageView ID="RPV_AddComponents" runat="server">
                    <table align="center">
                        <tr>
                            <td colspan="5"></td>                           
                        </tr>
                        
                        <tr>
                            <td></td>
                            <td align="left">
                                <asp:Label ID="lbl_Componentname" runat="server" Text="Component Name"></asp:Label>
                            </td>
                            <td><b>:</b></td>
                            <td align="left"> 
                                <asp:TextBox ID="txt_Componentname" runat="server" MaxLength="100" TabIndex="1"></asp:TextBox>
                            </td>
                            <td>
                                    <asp:RequiredFieldValidator ID="rfv_Componentname" runat="server" ErrorMessage="Please Specify Component Name " 
                                ControlToValidate="txt_Componentname" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td></td>
                            <td align="left">
                                <asp:Label ID="lbl_Componentdesc" runat="server" Text="Component Description"></asp:Label>
                            </td>
                            <td><b>:</b></td>
                            <td align="left"> 
                                <asp:TextBox ID="txt_Componentdesc" runat="server" MaxLength="100" TabIndex="2"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        
                        <tr id="Status" runat="server">
                            <td>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbl_Status" runat="server" Text="Status">
                                </asp:Label>
                            </td>
                            <td><b>:</b></td>
                            <td align="left">
                                <%--<asp:CheckBox ID="chk_Status" runat="server" />--%>
                                   <telerik:RadComboBox  ID="rcmb_Status" runat="server" TabIndex="3" 
                                        AutoPostBack="true"  Skin="WebBlue" MarkFirstMatch="true" >
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Active" Value="1" />
                                            <telerik:RadComboBoxItem Text="InActive" Value="0" />
                                        </Items>
                                    
                                    </telerik:RadComboBox>
                            </td>
                            <td></td>
                        </tr>
                        
                        <tr id="MinPercentage" runat="server">
                            <td></td>
                            <td align="left"> 
                                <asp:Label ID="lbl_Minpercentage" runat="server" Text="Minimum Percentage"></asp:Label>
                            </td>
                            <td><b>:</b></td>
                            <td align="left">
                                <telerik:RadNumericTextBox ID="rntxt_Min" runat="server" MinValue="0" MaxLength="3" TabIndex="4">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                    <asp:RequiredFieldValidator ID="rfv_Min" runat="server" ErrorMessage="Please Specify Minimum Percentage" 
                                    ControlToValidate="rntxt_Min" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="MaxPercentage" runat="server">
                            <td></td>
                            <td align="left">
                                <asp:Label ID="lbl_Maxpercentage" runat="server" Text="Max Percentage">
                                </asp:Label>
                            </td>
                            <td><b>:</b></td>
                            <td align="left">
                                <telerik:RadNumericTextBox ID="rntxt_Max" runat="server" MinValue="0" MaxLength="3" TabIndex="5">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfv_Max" runat="server" ErrorMessage="Please Specify Maximum Percentage" 
                                ControlToValidate="rntxt_Max" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                               <%-- <asp:CompareValidator ID="cv_Max" runat="server" ControlToValidate="rntxt_Min" ControlToCompare="rntxt_Max"
                                 Operator="GreaterThan" ValidationGroup="Controls" 
                                    ErrorMessage="Max Percentage Should be Greater than Min Percentage">*</asp:CompareValidator> --%>
                            </td>
                        </tr>
                      <tr>
                        <td colspan="5"></td>
                      </tr>  
                      
                      <tr>
                        <td colspan="2"></td>
                        <td colspan="3">
                            <asp:Button ID="btn_Save" runat="server" Text="Save" TabIndex="6" 
                                ValidationGroup="Controls" onclick="btn_Save_Click" />
                            <asp:Button ID="btn_Update" runat="server" Text="Update" TabIndex="6" 
                                ValidationGroup="Controls" onclick="btn_Save_Click" />
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" TabIndex="7" 
                                CausesValidation="False" onclick="btn_Cancel_Click" />
                        </td>
                      </tr>
                      
                      <tr>
                        <td colspan="5" align="center">
                            <asp:ValidationSummary ID="vs_Variablepaycomponent" runat="server" 
                            ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
                            
                        </td>
                      </tr>
                        
                    </table>
                </telerik:RadPageView> 
            </telerik:RadMultiPage>
        </td>
    </tr>
</table>
</asp:Content>

