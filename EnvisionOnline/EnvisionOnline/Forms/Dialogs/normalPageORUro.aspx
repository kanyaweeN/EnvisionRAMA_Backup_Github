<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageORUro.aspx.cs" Inherits="normalPageORUro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
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
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
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
                    <telerik:AjaxUpdatedControl ControlID="chkPercutaneousNephrostomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkPercutaneousNephroLithotomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkUreteroscopy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkUreteroscopicLithotripsy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkAntegradepyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkRetrogradepyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkDubleJStentInsertion"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkCystogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkUreterogram"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="favPercutaneousNephrostomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favPercutaneousNephroLithotomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favUreteroscopy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favUreteroscopicLithotripsy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favAntegradepyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favRetrogradepyelogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favDubleJStentInsertion"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favCystogram"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favUreterogram"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <div>
    <table width="100%">
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favPercutaneousNephrostomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS03"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkPercutaneousNephrostomy"            Text="Percutaneous Nephrostomy"            Value="CS03"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favPercutaneousNephroLithotomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS04"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkPercutaneousNephroLithotomy"            Text="Percutaneous NephroLithotomy"            Value="CS04"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUreteroscopy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS05"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUreteroscopy"            Text="Ureteroscopy"            Value="CS05"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUreteroscopicLithotripsy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS06"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUreteroscopicLithotripsy"            Text="Ureteroscopic Lithotripsy"            Value="CS06"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAntegradepyelogram"            Text="" Width="5px" style="vertical-align:top;"          Value="CS07"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAntegradepyelogram"            Text="Antegrade pyelogram"            Value="CS07"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favRetrogradepyelogram"            Text="" Width="5px" style="vertical-align:top;"          Value="CS08"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkRetrogradepyelogram"            Text="Retrograde pyelogram"            Value="CS08"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favDubleJStentInsertion"            Text="" Width="5px" style="vertical-align:top;"          Value="CS09"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkDubleJStentInsertion"            Text="Duble J Stent Insertion"            Value="CS09"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCystogram"            Text="" Width="5px" style="vertical-align:top;"          Value="CS10"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCystogram"            Text="Cystogram"            Value="CS10"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUreterogram"            Text="" Width="5px" style="vertical-align:top;"          Value="CS11"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUreterogram"            Text="Ureterogram"            Value="CS11"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
