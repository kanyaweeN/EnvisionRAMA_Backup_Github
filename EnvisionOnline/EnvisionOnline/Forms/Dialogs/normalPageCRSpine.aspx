<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRSpine.aspx.cs" Inherits="normalPageCRSpine" %>

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
            text-align:center;
            
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:22px;
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
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicalCspineAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineThoracicTspineAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicalCspineAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineThoracolumbarTLspineAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicalCspineLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineThoracolumbarTLspineSpot"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicalCspineLateralBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineThoracolumbarTLspineAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicalCspineOpenmouth"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineThoracolumbarTLspineLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicalCspineBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineThoracolumbarTLspineBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicalCspineLateralFlexExt" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineThoracolumbarTLspineFlexExt"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicalC7T1Swimming"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineThoracolumbarTLspineLateralBending"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineCervicothoracicCTspineAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSacrumAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkCoccyxAPLat"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineAPLATERAL"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSacrumAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkCoccyxAP" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSacrumLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkCoccyxLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineLATERAL"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineAPLATStanding"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWholeSpineAPLatStd"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineFlexExt"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWholeSpineAPStd"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWholeSpineBilateralBend"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineApLatBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkWholeSpineLatStd"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineLatBending"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSpineSpotOther"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkLumbarLSSpineLatStanding" />

                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicalCspineAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineThoracicTspineAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicalCspineAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineThoracolumbarTLspineAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicalCspineLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineThoracolumbarTLspineSpot"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicalCspineLateralBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineThoracolumbarTLspineAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicalCspineOpenmouth"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineThoracolumbarTLspineLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicalCspineBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineThoracolumbarTLspineBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicalCspineLateralFlexExt" /> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineThoracolumbarTLspineFlexExt"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicalC7T1Swimming"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineThoracolumbarTLspineLateralBending"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineCervicothoracicCTspineAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSacrumAPLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favCoccyxAPLat"/> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineAPLATERAL"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSacrumAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favCoccyxAP" /> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSacrumLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favCoccyxLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineLATERAL"/> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineAPLATStanding"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWholeSpineAPLatStd"/> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineFlexExt"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWholeSpineAPStd"/> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWholeSpineBilateralBend"/> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineApLatBothOb"/> 
                    <telerik:AjaxUpdatedControl ControlID="favWholeSpineLatStd"/> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineLatBending"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSpineSpotOther"/> 
                    <telerik:AjaxUpdatedControl ControlID="favLumbarLSSpineLatStanding" />
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
        <%--Cervical--%>
        <tr>
            <td class="columnBold" colspan="2"><asp:Label ID="Label6" runat="server" Text="Cervical"></asp:Label></td>
            <td class="columnBold" colspan="2"><asp:Label ID="Label7" runat="server" Text="Thoracic"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCervicalCspineAPLateral"            Text="" Width="10px" style="vertical-align:top;"                          Value="XX61"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicalCspineAPLateral"            Text="Cervical: C-spine (AP,Lateral)"       Value="XX61"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineThoracicTspineAPLateral"            Text="" Width="10px" style="vertical-align:top;"                          Value="XX65"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineThoracicTspineAPLateral"            Text="Thoracic: T-spine (AP,Lateral)"       Value="XX65"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
           
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineCervicalCspineAP"                   Text="" Width="10px" style="vertical-align:top;"                                  Value="XP16"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicalCspineAP"                   Text="Cervical: C-spine (AP)"                       Value="XP16"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineThoracolumbarTLspineAPLateral"      Text="" Width="10px" style="vertical-align:top;"                                  Value="XX66"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineThoracolumbarTLspineAPLateral"      Text="Thoraco-lumbar: T-L spine (AP,Lateral)"       Value="XX66"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCervicalCspineLateral"              Text="" Width="10px" style="vertical-align:top;"                       Value="XP18"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicalCspineLateral"              Text="Cervical: C-spine (Lateral)"       Value="XP18"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineThoracolumbarTLspineSpot"           Text="" Width="10px" style="vertical-align:top;"                       Value="XP87"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineThoracolumbarTLspineSpot"           Text="Thoraco-lumbar: T-L spine (Spot)"  Value="XP87"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCervicalCspineLateralBothOb"        Text="" Width="10px" style="vertical-align:top;"                                  Value="XX92"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicalCspineLateralBothOb"        Text="Cervical: C-spine (AP,Lateral,Both Oblique)"  Value="XX92"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineThoracolumbarTLspineAP"             Text="" Width="10px" style="vertical-align:top;"                                  Value="XX137"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineThoracolumbarTLspineAP"             Text="Thoraco-lumbar: T-L spine (AP)"               Value="XX137"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCervicalCspineOpenmouth"            Text="" Width="10px" style="vertical-align:top;"                                  Value="XX62"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicalCspineOpenmouth"            Text="Cervical: C-spine(Open mouth)"                Value="XX62"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineThoracolumbarTLspineLateral"        Text="" Width="10px" style="vertical-align:top;"                                  Value="XP86"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineThoracolumbarTLspineLateral"        Text="Thoraco-lumbar: T-L spine (Lateral)"          Value="XP86"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineCervicalCspineBothOb"                       Text="" Width="10px" style="vertical-align:top;"                                      Value="XX63"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicalCspineBothOb"                       Text="Cervical: C-spine (Both Oblique)"                 Value="XX63"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineThoracolumbarTLspineBothOb"                 Text="" Width="10px" style="vertical-align:top;"                                      Value="XP77"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineThoracolumbarTLspineBothOb"                 Text="Thoraco-lumbar: T-L spine (Both Oblique)"         Value="XP77"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSpineCervicalCspineLateralFlexExt"               Text="" Width="10px" style="vertical-align:top;"                                      Value="XX64"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicalCspineLateralFlexExt"               Text="Cervical: C-spine (Lateral Flex,Ext)"             Value="XX64"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    	<td class="favoritStyle"><telerik:RadButton ID="favSpineThoracolumbarTLspineFlexExt"                Text="" Width="10px" style="vertical-align:top;"                                      Value="XP84"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSpineThoracolumbarTLspineFlexExt"                Text="Thoraco-lumbar: T-L spine (Flex,Ext)"             Value="XP84"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>	
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineCervicalC7T1Swimming"                       Text="" Width="10px" style="vertical-align:top;"                                      Value="XP17"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicalC7T1Swimming"                       Text="Cervical: C7-T1 (Swimming)"                       Value="XP17"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineThoracolumbarTLspineLateralBending"         Text="" Width="10px" style="vertical-align:top;"                                      Value="XP85"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineThoracolumbarTLspineLateralBending"         Text="Thoraco-lumbar: T-L spine (Lateral Bending)"      Value="XP85"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineCervicothoracicCTspineAPLateral"            Text="" Width="10px" style="vertical-align:top;"                                      Value="XP71"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineCervicothoracicCTspineAPLateral"            Text="Cervicothoracic: C-T spine (AP,Lateral)"          Value="XP71"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="columnBold" colspan="2"><asp:Label ID="Label1" runat="server" Text="Sacrum"></asp:Label></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="columnBold" colspan="2"><asp:Label ID="Label8" runat="server" Text="Lumbar"></asp:Label></td>
                        
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		     <td colspan="2">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="2">
                                        <table width="100%">
                                            <tr>
                    		                    <td class="favoritStyle"><telerik:RadButton ID="favSacrumAPLateral"     Text="" Width="10px" style="vertical-align:top;"                              Value="XX6A"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                                <td class="textStyle"><telerik:RadButton    ID="chkSacrumAPLateral"     Text="Sacrum (AP,Lateral)"                      Value="XX6A"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" style="top: 0px; left: 0px"></telerik:RadButton></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td colspan="2">
                                        <table width="100%">
                                            <tr>
                    		                    <td class="favoritStyle"><telerik:RadButton ID="favCoccyxAPLat"         Text="" Width="10px" style="vertical-align:top;"                              Value="XX6B"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                                <td class="textStyle"><telerik:RadButton    ID="chkCoccyxAPLat"         Text="Coccyx (AP,Lateral)"                      Value="XX6B"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                            </tr>
                                        </table>
                                    </td>
                        
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>    
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineAPLATERAL"          Text="" Width="10px" style="vertical-align:top;"                              Value="XX67"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineAPLATERAL"          Text="Lumbar: L-S spine (AP,Lateral)"           Value="XX67"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		     <td colspan="2">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="2">
                                        <table width="100%">
                                            <tr>
                    		                    <td class="favoritStyle"><telerik:RadButton ID="favSacrumAP"            Text="" Width="10px" style="vertical-align:top;"                              Value="XX135"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                                <td class="textStyle"><telerik:RadButton    ID="chkSacrumAP"            Text="Sacrum (AP)"                              Value="XX135"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        
                                            </tr>
                                        </table>
                                    </td>
                                    <td colspan="2">
                                        <table width="100%">
                                            <tr>
                    		                    <td class="favoritStyle"><telerik:RadButton ID="favCoccyxAP"            Text="" Width="10px" style="vertical-align:top;"                              Value="XP21"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                                <td class="textStyle"><telerik:RadButton    ID="chkCoccyxAP"            Text="Coccyx (AP)"                              Value="XP21"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                            </tr>
                                        </table>
                                    </td>
                        
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		    <td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineAP"                 Text="" Width="10px" style="vertical-align:top;"                              Value="XP34"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineAP"                 Text="Lumbar: L-S spine (AP)"                   Value="XP34"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
             		     <td colspan="2">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="2">
                                        <table width="100%">
                                            <tr>
                    		                    <td class="favoritStyle"><telerik:RadButton ID="favSacrumLateral"       Text="" Width="10px" style="vertical-align:top;"                              Value="XX136"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                                <td class="textStyle"><telerik:RadButton    ID="chkSacrumLateral"       Text="Sacrum (Lateral)"                         Value="XX136"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        
                                            </tr>
                                        </table>
                                    </td>
                                    <td colspan="2">
                                        <table width="100%">
                                            <tr>
                    		                    <td class="favoritStyle"><telerik:RadButton ID="favCoccyxLateral"       Text="" Width="10px" style="vertical-align:top;"                              Value="XP22"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                                <td class="textStyle"><telerik:RadButton    ID="chkCoccyxLateral"       Text="Coccyx (Lateral)"                         Value="XP22"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                            </tr>
                                        </table>
                                    </td>
                        
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineLATERAL"            Text="" Width="10px" style="vertical-align:top;"                              Value="XP36"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineLATERAL"            Text="Lumbar: L-S spine (Lateral)"              Value="XP36"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="columnBold" colspan="2"><asp:Label ID="Label2" runat="server" Text="Whole Spine"></asp:Label></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineAPLATStanding"      Text="" Width="10px" style="vertical-align:top;"                              Value="XX6C"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineAPLATStanding"      Text="Lumbar: L-S spine (AP,Lat. Standing)"     Value="XX6C"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favWholeSpineAPLatStd"              Text="" Width="10px" style="vertical-align:top;"                              Value="XX95"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkWholeSpineAPLatStd"              Text="Whole Spine (AP,Lat. Standing)"           Value="XX95"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineFlexExt"            Text="" Width="10px" style="vertical-align:top;"                              Value="XX68"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineFlexExt"            Text="Lumbar: L-S spine (Flex,Ext)"             Value="XX68"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favWholeSpineAPStd"                 Text="" Width="10px" style="vertical-align:top;"                              Value="XX94"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkWholeSpineAPStd"                 Text="Whole Spine (AP Standing)"                Value="XX94"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    	<td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineBothOb"             Text="" Width="10px" style="vertical-align:top;"                              Value="XX69"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineBothOb"             Text="Lumbar: L-S spine (Both Oblique)"         Value="XX69"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    	<td class="favoritStyle"><telerik:RadButton ID="favWholeSpineBilateralBend"         Text="" Width="10px" style="vertical-align:top;"                              Value="XX142"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkWholeSpineBilateralBend"         Text="Whole Spine (Bilateral Bending)"          Value="XX142"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>	
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineApLatBothOb"        Text="" Width="10px" style="vertical-align:top;"                                      Value="XX93"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineApLatBothOb"        Text="Lumbar: L-S spine (AP,Lateral,Both Oblique)"      Value="XX93"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favWholeSpineLatStd"                Text="" Width="10px" style="vertical-align:top;"                                      Value="XX160"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkWholeSpineLatStd"                Text="Whole Spine (Lateral Standing)"                   Value="XX160"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineLatBending"         Text="" Width="10px" style="vertical-align:top;"                              Value="XP35"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineLatBending"         Text="Lumbar: L-S spine (Lateral Bending)"      Value="XP35"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favSpineSpotOther"                  Text="" Width="10px" style="vertical-align:top;"                              Value="XX157"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkSpineSpotOther"                  Text="Spine (Spot other)"                       Value="XX157"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		<td class="favoritStyle"><telerik:RadButton ID="favLumbarLSSpineLatStanding"        Text="" Width="10px" style="vertical-align:top;"                              Value="XX158"    runat="server"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                            <td class="textStyle"><telerik:RadButton    ID="chkLumbarLSSpineLatStanding"        Text="Lumbar: L-S spine (Lateral Standing)"     Value="XX158"    runat="server" ButtonType="ToggleButton" GroupName="CR"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                    		
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</form>
</body>
</html>
