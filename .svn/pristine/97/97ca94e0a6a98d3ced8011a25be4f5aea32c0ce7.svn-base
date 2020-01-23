<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="LoanRadWindow.aspx.cs" Inherits="Masters_LoanRadWindow" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
    <style type="text/css">
.setWidth
{
	width:100px !important;
}
        .setWidth1 {
            width:450px !important;
        }
        </style>
    <telerik:RadAjaxManagerProxy ID="RAM_County" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_County">
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
    <br /><br />
    <table width="880px">
        <tr>
            <td>
                <table align="center" style="vertical-align: top;" width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblKenya" runat="server" Text="REPUBLIC OF KENYA" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
            </td>
        </tr>

    <tr>
        <td>

    <table align="center" style="vertical-align: top;" width="100%">
        <tr>
            <td align="center">
                
                <asp:Label ID="lblVourcher" runat="server" Text="PAYMENT VOURCHER" Font-Bold="true"></asp:Label>
                    
            </td>
        </tr>
    </table>
            </td>
    </tr>
          <tr>
        <td>
     <table align="center" style="vertical-align: top;" width="100%">
        <tr>
            <td align="center">
            
                <asp:Label ID="lblSuspense" runat="server" Text="(DEPOSITS OF SUSPENSE)" Font-Bold="true"></asp:Label>
                
            </td>
        </tr>
    </table>
             </td>
    </tr>
          <tr>
        <td>
     <table align="center" style="vertical-align: top;" width="100%">
        <tr>
            <td align="center">
             
                <asp:Label ID="lblPayee" runat="server" Text="Payee's Name And Address:HON." Font-Bold="false"></asp:Label>
                 
            </td>
        </tr>
    </table>
             </td>
    </tr>
          <tr>
        <td>
   
    <table  runat="server" align="center" border="1" width="100%">
        <tr>
            <td rowspan="2" colspan="2">
                <asp:Label ID="lblParticulars" runat="server" Text="Particulars" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAmount" runat="server" Text="Amount" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>sh.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cts</td>
        </tr>
        <tr>
            <td colspan="2">
                 BEING SALARY IN ADVANCE TO THE HON.MP. TO BE RECOVERY FULLY FROM THIS JANUARY 201RY 2014 SALARY
                 &nbsp;</td>
            <td align="right" valign="bottom" rowspan="3"><telerik:RadTextBox ID="rtxtAmount" runat="server"
                                        Skin="WebBlue" MaxLength="100" CssClass="setWidth">
                                    </telerik:RadTextBox><br />
                <telerik:RadTextBox ID="rtxtVat" runat="server"
                                        Skin="WebBlue" MaxLength="100" CssClass="setWidth">
                                    </telerik:RadTextBox></td>
        </tr>
        <tr>
            <td >
                 <em>BANK CODE-BRANCH CODE-ACCOUNT NO:</em></td>
            <td align="right" >
                 <strong>NET</strong></td>
        </tr>
        <tr>
            <td>
                <telerik:RadTextBox ID="RadTextBox25" runat="server" Skin="WebBlue" MaxLength="100" Width="70%" CssClass="setWidth"></telerik:RadTextBox>
            </td>
            <td align="right">
                 <strong>VAT</strong></td>
        </tr>
        <tr>
            <td colspan="2">
              
                <asp:Label ID="lblAmount1" runat="server" Text="Amount Payable(in Words) Total  sh. cts"></asp:Label>
                 
            </td>
            <td align="right"><telerik:RadTextBox ID="rtxt_Total" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox></td>
        </tr>
        <tr>
            <td colspan="3">                
                <asp:Label ID="lblshillings" runat="server" Text="Shillings:"></asp:Label>
                <telerik:RadTextBox ID="rtxt_shillings" runat="server" Width="500px" CssClass="setWidth1"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                
                <asp:Label ID="lblAuthory" runat="server" Text="Authority Reference No."></asp:Label>
                   <telerik:RadTextBox ID="RadTextBox26" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
            </td>
        </tr>
    </table>
             </td>
    </tr>
          <tr>
        <td>
    <table  align="center" border="1" width="100%">
        <tr>
            <td align="center" colspan="2">
                 <asp:Label ID="lblExamination" runat="server" Text="EXAMINATION" Font-Bold="true"></asp:Label></td>
            <td align="center">
                <asp:Label ID="lblinternal" runat="server" Text="Internal Audit" Font-Bold="true"></asp:Label>    </td>
        </tr>
        
        <tr>
            <td align="left">
               
                 Voucher Examined By</td>
            <td align="left">
               
                <telerik:RadTextBox ID="rtxtexamined" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>   
            </td>
            <td >                          
                <telerik:RadTextBox ID="RadTextBox1" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox><br />
              
            </td>
        </tr>
        
        <tr>
            <td align="left">
               
                Date
                </td>
            <td align="left">
               
                <telerik:RadTextBox ID="rtxtdate" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
            </td>
            <td >                          
                <telerik:RadTextBox ID="RadTextBox2" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
              
            </td>
        </tr>
        </table>
        <table border="1">
        <tr>
            <td align="left" colspan="2" valign="top" width="50%">
                <asp:Label ID="Label1" runat="server" Text="DEPOSIT AND SUSPENSE CERTIFICATE" Font-Bold="true"></asp:Label>
                  <br />
                I Certify that the Amount of Payment has
                been Entered in the Relevant Register and
                the adequate funds previously deposited
                and credited to A/c No  <telerik:RadTextBox ID="RadTextBox3" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox> has been repaid<br />
                Net Deposit brought forward from previous
                <br />Month A/C No<telerik:RadTextBox ID="RadTextBox4" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox> &nbsp;ksh <telerik:RadTextBox ID="RadTextBox5" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox><br />
                Less/Add:
                <br />Total Payment/receipt Current month Ksh.
                <br />Balance:<telerik:RadTextBox ID="RadTextBox6" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>&nbsp;(+) Ksh<telerik:RadTextBox ID="RadTextBox7" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                <br />Less:This EntryVch.No Ksh<telerik:RadTextBox ID="RadTextBox8" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                &nbsp;<br />
&nbsp;&nbsp;&nbsp;
                I Certify that proper reconcilitation of the above
                balances Has been carried out and that this
                Payment is based on the named balance.<br />
                      Date.<telerik:RadTextBox ID="RadTextBox9" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox> 
                      &nbsp;&nbsp;&nbsp;&nbsp;Signature <telerik:RadTextBox ID="RadTextBox10" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                      <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Account/I/c Deposits & Suspense
                         
            </td>
            <td align="left" valign="top" width="50%" >
                <asp:Label ID="Label2" runat="server" Text="AUTHORIZATION" Font-Bold="true"></asp:Label>
                 <br />
                I certify that the Payment has been made on proper 
                authority.Where appropriate a relevant certificate has 
                been completed in the Space Provided overleaf <telerik:RadTextBox ID="RadTextBox11" runat="server"
                                        Skin="WebBlue" MaxLength="100" CssClass="setWidth">
                                    </telerik:RadTextBox>
                &nbsp;<br />
                     <br />
&nbsp;&nbsp;&nbsp;&nbsp;
                I am Satisfied that the Amount of payments has shown above
                is a proper charge to the item shown here below and hereby
                AUTHORIZE payment therefore without any alteration.
                     <br />
                     <br />
                     &nbsp;&nbsp;&nbsp;
                     Signature&nbsp;&nbsp; <telerik:RadTextBox ID="RadTextBox12" runat="server"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Accounting Officer/District Accountant
                     <br />
                     <br />
                     &nbsp;&nbsp;&nbsp;
                     Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <telerik:RadTextBox ID="RadTextBox13" runat="server" CssClass="setWidth"
                                        Skin="WebBlue" MaxLength="100">
                                    </telerik:RadTextBox> 
                      
            </td>
        </tr>
     </table>
    
  

             </td>
    </tr>
          <tr>
        <td>
   
               <table align="center" border="1" width="100%">
                   <tr>
                       <td rowspan="2"><h5 class="auto-style3">
                <asp:Label ID="Label5" runat="server" Text="VOTE" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label6" runat="server" Text="Head" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label7" runat="server" Text="Sub-Head" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label8" runat="server" Text="Source" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label9" runat="server" Text="Programme" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label10" runat="server" Text="Geographical" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label11" runat="server" Text="Item" Font-Bold="true"></asp:Label>
                    </h5></td>
                   </tr>
                   <tr>
                       <td><telerik:RadTextBox ID="RadTextBox14" runat="server" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox> </td>
                       <td><telerik:RadTextBox ID="RadTextBox15" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                       <td><telerik:RadTextBox ID="RadTextBox16" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                       <td><telerik:RadTextBox ID="RadTextBox17" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                       <td><telerik:RadTextBox ID="RadTextBox18" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                       <td><telerik:RadTextBox ID="RadTextBox19" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                   </tr>
                   <tr>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label3" runat="server" Text="Account No:" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label4" runat="server" Text="Dept.Vch" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label12" runat="server" Text="Station" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td colspan="2"><h5 class="auto-style3">
                <asp:Label ID="Label13" runat="server" Text="CASH BOOK" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td colspan="2"><h5 class="auto-style3">
                <asp:Label ID="Label14" runat="server" Text="AMOUNT:" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                   </tr>
                   <tr>
                       <td rowspan="2"><telerik:RadTextBox ID="RadTextBox22" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                       <td rowspan="2"><telerik:RadTextBox ID="RadTextBox23" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                       <td rowspan="2"><telerik:RadTextBox ID="RadTextBox24" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                       <td colspan="2"><h5 class="auto-style3">
                <asp:Label ID="Label15" runat="server" Text="Vch No:" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label16" runat="server" Text="Date" Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                       <td><h5 class="auto-style3">
                <asp:Label ID="Label17" runat="server" Text="SH." Font-Bold="true" Width="70%"></asp:Label>
                    </h5></td>
                   </tr>
                   <tr>
                       <td>&nbsp;</td>
                       <td></td>
                       <td rowspan="2"><telerik:RadTextBox ID="RadTextBox20" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                       <td colspan="2" rowspan="2"><telerik:RadTextBox ID="RadTextBox21" runat="server" Skin="WebBlue" MaxLength="100" CssClass="setWidth"></telerik:RadTextBox></td>
                   </tr>
               </table>
            </td></tr>
        </table>
          
</asp:Content>




