<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmEnvisionOrderNW.aspx.cs" Inherits="frmEnvisionOrderNW" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <meta http-equiv="x-ua-compatible" content="IE=8" />
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" CdnSettings-TelerikCdn="Disabled" CdnSettings-BaseUrl="http://miracleonline" />
    <style type="text/css">
        body
        {
            margin:0 0 0 0;
            font-family:MS Sans Serif;
        }
        div.combocss .rcbInputCell .rcbInput
        {
          padding-left: 24px !important;
          background-image: url('../../Resources/ICON/viewtree_24.png');
          background-repeat: no-repeat;
        }
         .textButton
        {
            text-align:left;
            vertical-align:text-top;
        }

        /** Customize the demo canvas */
.qsf-demo-canvas {}
 
 
     .qsf-demo-canvas fieldset {}
     .qsf-demo-canvas label {
          width: 100px;
          display: inline-block;
     }
 
     .qsf-demo-canvas ul {
          margin: 0;
          padding: 0;
          list-style: none;
     }
     .qsf-demo-canvas li {
          margin: 5px 0;
          min-height: 30px;
     }
 
 
/** Customize the control */
.qsf-demo-canvas .RadComboBox {
     display: inline-block;
}
 
.qsf-comparisson-table {
     width: 350px;
     float: right;
     clear: right;
}
     .qsf-comparisson-table table {
          width: 100%;
          border-collapse: collapse;
          border-spacing: 0;
          border: 0;
          background: #e0e0e0;
          table-layout: fixed;
     }
     .qsf-comparisson-table thead {
          background: #c0c0c0;
     }
     .qsf-comparisson-table th,
     .qsf-comparisson-table td {
          padding: 5px 10px;
          text-align: left;
     }
     .qsf-comparisson-table tbody th {
          text-align: right;
          background-color: #d0d0d0;
     }
     .qsf-comparisson-table .qsf-note {
          font-style: italic;
     }
    </style>
</head>
<body >
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server" CdnSettings-BaseUrl="http://miracleonline" CdnSettings-TelerikCdn="Disabled">
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
            function set_AjaxRequest(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
            function grdDetailCellSelect(sender, args) {
                var columnsName = args.get_column().get_uniqueName();
                if (columnsName == 'colstrEXAM_DT') {
                    var scheduleFlag = args.get_gridDataItem().getDataKeyValue("NEED_SCHEDULE");
                    var examid = args.get_gridDataItem().getDataKeyValue("EXAM_ID");
                    var priority = args.get_gridDataItem().getDataKeyValue("PRIORITY");
                    switch (scheduleFlag) {
                        case 'N': showChangeDatetime(examid); break;
                        case 'Y':
                            if (priority == "R") {
                                setOpentab(examid);
                            }break;
                        default: showChangeDatetime(examid); break;
                    }
                }
            }
            function showAutoExpandBPview(arg) {
                var grdDetail = $find("<%=grdDetail.ClientID %>");
                var cb1 = grdDetail.get_masterTableView().get_dataItems()[0].findControl("cmbSide");
                alert(cb1.get_text());
            }
            function setOpentab(exam_id) {
                var tab = $find("tabExam").findTabByValue("tabAppointment");
                if (tab != null) {
                    tab.set_selected(true);
                    set_AjaxRequest("getAppointment," + exam_id);
                }
            }
            function showChangeDatetime(arg) {
                window.radopen("../../Forms/Dialogs/OnlinePopupDatetime.aspx?EXAM_ID=" + arg, "OnlinePopupDatetime");
            }

            
            function RowDblClick(sender, eventArgs) {
                set_AjaxRequest("doubleClickEditExam," + eventArgs.getDataKeyValue("EXAM_ID"));
                
            }
            function RowDblClickAddExam(sender, eventArgs) {
                var grid = sender;
                var keyExamID = eventArgs.getDataKeyValue("EXAM_ID");
                var param;
                switch (grid.ClientID) {
                    case 'grdExamFavorite': param = 'AddExamFavorite,' + keyExamID;
                        break;
                    case 'grdExamTop10': param = 'AddExamTop10,' + keyExamID;
                        break;
                    case 'grdExam': param = 'AddExamAll,' + keyExamID;
                        break;
                }
                set_AjaxRequest(param);
            }
            function refreshGrid(arg) {
                if (!arg) {
                    set_AjaxRequest("Rebind");
                }
                else {
                    set_AjaxRequest(arg); 
                }
            }
            function refreshLogin(arg) {
                set_AjaxRequest("LOGIN");
            }
            function chkMessageBox(args) {
                set_AjaxRequest(args);
            }
            function prepareShowAlert(arg) {
                set_AjaxRequest(arg);
            }
            function normalPage(args) {
                set_AjaxRequest(args);
            }
            function onRowDropping(sender, args) {
                if (sender.get_id() == "grdExamFavorite") {
                    var node = args.get_destinationHtmlElement();
                    if (!isChildOf('<%=grdExamFavorite.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }
                else {
                    var node = args.get_destinationHtmlElement();
                    if (!isChildOf('trashCan', node)) {
                        args.set_cancel(true);
                    }
                    else {
                        if (confirm("Are you sure you want to delete this order?"))
                            args.set_destinationHtmlElement('trashCan');
                        else
                            args.set_cancel(true);
                    }
                }
            }
            function isChildOf(parentId, element) {
                while (element) {
                    if (element.id && element.id.indexOf(parentId) > -1) {
                        return true;
                    }
                    element = element.parentNode;
                }
                return false;
            }
            function AlphabetOnly(sender, eventArgs) {
                var c = eventArgs.get_keyCode();
                if (c == 60)
                    alert('Please change "<" to another word!!');
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="blockPopup" runat="server">
        <script type="text/javascript">
            function showNormalAlert(args) {
                switch (args) {
                    case 'ExamConflict':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4005", "windowOnlineMessageBox");
                        break;
                    case 'AddFavoriteExam':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4009", "windowOnlineMessageBox");
                        break;
                    case 'RemoveExamFavorite':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4017", "windowOnlineMessageBox");
                        break;
                    case 'SaveOrder':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4008", "windowOnlineMessageBox");
                        break;
                    case 'EditOrder':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4006", "windowOnlineMessageBox");
                        break;
                    case 'checkRefDoc':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4010", "windowOnlineMessageBox");
                        break;
                    case 'checkRefUnit':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4016", "windowOnlineMessageBox");
                        break;
                    case 'checkIndication':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4011", "windowOnlineMessageBox");
                        break;
                    case 'alertCannotInsertAppointment':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4012", "windowOnlineMessageBox");
                        break;
                    case 'checkAppointCase':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4013", "windowOnlineMessageBox");
                        break;
                    case 'checkCanRequest':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4014", "windowOnlineMessageBox");
                        break;
                    case 'checkBPView':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4015", "windowOnlineMessageBox");
                        break;
                    case 'ManualPopup':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args , "windowOnlineMessageBox");
                        break;
                    case 'createNewClinicalIndication':
                        window.radopen("../../Forms/Dialogs/OnlineCreateClinicalIndication.aspx?FROM=Indication", "windowCreateNewClinical");
                        break;
                    case 'createNewClinicalIndicationType':
                        window.radopen("../../Forms/Dialogs/OnlineCreateClinicalIndication.aspx?FROM=IndicationType", "windowCreateNewClinical");
                        break;
                    case 'checkStat':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4018", "windowOnlineMessageBox");
                        break;
                    case 'ShowalertExam':
                        window.radopen("../../Forms/Dialogs/OnlineAlertExam.aspx", "windowAlertExam");
                        break;
                    case 'Holiday':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args, "windowOnlineMessageBox");
                        break;
                    case 'ExamSameDate':
                        window.radopen("../../Forms/Dialogs/OnlineMessageBox.aspx?FROM=" + args + "&ALT_UID=ONL4026", "windowOnlineMessageBox");
                        break;
                }
            }
            function showHelp() {
                window.open('http://miracleonline/manualonlinerequest/pdf/manualonlinerequest.pdf', '_newtab');
            }
            function getHelp() {
                var combo = $find('<%=cmbManual.ClientID %>');
                var _value = combo.get_selectedItem().get_value();
                switch (_value) {
                    case "1":
                        window.open('http://miracleonline/manualonlinerequest/pdf/manualonlinerequest.pdf', '_newtab');
                        break;
                    case "2":
                        window.open('http://miracleonline/manualonlinerequest/pdf/manualonlinerequestCT.pdf', '_newtab');
                        break;
                    case "3":
                        window.open('http://miracleonline/manualonlinerequest/pdf/manualonlinerequestMRI.pdf', '_newtab');
                        break;
                    case "4":
                        window.open('http://miracleonline/manualonlinerequest/pdf/SimpleScreening.pdf', '_newtab');
                        break;
                }
            }
            function showBPViewCheck(examid) {
                window.radopen("../../Forms/Dialogs/OnlineEditOrder.aspx?EXAM_ID=" + examid, "windowEditOrder");
            }
            function showRiskManagement(arg) {
                window.radopen("../../Forms/Dialogs/frmRiskincedent.aspx?TAB_OPEN=" + arg, "windowRiskManagement");
            }
            function showCovid() {
                window.radopen("../../Forms/Dialogs/frmCovidDetail.aspx", "windowCovid");
            }
            function showBodyInterventionPopup() {
                window.radopen("../../Forms/Dialogs/frmBodyIntervention.aspx", "windowBodyInterventionPopup");
            }
            function showClinicalIndicationWithParams(arg) {
                window.radopen("../../Forms/Dialogs/frmClinicalIndicationTypeWithParameter.aspx?PARAM1=" + arg, "windowClinicalIndicationWithParam");
            }
            function showLoading() {
                window.radopen("../../Forms/Dialogs/OnlineLoadingForm.aspx", "windowShowLoading");
            }
            function showWaittingList(examid) {
                window.open("../../Forms/Dialogs/OnlineEditOrder.aspx?WINDOWS=IE&EXAM_ID=" + examid, "windowEditOrder", "channelmode=no, menubar=no, titlebar=no, toolbar=no, toolbar=no, scrollbars=no, resizable=no, top=100, left=100, width=400, height=400").focus();
            }
            function showEditorOrder(exam_id) {
                window.radopen("../../Forms/Dialogs/OnlineEditOrder.aspx?EXAM_ID=" + exam_id, "windowEditOrder");
            }
            function grdModalityRowDblClick(sender, eventArgs) {
                window.radopen("../../Forms/Orders/frmMasterNormalPages.aspx?TAB_OPEN=tabCT", "windowNormalPage");
            }
            function showBasicIndication(sender, eventArgs) {
                window.radopen("../../Forms/Dialogs/frmBasicClinicalIndication.aspx", "windowClinicalIndication");
            }
            function showNormalPage(arg) {
                window.radopen("../../Forms/Orders/frmMasterNormalPages.aspx?TAB_OPEN=" + arg, "windowNormalPage");
            }
            function showNormalPageAllGroup(arg) {
                window.radopen("../../Forms/Dialogs/normalPageAllExamGroup.aspx?GROUP_TEXT=" + arg, "windowNormalPage");
            }
            function showBodyInterventionPage() {
                window.radopen("../../Forms/Dialogs/normalPageBodyIntervention.aspx", "windowBodyInterventionPage");
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="blockRibbon" runat="server">
        <script type="text/javascript">
            function OnClientClose() {
            }
            function SetTab(sTabText, multipages) {
                window.setTimeout(function () {
                    if (sTabText == "tabAppointment") {
                        var tab = $find("tabExam").findTabByValue(sTabText);
                        if (tab != null) {
                            tab.set_selected(true);
                            SetTabAppoint(multipages);
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("checkAppointment");
                        }

                    }
                    else if (sTabText == 'tabExamTop10') {
                        var tab = $find("tabExam").findTabByValue(sTabText);
                        if (tab != null) {
                            tab.set_selected(true);
                        }
                    }
                    else if (sTabText == 'OrderWorklist') {
                        var tab = $find("RadTabStrip1").findTabByValue('tabOrderWorklist');
                        if (tab != null) {
                            tab.set_selected(true);
                            RefreshGridWorklist();
                        }
                    }
                    else if (sTabText == 'tabNewOrder') {
                        var tab = $find("RadTabStrip1").findTabByValue('tabNewOrder');
                        if (tab != null) {
                            tab.set_selected(true);
                            var tab2 = $find("tabExam").findTabByValue('tabExamTop10');
                            var tab3 = $find("tabExam").findTabByValue('tabAppointment');
                            if (tab2 != null) {
                                tab3.disable();
                                tab2.set_selected(true);
                            }
                        }
                    }

                }, 100);
            }
            function SetTabAppoint(sTabText) {
                window.setTimeout(function() {
                    var tab = $find("tabAppoint").findTabByValue(sTabText);
                    if (tab != null) {
                        tab.set_selected(true);
                    }
                }, 100);
            }
            function tabExam_ClientTabSelected(sender, args) {
                if (args.get_tab().get_text() == 'Appointment') {
                    set_AjaxRequest("checkAppointment");
                }
            }   
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="multiPageAppoint" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdExamFavorite" />
                    <telerik:AjaxUpdatedControl ControlID="grdExamTop10"/>
                    <telerik:AjaxUpdatedControl ControlID="grdExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdModality" />
                    
                    <telerik:AjaxUpdatedControl ControlID="tabExam" />
                    <telerik:AjaxUpdatedControl ControlID="tabAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="btnChkDefind" />
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate1" />
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate2" />
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate3" />
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate4" />
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate5" />
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate6" />
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate7" />
                    <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />

                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationTypeView" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationView" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationTypeView" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />

                    <telerik:AjaxUpdatedControl ControlID="rtbDemographic" />
                    <telerik:AjaxUpdatedControl ControlID="cmbRefDoc" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoIndicationDate1">
                <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate1" />
                <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoIndicationDate2">
                <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate2" />
                <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoIndicationDate3">
                <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate3" />
                <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoIndicationDate4">
                <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate4" />
                <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoIndicationDate5">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate5" />
                    <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoIndicationDate6">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate6" />
                    <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoIndicationDate7">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdoIndicationDate7" />
                    <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="dtIndicationDate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdDetail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="tabExam" />
                    <telerik:AjaxUpdatedControl ControlID="tabAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="cmbSide" />
                    <telerik:AjaxUpdatedControl ControlID="multiPageAppoint" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbPriority">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbPriority" />
                    <telerik:AjaxUpdatedControl ControlID="tabAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="multiPageAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="dtIndicationDate" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbClinic">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbClinic" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbSide">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbSide" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdExamFavorite">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdExamFavorite" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="cmbSide" />
                    <telerik:AjaxUpdatedControl ControlID="tabExam" />
                    <telerik:AjaxUpdatedControl ControlID="tabAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="multiPageAppoint" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdExamTop10">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdExamTop10" />
                    <telerik:AjaxUpdatedControl ControlID="grdExamFavorite" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="cmbSide" />
                    <telerik:AjaxUpdatedControl ControlID="tabExam" />
                    <telerik:AjaxUpdatedControl ControlID="tabAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="multiPageAppoint" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdExam">
                <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdExamFavorite" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="cmbSide" />
                    <telerik:AjaxUpdatedControl ControlID="tabExam" />
                    <telerik:AjaxUpdatedControl ControlID="tabAppoint" />
                    <telerik:AjaxUpdatedControl ControlID="multiPageAppoint" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="multiPageAppoint">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdAppointment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdAppointmentSP">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                    
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdAppointmentPM">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentCNMI" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdAppointmentCNMI">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointment" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentSP" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdAppointmentPM" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtbMainNW">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtbMainNW" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="treeFavoriteIndicationTypeView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="treeFavoriteIndicationView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationView" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="treeIndicationTypeView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationTypeView" />
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="contentViewIndicationType" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationTypeView" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="treeIndicationView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="treeIndicationView"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                    <telerik:AjaxUpdatedControl ControlID="txtEditor" />
                    <telerik:AjaxUpdatedControl ControlID="contentViewIndication" />
                    <telerik:AjaxUpdatedControl ControlID="treeFavoriteIndicationView" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbSearchExam">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbSearchExam" />
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="grdDetail" />
                    <telerik:AjaxUpdatedControl ControlID="tabExam" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            
            <telerik:AjaxSetting AjaxControlID="grdModality">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdModality" />
                    <telerik:AjaxUpdatedControl ControlID="grdExam" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoSearchExamGroup1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdoSearchExamGroup1" />
                    <telerik:AjaxUpdatedControl ControlID="grdExamTop10" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoSearchExamGroup2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdoSearchExamGroup2" />
                    <telerik:AjaxUpdatedControl ControlID="grdExamTop10" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rdoSearchExamGroup3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rdoSearchExamGroup3" />
                    <telerik:AjaxUpdatedControl ControlID="grdExamTop10" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cmbRefUnit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbRefUnit"/>
                     <telerik:AjaxUpdatedControl ControlID="multiPageExam" LoadingPanelID="RadAjaxLoadingPanel1" />
                     <telerik:AjaxUpdatedControl ControlID="multipageMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                     <telerik:AjaxUpdatedControl ControlID="grdDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCR">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnCR"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCT">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnCT"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnMR">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnMR" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnUS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnUS" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnMAMMO">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnMAMMO" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFlu">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnFlu" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnOR">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnOR" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnOPD">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnOPD" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="BodyIntervention">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="BodyIntervention" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="False" VisibleStatusbar="false"
        runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="windowOnlineMessageBox" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="400" Height="200" NavigateUrl="~/Forms/Dialogs/OnlineMessageBox.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowEditOrder" runat="server" Behaviors="Move" Modal="true" ReloadOnShow="true"
                Width="450" Height="600" NavigateUrl="~/Forms/Dialogs/OnlineEditOrder.aspx" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowAllNextAppoint" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="500" Height="200"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowRiskManagement" runat="server" Behaviors="Move" Modal="true" ReloadOnShow="true"
                Width="900" Height="530" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowCovid" runat="server" Behaviors="Close, Move" Modal="true" ReloadOnShow="true"
                Width="900" Height="530" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowClinicalIndicationWithParam" runat="server" Behaviors="Close, Move" Modal="true" ReloadOnShow="true"
                Width="500" Height="530" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowCancelReason" runat="server" Behaviors="Close, Move" Modal="true"
                Width="400" Height="480" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowAlertPatientPhone" runat="server" Behaviors="Move" Modal="true"
                Width="400" Height="300" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="OnlinePopupDatetime" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="Height"
                Modal="true" Width="400" Height="350" NavigateUrl="~/Forms/Dialogs/OnlinePopupDatetime.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowCreateNewClinical" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="Height"
                Modal="true" Width="400" Height="350"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowNormalPage" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="Height"
                Modal="true" Width="1100" Height="800"
             IconUrl="~/Resources/ICON/browse_16.png"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowClinicalIndication" runat="server" Behaviors="Close, Move" AutoSizeBehaviors="Height"
                Modal="true" Width="400" Height="600"
                IconUrl="~/Resources/ICON/browse_16.png"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        <Windows>
            <telerik:RadWindow ID="windowAlertExam" runat="server" Behaviors="Close" AutoSizeBehaviors="HeightProportional"
                Modal="true" Width="800" Height="430" NavigateUrl="~/Forms/Dialogs/OnlineAlertExam.aspx"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
         <Windows>
            <telerik:RadWindow ID="windowBodyInterventionPage" runat="server" Behaviors="Close, Move" Modal="true"
                Width="500" Height="150" IconUrl="~/Resources/ICON/browse_16.png" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
        
         <Windows>
            <telerik:RadWindow ID="windowBodyInterventionPopup" runat="server" Behaviors="Move" Modal="true"
                Width="500" Height="520" IconUrl="~/Resources/ICON/browse_16.png" OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table id="mainTable" style="border-style: none; " width="100%" align="center" border="0" cellspacing="0">
        <tr style="background-color: #000080">
             <td align="left" colspan="2">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="labelHead" runat="server" Text="Envision Online" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbVersion" runat="server" Text="v. 4.4.3.15" ForeColor="White" 
                                Font-Size="X-Small" Width="60px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmployeeName" runat="server" Text="Employee" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadButton Text="Log out" ID="btnLogout" runat="server" ButtonType="ToggleButton"
                                Width="60px" ForeColor="Red" OnClick="btnLogout_OnClick">
                            </telerik:RadButton>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="cmbManual" runat="server"  
                                EmptyMessage="คู่มือ"  Font-Bold="true"
                                AutoPostBack="true" OnClientSelectedIndexChanged="getHelp" >
                                <Items>
                                    <telerik:RadComboBoxItem Text="คู่มือพื้นฐาน" Value="1" />
                                    <telerik:RadComboBoxItem Text="คู่มือ CT" Value="2" />
                                    <telerik:RadComboBoxItem Text="คู่มือ MRI" Value="3" />
                                    <telerik:RadComboBoxItem Text="Simple Screeing CT & MRI" Value="4" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr valign="top" style="border-style: none">
            <td colspan="3">
                <telerik:RadToolBar ID="rtoolPatient" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton Value="rtoolbtnPatient">
                            <ItemTemplate>
                                <asp:Label ID="labelHN" runat="server" Text="HN : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblHN" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace1" runat="server" Width="10px" Text=""></asp:Label>
                                <asp:Label ID="labelPatientName" runat="server" Text="Name : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace2" runat="server" Width="10px" Text="  "></asp:Label>
                                <asp:Label ID="labelGender" runat="server" Text="Gender : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace3" runat="server" Width="10px" Text="  "></asp:Label>
                                <asp:Label ID="labelAge" runat="server" Text="Age : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace4" runat="server" Width="10px" Text="  "></asp:Label>
                                <asp:Label ID="labelDOB" runat="server" Text="DOB : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblDOB" runat="server" Text=""></asp:Label>
                                <asp:Label ID="labelSpace5" runat="server" Width="10px" Text="  "></asp:Label>
                                <asp:Label ID="labelPhone" runat="server" Text="Phone : " Font-Bold="True"></asp:Label>
                                <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblNonResident" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
             <td width="160px" style="border-style: none; padding: 0px; margin: 0px; border-spacing: 0px" >
                <telerik:RadToolBar ID="rtbMainNW" runat="server" Width="100%" Height="65px" OnButtonClick="rtbMain_ButtonClick">
                    <Items>
                        <telerik:RadToolBarButton Value="btnWorklist" Text="Worklist" ToolTip="Go to Worklist" Width="60px" 
                         ImagePosition="AboveText" ImageUrl="../../Resources/ICON/browse_32.png"/>
                         <telerik:RadToolBarButton Value="btnSaveNewOrder" Text="Save Order" ToolTip="Save Order" Width="60px" 
                         ImagePosition="AboveText" ImageUrl="../../Resources/ICON/saveLarge.png"/>
                         <telerik:RadToolBarButton Value="btnClearAll" Text="Clear All" ToolTip="Clear All" Width="60px" 
                         ImagePosition="AboveText" ImageUrl="../../Resources/ICON/clear.png" Visible="false"/>
                    </Items>
                </telerik:RadToolBar>                
            </td>
            <td style="border-style: none; padding: 0px; margin: 0px; border-spacing: 0px;" colspan="2">
                <table  id="subTable" style="border-width: thin; border-style: none; border-spacing: 0px;" width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left" valign="top" >
                        <telerik:RadToolBar ID="rtbDemographic" runat="server" Width="100%" Height="65px" BorderStyle="None">
                            <Items>
                                <telerik:RadToolBarButton Value="groupDemographic" BorderStyle="None">
                                    <ItemTemplate>
                                        <table cellpadding="1" cellspacing="0" border="0">
                                            <tr>
                                                <%--<td>
                                                    <asp:Label ID="labelPatientStatus" runat="server" Width="85px" Text="Patient Status : " />
                                                </td>
                                                <td>
                                                    <div class="qsf-demo-canvas qsf-demo-canvas-vertical">
                                                            <telerik:RadComboBox ID="cmbPatientStatus" runat="server" Height="140px" Width="140px" AllowCustomText="false">
                                                                <Items>
                                                                       <telerik:RadComboBoxItem Value="1" Text="Walk" />
                                                                       <telerik:RadComboBoxItem Value="2" Text="Wheel Chair" />
                                                                       <telerik:RadComboBoxItem Value="3" Text="Stretcher" />
                                                                </Items>
                                                            </telerik:RadComboBox>
                                                     </div>
                                                </td>--%>
                                                <td>
                                                    <asp:Label ID="labelInsurance" runat="server" Width="85px" Text="Insurance : " />
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtInsurance" runat="server" BackColor="Transparent" ReadOnly="true" Enabled="true" Width="140px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="labelRefDoc" runat="server" Width="85px" Text="Ordering Doc : " />
                                                </td>
                                                <td>
                                                <telerik:RadComboBox ID="cmbRefDoc" runat="server" EmptyMessage="Please select Doctor!!"
                                                    Height="140px" Width="228px" 
                                                    MarkFirstMatch="true" ShowMoreResultsBox="True" EnableLoadOnDemand="True"
                                                    AutoPostBack="true" OnItemsRequested="cmbRefDoc_ItemsRequested"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="labelClinicType" runat="server" Width="85px" Text="Clinic type : " />
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtClinicType" BackColor="Transparent" runat="server" ReadOnly="true" Enabled="true" Width="140px" />
                                                </td>
                                                <td>
                                        <asp:Label ID="labelRefUnit" runat="server" Width="85px" Text="Ordering Dept : " />
                                                </td>
                                                <td>
                                                <telerik:RadComboBox ID="cmbRefUnit" runat="server"
                                                    EmptyMessage="Please select Unit!!" 
                                                    Height="140px" Width="228px" MarkFirstMatch="true"
                                                    ShowMoreResultsBox="True" EnableLoadOnDemand="True" 
                                                    AutoPostBack="true"
                                                     OnItemsRequested="cmbRefUnit_ItemsRequested"
                                                     OnSelectedIndexChanged="cmbRefUnit_SelectedIndexChanged"/>
                                                </td>
                                                <%--<td>
                                        <telerik:RadTextBox ID="txtRefUnit" runat="server" BackColor="Transparent" Width="225px" ReadOnly="true" Enabled="true" />
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </telerik:RadToolBarButton>
                            </Items>
                        </telerik:RadToolBar>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="border-style: none; " width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
        <tr valign="top">
            <td width="40%" valign="top">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <telerik:RadTabStrip ID="tabMain" runat="server" MultiPageID="multipageMain" 
                                SelectedIndex="0">
                                <Tabs>
                                    <telerik:RadTab Text="Clinical Indication" Selected="true" ImageUrl="../../Resources/ICON/syringe.png">
                                    </telerik:RadTab>
                                </Tabs>
                            </telerik:RadTabStrip>
                            <telerik:RadMultiPage ID="multipageMain" runat="server" SelectedIndex="0">
                                <telerik:RadPageView ID="viewFavorite" runat="server">
                                    <table width="100%" cellspacing="0">
                                        <tr>
                                            <td width="30%" valign="top">
                                                <div style="width: 100%;">
                                                <telerik:RadTreeView ID="treeIndicationTypeView" runat="server" CheckBoxes="true" Height="247px"
                                                    OnContextMenuItemClick="treeIndicationTypeView_ContextMenuItemClick"
                                                    OnNodeCheck="treeIndicationTypeView_NodeCheck"
                                                    OnNodeClick="treeIndicationTypeView_NodeClick"
                                                    OnNodeCreated="treeIndicationTypeView_NodeCreated"
                                                    OnNodeDataBound="treeIndicationTypeView_NodeDataBound" >
                                                    <ContextMenus>
                                                        <telerik:RadTreeViewContextMenu ID="contentViewIndicationType" runat="server">
                                                           <Items>
                                                                <telerik:RadMenuItem Value="addClinical" Text="Create Clinical indication" ImageUrl="../../Resources/ICON/add2-16.png"/>
                                                                <telerik:RadMenuItem Value="delClinical" Text="Delete Clinical indication" ImageUrl="../../Resources/ICON/Actions-remove16.png"/>
                                                            </Items>
                                                        </telerik:RadTreeViewContextMenu>
                                                    </ContextMenus>
                                                </telerik:RadTreeView>
                                                </div>
                                            </td>
                                            <td width="70%" valign="top">
                                                <div style="width: 100%;">
                                                    <telerik:RadTreeView ID="treeIndicationView" runat="server" CheckBoxes="true" Width="100%" Height="249"
                                                        OnContextMenuItemClick="treeIndicationView_ContextMenuItemClick"
                                                        OnNodeCheck="treeIndicationView_NodeCheck"
                                                        OnNodeClick="treeIndicationView_NodeClick"
                                                        OnNodeCreated="treeIndicationView_NodeCreated"
                                                        OnNodeDataBound="treeIndicationView_NodeDataBound" >
                                                        <ContextMenus>
                                                            <telerik:RadTreeViewContextMenu ID="contentViewFavIndication" runat="server">
                                                                <Items>
                                                                    <telerik:RadMenuItem Value="addBasicIndication" Text="Add Basic Indication" ImageUrl="../../Resources/ICON/direction-folded-icon16.jpg">
                                                                    </telerik:RadMenuItem>
                                                                    <telerik:RadMenuItem Value="createSelfIndication" Text="Create Indication" ImageUrl="../../Resources/ICON/add2-16.png">
                                                                    </telerik:RadMenuItem>
                                                                    <telerik:RadMenuItem Value="removeIndication" Text="Remove My Indication" ImageUrl="../../Resources/ICON/delete.png">
                                                                    </telerik:RadMenuItem>
                                                                </Items>
                                                            </telerik:RadTreeViewContextMenu>
                                                        </ContextMenus>
                                                    </telerik:RadTreeView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <telerik:RadTabStrip ID="tabClinicalText" runat="server" MultiPageID="multipageClinicalText">
                                <Tabs>
                                    <telerik:RadTab Text="Clinical Text" Selected="true" ImageUrl="../../Resources/ICON/text_file.png">
                                    </telerik:RadTab>
                                </Tabs>
                            </telerik:RadTabStrip>
                            <telerik:RadMultiPage ID="multipageClinicalText" runat="server" SelectedIndex="0">
                                <telerik:RadPageView ID="viewClinicalText" runat="server">
                                        <telerik:RadTextBox ID="txtEditor" runat="server" TextMode="MultiLine" Width="100%" Height="150px" >
                                            <ClientEvents OnKeyPress="AlphabetOnly" />
                                        </telerik:RadTextBox>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="60%" valign="top">
                <table style="border-style: none; " width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <telerik:RadTabStrip ID="tabExam" runat="server" MultiPageID="multiPageExam" 
                                SelectedIndex="2">
                                <Tabs>
                                    <telerik:RadTab Text="Favorite Exam" Value="tabExamFavorite" 
                                        ImageUrl="../../Resources/ICON/favorite.png">
                                    </telerik:RadTab>
                                    <telerik:RadTab Text="Top 10 Exams" Value="tabExamTop10" Selected="True"
                                        ImageUrl="../../Resources/ICON/award-star-bronze-3-icon16.png">
                                    </telerik:RadTab>
                                    <telerik:RadTab Text="Exams" Value="tabExamAll" >
                                    </telerik:RadTab>
                                    <telerik:RadTab Text="Appointment" Value="tabAppointment" ImageUrl="../../Resources/ICON/calendar_2_16.png" Enabled="false">
                                    </telerik:RadTab>
                                </Tabs>
                            </telerik:RadTabStrip>
                            <telerik:RadMultiPage ID="multiPageExam" runat="server" SelectedIndex="2" 
                                Height="100%">
                                <telerik:RadPageView ID="pageExamFavorite" runat="server">
                                    <telerik:RadGrid ID="grdExamFavorite" runat="server" PageSize="7" Height="247px"
                                        ShowStatusBar="true" AllowSorting="True" AllowPaging="True" EnableAJAX="true"
                                        OnNeedDataSource="grdExamFavorite_NeedDataSource" 
                                        OnItemCommand="grdExamFavorite_ItemCommand"
                                        OnRowDrop="grdExamFavorite_RowDrop" >
                                        <ClientSettings EnableRowHoverStyle="true" AllowRowsDragDrop="true">
                                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                                            <ClientEvents OnRowDblClick="RowDblClickAddExam" OnRowDropping="onRowDropping" />
                                            <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="57px" />
                                        </ClientSettings>
                                        <MasterTableView TableLayout="Fixed" AutoGenerateColumns="false" 
                                            DataKeyNames="EXAM_ID" 
                                            ClientDataKeyNames="EXAM_ID"
                                            Summary="grdData table">
                                            <Columns>
                                                <telerik:GridButtonColumn CommandName="RemoveExamFavorite" ButtonType="ImageButton"
                                                    UniqueName="RemoveExamFavorite"
                                                    ImageUrl="../../Resources/ICON/Actions-remove16.png">
                                                    <HeaderStyle Width="25px" />
                                                    <ItemStyle Width="16px" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn CommandName="AddExam" HeaderTooltip="Make Study" ButtonType="ImageButton" UniqueName="colAddExam"
                                                    ImageUrl="../../Resources/ICON/add2-16.png">
                                                    <HeaderStyle Width="25px" />
                                                    <ItemStyle Width="16px" />
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                                                    UniqueName="colEXAM_UID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                    <ItemStyle Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="REQONL_DISPLAY" HeaderText="Exam Name" SortExpression="EXAM_NAME"
                                                    UniqueName="colEXAM_NAME" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                    <HeaderStyle Width="100%" />
                                                    <ItemStyle Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                                                    UniqueName="colEXAM_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                    <ItemStyle Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="RATE" HeaderText="RATE" SortExpression="RATE"
                                                    UniqueName="colRATE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                    <ItemStyle Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="MODALITY_ID" SortExpression="MODALITY_ID"
                                                    UniqueName="colMODALITY_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                    <ItemStyle Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NEED_SCHEDULE" HeaderText="NEED_SCHEDULE" SortExpression="NEED_SCHEDULE"
                                                    UniqueName="colNEED_SCHEDULE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                    <ItemStyle Wrap="true" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
                                        <FilterMenu EnableTheming="True">
                                            <CollapseAnimation Duration="200" Type="OutQuint" />
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="pageTo10Exam" Selected="true" runat="server">
                                    <table cellspacing="0" width="100%" align="center">
                                        <tr>
                                            <%--<td>
                                                <asp:Image ID="Image1" ImageUrl="~/Resources/ICON/viewtree_24.png" runat="server"
                                                    Height="15px" Width="15px" />
                                            </td>--%>
                                            <%--<td>
                                                <telerik:RadButton ID="rdoSearchExamGroup1" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="1 Month" GroupName="ExamFavorite" OnCheckedChanged="rdoSearchExamGroup1_CheckedChanged"
                                                    Checked="true">
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="rdoSearchExamGroup2" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="3 Month" GroupName="ExamFavorite" OnCheckedChanged="rdoSearchExamGroup1_CheckedChanged">
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="rdoSearchExamGroup3" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="6 Month" GroupName="ExamFavorite" OnCheckedChanged="rdoSearchExamGroup1_CheckedChanged">
                                                </telerik:RadButton>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadGrid ID="grdExamTop10" runat="server" PageSize="10" Height="245px" ShowStatusBar="true"
                                                    AllowSorting="True" AllowPaging="True" EnableAJAX="true" OnNeedDataSource="grdExamTop10_NeedDataSource"
                                                    OnItemCommand="grdExamTop10_ItemCommand"
                                                    OnItemDataBound="grdExamTop10_ItemDataBound">
                                                    <ClientSettings EnableRowHoverStyle="true">
                                                        <ClientEvents OnRowDblClick="RowDblClickAddExam" />
                                                        <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="57px" />
                                                    </ClientSettings>
                                                    <MasterTableView TableLayout="Auto" AutoGenerateColumns="false" ClientDataKeyNames="EXAM_ID"
                                                        Summary="grdData table">
                                                        <Columns>
                                                            <telerik:GridButtonColumn CommandName="AddFavoriteExam" ButtonType="ImageButton"
                                                               UniqueName="AddFavoriteExam" ImageUrl="../../Resources/ICON/favorite.png">
                                                               <HeaderStyle Width="25px" />
                                                               <ItemStyle Width="16px" />
                                                            </telerik:GridButtonColumn>
                                                            <telerik:GridButtonColumn CommandName="AddExam" HeaderTooltip="Make Study" ButtonType="ImageButton" UniqueName="colAddExam"
                                                                ImageUrl="../../Resources/ICON/add2-16.png">
                                                                <HeaderStyle Width="25px" />
                                                                <ItemStyle Width="16px" />
                                                            </telerik:GridButtonColumn>
                                                            <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                                                                UniqueName="colEXAM_UID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="REQONL_DISPLAY" HeaderText="Exam Name" SortExpression="EXAM_NAME"
                                                                UniqueName="colEXAM_NAME" Visible="true" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="EXAM_ID" SortExpression="EXAM_ID"
                                                                UniqueName="colEXAM_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="RATE" HeaderText="RATE" SortExpression="RATE"
                                                                UniqueName="colRATE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="MODALITY_ID" SortExpression="MODALITY_ID"
                                                                UniqueName="colMODALITY_ID" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="NEED_SCHEDULE" HeaderText="NEED_SCHEDULE" SortExpression="NEED_SCHEDULE"
                                                                UniqueName="colNEED_SCHEDULE" Visible="false" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
                                                    <FilterMenu EnableTheming="True">
                                                        <CollapseAnimation Duration="200" Type="OutQuint" />
                                                    </FilterMenu>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="pageExam" runat="server" Height="249px">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center">
                                        <tr style="width:100%">
                                            <td style="width:28%;">
                                                <telerik:RadButton ID="btnCR" runat="server" Text="Plain Film"
                                                     Font-Bold="true" Font-Size="Medium"
                                                     Width="99%" Height="60px" 
                                                     OnClick="btnCR_Click" style="top: 0px; left: 0px">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/CR48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td style="width:36%;">
                                                <telerik:RadButton ID="btnUS" runat="server" Text="Ultrasonography"
                                                    Font-Bold="True" Font-Size="Medium"
                                                    Width="99%" Height="60px"
                                                    OnClick="btnUS_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/US_2_48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td style="width:36%;">
                                                <telerik:RadButton ID="btnFlu" runat="server" Text="Fluorography"
                                                    Font-Bold="True" Font-Size="Medium"
                                                    Width="99%" Height="60px"
                                                    OnClick="btnFLU_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/CR48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" />
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="btnCT" runat="server" Text="CT"
                                                    Font-Bold="True" Font-Size="Medium"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnCT_Click" style="top: 0px; left: 1px">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/CT48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnMAMMO" runat="server" Text="Mammography"
                                                    Font-Bold="True" Font-Size="Medium"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnMAMMO_Click" style="top: 0px; left: 0px">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/Mammo48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnBodyIntervention" runat="server" Text="Body Intervention"
                                                    Font-Bold="True" Font-Size="Medium"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnBodyIntervention_Click" style="top: 0px; left: 0px">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/1200px-Cath_Lab_-_The_Noun_Project50.svg.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" />
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr> 
                                            <td>
                                                <telerik:RadButton ID="btnMR" runat="server" Text="MR"
                                                    Font-Bold="True" Font-Size="Medium"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnMR_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/MR48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" SecondaryIconHeight="45px" SecondaryIconWidth="45px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnOR" runat="server" Text="OR Imaging"
                                                    Font-Bold="True" Font-Size="Medium"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnOR_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/knee-icon48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnOPD" runat="server" Text="OPD/IPD Imaging"
                                                    Font-Bold="True" Font-Size="Medium"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnOPD_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/patient_walking_opd48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="45px" PrimaryIconWidth="45px" />
                                                 
                                                </telerik:RadButton>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                                <%--<telerik:RadPageView ID="pageExam" runat="server" Height="249px">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center">
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="btnCR" runat="server" Text="Plain Film"
                                                     Font-Bold="true" Font-Size="Larger"
                                                     Width="98%" Height="60px" 
                                                     OnClick="btnCR_Click" style="top: 0px; left: 0px">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/CR48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="50px" PrimaryIconWidth="50px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnUS" runat="server" Text="Ultrasonography"
                                                    Font-Bold="true" Font-Size="Larger"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnUS_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/US_2_48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="50px" PrimaryIconWidth="50px" />
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="btnCT" runat="server" Text="CT"
                                                    Font-Bold="true" Font-Size="Larger"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnCT_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/CT48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="50px" PrimaryIconWidth="50px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnFlu" runat="server" Text="Fluorography"
                                                    Font-Bold="true" Font-Size="Larger"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnFLU_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/CR48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="50px" PrimaryIconWidth="50px" />
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="btnMR" runat="server" Text="MR"
                                                    Font-Bold="true" Font-Size="Larger"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnMR_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/MR48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="50px" PrimaryIconWidth="50px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnMAMMO" runat="server" Text="Mammography"
                                                    Font-Bold="true" Font-Size="Larger"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnMAMMO_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/Mammo48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="50px" PrimaryIconWidth="50px" />
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadButton ID="btnOR" runat="server" Text="OR Imaging"
                                                    Font-Bold="true" Font-Size="Larger"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnOR_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/knee-icon48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="50px" PrimaryIconWidth="50px" />
                                                </telerik:RadButton>
                                            </td>
                                            <td>
                                                <telerik:RadButton ID="btnOPD" runat="server" Text="OPD/IPD Imaging"
                                                    Font-Bold="true" Font-Size="Larger"
                                                    Width="98%" Height="60px"
                                                    OnClick="btnOPD_Click">
                                                    <Icon PrimaryIconUrl="../../Resources/ICON/patient_walking_opd48.png"  PrimaryIconTop="2" PrimaryIconLeft="5" PrimaryIconHeight="50px" PrimaryIconWidth="50px" />
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>--%>
                                <telerik:RadPageView ID="viewAppoint" runat="server">
                                    <table width="100%" cellspacing="0">
                                        <tr>
                                            <td colspan="8" width="100%" valign="top">
                                                <telerik:RadComboBox ID="cmbRadiologistAppoint" runat="server" Width="100%"
                                                ShowMoreResultsBox="True" EnableLoadOnDemand="True" AutoPostBack="true"
                                                OnItemsRequested="cmbRadiologistAppoint_ItemsRequested"
                                                OnSelectedIndexChanged="cmbRadiologistAppoint_SelectedIndexChanged" >
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">
                                                <telerik:RadButton ID="rdoIndicationDate1" ButtonType="ToggleButton" ToggleType="Radio" 
                                                    runat="server" Text="1wk." GroupName="Indication" OnCheckedChanged="rdoIndicationDate_CheckedChanged">
                                                </telerik:RadButton>
                                            </td>
                                            <td colspan="1">
                                                <telerik:RadButton ID="rdoIndicationDate2" ButtonType="ToggleButton" ToggleType="Radio" 
                                                    runat="server" Text="2wk." GroupName="Indication" OnCheckedChanged="rdoIndicationDate_CheckedChanged">
                                                </telerik:RadButton>
                                            </td>
                                            <td colspan="1">
                                                <telerik:RadButton ID="rdoIndicationDate3" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="4wk." GroupName="Indication" OnCheckedChanged="rdoIndicationDate_CheckedChanged">
                                                </telerik:RadButton>
                                            </td>
                                            <td colspan="1">
                                                <telerik:RadButton ID="rdoIndicationDate4" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="3mo. (90 วัน)" GroupName="Indication" 
                                                    OnCheckedChanged="rdoIndicationDate_CheckedChanged" style="top: 0px; left: 0px">
                                                </telerik:RadButton>
                                            </td>
                                            <td colspan="1">
                                                <telerik:RadButton ID="rdoIndicationDate5" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="6mo. (180 วัน)" GroupName="Indication" OnCheckedChanged="rdoIndicationDate_CheckedChanged">
                                                </telerik:RadButton>
                                            </td>
                                            <td colspan="1">
                                                <telerik:RadButton ID="rdoIndicationDate7" ButtonType="ToggleButton" ToggleType="Radio"
                                                    runat="server" Text="1y. (365 วัน)" GroupName="Indication" OnCheckedChanged="rdoIndicationDate_CheckedChanged">
                                                </telerik:RadButton>
                                            </td>
                                            <td colspan="1">
                                                <telerik:RadButton ID="rdoIndicationDate6" ButtonType="ToggleButton" ToggleType="Radio" Checked="true"
                                                    runat="server" Text="other" GroupName="Indication" OnCheckedChanged="rdoIndicationDate_CheckedChanged">
                                                </telerik:RadButton>
                                            </td>
                                            <td colspan="1" >
                                            <telerik:RadDateTimePicker ID="dtIndicationDate" runat="server" AutoPostBackControl="Both"
                                            OnSelectedDateChanged="dtIndicationDate_SelectedDateChanged">
                                            <DateInput ID="DateInput1" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"></DateInput>
                                            </telerik:RadDateTimePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" width="100%" valign="top">
                                            <telerik:RadTabStrip ID="tabAppoint" runat="server" MultiPageID="multiPageAppoint">
                                                <Tabs>
                                                    <telerik:RadTab Value="Regular" Text="Regular Clinic" >
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Value="Special" Text="Special Clinic">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Value="VIP" Text="Premium Clinic">
                                                    </telerik:RadTab>
                                                    <telerik:RadTab Value="CNMI" Text="Regular CNMI" Visible="false" ImageUrl="../../Resources/ICON/ezgif.com-resize.gif">
                                                    </telerik:RadTab>
                                                </Tabs>
                                            </telerik:RadTabStrip>
                                            <telerik:RadMultiPage ID="multiPageAppoint" runat="server" SelectedIndex="0" Height="100%">
                                            <telerik:RadPageView ID="pageRegulaClinic" runat="server">
                                                <telerik:RadGrid ID="grdAppointment" runat="server" ShowHeader="false" ShowGroupPanel="false"
                                                    ShowStatusBar="false" AllowPaging="True" Height="168px" PageSize="10"
                                                    OnNeedDataSource="grdAppointment_NeedDataSource"
                                                    OnItemDataBound="grdAppointment_ItemDataBound"
                                                    >
                                                    <ClientSettings>
                                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="50px"></Scrolling>
                                                    </ClientSettings>
                                                    <MasterTableView  TableLayout="Fixed" DataKeyNames="SCHEDULE_ID" AutoGenerateColumns="false"
                                                        Summary="grdData table" ShowHeader="False" ShowHeadersWhenNoRecords="False" GridLines="None">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_DESC_DATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" Wrap="true" HorizontalAlign="Right" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_DESC" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="100%" />
                                                                <ItemStyle Width="100%" Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempMorning" HeaderText="Morning" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoMorning" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="เช้า" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoMorning_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left"/>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempAfternoon" HeaderText="Afternoon" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoAfternoon" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="บ่าย" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoAfternoon_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left"/>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempEvening" HeaderText="Evening" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoEvening" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="เย็น" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoEvening_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="CLINIC_TYPE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
    
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                             <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                             <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
                                                    <FilterMenu EnableTheming="True">
                                                        <CollapseAnimation Duration="200" Type="OutQuint" />
                                                    </FilterMenu>
                                                </telerik:RadGrid>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="pageSpecialClinic" runat="server">
                                                <telerik:RadGrid ID="grdAppointmentSP" runat="server" ShowHeader="false" ShowGroupPanel="false"
                                                    ShowStatusBar="false" AllowPaging="True" Height="168px" PageSize="10"
                                                    OnNeedDataSource="grdAppointmentSP_NeedDataSource"
                                                    OnItemDataBound="grdAppointmentSP_ItemDataBound"
                                                    >
                                                    <ClientSettings>
                                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="50px"></Scrolling>
                                                    </ClientSettings>
                                                    <MasterTableView TableLayout="Fixed" DataKeyNames="SCHEDULE_ID" AutoGenerateColumns="false"
                                                        Summary="grdData table" ShowHeader="False" ShowHeadersWhenNoRecords="False" GridLines="None">
                                                            <Columns>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_DESC_DATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" Wrap="true" HorizontalAlign="Right" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_DESC" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="100%" />
                                                                <ItemStyle Width="100%" Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempMorningSP" HeaderText="Morning" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoMorningSP" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="เช้า" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoMorningSP_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left"/>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempAfternoonSP" HeaderText="Afternoon" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoAfternoonSP" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="บ่าย" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoAfternoonSP_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left"/>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempEveningSP" HeaderText="Evening" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoEveningSP" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="เย็น" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoEveningSP_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="CLINIC_TYPE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
    
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                             <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                             <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
                                                    <FilterMenu EnableTheming="True">
                                                        <CollapseAnimation Duration="200" Type="OutQuint" />
                                                    </FilterMenu>
                                                </telerik:RadGrid>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="pagePremiumClinic" runat="server">
                                                <telerik:RadGrid ID="grdAppointmentPM" runat="server" ShowHeader="false" ShowGroupPanel="false"
                                                    ShowStatusBar="false" AllowPaging="True" Height="168px" PageSize="10"
                                                    OnNeedDataSource="grdAppointmentPM_NeedDataSource"
                                                    OnItemDataBound="grdAppointmentPM_ItemDataBound"
                                                    >
                                                    <ClientSettings>
                                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="50px"></Scrolling>
                                                    </ClientSettings>
                                                    <MasterTableView TableLayout="Fixed" DataKeyNames="SCHEDULE_ID" AutoGenerateColumns="false"
                                                        Summary="grdData table" ShowHeader="False" ShowHeadersWhenNoRecords="False" GridLines="None">
                                                       <Columns>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_DESC_DATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" Wrap="true" HorizontalAlign="Right" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_DESC" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="100%" />
                                                                <ItemStyle Width="100%" Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempMorningPM" HeaderText="Morning" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoMorningPM" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="เช้า" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoMorningPM_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left"/>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempAfternoonPM" HeaderText="Afternoon" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoAfternoonPM" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="บ่าย" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoAfternoonPM_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left"/>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempEveningPM" HeaderText="Evening" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoEveningPM" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="เย็น" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoEveningPM_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="CLINIC_TYPE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
    
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                             <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                             <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
                                                    <FilterMenu EnableTheming="True">
                                                        <CollapseAnimation Duration="200" Type="OutQuint" />
                                                    </FilterMenu>
                                                </telerik:RadGrid>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="pageRegularCNMI" runat="server">
                                                <telerik:RadGrid ID="grdAppointmentCNMI" runat="server" ShowHeader="false" ShowGroupPanel="false"
                                                    ShowStatusBar="false" AllowPaging="True" Height="168px" PageSize="10"
                                                    OnNeedDataSource="grdAppointmentCNMI_NeedDataSource"
                                                    OnItemDataBound="grdAppointmentCNMI_ItemDataBound"
                                                    >
                                                    <ClientSettings>
                                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="50px"></Scrolling>
                                                    </ClientSettings>
                                                    <MasterTableView TableLayout="Fixed" DataKeyNames="SCHEDULE_ID" AutoGenerateColumns="false"
                                                        Summary="grdData table" ShowHeader="False" ShowHeadersWhenNoRecords="False" GridLines="None">
                                                       <Columns>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_DESC_DATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" Wrap="true" HorizontalAlign="Right" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_DESC" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="100%" />
                                                                <ItemStyle Width="100%" Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempMorningCNMI" HeaderText="Morning" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoMorningCNMI" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="เช้า" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoMorningCNMI_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left"/>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempAfternoonCNMI" HeaderText="Afternoon" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoAfternoonCNMI" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="บ่าย" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoAfternoonCNMI_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left"/>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="rdotempEveningCNMI" HeaderText="Evening" ItemStyle-BorderStyle="Dashed">
                                                                <ItemTemplate>
                                                                    <telerik:RadButton ID="rdoEveningCNMI" ButtonType="ToggleButton" ToggleType="Radio"
                                                                                        runat="server" Text="เย็น" GroupName="ChangeDate" Checked="false"
                                                                                        OnCheckedChanged="rdoEveningCNMI_CheckedChanged" 
                                                                                        >
                                                                    </telerik:RadButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="55px" />
                                                                <ItemStyle Width="55px" HorizontalAlign="Left" />
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="CLINIC_TYPE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True">
                                                                <HeaderStyle Width="60px" />
                                                                <ItemStyle Width="60px" Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
    
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                            <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_M" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                             <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_A" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>

                                                             <telerik:GridBoundColumn DataField="SCHEDULE_STARTDATE_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SCHEDULE_ENDDATE_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="SESSION_ID_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="AVG_INV_TIME_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="MODALITY_ID_E" HeaderText="" AutoPostBackOnFilter="true"
                                                                ShowFilterIcon="false" AllowFiltering="True" Visible="false">
                                                                <ItemStyle Wrap="true" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
                                                    <FilterMenu EnableTheming="True">
                                                        <CollapseAnimation Duration="200" Type="OutQuint" />
                                                    </FilterMenu>
                                                </telerik:RadGrid>
                                            </telerik:RadPageView>
                                            </telerik:RadMultiPage>
                                            </td>
                                        </tr>
                                    </table>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <telerik:RadGrid ID="grdDetail" runat="server" PageSize="5" AllowSorting="True" AllowPaging="True" 
                                OnNeedDataSource="grdDetail_NeedDataSource" 
                                OnItemCommand="grdDetail_ItemCommand"
                                OnItemDataBound="grdDetail_ItemDataBound"
                                >
                                <MasterTableView EditMode="InPlace" AutoGenerateColumns="false" TableLayout="Auto"
                                    DataKeyNames="EXAM_ID" ClientDataKeyNames="ORDER_ID,EXAM_ID,CLINICAL_INSTRUCTION,strEXAM_DT,NEED_SCHEDULE,PRIORITY"
                                    Summary="grdData table">
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="cmbtempPriority" HeaderText="Priority" ItemStyle-BorderStyle="None">
                                            <ItemTemplate>
                                                <telerik:RadComboBox runat="server" ID="cmbPriority" Width="55px" ExpandDelay="10" BorderStyle="None" OnSelectedIndexChanged="cmbPriority_SelectedIndexChanged" AutoPostBack="True">
                                                </telerik:RadComboBox>
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_NAME" HeaderText="Exam Name" SortExpression="EXAM_NAME"
                                            UniqueName="colEXAM_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" HeaderText="Portable" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle Width="25px" />
                                            <ItemTemplate>
                                                <asp:CheckBox id="chkPortable" OnCheckedChanged="chkPortable_CheckedChanged" AutoPostBack="True" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="cmbtempSide" HeaderText="Side" ItemStyle-BorderStyle="None">
                                            <HeaderStyle Width="50px" />
                                            <ItemTemplate>
                                                <telerik:RadComboBox runat="server" ID="cmbSide" Width="85px" ExpandDelay="10" BorderStyle="None" 
                                                OnSelectedIndexChanged="cmbSide_SelectedIndexChanged" AutoPostBack="True">
                                                </telerik:RadComboBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="RATE" HeaderText="Price" SortExpression="RATE"
                                            UniqueName="colRATE" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible ="false">
                                            <HeaderStyle Width="40px" />
                                            <ItemStyle Wrap="true" Width="40px" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TOTAL_RATE" HeaderText="Price" SortExpression="TOTAL_RATE"
                                            UniqueName="colTOTAL_RATE" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            <HeaderStyle Width="40px" />
                                            <ItemStyle Wrap="true" Width="40px" Font-Bold="true" ForeColor="Red"/>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="cmbtempClinic" HeaderText="Clinic" ItemStyle-BorderStyle="None">
                                            <HeaderStyle Width="45px" />
                                            <ItemTemplate>
                                                <telerik:RadComboBox runat="server" ID="cmbClinic" Width="75px" ExpandDelay="10" BorderStyle="None" 
                                                OnSelectedIndexChanged="cmbClinic_SelectedIndexChanged" AutoPostBack="True">
                                                </telerik:RadComboBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="strEXAM_DT" DataType="System.String" HeaderText="Datetime"
                                            SortExpression="strEXAM_DT" UniqueName="colstrEXAM_DT" AutoPostBackOnFilter="true"
                                            ShowFilterIcon="false">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle Wrap="False" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn CommandName="DeleteColumn" ButtonType="ImageButton" ConfirmText="Are you sure you want to delete this order?!"
                                            UniqueName="DeleteColumn" ImageUrl="../../Resources/ICON/delete.png">
                                            <HeaderStyle Width="16px" />
                                            <ItemStyle Width="16px" />
                                        </telerik:GridButtonColumn>


                                        <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status" SortExpression="Status"
                                            UniqueName="colStatus" AutoPostBackOnFilter="true" ShowFilterIcon="false" AllowFiltering="True"
                                            Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="STATUS_TEXT" HeaderText="Status" SortExpression="STATUS_TEXT"
                                            UniqueName="colSTATUS_TEXT" AutoPostBackOnFilter="true" ShowFilterIcon="false"
                                            AllowFiltering="True" Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PRIORITY" HeaderText="Priority" SortExpression="Priority"
                                            UniqueName="colPriority" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PRIORITY_TEXT" HeaderText="Priority" SortExpression="PRIORITY_TEXT"
                                            UniqueName="colPRIORITY_TEXT" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PAT_DEST_ID" HeaderText="Service Loc." SortExpression="PAT_DEST_ID"
                                            UniqueName="colPAT_DEST_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false"
                                            Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PAT_DEST_DESC" HeaderText="Service Loc." SortExpression="PAT_DEST_ID"
                                            UniqueName="colPAT_DEST_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false"
                                            Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ORDER_ID" HeaderText="ORDER_ID" SortExpression="ORDER_ID"
                                            UniqueName="colORDER_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_ID" HeaderText="Exam Code" SortExpression="EXAM_ID"
                                            UniqueName="colEXAM_ID" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EXAM_UID" HeaderText="Exam Code" SortExpression="EXAM_UID"
                                            UniqueName="colEXAM_UID" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="BPVIEW_NAME" HeaderText="Side" SortExpression="Side"
                                            UniqueName="colSide" AutoPostBackOnFilter="true" ShowFilterIcon="false" Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CREATED_BY" DataType="System.String" HeaderText="Ordered by."
                                            SortExpression="CREATED_BY" UniqueName="colCREATED_BY" AutoPostBackOnFilter="true"
                                            ShowFilterIcon="false" Visible="false">
                                            <ItemStyle Wrap="False" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CREATED_NAME" HeaderText="Ordered by." SortExpression="CREATED_NAME"
                                            UniqueName="colCREATED_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false"
                                            Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RADIOLOGIST" HeaderText="Radiologist" SortExpression="RADIOLOGIST"
                                            UniqueName="colRADIOLOGIST" AutoPostBackOnFilter="true" ShowFilterIcon="false"
                                            Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ASSIGNED_NAME" HeaderText="Radiologist" SortExpression="ASSIGNED_NAME"
                                            UniqueName="colASSIGNED_NAME" AutoPostBackOnFilter="true" ShowFilterIcon="false"
                                            Visible="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="BPVIEW_ID" HeaderText="BPVIEW_ID" SortExpression="BPVIEW_ID"
                                            UniqueName="colBPVIEW_ID" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ACCESSION_NO" HeaderText="ACCESSION_NO" SortExpression="ACCESSION_NO"
                                            UniqueName="colACCESSION_NO" Visible="False" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CLINICAL_INSTRUCTION" HeaderText="CLINICAL_INSTRUCTION"
                                            UniqueName="colCLINICAL_INSTRUCTION" Visible="False" AutoPostBackOnFilter="true"
                                            ShowFilterIcon="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NEED_SCHEDULE" HeaderText="NEED_SCHEDULE"
                                            UniqueName="colNEED_SCHEDULE" Visible="False" AutoPostBackOnFilter="true"
                                            ShowFilterIcon="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="IS_CHOOSED_BPVIEW" HeaderText="IS_CHOOSED_BPVIEW"
                                            UniqueName="colIS_CHOOSED_BPVIEW" Visible="False" AutoPostBackOnFilter="true"
                                            ShowFilterIcon="false">
                                            <ItemStyle Wrap="true" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <PagerStyle Mode="NumericPages" PageButtonCount="5" PagerTextFormat="{4} Page {0} of {1}" />
                                <ClientSettings>
                                    <ClientEvents OnCellSelecting="grdDetailCellSelect" OnRowDblClick="RowDblClick" />
                                    <Selecting CellSelectionMode="SingleCell" />
                                </ClientSettings>
                                <FilterMenu EnableTheming="True">
                                    <CollapseAnimation Duration="200" Type="OutQuint" />
                                </FilterMenu>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
	</form>
</body>
</html>
