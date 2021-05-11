<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRERTraumaSeries.aspx.cs" Inherits="normalPageERTraumaSeries" %>

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
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesATser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesAser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesAnTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesCST5ser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesCSTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesCTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesFiTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesFoTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesFaTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesHTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesHiTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesMTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesNBTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesPTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesRTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesShTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesSkTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesTTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesToTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesWrSSTser" />
                    <telerik:AjaxUpdatedControl ControlID="ERTSeriesWrSTser" />

                    <telerik:AjaxUpdatedControl ControlID="favSeriesATser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesAser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesAnTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesCST5ser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesCSTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesCTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesFiTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesFoTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesFaTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesHTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesHiTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesMTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesNBTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesPTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesRTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesShTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesSkTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesTTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesToTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesWrSSTser" />
                    <telerik:AjaxUpdatedControl ControlID="favSeriesWrSTser" />
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
            <td class="columnBold" colspan="4"><asp:Label ID="Label50" runat="server" Text="ER TRAUMA SERIES"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesSkTser"       Text="" Width="5px" style="vertical-align:top;"               runat="server"  Value="XE001"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesSkTser"       Text="Skull Trauma Series"       runat="server"  Value="XE001"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesNBTser"       Text="" Width="5px" style="vertical-align:top;"               runat="server"  Value="XE002"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesNBTser"       Text="Nasal Bone Trauma Series"  runat="server"  Value="XE002"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesCST5ser"       Text="" Width="5px" style="vertical-align:top;"                                          runat="server"  Value="XE005"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesCST5ser"       Text="Cervical Spine Trauma Series (5 Year old and above)"  runat="server"  Value="XE005"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesMTser"         Text="" Width="5px" style="vertical-align:top;"                                          runat="server"  Value="XE004"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesMTser"         Text="Mandible Trauma Series"                               runat="server"  Value="XE004"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesCSTser"       Text="" Width="5px" style="vertical-align:top;"                                           runat="server"  Value="XE006"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesCSTser"       Text="Cervical Spine Trauma Series (<5 Years old)"           runat="server"  Value="XE006"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesFaTser"       Text="" Width="5px" style="vertical-align:top;"                                           runat="server"  Value="XE003"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesFaTser"       Text="Face Trauma Series"                                    runat="server"  Value="XE003"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td> 
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesPTser"         Text="" Width="5px" style="vertical-align:top;"                      runat="server"  Value="XE015"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesPTser"         Text="Pelvis Trauma Series"             runat="server"  Value="XE015"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesWrSTser"       Text="" Width="5px" style="vertical-align:top;"                      runat="server"  Value="XE011"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesWrSTser"       Text="Wrist Scaphoid Trauma Series R/L" runat="server"  Value="XE011"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesTTser"         Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE013"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesTTser"         Text="Thumb Trauma Series R/L"      runat="server"  Value="XE013"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesFiTser"        Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE014"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesFiTser"        Text="Finger Trauma Series R/L"     runat="server"  Value="XE014"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesATser"         Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE016"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesATser"         Text="Acetabulum Trauma Series"     runat="server"  Value="XE016"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesHiTser"        Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE017"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesHiTser"        Text="Hip Trauma Series R/L"        runat="server"  Value="XE017"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesFoTser"        Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE019"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesFoTser"        Text="Foot Trauma Series R/L"       runat="server"  Value="XE019"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                         <td class="favoritStyle"><telerik:RadButton ID="favSeriesCTser"         Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE020"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesCTser"         Text="Calcaneus Trauma Series R/L"  runat="server"  Value="XE020"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesAser"          Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE007"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesAser"          Text="Acromioclavicular Series"     runat="server"  Value="XE007"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesRTser"         Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE008"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesRTser"         Text="Rib Trauma Series R/L"        runat="server"  Value="XE008"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>          
        </tr>
        <tr>    
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesWrSSTser"      Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE010"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesWrSSTser"      Text="Wrist Trauma Series R/L"      runat="server"  Value="XE010"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesShTser"        Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE009"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesShTser"        Text="Shoulder Trauma Series R/L"   runat="server"  Value="XE009"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesHTser"         Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE012"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesHTser"         Text="Hand Trauma Series R/L"       runat="server"  Value="XE012"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesAnTser"        Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE018"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesAnTser"        Text="Ankle Trauma Series R/L"      runat="server"  Value="XE018"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"        OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSeriesToTser"        Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XE021"    ButtonType="ToggleButton" GroupName="FAV"       ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="ERTSeriesToTser"        Text="Toe Trauma Series R/L"        runat="server"  Value="XE021"   ButtonType="ToggleButton" GroupName="ERTraumaSeries"    ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
