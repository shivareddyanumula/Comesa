<%--<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true"
    CodeFile="frm_leaveopeningbalances.aspx.cs" Inherits="Payroll_frm_leaveopeningbalances"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphDefault" runat="Server">--%>
   <%-- <telerik:RadScriptBlock ID="rsbScripts" runat="server">

        <script language="javascript" type="text/javascript">
        
         function confirmationSave()
        {
            if (confirm("Are You Sure to Save the Record?"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
           </script>

    </telerik:RadScriptBlock>--%>
   <%-- <telerik:RadAjaxManagerProxy ID="RAM_LOB" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rg_LOB">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_Edit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Cancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Submit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_BUID">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcmb_Period">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RAL_Panel_Main_c" LoadingPanelID="RAL_Panel_Main" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    
    <table align="center" style="vertical-align: top;">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="lbl_Emplob" runat="server" Font-Bold="True" meta:resourcekey="lbl_Emplob"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbl_Period" runat="server" Font-Bold="True" meta:resourcekey="lbl_Period"></asp:Label>
            </td>
            <td align="center" style="margin-left: 80px">
                <telerik:RadComboBox  ID="rcmb_Period" runat="server"  Skin="WebBlue" 
                    meta:resourcekey="rcmb_PeriodResource1">
                </telerik:RadComboBox>
            </td>
            <td align="center">
                <asp:Label ID="lbl_BUID" runat="server" Font-Bold="True" meta:resourcekey="lbl_BUID"></asp:Label>
            </td>
            <td align="center" style="margin-left: 40px">
                <telerik:RadComboBox  ID="rcmb_BUID" runat="server"  Skin="WebBlue"  meta:resourcekey="rcmb_BUIDResource1"
                    AutoPostBack="True" OnSelectedIndexChanged="rcmb_BUID_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <telerik:RadGrid  ID="Rg_LOB" runat="server" AutoGenerateColumns="False"  Skin="WebBlue" 
                    AllowPaging="True" OnNeedDataSource="Rg_LOB_NeedDataSource" GridLines="None">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridNumericColumn UniqueName="column">
                            </telerik:GridNumericColumn>
                        </Columns>
                    </MasterTableView>
                    <HeaderContextMenu  Skin="WebBlue" >
                    </HeaderContextMenu>
                    <PagerStyle AlwaysVisible="True" />
                    <FilterMenu  Skin="WebBlue" >
                    </FilterMenu>
                </telerik:RadGrid>
                <%--<telerik:RadGrid  ID="Rg_LOB" runat="server"  Skin="WebBlue"  
                    AutoGenerateColumns="False" AllowPaging="True" GridLines="None">
                    <MasterTableView> 
                        
                    </MasterTableView>
                    
                    
                    <%--                    
                    <HeaderContextMenu  Skin="WebBlue" >
                    </HeaderContextMenu>
                    -- %>                    <%--<MasterTableView>
                    <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>

                    <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>

                    <EditFormSettings>
                    <EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif" CancelImageUrl="Cancel.gif"></EditColumn>
                    </EditFormSettings>
                    </MasterTableView>-- %>
                    <%--                    <MasterTableView EditMode="InPlace">
                        <Columns>
                        </Columns>
                    </MasterTableView>
                    <FilterMenu  Skin="WebBlue" >
                    </FilterMenu>
                    -- %><HeaderContextMenu  Skin="WebBlue" ></HeaderContextMenu>

<MasterTableView>
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<EditFormSettings>
<EditColumn InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif" EditImageUrl="Edit.gif" CancelImageUrl="Cancel.gif"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu  Skin="WebBlue" ></FilterMenu>
                </telerik:RadGrid>
                --%>
            <%--</td>
        </tr>
        <tr> 
           <td>
                <asp:Button ID="btn_Update" runat="server" meta:resourcekey="btn_Update"
                    OnClick="btn_Update_Click" Visible="False" />
            </td>
            <td>
                <asp:Button ID="btn_Finalise" runat="server" Enabled="False" meta:resourcekey="btn_Finalise"
                    onclick="btn_Finalise_Click" />
            </td>
            <td>
                <asp:Button ID="btn_Submit" runat="server" meta:resourcekey="btn_Submit"  
                    OnClick="btn_Submit_Click" Visible="False" />
            </td>
            </tr>
           
        
        </table>--%>--%>
<%--</asp:Content>
--%>