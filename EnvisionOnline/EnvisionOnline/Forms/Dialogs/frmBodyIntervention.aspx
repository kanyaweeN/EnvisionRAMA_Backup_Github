<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBodyIntervention.aspx.cs"
    Inherits="frmBodyIntervention" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Body Intervention</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        body
        {
            margin: 0 0 0 0;
            font-family: MS Sans Serif;
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
    <script type="text/javascript">
	    
    </script>
    <telerik:RadCodeBlock ID="blockGrid" runat="server">
        <script type="text/javascript">
            function OnClientClose() {
                GetRadWindow().close();
            }
            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
                return oWindow;
            }
            function SetTab(sTabText) {
                window.setTimeout(function () {
                    var tab = $find("tabMainRiskManagement").findTabByValue(sTabText);
                    if (tab != null) {
                        tab.set_selected(true);
                    }
                }, 100);
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function set_AjaxRequest(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
            function showNormalAlert(args) {
                switch (args) {
                    case 'RiskManagement':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox2.aspx?FROM=" + args, "windowOnlineMessageBox");
                        break;
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkOrganThyroid" />
                    <telerik:AjaxUpdatedControl ControlID="chkOrganCervical" />
                    
                    <telerik:AjaxUpdatedControl ControlID="chkRight" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeft" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightUpper" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightMiddle" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightLower" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftUpper" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftMiddle" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftLower" />
                    <telerik:AjaxUpdatedControl ControlID="chkOther" />
                    <telerik:AjaxUpdatedControl ControlID="txtOther" />

                    <telerik:AjaxUpdatedControl ControlID="chkImagingYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingMRI" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingCT" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUS" />
                    <telerik:AjaxUpdatedControl ControlID="dateImaging" />

                    <telerik:AjaxUpdatedControl ControlID="chkImagingNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUSNeck" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUSThyroid" />

                    <telerik:AjaxUpdatedControl ControlID="chkDrugYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkDrugNo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkOrganThyroid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkOrganThyroid" />
                    <telerik:AjaxUpdatedControl ControlID="chkOrganCervical" />

                    <telerik:AjaxUpdatedControl ControlID="chkRight" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeft" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightUpper" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightMiddle" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightLower" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftUpper" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftMiddle" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftLower" />
                    <telerik:AjaxUpdatedControl ControlID="chkOther" />
                    <telerik:AjaxUpdatedControl ControlID="txtOther" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkOrganCervical">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkOrganThyroid" />
                    <telerik:AjaxUpdatedControl ControlID="chkOrganCervical" />

                    <telerik:AjaxUpdatedControl ControlID="chkRight" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeft" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightUpper" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightMiddle" />
                    <telerik:AjaxUpdatedControl ControlID="chkRightLower" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftUpper" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftMiddle" />
                    <telerik:AjaxUpdatedControl ControlID="chkLeftLower" />
                    <telerik:AjaxUpdatedControl ControlID="chkOther" />
                    <telerik:AjaxUpdatedControl ControlID="txtOther" />
                </UpdatedControls>
            </telerik:AjaxSetting><telerik:AjaxSetting AjaxControlID="chkOther">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkOther" />
                    <telerik:AjaxUpdatedControl ControlID="txtOther" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="chkImagingYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkImagingYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingMRI" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingCT" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUS" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUSNeck" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUSThyroid" />
                    <telerik:AjaxUpdatedControl ControlID="dateImaging" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkImagingNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkImagingYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingMRI" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingCT" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUS" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUSNeck" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUSThyroid" />
                    <telerik:AjaxUpdatedControl ControlID="dateImaging" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkImagingMRI">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkImagingMRI" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingCT" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUS" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkImagingCT">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkImagingMRI" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingCT" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUS" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkImagingUS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkImagingMRI" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingCT" />
                    <telerik:AjaxUpdatedControl ControlID="chkImagingUS" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkDrugYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkDrugYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkDrugNo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkDrugNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkDrugYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkDrugNo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnSave" />
                    <telerik:AjaxUpdatedControl ControlID="lblAlert" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--<telerik:AjaxSetting AjaxControlID="btnCancle">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnCancle" />
                    <telerik:AjaxUpdatedControl ControlID="tbRisk" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="False" VisibleStatusbar="false"
        runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="windowOnlineMessageBox" runat="server" Behaviors="Close, Move"
                AutoSizeBehaviors="HeightProportional" Modal="true" Width="600" Height="250"
                NavigateUrl="~/Forms/Dialogs/OnlineMessageBox2.aspx" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table cellpadding="0" cellspacing="0" style="border-spacing: 0px" width="100%">
        <tr>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" style="border-spacing: 4px; padding: 0 0 0 0;"
                    width="100%" id="tbRisk">
                    <tr>
                        <td align="center">
                            <%--<asp:Label ID="Label3" runat="server" Text="กรุณาประเมินความเสี่ยงของคนไข้ ก่อนรับการตรวจ" Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="Larger"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" style="border-spacing: 4px; padding: 0 0 0 0;">
                                <tr style="width: 100%">
                                    <td colspan="4">
                                        <asp:Label ID="lblOrgan" runat="server" Font-Bold="true" Text="Organ"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <telerik:RadButton ID="chkOrganThyroid" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="Radio" GroupName="chkOrgan" Text="Thyroid" OnCheckedChanged="chkOrgan_CheckedChanged"
                                                        style="top: 0px; left: 0px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <telerik:RadButton ID="chkOrganCervical" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="Radio" GroupName="chkOrgan" Text="Cervical lymph node" OnCheckedChanged="chkOrgan_CheckedChanged"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr style="width: 100%">
                                    <td>
                                        <asp:Label ID="lblSide" runat="server" Font-Bold="true" Text="Side"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 50px">
                                                    <%--<asp:Label ID="lblRight" runat="server" Text="Right" Font-Bold="False" 
                                                        Font-Size="Small"></asp:Label>
--%>
                                                        <telerik:RadButton ID="chkRight" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="CheckBox" GroupName="chkSide" Text="Right" 
                                                        style="top: 1px; left: 0px" />
                                                </td>

                                                <td>
                                                    <telerik:RadButton ID="chkRightUpper" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="CheckBox" GroupName="chkRight" Text="Right Upper" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkRightMiddle" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="CheckBox" GroupName="chkRight" Text="Right Middle" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkRightLower" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="CheckBox" GroupName="chkRight" Text="Right Lower" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   <%-- <asp:Label ID="lblLeft" runat="server" Text="Left" Font-Bold="False" 
                                                        Font-Size="Small"></asp:Label>
                                                        --%>
                                                        <telerik:RadButton ID="chkLeft" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="CheckBox" GroupName="chkSide" Text="Left" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkLeftUpper" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="CheckBox" GroupName="chkLeft" Text="Left Upper" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkLeftMiddle" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="CheckBox" GroupName="chkLeft" Text="Left Middle" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkLeftLower" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="CheckBox" GroupName="chkLeft" Text="Left Lower" />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td colspan = "1">
                                                    <telerik:RadButton ID="chkOther" runat="server" ButtonType="ToggleButton" OnCheckedChanged="chkOther_CheckedChanged"
                                                        ToggleType="CheckBox" GroupName="chkOther" Text="Other" />
                                                </td>
                                                 <td colspan = "3">
                                                    <telerik:RadTextBox ID="txtOther" runat="server" TextMode="SingleLine" Width="99%"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="lblImaging" runat="server" Font-Bold="true" Text="มี Imaging ภายใน 1 ปี"
                                            Width="190px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 50px">
                                                    <telerik:RadButton ID="chkImagingYes" runat="server" ButtonType="ToggleButton" ToggleType="Radio"
                                                        GroupName="chkImaging" Text="Yes" OnCheckedChanged="chkImaging_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkImagingMRI" runat="server" ButtonType="ToggleButton" ToggleType="Radio"
                                                        GroupName="chkImagingYes" Text="MRI" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkImagingCT" runat="server" ButtonType="ToggleButton" ToggleType="Radio"
                                                        GroupName="chkImagingYes" Text="CT" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkImagingUS" runat="server" ButtonType="ToggleButton" ToggleType="Radio"
                                                        GroupName="chkImagingYes" Text="US" />
                                                </td> 
                                                <td >
                                                    <telerik:RadDateTimePicker ID="dateImaging" runat="server" Culture="th-TH">
                                                        <TimeView CellSpacing="-1" Culture="th-TH"></TimeView>
                                                        <TimePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></TimePopupButton>
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput ID="DateInput1" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"></DateInput>
                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDateTimePicker>
	                                            </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 50px">
                                                    <telerik:RadButton ID="chkImagingNo" runat="server" ButtonType="ToggleButton" ToggleType="Radio"
                                                            GroupName="chkImaging" Text="No" OnCheckedChanged="chkImaging_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <telerik:RadButton    ID="chkImagingUSNeck"   runat="server" ButtonType="ToggleButton" GroupName="chkImagingNo"  
                                                    Text="US Neck"    ToggleType="CheckBox"       Value="XU11"></telerik:RadButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                     <telerik:RadButton    ID="chkImagingUSThyroid"   runat="server" ButtonType="ToggleButton" GroupName="chkImagingNo"  
                                                     Text="US Thyroid"    ToggleType="CheckBox"       Value="XU02"></telerik:RadButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDrug" runat="server" Font-Bold="true" Text="มีประวัติได้รับยา antiplatelet or anticogulant"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <telerik:RadButton ID="chkDrugYes" runat="server" ButtonType="ToggleButton" ToggleType="Radio"
                                                        GroupName="chkDrug" Text="Yes" />
                                                </td>
                                                <td style="width: 10px">
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="ถ้าสามารถหยุดยาได้ให้หยุดยาก่อนทำหัตถการ"
                                                        Font-Size="Small" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <telerik:RadButton ID="chkDrugNo" runat="server" ButtonType="ToggleButton" ToggleType="Radio"
                                                        GroupName="chkDrug" Text="No" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <asp:Label ID="Label17" runat="server" Text="หมายเหตุ" Width="80px"></asp:Label>
                <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="Red" Font-Bold="true"
                    Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr align="center">
        <td >
            <table>
                <tr>
                    <td >
                        <telerik:RadButton ID="btnSave" runat="server" Text="Save" Width="100px" AutoPostBack="true"
                            OnClick="btnSave_Click">
                        </telerik:RadButton>
                    </td>
                    <td >
                        <telerik:RadButton ID="btnCancle" runat="server" Text="Cancel" Width="100px" AutoPostBack="true"
                            OnClick="btnCancle_Click">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </td >
           
        </tr>
    </table>
    </form>
</body>
</html>
