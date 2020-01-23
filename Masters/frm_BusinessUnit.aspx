<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_BusinessUnit.aspx.cs" Inherits="Masters_frm_BusinessUnit" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="cnt_BusinessUnit" ContentPlaceHolderID="cphDefault" runat="Server">
    <telerik:RadScriptBlock ID="Rsb_Scripts" runat="server">

        <script language="javascript" type="text/javascript">
            //added by joseph          
            function ValidateAlpha() {
                var keyCode = window.event.keyCode;
                if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                    window.event.returnValue = false;
                }
            }
            //
            function ShowPopForm(url) {
                var win = window.radopen(url, "rwin_Pop");
                // win.maximize();
                win.center();
                win.set_modal(true);
            }

            function ToggleRow() {
                var trNoOfHours = document.getElementById("trNoOfHours"),
                state = trNoOfHours.style.display;
                var checkBox = document.getElementsByName("chkNoOfHours");
                if (checkBox.checked) {
                    trCode.style.display = '';
                }
                else {
                    trCode.style.display = 'none';
                }
            }
            // for validating atleast one pay ment modes is selected or not
            //            function Validate(oSrc, args)  {

            //                    var iBox = 0; // collection index
            //                    var bChecked = false; // the switch to flip when we get a checked box
            //                    var sCheckBoxID = args.Value;  //value in the check box
            //                    while(document.getElementById(sCheckBoxID + iBox) && !bChecked) {
            //                    // only stay in the loop while we have additional boxes but no checks yet
            //                        if (document.getElementById(sCheckBoxID + iBox).checked) 
            //                            { bChecked = true; }
            //                    iBox++;

            //                    }

            //                    args.IsValid = bChecked;
            //              //dsocument.getElementById("RLB_BusinessUnitPaymentMode").
            //           }
            //               function Validate()
            //               {
            //                       var Countofcheckboxes=0;
            //                       var Checkboxlist=document.getElementsByTagName("RadListBox");
            //                       for(var index=0; index>Checkboxlist.length;index++)
            //                       {
            //                        if(Checkboxlist[index].Checked)
            //                            Countofcheckboxes+=1;
            //                       }
            //                       if (Countofcheckboxes <= 0)
            //                           return alert("Select Atleast One Payment Mode");
            //               }

        </script>

        <%--<script language="javascript" type="text/javascript">
            function disableButton(sender, group) {
                //Page_ClientValidate(group);
                if (Page_IsValid) {
                    sender.disabled = "disabled";
                    __doPostBack(sender.name, '');
                }
            }
	</script>--%>
    </telerik:RadScriptBlock>
    <telerik:RadAjaxManagerProxy ID="RAM_BusinessUnit" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_BusinessUnit">
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
            <telerik:AjaxSetting AjaxControlID="rcmb_BusinessUnitCategory">
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
                <asp:Label ID="lbl_BusinessUnitHeader" runat="server" Text="Business Unit" Font-Bold="True"
                    meta:resourcekey="lbl_BusinessUnitHeaderResource1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="Rm_BU_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="990px" meta:resourcekey="Rm_BU_pageResource1">
                    <telerik:RadPageView ID="Rp_BU_ViewMain" runat="server" meta:resourcekey="Rp_BU_ViewMainResource1"
                        Selected="True">
                        <asp:UpdatePanel ID="updPanel1" runat="server">
                            <ContentTemplate>
                                <table align="center" width="60%">
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="Rg_BusinessUnit" runat="server" AutoGenerateColumns="False"
                                                AllowFilteringByColumn="True" AllowSorting="True" Skin="WebBlue" GridLines="None"
                                                OnNeedDataSource="Rg_BusinessUnit_NeedDataSource" AllowPaging="True" meta:resourceKey="Rg_BusinessUnit">
                                                <GroupingSettings CaseSensitive="False" />
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_ID" HeaderText="ID" meta:resourceKey="BUSINESSUNIT_ID"
                                                            UniqueName="BUSINESSUNIT_ID" Visible="False">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_CODE" HeaderText="Code" meta:resourcekey="BUSINESSUNIT_CODE"
                                                            UniqueName="BUSINESSUNIT_CODE" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_DESC" HeaderText="Name" meta:resourcekey="BUSINESSUNIT_DESC"
                                                            UniqueName="BUSINESSUNIT_DESC" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <%-- <telerik:GridBoundColumn DataField="BUSINESSUNIT_CATAGORY_ID" HeaderText="Address"
                                                            meta:resourcekey="BUSINESSUNIT_CATAGORY_ID" UniqueName="BUSINESSUNIT_CATAGORY_ID"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>--%>
                                                        <telerik:GridBoundColumn DataField="BUSINESSUNIT_ADDRESS" HeaderText="Address" meta:resourcekey="BUSINESSUNIT_ADDRESS"
                                                            UniqueName="BUSINESSUNIT_ADDRESS" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="Edit" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("BUSINESSUNIT_ID") %>'
                                                                    meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <CommandItemTemplate>
                                                        <div align="right">
                                                            <asp:LinkButton ID="lnk_Add" runat="server" meta:resourcekey="lnk_AddResource2" OnCommand="lnk_Add_Command">Add</asp:LinkButton>
                                                        </div>
                                                    </CommandItemTemplate>
                                                </MasterTableView>
                                                <PagerStyle AlwaysVisible="True" />
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
                                                <%-- <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="D2" runat="server"
                                                        href="~/Masters/Importsheets/BusinessUnitTemplate.xlsx">Download BusinessUnit Template</a>
                                                    </td>
                                                    <td>
                                                        <strong>:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_Imp_Businessunit" runat="server" Text="Import" OnClick="Btn_Imp_Businessunit_click" />
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <%--<asp:PostBackTrigger ControlID="btn_Imp_Businessunit" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_BU_ViewDetails" runat="server" meta:resourcekey="Rp_BU_ViewDetailsResource1">
                        <asp:UpdatePanel ID="upnl_Uploadimage" runat="server">
                            <ContentTemplate>
                                <table align="center">
                                    <tr>
                                        <td align="center" colspan="4" style="font-weight: bold;"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnitID" runat="server" Visible="False" meta:resourcekey="lbl_BusinessUnitID"></asp:Label>
                                            <asp:Label ID="lbl_BusinessUnitCode" runat="server" Text="Code" meta:resourcekey="lbl_BusinessUnitCode"></asp:Label>
                                        </td>
                                        <td><strong>:</strong>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_BusinessUnitCode" runat="server" Skin="WebBlue" MaxLength="100"
                                                meta:resourcekey="rtxt_BusinessUnitCodeResource1">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_BusinessUnitCode0" runat="server" ControlToValidate="rtxt_BusinessUnitCode"
                                                ErrorMessage="Please Enter Name" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>&#160;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnitDesc" runat="server" Text="Description" meta:resourcekey="lbl_BusinessUnitDesc"></asp:Label>
                                        </td>
                                        <td><strong>:</strong>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_BusinessUnitDesc" runat="server" Skin="WebBlue" meta:resourcekey="rtxt_BusinessUnitDesc"
                                                MaxLength="100" Width="200px" LabelCssClass="">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="category" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnitCategory" runat="server" Text="Category" meta:resourcekey="lbl_BusinessUnitCategory"></asp:Label>
                                        </td>
                                        <td><strong>:</strong>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnitCategory" runat="server" AutoPostBack="True" MaxHeight="120px"
                                                MarkFirstMatch="true" meta:resourcekey="rcmb_BusinessUnitCategory" Skin="WebBlue"
                                                OnSelectedIndexChanged="rcmb_BusinessUnitCategory_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>&#160;</td>
                                    </tr>
                                    <tr id="parentBu" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnitParent" runat="server" Text="Parent Business Unit"
                                                meta:resourcekey="lbl_BusinessUnitParent"></asp:Label>
                                        </td>
                                        <td><strong>:</strong>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnitParent" runat="server" Skin="WebBlue" meta:resourcekey="rcmb_BusinessUnitParent"
                                                MarkFirstMatch="true" MaxHeight="120px" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="tr_rcmb_BusinessUnitCountry" runat="server">
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnitCountry" runat="server" Text="Country" meta:resourcekey="lbl_BusinessUnitCountry"></asp:Label>
                                        </td>
                                        <td><strong>:</strong>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnitCountry" runat="server" MaxHeight="120px" meta:resourceKey="rcmb_BusinessUnitCountry"
                                                Skin="WebBlue" MarkFirstMatch="true" AutoPostBack="false" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitCountry" runat="server" ControlToValidate="rcmb_BusinessUnitCountry"
                                                InitialValue="Select" ValidationGroup="Controls" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td runat="server"></td>
                                    </tr>
                                    <%--OnSelectedIndexChanged="rcmb_BusinessUnitCountry_SelectedIndexChanged">--%>
                                    <%--<asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitCountry" runat="server" ControlToValidate="rcmb_BusinessUnitCountry" 
                                                ErrorMessage="please select Country" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                    <%--<asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitCountry" runat="server" ControlToValidate="rcmb_BusinessUnitCountry"
                                               ErrorMessage="Please Select Country" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>
                                    <%-- <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitCountry" runat="server" ControlToValidate="rcmb_BusinessUnitCountry"
                                                ErrorMessage="Please Select Country" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>--%>

                                    <%--<td id="Td4" runat="server">
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitCountry" runat="server" ControlToValidate="rcmb_BusinessUnitCountry"
                                                ErrorMessage="Please Select Country" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>--%>

                                    <%--  <tr id="tr_rcmb_BusinessDirectorate" runat="server">
                                        <td id="Td5" runat="server">
                                            <asp:Label ID="lblBusinessDirectorate" runat="server" Text="Directorate" meta:resourcekey="lblBusinessDirectorate"></asp:Label>
                                        </td>
                                        <td id="Td6" runat="server">:
                                        </td>
                                        <td id="Td7" runat="server">
                                            <telerik:RadComboBox ID="rcmb_BusinessDirectorate" runat="server" meta:resourcekey="rcmbBusinessDirectorate"
                                                MarkFirstMatch="true" Skin="WebBlue">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td id="Td8" runat="server">
                                            <asp:RequiredFieldValidator ID="rfvBusinessDirectorate" runat="server" ControlToValidate="rcmb_BusinessDirectorate"
                                                ErrorMessage="Please Select Directorate" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>


                                    <tr id="tr_rcmb_BusinessUnitCurrency" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessUnitCurrency" runat="server" Text="Currency" meta:resourcekey="lbl_BusinessUnitCurrency"></asp:Label>
                                        </td>
                                        <td runat="server"><strong>:</strong>
                                        </td>
                                        <td runat="server">
                                            <telerik:RadComboBox ID="rcmb_BusinessUnitCurrency" runat="server" Skin="WebBlue" MaxHeight="120px"
                                                MarkFirstMatch="true" meta:resourcekey="rcmb_BusinessUnitCurrency" MaxLength="100" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitCurrency" runat="server" ControlToValidate="rcmb_BusinessUnitCurrency"
                                                ErrorMessage="Please Select Currency" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td runat="server"></td>
                                    </tr>
                                    <tr id="tr_rcmb_BusinessUnitDateFormat" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessUnitDateFormat" runat="server" Text="Date Format" meta:resourcekey="lbl_BusinessUnitDateFormat"></asp:Label>
                                        </td>
                                        <td runat="server"><strong>:</strong>
                                        </td>
                                        <td runat="server">
                                            <telerik:RadComboBox ID="rcmb_BusinessUnitDateFormat" runat="server" meta:resourcekey="rcmb_BusinessUnitDateFormat" MaxHeight="120px"
                                                MarkFirstMatch="true" Skin="WebBlue" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitDateFormat" runat="server" ControlToValidate="rcmb_BusinessUnitDateFormat"
                                                ErrorMessage="Please Select DateFormat" Text="*" InitialValue="Select" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td runat="server"></td>
                                    </tr>
                                    <tr id="tr_rtxt_BusinessUnitAddress" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessUnitAddress" runat="server" Text="Address" meta:resourcekey="lbl_BusinessUnitAddress"></asp:Label>
                                        </td>
                                        <td runat="server"><strong>:</strong>
                                        </td>
                                        <td runat="server">
                                            <telerik:RadTextBox ID="rtxt_BusinessUnitAddress" runat="server" LabelCssClass=""
                                                MaxLength="100" meta:resourcekey="rtxt_BusinessUnitAddress" Skin="WebBlue" TextMode="MultiLine" Style="resize: none">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_BusinessUnitAddress" runat="server" ControlToValidate="rtxt_BusinessUnitAddress"
                                                ErrorMessage="Please Enter Address" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td runat="server"></td>
                                    </tr>
                                    <tr id="pf" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_PensionFactor" runat="server" Text="Pension Factor">

                                            </asp:Label>

                                        </td>
                                        <td>:</td>
                                        <td>
                                            <%--   <telerik:RadTextBox ID="rad_BusinessFactor" runat="server" 
                                             MarkFirstMatch="true" Skin="WebBlue">                                              
                                            </telerik:RadTextBox>--%>
                                            <telerik:RadNumericTextBox ID="rad_PensionFactor" runat="server" Skin="WebBlue" Width="125px"
                                                MinValue="0" MaxValue="99" NumberFormat-DecimalDigits="0">
                                            </telerik:RadNumericTextBox>&nbsp;&nbsp;
                                        </td>
                                        <td id="Td5" runat="server">
                                            <asp:RequiredFieldValidator ID="RFV_PensionFactor" runat="server" ControlToValidate="rad_PensionFactor"
                                                ErrorMessage="Please Enter Pension Factor" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>

                                    </tr>
                                    <%--<tr id="tr_rmtxt_BusinessUnitAge" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessUnitAge" runat="server" Text="Age" meta:resourceKey="lbl_BusinessUnitAge"></asp:Label>
                                        </td>
                                        <td runat="server"><strong>:</strong>
                                        </td>
                                        <td runat="server">
                                            <telerik:RadNumericTextBox ID="rmtxt_BusinessUnitAge" runat="server" Culture="English (United States)"
                                               SkinId="1" DataType="System.Int32" LabelCssClass="" MaxLength="2" meta:resourcekey="rmtxt_BusinessUnitAge"
                                                Skin="WebBlue" Value="18" Width="30px">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                            <telerik:RadNumericTextBox ID="rmtxt_BusinessUnitAgeM" runat="server" Culture="English (United States)"
                                                LabelCssClass="" MaxLength="2" meta:resourcekey="rmtxt_BusinessUnitAgeM" Skin="WebBlue"
                                         SkinId="1"       Value="55" Width="30px" MaxValue="99" MinValue="0">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td runat="server">
                                            <asp:CompareValidator ID="rcv_Age" runat="server" ControlToCompare="rmtxt_BusinessUnitAge"
                                                ControlToValidate="rmtxt_BusinessUnitAgeM" ErrorMessage="Minimum Age cannot be greater than Maximum Age"
                                                Operator="GreaterThan" ValidationGroup="Controls">*</asp:CompareValidator>
                                        </td>
                                    </tr>--%>
                                    <tr id="tr_rmtxt_BusinessUnitFiscalYear" runat="server" visible="false">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessUnitFiscalYear" runat="server" Text="Fiscal Year" Visible="false" meta:resourceKey="lbl_BusinessUnitFiscalYear"></asp:Label>
                                        </td>
                                        <td runat="server">:
                                        </td>
                                        <td runat="server">
                                            <%--<telerik:RadMaskedTextBox  ID="rmtxt_BusinessUnitFiscalYear"  Skin="WebBlue" 
                                        runat="server" Mask="&lt;1  JAN|2  FEB|3  MAR|4  APR|5  MAY|6  JUN|7  JUL|8  AUG|9  SEP|10 OCT|11 NOV|12 DEC&gt;-&lt;1  JAN|2  FEB|3  MAR|4  APR|5  MAY|6  JUN|7  JUL|8  AUG|9  SEP|10 OCT|11 NOV|12 DEC&gt;"
                                        Style="text-transform: uppercase;" TextWithLiterals="1  JAN-1  JAN" Width="125px"
                                        Text="1  JAN1  JAN">
                                    </telerik:RadMaskedTextBox>--%>
                                            <telerik:RadMaskedTextBox ID="rmtxt_BusinessUnitFiscalYear" Skin="WebBlue" runat="server"
                                                Mask="&lt;1  JAN|2  FEB|3  MAR|4  APR|5  MAY|6  JUN|7  JUL|8  AUG|9  SEP|10 OCT|11 NOV|12 DEC&gt;-&lt;1  JAN|2  FEB|3  MAR|4  APR|5  MAY|6  JUN|7  JUL|8  AUG|9  SEP|10 OCT|11 NOV|12 DEC&gt;"
                                                Style="text-transform: uppercase;" TextWithLiterals="1  JAN-1  JAN" Width="125px"
                                                Visible="false" Text="1  JAN1  JAN" LabelCssClass="" meta:resourceKey="rmtxt_BusinessUnitFiscalYear"
                                                AllowEmptyEnumerations="true">
                                            </telerik:RadMaskedTextBox>
                                        </td>
                                        <td runat="server"></td>
                                    </tr>
                                    <tr id="tr_rmtxt_BusinessUnitCalendarYear" runat="server" visible="false">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessUnitCalendarYear" runat="server" meta:resourceKey="lbl_BusinessUnitCalendarYear" Visible="false"
                                                Text="Calendar Year"></asp:Label>
                                        </td>
                                        <td runat="server">:
                                        </td>
                                        <td runat="server">
                                            <telerik:RadMaskedTextBox ID="rmtxt_BusinessUnitCalendarYear" runat="server" Mask="&lt;1  JAN|2  FEB|3  MAR|4  APR|5  MAY|6  JUN|7  JUL|8  AUG|9  SEP|10 OCT|11 NOV|12 DEC&gt;-&lt;1  JAN|2  FEB|3  MAR|4  APR|5  MAY|6  JUN|7  JUL|8  AUG|9  SEP|10 OCT|11 NOV|12 DEC&gt;"
                                                Skin="WebBlue" Style="text-transform: uppercase;" Text="1  JAN1  JAN" TextWithLiterals="1  JAN-1  JAN" Visible="false"
                                                Width="125px" AllowEmptyEnumerations="true">
                                            </telerik:RadMaskedTextBox>
                                        </td>
                                        <td runat="server"></td>
                                    </tr>
                                    <tr id="tr_rmtxt_BusinessUnitLocalisation" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessunitLocalisation" runat="server" Text="Localisation" meta:resourceKey="lbl_BusinessUnitCalendarYear"></asp:Label>
                                        </td>
                                        <td runat="server"><strong>:</strong>
                                        </td>
                                        <td runat="server">
                                            <telerik:RadComboBox ID="rcmb_Localisation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcmb_Localisation_SelectedIndexChanged"
                                                MarkFirstMatch="true" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Localisation" runat="server" ControlToValidate="rcmb_Localisation"
                                                ErrorMessage="Please Select Localisation" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <%--  <td runat="server">
                                            <asp:RequiredFieldValidator ID="rfv_Localisation" runat="server" ControlToValidate="rcmb_Localisation"
                                                ErrorMessage="Please Select Localisation" InitialValue="Select" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>
                                    <tr id="tr_ABNNo1" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_ABNNo" runat="server" Text="ABN Number" Visible="false"></asp:Label>
                                        </td>
                                        <td>
                                            <strong>:</strong>
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_ABNNumber" runat="server" MaxLength="20" Visible="false">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rtxt_ABNNumber" runat="server" ControlToValidate="rtxt_ABNNumber"
                                                ErrorMessage="Please Enter ABN Number" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="tr_chk_BusinessUnitOverTime" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessUnitOverTime" runat="server" Text="OverTime"></asp:Label>
                                        </td>
                                        <td runat="server"><strong>:</strong>
                                        </td>
                                        <td runat="server">
                                            <asp:CheckBox ID="chk_BusinessUnitOverTime" runat="server" meta:resourceKey="chk_BusinessUnitOverTime" />
                                        </td>
                                        <td runat="server"></td>
                                    </tr>
                                    <tr id="tr_rcmb_BusinessUnitPaymentMode" runat="server">
                                        <td runat="server">
                                            <asp:Label ID="lbl_BusinessUnitPayMentModes" runat="server" meta:resourceKey="lbl_BusinessUnitPayMentModes"
                                                Text="Payment Modes"></asp:Label>
                                        </td>
                                        <td runat="server"><strong>:</strong>
                                        </td>
                                        <td runat="server" rowspan="4">&nbsp;<telerik:RadListBox ID="RLB_BusinessUnitPaymentMode" runat="server" CheckBoxes="true"
                                            Height="100px" Width="200px">
                                        </telerik:RadListBox>
                                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td runat="server">
                                            <%-- <asp:RequiredFieldValidator ID="rfv_rcmb_BusinessUnitPaymentMode" runat="server"
                                        ControlToValidate="rcmb_BusinessUnitPaymentMode" ErrorMessage="Please select a Paymode"
                                        Text="*" ValidationGroup="Controls" meta:resourceKey="rfv_rcmb_BusinessUnitPaymentMode"></asp:RequiredFieldValidator>--%>
                                            <%--<asp:CustomValidator ID="cv_Paymentmodes" runat="server" Text="*" ErrorMessage="Select Atleast One Paymentmode " 
                                        ControlToValidate="RLB_BusinessUnitPaymentMode" ClientValidationFunction="Validate" ValidationGroup="Controls"></asp:CustomValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnitStartDate" runat="server" meta:resourcekey="lbl_BusinessUnitStartDate"
                                                Text="Start Date"></asp:Label>
                                        </td>
                                        <td><strong>:</strong>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_BusinessUnitStartDate" runat="server" meta:resourcekey="rdtp_BusinessUnitStartDate"
                                                Skin="WebBlue">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_BUStartDate" runat="server" ControlToValidate="rdtp_BusinessUnitStartDate"
                                                ErrorMessage="Please Enter Start Date" Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="enddate" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnitEndDate" runat="server" meta:resourcekey="lbl_BusinessUnitEndDate"
                                                Text="End Date"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_BusinessUnitEndDate" runat="server" meta:resourcekey="rdtp_BusinessUnitEndDate"
                                                Skin="WebBlue">
                                            </telerik:RadDatePicker>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:CompareValidator ID="rcv_rdtp_BusinessUnitEndDate" runat="server" ControlToCompare="rdtp_BusinessUnitStartDate"
                                                ControlToValidate="rdtp_BusinessUnitEndDate" ErrorMessage="End Date Cannot be Less than Start Date"
                                                Operator="GreaterThan" ValidationGroup="Controls">*</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="PayType">
                                        <td>
                                            <asp:Label ID="lbl_PayType" runat="server" meta:resourcekey="lbl_PayType"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_PayType" runat="server" LabelCssClass="" MaxLength="15"
                                                meta:resourcekey="rtxt_PayType" Skin="WebBlue" Style="text-transform: capitalize;"
                                                Width="200px" onkeypress="ValidateAlpha();">
                                            </telerik:RadTextBox>
                                            <%--validateR(this, '')" ruleset="[^a-z]" --%>
                                        </td>
                                    </tr>
                                    <tr id="BusinessSuffix" runat="server">
                                        <td>
                                            <asp:Label ID="lbl_BusinessSuffix" runat="server" meta:resourcekey="lbl_BusinessSuffix"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="rtxt_BusinessSuffix" runat="server" LabelCssClass="" MaxLength="4"
                                                meta:resourcekey="rtxt_BusinessUnitDesc" Skin="WebBlue" Style="text-transform: uppercase;"
                                                Width="200px">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr id="supervisor" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnitSupervisor" runat="server" meta:resourcekey="lbl_BusinessUnitSupervisor"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_BusinessUnitSupervisor" runat="server" AutoPostBack="True" Filter="Contains"
                                                MarkFirstMatch="true" meta:resourcekey="rcmb_BusinessUnitSupervisor" Skin="WebBlue">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr id="metro_id" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_metro" runat="server" Visible="false" Text="Metro"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="CB_Ismetro" runat="server" Visible="false" />
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lbl_Value" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <%--  <tr id="Variablepay" runat="server" >
                                        <td>
                                            <asp:Label ID="lbl_VariablePay" runat="server" Text="Is VariablePay"></asp:Label>
                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chk_Isvariablepay" runat="server" />
                                        </td>
                                        <td></td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BasicPercent" runat="server" Text="Basic Percent" Visible="false">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <%--<b>:</b>--%>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntxt_BasicPercent" runat="server" MinValue="0.00" Visible="false"
                                                MaxValue="100.00" MaxLength="3">
                                            </telerik:RadNumericTextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rfv_BasicPercent" Enabled="false" runat="server" Text="*" ControlToValidate="rntxt_BasicPercent"
                                                ValidationGroup="Controls" ErrorMessage="Please Enter Basic Percent">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="trNote" runat="server" visible="false">
                                        <td colspan="4">
                                            <asp:Label ID="lblNote" runat="server" Text="NOTE: Once saved Minimum No. Of Hours checked/unchecked status cannot be changed later"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trChkNoOfHours" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_noofhours" runat="server" Text="Minimum No. Of Hours">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkNoOfHours" runat="server" AutoPostBack="true" OnCheckedChanged="chkNoOfHours_CheckedChanged" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="trNoOfHours" runat="server" visible="false">
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rntxt_noofhours" runat="server" MinValue="0.00" MaxValue="100.00"
                                                Visible="false" MaxLength="4">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_rntxt_noofhours" runat="server" Text="*" ControlToValidate="rntxt_noofhours"
                                                ValidationGroup="Controls" ErrorMessage="Please Enter Minimum No Of Working Hours">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="tr_annual" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_AnnualProcess" runat="server" Visible="false" Text="Annual Process"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chk_AnnualProcess" runat="server" Visible="false" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="status" runat="server" visible="false">
                                        <td>Status</td>
                                        <td>:</td>
                                        <td>
                                            <telerik:RadComboBox ID="Rcm_status" runat="server" AutoPostBack="True" MarkFirstMatch="true"
                                                MaxHeight="200px" Filter="Contains" TabIndex="1">
                                            </telerik:RadComboBox>
                                            &nbsp<asp:RequiredFieldValidator ID="RFV_STATUS" runat="server" ControlToValidate="Rcm_status"
                                                ErrorMessage="Please Enter Status" ValidationGroup="Controls">*</asp:RequiredFieldValidator></td>
                                        <td></td>


                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_UploadImg" runat="server" meta:resourcekey="lbl_UploadImg" Text="Business Unit Logo"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:FileUpload ID="FUpload" runat="server" meta:resourcekey="FUpload" />
                                            <asp:Button ID="btn_Upload" runat="server" Text="Upload Image" OnClick="btn_Upload_Click" />
                                            <%--ValidationGroup="Controls"--%>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RExpession_Upload" runat="Server" ControlToValidate="FUpload"
                                                ErrorMessage="Only .jpg and png files are allowed" Text="*" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png))$"
                                                ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                        <td>
                                            <asp:Image ID="RBI_BU_Image" runat="server" Width="182px" Height="202px" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                        <td>
                                            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%--                                    <tr>
                                        <td colspan="2">
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkPicDelete" runat="server" Text="Delete Picture" OnClick="lnkPicDelete_Click"></asp:LinkButton>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btn_Update" runat="server" CausesValidation="true" meta:resourceKey="btn_Update"
                                                OnClick="btn_Save_Click" OnClientClick="disableButton(this,'Controls')" Text="Update"
                                                UseSubmitBehavior="false" Visible="False" />
                                            <%--OnClientClick="Validate"/>--%>&nbsp;<asp:Button ID="btn_Save" runat="server"
                                                CausesValidation="true" meta:resourceKey="btn_Save" OnClick="btn_Save_Click"
                                                OnClientClick="disableButton(this,'Controls')" Text="Save" UseSubmitBehavior="false"
                                                Visible="False" />
                                            <%--OnClientClick="Validate"/>--%>
                                            &nbsp;
                                            <asp:Button ID="btn_Cancel" runat="server" meta:resourceKey="btn_Cancel" OnClick="btn_Cancel_Click"
                                                Text="Cancel" />
                                            <asp:ValidationSummary ID="vs_BusinessUnit" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="Controls" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">&nbsp;
                                        </td>
                                        <td align="center">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btn_Upload" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>