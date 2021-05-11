<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageFavorit.aspx.cs" Inherits="normalPageFavorit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        body
        {
            margin:0 0 0 0;
            font-family:MS Sans Serif;
        }
         .header
        {
            position: relative;
            margin: 1px;
            padding: 0px;
            background: #4b6c9e;
            color: #f9f9f9;
            font-weight:bold;
            width: 100%;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-TelerikCdn="Disabled">
		<Scripts>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
	  
    </script>
    <telerik:RadCodeBlock ID="blockGrid" runat="server">
        <script type="text/javascript">
            function set_AjaxRequest(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
            function refreshGrid(arg) {
                if (!arg) {
                    set_AjaxRequest("Rebind");
                }
                else {
                    set_AjaxRequest(arg);
                }
            }
            function chkMessageBox(args) {
                set_AjaxRequest(args);
            }
            function RowDblClickAddExam(sender, eventArgs) {
                var grid = sender;
                var keyExamID = eventArgs.getDataKeyValue("EXAM_ID");
                var keyExamUID = eventArgs.getDataKeyValue("EXAM_UID");
                var param;
                switch (grid.ClientID) {
                    case 'grdExamFavorite': param = 'AddExamAll,' + keyExamID + keyExamUID;
                        break;
                }
                set_AjaxRequest(param);
            }

            function onRowDropping(sender, args) {
                if (sender.get_id() == "grdExamFavorite") {
                    var node = args.get_destinationHtmlElement();
                    if (!isChildOf('<%=grdExamFavorite.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }
                else {
                    var node = args.get_destinationHtmlElement();
                    if (!isChildOf('trashCan', node)) {
                        args.set_cancel(true);
                    }
                    else {
                        if (confirm("Are you sure you want to delete this order?"))
                            args.set_destinationHtmlElement('trashCan');
                        else
                            args.set_cancel(true);
                    }
                }
            }
            function isChildOf(parentId, element) {
                while (element) {
                    if (element.id && element.id.indexOf(parentId) > -1) {
                        return true;
                    }
                    element = element.parentNode;
                }
                return false;
            }

        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function showNormalAlert(args) {
                switch (args) {
                    case 'AddFavoriteExam':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4009", "windowOnlineMessageBox");
                        break;
                    case 'RemoveExamFavorite':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4017", "windowOnlineMessageBox");
                        break;
                    case 'checkCanRequest':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4014", "windowOnlineMessageBox");
                        break;
                }
            }
            function OnClientClose() {
            } 
        </script>
    </telerik:RadCodeBlock>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest" >
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdExamFavorite" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdExamFavorite">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdExamFavorite"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="False" VisibleStatusbar="false"
        runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="windowOnlineMessageBox" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="400" Height="200" NavigateUrl="~/Forms/Dialogs/OnlineMessageBox.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
	<div>    
        <asp:Label ID="lblHeard" runat="server" Text="Exam Name" Width="100%" CssClass="header"></asp:Label>
      <telerik:RadGrid ID="grdExamFavorite" runat="server" PageSize="25" Height="488px"
            ShowStatusBar="true" AllowSorting="True" AllowPaging="True" EnableAJAX="true"
            OnNeedDataSource="grdExamFavorite_NeedDataSource"
            OnItemCommand="grdExamFavorite_ItemCommand"
            OnRowDrop="grdExamFavorite_RowDrop">
            <ClientSettings EnableRowHoverStyle="true" AllowRowsDragDrop="true">
                <Selecting AllowRowSelect="true" EnableDragToSelectRows="true"  />
                <ClientEvents OnRowDblClick="RowDblClickAddExam" OnRowDropping="onRowDropping" />
                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="57px" />
            </ClientSettings>
                   
            <MasterTableView TableLayout="Fixed" AutoGenerateColumns="false" ShowHeader="false" 
                DataKeyNames="EXAM_ID" 
                ClientDataKeyNames="EXAM_ID"
                Summary="grdData table">
                <Columns>
                    <telerik:GridButtonColumn CommandName="RemoveExamFavorite" ButtonType="ImageButton" HeaderStyle-BackColor="#4b6c9e"
                        UniqueName="RemoveExamFavorite"
                        ImageUrl="../../Resources/ICON/Actions-remove16.png">
                        <HeaderStyle Width="25px" />
                        <ItemStyle Width="16px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="AddExam" HeaderTooltip="Make Study" HeaderStyle-BackColor="#4b6c9e" ButtonType="ImageButton" UniqueName="colAddExam"
                        ImageUrl="../../Resources/ICON/add2-16.png">
                        <HeaderStyle Width="25px" />
                        <ItemStyle Width="16px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                        UniqueName="colEXAM_UID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <HeaderStyle Width="0px" />
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="REQONL_DISPLAY" HeaderText="Exam Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#4b6c9e" SortExpression="EXAM_NAME"
                        UniqueName="colEXAM_NAME" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <HeaderStyle Width="100%" />
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                        UniqueName="colEXAM_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <HeaderStyle Width="0px" />
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RATE" HeaderText="RATE" SortExpression="RATE"
                        UniqueName="colRATE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <HeaderStyle Width="0px" />
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="MODALITY_ID" SortExpression="MODALITY_ID"
                        UniqueName="colMODALITY_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <HeaderStyle Width="0px" />
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NEED_SCHEDULE" HeaderText="NEED_SCHEDULE" SortExpression="NEED_SCHEDULE"
                        UniqueName="colNEED_SCHEDULE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        <HeaderStyle Width="0px" />
                        <ItemStyle Wrap="true" />
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
            <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
            <FilterMenu EnableTheming="True">
                <CollapseAnimation Duration="200" Type="OutQuint" />
            </FilterMenu>
        </telerik:RadGrid>
     </div>
	</form>
</body>
</html>
