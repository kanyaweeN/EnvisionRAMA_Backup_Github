<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRUpperExtremity.aspx.cs" Inherits="normalPageCRUpperExtremity" %>

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
        	width:210px;
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
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkHandPAOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkHandPA"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkHandLat" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkFingerIndexAPLat"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFingerLittleAPLat" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkFingerMiddleAPLat" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkFingerRingAPLat"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFingerThumbAPLat"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointPA"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointPALat" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointSupinatedObView"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointSemipronatedObView"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointZeroPALAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointCarpalBoss"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointCarpalTunnel"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointPARadialDeviation"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointPAUlnarDeviation"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointBrewerton"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointScaphoidAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointScaphoidLAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointPAClenchFist"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointLatFlexion"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkForeArmRadiusUlnarAPLAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkElbowJointAPLAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkElbowJointCoyle" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkElbowJointCoronoid" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkElbowJointJone"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkHumerusArmAPLAT" />
                    <telerik:AjaxUpdatedControl ControlID="chkFingerThumbAPLatRobert" />
                    <telerik:AjaxUpdatedControl ControlID="chkWristJointLatExtension" />
                    <telerik:AjaxUpdatedControl ControlID="chkElbowJointLatFullF" />
                    <telerik:AjaxUpdatedControl ControlID="chkElbowJointLatFullE" />

                    <telerik:AjaxUpdatedControl ControlID="favHandPAOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="favHandPA"/> 
                    <telerik:AjaxUpdatedControl ControlID="favHandLat" /> 
                    <telerik:AjaxUpdatedControl ControlID="favFingerIndexAPLat"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFingerLittleAPLat" /> 
                    <telerik:AjaxUpdatedControl ControlID="favFingerMiddleAPLat" /> 
                    <telerik:AjaxUpdatedControl ControlID="favFingerRingAPLat"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFingerThumbAPLat"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointPA"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointPALat" /> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointSupinatedObView"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointSemipronatedObView"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointZeroPALAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointCarpalBoss"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointCarpalTunnel"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointPARadialDeviation"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointPAUlnarDeviation"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointBrewerton"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointScaphoidAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointScaphoidLAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointPAClenchFist"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWristJointLatFlexion"/> 
                    <telerik:AjaxUpdatedControl ControlID="favForeArmRadiusUlnarAPLAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="favElbowJointAPLAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="favElbowJointCoyle" /> 
                    <telerik:AjaxUpdatedControl ControlID="favElbowJointCoronoid" /> 
                    <telerik:AjaxUpdatedControl ControlID="favElbowJointJone"/> 
                    <telerik:AjaxUpdatedControl ControlID="favHumerusArmAPLAT" />
                    <telerik:AjaxUpdatedControl ControlID="favFingerThumbAPLatRobert" />
                    <telerik:AjaxUpdatedControl ControlID="favWristJointLatExtension" />
                    <telerik:AjaxUpdatedControl ControlID="favElbowJointLatFullF" />
                    <telerik:AjaxUpdatedControl ControlID="favElbowJointLatFullE" />
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
	<table width="100%">
        <tr>
            <td class="columnBold"><asp:Label ID="Label6" runat="server" Text="Hand"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favHandPAOblique"              Text="" Width="5px" style="vertical-align:top;"                  Value="XX71"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkHandPAOblique"              Text="Hand (AP,Oblique)"            Value="XX71"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favHandPA"                     Text="" Width="5px" style="vertical-align:top;"                  Value="XX79"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkHandPA"                     Text="Hand (AP)"                    Value="XX79"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favHandLat"                    Text="" Width="5px" style="vertical-align:top;"                  Value="XX105"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkHandLat"                    Text="Hand (Lateral)"               Value="XX105"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favFingerIndexAPLat"           Text="" Width="5px" style="vertical-align:top;"                  Value="XX127"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkFingerIndexAPLat"           Text="Finger : Index (AP,Lateral)"  Value="XX127"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favFingerLittleAPLat"          Text="" Width="5px" style="vertical-align:top;"                          Value="XX128"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkFingerLittleAPLat"          Text="Finger : Little (AP,Lateral)"         Value="XX128"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favFingerMiddleAPLat"          Text="" Width="5px" style="vertical-align:top;"                          Value="XX129"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkFingerMiddleAPLat"          Text="Finger : Middle (AP,Lateral)"         Value="XX129"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favFingerRingAPLat"            Text="" Width="5px" style="vertical-align:top;"                          Value="XX130"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkFingerRingAPLat"            Text="Finger : Ring (AP,Lateral)"           Value="XX130"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favFingerThumbAPLat"           Text="" Width="5px" style="vertical-align:top;"                          Value="XP88"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkFingerThumbAPLat"           Text="Finger : Thumb (AP,Lateral)"          Value="XP88"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favFingerThumbAPLatRobert"     Text="" Width="5px" style="vertical-align:top;"                          Value="XX109"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkFingerThumbAPLatRobert"     Text="Fingger[Thumb (Robert)]"         Value="XX109"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Wrist"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointPA"               Text="" Width="5px" style="vertical-align:top;"                          Value="XX82"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointPA"               Text="Wrist Joint (PA)"                     Value="XX82"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointPALat"            Text="" Width="5px" style="vertical-align:top;"                          Value="XX81"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointPALat"            Text="Wrist Joint (PA,Lateral)"             Value="XX81"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointSupinatedObView"      Text="" Width="5px" style="vertical-align:top;"                              Value="XX141"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointSupinatedObView"      Text="Wrist Joint (Supinated Oblique view)"     Value="XX141"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointZeroPALAT"            Text="" Width="5px" style="vertical-align:top;"                              Value="XX139"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointZeroPALAT"            Text="Wrist Joint (Zero: PA,Lateral)"           Value="XX139"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointSemipronatedObView"   Text="" Width="5px" style="vertical-align:top;"                              Value="XX146"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointSemipronatedObView"   Text="Wrist Joint (Semipronated Oblique view)"  Value="XX146"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>     
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointCarpalBoss"           Text="" Width="5px" style="vertical-align:top;"                              Value="XX144"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointCarpalBoss"           Text="Wrist Joint (Carpal Boss)"                Value="XX144"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointCarpalTunnel"         Text="" Width="5px" style="vertical-align:top;"                          Value="XX145"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointCarpalTunnel"         Text="Wrist Joint (Carpal Tunnel)"          Value="XX145"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>         
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointPARadialDeviation"    Text="" Width="5px" style="vertical-align:top;"                          Value="XX140"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointPARadialDeviation"    Text="Wrist Joint (PA Radial deviation)"    Value="XX140"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointPAUlnarDeviation"     Text="" Width="5px" style="vertical-align:top;"                      Value="XX113"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointPAUlnarDeviation"     Text="Wrist Joint (PA Ulnar deviation)" Value="XX113"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>        
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointBrewerton"            Text="" Width="5px" style="vertical-align:top;"                      Value="XX114"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointBrewerton"            Text="Wrist Joint (Brewerton)"          Value="XX114"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointScaphoidAP"           Text="" Width="5px" style="vertical-align:top;"                      Value="XX115"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointScaphoidAP"           Text="Wrist Joint (Scaphoid AP)"        Value="XX115"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>           
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointScaphoidLAT"          Text="" Width="5px" style="vertical-align:top;"                      Value="XX116"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointScaphoidLAT"          Text="Wrist Joint (Scaphoid Lateral)"   Value="XX116"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointPAClenchFist"         Text="" Width="5px" style="vertical-align:top;"                      Value="XX138"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointPAClenchFist"         Text="Wrist Joint (PA Clench Fist)"     Value="XX138"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointLatFlexion"           Text="" Width="5px" style="vertical-align:top;"                      Value="XP90"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointLatFlexion"           Text="Wrist Joint (Lateral Flexion)"    Value="XP90"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favWristJointLatExtension"         Text="" Width="5px" style="vertical-align:top;"                              Value="XP9090"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkWristJointLatExtension"         Text="Wrist Joint (Lateral Extension)"          Value="XP9090"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Arm"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favForeArmRadiusUlnarAPLAT"        Text="" Width="5px" style="vertical-align:top;"                              Value="XX72"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="4"><telerik:RadButton ID="chkForeArmRadiusUlnarAPLAT"        Text="Fore arm : Radius : Ulnar (AP,Lateral)"   Value="XX72"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favElbowJointAPLAT"            Text="" Width="5px" style="vertical-align:top;"                  Value="XX83"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkElbowJointAPLAT"            Text="Elbow Joint (AP, Lateral)"    Value="XX83"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favElbowJointCoyle"            Text="" Width="5px" style="vertical-align:top;"                  Value="XX117"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkElbowJointCoyle"            Text="Elbow Joint (Coyle)"          Value="XX117"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favElbowJointCoronoid"         Text="" Width="5px" style="vertical-align:top;"                  Value="XX125"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkElbowJointCoronoid"         Text="Elbow Joint (Coronoid)"       Value="XX125"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favElbowJointJone"             Text="" Width="5px" style="vertical-align:top;"                  Value="XX126"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkElbowJointJone"             Text="Elbow Joint (Jone)"           Value="XX126"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favElbowJointLatFullF"         Text="" Width="5px" style="vertical-align:top;"                          Value="XX90126"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkElbowJointLatFullF"         Text="Elbow joint Lat Full Flexion"         Value="XX90126"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favElbowJointLatFullE"         Text="" Width="5px" style="vertical-align:top;"                          Value="XX91126"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkElbowJointLatFullE"         Text="Elbow joint Lat Full Extension"       Value="XX91126"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton          ID="favHumerusArmAPLAT"            Text="" Width="5px" style="vertical-align:top;"                  Value="XX73"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="2"><telerik:RadButton ID="chkHumerusArmAPLAT"            Text="Humerus : Arm (AP,Lateral)"   Value="XX73"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
    </table>
	</form>
</body>
</html>
