<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRHeadAndNeck.aspx.cs" Inherits="normalPageCRHeadAndNeck" %>

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
        	width:150px;
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
                    <telerik:AjaxUpdatedControl ControlID="chkSkullPALat"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullTowne"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullBaseview"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullWater" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullPALatTowne"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullSpotsella"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullOthers"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullCaldwell"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSkullTangential"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialBoneWater"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialTMjoint"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialMastoids"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialPNSParanasalsinusesCaldwellWater"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialOpticForamenrh15"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialPNSParanasalsinuseslateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialIACPATowneStenver"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialOrbitCaldwell"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialIACStenver"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialOrbitCaldwellWater" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialZygomaWaterbaseview"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialOrbitCaldwelllookuplookdown"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialZygomaTowne"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialOrbitLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialNasalBoneLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialOrbitLaterallookuplookdown"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFacialNasalBoneSemiwaterlateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMandibleMandibularTowne"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMANDIBLEPAOBLIQUE"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMandibleCephalometryAPPA"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMandibleBothOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMandibleCephalometryLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMandiblePABothOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkStyloidProcessAPOpenmouthlat"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMandiblePanoramic"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkNeckSofttissueAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkNeckSofttissueLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkNeckSofttissueAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkAdenoidLateral" />

                    <telerik:AjaxUpdatedControl ControlID="favSkullPALat"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullTowne"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullBaseview"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullWater" /> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullPALatTowne"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullSpotsella"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullOthers"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullCaldwell"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSkullTangential"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialBoneWater"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialTMjoint"/>  
                    <telerik:AjaxUpdatedControl ControlID="favFacialMastoids"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialPNSParanasalsinusesCaldwellWater"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialOpticForamenrh15"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialPNSParanasalsinuseslateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialIACPATowneStenver"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialOrbitCaldwell"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialIACStenver"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialOrbitCaldwellWater" /> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialZygomaWaterbaseview"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialOrbitCaldwelllookuplookdown"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialZygomaTowne"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialOrbitLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialNasalBoneLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialOrbitLaterallookuplookdown"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFacialNasalBoneSemiwaterlateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMandibleMandibularTowne"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMANDIBLEPAOBLIQUE"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMandibleCephalometryAPPA"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMandibleBothOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMandibleCephalometryLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMandiblePABothOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="favStyloidProcessAPOpenmouthlat"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMandiblePanoramic"/> 
                    <telerik:AjaxUpdatedControl ControlID="favNeckSofttissueAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favNeckSofttissueLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favNeckSofttissueAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favAdenoidLateral" />
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
	<table cellpadding="0" cellspacing="0" width="100%">
        <%--SKULL--%>
        <tr>
            <td class="columnBold"><asp:Label ID="lbSrin" runat="server" Text="Skull"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton  ID="favSkullPALat"         Text="" Width="10px" style="vertical-align:top;"   Value="XX11"     runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton   ID="chkSkullPALat"         Text="Skull (PA,Lat)"           Value="XX11"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullTowne"         Text="" Width="10px" style="vertical-align:top;"        Value="XX12"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSkullTowne"         Text="Skull (Towne)"            Value="XX12"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullLateral"       Text="" Width="10px" style="vertical-align:top;"          Value="XX13"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSkullLateral"       Text="Skull (Lateral)"          Value="XX13"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullBaseview"      Text="" Width="10px" style="vertical-align:top;"          Value="XX14"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSkullBaseview"      Text="Skull (Base view)"        Value="XX14"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullWater"                              Text="" Width="10px" style="vertical-align:top;"          Value="XX15"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"   colspan="1"><telerik:RadButton  ID="chkSkullWater"                              Text="Skull (Water)"            Value="XX15"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullPALatTowne"                         Text="" Width="10px" style="vertical-align:top;"          Value="XX90"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSkullPALatTowne"                         Text="Skull PA,Lat,Towne"     Value="XX90"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullSpotsella"                          Text="" Width="10px" style="vertical-align:top;"          Value="XX16"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSkullSpotsella"                          Text="Skull (Spot sella)"       Value="XX16"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullOthers"                             Text="" Width="10px" style="vertical-align:top;"          Value="XP69"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSkullOthers"                             Text="Skull (Others)"           Value="XP69"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullCaldwell"                           Text="" Width="10px" style="vertical-align:top;"          Value="XX143"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSkullCaldwell"                           Text="Skull (Caldwell)"         Value="XX143"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favSkullTangential"                         Text="" Width="10px" style="vertical-align:top;"          Value="XP70"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSkullTangential"                         Text="Skull (Tangential)"       Value="XP70"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--FACIAL--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Facial"></asp:Label></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialBoneWater"                         Text="" Width="10px" style="vertical-align:top;"          Value="XP26"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialBoneWater"                         Text="Facial Bone (Water)"      Value="XP26"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialTMjoint"                           Text="" Width="10px" style="vertical-align:top;"          Value="XX26"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialTMjoint"                           Text="Facial (TM.joint)"        Value="XX26"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialMastoids"                          Text="" Width="10px" style="vertical-align:top;"                                      Value="XX22"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialMastoids"                          Text="Facial (Mastoids)"                                    Value="XX22"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialPNSParanasalsinusesCaldwellWater"  Text="" Width="10px" style="vertical-align:top;"                                      Value="XX21"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialPNSParanasalsinusesCaldwellWater"  Text="Facial : (PNS) Paranasal sinuses (Caldwell,Water)"    Value="XX21"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>     
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialOpticForamenrh15"                  Text="" Width="10px" style="vertical-align:top;"                              Value="XP48"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialOpticForamenrh15"                  Text="Facial : Optic foramen (Rheese150)"           Value="XP48"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialPNSParanasalsinuseslateral"        Text="" Width="10px" style="vertical-align:top;"                              Value="XP53"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialPNSParanasalsinuseslateral"        Text="Facial : (PNS) Paranasal sinuses (lateral)"   Value="XP53"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>       
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialIACPATowneStenver"                 Text="" Width="10px" style="vertical-align:top;"                              Value="XX25"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialIACPATowneStenver"                 Text="Facial : IAC (PA,Towne,Stenver)"              Value="XX25"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialOrbitCaldwell"                     Text="" Width="10px" style="vertical-align:top;"                              Value="XP50"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialOrbitCaldwell"                     Text="Facial : Orbit (Caldwell)"                    Value="XP50"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td>              
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialIACStenver"                        Text="" Width="10px" style="vertical-align:top;"                              Value="XP32"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialIACStenver"                        Text="Facial : IAC (Stenver)"                       Value="XP32"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialOrbitCaldwellWater"                Text="" Width="10px" style="vertical-align:top;"                              Value="XP51"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialOrbitCaldwellWater"                Text="Facial : Orbit (Caldwell,Water)"              Value="XP51"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>                                   
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialZygomaWaterbaseview"               Text="" Width="10px" style="vertical-align:top;"                              Value="XP92"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialZygomaWaterbaseview"               Text="Facial : Zygoma (Water,base view)"            Value="XP92"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>         
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialOrbitCaldwelllookuplookdown"       Text="" Width="10px" style="vertical-align:top;"                              Value="XX118"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialOrbitCaldwelllookuplookdown"       Text="Facial : Orbit (Caldwell:look up,look down)"  Value="XX118"   runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>                    
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialZygomaTowne"               Text="" Width="10px" style="vertical-align:top;"              Value="XP91"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialZygomaTowne"               Text="Facial : Zygoma (Towne)"      Value="XP91"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialOrbitLateral"              Text="" Width="10px" style="vertical-align:top;"              Value="XP49"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialOrbitLateral"              Text="Facial : Orbit (Lateral)"     Value="XP49"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialNasalBoneLateral"              Text="" Width="10px" style="vertical-align:top;"                              Value="XP40"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialNasalBoneLateral"              Text="Facial : Nasal Bone (Lateral)"                Value="XP40"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialOrbitLaterallookuplookdown"    Text="" Width="10px" style="vertical-align:top;"                              Value="XX119"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialOrbitLaterallookuplookdown"    Text="Facial : Orbit (Lateral:look up,look down)"   Value="XX119"   runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favFacialNasalBoneSemiwaterlateral" Text="" Width="10px" style="vertical-align:top;"                                  Value="XP41"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkFacialNasalBoneSemiwaterlateral" Text="Facial : Nasal Bone (Semi-water, lateral)"        Value="XP41"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--MANDIBLE--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Mandible"></asp:Label></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favMandibleMandibularTowne"         Text="" Width="10px" style="vertical-align:top;"                  Value="XP38"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkMandibleMandibularTowne"         Text="Mandible (Mandibular Towne)"      Value="XP38"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favMANDIBLEPAOBLIQUE"               Text="" Width="10px" style="vertical-align:top;"                  Value="XX121"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkMANDIBLEPAOBLIQUE"               Text="Mandible (PA,Oblique)"            Value="XX121"   runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favMandibleCephalometryAPPA"        Text="" Width="10px" style="vertical-align:top;"                  Value="XX102"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkMandibleCephalometryAPPA"        Text="Mandible : Cephalometry (AP/PA)"  Value="XX102"   runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favMandibleBothOblique"             Text="" Width="10px" style="vertical-align:top;"                  Value="XP37"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkMandibleBothOblique"             Text="Mandible (Both Oblique)"          Value="XP37"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favMandibleCephalometryLateral"     Text="" Width="10px" style="vertical-align:top;"                      Value="XP15"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkMandibleCephalometryLateral"     Text="Mandible : Cephalometry (Lateral)"    Value="XP15"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favMandiblePABothOblique"           Text="" Width="10px" style="vertical-align:top;"                      Value="XP39"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkMandiblePABothOblique"           Text="Mandible (PA,Both Oblique)"           Value="XP39"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favStyloidProcessAPOpenmouthlat"    Text="" Width="10px" style="vertical-align:top;"                      Value="XP80"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkStyloidProcessAPOpenmouthlat"    Text="Styloid Process (AP-Open mouth,lat)"  Value="XP80"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favMandiblePanoramic"               Text="" Width="10px" style="vertical-align:top;"                      Value="XP52"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkMandiblePanoramic"               Text="Mandible : Panoramic"                 Value="XP52"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--NECK--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label3" runat="server" Text="Neck"></asp:Label></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favNeckSofttissueAP"                Text="" Width="10px" style="vertical-align:top;"                      Value="XX101"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkNeckSofttissueAP"                Text="Neck : Soft tissue (AP)"              Value="XX101"   runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favNeckSofttissueLateral"           Text="" Width="10px" style="vertical-align:top;"                      Value="XP45"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkNeckSofttissueLateral"           Text="Neck : Soft tissue (Lateral)"         Value="XP45"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favNeckSofttissueAPLateral"         Text="" Width="10px" style="vertical-align:top;"                      Value="XP46"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkNeckSofttissueAPLateral"         Text="Neck : Soft tissue (AP,Lateral)"      Value="XP46"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"colspan="1"><telerik:RadButton  ID="favAdenoidLateral"                  Text="" Width="10px" style="vertical-align:top;"                      Value="XP05"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkAdenoidLateral"                  Text="Adenoid (Lateral)"                    Value="XP05"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</form>
</body>
</html>
