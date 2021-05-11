 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageAllExam.aspx.cs" Inherits="normalPageAllExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline" />
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
        div.combocss .rcbInputCell .rcbInput
        {
          padding-left: 24px !important;
          background-image: url('../../Resources/ICON/viewtree_24.png');
          background-repeat: no-repeat;
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
	    function RowDblClickAddExam(sender, eventArgs) {
	        var grid = sender;
	        var keyExamID = eventArgs.getDataKeyValue("EXAM_ID");
	        var keyExamUID = eventArgs.getDataKeyValue("EXAM_UID");
	        var param;
	        switch (grid.ClientID) {
	            case 'grdExam': param = 'AddExamAll,' + keyExamID + ',' + keyExamUID;
	                break;
	        }
	        set_AjaxRequest(param);
	    }
    </script>
    <telerik:RadCodeBlock ID="blockGrid" runat="server">
        <script type="text/javascript">
            function set_AjaxRequest(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
            function refreshGrid(arg) {
                set_AjaxRequest(arg);
            }
            function chkMessageBox(args) {
                set_AjaxRequest(args);
            }
            function OnClientClose() {
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
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdModality" />
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdModality">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdModality" />
                    <telerik:AjaxUpdatedControl ControlID="cmbSearchExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdExam">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbSearchExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbSearchExam">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbSearchExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1" />
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
        <table>
            <tr>
                <td colspan="1" rowspan="2" valign="top">
                    <asp:Label ID="lblHeard" runat="server" Text="Modality" Width="100%" CssClass="header"></asp:Label>
                    <telerik:RadGrid ID="grdModality" runat="server" PageSize="15" Height="441px" ShowStatusBar="false"
                        AllowSorting="false" AllowPaging="false" EnableAJAX="true" AllowFilteringByColumn="false"  
                        OnNeedDataSource="grdModality_NeedDataSource"
                        OnItemDataBound="grdModality_ItemDataBound"
                        OnSelectedIndexChanged="grdModality_SelectedIndexChanged">
                        <ClientSettings EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                            <Scrolling AllowScroll="True" ScrollHeight="50px" UseStaticHeaders="true" />
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed"
                            ClientDataKeyNames="TYPE_ID" DataKeyNames="TYPE_ID" ShowHeader="false">
                            <Columns>
                                <telerik:GridBoundColumn DataField="TYPE_ID" HeaderText="TYPE_ID" SortExpression="TYPE_ID"
                                    UniqueName="colTYPE_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%" Visible="false">
                                    <ItemStyle Wrap="true"  />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DESCR" HeaderText="Modality NAME" SortExpression="DESCR" HeaderStyle-BackColor="#4b6c9e" HeaderStyle-ForeColor="White"
                                    UniqueName="colDESCR" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="110px" />
                                    <ItemStyle Wrap="true" Width="110px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <FilterMenu EnableTheming="True">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
                <td colspan="1" width="100%">
                    <telerik:RadComboBox ID="cmbSearchExam" runat="server" Width="100%" CssClass="combocss"
                    ShowMoreResultsBox="True" EnableLoadOnDemand="True" AutoPostBack="true"
                    OnItemsRequested="cmbSearchExam_ItemsRequested"
                    OnSelectedIndexChanged="cmbSearchExam_SelectedIndexChanged" 
                    ShowToggleImage="False">
                </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    <asp:Label ID="Label1" runat="server" Text="Exam Name" Width="100%" CssClass="header"></asp:Label>
                    <telerik:RadGrid ID="grdExam" runat="server" PageSize="16" Height="415px" ShowStatusBar="true"
                        AllowSorting="True" AllowPaging="True" EnableAJAX="true" AllowFilteringByColumn="false" 
                        OnNeedDataSource="grdExam_NeedDataSource"
                        OnItemCommand="grdExam_ItemCommand"
                        OnItemDataBound="grdExam_ItemDataBound">
                        <ClientSettings EnableRowHoverStyle="true">
                            <Scrolling AllowScroll="true" UseStaticHeaders="true"/>
                            <ClientEvents OnRowDblClick="RowDblClickAddExam" />
                        </ClientSettings>
                        <MasterTableView TableLayout="Fixed" AutoGenerateColumns="false"
                            ClientDataKeyNames="EXAM_ID" ShowHeader="false">
                            <Columns>
                                <telerik:GridButtonColumn CommandName="AddFavoriteExam" ButtonType="ImageButton" HeaderStyle-BackColor="#4b6c9e"
                                    UniqueName="AddFavoriteExam" ImageUrl="../../Resources/ICON/favorite_gray.png">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="AddExam" HeaderTooltip="Make Study" ButtonType="ImageButton" UniqueName="colAddExam" HeaderStyle-BackColor="#4b6c9e"
                                    ImageUrl="../../Resources/ICON/add2-16.png">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle Width="16px" />
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                                    UniqueName="colEXAM_UID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false"  FilterControlWidth="100%">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REQONL_DISPLAY" HeaderText="Exam Name" SortExpression="EXAM_NAME" HeaderStyle-BackColor="#4b6c9e" HeaderStyle-ForeColor="White"
                                    UniqueName="colEXAM_NAME" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false" FilterControlWidth="100%">
                                    <HeaderStyle Width="100%" />
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                                    UniqueName="colEXAM_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RATE" HeaderText="RATE" SortExpression="RATE"
                                    UniqueName="colRATE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="MODALITY_ID" SortExpression="MODALITY_ID"
                                    UniqueName="colMODALITY_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NEED_SCHEDULE" HeaderText="NEED_SCHEDULE" SortExpression="NEED_SCHEDULE"
                                    UniqueName="colNEED_SCHEDULE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                    <ItemStyle Wrap="true" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
                        <FilterMenu EnableTheming="True">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
	</div>
	</form>
</body>
</html>
