<%@ Page Title="" Language="C#" MasterPageFile="~/SMHRMaster.master" AutoEventWireup="true" 
    CodeFile="frm_CourseCalendar.aspx.cs" Inherits="Training_frm_CourseCalendar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Reference Control="AppointmentToolTip.ascx" %>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphDefault" Runat="Server">
  <table>
    <tr>
      <td align ="center" >
        <%--<telerik:RadPane runat="Server" ID="rightPane" Scrolling="None" Width="490px" >

        <telerik:RadScheduler ID="rs" runat ="server"  DataKeyField="ID" DataSubjectField="Description" 
        DataStartField="Start" DataEndField="End"  Height="300px" Width ="551px" Skin="Office2007">
        </telerik:RadScheduler>
        </telerik:RadPane> --%>
        <script type="text/javascript">
            //<![CDATA[

            function hideActiveToolTip() {
            
                var controller = Telerik.Web.UI.RadToolTipController.getInstance();
                var tooltip = controller.get_activeToolTip();
                if (tooltip)
                {
                    tooltip.hide(); 
                }
            }
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler);
            function beginRequestHandler(sender, args) {
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                if (args.get_postBackElement().id.indexOf('RadScheduler1') != -1) {
                    hideActiveToolTip();
                }
            }

            function clientBeforeShow(sender, eventArgs) {
                w = $telerik.$(window).width() / 2;
                h = $telerik.$(window).height() / 2;

                if ((sender._mouseX > w) && (sender._mouseY > h)) {
                    sender.set_position(Telerik.Web.UI.ToolTipPosition.TopLeft);
                    return;
                }
                if ((sender._mouseX < w) && (sender._mouseY > h)) {
                    sender.set_position(Telerik.Web.UI.ToolTipPosition.TopRight);
                    return;
                }
                if ((sender._mouseX > w) && (sender._mouseY < h)) {
                    sender.set_position(Telerik.Web.UI.ToolTipPosition.BottomLeft);
                    return;
                }
                sender.set_position(Telerik.Web.UI.ToolTipPosition.BottomRight);
            }
            //]]>
        </script>


  <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
  <ContentTemplate>

 <%-- <asp:Panel ID="Panel1" runat="server" Width="60%" name="pnl_Schd" ScrollBars="Auto">--%>
     <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="Tr_Name"
                           DataKeyField="Tr_Id" DataStartField="Tr_Name" DataSubjectField="Tr_Name"
                           DayEndTime="18:00:00" DayStartTime="08:00:00" TimeZoneOffset="03:00:00" Width="100%" 
                           DisplayDeleteConfirmation="false" >

        <AdvancedForm Modal="true" />
                    <TimelineView UserSelectable="false" />
         <TimeSlotContextMenuSettings EnableDefault="true" />
         <AppointmentContextMenuSettings EnableDefault="true" /> 

     </telerik:RadScheduler>
      <telerik:RadToolTipManager runat="server" ID="RadToolTipManager1" Width="320" Height="210"
                    Animation="None" HideEvent="LeaveToolTip" Text="Loading..." RelativeTo="Element"
                    OnAjaxUpdate="RadToolTipManager1_AjaxUpdate" OnClientBeforeShow="clientBeforeShow" EnableShadow="true"
                    />
            </ContentTemplate>
        </asp:UpdatePanel>

   <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
     <AjaxSettings>
       <telerik:AjaxSetting AjaxControlID="RadScheduler1">
        <UpdatedControls>
          <telerik:AjaxUpdatedControl ControlID="RadScheduler1" />
        </UpdatedControls>
       </telerik:AjaxSetting>
     </AjaxSettings>
    </telerik:RadAjaxManager>--%>
<%--  </asp:Panel>--%>
       

</td>
</tr> 
 </table>
</asp:Content>

