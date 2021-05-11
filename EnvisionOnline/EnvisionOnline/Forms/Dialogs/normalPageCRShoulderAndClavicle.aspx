<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRShoulderAndClavicle.aspx.cs" Inherits="normalPageCRShoulderAndClavicle" %>

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
        	height:22px;
        	width:90px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:22px;
        	width:140px;
            vertical-align:top;
        }
        .columnNameWidth
        {
         width:250px;
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
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointScapularSupraspinatousoutlet"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointScapulartranscapularYview"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointApTransaxillary"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointAp"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointIntExt"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointStrykerNotch" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointTransaxillary" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointTransthoracic"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointWestPoint"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkScapularAPPA"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkCLAVICLEAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkClavicleLatLord"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkClavicleSternoclavicalarSCJointSerendipity"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkClavicleSternoclavicalarSCJointAPOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkClavicleAcromioclavicularACjointAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkClavicleAcromioclavicularACjointBoth"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkClavicleAcromioclavicularACjointWEIGHT"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkClavicleAcromioclavicularACjointZANCA" />
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointApTrue" />
                    <telerik:AjaxUpdatedControl ControlID="chkShoulderJointAp30" />
                    <telerik:AjaxUpdatedControl ControlID="chkClavicleAcromioclavicularACjointZANCAB" />

                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointScapularSupraspinatousoutlet"/> 
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointScapulartranscapularYview"/> 
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointApTransaxillary"/> 
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointAp"/> 
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointIntExt"/> 
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointStrykerNotch" /> 
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointTransaxillary" /> 
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointTransthoracic"/> 
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointWestPoint"/> 
                    <telerik:AjaxUpdatedControl ControlID="favScapularAPPA"/> 
                    <telerik:AjaxUpdatedControl ControlID="favCLAVICLEAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favClavicleLatLord"/> 
                    <telerik:AjaxUpdatedControl ControlID="favClavicleSternoclavicalarSCJointSerendipity"/> 
                    <telerik:AjaxUpdatedControl ControlID="favClavicleSternoclavicalarSCJointAPOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="favClavicleAcromioclavicularACjointAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favClavicleAcromioclavicularACjointBoth"/> 
                    <telerik:AjaxUpdatedControl ControlID="favClavicleAcromioclavicularACjointWEIGHT"/> 
                    <telerik:AjaxUpdatedControl ControlID="favClavicleAcromioclavicularACjointZANCA" />
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointApTrue" />
                    <telerik:AjaxUpdatedControl ControlID="favShoulderJointAp30" />
                    <telerik:AjaxUpdatedControl ControlID="favClavicleAcromioclavicularACjointZANCAB" />
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
	<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="columnBold"><asp:Label ID="Label6" runat="server" Text="Shoulder"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    	<td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointScapularSupraspinatousoutlet"       Text="" Width="10px" style="vertical-align:top;"                                                  Value="XP63"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointScapularSupraspinatousoutlet"       Text="Shoulder Joint Scapular (Supra spinatous outlet)"             Value="XP63"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointScapulartranscapularYview"          Text="" Width="10px" style="vertical-align:top;"                                                  Value="XP64"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointScapulartranscapularYview"          Text="Shoulder Joint Scapular (Transcapular Y view)"                Value="XP64"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--<tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointApTransaxillary"    Text="" Width="10px" style="vertical-align:top;"                              Value="XP61"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointApTransaxillary"    Text="Shoulder Joint (AP,Transaxillary)"        Value="XP61"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointAp"             Text="" Width="10px" style="vertical-align:top;"                          Value="XX84"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointAp"             Text="Shoulder Joint (AP)"                  Value="XX84"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointApTrue"         Text="" Width="10px" style="vertical-align:top;"                          Value="XP102"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointApTrue"         Text="Joint [Shoulder (True AP)]"             Value="XP102"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointAp30"           Text="" Width="10px" style="vertical-align:top;"                          Value="XX9184"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointAp30"           Text="Shoulder Joint (Apical 30⁰)"          Value="XX9184"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                    	<td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointIntExt"         Text="" Width="10px" style="vertical-align:top;"                          Value="XX85"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointIntExt"         Text="Shoulder Joint (Int/Ext)"             Value="XX85"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointStrykerNotch"   Text="" Width="10px" style="vertical-align:top;"                          Value="XP62"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointStrykerNotch"   Text="Shoulder Joint (Stryker notch)"       Value="XP62"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointTransaxillary"  Text="" Width="10px" style="vertical-align:top;"                          Value="XP65"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointTransaxillary"  Text="Shoulder Joint (Transaxillary)"       Value="XP65"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointTransthoracic"  Text="" Width="10px" style="vertical-align:top;"                          Value="XP66"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointTransthoracic"  Text="Shoulder Joint (Transthoracic)"       Value="XP66"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favShoulderJointWestPoint"      Text="" Width="10px" style="vertical-align:top;"                          Value="XP67"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkShoulderJointWestPoint"      Text="Shoulder Joint (West point)"          Value="XP67"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favScapularAPPA"        Text="" Width="10px" style="vertical-align:top;"                          Value="XX148"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkScapularAPPA"        Text="Scapular (AP/PA)"                     Value="XX148"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr>
         <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Clavicle"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favCLAVICLEAP"          Text="" Width="10px" style="vertical-align:top;"                          Value="XX7A"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkCLAVICLEAP"          Text="Clavicle (AP)"                        Value="XX7A"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favClavicleLatLord"     Text="" Width="10px" style="vertical-align:top;"                          Value="XP20"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkClavicleLatLord"     Text="Clavicle (Lateral Lordotic)"          Value="XP20"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton ID="favClavicleSternoclavicalarSCJointSerendipity"      Text="" Width="10px" style="vertical-align:top;"                                               Value="XX120"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkClavicleSternoclavicalarSCJointSerendipity"      Text="Clavicle : Sternoclavicalar: S-C joint (Serendipity)"      Value="XX120"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favClavicleSternoclavicalarSCJointAPOb"             Text="" Width="10px" style="vertical-align:top;"                                               Value="XP78"   runat="server"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkClavicleSternoclavicalarSCJointAPOb"             Text="Clavicle : Sternoclavicalar: S-C joint (AP,Oblique)"       Value="XP78"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favClavicleAcromioclavicularACjointAP"              Text="" Width="10px" style="vertical-align:top;"                                               Value="XP03"   runat="server"      ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkClavicleAcromioclavicularACjointAP"              Text="Clavicle : Acromioclavicular: A-C joint (AP)"              Value="XP03"   runat="server"      ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favClavicleAcromioclavicularACjointBoth"            Text="" Width="4px" style="vertical-align:top;"                                                          Value="XX159"    runat="server"      ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkClavicleAcromioclavicularACjointBoth"            Text="Clavicle : Acromioclavicular: A-C joint (Both Stress AP view)"        Value="XX159"   runat="server"      ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favClavicleAcromioclavicularACjointWEIGHT"          Text="" Width="4px" style="vertical-align:top;"                                               Value="XP04"       runat="server"      ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="3"><telerik:RadButton    ID="chkClavicleAcromioclavicularACjointWEIGHT"          Text="Clavicle : Acromioclavicular: A-C joint (Weight Bearing)"  Value="XP04"       runat="server"      ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favClavicleAcromioclavicularACjointZANCA"           Text="" Width="10px" style="vertical-align:top;"                                               Value="XX147"       runat="server"      ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkClavicleAcromioclavicularACjointZANCA"           Text="Clavicle : Acromioclavicular: A-C joint (Zanca view)"      Value="XX147"      runat="server"      ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
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
                        <td class="favoritStyle"><telerik:RadButton             ID="favClavicleAcromioclavicularACjointZANCAB"          Text="" Width="10px" style="vertical-align:top;"                              Value="XX90147"        runat="server"      ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkClavicleAcromioclavicularACjointZANCAB"          Text="Clavicle Zanca view (Both sides)"         Value="XX90147"     runat="server"      ButtonType="ToggleButton" GroupName="CR"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</form>
</body>
</html>
