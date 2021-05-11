<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCTV.aspx.cs" Inherits="normalPageCTV" %>

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
                    <telerik:AjaxUpdatedControl ControlID="chkCTVNeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTVNeuroNeck"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTVBodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTVBodyAbdomen"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTVBodyPeripheral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTVMSKArm"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="favCTVNeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTVNeuroNeck"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTVBodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTVBodyAbdomen"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTVBodyPeripheral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTVMSKArm"></telerik:AjaxUpdatedControl>
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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Neuro"></asp:Label></td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTVNeuroBrain"       Text="" Width="5px" style="vertical-align:top;"              Value="XC032"   runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTVNeuroBrain"       Text="CTV Brain"                Value="XC032"   runat="server"  ButtonType="ToggleButton" GroupName="CTV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTVNeuroNeck"        Text="" Width="5px" style="vertical-align:top;"              Value="XC033"   runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTVNeuroNeck"        Text="CTV Neck"                 Value="XC033"   runat="server"  ButtonType="ToggleButton" GroupName="CTV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Body"></asp:Label></td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTVBodyChest"        Text="" Width="5px" style="vertical-align:top;"              Value="XC034"   runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTVBodyChest"        Text="CTV Chest"                Value="XC034"   runat="server"  ButtonType="ToggleButton" GroupName="CTV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTVBodyAbdomen"      Text="" Width="5px" style="vertical-align:top;"              Value="XC035"   runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTVBodyAbdomen"      Text="CTV Abdomen"              Value="XC035"   runat="server"  ButtonType="ToggleButton" GroupName="CTV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle">&nbsp;</td>
            <td  colspan="2">
                <table width="100%">
                    <tr> 
                        <td class="favoritStyle"><telerik:RadButton ID="favCTVBodyPeripheral"   Text="" Width="5px" style="vertical-align:top;"              Value="XC037"   runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTVBodyPeripheral"   Text="CTV Peripheral Run Off"   Value="XC037"   runat="server"  ButtonType="ToggleButton" GroupName="CTV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label3" runat="server" Text="MSK"></asp:Label></td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTVMSKArm"           Text="" Width="5px" style="vertical-align:top;"              Value="XC036"   runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
            <td class="textStyle"><telerik:RadButton    ID="chkCTVMSKArm"           Text="CTV Arm"                  Value="XC036"   runat="server"  ButtonType="ToggleButton" GroupName="CTV"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
