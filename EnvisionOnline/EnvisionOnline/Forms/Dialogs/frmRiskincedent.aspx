<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRiskincedent.aspx.cs" Inherits="frmRiskincedent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Risk Management</title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" />
    <style type="text/css">
        body
        {
            margin:0 0 0 0;
            font-family:MS Sans Serif;
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
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox2.aspx?FROM="  + args , "windowOnlineMessageBox");
                        break;
                }
            }
        </script>
    </telerik:RadCodeBlock>
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkUseContrastYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkUseContrastNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtUseContrast" />
                    <telerik:AjaxUpdatedControl ControlID="txtLastestResultDate" />
                    <telerik:AjaxUpdatedControl ControlID="txtgfr" />
                    
                    <telerik:AjaxUpdatedControl ControlID="txtCreatinine" />
                    <telerik:AjaxUpdatedControl ControlID="tabMainRiskManagement" />

                    <telerik:AjaxUpdatedControl ControlID="chkWearingMetalEquipmentInTheBodyYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkWearingMetalEquipmentInTheBodyNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtWearingMetalEquipmentInTheBody" />

                    <telerik:AjaxUpdatedControl ControlID="chkThreadLiftingYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkThreadLiftingNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtThreadLifting" />

                    <telerik:AjaxUpdatedControl ControlID="chkMetalInEyeYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkMetalInEyeNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtMetalInEye" />

                    <telerik:AjaxUpdatedControl ControlID="chkInsertTheMetalTracheaTubeYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkInsertTheMetalTracheaTubeNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtInsertTheMetalTracheaTube" />

                    <telerik:AjaxUpdatedControl ControlID="chkWearBracesYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkWearBracesNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtWearBraces" />

                    <telerik:AjaxUpdatedControl ControlID="chkPermanentRadiationImplantationYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkPermanentRadiationImplantationNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtPermanentRadiationImplantation" />

                    <telerik:AjaxUpdatedControl ControlID="chkClaustrophobiaYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkClaustrophobiaNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtClaustrophobia" />

                    <telerik:AjaxUpdatedControl ControlID="chkPregnantMRIYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkPregnantMRINo" />
                    <telerik:AjaxUpdatedControl ControlID="txtPregnantMRI" />

                    <telerik:AjaxUpdatedControl ControlID="chkAllergicMRIContrastMediaYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicMRIContrastMediaNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtAllergicMRIContrastMedia" />

                    <telerik:AjaxUpdatedControl ControlID="chkIodineAllergyYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkIodineAllergyNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtIodineAllergy" />

                    <telerik:AjaxUpdatedControl ControlID="chkFoodAllergyYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkFoodAllergyNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtFoodAllergy" />

                    <telerik:AjaxUpdatedControl ControlID="chkAsthmaYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkAsthmaNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtAsthma" />

                    <telerik:AjaxUpdatedControl ControlID="chkKidneydiseaseYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneydiseaseNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtKidneydisease" />

                    <telerik:AjaxUpdatedControl ControlID="chkKidneytransplantYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneytransplantNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtKidneytransplant" />

                    <telerik:AjaxUpdatedControl ControlID="chkPregnantCTYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkPregnantCTNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtPregnantCT" />

                    <telerik:AjaxUpdatedControl ControlID="chkAllergicCTYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicCTNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtAllergicCT" />

                    <telerik:AjaxUpdatedControl ControlID="btnSave" />
                    <%--<telerik:AjaxUpdatedControl ControlID="btnCancle" />--%>
                    <telerik:AjaxUpdatedControl ControlID="tbRisk"  LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkUseContrastYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkUseContrastYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtUseContrast" />
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicMRIContrastMediaYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicMRIContrastMediaNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkIodineAllergyYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkIodineAllergyNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkFoodAllergyYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkFoodAllergyNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkAsthmaYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkAsthmaNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneydiseaseYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneydiseaseNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneytransplantYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneytransplantNo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkUseContrastNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkUseContrastNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtUseContrast" />
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicMRIContrastMediaYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicMRIContrastMediaNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkIodineAllergyYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkIodineAllergyNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkFoodAllergyYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkFoodAllergyNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkAsthmaYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkAsthmaNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneydiseaseYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneydiseaseNo" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneytransplantYes" />
                    <telerik:AjaxUpdatedControl ControlID="chkKidneytransplantNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtAllergicMRIContrastMedia" />
                    <telerik:AjaxUpdatedControl ControlID="txtIodineAllergy" />
                    <telerik:AjaxUpdatedControl ControlID="txtFoodAllergy" />
                    <telerik:AjaxUpdatedControl ControlID="txtAsthma" />
                    <telerik:AjaxUpdatedControl ControlID="txtKidneydisease" />
                    <telerik:AjaxUpdatedControl ControlID="txtKidneytransplant" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkWearingMetalEquipmentInTheBodyYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkWearingMetalEquipmentInTheBodyYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtWearingMetalEquipmentInTheBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkWearingMetalEquipmentInTheBodyNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkWearingMetalEquipmentInTheBodyNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtWearingMetalEquipmentInTheBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkThreadLiftingYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkThreadLiftingYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtThreadLifting" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkThreadLiftingNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkThreadLiftingNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtThreadLifting" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkMetalInEyeYes">
                <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="chkMetalInEyeYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtMetalInEye" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkMetalInEyeNo">
                <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="chkMetalInEyeNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtMetalInEye" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkInsertTheMetalTracheaTubeYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkInsertTheMetalTracheaTubeYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtInsertTheMetalTracheaTube" />
                </UpdatedControls>
            </telerik:AjaxSetting>   
            <telerik:AjaxSetting AjaxControlID="chkInsertTheMetalTracheaTubeNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkInsertTheMetalTracheaTubeNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtInsertTheMetalTracheaTube" />
                </UpdatedControls>
            </telerik:AjaxSetting>   
            <telerik:AjaxSetting AjaxControlID="chkWearBracesYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkWearBracesYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtWearBraces" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkWearBracesNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkWearBracesNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtWearBraces" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkPermanentRadiationImplantationYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkPermanentRadiationImplantationYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtPermanentRadiationImplantation" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkPermanentRadiationImplantationNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkPermanentRadiationImplantationNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtPermanentRadiationImplantation" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkClaustrophobiaYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkClaustrophobiaYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtClaustrophobia" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkClaustrophobiaNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkClaustrophobiaNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtClaustrophobia" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkPregnantMRIYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkPregnantMRIYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtPregnantMRI" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkPregnantMRINo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkPregnantMRINo" />
                    <telerik:AjaxUpdatedControl ControlID="txtPregnantMRI" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkAllergicMRIContrastMediaYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicMRIContrastMediaYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtAllergicMRIContrastMedia" />
                </UpdatedControls>
            </telerik:AjaxSetting>   
            <telerik:AjaxSetting AjaxControlID="chkAllergicMRIContrastMediaNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicMRIContrastMediaNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtAllergicMRIContrastMedia" />
                </UpdatedControls>
            </telerik:AjaxSetting>   
            <telerik:AjaxSetting AjaxControlID="chkIodineAllergyYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkIodineAllergyYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtIodineAllergy" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkIodineAllergyNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkIodineAllergyNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtIodineAllergy" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkFoodAllergyYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkFoodAllergyYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtFoodAllergy" />
                </UpdatedControls>
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="chkFoodAllergyNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkFoodAllergyNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtFoodAllergy" />
                </UpdatedControls>
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="chkAsthmaYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkAsthmaYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtAsthma" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <telerik:AjaxSetting AjaxControlID="chkAsthmaNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkAsthmaNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtAsthma" />
                </UpdatedControls>
            </telerik:AjaxSetting> 
              <telerik:AjaxSetting AjaxControlID="chkKidneydiseaseYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkKidneydiseaseYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtKidneydisease" />
                </UpdatedControls>
            </telerik:AjaxSetting>   
            <telerik:AjaxSetting AjaxControlID="chkKidneydiseaseNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkKidneydiseaseNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtKidneydisease" />
                </UpdatedControls>
            </telerik:AjaxSetting>    
            <telerik:AjaxSetting AjaxControlID="chkKidneytransplantYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkKidneytransplantYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtKidneytransplant" />
                </UpdatedControls>
            </telerik:AjaxSetting>   
            <telerik:AjaxSetting AjaxControlID="chkKidneytransplantNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkKidneytransplantNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtKidneytransplant" />
                </UpdatedControls>
            </telerik:AjaxSetting>   
            
            <telerik:AjaxSetting AjaxControlID="chkPregnantCTYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkPregnantCTYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtPregnantCT" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkPregnantCTNo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkPregnantCTNo" />
                    <telerik:AjaxUpdatedControl ControlID="txtPregnantCT" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="chkAllergicCTYes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkAllergicCTYes" />
                    <telerik:AjaxUpdatedControl ControlID="txtAllergicCT" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            
            <telerik:AjaxSetting AjaxControlID="tabMainRiskManagement">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lbCaution" />
                    <telerik:AjaxUpdatedControl ControlID="txtUseContrast" />
                    <telerik:AjaxUpdatedControl ControlID="multipageMainRisk" />
                    <telerik:AjaxUpdatedControl ControlID="lblAlert" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnSave" />
                    <telerik:AjaxUpdatedControl ControlID="lblAlert" />
                    <telerik:AjaxUpdatedControl ControlID="tbRisk"  LoadingPanelID="RadAjaxLoadingPanel1" />
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
            <telerik:RadWindow ID="windowOnlineMessageBox" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="600" Height="250" NavigateUrl="~/Forms/Dialogs/OnlineMessageBox2.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table cellpadding="0" cellspacing="0" style="border-spacing: 0px" width="100%" >
        <tr>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" style="border-spacing: 4px; padding:0 0 0 0;" width="100%" id="tbRisk">
                    <tr>
                        <td align="center">
                            <asp:Label ID="Label3" runat="server" Text="กรุณาประเมินความเสี่ยงของคนไข้ ก่อนรับการตรวจ" Width="100%" ForeColor="Blue" Font-Bold="true" Font-Size="Larger"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <%--<asp:Label ID="Label18" runat="server" Font-Bold="true" Text="The requested resource is not available." Width="170px"></asp:Label>--%>

                            <table cellpadding="0" cellspacing="0" style="border-spacing: 4px; padding:0 0 0 0;">
                                <tr>
                                    <td>
	                                    <asp:Label ID="lblCreatinine" runat="server" Font-Bold="true" Text="CREATININE (mg/dL) : " Width="190px"></asp:Label>
                                    </td>
                                     <td>
	                                    <asp:Label ID="txtCreatinine" runat="server" Text="-" ></asp:Label>
                                    </td>
                                    <td width="20px"></td>
                                    <td>
	                                    <asp:Label ID="Label14" runat="server" Font-Bold="true" Text="" Width="190px">GFR (ml/min/1.73m<sup>2</sup>) : </asp:Label>
                                    </td>
                                     <td>
	                                    <asp:Label ID="txtgfr" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Font-Bold="true" Text="Reported date : " Width="190px"></asp:Label>
                                    </td>
                                    <td>
	                                    <asp:Label ID="txtLastestResultDate" runat="server" Text="-"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td colspan="2">
                                        <asp:Label ID="lblAlertLastestResultDate" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <table cellpadding="0" cellspacing="0" style="border-spacing: 4px; padding: 0 0 0 0;">
                                            <tr>
                                                <td>
                                                    <telerik:RadButton ID="chkUseContrastNo" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="Radio" GroupName="chkUseContrast" Text="" Value="22" OnCheckedChanged="chkUseContrast_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" Text="Non IV Contrast" Width="120px"></asp:Label>
                                                </td>
                                                <td>
                                                    <telerik:RadButton ID="chkUseContrastYes" runat="server" ButtonType="ToggleButton"
                                                        ToggleType="Radio" GroupName="chkUseContrast" Text="" Value="22" OnCheckedChanged="chkUseContrast_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="IV Contrast" Width="120px"></asp:Label>
                                                </td>
                                                <td width="80%">
                                                    <asp:Label ID="txtUseContrast" runat="server" Text="" Width="100%" Font-Size="Small"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
	                    </td>
                    </tr>
                    <tr>
	                    <td>
                            
	                    </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <telerik:RadTabStrip ID="tabMainRiskManagement" runat="server" 
                                MultiPageID="multipageMainRisk" ontabclick="tabMainRiskManagement_TabClick">
                                <Tabs>
                                    <telerik:RadTab Value="tabMRI" Text="RISK OF MRI STUDY" Selected="true" Width="50%" ImageUrl="../../Resources/ICON/iso-strong-magnetic-field-symbol-is-2006_24.png"></telerik:RadTab>
                                    <telerik:RadTab Value="tabCT" Text="RISK OF CT STUDY" Width="50%" ImageUrl="../../Resources/ICON/precaution24.png"></telerik:RadTab>
                                </Tabs>
                            </telerik:RadTabStrip>
                            <telerik:RadMultiPage ID="multipageMainRisk" runat="server" SelectedIndex="0">
                                <telerik:RadPageView ID="viewRiskOFMRI" runat="server" BorderWidth="1" BorderStyle="Solid" BorderColor="LightBlue" 
                                 Width="100%" Height="100%">
                                    <table cellpadding="1" cellspacing="0" width="100%">
                                        <tr>
                                            <td><asp:Label ID="Label51" runat="server" Text="Yes" Width="40px"></asp:Label></td>
                                            <td><asp:Label ID="Label50" runat="server" Text="No" Width="40px"></asp:Label></td>
                                            <td></td>
                                            <td><asp:Label ID="Label4" runat="server" Text="รายละเอียด"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkClaustrophobiaYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkClaustrophobia"
                                                    Width="40px" Value="23"  OnCheckedChanged="chkClaustrophobia_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkClaustrophobiaNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkClaustrophobia"
                                                    Width="40px" Value="23"  OnCheckedChanged="chkClaustrophobia_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="Claustrophobia : กลัวที่แคบ"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtClaustrophobia" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkThreadLiftingYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkThreadLifting"
                                                    Width="40px" Value="24"  OnCheckedChanged="chkThreadLifting_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkThreadLiftingNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkThreadLifting"
                                                    Width="40px" Value="24"  OnCheckedChanged="chkThreadLifting_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="ศัลยกรรมร้อยไหมที่ใบหน้า"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtThreadLifting" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkWearBracesYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkWearBraces"
                                                    Width="40px" Value="25"  OnCheckedChanged="chkWearBraces_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkWearBracesNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkWearBraces"
                                                    Width="40px" Value="25"  OnCheckedChanged="chkWearBraces_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="ใส่เหล็กจัดฟัน"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtWearBraces" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkWearingMetalEquipmentInTheBodyYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkWearingMetalEquipmentInTheBody"
                                                    Width="40px" Value="32"  OnCheckedChanged="chkWearingMetalEquipmentInTheBody_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkWearingMetalEquipmentInTheBodyNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkWearingMetalEquipmentInTheBody"
                                                    Width="40px" Value="32"  OnCheckedChanged="chkWearingMetalEquipmentInTheBody_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="ผ่าตัดใส่อุปกรณ์โลหะในร่างกาย เช่น plate screwsยึดกระดูก ข้อเข่า ข้อสะโพกเทียม"></asp:Label>
                                                <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtWearingMetalEquipmentInTheBody" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <telerik:RadButton ID="chkInsertTheMetalTracheaTubeYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkInsertTheMetalTracheaTube"
                                                    Width="40px" Value="41"  OnCheckedChanged="chkInsertTheMetalTracheaTube_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkInsertTheMetalTracheaTubeNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkInsertTheMetalTracheaTube"
                                                    Width="40px" Value="41"  OnCheckedChanged="chkInsertTheMetalTracheaTube_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="ใส่ท่อหลอดลมคอชนิดโลหะ"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtInsertTheMetalTracheaTube" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkPermanentRadiationImplantationYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkPermanentRadiationImplantation"
                                                    Width="40px" Value="43"  OnCheckedChanged="chkPermanentRadiationImplantation_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkPermanentRadiationImplantationNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkPermanentRadiationImplantation"
                                                    Width="40px" Value="43"  OnCheckedChanged="chkPermanentRadiationImplantation_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="เคยรักษาแบบฝังสารกัมมันตรังสีแบบถาวรหรือไม่"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtPermanentRadiationImplantation" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkPregnantMRIYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkPregnantMRI"
                                                    Width="40px" Value="44"  OnCheckedChanged="chkPregnantMRI_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkPregnantMRINo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkPregnantMRI"
                                                    Width="40px" Value="44"  OnCheckedChanged="chkPregnantMRI_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text="ตั้งครรภ์"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtPregnantMRI" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr><tr>
                                            <td>
                                                <telerik:RadButton ID="chkMetalInEyeYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkMetalInEye"
                                                    Width="40px" Value="46"  OnCheckedChanged="chkMetalInEye_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkMetalInEyeNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkMetalInEye"
                                                    Width="40px" Value="46"  OnCheckedChanged="chkMetalInEye_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label29" runat="server" Text="มีเศษโลหะฝังในตา"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtMetalInEye" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkAllergicMRIContrastMediaYes" runat="server" ButtonType="ToggleButton"
                                                    ToggleType="Radio" GroupName="chkAllergicMRIContrastMedia" Width="40px"
                                                    Value="47" OnCheckedChanged="chkAllergicMRIContrastMedia_CheckedChanged" />
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkAllergicMRIContrastMediaNo" runat="server" ButtonType="ToggleButton"
                                                    ToggleType="Radio" GroupName="chkAllergicMRIContrastMedia" Width="40px"
                                                    Value="47" OnCheckedChanged="chkAllergicMRIContrastMedia_CheckedChanged" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAllergicMRIContrastMedia" runat="server" Text="มีประวัติแพ้สาร MRI contrast media"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtAllergicMRIContrastMedia" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="viewRiskOFCT" runat="server" BorderWidth="1" BorderStyle="Solid" BorderColor="LightBlue"
                                 Width="100%" Height="270px">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            
                                            <td><asp:Label ID="Label48" runat="server" Text="Yes" Width="40px"></asp:Label></td>
                                            <td><asp:Label ID="Label20" runat="server" Text="No" Width="40px"></asp:Label></td>
                                            <td></td>
                                            <td><asp:Label ID="Label25" runat="server" Text="รายละเอียด"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkFoodAllergyYes" runat="server"  
                                                    ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkFoodAllergy" 
                                                    Value="13"  OnCheckedChanged="chkFoodAllergy_CheckedChanged" 
                                                    style="top: 0px; left: 0px; width: 40px"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkFoodAllergyNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkFoodAllergy"
                                                    Width="40px" Value="13"  OnCheckedChanged="chkFoodAllergy_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label21" runat="server" Text="Food / Seafood Allergy (แพ้อาหาร / อาหารทะเล)"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtFoodAllergy" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkIodineAllergyYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkIodineAllergy"
                                                    Width="40px" Value="15"  OnCheckedChanged="chkIodineAllergy_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkIodineAllergyNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkIodineAllergy"
                                                    Width="40px" Value="15"  OnCheckedChanged="chkIodineAllergy_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Iodine / Contrast Allergy (แพ้สารไอโอดีน / สารทึบรังสี)"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtIodineAllergy" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkAsthmaYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkAsthma"
                                                    Width="40px" Value="16"  OnCheckedChanged="chkAsthma_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkAsthmaNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkAsthma"
                                                    Width="40px" Value="16"  OnCheckedChanged="chkAsthma_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="asthma (หอบหืด)"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtAsthma" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkKidneydiseaseYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkKidneydisease"
                                                    Width="40px" Value="50"  OnCheckedChanged="chkKidneydisease_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkKidneydiseaseNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkKidneydisease"
                                                    Width="40px" Value="50"  OnCheckedChanged="chkKidneydisease_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="มีโรคไต"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtKidneydisease" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkKidneytransplantYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkKidneytransplant"
                                                    Width="40px" Value="17"  OnCheckedChanged="chkKidneytransplant_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkKidneytransplantNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkKidneytransplant"
                                                    Width="40px" Value="17"  OnCheckedChanged="chkKidneytransplant_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label15" runat="server" Text="Kidney transplant (มีไตข้างเดียว หรือเคยปลูกถ่ายไต)"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtKidneytransplant" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkPregnantCTYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkPregnantCT"
                                                    Width="40px" Value="48"  OnCheckedChanged="chkPregnantCT_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkPregnantCTNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkPregnantCT"
                                                    Width="40px" Value="48"  OnCheckedChanged="chkPregnantCT_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="ตั้งครรภ์"></asp:Label>
                                            </td>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtPregnantCT" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="chkAllergicCTYes" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkAllergicCT"
                                                    Width="40px" Value="49"  OnCheckedChanged="chkAllergicCT_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="chkAllergicCTNo" runat="server"  ButtonType="ToggleButton" ToggleType="Radio" GroupName="chkAllergicCT"
                                                    Width="40px" Value="49"  OnCheckedChanged="chkAllergicCT_CheckedChanged"/>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text="มีประวัติการรักษาแบบฝังสารกัมมันตรังสีแบบถาวร"></asp:Label>
                                            </td>             
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td><telerik:RadTextBox ID="txtAllergicCT" runat="server" TextMode="SingleLine" Width="99%" DisabledStyle-BackColor="LightBlue"></telerik:RadTextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:Label ID="Label17" runat="server" Text="หมายเหตุ" Width="80px"></asp:Label>
            <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td align="right"><telerik:RadButton ID="btnSave" runat="server" Text="Save" Width="100px" AutoPostBack="true" OnClick="btnSave_Click"></telerik:RadButton></td>
            <td align="left"><telerik:RadButton ID="btnCancle" runat="server" Text="Cancel" Width="100px" AutoPostBack="true" OnClick="btnCancle_Click"></telerik:RadButton></td>
        </tr>
        <tr>
            <td colspan="2">
                <%--<asp:Label ID="Label61" runat="server" Text="** สามารถข้ามข้อมูลนี้ได้โดยการ กด Save" Width="100%" ForeColor="RosyBrown" Font-Bold="true" Font-Size="Small"></asp:Label>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lbCaution" runat="server" Text="" Width="100%"></asp:Label>
            </td>
        </tr>
    </table>
	</form>
</body>
</html>
