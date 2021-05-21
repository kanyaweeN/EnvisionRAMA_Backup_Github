<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageUS.aspx.cs" Inherits="normalPageUS" %>

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
        	width:60px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:5px;
        	width:200px;
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
                     <telerik:AjaxUpdatedControl ControlID="chkUSBrain"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSSalivaryGland"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSThyroid" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSNeck"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSBreast"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSChestThorax"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSUpperAbdomen"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSLowerAbdomen"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSWholeAbdomen"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSLowerAbdomenTransR"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSLowerAbdomenTransV"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSKidneyOnly" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSKUB"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSTestisScrotum"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSProstate"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSElastography"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSMSKSpineSpinal"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSMSKJointBone"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerkidney"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplercarotid"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSDoppleTestis"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSOther"/>
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerOther" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSRectumAnus" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSLowerAbdomenTransvaginal" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerUpperVeinSingle" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerUpperVeinBoth" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerLowerVeinSingle" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerLowerVeinBoth" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerUpperArterySingle" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerUpperArteryBoth" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerLowerArterySingle" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerLowerArteryBoth" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerUpperAVFSingle" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerUpperAVFBoth" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerAbdomenAneurysm" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerAbdomenEVAR" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerAbdomenIVC" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerAbdomenLiverPV" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerAbdomenLiver" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerAbdomenKidney" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerVascularArterySingle" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerVascularArteryBoth" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerVascularVeinSingle" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerVascularVeinBoth" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerVaricoseBoth" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerVascularAnomalySingle" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSDopplerVascularAnomalyBoth" />  
                     
                     <telerik:AjaxUpdatedControl ControlID="chkUSShoulderjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSArmjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSElbowjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSForearmjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSWristjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSHandjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSKneejoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSHipjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSAnklejoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSFootjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSThighjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSLegjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="chkUSHermiajoint1part" />  

                     <telerik:AjaxUpdatedControl ControlID="favUSBrain"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSSalivaryGland"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSThyroid" />
                     <telerik:AjaxUpdatedControl ControlID="favUSNeck"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSBreast"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSChestThorax"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSUpperAbdomen"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSLowerAbdomen"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSWholeAbdomen"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSLowerAbdomenTransR"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSLowerAbdomenTransV"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSKidneyOnly" />
                     <telerik:AjaxUpdatedControl ControlID="favUSKUB"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSTestisScrotum"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSProstate"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSElastography"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSMSKSpineSpinal"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSMSKJointBone"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerkidney"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplercarotid"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSDoppleTestis"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSOther"/>
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerOther" />
                     <telerik:AjaxUpdatedControl ControlID="favUSRectumAnus" />
                     <telerik:AjaxUpdatedControl ControlID="favUSLowerAbdomenTransvaginal" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerUpperVeinSingle" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerUpperVeinBoth" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerLowerVeinSingle" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerLowerVeinBoth" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerUpperArterySingle" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerUpperArteryBoth" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerLowerArterySingle" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerLowerArteryBoth" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerUpperAVFSingle" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerUpperAVFBoth" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerAbdomenAneurysm" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerAbdomenEVAR" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerAbdomenIVC" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerAbdomenLiverPV" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerAbdomenLiver" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerAbdomenKidney" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerVascularArterySingle" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerVascularArteryBoth" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerVascularVeinSingle" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerVascularVeinBoth" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerVaricoseBoth" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerVascularAnomalySingle" />
                     <telerik:AjaxUpdatedControl ControlID="favUSDopplerVascularAnomalyBoth" />  
                     
                     <telerik:AjaxUpdatedControl ControlID="favUSShoulderjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSArmjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSElbowjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSForearmjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSWristjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSHandjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSKneejoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSHipjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSAnklejoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSFootjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSThighjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSLegjoint1part" />
                     <telerik:AjaxUpdatedControl ControlID="favUSHermiajoint1part" />                     
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
            <td align="center" class="header" colspan="5">
                <asp:Label ID="lblHeard" runat="server" Text="ULTRASONOGRAPHY"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label  ID="Label53" runat="server" Text="Head and Neck"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSBrain"                 Text="" Width="5px" style="vertical-align:top;"          Value="XU04"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSBrain"                 Text="US Brain"             Value="XU04"    runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSSalivaryGland"         Text="" Width="5px" style="vertical-align:top;"          Value="XU15"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSSalivaryGland"         Text="US Salivary Gland"    Value="XU15"    runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSThyroid"               Text="" Width="5px" style="vertical-align:top;"          Value="XU02"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSThyroid"               Text="US Thyroid"           Value="XU02"    runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSNeck"                  Text="" Width="5px" style="vertical-align:top;"          Value="XU11"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSNeck"                  Text="US Neck"              Value="XU11"    runat="server" ButtonType="ToggleButton" GroupName="HeadAndNeck"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label  ID="Label1" runat="server"  Text="Chest and Abdomen"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSBreast"                    Text="" Width="5px" style="vertical-align:top;"          Value="XU05"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSBreast"                    Text="US Breast"            Value="XU05"    runat="server" ButtonType="ToggleButton" GroupName="ChestAndAbdomen"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSChestThorax"               Text="" Width="5px" style="vertical-align:top;"          Value="XU06"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSChestThorax"               Text="US Chest / Thorax"    Value="XU06"    runat="server" ButtonType="ToggleButton" GroupName="ChestAndAbdomen"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSUpperAbdomen"              Text="" Width="5px" style="vertical-align:top;"          Value="XU03"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSUpperAbdomen"              Text="US Upper Abdomen"     Value="XU03"    runat="server" ButtonType="ToggleButton" GroupName="ChestAndAbdomen"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSLowerAbdomen"              Text="" Width="5px" style="vertical-align:top;"          Value="XU01"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSLowerAbdomen"              Text="US Lower Abdomen"     Value="XU01"    runat="server" ButtonType="ToggleButton" GroupName="ChestAndAbdomen"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSWholeAbdomen"          Text="" Width="5px" style="vertical-align:top;"                          Value="XU19"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkUSWholeAbdomen"          Text="US Whole Abdomen"                     Value="XU19"    runat="server" ButtonType="ToggleButton" GroupName="ChestAndAbdomen"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSRectumAnus"            Text="" Width="5px" style="vertical-align:top;"                          Value="XU21"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkUSRectumAnus"            Text="US Lower Abdomen (Trans-rectal)"      Value="XU21"    runat="server" ButtonType="ToggleButton" GroupName="ChestAndAbdomen"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSLowerAbdomenTransV"            Text="" Width="5px" style="vertical-align:top;"                          Value="XU22"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkUSLowerAbdomenTransV"            Text="US Lower Abdomen (Trans-vaginal)"     Value="XU22"    runat="server" ButtonType="ToggleButton" GroupName="ChestAndAbdomen"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>            
        </tr>
        <tr>
            <td class="columnBold"><asp:Label  ID="Label2" runat="server"               Text="Urogenital"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton     ID="favUSKidneyOnly"        Text="" Width="5px" style="vertical-align:top;"          Value="XU10"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton        ID="chkUSKidneyOnly"        Text="US Kidney (Only)"     Value="XU10"    runat="server" ButtonType="ToggleButton" GroupName="Urogenital"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton     ID="favUSKUB"               Text="" Width="5px" style="vertical-align:top;"          Value="XU23"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton        ID="chkUSKUB"               Text="US KUB"               Value="XU23"    runat="server" ButtonType="ToggleButton" GroupName="Urogenital"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td>          
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton     ID="favUSTestisScrotum"     Text="" Width="5px" style="vertical-align:top;"          Value="XU16"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton        ID="chkUSTestisScrotum"     Text="US Testis / Scrotum"  Value="XU16"    runat="server" ButtonType="ToggleButton" GroupName="Urogenital"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td>  
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSProstate"              Text="" Width="5px" style="vertical-align:top;"                  Value="XU24"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSProstate"              Text="US Prostate (Trans-rectal)"   Value="XU24"    runat="server" ButtonType="ToggleButton" GroupName="Urogenital"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton     ID="favUSElastography"      Text="" Width="5px" style="vertical-align:top;"          Value="XU12"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton        ID="chkUSElastography"      Text="US Elastography"      Value="XU12"    runat="server" ButtonType="ToggleButton" GroupName="Urogenital"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label  ID="Label3" runat="server"  Text="Musculoskeletal"></asp:Label></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSMSKSpineSpinal"        Text="" Width="5px" style="vertical-align:top;"              Value="XU17"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkUSMSKSpineSpinal"        Text="US Spine or Spinal Cord"  Value="XU17"   runat="server" ButtonType="ToggleButton" GroupName="Musculoskeletal"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSMSKJointBone"          Text="" Width="5px" style="vertical-align:top;"              Value="XU09"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkUSMSKJointBone"          Text="US Joint or Bone"         Value="XU09"   runat="server" ButtonType="ToggleButton" GroupName="Musculoskeletal"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label  ID="Label4" runat="server"  Text="Doppler"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerkidney"             Text="" Width="5px" style="vertical-align:top;"                  Value="XU07"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkUSDopplerkidney"             Text="US Doppler kidney"            Value="XU07"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplercarotid"            Text="" Width="5px" style="vertical-align:top;"                  Value="XU25"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkUSDopplercarotid"            Text="US Doppler Carotid Artery"    Value="XU25"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerUpperVeinSingle"        Text="" Width="5px" style="vertical-align:top;"                                          Value="XU37"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerUpperVeinSingle"        Text="US Doppler Upper Extremity (Deep Vein : Single Side)"      Value="XU37"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
              <%--  <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerUpperVeinBoth"          Text="" Width="5px" style="vertical-align:top;"                                          Value="XU38"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerUpperVeinBoth"          Text="US Doppler Upper Extremity (Vein : Both Side)"        Value="XU38"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerLowerVeinSingle"        Text="" Width="5px" style="vertical-align:top;"                                          Value="XU41"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerLowerVeinSingle"        Text="US Doppler Lower Extremity (Deep Vein : Single Side)"      Value="XU41"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerLowerVeinBoth"          Text="" Width="5px" style="vertical-align:top;"                                          Value="XU42"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerLowerVeinBoth"          Text="US Doppler Lower Extremity (Vein : Both Side)"        Value="XU42"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerUpperArterySingle"      Text="" Width="5px" style="vertical-align:top;"                                          Value="XU40"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerUpperArterySingle"      Text="US Doppler Upper Extremity (Artery : Single Side)"    Value="XU40"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerUpperArteryBoth"        Text="" Width="5px" style="vertical-align:top;"                                          Value="XU39"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerUpperArteryBoth"        Text="US Doppler Upper Extremity (Artery : Both Side)"      Value="XU39"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerLowerArterySingle"     Text="" Width="5px" style="vertical-align:top;"                                          Value="XU44"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerLowerArterySingle"     Text="US Doppler Lower Extremity (Artery : Single Side)"    Value="XU44"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
              <%--  <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerLowerArteryBoth"       Text="" Width="5px" style="vertical-align:top;"                                          Value="XU43"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerLowerArteryBoth"       Text="US Doppler Lower Extremity (Artery : Both Side)"      Value="XU43"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerUpperAVFSingle"         Text="" Width="5px" style="vertical-align:top;"                                                                      Value="XU46"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerUpperAVFSingle"         Text="US Doppler Upper Extremity for Hemodialysis access (AVF, AVBG : Single Side) "    Value="XU46"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerUpperAVFBoth"           Text="" Width="5px" style="vertical-align:top;"                                                                      Value="XU45"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerUpperAVFBoth"           Text="US Doppler Upper Extremity for Hemodialysis access (AVF, AVBG : Both Side) "      Value="XU45"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
        </tr>
        <%--<tr>
            <td></td>
        </tr>--%>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerAbdomenAneurysm"        Text="" Width="5px" style="vertical-align:top;"                              Value="XU48"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerAbdomenAneurysm"        Text="US Doppler Abdomen (Aorta : Aneurysm)"    Value="XU48"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerAbdomenEVAR"            Text="" Width="5px" style="vertical-align:top;"                              Value="XU56"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerAbdomenEVAR"            Text="US Doppler Abdomen (Aorta : EVAR)"        Value="XU56"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerAbdomenIVC"             Text="" Width="5px" style="vertical-align:top;"                              Value="XU50"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerAbdomenIVC"             Text="US Doppler Abdomen (IVC, Iliac Vein)"     Value="XU50"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerAbdomenLiverPV"         Text="" Width="5px" style="vertical-align:top;"                              Value="XU51"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerAbdomenLiverPV"         Text="US Doppler Abdomen (Liver : PV, HV, HA)"  Value="XU51"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerAbdomenLiver"           Text="" Width="5px" style="vertical-align:top;"                              Value="XU52"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerAbdomenLiver"           Text="US Doppler Abdomen (Liver Transplant)"    Value="XU52"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerAbdomenKidney"          Text="" Width="5px" style="vertical-align:top;"                              Value="XU53"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerAbdomenKidney"          Text="US Doppler Abdomen (Kidney Transplant)"   Value="XU53"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerVascularArterySingle"       Text="" Width="5px" style="vertical-align:top;"                                  Value="XU34"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerVascularArterySingle"       Text="US Doppler Vascular (Artery) (Single Side)"   Value="XU34"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            <td class="textStyle" colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerVascularArteryBoth"         Text="" Width="5px" style="vertical-align:top;"                                  Value="XU33"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerVascularArteryBoth"         Text="US Doppler  Vascular (Artery) (Both Side)"    Value="XU33"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerVascularVeinSingle"         Text="" Width="5px" style="vertical-align:top;"                                      Value="XU36"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerVascularVeinSingle"         Text="US Doppler Vascular (Vein) (Single Side)"    Value="XU36"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
               <%-- <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerVascularVeinBoth"           Text="" Width="5px" style="vertical-align:top;"                                      Value="XU35"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerVascularVeinBoth"           Text="US Doppler  Vascular (Deep Vein) (Both Side)"     Value="XU35"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            
        </tr>
        <%--<tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                         <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerVascularAnomalySingle"      Text="" Width="5px" style="vertical-align:top;"                                                      Value="XU29"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerVascularAnomalySingle"      Text="US Doppler Vascular Anomaly (Extremity : Artery) Single Side"     Value="XU29"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDopplerVascularAnomalyBoth"        Text="" Width="5px" style="vertical-align:top;"                                                      Value="XU29"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td colspan="2"><telerik:RadButton    ID="chkUSDopplerVascularAnomalyBoth"        Text="US Doppler Vascular Anomaly (Extremity : Artery) Both Side"       Value="XU29"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
           
        </tr>--%>
         <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favUSDoppleTestis"              Text="" Width="5px" style="vertical-align:top;"                  Value="XU28"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkUSDoppleTestis"              Text="US Doppler Testis"            Value="XU28"    runat="server" ButtonType="ToggleButton" GroupName="Doppler"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label        ID="Label5"                    Text="Other"    runat="server"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSOther"             Text="" Width="5px" style="vertical-align:top;"          Value="XU20"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSOther"             Text="US Other"             Value="XU20"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSDopplerOther"      Text="" Width="5px" style="vertical-align:top;"          Value="XU29"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSDopplerOther"      Text="US Doppler (Other)"   Value="XU29"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td ></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSShoulderjoint1part"             Text="" Width="5px" style="vertical-align:top;"          Value="XU57"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSShoulderjoint1part"             Text="US Shoulder joint (1 part)"             Value="XU57"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSArmjoint1part"      Text="" Width="5px" style="vertical-align:top;"          Value="XU58"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSArmjoint1part"      Text="US Arm joint (1 part)"   Value="XU58"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td ></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSElbowjoint1part"             Text="" Width="5px" style="vertical-align:top;"          Value="XU59"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSElbowjoint1part"             Text="US Elbow joint (1 part)"             Value="XU59"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSForearmjoint1part"             Text="" Width="5px" style="vertical-align:top;"          Value="XU60"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSForearmjoint1part"             Text="US Forearm joint (1 part)"             Value="XU60"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td ></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSWristjoint1part"             Text="" Width="5px" style="vertical-align:top;"          Value="XU61"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSWristjoint1part"             Text="US Wrist joint (1 part)"             Value="XU61"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSHandjoint1part"      Text="" Width="5px" style="vertical-align:top;"          Value="XU62"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSHandjoint1part"      Text="US Hand joint (1 part)"   Value="XU62"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td ></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSKneejoint1part"             Text="" Width="5px" style="vertical-align:top;"          Value="XU63"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSKneejoint1part"             Text="US Knee joint (1 part)"             Value="XU63"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSHipjoint1part"      Text="" Width="5px" style="vertical-align:top;"          Value="XU64"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSHipjoint1part"      Text="US Hip joint (1 part)"   Value="XU64"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td ></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSAnklejoint1part"             Text="" Width="5px" style="vertical-align:top;"          Value="XU65"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSAnklejoint1part"             Text="US Ankle joint (1 part)"             Value="XU65"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSFootjoint1part"      Text="" Width="5px" style="vertical-align:top;"          Value="XU66"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSFootjoint1part"      Text="US Foot joint (1 part)"   Value="XU66"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td ></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSThighjoint1part"             Text="" Width="5px" style="vertical-align:top;"          Value="XU67"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSThighjoint1part"             Text="US Thigh joint (1 part)"             Value="XU67"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSLegjoint1part"      Text="" Width="5px" style="vertical-align:top;"          Value="XU68"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSLegjoint1part"      Text="US Leg joint (1 part)"   Value="XU68"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td ></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSHermiajoint1part"             Text="" Width="5px" style="vertical-align:top;"          Value="XU69"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSHermiajoint1part"             Text="US Hermia joint (1 part)"             Value="XU69"     runat="server" ButtonType="ToggleButton" GroupName="Other"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
