<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_Kraform.aspx.cs" Inherits="PMS_frm_KRA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../smhr.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript">
        function ShowPastDataPop() {
            var win = window.radopen('../Approval/frm_PastInspections.aspx', "rwPastInspectionData");
            win.set_height("500");
            win.set_width("800");
            win.center();
            win.set_modal(true);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Close);

        }
    </script>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lbl_KRA" runat="server" Text="Key Result Area" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="RM_kraform" runat="server" meta:resourcekey="RM_kraformResource1">
                    <telerik:RadPageView ID="RP_kraform" runat="server" meta:resourcekey="RP_kraformResource1">
                        <table align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RG_kraform" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        PageSize="5" Skin="WebBlue" GridLines="None" AllowFilteringByColumn="True" OnNeedDataSource="RG_kraform_NeedDataSource"
                                        meta:resourcekey="RG_kraformResource1" Width="900px">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="Business Unit" DataField="BUSINESSUNIT_CODE"
                                                    Visible="true">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn HeaderText="KRA ID" DataField="KRA_KRAID" UniqueName="column11"
                                                    meta:resourcekey="GridBoundColumnResource11">
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn HeaderText="KRA Name" DataField="KRA_NAME" UniqueName="column"
                                                    meta:resourcekey="GridBoundColumnResource1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Description" DataField="KRA_DESCRIPTION" UniqueName="column1"
                                                    meta:resourcekey="GridBoundColumnResource2">
                                                </telerik:GridBoundColumn>
                                                <%-- <telerik:GridBoundColumn HeaderText="Measure" DataField="KRA_MEASURE" UniqueName="column2"
                                                    meta:resourcekey="GridBoundColumnResource3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Measure" UniqueName="column_measure" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <telerik:RadTextBox ID="txt_measure" runat="server" Enabled="false" TextMode="MultiLine"
                                                            Text='<%# Eval("KRA_MEASURE") %>'>
                                                        </telerik:RadTextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <%-- <telerik:GridBoundColumn HeaderText="Weightage" DataField="KRA_WEIGHTAGE">
                                                </telerik:GridBoundColumn>--%>
                                                <telerik:GridBoundColumn HeaderText="Status" DataField="KRA_STATUS" UniqueName="KRA_STATUS"
                                                    meta:resourcekey="GridBoundColumnResource3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" OnCommand="lnk_Edit_Commnad" CommandArgument='<%# Eval("KRA_ID") %>'
                                                            meta:resourcekey="lnk_EditResource1">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_ADD" runat="server" OnCommand="lnk_Add_Command" Text="Add"></asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                            <PagerStyle AlwaysVisible="true" />
                                        </MasterTableView>
                                        <GroupingSettings CaseSensitive="false" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RP_kraformview2" runat="server" Width="100%" meta:resourcekey="RP_kraformview2Resource1">
                        <table align="center">
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Label ID="lbl_KRAdet" runat="server" Text="Details" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lbl_BusinessUnit" runat="server" meta:resourcekey="lbl_BusinessUnit"
                                        Text="Business&nbsp;Unit"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadComboBox ID="rcmb_BUI" runat="server" Width="150px" MarkFirstMatch="true" Filter="Contains">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_rcmb_BUI" runat="server" ControlToValidate="rcmb_BUI"
                                        ErrorMessage="Business Unit is Mandatory" ValidationGroup="CONTROLS" InitialValue="Select">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="left">
                                    <asp:Label ID="lbl_KraID" runat="server" Text="KRA&nbsp;ID"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="rtxt_KRAID" runat="server" LabelCssClass="" MaxLength="20">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RFV_rtxt_KRAID" runat="server" ControlToValidate="rtxt_KRAID"
                                        ErrorMessage="Please Enter KRA ID" ValidationGroup="CONTROLS">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_id" runat="server" Text="[lbl_id]" Visible="False" meta:resourcekey="lbl_idResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small"></asp:Label>
                                    <asp:Label ID="lbl_kraname" runat="server" Text="KRA Name" Style="text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: small;"
                                        meta:resourcekey="lbl_kranameResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_kraname" runat="server" MaxLength="1000" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_kraname"
                                        ErrorMessage="Please Enter KRA Name" Text="*" ValidationGroup="CONTROLS"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_description" runat="server" Text="Description" Style="text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: small;"
                                        meta:resourcekey="lbl_descriptionResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" MaxLength="1000"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_description"
                                        ErrorMessage="Please Enter Description" Text="*" ValidationGroup="CONTROLS"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <div id="divActive" runat="server" visible="false">
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblIsActive" runat="server" Text="Inactive" Style="text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: small;"
                                            meta:resourcekey="lblIsActiveResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <b>:</b>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkActive" runat="server" />
                                    </td>
                                    <td></td>
                                </tr>
                            </div>
                            <%--<tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lbl_Measure" runat="server" Text="Measure" Style="text-align: right;
                                        font-family: Arial, Helvetica, sans-serif; font-size: small;" meta:resourcekey="lbl_MeasureResource1"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Measure" runat="server" TextMode="MultiLine" MaxLength="1000"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Measure"
                                        Text="*" ControlToValidate="txt_Measure" ValidationGroup="CONTROLS"></asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <%-- <tr>
                                <td>
                                    <asp:Label ID="lbl_Weightage" runat="server" Text="Weightage"></asp:Label>
                                </td>
                                <td>
                                    <b>:</b>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="RNT_KraWeightage" runat="server" 
                                        MaxLength="1"  >
                                    </telerik:RadNumericTextBox>
                                    <td>
                                    MaxWeightage
                                     <asp:Label ID="lbl_max_weightage" runat="server" Visible="false"></asp:Label></td>
                                </td>
                                <td>
                               
                                    <asp:RequiredFieldValidator ID="rfv_kraweightage" runat="server" ControlToValidate="RNT_KraWeightage"
                                        ErrorMessage="Please Enter Weightage " SetFocusOnError="True" Text="*" ValidationGroup="CONTROLS"></asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btn_SAVE" runat="server" Text="Save" OnClick="btn_SAVE_Click1" meta:resourcekey="btn_SAVEResource1"
                                        Style="font-family: Arial, Helvetica, sans-serif; font-size: small" OnClientClick="disableButton(this,'CONTROLS')"
                                        UseSubmitBehavior="false" />&nbsp;
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"
                                        ValidationGroup="CONTROLS" meta:resourcekey="btn_UpdateResource1" Style="font-family: Arial, Helvetica, sans-serif; font-size: small" />&nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click"
                                        meta:resourcekey="btn_CancelResource1" Style="font-family: Arial, Helvetica, sans-serif; font-size: small" />
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="pnlAddObj" runat="server" Visible="false">
                            <table align="center">
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Label ID="lbl_Objectives" runat="server" Text="Objectives" Style="text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: small;"
                                            meta:resourcekey="lbl_ObjectivesResource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl" runat="server" Text="<b>:</b>"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txt_Objectives" runat="server" MaxLength="50"
                                            Width="200px">
                                        </telerik:RadTextBox>
                                        <asp:Button ID="btn_AddObjectives" runat="server" Text="Add" OnCommand="btn_AddObjectives_Command" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <telerik:RadMultiPage ID="rmpKraObj" runat="server" meta:resourcekey="rmpKraObjResource1">
                                            <telerik:RadPageView ID="rpKraObj" runat="server" meta:resourcekey="rpKraObjResource1">
                                                <table align="center">
                                                    <tr>
                                                        <td colspan="4">
                                                            <telerik:RadGrid ID="rgKraObj" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                                PageSize="5" Skin="WebBlue" GridLines="None" AllowFilteringByColumn="false" OnNeedDataSource="rgKraObj_NeedDataSource"
                                                                meta:resourcekey="rgKraObjResource1" Width="900px" OnItemDataBound="rgKraObj_ItemDataBound">
                                                                <MasterTableView CommandItemDisplay="None">
                                                                    <Columns>
                                                                        <telerik:GridBoundColumn HeaderText="Objective ID" DataField="KRA_OBJ_ID" UniqueName="KRA_OBJ_ID"
                                                                            meta:resourcekey="GridBoundColumnResource3" Visible="false">
                                                                        </telerik:GridBoundColumn>
                                                                        <%--<telerik:GridBoundColumn HeaderText="Objective Name" DataField="KRA_OBJ_NAME" UniqueName="KRA_OBJ_NAME"
                                                                            meta:resourcekey="GridBoundColumnResource3">
                                                                        </telerik:GridBoundColumn>--%>

                                                                        <telerik:GridTemplateColumn HeaderText="Objective" UniqueName="Edit_New" AllowFiltering="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblObjId" runat="server" Text='<%#Eval("KRA_OBJ_ID") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblObj" runat="server" Text='<%#Eval("KRA_OBJ_NAME") %>'></asp:Label>
                                                                                <telerik:RadTextBox ID="rtxtObjNameNew" Value='<%#Eval("KRA_OBJ_NAME") %>' runat="server"
                                                                                    Skin="WebBlue" MaxLength="50" Visible="false">
                                                                                </telerik:RadTextBox>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource1">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkBtnEditNew" runat="server" CommandName="lnkBtnNewEdit" OnCommand="lnkBtnEditNew_Command" CommandArgument='<%# Eval("KRA_OBJ_ID") %>'
                                                                                    meta:resourcekey="lnkBtnEditNew_ObjResource1">Edit New</asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkBtnUpdateNew" runat="server" CommandName="lnkBtnUpdateNew" OnCommand="lnkBtnUpdateNew_Command" CommandArgument='<%# Eval("KRA_OBJ_ID") %>'
                                                                                    meta:resourcekey="lnkBtnUpdateNew_ObjResource1" Visible="false">Update New</asp:LinkButton>
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:LinkButton ID="lnkBtnCancelNew" runat="server" CommandName="lnkBtnCancelNew" OnCommand="lnkBtnCancelNew_Command"
                                                                                    meta:resourcekey="lnkBtnCancelNew_ObjResource1" Visible="false">Cancel New</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>

                                                                        <telerik:GridBoundColumn HeaderText="Status" DataField="OBJ_STATUS" UniqueName="OBJ_STATUS"
                                                                            meta:resourcekey="GridBoundColumnResource3">
                                                                        </telerik:GridBoundColumn>
                                                                        <%--<telerik:GridTemplateColumn AllowFiltering="false" UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource1">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkBtnEdit" runat="server" CommandName="lnkBtnEdit" OnCommand="lnkBtnEdit_Command" CommandArgument='<%# Eval("KRA_OBJ_ID") %>'
                                                                                    meta:resourcekey="lnk_Del_Kra_ObjResource1">Edit Record</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                        <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TemplateColumn" meta:resourcekey="GridTemplateColumnResource1">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnk_Del_Kra_Obj" runat="server" OnCommand="lnk_Del_Kra_Obj_Command" CommandArgument='<%# Eval("KRA_OBJ_ID") %>'
                                                                                    CommandName="Inactive" meta:resourcekey="lnk_Del_Kra_ObjResource1">Set Inactive</asp:LinkButton>
                                                                                <asp:LinkButton ID="lnk_Cancel_Kra_Obj" runat="server" OnCommand="lnk_Del_Kra_Obj_Command" CommandArgument='<%# Eval("KRA_OBJ_ID") %>'
                                                                                    CommandName="CancelKraObj" meta:resourcekey="lnk_Cancel_Kra_ObjResource1">Set Active</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                    </Columns>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpKraObj2" runat="server" Width="100%" meta:resourcekey="rpKraObj2Resource1">
                                                <table align="center">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblKraObjName" runat="server" Text="Objective Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <b>:</b>
                                                        </td>
                                                        <td>
                                                            <telerik:RadTextBox ID="rtbKraObjName" runat="server" Width="180px"></telerik:RadTextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblIsActiveKraObj" runat="server" Text="Inactive" Visible="false"></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:CheckBox ID="chkBoxIsActive" runat="server" Visible="false" />
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2">
                                                            <asp:Button ID="btnKraObjUpdate" runat="server" Text="Update Record" OnClick="btnKraObjUpdate_Click" />
                                                            <asp:Button ID="btnKraObjCancel" runat="server" Text="Back" OnClick="btnKraObjCancel_Click" />
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:ValidationSummary ID="vs_KRASummary" runat="server" ValidationGroup="CONTROLS"
                            ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vs_KRASummaryResource1" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>