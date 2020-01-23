<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_RecruitmentCost.aspx.cs" Inherits="Recruitment_frm_RecruitmentCost" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntxtRecmntCost" ContentPlaceHolderID="cphDefault" runat="Server">
    <script type="text/javascript">
        function checkExtension(radUpload, eventArgs) {
            var input = eventArgs.get_fileInputField();
            if (!radUpload.isExtensionValid(input.value)) {
                var inputs = radUpload.getFileInputs();
                for (i = 0; inputs.length > i; i++) {
                    if (inputs[i] == input) {
                        alert(input.value + " does not have a valid extension.");
                        radUpload.clearFileInputAt(i);
                        break;
                    }
                }
            }
        }
    </script>
    <table align="center" style="vertical-align: top;">
        <tr>
            <td>
                <telerik:RadWindowManager ID="RWM_RecmntCostMaster" runat="server" Style="z-index: 8000">
                </telerik:RadWindowManager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_RecmntCostMaster" runat="server" Text="Recruitment Cost" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadAjaxManagerProxy ID="RAM_RecmntCostMaster" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="Rg_RecmntCostMaster">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManagerProxy>
                <telerik:RadMultiPage ID="Rm_HDPT_page" runat="server" SelectedIndex="0" Style="z-index: 10"
                    Width="1100px" Height="600px" ScrollBars="Auto">
                    <telerik:RadPageView ID="Rp_DPT_ViewMain" runat="server" Selected="True">
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="Rg_RecmntCost" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        AllowPaging="True" AllowFilteringByColumn="true" Skin="WebBlue" OnNeedDataSource="Rg_RecmntCost_NeedDataSource"
                                        OnItemCommand="Rg_RecmntCost_ItemCommand">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="JOBREQ_REQCODE" UniqueName="JOBREQ_REQCODE"
                                                    AllowFiltering="true" HeaderText="Requisition Name"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="HR_MASTER_CODE" UniqueName="HR_MASTER_CODE"
                                                    AllowFiltering="true" HeaderText="Type of Cost" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridDateTimeColumn DataField="COST_DATE" UniqueName="COST_DATE" FilterControlWidth="100px"
                                                    AllowFiltering="true" HeaderText="Date" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridDateTimeColumn>
                                                <telerik:GridNumericColumn DataField="COST_AMOUNT" UniqueName="COST_AMOUNT" FilterControlWidth="100px"
                                                    AllowFiltering="true" HeaderText="Amount" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridNumericColumn>
                                                <%--<telerik:GridBoundColumn DataField="COST_FILEPATH" UniqueName="COST_FILEPATH"
                                                    AllowFiltering="true" HeaderText="Path" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridAttachmentColumn AttachmentDataField="COST_FILEPATH" AttachmentKeyFields="COST_ID"
                                                    FileNameTextField="COST_FILEPATH" DataTextField="COST_FILEPATH" UniqueName="COST_FILEPATH"
                                                    HeaderText="Download">
                                                </telerik:GridAttachmentColumn>--%>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Download">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtn_download" Text='<%#  Eval("COST_FILEPATH") %>' runat="server"
                                                            OnCommand="lbtn_download_Command" CommandArgument='<%#Eval("COST_FILEPATH") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="ColEdit" meta:resourcekey="ColEdit" AllowFiltering="false"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnk_Edit" runat="server" CommandArgument='<%# Eval("COST_ID") %>'
                                                            meta:resourcekey="lnk_Edit" OnCommand="lnk_Edit_Command">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <CommandItemTemplate>
                                                <div align="right">
                                                    <asp:LinkButton ID="lnk_Add" runat="server" OnCommand="lnk_Add_Command"
                                                        CommandArgument='<%# Eval("COST_ID") %>'
                                                        meta:resourceKey="lnk_Add">Add</asp:LinkButton>
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <PagerStyle AlwaysVisible="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>

                    </telerik:RadPageView>
                    <telerik:RadPageView ID="Rp_Rec_Cost_2" runat="server">
                        <asp:UpdatePanel ID="upnl_Uploadimage" runat="server">
                            <ContentTemplate>
                                <table align="center">
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lbl_RecmntCostID" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_BusinessUnit" runat="server" Text="Business Unit"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="Rcb_BusinessUnit" runat="server" MarkFirstMatch="true" Filter="Contains"
                                                AutoPostBack="True" OnSelectedIndexChanged="Rcb_BusinessUnit_SelectedIndexChanged" MaxHeight="120px">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RFV_BusinessUnit" runat="server" ControlToValidate="Rcb_BusinessUnit"
                                                ErrorMessage="Please Select Business Unit" ValidationGroup="Controls" InitialValue="Select">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_RscReq" runat="server" meta:resourcekey="lbl_RscReq" Text="Resource Requisition"></asp:Label>
                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcmb_RscReq" runat="server" AutoPostBack="True" MarkFirstMatch="true" Skin="WebBlue" MaxHeight="200px" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_RscReq" runat="server" ControlToValidate="rcmb_RscReq" ErrorMessage="Please Select Resource Requisition" InitialValue="Select" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_TypCost" runat="server" Text="Type of Cost"></asp:Label>
                                        </td>
                                        <td>
                                            <b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rad_TypCost" AutoPostBack="True" runat="server" Skin="WebBlue"
                                                EnableEmbeddedSkins="false" MarkFirstMatch="true" MaxHeight="200px" Filter="Contains">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_TypCost" runat="server" ControlToValidate="rad_TypCost"
                                                InitialValue="Select" ErrorMessage="Please Select Type of Cost" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Date" runat="server" Text="Date"></asp:Label>
                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="rdtp_Date" runat="server"
                                                Skin="WebBlue">
                                                <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                    ViewSelectorText="x">
                                                </Calendar>
                                                <DatePopupButton Skin="WebBlue" HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_Date" runat="server" ControlToValidate="rdtp_Date"
                                                ErrorMessage="Please Select Date" Text="*" ValidationGroup="Controls" ForeColor="Red"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Amount" runat="server" Text="Amount"></asp:Label>
                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="rad_Amount" runat="server" Skin="WebBlue" MaxLength="10">
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="req_Amount" runat="server" ControlToValidate="rad_Amount" ErrorMessage="Please Enter Amount" ValidationGroup="Controls">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblUploadImage" Text="Upload" runat="server" />
                                        </td>
                                        <td><b>:</b>
                                        </td>
                                        <td>
                                            <telerik:RadUpload ID="ruImageUpload" runat="server" MaxFileInputsCount="1" AllowedFileExtensions=".pdf,.doc,.docx,.xls,.xlsx"
                                                ControlObjectsVisibility="None" OnClientFileSelected="checkExtension" Skin="Default"
                                                Width="120px">
                                            </telerik:RadUpload>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnImgUpload" runat="server" Text="Upload" OnClick="btnImgUpload_Click" />
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="4">
                                            <asp:Label ID="lblErr" runat="server" Font-Size="X-Small" Text="Note:Select Upload (pdf, doc, docx, xls, xlsx)
                                        File size should be less than 50MB ."
                                                ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                <td>
                                    <asp:Label ID="lbl_UploadImg" runat="server" meta:resourcekey="lbl_UploadImg" Text="Upload"></asp:Label>
                                </td>
                                <td><b>:</b></td>
                                <td>
                                    <telerik:RadTextBox ID="rtbPath" runat="server" Width="180px"></telerik:RadTextBox>
                                    <asp:FileUpload ID="FUpload" runat="server" meta:resourcekey="FUpload" />
                                    <asp:Button ID="btn_Upload" runat="server" Text="Upload Image" OnClick="btn_Upload_Click" />
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RExpession_Upload" runat="Server" ControlToValidate="FUpload"
                                        ErrorMessage="Only .jpg files are allowed" Text="*" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg))$"
                                        ValidationGroup="Controls" />
                                </td>
                            </tr>--%>
                                    <%--<tr>
                                <td colspan="2"></td>
                                <td>
                                    <asp:Image ID="RBI_BU_Image" runat="server" Width="182px" Height="202px" />
                                </td>
                                <td></td>
                            </tr>--%>
                                    <tr>
                                        <td colspan="4" style="text-align: center">
                                            <asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsg"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center">
                                    <tr>
                                        <td align="center" colspan="3">
                                            <br />
                                            <asp:Button ID="BTN_SAVE" runat="server" Text="Save" OnClick="BTN_SAVE_Click" ValidationGroup="Controls" />
                                            <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="BTN_SAVE_Click" ValidationGroup="Controls" />
                                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
                                            <asp:ValidationSummary ID="vsRecmntCost" runat="server" ValidationGroup="Controls" ShowMessageBox="true" ShowSummary="false" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnImgUpload" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>