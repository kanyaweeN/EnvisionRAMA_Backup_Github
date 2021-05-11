<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageMR.aspx.cs" Inherits="normalPageMR" %>

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
        </Windows>
        <Windows>
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
                    <telerik:AjaxUpdatedControl ControlID="chkMRI" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRA" />  
                    <telerik:AjaxUpdatedControl ControlID="chkMRVBrain" />
                    <telerik:AjaxUpdatedControl ControlID="chkMR_Brain" />
                    <telerik:AjaxUpdatedControl ControlID="chkFUNCTIONALBRAIN" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRSPECTROSCOPY" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRPERFUSION" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRIMRABrain" />
                    <telerik:AjaxUpdatedControl ControlID="chkNECK" />
                    <telerik:AjaxUpdatedControl ControlID="chkNASOPHARYNX" />
                    <telerik:AjaxUpdatedControl ControlID="chkOROPHARYX" />
                    <telerik:AjaxUpdatedControl ControlID="chkLARYNX" />
                    <telerik:AjaxUpdatedControl ControlID="chkCERVICAL" />
                    <telerik:AjaxUpdatedControl ControlID="chkTHORACIC" />
                    <telerik:AjaxUpdatedControl ControlID="chkLUMBOSACRAL" />
                    <telerik:AjaxUpdatedControl ControlID="chkSPINEWHOLE" />
                    <telerik:AjaxUpdatedControl ControlID="chkUPPER" />
                    <telerik:AjaxUpdatedControl ControlID="chkLOWER" />
                    <telerik:AjaxUpdatedControl ControlID="chkWHOLEABDOMEN" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRCPONLY" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRCPMRIUPPERABDOMEN" />
                    <telerik:AjaxUpdatedControl ControlID="chkPROSTATE" />
                    <telerik:AjaxUpdatedControl ControlID="chkORBIT" />
                    <telerik:AjaxUpdatedControl ControlID="chkPARANASALSINUSES" />
                    <telerik:AjaxUpdatedControl ControlID="chkCHEST" />
                    <telerik:AjaxUpdatedControl ControlID="chkCARDIAC" />
                    <telerik:AjaxUpdatedControl ControlID="chkBREAST" />
                    <telerik:AjaxUpdatedControl ControlID="chkBREAST_BOTH" />
                    <telerik:AjaxUpdatedControl ControlID="chkOTHERS" />

                    <telerik:AjaxUpdatedControl ControlID="favMR_Brain" />
                    <telerik:AjaxUpdatedControl ControlID="favFUNCTIONALBRAIN" />
                    <telerik:AjaxUpdatedControl ControlID="favMRSPECTROSCOPY" />
                    <telerik:AjaxUpdatedControl ControlID="favMRPERFUSION" />
                    <telerik:AjaxUpdatedControl ControlID="favNECK" />
                    <telerik:AjaxUpdatedControl ControlID="favNASOPHARYNX" />
                    <telerik:AjaxUpdatedControl ControlID="favOROPHARYX" />
                    <telerik:AjaxUpdatedControl ControlID="favLARYNX" />
                    <telerik:AjaxUpdatedControl ControlID="favCERVICAL" />
                    <telerik:AjaxUpdatedControl ControlID="favTHORACIC" />
                    <telerik:AjaxUpdatedControl ControlID="favLUMBOSACRAL" />
                    <telerik:AjaxUpdatedControl ControlID="favSPINEWHOLE" />
                    <telerik:AjaxUpdatedControl ControlID="favUPPER" />
                    <telerik:AjaxUpdatedControl ControlID="favLOWER" />
                    <telerik:AjaxUpdatedControl ControlID="favWHOLEABDOMEN" />
                    <telerik:AjaxUpdatedControl ControlID="favMRCPONLY" />
                    <telerik:AjaxUpdatedControl ControlID="favMRCPMRIUPPERABDOMEN" />
                    <telerik:AjaxUpdatedControl ControlID="favPROSTATE" />
                    <telerik:AjaxUpdatedControl ControlID="favORBIT" />
                    <telerik:AjaxUpdatedControl ControlID="favPARANASALSINUSES" />
                    <telerik:AjaxUpdatedControl ControlID="favCHEST" />
                    <telerik:AjaxUpdatedControl ControlID="favCARDIAC" />
                    <telerik:AjaxUpdatedControl ControlID="favBREAST" />
                    <telerik:AjaxUpdatedControl ControlID="favBREAST_BOTH" />
                    <telerik:AjaxUpdatedControl ControlID="favOTHERS" /> 
                    <telerik:AjaxUpdatedControl ControlID="favMRAHeart"/>
                    <telerik:AjaxUpdatedControl ControlID="chkMRAHeart" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkMRI">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkMRI" />
                    <telerik:AjaxUpdatedControl ControlID="LabelTestText" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRA" />  
                    <telerik:AjaxUpdatedControl ControlID="chkMRVBrain" /> 
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkMRA">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkMRI" />
                    <telerik:AjaxUpdatedControl ControlID="LabelTestText" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRA" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkMRVBrain" />   
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkMRVBrain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkMRI" />
                    <telerik:AjaxUpdatedControl ControlID="LabelTestText" />
                    <telerik:AjaxUpdatedControl ControlID="chkMRA" /> 
                    <telerik:AjaxUpdatedControl ControlID="chkMRVBrain" />   
                </UpdatedControls>
            </telerik:AjaxSetting>
         </AjaxSettings>
	</telerik:RadAjaxManager>
	<div>
    <table width="100%">
       <tr>
            <td class="columnBold" colspan="9"><asp:Label ID="lbMr" runat="server" Text="Request For"></asp:Label></td>        
       </tr>
       <tr>
            <td></td>
            <td></td>
            <td class="textStyle" colspan="2"><telerik:RadButton ID="chkMRI" Text="MRI" Value="XM36" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupMRI" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            <td class="textStyle" colspan="2"><telerik:RadButton ID="chkMRA" Text="MR Angiography" Value="XM37" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupMRA" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
            <td class="textStyle" colspan="2"><telerik:RadButton ID="chkMRVBrain" Text="MRV Brain" Value="XM38" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupMRA" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>   
            <td></td>
	   </tr>
       <tr>
            <td class="columnBold" colspan="9"><asp:Label ID="Label7" runat="server" Text="Part Of Be Evaluated"></asp:Label></td>        
       </tr>
       <tr>
            <td class="columnBold"><asp:Label ID="Label8" runat="server" Text="Brain"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMR_Brain"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM11"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMR_Brain"           Text="MRI Brain" Value="XM11" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favFUNCTIONALBRAIN"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM41"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkFUNCTIONALBRAIN"    Text="MRI Functional Brain" Value="XM41" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRSPECTROSCOPY"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM39"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRSPECTROSCOPY"     Text="MRI Spectroscopy" Value="XM39" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRPERFUSION"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM40"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRPERFUSION"        Text="MRI Perfusion" Value="XM40" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
	   </tr>
       <tr>
            <td></td>
            <td>
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"> </td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRIMRABrain"    Text="MRI+MRA Brain" Value="XM11_XM37" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
       </tr>
       <tr>
            <td class="columnBold"><asp:Label ID="Label9" runat="server" Text="Neck"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favNECK"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM17"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkNECK"               Text="MRI Neck" Value="XM17" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favNASOPHARYNX"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM14"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkNASOPHARYNX"        Text="MRI Nasopharynx" Value="XM14" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favOROPHARYX"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM16"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkOROPHARYX"          Text="MRI Oropharynx" Value="XM16" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLARYNX"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM17"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLARYNX"             Text="MRI Larynx" Value="XM17" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td> 
	   </tr>
       <tr>
            <td class="columnBold"><asp:Label ID="Label10" runat="server" Text="Spine"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCERVICAL"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM24"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCERVICAL"           Text="MRI Cervical" Value="XM24" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favTHORACIC"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM25"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkTHORACIC"           Text="MRI Thoracic" Value="XM25" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLUMBOSACRAL"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM26"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLUMBOSACRAL"        Text="MRI Lumbosacral" Value="XM26" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favSPINEWHOLE"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM27"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkSPINEWHOLE"         Text="MRI Whole Spine" Value="XM27" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
	   </tr>
       <tr>
            <td class="columnBold"><asp:Label ID="Label11" runat="server" Text="Abdomen"></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favUPPER"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM21"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkUPPER"              Text="MRI Upper Abdomen" Value="XM21" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favLOWER"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM22"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkLOWER"              Text="MRI Lower Abdomen" Value="XM22" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favWHOLEABDOMEN"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM23"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkWHOLEABDOMEN"       Text="MRI Whole Abdomen" Value="XM23" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            
	   </tr>
       <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRCPMRIUPPERABDOMEN"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM50"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRCPMRIUPPERABDOMEN" Text="MRCP+MRI Upper Abdomen" Value="XM50" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRCPONLY"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM51"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRCPONLY"           Text="MRCP Only" Value="XM51" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favPROSTATE"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM25"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkPROSTATE" Text="MRI Prostate(Endorectal Coil)" Value="XM72" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>            
	   </tr>
       <tr>
            <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Etc."></asp:Label></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favORBIT"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM13"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkORBIT"              Text="MRI Orbit" Value="XM13" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favPARANASALSINUSES"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM15"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkPARANASALSINUSES"   Text="MRI Paranasal Sinuses" Value="XM15" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCHEST"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM19"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCHEST"              Text="MRI Chest" Value="XM19" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favCARDIAC"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM80"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkCARDIAC"            Text="MRI Heart" Value="XM80" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
	   </tr>
       <tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBREAST"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM45"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBREAST"                  Text="MRI Breast" Value="XM45" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favBREAST_BOTH"           Text="" Width="5px" style="vertical-align:top;"                      Value="XM46"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkBREAST_BOTH"    Text="MRI Breast(Both)" Value="XM46" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>     
            <td colspan="2">
            </td>
            <td colspan="2">
                <%--<table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton ID="favMRAHeart"        Text="" Width="5px" style="vertical-align:top;"      Value="XM99"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle"><telerik:RadButton    ID="chkMRAHeart"        Text="MRA Heart"        Value="XM99"    runat="server" ButtonType="ToggleButton" GroupName="MRA"  ToggleType="CheckBox"  OnCheckedChanged="chekbox_CheckedChanged" style="top: 0px; left: 0px"></telerik:RadButton></td>
                    </tr>
                </table>--%>
            </td>         
	   </tr>
       <%--<tr>
            <td></td>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td class="favoritStyle"><telerik:RadButton             ID="favOTHERS"           Text="" Width="5px" style="vertical-align:top;"                      Value="OTH"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="4"><telerik:RadButton    ID="chkOTHERS"         Text="Others" Value="OTH" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="lbMrEvaluated" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                    </tr>
                </table>
            </td>
	   </tr>--%>
	</table>
	</div>
	</form>
</body>
</html>
