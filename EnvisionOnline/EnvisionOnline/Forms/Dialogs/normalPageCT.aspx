<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normalPageCT.aspx.cs" Inherits="normalPageCT" %>

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
        	height:20px;
        	width:100px;
            text-align:center;
        	color: #f9f9f9;
            font-size :  medium;
        }
        .textStyle
        {
        	Font-Size:x-small;
            vertical-align:top;	
        	height:5px;
        	width:100px;
        	text-align:left;
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
	    
    </script>
    <telerik:RadCodeBlock ID="blockGrid" runat="server">
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
                     <telerik:AjaxUpdatedControl ControlID="chksr_RoutineBrain"/>
                     <telerik:AjaxUpdatedControl ControlID="chksr_Skull_Orbit" />
                     <telerik:AjaxUpdatedControl ControlID="chksr_Pitui" />
                     <telerik:AjaxUpdatedControl ControlID="chksr_IAC" />
                     <telerik:AjaxUpdatedControl ControlID="chkHeadNeck_PS" />
                     <telerik:AjaxUpdatedControl ControlID="chkchkNASOPHARYNX" />
                     <telerik:AjaxUpdatedControl ControlID="chkHeadNeck_SS"/>
                     <telerik:AjaxUpdatedControl ControlID="chkHeadNeck_Thyrold"/>
                     <telerik:AjaxUpdatedControl ControlID="chkHeadNeckOral"/>
                     <telerik:AjaxUpdatedControl ControlID="chkchkORALCAVITY"/>
                     <telerik:AjaxUpdatedControl ControlID="chkHeadNeck_Airway"/>
                     <telerik:AjaxUpdatedControl ControlID="chkHeadNeck_Larynx"/>
                     <telerik:AjaxUpdatedControl ControlID="chkHeadNeck_Neck"/>
                     <telerik:AjaxUpdatedControl ControlID="chkTB_BoneOnly"/>
                     <telerik:AjaxUpdatedControl ControlID="chkTB_Bone"/>
                     <telerik:AjaxUpdatedControl ControlID="chklbChest"/>
                     <telerik:AjaxUpdatedControl ControlID="chkCh_HRCT"/>
                     <telerik:AjaxUpdatedControl ControlID="chkCh_Full"/>
                     <telerik:AjaxUpdatedControl ControlID="chkCardio_Full"/>
                     <telerik:AjaxUpdatedControl ControlID="chkAbd_UP"/>
                     <telerik:AjaxUpdatedControl ControlID="chkAbd_LOW"/>
                     <telerik:AjaxUpdatedControl ControlID="chkAbd_WH"/>
                     <telerik:AjaxUpdatedControl ControlID="chkSp_C"/>
                     <telerik:AjaxUpdatedControl ControlID="chkSp_LS"/>
                     <telerik:AjaxUpdatedControl ControlID="chkSp_T"/>
                     <telerik:AjaxUpdatedControl ControlID="chkSpec_CTC"/>
                     <telerik:AjaxUpdatedControl ControlID="chkSpec_CTT" />
                     <telerik:AjaxUpdatedControl ControlID="chkScr_CAC"/>
                     <telerik:AjaxUpdatedControl ControlID="chkCTACoronoryArtery" />
                     <telerik:AjaxUpdatedControl ControlID="chkAbd_KUB" />
                     <telerik:AjaxUpdatedControl ControlID="chkScr_Others" />

                     <telerik:AjaxUpdatedControl ControlID="favsr_RoutineBrain"/>
                     <telerik:AjaxUpdatedControl ControlID="favsr_Skull_Orbit" />
                     <telerik:AjaxUpdatedControl ControlID="favsr_Pitui" />
                     <telerik:AjaxUpdatedControl ControlID="favsr_IAC" />
                     <telerik:AjaxUpdatedControl ControlID="favHeadNeck_PS" />
                     <telerik:AjaxUpdatedControl ControlID="favchkNASOPHARYNX" />
                     <telerik:AjaxUpdatedControl ControlID="favHeadNeck_SS"/>
                     <telerik:AjaxUpdatedControl ControlID="favHeadNeck_Thyrold"/>
                     <telerik:AjaxUpdatedControl ControlID="favHeadNeckOral"/>
                     <telerik:AjaxUpdatedControl ControlID="favchkORALCAVITY"/>
                     <telerik:AjaxUpdatedControl ControlID="favHeadNeck_Airway"/>
                     <telerik:AjaxUpdatedControl ControlID="favHeadNeck_Larynx"/>
                     <telerik:AjaxUpdatedControl ControlID="favHeadNeck_Neck"/>
                     <telerik:AjaxUpdatedControl ControlID="favTB_BoneOnly"/>
                     <telerik:AjaxUpdatedControl ControlID="favTB_Bone"/>
                     <telerik:AjaxUpdatedControl ControlID="favlbChest"/>
                     <telerik:AjaxUpdatedControl ControlID="favCh_HRCT"/>
                     <telerik:AjaxUpdatedControl ControlID="favCh_Full"/>
                     <telerik:AjaxUpdatedControl ControlID="favCardio_Full"/>
                     <telerik:AjaxUpdatedControl ControlID="favAbd_UP"/>
                     <telerik:AjaxUpdatedControl ControlID="favAbd_LOW"/>
                     <telerik:AjaxUpdatedControl ControlID="favAbd_WH"/>
                     <telerik:AjaxUpdatedControl ControlID="favSp_C"/>
                     <telerik:AjaxUpdatedControl ControlID="favSp_LS"/>
                     <telerik:AjaxUpdatedControl ControlID="favSp_T"/>
                     <telerik:AjaxUpdatedControl ControlID="favSpec_CTC"/>
                     <telerik:AjaxUpdatedControl ControlID="favSpec_CTT" />
                     <telerik:AjaxUpdatedControl ControlID="favScr_CAC"/>
                     <telerik:AjaxUpdatedControl ControlID="favCTACoronoryArtery" />
                     <telerik:AjaxUpdatedControl ControlID="favAbd_KUB" />
                     <telerik:AjaxUpdatedControl ControlID="favScr_Others" />

                     <telerik:AjaxUpdatedControl ControlID="favCTABrain" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTABrain" />
                     <telerik:AjaxUpdatedControl ControlID="favCTANeck" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTANeck" />
                     <telerik:AjaxUpdatedControl ControlID="favCTAAorta" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTAAorta" />
                     <telerik:AjaxUpdatedControl ControlID="favCTAWholeAorta" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTAWholeAorta" />
                     <telerik:AjaxUpdatedControl ControlID="favCTAForPE" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTAForPE" />
                     <telerik:AjaxUpdatedControl ControlID="favCTAPeripheralRunOff" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTAPeripheralRunOff" />
                     <telerik:AjaxUpdatedControl ControlID="favCTARenalArtery" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTARenalArtery" />
                     <telerik:AjaxUpdatedControl ControlID="favCTShoulderJT" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTShoulderJT" />
                     <telerik:AjaxUpdatedControl ControlID="favCTElbowJT" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTElbowJT" />
                     <telerik:AjaxUpdatedControl ControlID="favCTWristJT" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTWristJT" />
                     <telerik:AjaxUpdatedControl ControlID="favCTHipJT" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTHipJT" />
                     <telerik:AjaxUpdatedControl ControlID="favCTKneeJT" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTKneeJT" />
                     <telerik:AjaxUpdatedControl ControlID="favCTAnkleJT" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTAnkleJT" />
                     <telerik:AjaxUpdatedControl ControlID="favCTFoot" />
                     <telerik:AjaxUpdatedControl ControlID="chkCTFoot" />
                     <telerik:AjaxUpdatedControl ControlID="favAbd_CTAppendix" />
                     <telerik:AjaxUpdatedControl ControlID="chkAbd_CTAppendix" />
                     <telerik:AjaxUpdatedControl ControlID="fav3DCTSCAN" />
                     <telerik:AjaxUpdatedControl ControlID="chk3DCTSCAN" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
	</telerik:RadAjaxManager>
	<div>
    <table width="100%">
        <tr>
            <td align="center" class="header" colspan="2">
                  <asp:Label ID="lbPOInvest" runat="server" Text="Parts Of Investgation"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%">
                    <tr>
                        <td class="columnBold" ><asp:Label ID="lbSrin" runat="server" Text="Brain"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favsr_RoutineBrain"     Text="" Width="5px" style="vertical-align:top;"          Value="XC01"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chksr_RoutineBrain"     Text="CT Brain(Routine)"        Value="XC01"    runat="server" ButtonType="ToggleButton" GroupName="groupCT" ToggleType="CheckBox" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favsr_Pitui"    Text="" Width="5px" style="vertical-align:top;"  Value="XC81"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chksr_Pitui"    Text="CT Pituitary"    Value="XC81"    runat="server" ButtonType="ToggleButton" GroupName="groupCT" ToggleType="CheckBox" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="favsr_IAC"      Text="" Width="5px" style="vertical-align:top;"  Value="XC09"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chksr_IAC"      Text="CT IAC"          Value="XC09"    runat="server" ButtonType="ToggleButton" GroupName="groupCT" ToggleType="CheckBox" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton     ID="favsr_Skull_Orbit"            Text="" Width="5px" style="vertical-align:top;"                      Value="XC03"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton        ID="chksr_Skull_Orbit"            Text="CT Orbit"   Value="XC03"           runat="server" ButtonType="ToggleButton" GroupName="groupCT" ToggleType="CheckBox" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="columnBold"><asp:Label ID="lbHead_Neck" runat="server" Text="HeadAndNeck"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favHeadNeck_SS"         Text="" Width="5px" style="vertical-align:top;"          Value="XC06"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkHeadNeck_SS"         Text="CT Screening Sinuses"    Value="XC06"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favHeadNeck_PS"         Text="" Width="5px" style="vertical-align:top;"          Value="XC05"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkHeadNeck_PS"         Text="CT Paranasal Sinuses"    Value="XC05"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="favHeadNeck_Neck"       Text="" Width="5px" style="vertical-align:top;"  Value="XC12"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkHeadNeck_Neck"       Text="CT Neck"         Value="XC12"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favchkNASOPHARYNX"      Text="" Width="5px" style="vertical-align:top;"          Value="XC08"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkchkNASOPHARYNX"      Text="CT Nasopharynx"          Value="XC08"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favHeadNeckOral"        Text="" Width="5px" style="vertical-align:top;"  Value="XC79"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkHeadNeckOral"        Text="CT Oropharynx"   Value="XC79"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>          
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favchkORALCAVITY"       Text="" Width="5px" style="vertical-align:top;"  Value="XC77"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkchkORALCAVITY"       Text="CT Oral Cavity"  Value="XC77"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favHeadNeck_Thyrold"    Text="" Width="5px" style="vertical-align:top;"  Value="XC82"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkHeadNeck_Thyrold"    Text="CT Thyroid"      Value="XC82"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <%--<td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favHeadNeck_Airway"         Text="" Width="5px" style="vertical-align:top;"  Value="XC66"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkHeadNeck_Airway"         Text="Airway"       Value="XC66"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                        <td class="favoritStyle"><telerik:RadButton             ID="favHeadNeck_Larynx"         Text="" Width="5px" style="vertical-align:top;"          Value="XC80"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                        <td class="textStyle"><telerik:RadButton    ID="chkHeadNeck_Larynx"         Text="Larynx/Hypopharynx"   Value="XC80"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged" ></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>--%>
                    </tr>
                    <tr>
                        <td class="columnBold"><asp:Label Text="Temporal Bone" ID="lbTemporalBone" runat="server"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="favTB_BoneOnly"     Text="" Width="5px" style="vertical-align:top;"  Value="XC10"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkTB_BoneOnly"     Text="CT Bone Only"    Value="XC10"    runat="server"      ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="columnBold"><asp:Label Text="Chest" ID="lbChest" runat="server"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="favCh_Full"     Text="" Width="5px" style="vertical-align:top;"          Value="XC13"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCh_Full"     Text="CT Full Chest Study"     Value="XC13"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="favCh_HRCT"     Text="" Width="5px" style="vertical-align:top;"          Value="XC105"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkCh_HRCT"     Text="High resolotion CT chest (HRCT)"                 Value="XC105"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
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
                        <td class="columnBold"><asp:Label ID="lbCardiovascular" runat="server" Text="Cardiovascular System"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="favCardio_Full"         Text="" Width="5px" style="vertical-align:top;"          Value="XC65"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton   ID="chkCardio_Full"         Text="CT Full Cardiac Study"   Value="XC65"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTACoronoryArtery"     Text="" Width="5px" style="vertical-align:top;"              Value="XC65"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTACoronoryArtery"     Text="CTA Coronary Artery"            Value="XC65"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td> 
                         <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favScr_CAC"     Text="" Width="5px" style="vertical-align:top;"              Value="XC41"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkScr_CAC"     Text="CT Screening CAC"            Value="XC41"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td> 
                    </tr>
                    <tr>
                        <td class="columnBold"><asp:Label ID="lbAbdomen" runat="server" Text="Abdomen"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favAbd_UP"          Text="" Width="5px" style="vertical-align:top;"  Value="XC16"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkAbd_UP"          Text="CT Upper Abdomen"        Value="XC16"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favAbd_LOW"         Text="" Width="5px" style="vertical-align:top;"  Value="XC17"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkAbd_LOW"         Text="CT Lower Abdomen"        Value="XC17"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>         
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favAbd_WH"          Text="" Width="5px" style="vertical-align:top;"  Value="XC18"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkAbd_WH"          Text="CT Whole Abdomen"        Value="XC18"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favAbd_KUB"          Text="" Width="5px" style="vertical-align:top;"  Value="XC031"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkAbd_KUB"          Text="CT KUB"        Value="XC031"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favAbd_CTAppendix"          Text="" Width="5px" style="vertical-align:top;"  Value="XC044"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkAbd_CTAppendix"          Text="CT Appendix"        Value="XC044"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            
                        </td>
                        <td colspan="2">
                            
                        </td>
                        <td colspan="2">
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="columnBold"><asp:Label ID="lbSpine" runat="server" Text="Spine"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favSp_C"        Text="" Width="5px" style="vertical-align:top;"  Value="XC21"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkSp_C"        Text="CT C-Spine"      Value="XC21"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favSp_T"        Text="" Width="5px" style="vertical-align:top;"  Value="XC22"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkSp_T"        Text="CT T-Spine"      Value="XC22"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favSp_LS"       Text="" Width="5px" style="vertical-align:top;"  Value="XC23"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkSp_LS"       Text="CT L-S Spine"    Value="XC23"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>        
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="columnBold"><asp:Label ID="Label2" runat="server" Text="MSK"></asp:Label></td>
                        <td colspan="2">
                            <%--<table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTShoulderJT"        Text="" Width="5px" style="vertical-align:top;"  Value="XC24"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTShoulderJT"        Text="CT Shoulder JT."      Value="XC24"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>--%>
                        </td>
                        <td colspan="2">
                           <%-- <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTElbowJT"        Text="" Width="5px" style="vertical-align:top;"  Value="XC25"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTElbowJT"        Text="CT Elbow JT."      Value="XC25"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>--%>
                        </td>
                        <td colspan="2">
                            <%--<table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTWristJT"        Text="" Width="5px" style="vertical-align:top;"  Value="XC26"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTWristJT"        Text="CT Wrist JT."      Value="XC26"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>--%>
                        </td>
                        <td colspan="2">
                           <%-- <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTHipJT"        Text="" Width="5px" style="vertical-align:top;"  Value="XC27"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTHipJT"        Text="CT Hip JT."      Value="XC27"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>--%>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">
                            <%--<table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTKneeJT"        Text="" Width="5px" style="vertical-align:top;"  Value="XC28"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTKneeJT"        Text="CT Knee JT."      Value="XC28"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>--%>
                        </td>
                        <td colspan="2">
                            <%--<table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTAnkleJT"        Text="" Width="5px" style="vertical-align:top;"  Value="XC29"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTAnkleJT"        Text="CT Ankle JT."      Value="XC29"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>--%>
                        </td>
                        <td colspan="2">
                            <%--<table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTFoot"        Text="" Width="5px" style="vertical-align:top;"  Value="XC92"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTFoot"        Text="CT Foot"      Value="XC92"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="columnBold"><asp:Label ID="Label1" runat="server" Text="Special"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTABrain"        Text="" Width="5px" style="vertical-align:top;"  Value="XC78"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTABrain"        Text="CTA Brain"      Value="XC78"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTANeck"        Text="" Width="5px" style="vertical-align:top;"  Value="XC86"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTANeck"        Text="CTA Neck"      Value="XC86"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTAAorta"        Text="" Width="5px" style="vertical-align:top;"  Value="XC59"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTAAorta"        Text="CTA Aorta"      Value="XC59"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTAWholeAorta"        Text="" Width="5px" style="vertical-align:top;"  Value="XC61"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTAWholeAorta"        Text="CTA Whole Aorta"      Value="XC61"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTAForPE"        Text="" Width="5px" style="vertical-align:top;"  Value="XC62"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTAForPE"        Text="CTA For PE"      Value="XC62"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTAPeripheralRunOff"        Text="" Width="5px" style="vertical-align:top;"  Value="XC63"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTAPeripheralRunOff"        Text="CTA Peripheral Run Off"      Value="XC63"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favCTARenalArtery"        Text="" Width="5px" style="vertical-align:top;"  Value="XC64"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkCTARenalArtery"        Text="CTA Renal Artery"      Value="XC64"    runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="columnBold"><asp:Label ID="lbSpecial" runat="server" Text="Special Study"></asp:Label></td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="favSpec_CTC"    Text="" Width="5px" style="vertical-align:top;"              Value="XC96"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                        <td class="textStyle" colspan="1"><telerik:RadButton    ID="chkSpec_CTC"    Text="CT Colonoscopy"           Value="XC96" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                        
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="favSpec_CTT"    Text="" Width="5px" style="vertical-align:top;"              Value="XC66"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkSpec_CTT"    Text="CT Tracheobronchoscopy"   Value="XC66"  runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2">
                            <%--<table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton             ID="fav3DCTSCAN"    Text="" Width="5px" style="vertical-align:top;"              Value="XC050"   runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chk3DCTSCAN"    Text="3D CT SCAN "   Value="XC050"  runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>--%>
                        </td>
                        <%--<td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td class="favoritStyle"><telerik:RadButton ID="favScr_Others"  Text="" Width="5px" style="vertical-align:top;"      Value="OTH"    runat="server"       ButtonType="ToggleButton" GroupName="FAV"  ToggleType="CustomToggle"   OnClick="Favorite_Click" ><Icon PrimaryIconUrl = "../../Resources/ICON/favorite_gray_12.png"  /></telerik:RadButton></td>
                                    <td class="textStyle"><telerik:RadButton    ID="chkScr_Others"  Text="Others"           Value="OTH"     runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" GroupName="groupCT" OnCheckedChanged="chekbox_CheckedChanged"></telerik:RadButton></td>
                                </tr>
                            </table>
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
    </table>   
	</div>
	</form>
</body>
</html>