<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageMRV.aspx.cs" Inherits="normalPageMRV" %>

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
        .tabBGHover
        {
        	background: #00CCFF;
        }
        .tabBG1
        {
        	background: #006633;
        }
        .tabBG2
        {
        	background: #00CC00;
        }
        .tabPlainExam
        {
        	margin: 0px;
        	background: #505050;
        	height:50px;
        	width:150px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :larger;
        }
        .columnBold
        {
        	margin: 0px;
        	background: #4b6c9e;
        	height:25px;
        	width:110px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:25px;
        	width:120px;
            vertical-align:top;
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
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-TelerikCdn="Disabled">
		<Scripts>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript">
		//Put your JavaScript code here.
    </script>
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function set_AjaxRequest(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
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
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">    
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkMRVNeuro"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRVBodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRVBodyUpper"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRVBodyLower"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="favMRVNeuro"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRVBodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRVBodyUpper"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRVBodyLower"></telerik:AjaxUpdatedControl>
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
            <telerik:RadWindow ID="windowAlertExam" runat="server" Behaviors="Close" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="800" Height="430" NavigateUrl="~/Forms/Dialogs/OnlineAlertExam.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
	<div>
    <table width="100%">
    <%--NEURO--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Neuro"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRVNeuro"            Text="" Width="5px" style="vertical-align:top;"          Value="XM38"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRVNeuro"            Text="MRV Brain"            Value="XM38"   runat="server"   ButtonType="ToggleButton" GroupName="MRV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Body"></asp:Label></td>
            <td colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRVBodyChest"        Text="" Width="5px" style="vertical-align:top;"          Value="XM67"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRVBodyChest"        Text="MRV Chest"            Value="XM67"   runat="server"   ButtonType="ToggleButton" GroupName="MRV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>       
            
        </tr>
    <%--BODY--%>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRVBodyUpper"        Text="" Width="5px" style="vertical-align:top;"          Value="XM68"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRVBodyUpper"        Text="MRV Upper Abdomen"    Value="XM68"   runat="server"   ButtonType="ToggleButton" GroupName="MRV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>     
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                         <td class="favoritStyle"><telerik:RadButton ID="favMRVBodyLower"        Text="" Width="5px" style="vertical-align:top;"          Value="XM69"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
            <td class="textStyle"><telerik:RadButton    ID="chkMRVBodyLower"        Text="MRV Lower Abdomen"    Value="XM69"   runat="server"   ButtonType="ToggleButton" GroupName="MRV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
