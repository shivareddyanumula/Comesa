<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" CodeFile="frm_RatingFeedbackQuestions.aspx.cs" Inherits="HR_TRAINING_frm_RatingFeedbackQuestions" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" runat="Server">



    <table align="center">
        <tr>
            <td>
                <div style="height: 490px; width: 1014px; overflow: auto;">
                    <table align="center">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lbl_AttendanceDteails" runat="server" Text="Rate Feedback Questions"
                                    Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="center">
                                <table>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left">
                                            <asp:Label ID="lblTrainigRequestId" runat="server" Visible="False" meta:resourcekey="lblTrainigRequestId"></asp:Label>
                                            <asp:Label ID="lbl_Type" runat="server" Text="Type" meta:resourcekey="lbl_Type"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rc_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rc_type_SelectedIndexChanged">

                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="Select" Value="Select" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Service Provider" Value="Service Provider" />
                                                    <telerik:RadComboBoxItem runat="server" Text="Trainer" Value="Trainer" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_rc_type" ErrorMessage="Please Select Type" InitialValue="Select" ValidationGroup="Part" ControlToValidate="rc_type">*
                                            </asp:RequiredFieldValidator>


                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left">
                                            <asp:Label ID="Label1" runat="server" Visible="False" meta:resourcekey="lblTrainigRequestId"></asp:Label>
                                            <asp:Label ID="lbl_ServiceProvider" runat="server" Text="Service Provider" meta:resourcekey="lbl_ServiceProvider"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rc_ServiceProvider" runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="rc_ServiceProvider_SelectedIndexChanged" Filter="Contains">
                                            </telerik:RadComboBox>

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfv_ServiceProvider" runat="server" ControlToValidate="rc_ServiceProvider"
                                                meta:resourcekey="rfv_ServiceProvider" ErrorMessage="Please Select Service Provider" InitialValue="Select"
                                                Text="*" ValidationGroup="Controls"></asp:RequiredFieldValidator>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left">
                                            <asp:Label ID="ll_Trainer" runat="server" Text="Trainer" meta:resourcekey="ll_Trainer"></asp:Label>
                                        </td>
                                        <td>:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rc_Trainer" runat="server" Skin="WebBlue" AutoPostBack="true" Filter="Contains">
                                            </telerik:RadComboBox>

                                        </td>
                                        <td></td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td align="left"></td>

                                        <td></td>
                                        <td></td>
                                        <td></td>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RG_TrainingApproval" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    Skin="WebBlue" Visible="false">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="FEEDBACKQUESTION_ID" UniqueName="FEEDBACKQUESTION_ID" HeaderText="ID"
                                                meta:resourcekey="FEEDBACKQUESTION_ID" Visible="False">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="Feedbackquestion_question" UniqueName="Feedbackquestion_question"
                                                HeaderText="Factors" meta:resourcekey="Feedbackquestion_question">
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="1" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1" HeaderText="Rating-1">
                                                <ItemTemplate>
                                                    <input id="rbn_Rate1" type="radio" runat="server" value="1" name="myRadio" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="2" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1" HeaderText="Rating-2">
                                                <ItemTemplate>
                                                    <input id="rbn_Rate2" type="radio" runat="server" value="2" name="myRadio" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="3" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1" HeaderText="Rating-3">
                                                <ItemTemplate>
                                                    <input id="rbn_Rate3" type="radio" runat="server" value="3" name="myRadio" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="4" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1" HeaderText="Rating-4">
                                                <ItemTemplate>
                                                    <input id="rbn_Rate4" type="radio" runat="server" value="4" name="myRadio" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="5" AllowFiltering="false" meta:resourcekey="GridTemplateColumnResource1" HeaderText="Rating-5">
                                                <ItemTemplate>
                                                    <input id="rbn_Rate5" type="radio" runat="server" value="5" name="myRadio" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>



                                        </Columns>

                                    </MasterTableView>
                                    <PagerStyle AlwaysVisible="True" />
                                    <HeaderContextMenu Skin="WebBlue">
                                    </HeaderContextMenu>
                                </telerik:RadGrid>

                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btn_submit" runat="server" Text="Save" Visible="false" OnClick="btn_submit_Click" ValidationGroup="Controls" />
                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Visible="false" OnClick="btn_Cancel_Click" ValidationGroup="Controls" />
                                <asp:ValidationSummary ID="vs_TrainerProf" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Controls" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>