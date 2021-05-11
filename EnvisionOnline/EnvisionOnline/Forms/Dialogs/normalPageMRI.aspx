<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageMRI.aspx.cs" Inherits="normalPageMRI" %>

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
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKShoulderL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKShoulderR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKWristL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKWristR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKElbowL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKElbowR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKKneeL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKKneeR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKAnkleL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKAnkleR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKArmL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKArmR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKForArmL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKForArmR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKFemurL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKFemurR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKHandL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKHandR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKFootL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKFootR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKCevical"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKThoracic"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKLumbosaral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKBrachial"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKPelvic"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKArthrography"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKHip"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKCheeck"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKMandible"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMSKThigh"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroThyroid"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroTm"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroMyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroCisternogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuro3DIAC"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroBaseOfSkull"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroCVV"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroHippocampus"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroPituitary"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroCavernous"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroBrachial"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroSRT"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroCervico"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroScreeningSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroSacral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroLS"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroParotid"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroOral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyUpper"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyLower"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyBreast1"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyBreast2"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyProstate"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyAbdomenMRCP"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyMRCP"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyScreeningCoronary"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyProstateEndorectal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyPancreas"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyAdrenal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyKidney"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyPelvic"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRIBodyPyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRINeuroBrainOnly" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRIOropharynx" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRIScreenningSpine" />

                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKShoulderL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKShoulderR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKWristL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKWristR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKElbowL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKElbowR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKKneeL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKKneeR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKAnkleL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKAnkleR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKArmL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKArmR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKForArmL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKForArmR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKFemurL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKFemurR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKHandL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKHandR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKFootL"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKFootR"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKCevical"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKThoracic"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKLumbosaral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKBrachial"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKPelvic"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKArthrography"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKHip"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKCheeck"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKMandible"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKThigh"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroThyroid"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroTm"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroMyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroCisternogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuro3DIAC"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroBaseOfSkull"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroCVV"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroHippocampus"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroPituitary"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroCavernous"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroBrachial"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroSRT"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroCervico"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroScreeningSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroSacral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroLS"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroParotid"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroOral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyUpper"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyLower"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyBreast1"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyBreast2"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyProstate"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyAbdomenMRCP"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyMRCP"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyScreeningCoronary"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyProstateEndorectal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyPancreas"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyAdrenal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyKidney"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyPelvic"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRIBodyPyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRINeuroBrainOnly" />
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKScreenningSpine" />
                    <telerik:AjaxUpdatedControl ControlID="favMRIMSKScreenningSpine" />
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
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Neuro"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroBrainOnly"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM11"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroBrainOnly"           Text="MRI Brain"             Value="XM11"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroPituitary"       Text="" Width="5px" style="vertical-align:top;"                      Value="XXXX"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroPituitary"       Text="MRI Pituitary Gland"              Value="XM59"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuro3DIAC"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM44"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuro3DIAC"           Text="MRI 3D IAC"                       Value="XM44"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroBaseOfSkull"     Text="" Width="5px" style="vertical-align:top;"                      Value="XM56"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroBaseOfSkull"     Text="MRI Base Of Skull"                Value="XM56"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroCVV"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM57"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroCVV"             Text="MRI CN V"                         Value="XM57"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroBrain"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM12"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroBrain"           Text="MRI Brain + CSF Flow"             Value="XM12"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroHippocampus"     Text="" Width="5px" style="vertical-align:top;"                      Value="XM58"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroHippocampus"     Text="MRI Hippocampus"                  Value="XM58"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroCavernous"       Text="" Width="5px" style="vertical-align:top;"                      Value="XXXX"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroCavernous"       Text="MRI Cavernous Sinus"              Value="XM60"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
         <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroSRT"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM71"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroSRT"             Text="MRI SRT Or SRS [Only]"            Value="XM71"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIOropharynx"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM16"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIOropharynx"             Text="MRI Oropharynx"            Value="XM16"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroParotid"         Text="" Width="5px" style="vertical-align:top;"                      Value="XMA1"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroParotid"         Text="MRI Parotid Gland"                Value="XMA1"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroOral"        Text="" Width="5px" style="vertical-align:top;"                      Value="XMA8"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroOral"        Text="MRI Oral Cavity"                  Value="XMA8"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroCisternogram"    Text="" Width="5px" style="vertical-align:top;"                      Value="XM43"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroCisternogram"    Text="MRI Cisternogram"                 Value="XM43"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroThyroid"         Text="" Width="5px" style="vertical-align:top;"                      Value="XM18"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroThyroid"         Text="MRI Thyroid"                      Value="XM18"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroTm"              Text="" Width="5px" style="vertical-align:top;"                      Value="XM28"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroTm"              Text="MRI TM Joint"                     Value="XM28"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroBrachial"        Text="" Width="5px" style="vertical-align:top;"                      Value="XXXX"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroBrachial"        Text="MRI Brachial Plexus [Neuro]"      Value="XM70"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td> 
        </tr>
         <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroScreeningSpine"  Text="" Width="5px" style="vertical-align:top;"                      Value="XM89"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroScreeningSpine"  Text="MRI Screening Spine"              Value="XM89"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroSacral"          Text="" Width="5px" style="vertical-align:top;"                      Value="XM90"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroSacral"          Text="MRI Sacral Plexus"                Value="XM90"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroLS"              Text="" Width="5px" style="vertical-align:top;"                      Value="XM98"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroLS"              Text="MRI LS - Plexus"                  Value="XM98"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroCervico"         Text="" Width="5px" style="vertical-align:top;"                      Value="XM88"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroCervico"         Text="MRI Cervico Medullary Junction"   Value="XM88"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
         <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRINeuroMyelogram"       Text="" Width="5px" style="vertical-align:top;"                      Value="XM42"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRINeuroMyelogram"       Text="MRI Myelogram"                    Value="XM42"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
         <%--BODY--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label3" runat="server" Text="Body"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyChest"        Text="" Width="5px" style="vertical-align:top;"                      Value="XM19"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyChest"        Text="MRI Chest"                        Value="XM19"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyUpper"        Text="" Width="5px" style="vertical-align:top;"                      Value="XM21"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyUpper"        Text="MRI Upper Abdomen"                Value="XM21"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyAbdomenMRCP"      Text="" Width="5px" style="vertical-align:top;"                      Value="XM50"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyAbdomenMRCP"      Text="MRI Upper Abdomen + MRCP"         Value="XM50"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyMRCP"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM51"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyMRCP"             Text="MRCP [Only]"                      Value="XM51"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyPancreas"                 Text="" Width="5px" style="vertical-align:top;"                          Value="XM82"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyPancreas"                 Text="MRI Pancreas"                         Value="XM82"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyAdrenal"                  Text="" Width="5px" style="vertical-align:top;"                  Value="XM83"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyAdrenal"                  Text="MRI Adrenal Gland"            Value="XM83"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyKidney"                   Text="" Width="5px" style="vertical-align:top;"                  Value="XM84"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyKidney"                   Text="MRI Kidney"                   Value="XM84"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyLower"        Text="" Width="5px" style="vertical-align:top;"                      Value="XM22"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyLower"        Text="MRI Lower Abdomen"                Value="XM22"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyWhole"            Text="" Width="5px" style="vertical-align:top;"                  Value="XM23"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyWhole"            Text="MRI Whole Abdomen"            Value="XM23"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyPelvic"                   Text="" Width="5px" style="vertical-align:top;"                  Value="XM85"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyPelvic"                   Text="MRI Pelvic Cavity"            Value="XM85"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyProstateEndorectal"       Text="" Width="5px" style="vertical-align:top;"                          Value="XM72"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyProstateEndorectal"       Text="MRI Prostate Gland + Endorectal Coil" Value="XM72"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyProstate"         Text="" Width="5px" style="vertical-align:top;"                      Value="XM48"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyProstate"         Text="MRI Prostate Gland"               Value="XM48"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyBreast1"          Text="" Width="5px" style="vertical-align:top;"                  Value="XM45"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyBreast1"          Text="MRI Breast [1 ข้าง]"           Value="XM45"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyBreast2"          Text="" Width="5px" style="vertical-align:top;"                  Value="XM46"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyBreast2"          Text="MRI Breast [2 ข้าง]"           Value="XM46"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyScreeningCoronary"        Text="" Width="5px" style="vertical-align:top;"                          Value="XM52"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyScreeningCoronary"        Text="MRI Screening Coronary"               Value="XM52"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIBodyPyelogram"                Text="" Width="5px" style="vertical-align:top;"                  Value="XM87"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIBodyPyelogram"                Text="MRI Pyelogram"                Value="XM87"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--MUSCULOSKELETAL(MSK)--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="MSK"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKShoulderL"         Text="" Width="5px" style="vertical-align:top;"                  Value="XM001"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKShoulderL"         Text="MRI LT. Shoulder"             Value="XM001"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>          
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKShoulderR"         Text="" Width="5px" style="vertical-align:top;"                  Value="XM002"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKShoulderR"         Text="MRI RT. Shoulder"             Value="XM002"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKArmL"              Text="" Width="5px" style="vertical-align:top;"                      Value="XM016"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKArmL"              Text="MRI LT. Arm"                      Value="XM016"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKArmR"              Text="" Width="5px" style="vertical-align:top;"                      Value="XM017"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKArmR"              Text="MRI RT. Arm"                      Value="XM017"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKElbowL"            Text="" Width="5px" style="vertical-align:top;"                  Value="XM007"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKElbowL"            Text="MRI LT. Elbow"                Value="XM007"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKElbowR"            Text="" Width="5px" style="vertical-align:top;"                  Value="XM008"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKElbowR"            Text="MRI RT. Elbow"                Value="XM008"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKForArmL"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM019"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKForArmL"           Text="MRI LT. Forearm"                  Value="XM019"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKForArmR"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM020"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKForArmR"           Text="MRI RT. Forearm"                  Value="XM020"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKWristL"            Text="" Width="5px" style="vertical-align:top;"                  Value="XM004"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKWristL"            Text="MRI LT. Wrist"                Value="XM004"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKWristR"            Text="" Width="5px" style="vertical-align:top;"                  Value="XM005"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKWristR"            Text="MRI RT. Wrist"                Value="XM005"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKHandL"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM028"       runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKHandL"             Text="MRI LT. Hand"                     Value="XM028"       runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKHandR"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM029"       runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKHandR"             Text="MRI RT. Hand"                     Value="XM029"       runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKHip"               Text="" Width="5px" style="vertical-align:top;"                      Value="XM34"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKHip"               Text="MRI Hip"                          Value="XM34"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKPelvic"            Text="" Width="5px" style="vertical-align:top;"                      Value="XM78"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKPelvic"            Text="MRI Pelvic Bone - Ortho"          Value="XM78"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKFemurL"            Text="" Width="5px" style="vertical-align:top;"                      Value="XM022"       runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKFemurL"            Text="MRI LT. Femur"                    Value="XM022"       runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKFemurR"            Text="" Width="5px" style="vertical-align:top;"                      Value="XM023"       runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKFemurR"            Text="MRI RT. Femur"                    Value="XM023"       runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKKneeL"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM010"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKKneeL"             Text="MRI LT. Knee"                     Value="XM010"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKKneeR"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM011"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKKneeR"             Text="MRI RT. Knee"                     Value="XM011"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKAnkleL"            Text="" Width="5px" style="vertical-align:top;"                      Value="XM013"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKAnkleL"            Text="MRI LT. Ankle"                    Value="XM013"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKAnkleR"            Text="" Width="5px" style="vertical-align:top;"                      Value="XM014"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKAnkleR"            Text="MRI RT. Ankle"                    Value="XM014"   runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKFootL"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM031"       runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKFootL"             Text="MRI LT. Foot"                     Value="XM031"       runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKFootR"             Text="" Width="5px" style="vertical-align:top;"                      Value="XM032"       runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKFootR"             Text="MRI RT. Foot"                     Value="XM032"       runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKCevical"           Text="" Width="5px" style="vertical-align:top;"                  Value="XM73"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKCevical"           Text="MRI Cevical Spine - Ortho"    Value="XM73"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKBrachial"          Text="" Width="5px" style="vertical-align:top;"                      Value="XM77"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKBrachial"          Text="MRI Brachial Plesxus - Ortho"     Value="XM77"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKThoracic"          Text="" Width="5px" style="vertical-align:top;"                  Value="XM74"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKThoracic"          Text="MRI Thoracic Spine - Ortho"   Value="XM74"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKLumbosaral"        Text="" Width="5px" style="vertical-align:top;"                      Value="XM75"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKLumbosaral"        Text="MRI Lumbosacral Spine - Ortho"    Value="XM75"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKWhole"             Text="" Width="5px" style="vertical-align:top;"                  Value="XM76"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKWhole"             Text="MRI Whole Spine - Ortho"      Value="XM76"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKThigh"             Text="" Width="5px" style="vertical-align:top;"                      Value="XMA7"        runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKThigh"             Text="MRI Thigh"                        Value="XMA7"        runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
        </tr>
        <tr>
            <td></td>
            
            <td colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKMandible"          Text="" Width="5px" style="vertical-align:top;"                      Value="XM95"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKMandible"          Text="MRI Mandible"                     Value="XM95"    runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKCheeck"            Text="" Width="5px" style="vertical-align:top;"                      Value="XM93"        runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKCheeck"            Text="MRI Cheeck"                       Value="XM93"        runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKArthrography"      Text="" Width="5px" style="vertical-align:top;"                      Value="XM79"        runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKArthrography"      Text="MRI Arthrography"                 Value="XM79"        runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRIMSKScreenningSpine"      Text="" Width="5px" style="vertical-align:top;"                      Value="XM89"        runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMSKScreenningSpine"      Text="MRI Screenning Spine"                 Value="XM89"        runat="server" ButtonType="ToggleButton" GroupName="MRI"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
