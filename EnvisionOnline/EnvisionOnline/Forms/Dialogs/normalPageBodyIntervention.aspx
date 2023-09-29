<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageBodyIntervention.aspx.cs" Inherits="normalPageBodyIntervention" %>

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
        }
        .columnBold
        {
        	margin: 0px;
        	background: #4b6c9e;
        	height:20px;
        	width:100px;
            text-align:center;
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
            vertical-align:top;	
        	height:5px;
        	width:100px;
        	text-align:left;
        }
        .favoritStyle
        {
        	height:20px;
        	width:0px;
            vertical-align:top;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
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
            function showNormalAlert(args) {
                switch (args) {
                    case 'checkCanRequest':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4014", "windowOnlineMessageBox");
                        break;
                    case 'AddFavoriteExam':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4009", "windowOnlineMessageBox");
                        break;
                    case 'RemoveExamFavorite':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4017", "windowOnlineMessageBox");
                        break;
                    case 'ShowalertExam':
                        window.radopen("../../Forms/Dialogs/OnlineAlertExam.aspx", "windowAlertExam");
                        break;
                }
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
            function OnClientClose() {
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="False" VisibleStatusbar="false"
        runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="windowOnlineMessageBox" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="400" Height="200" NavigateUrl="~/Forms/Dialogs/OnlineMessageBox.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowAlertExam" runat="server" Behaviors="Close" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="800" Height="430" NavigateUrl="~/Forms/Dialogs/OnlineAlertExam.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="favFNA"/>
                     <telerik:AjaxUpdatedControl ControlID="chkFNA"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
	<div>
        <table width="100%">
            <tr>
                <td align="center" class="header">
                    <asp:Label ID="lblHeard" runat="server" Text="Body Intervention"></asp:Label>
                </td>
            </tr>
            <tr>
                <td >
                    <table width="100%">
                        <tr>
                            <td class="favoritStyle"><telerik:RadButton ID="favFNA"     Text="" Width="5px" style="vertical-align:top;"          Value="XS133"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkFNA"     Text="Fine Needle Aspiration under US guidance"        Value="XS133"    runat="server" ButtonType="ToggleButton" GroupName="groupBodyIntervention" ToggleType="CheckBox" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        </tr>
                    </table>
                </td>
           
            </tr>
        </table>
         <br />
        <telerik:RadToolBar ID="rtoolResult" runat="server" Width="100%" OnButtonClick="rtoolResult_ButtonClick">
            <Items>
                <telerik:RadToolBarButton Value="btnSave" Text="Save" ToolTip="Save" Width="60px"
                    ImageUrl="../../Resources/ICON/saveAndClose.png" ImagePosition="Left" />
                <telerik:RadToolBarButton Value="btnCancel" Text="Cancel" ToolTip="Cancel" Width="60px"
                    ImageUrl="../../Resources/ICON/close3_16.png" ImagePosition="Left" />
            </Items>
        </telerik:RadToolBar>
	</div>
	</form>
</body>
</html>
