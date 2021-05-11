<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCTA.aspx.cs" Inherits="normalPageCTA" %>

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
                    <telerik:AjaxUpdatedControl ControlID="chkCTANeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTANeuroNeck"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTABodyAorta"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTABodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTABodyWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTABodyPE"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTABodyRenal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTABodyCoronary"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTABodyLiver"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTAMSKArm"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTAUpperextremiyperipheralrunoff"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTALowerextremiyperipheralrunoff"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="favCTANeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTANeuroNeck"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTABodyAorta"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTABodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTABodyWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTABodyPE"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTABodyRenal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTABodyCoronary"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTABodyLiver"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTAMSKArm"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTAUpperextremiyperipheralrunoff"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTALowerextremiyperipheralrunoff"></telerik:AjaxUpdatedControl>
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
        <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Neuro"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTANeuroBrain"       Text="" Width="5px" style="vertical-align:top;"          Value="XC78"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTANeuroBrain"       Text="CTA Brain"            Value="XC78"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTANeuroNeck"        Text="" Width="5px" style="vertical-align:top;"          Value="XC86"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTANeuroNeck"        Text="CTA Neck"             Value="XC86"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Body"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTABodyChest"        Text="" Width="5px" style="vertical-align:top;"          Value="XC60"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTABodyChest"        Text="CTA Chest"            Value="XC60"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTABodyPE"           Text="" Width="5px" style="vertical-align:top;"          Value="XC62"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTABodyPE"           Text="CTA For PE"           Value="XC62"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTABodyCoronary"     Text="" Width="5px" style="vertical-align:top;"          Value="XC65"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTABodyCoronary"     Text="CTA Coronary Artery"  Value="XC65"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTABodyAorta"        Text="" Width="5px" style="vertical-align:top;"          Value="XC59"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTABodyAorta"        Text="CTA Aorta"            Value="XC59"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
            
            <td>&nbsp;</td>
            
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTABodyWhole"        Text="" Width="5px" style="vertical-align:top;"          Value="XC61"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTABodyWhole"        Text="CTA Whole Aorta"      Value="XC61"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTABodyLiver"        Text="" Width="5px" style="vertical-align:top;"          Value="XC76"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTABodyLiver"        Text="CTA Liver Donor"      Value="XC76"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTABodyRenal"        Text="" Width="5px" style="vertical-align:top;"          Value="XC64"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTABodyRenal"        Text="CTA Renal Artery"     Value="XC64"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                     </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTAUpperextremiyperipheralrunoff"        Text="" Width="5px" style="vertical-align:top;"          Value="XC63"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTAUpperextremiyperipheralrunoff"        Text="CTA Upper extremiy (peripheral run off)"     Value="XC63"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
         <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTALowerextremiyperipheralrunoff"        Text="" Width="5px" style="vertical-align:top;"          Value="XC066"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTALowerextremiyperipheralrunoff"        Text="CTA Lower extremities (peripheral run off)"     Value="XC066"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                     </tr>
                </table>
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label3" runat="server" Text="MSK"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTAMSKArm"           Text="" Width="5px" style="vertical-align:top;"          Value="XC85"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTAMSKArm"           Text="CTA Arm"              Value="XC85"    runat="server"  ButtonType="ToggleButton" GroupName="CTA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
