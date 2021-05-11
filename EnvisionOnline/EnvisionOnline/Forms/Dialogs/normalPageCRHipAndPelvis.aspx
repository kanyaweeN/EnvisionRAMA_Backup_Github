<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCRHipAndPelvis.aspx.cs" Inherits="normalPageCRHipAndPelvis" %>

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
        	width:100px;
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
                    <telerik:AjaxUpdatedControl ControlID="chkHIPJointAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkHIPJointAPFrogLeg"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkHIPJointFrogLeg"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkHIPJointJudets"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkHIPJointLatCross"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkHIPJointTrueAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkPelvisAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkPelvisLAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkPelvisINLET"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkPelvisOUTLET"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSacroiliacsAP15Both"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkSacroiliacsAP15"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkPenisAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkPenisLeteral" />
                    <telerik:AjaxUpdatedControl ControlID="chkHIPJointFalseProfile" />
                    <telerik:AjaxUpdatedControl ControlID="chkHIPJointTractionview" />

                    <telerik:AjaxUpdatedControl ControlID="favHIPJointAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favHIPJointAPFrogLeg"/> 
                    <telerik:AjaxUpdatedControl ControlID="favHIPJointFrogLeg"/> 
                    <telerik:AjaxUpdatedControl ControlID="favHIPJointJudets"/> 
                    <telerik:AjaxUpdatedControl ControlID="favHIPJointLatCross"/> 
                    <telerik:AjaxUpdatedControl ControlID="favHIPJointTrueAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favPelvisAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favPelvisLAT"/> 
                    <telerik:AjaxUpdatedControl ControlID="favPelvisINLET"/> 
                    <telerik:AjaxUpdatedControl ControlID="favPelvisOUTLET"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSacroiliacsAP15Both"/> 
                    <telerik:AjaxUpdatedControl ControlID="favSacroiliacsAP15"/> 
                    <telerik:AjaxUpdatedControl ControlID="favPenisAP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favPenisLeteral" />
                    <telerik:AjaxUpdatedControl ControlID="favHIPJointFalseProfile" />
                    <telerik:AjaxUpdatedControl ControlID="favHIPJointTractionview" />
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
        <tr>
            <td class="columnBold"><asp:Label ID="Label6" runat="server" Text="Hip Joint"></asp:Label></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favHIPJointAP"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX86"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="columnNameWidth" colspan="4"><telerik:RadButton ID="chkHIPJointAP"           Text="Hip Joint (AP)"                   Value="XX86"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favHIPJointAPFrogLeg"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX87"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="columnNameWidth" colspan="4"><telerik:RadButton ID="chkHIPJointAPFrogLeg"    Text="Hip Joint (AP,Frog leg)"          Value="XX87"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favHIPJointFrogLeg"              Text="" Width="10px" style="vertical-align:top;"                      Value="XP29"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="columnNameWidth" colspan="4"><telerik:RadButton ID="chkHIPJointFrogLeg"      Text="Hip Joint (Frog leg)"             Value="XP29"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favHIPJointJudets"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX24"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="columnNameWidth" colspan="4"><telerik:RadButton ID="chkHIPJointJudets"       Text="Hip Judet"              Value="XX24"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favHIPJointLatCross"              Text="" Width="10px" style="vertical-align:top;"                      Value="XP31"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="columnNameWidth" colspan="4"><telerik:RadButton ID="chkHIPJointLatCross"     Text="Hip Joint (Lateral crosstable)"   Value="XP31"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favHIPJointTrueAP"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX111"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="columnNameWidth" colspan="4"><telerik:RadButton ID="chkHIPJointTrueAP"       Text="Hip Joint (True AP)"              Value="XX111"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favHIPJointFalseProfile"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX90111"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="columnNameWidth" colspan="4"><telerik:RadButton ID="chkHIPJointFalseProfile"       Text="Hip Joint False Profile"              Value="XX90111"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favHIPJointTractionview"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX91111"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="columnNameWidth" colspan="4"><telerik:RadButton ID="chkHIPJointTractionview"       Text="Hip Joint Traction view"              Value="XX91111"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label4" runat="server" Text="Pelvis"></asp:Label></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favPelvisAP"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX74"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="textStyle"       colspan="4" ><telerik:RadButton ID="chkPelvisAP"                  Text="Pelvis (AP)"                      Value="XX74"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favPelvisLAT"              Text="" Width="10px" style="vertical-align:top;"                      Value="XP58"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="textStyle"       colspan="4" ><telerik:RadButton ID="chkPelvisLAT"                 Text="Pelvis (Lateral)"                 Value="XP58"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favPelvisINLET"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX133"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="textStyle"       colspan="4" ><telerik:RadButton ID="chkPelvisINLET"               Text="Pelvis (Inlet)"                   Value="XX133"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favPelvisOUTLET"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX134"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="textStyle"       colspan="4" ><telerik:RadButton ID="chkPelvisOUTLET"              Text="Pelvis (Outlet)"                  Value="XX134"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Sacroiliacs"></asp:Label></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favSacroiliacsAP15Both"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX88"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="textStyle"       colspan="4" ><telerik:RadButton ID="chkSacroiliacsAP15Both"       Text="Sacroiliacs: S-I joint (AP150,Both Oblique)"  Value="XX88"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favSacroiliacsAP15"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX8C"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="textStyle"       colspan="4" ><telerik:RadButton ID="chkSacroiliacsAP15"           Text="Sacroiliacs: S-I joint (AP150)"    Value="XX8C"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label3" runat="server" Text="Penis"></asp:Label></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favPenisAP"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX149"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="textStyle"       colspan="4" ><telerik:RadButton ID="chkPenisAP"                   Text="Penis (AP)"                       Value="XX149"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
        </tr>
        <tr>
            <td></td>
            <td class="favoritStyle"    colspan="1"><telerik:RadButton ID="favPenisLeteral"              Text="" Width="10px" style="vertical-align:top;"                      Value="XX150"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
            <td class="textStyle"       colspan="4" ><telerik:RadButton ID="chkPenisLeteral"              Text="Penis (Lateral)"                  Value="XX150"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
        </tr>
    </table>
	</form>
</body>
</html>
