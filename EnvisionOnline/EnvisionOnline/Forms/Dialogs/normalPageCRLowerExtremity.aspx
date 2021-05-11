<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRLowerExtremity.aspx.cs" Inherits="normalPageCRLowerExtremity" %>

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
        	width:110px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:25px;
            vertical-align:top;
        }
        td
        {
            vertical-align:top;
        }
        .comboBoxWidth
        {
        	width:20px;
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
                    <telerik:AjaxUpdatedControl ControlID="chkFootAPO" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootLC" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootLCD" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootLCP" />
                    <telerik:AjaxUpdatedControl ControlID="chkToePA" />
                    <telerik:AjaxUpdatedControl ControlID="chkLegAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkCalB" />
                    <telerik:AjaxUpdatedControl ControlID="chkCalC" />
                    <telerik:AjaxUpdatedControl ControlID="chkCalAx" />
                    <telerik:AjaxUpdatedControl ControlID="chkCalL" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootL" />
                    <telerik:AjaxUpdatedControl ControlID="chkCalAxL" />
                    <telerik:AjaxUpdatedControl ControlID="chkBToePA" />
                    <telerik:AjaxUpdatedControl ControlID="chkFemAPL" />
                    <telerik:AjaxUpdatedControl ControlID="chkFemAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkFemL" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinAPL" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinL" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinWAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinPL" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinPS" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinPM" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinBAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkAJoinPA" />
                    <telerik:AjaxUpdatedControl ControlID="chkAJoinM" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootAPWeight" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootLWeight" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootLSesamoid" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootLSaltzman" />
                    <telerik:AjaxUpdatedControl ControlID="chkAJoinApweight" />
                    <telerik:AjaxUpdatedControl ControlID="chkAJoinLateral" />
                    <telerik:AjaxUpdatedControl ControlID="chkAJoinMortise" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinTL" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinTvAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinTview" />
                    <telerik:AjaxUpdatedControl ControlID="chkKJoinApvarus" />

                    <telerik:AjaxUpdatedControl ControlID="favFootAPO" />
                    <telerik:AjaxUpdatedControl ControlID="favFootLC" />
                    <telerik:AjaxUpdatedControl ControlID="favFootLCD" />
                    <telerik:AjaxUpdatedControl ControlID="favFootLCP" />
                    <telerik:AjaxUpdatedControl ControlID="favToePA" />
                    <telerik:AjaxUpdatedControl ControlID="favLegAP" />
                    <telerik:AjaxUpdatedControl ControlID="favCalB" />
                    <telerik:AjaxUpdatedControl ControlID="favCalC" />
                    <telerik:AjaxUpdatedControl ControlID="favCalAx" />
                    <telerik:AjaxUpdatedControl ControlID="favCalL" />
                    <telerik:AjaxUpdatedControl ControlID="favFootL" />
                    <telerik:AjaxUpdatedControl ControlID="favCalAxL" />
                    <telerik:AjaxUpdatedControl ControlID="favBToePA" />
                    <telerik:AjaxUpdatedControl ControlID="favFemAPL" />
                    <telerik:AjaxUpdatedControl ControlID="favFemAP" />
                    <telerik:AjaxUpdatedControl ControlID="favFemL" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinAPL" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinL" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinWAP" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinPL" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinPS" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinPM" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinBAP" />
                    <telerik:AjaxUpdatedControl ControlID="favAJoinPA" />
                    <telerik:AjaxUpdatedControl ControlID="favAJoinM" />
                    <telerik:AjaxUpdatedControl ControlID="favFootAPWeight" />
                    <telerik:AjaxUpdatedControl ControlID="favFootLWeight" />
                    <telerik:AjaxUpdatedControl ControlID="favFootLSesamoid" />
                    <telerik:AjaxUpdatedControl ControlID="favFootLSaltzman" />
                    <telerik:AjaxUpdatedControl ControlID="favAJoinApweight" />
                    <telerik:AjaxUpdatedControl ControlID="favAJoinLateral" />
                    <telerik:AjaxUpdatedControl ControlID="favAJoinMortise" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinTL" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinTvAP" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinTview" />
                    <telerik:AjaxUpdatedControl ControlID="favKJoinApvarus" />

                    <telerik:AjaxUpdatedControl ControlID="favFootAPLateralWeightbearing" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootAPLateralWeightbearing" />
                    <telerik:AjaxUpdatedControl ControlID="favFootObliqueNonWeightbearing" />
                    <telerik:AjaxUpdatedControl ControlID="chkFootObliqueNonWeightbearing" />
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
            <td class="columnBold"><asp:Label  ID="Label40" runat="server" Text="Foot"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootAPO"         Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XX77"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootAPO"         Text="Foot (AP,Oblique)"            runat="server"  Value="XX77"    ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootLC"          Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XP28"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootLC"          Text="Foot (Lateral Crosstable)"    runat="server"  Value="XP28"    ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootAPWeight"        Text="" Width="10px" style="vertical-align:top;"              runat="server"  Value="XP118"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootAPWeight"        Text="Foot AP Weight bearing"   runat="server"  Value="XP118"  ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>    
                        <td class="favoritStyle"><telerik:RadButton ID="favFootL"               Text="" Width="10px" style="vertical-align:top;"              runat="server"  Value="XX110"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootL"               Text="Foot (Lateral)"           runat="server"  Value="XX110"   ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootAPLateralWeightbearing"        Text="" Width="10px" style="vertical-align:top;"              runat="server"  Value="XP56"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootAPLateralWeightbearing"        Text="Foot : wt. bearing (ap,lat)"   runat="server"  Value="XP56"  ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>    
                        <td class="favoritStyle"><telerik:RadButton ID="favFootObliqueNonWeightbearing"               Text="" Width="10px" style="vertical-align:top;"              runat="server"  Value="XP76"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootObliqueNonWeightbearing"               Text="Foot : non wt. bearing"           runat="server"  Value="XP76"   ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootLWeight"         Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XP117"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootLWeight"         Text="Foot Lateral Weight bearing"  runat="server"  Value="XP117"     ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootLSesamoid"       Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XX122"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootLSesamoid"       Text="Foot (Sesamoid)"           runat="server"  Value="XX122"     ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootLSaltzman"       Text="" Width="10px" style="vertical-align:top;"                                  runat="server"  Value="XP112"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootLSaltzman"       Text="Foot [hindfoot alignment](Saltzman)"        runat="server"  Value="XP112"     ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootLCP"             Text="" Width="10px" style="vertical-align:top;"                                  runat="server"  Value="XX132"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootLCP"             Text="Foot [Lateral Crosstable (Plantar flexion)]"  runat="server"  Value="XX132"       ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"      OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFootLCD"       Text="" Width="10px" style="vertical-align:top;"                                runat="server"  Value="XX131"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFootLCD"       Text="Foot [Lateral Crosstable (Dorsiflexion)]"   runat="server"  Value="XX131"   ButtonType="ToggleButton" GroupName="Foot"          ToggleType="CheckBox"      OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBToePA"        Text="" Width="10px" style="vertical-align:top;"                                runat="server"  Value="XP08"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>   
                        <td class="textStyle"><telerik:RadButton    ID="chkBToePA"        Text="Big Toe (PA,Lateral)"                       runat="server"  Value="XP08"    ButtonType="ToggleButton" GroupName="BigToe"        ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favToePA"       Text="" Width="10px" style="vertical-align:top;"                          runat="server"  Value="XP89"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkToePA"       Text="Toe (PA,Lateral)"                     runat="server"  Value="XP89"    ButtonType="ToggleButton" GroupName="Toe"           ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLegAP"       Text="" Width="10px" style="vertical-align:top;"                          runat="server"  Value="XX76"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLegAP"       Text="Leg : Tibia : Fibular (AP,Lateral)"   runat="server"  Value="XX76"    ButtonType="ToggleButton" GroupName="LegTibia"      ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>    
                        <td class="favoritStyle"><telerik:RadButton ID="favCalB"       Text="" Width="10px" style="vertical-align:top;"           runat="server"  Value="XX123"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCalB"       Text="Calcaneus (Broden)"    runat="server"  Value="XX123"   ButtonType="ToggleButton" GroupName="Calcaneus"     ToggleType="CheckBox"      OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCalC"       Text="" Width="10px" style="vertical-align:top;"           runat="server"  Value="XX124"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCalC"       Text="Calcaneus (Canale)"    runat="server"  Value="XX124"   ButtonType="ToggleButton" GroupName="Calcaneus"     ToggleType="CheckBox"      OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCalAx"       Text="" Width="10px" style="vertical-align:top;"          runat="server"  Value="XP12"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCalAx"       Text="Calcaneus (Axial)"    runat="server"  Value="XP12"    ButtonType="ToggleButton" GroupName="Calcaneus"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCalL"        Text="" Width="10px" style="vertical-align:top;"          runat="server"  Value="XP13"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCalL"        Text="Calcaneus (Lateral)"  runat="server"  Value="XP13"    ButtonType="ToggleButton" GroupName="Calcaneus"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCalAxL"       Text="" Width="10px" style="vertical-align:top;"                 runat="server"  Value="XP14"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCalAxL"       Text="Calcaneus (Axial,Lateral)"   runat="server"  Value="XP14"    ButtonType="ToggleButton" GroupName="Calcaneus"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label  ID="Label47" runat="server" Text="Femur : Thight"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFemAPL"      Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XX75"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFemAPL"      Text="Femur : Thight (AP, Lateral)" runat="server"  Value="XX75"    ButtonType="ToggleButton" GroupName="FemurThight"   ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFemAP"       Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XP27"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFemAP"       Text="Femur : Thight (AP)"          runat="server"  Value="XP27"    ButtonType="ToggleButton" GroupName="FemurThight"   ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFemL"        Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XX112"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFemL"        Text="Femur : Thight (Lateral)"     runat="server"  Value="XX112"   ButtonType="ToggleButton" GroupName="FemurThight"   ToggleType="CheckBox"      OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label  ID="Label46" runat="server" Text="Knee Joint"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinAPL"    Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XX89"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinAPL"    Text="Knee Joint (AP,Lateral)"      runat="server"  Value="XX89"    ButtonType="ToggleButton" GroupName="KneeJoint"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinL"      Text="" Width="10px" style="vertical-align:top;"                  runat="server"  Value="XP54"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinL"      Text="Knee Joint (Laurin)"         runat="server"  Value="XP54"    ButtonType="ToggleButton" GroupName="KneeJoint"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinWAP"      Text="" Width="10px" style="vertical-align:top;"                                runat="server"  Value="XX8A"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinWAP"      Text="Knee Joint  Weight bearing (AP, Lateral)"   runat="server"  Value="XX8A"    ButtonType="ToggleButton" GroupName="KneeJoint"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinPL"       Text="" Width="10px" style="vertical-align:top;"                                runat="server"  Value="XP33"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinPL"       Text="Knee Joint : Patella (Laurin)]"             runat="server"  Value="XP33"    ButtonType="ToggleButton" GroupName="KneeJoint"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinTL"       Text="" Width="10px" style="vertical-align:top;"                        runat="server"  Value="XP107"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinTL"       Text="Joint Knee True Lateral (Flex 30)"  runat="server"  Value="XP107"      ButtonType="ToggleButton" GroupName="KneeJoint"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinTvAP"     Text="" Width="10px" style="vertical-align:top;"                        runat="server"  Value="XP9133"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinTvAP"     Text="Knee Joint Tunnel view (AP)"        runat="server"  Value="XP9133"      ButtonType="ToggleButton" GroupName="KneeJoint"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinTview"      Text="" Width="10px" style="vertical-align:top;"                              runat="server"  Value="XP9233"        ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinTview"      Text="Knee Joint Traction view"                 runat="server"  Value="XP9233"      ButtonType="ToggleButton" GroupName="KneeJoint"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinApvarus"    Text="" Width="10px" style="vertical-align:top;"                              runat="server"  Value="XP9333"        ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinApvarus"    Text="Knee Joint AP varus & valgus stress test" runat="server"  Value="XP9333"      ButtonType="ToggleButton" GroupName="KneeJoint"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinPS"       Text="" Width="10px" style="vertical-align:top;"                        runat="server"  Value="XP57"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinPS"       Text="Knee Joint : Patella (Skyline)"     runat="server"  Value="XP57"        ButtonType="ToggleButton" GroupName="KneeJoint"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinPM"       Text="" Width="10px" style="vertical-align:top;"                        runat="server"  Value="XP55"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinPM"       Text="Knee Joint : Patella (Merchant)"    runat="server"  Value="XP55"        ButtonType="ToggleButton" GroupName="KneeJoint"     ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favKJoinBAP"        Text="" Width="10px" style="vertical-align:top;"                                          runat="server"  Value="XX97"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkKJoinBAP"        Text="Knee Joint : Both side weight bearing (AP,Lateral)]"  runat="server"  Value="XX97"    ButtonType="ToggleButton" GroupName="KneeJoint"    ToggleType="CheckBox"   OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label  ID="Label44" runat="server" Text="Ankle Joint"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAJoinPA"         Text="" Width="10px" style="vertical-align:top;"              runat="server"  Value="XX8B"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAJoinPA"         Text="Ankle Joint (PA,Lateral)" runat="server"  Value="XX8B"    ButtonType="ToggleButton" GroupName="AnkleJoint"   ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAJoinM"          Text="" Width="10px" style="vertical-align:top;"              runat="server"  Value="XP06"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAJoinM"          Text="Ankle Joint (Mortise)"    runat="server"  Value="XP06"    ButtonType="ToggleButton" GroupName="AnkleJoint"   ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td> 
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAJoinApweight"   Text="" Width="10px" style="vertical-align:top;"                          runat="server"  Value="XP115"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAJoinApweight"   Text="Ankle Joint AP weight bearing"        runat="server"  Value="XP115"      ButtonType="ToggleButton" GroupName="AnkleJoint"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAJoinLateral"    Text="" Width="10px" style="vertical-align:top;"                          runat="server"  Value="XP116"        ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAJoinLateral"    Text="Ankle Joint Lateral weight bearing"   runat="server"  Value="XP116"      ButtonType="ToggleButton" GroupName="AnkleJoint"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>      
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAJoinMortise"    Text="" Width="10px" style="vertical-align:top;"                          runat="server"  Value="XP33"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAJoinMortise"    Text="Joint [Ankle :wt. bearing (mortisr)]"   runat="server"  Value="XP33"  ButtonType="ToggleButton" GroupName="AnkleJoint"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
