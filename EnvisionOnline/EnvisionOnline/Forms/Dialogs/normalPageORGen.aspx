<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageORGen.aspx.cs" Inherits="normalPageORGen" %>

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
                    <telerik:AjaxUpdatedControl ControlID="favDilateEsophagus"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkDilateEsophagus"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="favDilatePylorus"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkDilatePylorus"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="favNasojeInsertion"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="chkNasojeInsertion"></telerik:AjaxUpdatedControl>
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
                        <td class="favoritStyle"><telerik:RadButton ID="favDilateEsophagus"            Text="" Width="5px" style="vertical-align:top;"          Value="CS36"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkDilateEsophagus"            Text="Dilate Esophagus"            Value="CS36"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favDilatePylorus"            Text="" Width="5px" style="vertical-align:top;"          Value="CS37"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkDilatePylorus"            Text="Dilate Pylorus"            Value="CS37"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favNasojeInsertion"            Text="" Width="5px" style="vertical-align:top;"          Value="CS38"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkNasojeInsertion"            Text="Nasoje Insertion"            Value="CS38"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
