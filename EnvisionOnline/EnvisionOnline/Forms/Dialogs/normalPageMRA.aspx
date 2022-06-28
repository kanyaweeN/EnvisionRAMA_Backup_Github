<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageMRA.aspx.cs" Inherits="normalPageMRA" %>

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
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkMRANeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRAMSKArm"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRABodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRABodyUpper"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRABodyLower"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRABodyRenal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRABodyPeripheral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRABodyWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRABodyThoracic"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRABodyAbdominal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRAHeart"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkMRAHeartKit"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="favMRANeuroBrain"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRAMSKArm"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRABodyChest"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRABodyUpper"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRABodyLower"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRABodyRenal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRABodyPeripheral"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRABodyWhole"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRABodyThoracic"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRABodyAbdominal"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRAHeart"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMRAHeartKit"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
	<div>
    <table width="100%">
    <%--NEURO--%>
        <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Neuro"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRANeuroBrain" runat="server" ButtonType="ToggleButton" GroupName="FAV" OnClick="Favorite_Click" style="vertical-align:top;" Text="" ToggleType="CustomToggle" Value="XM37" Width="5px"><Icon PrimaryIconUrl="../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRANeuroBrain"       Text="MRA Brain"            Value="XM37"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
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
            <td class="columnBold"><asp:Label ID="Label3" runat="server" Text="Body"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRABodyChest"       Text="" Width="5px" style="vertical-align:top;"           Value="XM62"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRABodyChest"       Text="MRA Chest"             Value="XM62"    runat="server"  ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRABodyThoracic"     Text="" Width="5px" style="vertical-align:top;"              Value="XMM7"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRABodyThoracic"     Text="MRA Thoracic Aorta"       Value="XMM7"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRABodyAbdominal"    Text="" Width="5px" style="vertical-align:top;"              Value="XMM8"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRABodyAbdominal"    Text="MRA Abdominal Aorta"      Value="XMM8"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRABodyRenal"        Text="" Width="5px" style="vertical-align:top;"              Value="XM109"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRABodyRenal"        Text="MRA  renal artery (only)"         Value="XM109"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRABodyWhole"       Text="" Width="5px" style="vertical-align:top;"               Value="XMA2"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRABodyWhole"       Text="MRA Whole Abdomen"         Value="XMA2"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRABodyUpper"       Text="" Width="5px" style="vertical-align:top;"           Value="XM110"    runat="server"  ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRABodyUpper"       Text="MRA Upper abdomen (only)"     Value="XM110"    runat="server"  ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    <%--BODY--%>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRABodyLower"       Text="" Width="5px" style="vertical-align:top;"               Value="XM104"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRABodyLower"       Text="MRA  Lower abdomen (only)"         Value="XM104"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRABodyPeripheral"   Text="" Width="5px" style="vertical-align:top;"              Value="XM66"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRABodyPeripheral"   Text="MRA Peripheral Run Off"   Value="XM66"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label4" runat="server" Text="Heart"></asp:Label></td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRAHeart"        Text="" Width="5px" style="vertical-align:top;"      Value="XM99"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRAHeart"        Text="MRA Heart"        Value="XM99"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" style="top: 0px; left: 0px"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favMRAHeartKit"     Text="" Width="2px" style="vertical-align:top;"                                                      Value="XMR8"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkMRAHeartKit"     Text="MRA Heart Continuum MR Infusion Sysytem Standard Administra Kit"  Value="XMR8"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table>
                    <tr>
                        <td class="favoritStyle"></td>
                        <td class="textStyle"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="MSK"></asp:Label></td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRAMSKArm"       Text="" Width="5px" style="vertical-align:top;"      Value="XM96"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRAMSKArm"       Text="MRA Arm"          Value="XM96"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
           
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
