<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRBone.aspx.cs" Inherits="normalPageBone" %>

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
        	width:100px;
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
                IconUrl="~/Resources/ICON/browse_16.png"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="favBoneSur" />
                    <telerik:AjaxUpdatedControl ControlID="chkBoneSur" />
                    <telerik:AjaxUpdatedControl ControlID="favBoneAPS" />
                    <telerik:AjaxUpdatedControl ControlID="chkBoneAPS" />
                    <telerik:AjaxUpdatedControl ControlID="favBoneA6" />
                    <telerik:AjaxUpdatedControl ControlID="chkBoneA6" />
                    <telerik:AjaxUpdatedControl ControlID="favBoneA12" />
                    <telerik:AjaxUpdatedControl ControlID="chkBoneA12" />
                    <telerik:AjaxUpdatedControl ControlID="favBoneLAPBaby" />
                    <telerik:AjaxUpdatedControl ControlID="chkBoneLAPBaby" />
                    <telerik:AjaxUpdatedControl ControlID="favBoneLAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkBoneLAP" />
                    <telerik:AjaxUpdatedControl ControlID="favBoneScAP" />
                    <telerik:AjaxUpdatedControl ControlID="chkBoneScAP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    
	<div>
    <table width="100%">
        <tr>
            <td class="columnBold"><asp:Label  ID="Label49" runat="server" Text="Bone"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBoneLAPBaby"         Text="" Width="5px" style="vertical-align:top;"                      runat="server"  Value="XP93"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBoneLAPBaby"         Text="Bone : Long bones AP (เด็ก)"        runat="server"  Value="XP93"    ButtonType="ToggleButton" GroupName="Bone"         ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBoneLAP"             Text="" Width="5px" style="vertical-align:top;"                      runat="server"  Value="XP94"    ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBoneLAP"             Text="Bone : Long bones AP (ผู้ใหญ่)"      runat="server"  Value="XP94"    ButtonType="ToggleButton" GroupName="Bone"         ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>   
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBoneSur"             Text="" Width="5px" style="vertical-align:top;"      runat="server"  Value="XP11"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"/></telerik:RadButton></td>
                        <td class="textStyle" ><telerik:RadButton    ID="chkBoneSur"             Text="Bone Survey"      runat="server"  Value="XP11"    ButtonType="ToggleButton" GroupName="Bone"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBoneAPS"             Text="" Width="5px" style="vertical-align:top;"      runat="server"  Value="XP07"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBoneAPS"             Text="Babygram (AP)"    runat="server"  Value="XP07"    ButtonType="ToggleButton" GroupName="Bone"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBoneA6"              Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XP10"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBoneA6"              Text="Bone Age (Baby-6 year)"   runat="server"  Value="XP10"    ButtonType="ToggleButton" GroupName="Bone"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBoneA12"             Text="" Width="5px" style="vertical-align:top;"              runat="server"  Value="XP09"    ButtonType="ToggleButton" GroupName="FAV"   ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBoneA12"             Text="Bone Age (6-12 year)"     runat="server"  Value="XP09"    ButtonType="ToggleButton" GroupName="Bone"          ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>
        </tr>
                    
        <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBoneScAP"            Text="" Width="5px" style="vertical-align:top;"      runat="server"  Value="XP60"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click"><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBoneScAP"            Text="Scannogram (AP)"  runat="server"  Value="XP60"     ButtonType="ToggleButton" GroupName="Bone"         ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
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
    </table>
	</div>
	</form>
</body>
</html>
