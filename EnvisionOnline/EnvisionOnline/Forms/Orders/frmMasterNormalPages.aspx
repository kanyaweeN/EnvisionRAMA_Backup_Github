<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMasterNormalPages.aspx.cs" Inherits="frmMasterNormalPages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Common Exam</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
     <style type="text/css">
        body
        {
            margin:0 0 0 0;
            font-family:MS Sans Serif;
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
    <telerik:RadCodeBlock ID="timerRefresh" runat="server">
        <script type="text/javascript">
            
        </script>
    </telerik:RadCodeBlock>
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
            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();

            }
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)
                return oWindow;
            }
            function SetTab(sTabText) {
                window.setTimeout(function () {
                    var tab = $find("tabMain").findTabByValue(sTabText);
                    if (tab != null) {
                        tab.set_selected(true);
                    }
                }, 100);
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function showNormalAlert(args) {
                switch (args) {
                    case 'ExamConflict':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4005", "windowOnlineMessageBox");
                        break;
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
    <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1">
    </telerik:RadAjaxLoadingPanel>
	<telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" EnablePageHeadUpdate="true" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Timer1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtResult" />
                    </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="tabMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tabMain" />
                    <telerik:AjaxUpdatedControl ControlID="tabFavorite" />
                    <telerik:AjaxUpdatedControl ControlID="tabCR" />
                    <telerik:AjaxUpdatedControl ControlID="tabUS" />
                    <telerik:AjaxUpdatedControl ControlID="tabCT" />
                    <telerik:AjaxUpdatedControl ControlID="tabMR" />
                    <telerik:AjaxUpdatedControl ControlID="tabFLU" />
                    <telerik:AjaxUpdatedControl ControlID="tabMAMMO" />
                    <telerik:AjaxUpdatedControl ControlID="tabAllExam" />
                    <telerik:AjaxUpdatedControl ControlID="multipageMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="tabFavorite">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tabFavorite"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="viewFavoriteExam" LoadingPanelID="LoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbSearchExam">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbSearchExam" />
                    <telerik:AjaxUpdatedControl ControlID="tabMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="multipageMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbSearchExam" />
                    <telerik:AjaxUpdatedControl ControlID="multipageMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
	<div>
        <telerik:RadTabStrip ID="tabMain" runat="server" MultiPageID="multipageMain" AutoPostBack="true">
            <Tabs>
                <telerik:RadTab Value="tabBlank"    Text=" " Visible="false"></telerik:RadTab>
                <telerik:RadTab Value="tabFavorite" Text="Favorite" ImageUrl="../../Resources/ICON/favorite.png"></telerik:RadTab>
                <telerik:RadTab Value="tabCR"       Text="Plain Film" ImageUrl="../../Resources/ICON/CR16.jpg"></telerik:RadTab>
                <telerik:RadTab Value="tabUS"       Text="Ultrasonography" ImageUrl="../../Resources/ICON/US_2_16.jpg"></telerik:RadTab>
                <telerik:RadTab Value="tabCT"       Text="CT" ImageUrl="../../Resources/ICON/CT16.jpg"></telerik:RadTab>
                <telerik:RadTab Value="tabMR"       Text="MR" ImageUrl="../../Resources/ICON/MR16.jpg"></telerik:RadTab>
                <telerik:RadTab Value="tabFLU"      Text="Fluorography" ImageUrl="../../Resources/ICON/CR16.jpg"></telerik:RadTab>
                <telerik:RadTab Value="tabMAMMO"    Text="Mammography" ImageUrl="../../Resources/ICON/Mammo16.jpg"></telerik:RadTab>
                <telerik:RadTab Value="tabAllExam"  Text="AllExam" ImageUrl="../../Resources/ICON/browse_16.png"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="multipageMain" runat="server" SelectedIndex="0" ScrollBars="Hidden">
            <telerik:RadPageView ID="viewBlank" runat="server"></telerik:RadPageView>
            <telerik:RadPageView ID="viewFavoriteExam"  runat="server" Height="490" ContentUrl="~/Forms/Dialogs/normalPageFavorit.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewGeneral"       runat="server" Height="490" ContentUrl="~/Forms/Dialogs/normalPagePlainFilm.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewUS"            runat="server" Height="490" ContentUrl="~/Forms/Dialogs/normalPageUS.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewCT"            runat="server" Height="490" ContentUrl="~/Forms/Dialogs/normalPageMutiCT.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewMR"            runat="server" Height="490" ContentUrl="~/Forms/Dialogs/normalPageMutiMR.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewFLU"           runat="server" Height="490" ContentUrl="~/Forms/Dialogs/normalPageFLU.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewMammo"         runat="server" Height="490" ContentUrl="~/Forms/Dialogs/normalPageMammo.aspx"></telerik:RadPageView>
            <telerik:RadPageView ID="viewAllExam"       runat="server" Height="490" ContentUrl="~/Forms/Dialogs/normalPageAllExam.aspx"></telerik:RadPageView>
        </telerik:RadMultiPage>
	</div>
        <telerik:RadToolBar ID="rtoolResult" runat="server" Width="100%" OnButtonClick="rtoolResult_ButtonClick">
            <Items>
                <telerik:RadToolBarButton Value="btnSave" Text="Save" ToolTip="Save" Width="60px" ImageUrl="../../Resources/ICON/saveAndClose.png" ImagePosition="Left" />
                <telerik:RadToolBarButton Value="btnCancel" Text="Cancel" ToolTip="Cancel" Width="60px" ImageUrl="../../Resources/ICON/close3_16.png" ImagePosition="Left" />
                <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="groupResult" BorderStyle="None" CommandName="txtGP">
                    <ItemTemplate>
                        <telerik:RadTextBox ID="txtResult" runat="server" 
                        BackColor="Transparent" BorderColor="Transparent" AutoPostBack="true"
                        ReadOnly="true" Enabled="true"
                        Text="" 
                        Width="500px" />
                    </ItemTemplate>
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" Enabled="true">
            </asp:Timer>
        </asp:Panel>
	</form>
</body>
</html>
