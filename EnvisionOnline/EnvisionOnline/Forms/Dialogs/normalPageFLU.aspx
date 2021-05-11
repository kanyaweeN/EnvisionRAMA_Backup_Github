<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageFLU.aspx.cs" Inherits="normalPageFLU" %>

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
        	height:30px;
        	width:100px;
            text-align:center;
            
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
        	height:30px;
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
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkFluBariumswallowEsophagography"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluIVP"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluSialogramSingle"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluFluoroscopiconlyFlu"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluBariumSwallowwithwatersoluble"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluHysterosalpingography"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluDefecography"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluTomographyBone"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluBariumEnemaBESinglecontrast"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluVoidingCystogramCHILD"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluFistulography"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluTomographyWholeLung"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluBariumEnemaBDoubleaircontrast"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluVoidingCystogramYOUNG"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluMyelographyTotal"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluTomosynthesis"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluUGIStudybariummeal"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluCystography"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluOstogram"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluTomographyOthers"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluUGIStudywithwatersoluble"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluDacryocystography"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluVideoforEsophagogram"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluGIFollowThroughLongGI"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluUrethrography"/> 
                    <telerik:AjaxUpdatedControl ControlID="chkFluFluoroscopicVideorecord" />

                    <telerik:AjaxUpdatedControl ControlID="favFluBariumswallowEsophagography"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluIVP"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluSialogramSingle"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluFluoroscopiconlyFlu"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluBariumSwallowwithwatersoluble"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluHysterosalpingography"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluDefecography"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluTomographyBone"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluBariumEnemaBESinglecontrast"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluVoidingCystogramCHILD"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluFistulography"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluTomographyWholeLung"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluBariumEnemaBDoubleaircontrast"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluVoidingCystogramYOUNG"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluMyelographyTotal"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluTomosynthesis"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluUGIStudybariummeal"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluCystography"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluOstogram"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluTomographyOthers"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluUGIStudywithwatersoluble"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluDacryocystography"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluVideoforEsophagogram"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluGIFollowThroughLongGI"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluUrethrography"/> 
                    <telerik:AjaxUpdatedControl ControlID="favFluFluoroscopicVideorecord" />
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
            <td align="center" class="header" colspan="7">
                <asp:Label ID="lblHeard" runat="server" Text="FLUOROSCOPIC AND SPECIAL STUDY"></asp:Label>
            </td>
        </tr>
        <tr>  
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="GI Tract System"></asp:Label></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluBariumswallowEsophagography"      Text="" Width="5px" style="vertical-align:top;"                          Value="XS77"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluBariumswallowEsophagography"      Text="Barium Swallow (Esophagography)"      Value="XS77"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
             
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluBariumSwallowwithwatersoluble"    Text="" Width="5px" style="vertical-align:top;"                              Value="XS39"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluBariumSwallowwithwatersoluble"    Text="Barium Swallow (with water soluble)"      Value="XS39"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
             
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluUGIStudybariummeal"               Text="" Width="5px" style="vertical-align:top;"                          Value="XS75"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluUGIStudybariummeal"               Text="UGI Study (barium meal)"         Value="XS75"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluUGIStudywithwatersoluble"         Text="" Width="5px" style="vertical-align:top;"                              Value="XS76"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluUGIStudywithwatersoluble"         Text="UGI Study (with water soluble)"      Value="XS76"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favFluGIFollowThroughLongGI"        Text="" Width="5px" style="vertical-align:top;"                              Value="XS74"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluGIFollowThroughLongGI"        Text="GI Follow Through (Long GI)"   Value="XS74"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluBariumEnemaBESinglecontrast"      Text="" Width="5px" style="vertical-align:top;"                          Value="XS72"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluBariumEnemaBESinglecontrast"      Text="Barium Enema : BE (Single contrast)"  Value="XS72"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td> 
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluBariumEnemaBDoubleaircontrast"    Text="" Width="5px" style="vertical-align:top;"                              Value="XS73"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluBariumEnemaBDoubleaircontrast"    Text="Barium Enema : BE (Double air contrast)"  Value="XS73"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluDefecography"             Text="" Width="5px" style="vertical-align:top;"                  Value="XS85"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluDefecography"             Text="Defecography"                 Value="XS85"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
            
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluOstogram"                 Text="" Width="5px" style="vertical-align:top;"                  Value="XS41"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
            <td class="textStyle"><telerik:RadButton    ID="chkFluOstogram"                 Text="Ostogram (Loopogram)"         Value="XS41"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
            
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td> 
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluVideoforEsophagogram"     Text="" Width="5px" style="vertical-align:top;"                  Value="XS70"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluVideoforEsophagogram"     Text="Video for Esophagogram"       Value="XS70"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td> 
                    </tr>
                </table>
            </td>
        </tr>
         <tr>
            <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="Urogenital System"></asp:Label></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluIVP"                      Text="" Width="5px" style="vertical-align:top;"                          Value="XS78"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluIVP"                      Text="IVP"                                  Value="XS78"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluVoidingCystogramCHILD"    Text="" Width="5px" style="vertical-align:top;"                          Value="XSA2"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluVoidingCystogramCHILD"    Text="Voiding Cystogram (เด็ก)[VCUG]"         Value="XSA2"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluVoidingCystogramYOUNG"    Text="" Width="5px" style="vertical-align:top;"                          Value="XSA1"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluVoidingCystogramYOUNG"    Text="Voiding Cystogram (ผู้ใหญ่)[VCUG]"       Value="XSA1"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluUrethrography"            Text="" Width="5px" style="vertical-align:top;"              Value="XS60"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluUrethrography"            Text="Urethrography"            Value="XS60"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluCystography"              Text="" Width="5px" style="vertical-align:top;"              Value="XS31"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluCystography"              Text="Cystography"              Value="XS31"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluHysterosalpingography"    Text="" Width="5px" style="vertical-align:top;"              Value="XS40"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluHysterosalpingography"    Text="Hysterosalpingography"    Value="XS40"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label3" runat="server" Text="Other System"></asp:Label></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluDacryocystography"        Text="" Width="5px" style="vertical-align:top;"              Value="XS32"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluDacryocystography"        Text="Dacryocystography "       Value="XS32"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluSialogramSingle"          Text="" Width="5px" style="vertical-align:top;"              Value="XS84"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluSialogramSingle"          Text="Sialogram [Single]"       Value="XS84"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluFistulography"            Text="" Width="5px" style="vertical-align:top;"              Value="XS35"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluFistulography"            Text="Fistulography"            Value="XS35"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluMyelographyTotal"               Text="" Width="5px" style="vertical-align:top;"              Value="XS49"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluMyelographyTotal"               Text="Myelography , Total"               Value="XS49"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluFluoroscopiconlyFlu"      Text="" Width="5px" style="vertical-align:top;"              Value="XS36"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluFluoroscopiconlyFlu"      Text="Fluoroscopic (only Flu)"  Value="XS36"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="columnBold"><asp:Label ID="Label4" runat="server" Text="Tomography"></asp:Label></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluTomographyBone"           Text="" Width="5px" style="vertical-align:top;"              Value="XS100"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluTomographyBone"           Text="Tomography (Bone)"        Value="XS100"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" style="top: 0px; left: 0px"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluTomographyWholeLung"      Text="" Width="5px" style="vertical-align:top;"              Value="XS59"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluTomographyWholeLung"      Text="Tomography (Whole Lung)"  Value="XS59"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluTomosynthesis"            Text="" Width="5px" style="vertical-align:top;"              Value="XS101"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluTomosynthesis"            Text="Tomosynthesis"            Value="XS101"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td></td>
            <td class="textStyle" colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFluTomographyOthers"         Text="" Width="5px" style="vertical-align:top;"              Value="XS58"    runat="server" ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFluTomographyOthers"         Text="Tomography  (Others)"     Value="XS58"    runat="server" ButtonType="ToggleButton" GroupName="US"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</div>
	</form>
</body>
</html>
