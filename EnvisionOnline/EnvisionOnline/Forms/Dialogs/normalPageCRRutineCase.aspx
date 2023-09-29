<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRRutineCase.aspx.cs" Inherits="normalPageCRRutineCase" %>

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
        	height:25px;
        	width:100px;
            text-align:center;
        	color: #f9f9f9;
            font-size :  medium;
            vertical-align : middle;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:30px;
        	width:120px;
            vertical-align:top;
        }
        .comboBoxWidth
        {
        	width:20px;
        }
        .favoritStyle
        {
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
    <telerik:RadCodeBlock ID="blockGrid" runat="server">
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
                    <telerik:AjaxUpdatedControl ControlID="chkSKullAPLatTow" />
                    <telerik:AjaxUpdatedControl ControlID="chkChestRoutine" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineC4View" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesClavicle" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsWrist" />
                    <telerik:AjaxUpdatedControl ControlID="chkSKullAPLat" />
                    <telerik:AjaxUpdatedControl ControlID="chkChestSpine" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCAPLat" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesBothAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsBoth" />
                    <telerik:AjaxUpdatedControl ControlID="chkSKullTow" />
                    <telerik:AjaxUpdatedControl ControlID="chkChestLater" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCOpen" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesHandAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsElbow" />
                    <telerik:AjaxUpdatedControl ControlID="chkSKullLat" />
                    <telerik:AjaxUpdatedControl ControlID="chkChestDecub" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCBoth" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesForarm" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsShoulder" />
                    <telerik:AjaxUpdatedControl ControlID="chkSKullBaseView" />
                    <telerik:AjaxUpdatedControl ControlID="chkChestLordo" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCLat" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesHumerus" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsShoulderint" />
                    <telerik:AjaxUpdatedControl ControlID="chkSKullWater" />
                    <telerik:AjaxUpdatedControl ControlID="chkChestSpot" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineTAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesPelvis" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsBothHipsAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkSKullSpot" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineTLAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesfemur" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsHip" />
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenSupUp" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineLSAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesLeg" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsBothHips" />
                    <telerik:AjaxUpdatedControl ControlID="chkHeadAndNeckParan" />
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenUp" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineLSflx" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesFoot" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsSIAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkHeadAndNeckMasto" />
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenSup" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineLSBoth" />
                    <telerik:AjaxUpdatedControl ControlID="chkBonesFinger" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsSI" />
                    <telerik:AjaxUpdatedControl ControlID="chkHeadAndNeckOrbit" />
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenLat" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineLSStan" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsKneeAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkHeadAndNeckOptic" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineSac" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsKnee" />
                    <telerik:AjaxUpdatedControl ControlID="chkHeadAndNeckIAC" />
                    <telerik:AjaxUpdatedControl ControlID="chkKUBRoutine" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCocc" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsKneeBoth" />
                    <telerik:AjaxUpdatedControl ControlID="chkHeadAndNeckTMJ" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineWholeAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkJointsAnkleAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkHeadAndNeckSLat" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineWholeAPLat" />
                    <telerik:AjaxUpdatedControl ControlID="chkHeadAndNeckSAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkSpineLS4vi" />

                    <telerik:AjaxUpdatedControl ControlID="favSKullAPLatTow" />
                    <telerik:AjaxUpdatedControl ControlID="favChestRoutine" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineC4View" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesClavicle" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsWrist" />
                    <telerik:AjaxUpdatedControl ControlID="favSKullAPLat" />
                    <telerik:AjaxUpdatedControl ControlID="favChestSpine" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineCAPLat" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesBothAP" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsBoth" />
                    <telerik:AjaxUpdatedControl ControlID="favSKullTow" />
                    <telerik:AjaxUpdatedControl ControlID="favChestLater" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineCOpen" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesHandAP" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsElbow" />
                    <telerik:AjaxUpdatedControl ControlID="favSKullLat" />
                    <telerik:AjaxUpdatedControl ControlID="favChestDecub" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineCBoth" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesForarm" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsShoulder" />
                    <telerik:AjaxUpdatedControl ControlID="favSKullBaseView" />
                    <telerik:AjaxUpdatedControl ControlID="favChestLordo" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineCLat" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesHumerus" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsShoulderint" />
                    <telerik:AjaxUpdatedControl ControlID="favSKullWater" />
                    <telerik:AjaxUpdatedControl ControlID="favChestSpot" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineTAP" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesPelvis" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsBothHipsAP" />
                    <telerik:AjaxUpdatedControl ControlID="favSKullSpot" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineTLAP" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesfemur" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsHip" />
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenSupUp" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineLSAP" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesLeg" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsBothHips" />
                    <telerik:AjaxUpdatedControl ControlID="favHeadAndNeckParan" />
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenUp" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineLSflx" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesFoot" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsSIAP" />
                    <telerik:AjaxUpdatedControl ControlID="favHeadAndNeckMasto" />
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenSup" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineLSBoth" />
                    <telerik:AjaxUpdatedControl ControlID="favBonesFinger" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsSI" />
                    <telerik:AjaxUpdatedControl ControlID="favHeadAndNeckOrbit" />
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenLat" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineLSStan" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsKneeAP" />
                    <telerik:AjaxUpdatedControl ControlID="favHeadAndNeckOptic" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineSac" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsKnee" />
                    <telerik:AjaxUpdatedControl ControlID="favHeadAndNeckIAC" />
                    <telerik:AjaxUpdatedControl ControlID="favKUBRoutine" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineCocc" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsKneeBoth" />
                    <telerik:AjaxUpdatedControl ControlID="favHeadAndNeckTMJ" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineWholeAP" />
                    <telerik:AjaxUpdatedControl ControlID="favJointsAnkleAP" />
                    <telerik:AjaxUpdatedControl ControlID="favHeadAndNeckSLat" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineWholeAPLat" />
                    <telerik:AjaxUpdatedControl ControlID="favHeadAndNeckSAP" />
                    <telerik:AjaxUpdatedControl ControlID="favSpineLS4vi" />
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
        <Windows>
            <telerik:RadWindow ID="windowAlertExam" runat="server" Behaviors="Close" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="800" Height="430" NavigateUrl="~/Forms/Dialogs/OnlineAlertExam.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
	<div>
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td class="columnBold" style="width:20%;" colspan="2"><asp:Label  ID="Label40" runat="server" Text="Skull"></asp:Label></td>
            <td class="columnBold" style="width:20%;" colspan="2"><asp:Label  ID="Label8" runat="server" Text="Chest"></asp:Label></td>
            <td class="columnBold" style="width:20%;" colspan="2"><asp:Label  ID="Label5" runat="server" Text="Spine"></asp:Label></td>
            <td class="columnBold" style="width:20%;" colspan="2"><asp:Label  ID="Label6" runat="server" Text="Bones"></asp:Label></td>
            <td class="columnBold" style="width:20%;" colspan="2"><asp:Label  ID="Label7" runat="server" Text="Joints"></asp:Label></td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSKullAPLatTow"   Width="5px" style="vertical-align:top;" runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text=""          ToggleType="CustomToggle"   Value="XX90"   OnClick="Favorite_Click"   ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSKullAPLatTow"   runat="server" ButtonType="ToggleButton" GroupName="Skull"  Text="90 AP,Lat,Towne's"    ToggleType="CheckBox"       Value="XX90" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle"  colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favChestRoutine"    runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX31"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkChestRoutine"    runat="server" ButtonType="ToggleButton" GroupName="Chest"  Text="31 Routine:Upright"   ToggleType="CheckBox"       Value="XX31" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineC4View"     runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX92"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineC4View"     runat="server" ButtonType="ToggleButton" GroupName="Spine"  Text="92 C-Spine(4 View)"   ToggleType="CheckBox"       Value="XX92" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesClavicle"   runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX7A"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesClavicle"   runat="server" ButtonType="ToggleButton" GroupName="Bones"  Text="7A Clavicle AP"       ToggleType="CheckBox"       Value="XX7A" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsWrist"     runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX81"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsWrist"     runat="server" ButtonType="ToggleButton" GroupName="Joints" Text="81 Wrist:AP,Lat"      ToggleType="CheckBox"       Value="XX81" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSKullAPLat"  runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX11"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSKullAPLat"  runat="server" ButtonType="ToggleButton" GroupName="Skull"  Text="11 AP,Lat"            ToggleType="CheckBox"       Value="XX11" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favChestSpine"  runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX32"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkChestSpine"  runat="server" ButtonType="ToggleButton" GroupName="Chest"  Text="32 Spine"             ToggleType="CheckBox"       Value="XX32" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCAPLat" runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX61"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCAPLat" runat="server" ButtonType="ToggleButton" GroupName="Spine"  Text="61 C-Spine(AP,Lat)"   ToggleType="CheckBox"       Value="XX61" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesBothAP" runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX79"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesBothAP" runat="server" ButtonType="ToggleButton" GroupName="Bones"  Text="79 Both Hand:AP"      ToggleType="CheckBox"       Value="XX79" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsBoth"  runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX82"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsBoth"  runat="server" ButtonType="ToggleButton" GroupName="Joints" Text="82 Both Wrists:AP"    ToggleType="CheckBox"       Value="XX82" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSKullTow"        runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX12"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSKullTow"        runat="server" ButtonType="ToggleButton" GroupName="Skull"  Text="12 Towne's"           ToggleType="CheckBox"       Value="XX12" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favChestLater"      runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX33"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkChestLater"      runat="server" ButtonType="ToggleButton" GroupName="Chest"  Text="33 Lateral"           ToggleType="CheckBox"       Value="XX33" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCOpen"      runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX62"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCOpen"      runat="server" ButtonType="ToggleButton" GroupName="Spine"  Text="62 C-open Mouth"      ToggleType="CheckBox"       Value="XX62" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesHandAP"     runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX71"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesHandAP"     runat="server" ButtonType="ToggleButton" GroupName="Bones"  Text="71 Hand:AP,Obl"       ToggleType="CheckBox"       Value="XX71" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsElbow"     runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX83"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsElbow"     runat="server" ButtonType="ToggleButton" GroupName="Joints" Text="83 Elbow:AP,Lat"      ToggleType="CheckBox"       Value="XX83" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSKullLat"        runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX13"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSKullLat"        runat="server" ButtonType="ToggleButton" GroupName="Skull"  Text="13 Lateral"           ToggleType="CheckBox"       Value="XX13" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favChestDecub"      runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX34"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkChestDecub"      runat="server" ButtonType="ToggleButton" GroupName="Chest"  Text="34 Decubitus"         ToggleType="CheckBox"       Value="XX34" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCBoth"      runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX63"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCBoth"      runat="server" ButtonType="ToggleButton" GroupName="Spine"  Text="63 C-Both Obl"        ToggleType="CheckBox"       Value="XX63" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesForarm"     runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX72"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesForarm"     runat="server" ButtonType="ToggleButton" GroupName="Bones"  Text="72 Forearm:AP,Lat"    ToggleType="CheckBox"       Value="XX72" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsShoulder"  runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX84"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsShoulder"  runat="server" ButtonType="ToggleButton" GroupName="Joints" Text="84 Shoulder:AP"       ToggleType="CheckBox"       Value="XX84" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSKullBaseView"       runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX14"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSKullBaseView"       runat="server" ButtonType="ToggleButton" GroupName="Skull"  Text="14 Base View"         ToggleType="CheckBox"       Value="XX14" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favChestLordo"          runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX35"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkChestLordo"          runat="server" ButtonType="ToggleButton" GroupName="Chest"  Text="35 Lordotic"          ToggleType="CheckBox"       Value="XX35" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCLat"           runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX64"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCLat"           runat="server" ButtonType="ToggleButton" GroupName="Spine"  Text="64 C-Lat:Flx/Ext"     ToggleType="CheckBox"       Value="XX64" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesHumerus"        runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX73"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesHumerus"        runat="server" ButtonType="ToggleButton" GroupName="Bones"  Text=" 73 Humerus:AP,Lat"    ToggleType="CheckBox"       Value="XX73" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsShoulderint"   runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX85"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsShoulderint"   runat="server" ButtonType="ToggleButton" GroupName="Joints" Text="85 Shoulder:Int/Ext"  ToggleType="CheckBox"       Value="XX85" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
         <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSKullWater"          runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX15"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSKullWater"          runat="server" ButtonType="ToggleButton" GroupName="Skull"  Text="15 Water's"           ToggleType="CheckBox"       Value="XX15" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favChestSpot"           runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX36"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkChestSpot"           runat="server" ButtonType="ToggleButton" GroupName="Chest"  Text="36 Spot.."            ToggleType="CheckBox"       Value="XX36" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineTAP"            runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX65"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineTAP"            runat="server" ButtonType="ToggleButton" GroupName="Spine"  Text="65 T-Spine(AP,Lat)"   ToggleType="CheckBox"       Value="XX65" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesPelvis"         runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX74"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesPelvis"         runat="server" ButtonType="ToggleButton" GroupName="Bones"  Text="74 Pelvis:AP"         ToggleType="CheckBox"       Value="XX74" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsBothHipsAP"    runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX86"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsBothHipsAP"    runat="server" ButtonType="ToggleButton" GroupName="Joints" Text="86 Both Hips:AP"      ToggleType="CheckBox"       Value="XX86" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
         <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSKullSpot"           runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX16"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSKullSpot"           runat="server" ButtonType="ToggleButton" GroupName="Skull"  Text="16 Spot Sella"        ToggleType="CheckBox"       Value="XX16" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineTLAP"           runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX66"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineTLAP"           runat="server" ButtonType="ToggleButton" GroupName="Spine"  Text="66 T-L Spine(AP,Lat)" ToggleType="CheckBox"       Value="XX66" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesfemur"          runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX75"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesfemur"          runat="server" ButtonType="ToggleButton" GroupName="Bones"  Text="75 Femur:AP,Lat"      ToggleType="CheckBox"       Value="XX75" OnCheckedChanged="chekbox_CheckedChanged" style="top: 0px; left: 0px; height: 20px"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsHip"           runat="server" ButtonType="ToggleButton" GroupName="FAV"    Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX87"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsHip"           runat="server" ButtonType="ToggleButton" GroupName="Joints" Text="87 Hip:AP-Frogleg"    ToggleType="CheckBox"       Value="XX87" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="columnBold" colspan="2"><asp:Label  ID="Label1" runat="server" Text="Head&Neck"></asp:Label></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="columnBold" colspan="2"><asp:Label        ID="Label3"                    runat="server" Text="Abdomen"></asp:Label></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineLSAP"           runat="server" ButtonType="ToggleButton" GroupName="FAV"        Text="" Width="5px" style="vertical-align:top;"              ToggleType="CustomToggle"   Value="XX67"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineLSAP"           runat="server" ButtonType="ToggleButton" GroupName="Spine"      Text="67 L-S:AP,Lat"            ToggleType="CheckBox"       Value="XX67" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesLeg"            runat="server" ButtonType="ToggleButton" GroupName="FAV"        Text="" Width="5px" style="vertical-align:top;"              ToggleType="CustomToggle"   Value="XX76"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesLeg"            runat="server" ButtonType="ToggleButton" GroupName="Bones"      Text="76 Leg:AP,Lat"            ToggleType="CheckBox"       Value="XX76" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsBothHips"      runat="server" ButtonType="ToggleButton" GroupName="FAV"        Text="" Width="5px" style="vertical-align:top;"              ToggleType="CustomToggle"   Value="XX96"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsBothHips"      runat="server" ButtonType="ToggleButton" GroupName="Joints"     Text="96 Both hips:AP-Frogleg"  ToggleType="CheckBox"       Value="XX96" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favHeadAndNeckParan"    runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX21"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkHeadAndNeckParan"    runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"    Text="21 Paranasal"         ToggleType="CheckBox"       Value="XX21" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAbdomenSupUp"        runat="server" ButtonType="ToggleButton" GroupName="FAV"        Text="" Width="5px" style="vertical-align:top;"              ToggleType="CustomToggle"   Value="XX41"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAbdomenSupUp"        runat="server" ButtonType="ToggleButton" GroupName="Abdomen"    Text="41 Supine,Upright"        ToggleType="CheckBox"       Value="XX41" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineLS4vi"          runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX93"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineLS4vi"          runat="server" ButtonType="ToggleButton" GroupName="Spine"          Text="93 L-S:(4 view)"      ToggleType="CheckBox"       Value="XX93" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesFoot"           runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX77"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesFoot"           runat="server" ButtonType="ToggleButton" GroupName="Bones"          Text="77 Foot:AP,Lat"       ToggleType="CheckBox"       Value="XX77" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favHeadAndNeckMasto"    runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX22"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkHeadAndNeckMasto"    runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"    Text="22 Mastoids"          ToggleType="CheckBox"       Value="XX22" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAbdomenUp"           runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX42"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAbdomenUp"           runat="server" ButtonType="ToggleButton" GroupName="Abdomen"        Text="42 Upright"           ToggleType="CheckBox"       Value="XX42" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineLSflx"          runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX68"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineLSflx"          runat="server" ButtonType="ToggleButton" GroupName="Spine"          Text="68 L-S:Flx/Ext"       ToggleType="CheckBox"       Value="XX68" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBonesFinger"         runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX78"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBonesFinger"         runat="server" ButtonType="ToggleButton" GroupName="Bones"          Text="78 Finger"            ToggleType="CheckBox"       Value="XX78" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
               <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsKneeAP"        runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"              ToggleType="CustomToggle"   Value="XX89"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsKneeAP"        runat="server" ButtonType="ToggleButton" GroupName="Joints"         Text="89 Knee AP,Lat"           ToggleType="CheckBox"       Value="XX89" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>    
            
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favHeadAndNeckOrbit"        runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX23"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkHeadAndNeckOrbit"        runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"    Text="23 Orbits"            ToggleType="CheckBox"       Value="XX23" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAbdomenSup"          runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX43"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAbdomenSup"          runat="server" ButtonType="ToggleButton" GroupName="Abdomen"        Text="43 Supine"            ToggleType="CheckBox"       Value="XX43" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineLSBoth"             runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX69"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton ID="chkSpineLSBoth"    runat="server" ButtonType="ToggleButton" GroupName="Spine"          Text="69 L-S:Both Obl"      ToggleType="CheckBox"       Value="XX69" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                       
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
               <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favJointsKneeBoth"      runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"                          ToggleType="CustomToggle"   Value="XX97"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton                ID="chkJointsKneeBoth"      runat="server" ButtonType="ToggleButton" GroupName="Joints"         Text="97 Knee(wt) Bearing AP,Lat [Both]"    ToggleType="CheckBox"       Value="XX97" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favHeadAndNeckOptic"    runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"              ToggleType="CustomToggle"   Value="XX9023"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkHeadAndNeckOptic"    runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"    Text="24 Optic Foramen"         ToggleType="CheckBox"       Value="XX9023" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>    
                        <td class="favoritStyle"><telerik:RadButton ID="favAbdomenLat"              runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX44"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAbdomenLat"              runat="server" ButtonType="ToggleButton" GroupName="Abdomen"        Text="44 Lateral"           ToggleType="CheckBox"       Value="XX44" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineLSStan"         runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"              ToggleType="CustomToggle"   Value="XX6C"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSpineLSStan"         runat="server" ButtonType="ToggleButton" GroupName="Spine"          Text="6C L-S:Standing(AP,Lat)"  ToggleType="CheckBox"       Value="XX6C" OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favJointsKnee"          runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"                  ToggleType="CustomToggle"   Value="XX8A"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton                ID="chkJointsKnee"          runat="server" ButtonType="ToggleButton" GroupName="Joints"         Text="8A Knee(wt) Bearing AP,Lat"   ToggleType="CheckBox"       Value="XX8A" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favHeadAndNeckIAC"      runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX25"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton                ID="chkHeadAndNeckIAC"      runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"    Text="25 IAC'S"             ToggleType="CheckBox"       Value="XX25" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="columnBold" colspan="2"><asp:Label           ID="Label4"                 runat="server" Text="KUB"></asp:Label></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favSpineSac"            runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX6A"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton                ID="chkSpineSac"            runat="server" ButtonType="ToggleButton" GroupName="Spine"          Text="6A Sacral(AP,Lat)"    ToggleType="CheckBox"       Value="XX6A" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                    
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
               <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsSIAP"          runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX8C"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsSIAP"          runat="server" ButtonType="ToggleButton" GroupName="Joints"         Text="8C S-I:AP Degree 15"  ToggleType="CheckBox"       Value="XX8C" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table> 
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favHeadAndNeckTMJ"      runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX26"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton                ID="chkHeadAndNeckTMJ"      runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"    Text="26 TMJ'S"             ToggleType="CheckBox"       Value="XX26" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favKUBRoutine"          runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX51"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton                ID="chkKUBRoutine"          runat="server" ButtonType="ToggleButton" GroupName="KUB"            Text="51 Routine"           ToggleType="CheckBox"       Value="XX51" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favSpineCocc"           runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX6B"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton    ID="chkSpineCocc"           runat="server" ButtonType="ToggleButton" GroupName="Spine"          Text="6B Coccyx(AP,Lat)"    ToggleType="CheckBox"       Value="XX6B" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2"></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsSI"                runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX88"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsSI"                runat="server" ButtonType="ToggleButton" GroupName="Joints"         Text="88 S-I:Obl"          ToggleType="CheckBox"       Value="XX88" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favHeadAndNeckSLat"     runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"                          ToggleType="CustomToggle"   Value="XP45"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkHeadAndNeckSLat"     runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"    Text="45 Soft Tissue Neck(Lat)"             ToggleType="CheckBox"       Value="XP45" OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favSpineWholeAP"        runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"                          ToggleType="CustomToggle"   Value="XX94"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSpineWholeAP"        runat="server" ButtonType="ToggleButton" GroupName="Spine"          Text="94 Whole Spine (Standing) AP"         ToggleType="CheckBox"       Value="XX94" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>    
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favHeadAndNeckSAP"      runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"                          ToggleType="CustomToggle"   Value="XP46"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkHeadAndNeckSAP"      runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"    Text="46 Soft Tissue Neck(AP,Lat)"          ToggleType="CheckBox"       Value="XP46" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favSpineWholeAPLat"     runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"                          ToggleType="CustomToggle"   Value="XX95"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSpineWholeAPLat"     runat="server" ButtonType="ToggleButton" GroupName="Spine"          Text="95 Whole Spine (standing) AP,Lateral" ToggleType="CheckBox"       Value="XX95" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr> 
        <tr>
        <td class="textStyle" colspan="4">
                <table width="100%">
                    <tr>
                    
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favJointsAnkleAP"               runat="server" ButtonType="ToggleButton" GroupName="FAV"            Text="" Width="5px" style="vertical-align:top;"          ToggleType="CustomToggle"   Value="XX8B"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkJointsAnkleAP"               runat="server" ButtonType="ToggleButton" GroupName="Joints"         Text="8B Ankle:AP,Lat"      ToggleType="CheckBox"       Value="XX8B" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>          
        </tr>           
    </table>
	</div>
	</form>
</body>
</html>
