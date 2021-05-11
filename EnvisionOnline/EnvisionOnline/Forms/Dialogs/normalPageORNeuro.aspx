<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageORNeuro.aspx.cs" Inherits="normalPageORNeuro" %>

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
                    <telerik:AjaxUpdatedControl ControlID="chkLaminectomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favLaminectomy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkLaminotomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favLaminotomy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkLaminoplasy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favLaminoplasy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkDiscectomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favDiscectomy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkEndoDiscectomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favEndoDiscectomy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkMicroDiscectomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMicroDiscectomy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkTransthoracoLaminectomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favTransthoracoLaminectomy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkTransoralLaminectomy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favTransoralLaminectomy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkLateralMassScrewFixation"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favLateralMassScrewFixation"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkAnteriorlumbarinterbodyfusion"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favAnteriorlumbarinterbodyfusion"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkTransforaminallumbarinterbodyfusion"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favTransforaminallumbarinterbodyfusion"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkPosteriorlumbarinterbodyfusions"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favPosteriorlumbarinterbodyfusions"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkObliquelumbarinterbodyfusion"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favObliquelumbarinterbodyfusion"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkAnteriorcervicaldiscectomyandfusion"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favAnteriorcervicaldiscectomyandfusion"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkSelectiveNerveRootBlocks"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favSelectiveNerveRootBlocks"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkMicrotranssphenoidalapproachtopituitarysurgery"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favMicrotranssphenoidalapproachtopituitarysurgery"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkEpiduralsteroidinjection"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favEpiduralsteroidinjection"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkEpiduroscopy"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favEpiduroscopy"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkRadiofrequencyExposureofthethirdsegmentV3"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favRadiofrequencyExposureofthethirdsegmentV3"></telerik:AjaxUpdatedControl>

                    <telerik:AjaxUpdatedControl ControlID="chkLumbarperitonealshunt"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="favLumbarperitonealshunt"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
    <div>
    <table width="100%">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLaminectomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS12"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLaminectomy"            Text="Laminectomy"            Value="CS12"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLaminotomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS13"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLaminotomy"            Text="Laminotomy"            Value="CS13"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLaminoplasy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS14"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLaminoplasy"            Text="Laminoplasy"            Value="CS14"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favDiscectomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS15"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkDiscectomy"            Text="Discectomy"            Value="CS15"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favEndoDiscectomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS16"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkEndoDiscectomy"            Text="Endo Discectomy"            Value="CS16"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMicroDiscectomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS17"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMicroDiscectomy"            Text="Micro Discectomy"            Value="CS17"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favTransthoracoLaminectomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS18"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkTransthoracoLaminectomy"            Text="Transthoraco-Laminectomy"            Value="CS18"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favTransoralLaminectomy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS19"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkTransoralLaminectomy"            Text="Transoral-Laminectomy"            Value="CS19"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLateralMassScrewFixation"            Text="" Width="5px" style="vertical-align:top;"          Value="CS20"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLateralMassScrewFixation"            Text="Lateral Mass Screw Fixation"            Value="CS20"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAnteriorlumbarinterbodyfusion"            Text="" Width="5px" style="vertical-align:top;"          Value="CS21"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAnteriorlumbarinterbodyfusion"            Text="Anterior lumbar interbody fusion"            Value="CS21"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favTransforaminallumbarinterbodyfusion"            Text="" Width="5px" style="vertical-align:top;"          Value="CS22"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkTransforaminallumbarinterbodyfusion"            Text="Transforaminal lumbar interbody fusion"            Value="CS22"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favPosteriorlumbarinterbodyfusions"            Text="" Width="5px" style="vertical-align:top;"          Value="CS23"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkPosteriorlumbarinterbodyfusions"            Text="Posterior lumbar interbody fusions"            Value="CS23"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favObliquelumbarinterbodyfusion"            Text="" Width="5px" style="vertical-align:top;"          Value="CS24"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkObliquelumbarinterbodyfusion"            Text="Oblique lumbar interbody fusion"            Value="CS24"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favAnteriorcervicaldiscectomyandfusion"            Text="" Width="5px" style="vertical-align:top;"          Value="CS25"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkAnteriorcervicaldiscectomyandfusion"            Text="Anterior cervical discectomy and fusion"            Value="CS25"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSelectiveNerveRootBlocks"            Text="" Width="5px" style="vertical-align:top;"          Value="CS26"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSelectiveNerveRootBlocks"            Text="Selective Nerve Root Blocks"            Value="CS26"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMicrotranssphenoidalapproachtopituitarysurgery"            Text="" Width="5px" style="vertical-align:top;"          Value="CS27"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMicrotranssphenoidalapproachtopituitarysurgery"            Text="Micro  transsphenoidal approach to pituitary surgery"            Value="CS27"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favEpiduralsteroidinjection"            Text="" Width="5px" style="vertical-align:top;"          Value="CS28"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkEpiduralsteroidinjection"            Text="Epidural steroid injection"            Value="CS28"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favEpiduroscopy"            Text="" Width="5px" style="vertical-align:top;"          Value="CS29"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkEpiduroscopy"            Text="Epiduroscopy"            Value="CS29"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favRadiofrequencyExposureofthethirdsegmentV3"            Text="" Width="5px" style="vertical-align:top;"          Value="CS30"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkRadiofrequencyExposureofthethirdsegmentV3"            Text="Radiofrequency Exposure of the third segment (V3)"            Value="CS30"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLumbarperitonealshunt"            Text="" Width="5px" style="vertical-align:top;"          Value="CS31"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLumbarperitonealshunt"            Text="Lumbar–peritoneal shunt"            Value="CS31"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favVagusNerveStimulatorInsertion"            Text="" Width="5px" style="vertical-align:top;"          Value="CS32"   runat="server"   ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkVagusNerveStimulatorInsertion"            Text="Vagus Nerve Stimulator Insertion"            Value="CS32"   runat="server"   ButtonType="ToggleButton" GroupName="ORT"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
