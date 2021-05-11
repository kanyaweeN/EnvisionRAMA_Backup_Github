<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRChestAndAbdomen.aspx.cs" Inherits="normalPageCRChestAndAbdomen" %>

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
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkChestUpright" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkChestSupine" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkChestLordotic" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkChestLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkChestDecubitus"/>  
                    <telerik:AjaxUpdatedControl ControlID="chkChestOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkChestSpotlocation"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSternumOblipueLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkRibOblique" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkRibPAOblipue"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenSupineUpright"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenSupine"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenUpright" />
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenAcuteAbdomenSeries"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenProne"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkAbdomenDecubitus"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkKUBRoutine" />

                    <telerik:AjaxUpdatedControl ControlID="favChestUpright" /> 
                    <telerik:AjaxUpdatedControl ControlID="favChestSupine" /> 
                    <telerik:AjaxUpdatedControl ControlID="favChestLordotic" /> 
                    <telerik:AjaxUpdatedControl ControlID="favChestLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favChestDecubitus"/>  
                    <telerik:AjaxUpdatedControl ControlID="favChestOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="favChestSpotlocation"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSternumOblipueLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favRibOblique" /> 
                    <telerik:AjaxUpdatedControl ControlID="favRibPAOblipue"/> 
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenSupineUpright"/> 
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenLateral"/> 
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenOblique"/> 
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenSupine"/> 
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenUpright" />
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenAcuteAbdomenSeries"/> 
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenProne"/> 
                    <telerik:AjaxUpdatedControl ControlID="favAbdomenDecubitus"/> 
                    <telerik:AjaxUpdatedControl ControlID="favKUBRoutine" />
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
	<table width="100%">
    <%--CHEST--%>
    <tr>
        <td class="columnBold"><asp:Label ID="Label4" runat="server" Text="Chest"></asp:Label></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favChestUpright"         Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XX31"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkChestUpright"         Text="Chest (Upright)"          runat="server"  Value="XX31"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favChestLordotic"        Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XX35"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkChestLordotic"        Text="Chest (Lordotic)"         runat="server"  Value="XX35"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favChestSupine"              Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XX32"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkChestSupine"              Text="Chest (Supine)"               runat="server"  Value="XX32"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favSternumOblipueLateral"    Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XP79"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkSternumOblipueLateral"    Text="Sternum (Oblique,Lateral)"    runat="server"  Value="XP79"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favChestLateral"             Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XX33"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkChestLateral"             Text="Chest (Lateral)"          runat="server"  Value="XX33"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favChestDecubitus"           Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XX34"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkChestDecubitus"           Text="Chest (Decubitus)"        runat="server"  Value="XX34"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favChestOblique"             Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XP19"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkChestOblique"             Text="Chest (Oblique)"          runat="server"  Value="XP19"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>       
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favChestSpotlocation"        Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XX36"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkChestSpotlocation"        Text="Chest (Spot location)"    runat="server"  Value="XX36"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td> 
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favRibPAOblipue"             Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XP59"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkRibPAOblipue"             Text="Rib (PA, Oblique)"        runat="server"  Value="XP59"     ButtonType="ToggleButton" GroupName="CR"           ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favRibOblique"               Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XX104"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkRibOblique"               Text="Rib (Oblique)"            runat="server"  Value="XX104"    ButtonType="ToggleButton" GroupName="CR"           ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <%--ABDOMEN--%>
    <tr>
        <td class="columnBold"><asp:Label ID="Label5" runat="server" Text="Abdomen"></asp:Label></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favAbdomenSupineUpright"     Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XX41"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkAbdomenSupineUpright"     Text="Abdomen (Supine, Upright)"    runat="server"  Value="XX41"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favAbdomenLateral"           Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XX44"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkAbdomenLateral"           Text="Abdomen (Lateral)"            runat="server"  Value="XX44"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favAbdomenUpright"           Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XX42"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkAbdomenUpright"           Text="Abdomen (Upright)"            runat="server"  Value="XX42"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favAbdomenOblique"           Text="" Width="5px" style="vertical-align:top;"                  runat="server"  Value="XP01"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkAbdomenOblique"           Text="Abdomen (Oblique)"            runat="server"  Value="XP01"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favAbdomenSupine"                Text="" Width="5px" style="vertical-align:top;"                          runat="server"  Value="XX43"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkAbdomenSupine"                Text="Abdomen (Supine)"                     runat="server"  Value="XX43"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favAbdomenAcuteAbdomenSeries"    Text="" Width="5px" style="vertical-align:top;"                          runat="server"  Value="XX91"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkAbdomenAcuteAbdomenSeries"    Text="Abdomen (Acute Abdomen Series)"       runat="server"  Value="XX91"    ButtonType="ToggleButton" GroupName="CR"            ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>       
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favAbdomenProne"             Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XP95"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkAbdomenProne"             Text="Abdomen (Prone)"          runat="server"  Value="XP95"     ButtonType="ToggleButton" GroupName="CR"           ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favAbdomenDecubitus"         Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XP02"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="2"><telerik:RadButton ID="chkAbdomenDecubitus"         Text="Abdomen (Decubitus)"      runat="server"  Value="XP02"     ButtonType="ToggleButton" GroupName="CR"           ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <table width="100%">
                <tr>
                    <td class="favoritStyle"colspan="1"><telerik:RadButton ID="favKUBRoutine"               Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XX51"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                    <td class="textStyle"   colspan="4"><telerik:RadButton ID="chkKUBRoutine"               Text="KUB (Routine)"            runat="server"  Value="XX51"     ButtonType="ToggleButton" GroupName="CR"           ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                </tr>
            </table>
        </td>
    </tr>
</table>                      
	</form>
</body>
</html>
