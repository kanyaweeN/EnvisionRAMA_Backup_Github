<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageMammo.aspx.cs" Inherits="normalPageMammo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        	height:25px;
        	width:100px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:25px;
        	width:95px;
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
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"  OnAjaxRequest="RadAjaxManager1_AjaxRequest">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID ="RadAjaxManager1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="chkMammographyNeedlelocalizatio" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkUSBreastPostMammoScreenning"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMammographyRoutineBothBreasts"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkUSBreastNeedlelocalization"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMammographyOnebreast"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkUSBreastCystAspiration"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMammographyScreeningbothBreast"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkDuctography"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkCoreNeedleBiopsyUnderUltrasound"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMammographySpotBreast"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkCoreNeedleBiopsywithMammotomeG11"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkMammographyAugmented" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkCoreNeedleBiopsywithMammotomeG8"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkCoreNeedleBiopsyUnderUSwithMarker"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkUSBreast" />

                    <telerik:AjaxUpdatedControl ControlID="favUSBreastPostMammoScreenning"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMammographyRoutineBothBreasts"/> 
                    <telerik:AjaxUpdatedControl ControlID="favUSBreastNeedlelocalization"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMammographyOnebreast"/> 
                    <telerik:AjaxUpdatedControl ControlID="favUSBreastCystAspiration"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMammographyScreeningbothBreast"/> 
                    <telerik:AjaxUpdatedControl ControlID="favDuctography"/> 
                    <telerik:AjaxUpdatedControl ControlID="favCoreNeedleBiopsyUnderUltrasound"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMammographySpotBreast"/> 
                    <telerik:AjaxUpdatedControl ControlID="favCoreNeedleBiopsywithMammotomeG11"/> 
                    <telerik:AjaxUpdatedControl ControlID="favMammographyAugmented" /> 
                    <telerik:AjaxUpdatedControl ControlID="favCoreNeedleBiopsywithMammotomeG8"/> 
                    <telerik:AjaxUpdatedControl ControlID="favCoreNeedleBiopsyUnderUSwithMarker"/> 
                    <telerik:AjaxUpdatedControl ControlID="favUSBreast" />
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
            <td align="center" class="header" colspan="4">
                <asp:Label ID="lblHeard" runat="server" Text="MAMMOGRAPHY"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="columnBold" colspan="2"><asp:Label ID="Label1" runat="server" Text="Mammography"></asp:Label></td>
            <td class="columnBold" colspan="2"><asp:Label ID="Label2" runat="server" Text="US"></asp:Label></td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMammographyRoutineBothBreasts"       Text="" Width="5px" style="vertical-align:top;"                              runat="server"  Value="XS80"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMammographyRoutineBothBreasts"       Text="Mammography (Routine Both  Breasts)"   runat="server"  Value="XS80"     ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSBreast"                            Text="" Width="5px" style="vertical-align:top;"                              runat="server"  Value="XU05"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSBreast"                            Text="US Breast"                                runat="server"  Value="XU05"     ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        <%--<td class="favoritStyle"><telerik:RadButton ID="favUSBreastPostMammoScreenning"         Text="" Width="5px" style="vertical-align:top;"                              runat="server"  Value="XS91"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSBreastPostMammoScreenning"         Text="US Breast (Post Mammo Screenning)"        runat="server"  Value="XS91"     ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"     OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMammographyOnebreast"                Text="" Width="5px" style="vertical-align:top;"                                              Value="XS81"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMammographyOnebreast"                Text="Mammography (One Breast)"                                 Value="XS81"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                   </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSBreastNeedlelocalization"          Text="" Width="5px" style="vertical-align:top;"                                              Value="XS94"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSBreastNeedlelocalization"          Text="Ultrasound,Needle localization (Breast)"           Value="XS94"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMammographyScreeningbothBreast"      Text="" Width="5px" style="vertical-align:top;"                              runat="server"  Value="XS86"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMammographyScreeningbothBreast"      Text="Mammography (Screening both Breast )"     runat="server"  Value="XS86"     ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"     OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCoreNeedleBiopsyUnderUltrasound"     Text="" Width="5px" style="vertical-align:top;"                                              Value="XI43"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCoreNeedleBiopsyUnderUltrasound"     Text="Core Needle Biopsy, Under Ultrasound (Breast)"            Value="XI43"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr> 
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMammographyAugmented"                Text="" Width="5px" style="vertical-align:top;"                                              Value="XS88"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMammographyAugmented"                Text="Mammography (Augmented)"                                  Value="XS88"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUSBreastCystAspiration"              Text="" Width="5px" style="vertical-align:top;"                                              Value="XI46"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSBreastCystAspiration"              Text="Ultrasound,Cyst Aspiration (Breast)"                    Value="XI46"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMammographySpotBreast"               Text="" Width="5px" style="vertical-align:top;"                                              Value="XS90"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMammographySpotBreast"               Text="Mammography (Spot Breast)"                                Value="XS90"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"     OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>            
                        <td class="favoritStyle"><telerik:RadButton ID="favCoreNeedleBiopsyUnderUSwithMarker"   Text="" Width="5px" style="vertical-align:top;"                                                          Value="XI64"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCoreNeedleBiopsyUnderUSwithMarker"   Text="Core Needle Biopsy (Under Ultrasound  with Marker) (Breast)"          Value="XI64"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMammographyNeedlelocalizatio"        Text="" Width="5px" style="vertical-align:top;"                                          Value="XS79"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMammographyNeedlelocalizatio"        Text="Mammography,Needle localization"               Value="XS79"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <%--<td class="favoritStyle"><telerik:RadButton ID="favUSBreast"                            Text="" Width="5px" style="vertical-align:top;"                              runat="server"  Value="XU05"     ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUSBreast"                            Text="US Breast"                                runat="server"  Value="XU05"     ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"       OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favDuctography"                         Text="" Width="5px" style="vertical-align:top;"                                              Value="XS82"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkDuctography"                         Text="Ductography"                                              Value="XS82"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        
                    </tr>
                </table>
            </td>  
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCoreNeedleBiopsywithMammotomeG11"    Text="" Width="5px" style="vertical-align:top;"                                          Value="XI61"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCoreNeedleBiopsywithMammotomeG11"    Text="Core Needle Biopsy with Vacuum-assisted device [G11]"       Value="XI61"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCoreNeedleBiopsywithMammotomeG8"     Text="" Width="5px" style="vertical-align:top;"                                                          Value="XI62"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle" OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png" /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCoreNeedleBiopsywithMammotomeG8"     Text="Core Needle Biopsy with Vacuum-assisted device + marker (Breast) [G8]"     Value="XI62"    runat="server" ButtonType="ToggleButton" GroupName="MAMMOGRAPHY"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>  
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
