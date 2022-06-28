<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCTMain.aspx.cs" Inherits="normalPageCTMain" %>

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
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroSella"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroOrbit"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroSinus"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroScreeningSinuses"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroFacialBone"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroNasopharynx"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroIAC"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroTemporalBone"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroParotidGland"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroNeckThyroidANDParathyriod"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroCervicalSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroThoracicSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroLumbosaralSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroFacialBone3Dimension"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroAngiogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroOralCavity"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroOrcpharynx"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroLarynx"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroPituitary"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroThyroid"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroMyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroBrainCT"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroBrainCTDWI"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroNasalCavity"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTNeuroBaseOfSkull"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKShoulder"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKElbow"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKWrist"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKHip"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKCervicalSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKFemur"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKKnee"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKAnkle"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKBoneMineralDensity"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKThoracicSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKLumbosacralSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKPelvicSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKThigh"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKFoot"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCTMSKCalcannous"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyChestAndMediastinum"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyUpper"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyLower"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyKidney"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyPancreas"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyColonos"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyKUB"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyScreeningLung"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyBiopsyOnly"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyScreeningTest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyGuidedBio"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyScreeningKUB"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyScreeningAbdominal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyHRCT"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyColonoscopy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyScreeningLiver"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyScreeningAbdomen"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyFistulogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyFacet"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkScr_Lung" />
                    <telerik:AjaxUpdatedControl ControlID="chkScr_Liver"/>
                    <telerik:AjaxUpdatedControl ControlID="chkScr_ABD"/>
                    <telerik:AjaxUpdatedControl ControlID="chkScr_KUB"/>
                    <telerik:AjaxUpdatedControl ControlID="chkScr_ABDTR"/>
                    <telerik:AjaxUpdatedControl ControlID="chkCT_BIO"/>
                    <telerik:AjaxUpdatedControl ControlID="chkCT_Face"/>
                    <telerik:AjaxUpdatedControl ControlID="chkBodyCTAppendix"/>

                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroSella"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroOrbit"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroSinus"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroScreeningSinuses"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroFacialBone"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroNasopharynx"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroIAC"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroTemporalBone"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroParotidGland"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroNeckThyroidANDParathyriod"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroCervicalSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroThoracicSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroLumbosaralSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroFacialBone3Dimension"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroAngiogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroOralCavity"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroOrcpharynx"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroLarynx"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroPituitary"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroThyroid"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroMyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroBrainCT"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroBrainCTDWI"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroNasalCavity"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTNeuroBaseOfSkull"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKShoulder"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKElbow"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKWrist"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKHip"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKCervicalSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKFemur"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKKnee"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKAnkle"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKBoneMineralDensity"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKThoracicSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKLumbosacralSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKPelvicSpine"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKThigh"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKFoot"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCTMSKCalcannous"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyChestAndMediastinum"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyUpper"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyLower"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyKidney"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyPancreas"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyColonos"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyKUB"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyScreeningLung"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyBiopsyOnly"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyScreeningTest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyGuidedBio"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyScreeningKUB"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyScreeningAbdominal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyHRCT"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyColonoscopy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyScreeningLiver"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyScreeningAbdomen"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyFistulogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyFacet"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favBodyCTAppendix"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favScr_Lung" />
                    <telerik:AjaxUpdatedControl ControlID="favScr_Liver"/>
                    <telerik:AjaxUpdatedControl ControlID="favScr_ABD"/>
                    <telerik:AjaxUpdatedControl ControlID="favScr_KUB"/>
                    <telerik:AjaxUpdatedControl ControlID="favScr_ABDTR"/>
                    <telerik:AjaxUpdatedControl ControlID="favCT_BIO"/>
                    <telerik:AjaxUpdatedControl ControlID="favCT_Face"/>

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
        <%--NEURO--%>
        <tr>
            <td class="columnBold"><asp:Label ID="lbSrin" runat="server" Text="Neuro"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroBrain"                        Text="" Width="5px" style="vertical-align:top;"              Value="XC01"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroBrain"                        Text="CT Brain"                 Value="XC01"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroSella"                        Text="" Width="5px" style="vertical-align:top;"              Value="XC02"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroSella"                        Text="CT Sella"                 Value="XC02"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroPituitary"            Text="" Width="5px" style="vertical-align:top;"              Value="XC81"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroPituitary"            Text="CT Pituitary"             Value="XC81"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroBaseOfSkull"          Text="" Width="5px" style="vertical-align:top;"              Value="XC94"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroBaseOfSkull"          Text="CT Base Of Skull"         Value="XC94"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroOrbit"                        Text="" Width="5px" style="vertical-align:top;"              Value="XC03"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroOrbit"                        Text="CT Orbit"                 Value="XC03"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroSinus"                        Text="" Width="5px" style="vertical-align:top;"              Value="XC05"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroSinus"                        Text="CT Sinus"                 Value="XC05"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroScreeningSinuses"             Text="" Width="5px" style="vertical-align:top;"              Value="XC06"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroScreeningSinuses"             Text="CT Screening Sinuses"     Value="XC06"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroFacialBone"                   Text="" Width="5px" style="vertical-align:top;"              Value="XC07"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroFacialBone"                   Text="CT Facial Bone"           Value="XC07"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroFacialBone3Dimension"         Text="" Width="5px" style="vertical-align:top;"                  Value="XC37"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroFacialBone3Dimension"         Text="CT Facial Bone 3 Dimension"   Value="XC37"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroIAC"                          Text="" Width="5px" style="vertical-align:top;"              Value="XC09"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroIAC"                          Text="CT IAC"                   Value="XC09"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroTemporalBone"                 Text="" Width="5px" style="vertical-align:top;"              Value="XC10"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroTemporalBone"                 Text="CT Temporal Bone"         Value="XC10"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroNasopharynx"                  Text="" Width="5px" style="vertical-align:top;"              Value="XC08"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroNasopharynx"                  Text="CT Nasopharynx"           Value="XC08"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroNasalCavity"          Text="" Width="5px" style="vertical-align:top;"              Value="XC04"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroNasalCavity"          Text="CT Nasal Cavity"          Value="XC04"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroOrcpharynx"           Text="" Width="5px" style="vertical-align:top;"              Value="XC79"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroOrcpharynx"           Text="CT Oropharynx"            Value="XC79"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroLarynx"               Text="" Width="5px" style="vertical-align:top;"              Value="XC80"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroLarynx"               Text="CT Larynx"                Value="XC80"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroOralCavity"           Text="" Width="5px" style="vertical-align:top;"              Value="XC77"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroOralCavity"           Text="CT Oral Cavity"           Value="XC77"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroParotidGland"                 Text="" Width="5px" style="vertical-align:top;"                          Value="XC11"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroParotidGland"                 Text="CT Parotid Gland"                     Value="XC11"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroNeckThyroidANDParathyriod"    Text="" Width="5px" style="vertical-align:top;"                          Value="XC12"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroNeckThyroidANDParathyriod"    Text="CT Neck Thyroid And Parathyroid"      Value="XC12"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroThyroid"              Text="" Width="5px" style="vertical-align:top;"              Value="XC82"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroThyroid"              Text="CT Thyroid"               Value="XC82"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroBrainCT"              Text="" Width="5px" style="vertical-align:top;"                          Value="XC87"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroBrainCT"              Text="CT Brain - CT Perfusion - CTA"        Value="XC87"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroBrainCTDWI"           Text="" Width="5px" style="vertical-align:top;"                          Value="XC88"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroBrainCTDWI"           Text="CT Brain - CT Perfusion - CTA - DWI"  Value="XC88"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroMyelogram"            Text="" Width="5px" style="vertical-align:top;"                          Value="XC83"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroMyelogram"            Text="CT Myelogram"                         Value="XC83"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroCervicalSpine"                Text="" Width="5px" style="vertical-align:top;"                          Value="XC21"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroCervicalSpine"                Text="CT Cervical Spine"                    Value="XC21"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroThoracicSpine"                Text="" Width="5px" style="vertical-align:top;"                  Value="XC22"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroThoracicSpine"                Text="CT Thoracic Spine"            Value="XC22"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroLumbosaralSpine"              Text="" Width="5px" style="vertical-align:top;"                  Value="XC23"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroLumbosaralSpine"              Text="CT Lumbosacral Spine"         Value="XC23"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTNeuroAngiogram"            Text="" Width="5px" style="vertical-align:top;"              Value="XC38"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTNeuroAngiogram"            Text="CT Angiogram"             Value="XC38"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>--%>
            </td>
        </tr>
        <%--BODY--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Body"></asp:Label></td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyChestAndMediastinum"     Text="" Width="5px" style="vertical-align:top;"                  Value="XC13"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyChestAndMediastinum"     Text="CT Chest And Mediastinum"     Value="XC13"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>         
                    </tr>
                </table>
            </td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyHRCT"                    Text="" Width="5px" style="vertical-align:top;"      Value="XC105"    runat="server"          ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyHRCT"                    Text="High resolotion CT chest (HRCT)"             Value="XC105"    runat="server"          ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyUpper"                   Text="" Width="5px" style="vertical-align:top;"                  Value="XC16"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyUpper"                   Text="CT Upper Abdomen"             Value="XC16"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            
            
        </tr>
        <tr>
            <td></td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyLower"                   Text="" Width="5px" style="vertical-align:top;"                  Value="XC17"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyLower"                   Text="CT Lower Abdomen"             Value="XC17"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyWhole"                   Text="" Width="5px" style="vertical-align:top;"                  Value="XC18"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyWhole"                   Text="CT Whole Abdomen"             Value="XC18"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyKidney"                  Text="" Width="5px" style="vertical-align:top;"                  Value="XC19"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyKidney"                  Text="CT Kidney"                    Value="XC19"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyPancreas"                Text="" Width="5px" style="vertical-align:top;"                  Value="XC20"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyPancreas"                Text="CT Pancreas"                  Value="XC20"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyKUB"                     Text="" Width="5px" style="vertical-align:top;"                  Value="XC031"   runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyKUB"                     Text="CT KUB"                       Value="XC031"   runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyColonos"                 Text="" Width="5px" style="vertical-align:top;"                  Value="XC96"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyColonos"                 Text="CT Colonoscopy"               Value="XC96"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyScreeningTest"           Text="" Width="5px" style="vertical-align:top;"                  Value="XC41"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyScreeningTest"           Text="CT Screening Test [รวม CAC]"  Value="XC41"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyGuidedBio"               Text="" Width="5px" style="vertical-align:top;"                  Value="XC46"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyGuidedBio"               Text="CT Guided Biopsy"             Value="XC46"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyFistulogram"             Text="" Width="5px" style="vertical-align:top;"              Value="XC84"    runat="server"          ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyFistulogram"             Text="CT Fistulogram"           Value="XC84"    runat="server"          ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>        
        </tr>
        <tr>
            <td></td>         
            <td  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBodyCTAppendix"             Text="" Width="5px" style="vertical-align:top;"                  Value="XC044"    runat="server"          ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBodyCTAppendix"             Text="CT Appendix"               Value="XC044"    runat="server"          ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>    
        </tr>
        <%--MSK--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="MSK"></asp:Label></td>
            <td colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKShoulder"                 Text="" Width="5px" style="vertical-align:top;"            Value="XC24"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKShoulder"              Text="CT Shoulder JT."           Value="XC24"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKElbow"                 Text="" Width="5px" style="vertical-align:top;"               Value="XC25"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKElbow"                 Text="CT Elbow JT."              Value="XC25"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKWrist"                 Text="" Width="5px" style="vertical-align:top;"               Value="XC26"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKWrist"                 Text="CT Wrist JT."              Value="XC26"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKHip"                    Text="" Width="5px" style="vertical-align:top;"                          Value="XC27"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKHip"                    Text="CT Hip JT."                           Value="XC27"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKKnee"                   Text="" Width="5px" style="vertical-align:top;"              Value="XC28"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKKnee"                   Text="CT Knee JT."              Value="XC28"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKAnkle"                  Text="" Width="5px" style="vertical-align:top;"              Value="XC29"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKAnkle"                  Text="CT Ankle JT."             Value="XC29"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>--%>
            </td> 
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKBoneMineralDensity"     Text="" Width="5px" style="vertical-align:top;"              Value="XC43"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKBoneMineralDensity"     Text="CT Bone Mineral Density"  Value="XC43"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKCervicalSpine"          Text="" Width="5px" style="vertical-align:top;"                          Value="XC71"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKCervicalSpine"          Text="CT Cervical Spine Spiral - Ortho"     Value="XC71"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKThoracicSpine"          Text="" Width="5px" style="vertical-align:top;"                          Value="XC72"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKThoracicSpine"          Text="CT Thoracic Spine Spiral - Ortho"     Value="XC72"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKLumbosacralSpine"       Text="" Width="5px" style="vertical-align:top;"                          Value="XC73"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKLumbosacralSpine"       Text="CT LUMBOSACRAL Spine Spiral - Ortho"  Value="XC73"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>          
                    </tr>
                </table>
            </td>
            
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKPelvicSpine"            Text="" Width="5px" style="vertical-align:top;"                          Value="XC74"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKPelvicSpine"            Text="CT Pelvic Bone Spiral - Ortho"        Value="XC74"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKFemur"                  Text="" Width="5px" style="vertical-align:top;"                          Value="XC90"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKFemur"                  Text="CT Femur"                             Value="XC90"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
         </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKThigh"                  Text="" Width="5px" style="vertical-align:top;"          Value="XC91"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKThigh"                  Text="CT Thigh"             Value="XC91"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            <td  colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKFoot"                   Text="" Width="5px" style="vertical-align:top;"          Value="XC92"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKFoot"                   Text="CT Foot"              Value="XC92"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            <td  colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCTMSKCalcannous"             Text="" Width="5px" style="vertical-align:top;"          Value="XC93"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCTMSKCalcannous"             Text="CT Calcaneus"        Value="XC93"    runat="server"  ButtonType="ToggleButton" GroupName="CT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            
        </tr>
        <%--Screening Study--%>
        <tr>
            <td class="columnBold"><asp:Label ID="lbScreeningStudy" runat="server" Text="Screening Study"></asp:Label></td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favScr_Lung"    Text="" Width="5px" style="vertical-align:top;"              Value="XC49"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkScr_Lung"    Text="Screening Lung Cancer"    Value="XC49"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favScr_KUB"     Text="" Width="5px" style="vertical-align:top;"                  Value="XC52"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkScr_KUB"     Text="Screening KUB Stone"          Value="XC52"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favScr_ABDTR"   Text="" Width="5px" style="vertical-align:top;"                  Value="XC53"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkScr_ABDTR"   Text="Screening Abdominal Trauma"   Value="XC53"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favScr_Liver"   Text="" Width="5px" style="vertical-align:top;"              Value="XC51"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkScr_Liver"   Text="Screening Liver Cancer"   Value="XC51"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favScr_ABD"     Text="" Width="5px" style="vertical-align:top;"                          Value="XC50"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkScr_ABD"     Text="Screening Abdomen For Acute Abdomen"  Value="XC50"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--CT Guided For--%>
        <tr>
            <td class="columnBold"><asp:Label ID="lbCT_Guided1" runat="server" Text="CT Guided For"></asp:Label></td>
            <td colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCT_Face"     Text="" Width="5px" style="vertical-align:top;"      Value="XC44"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCT_Face"     Text="Facet Injection"  Value="XC44"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCT_BIO"      Text="" Width="5px" style="vertical-align:top;"      Value="XC33"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCT_BIO"      Text="Biopsy"           Value="XC33"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
        </tr>
        
    </table>
	</div>
	</form>
</body>
</html>
