using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Configuration;

namespace EnvisionOnline.Common.Linq
{
    [System.Data.Linq.Mapping.DatabaseAttribute(Name = "RIS_RAMA")]
    public partial class EnvisionDataContext : System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        #region Extensibility Method Definitions
        partial void OnCreated();
        partial void InsertFIN_INVOICE(FIN_INVOICE instance);
        partial void UpdateFIN_INVOICE(FIN_INVOICE instance);
        partial void DeleteFIN_INVOICE(FIN_INVOICE instance);
        partial void InsertFIN_INVOICEDTL(FIN_INVOICEDTL instance);
        partial void UpdateFIN_INVOICEDTL(FIN_INVOICEDTL instance);
        partial void DeleteFIN_INVOICEDTL(FIN_INVOICEDTL instance);
        partial void InsertFIN_PAYMENT(FIN_PAYMENT instance);
        partial void UpdateFIN_PAYMENT(FIN_PAYMENT instance);
        partial void DeleteFIN_PAYMENT(FIN_PAYMENT instance);
        partial void InsertFIN_PAYMENTDTL(FIN_PAYMENTDTL instance);
        partial void UpdateFIN_PAYMENTDTL(FIN_PAYMENTDTL instance);
        partial void DeleteFIN_PAYMENTDTL(FIN_PAYMENTDTL instance);
        partial void InsertGBL_ALERT(GBL_ALERT instance);
        partial void UpdateGBL_ALERT(GBL_ALERT instance);
        partial void DeleteGBL_ALERT(GBL_ALERT instance);
        partial void InsertGBL_ALERTDTL(GBL_ALERTDTL instance);
        partial void UpdateGBL_ALERTDTL(GBL_ALERTDTL instance);
        partial void DeleteGBL_ALERTDTL(GBL_ALERTDTL instance);
        partial void InsertGBL_EMPSCHEDULE(GBL_EMPSCHEDULE instance);
        partial void UpdateGBL_EMPSCHEDULE(GBL_EMPSCHEDULE instance);
        partial void DeleteGBL_EMPSCHEDULE(GBL_EMPSCHEDULE instance);
        partial void InsertGBL_EMPSCHEDULECATEGORY(GBL_EMPSCHEDULECATEGORY instance);
        partial void UpdateGBL_EMPSCHEDULECATEGORY(GBL_EMPSCHEDULECATEGORY instance);
        partial void DeleteGBL_EMPSCHEDULECATEGORY(GBL_EMPSCHEDULECATEGORY instance);
        partial void InsertGBL_ENV(GBL_ENV instance);
        partial void UpdateGBL_ENV(GBL_ENV instance);
        partial void DeleteGBL_ENV(GBL_ENV instance);
        partial void InsertGBL_ENVLOG(GBL_ENVLOG instance);
        partial void UpdateGBL_ENVLOG(GBL_ENVLOG instance);
        partial void DeleteGBL_ENVLOG(GBL_ENVLOG instance);
        partial void InsertGBL_ENVLOGCAPTURE(GBL_ENVLOGCAPTURE instance);
        partial void UpdateGBL_ENVLOGCAPTURE(GBL_ENVLOGCAPTURE instance);
        partial void DeleteGBL_ENVLOGCAPTURE(GBL_ENVLOGCAPTURE instance);
        partial void InsertGBL_EXCEPTIONLOG(GBL_EXCEPTIONLOG instance);
        partial void UpdateGBL_EXCEPTIONLOG(GBL_EXCEPTIONLOG instance);
        partial void DeleteGBL_EXCEPTIONLOG(GBL_EXCEPTIONLOG instance);
        partial void InsertGBL_GENERAL(GBL_GENERAL instance);
        partial void UpdateGBL_GENERAL(GBL_GENERAL instance);
        partial void DeleteGBL_GENERAL(GBL_GENERAL instance);
        partial void InsertGBL_GENERALDTL(GBL_GENERALDTL instance);
        partial void UpdateGBL_GENERALDTL(GBL_GENERALDTL instance);
        partial void DeleteGBL_GENERALDTL(GBL_GENERALDTL instance);
        partial void InsertGBL_GRANTOBJECT(GBL_GRANTOBJECT instance);
        partial void UpdateGBL_GRANTOBJECT(GBL_GRANTOBJECT instance);
        partial void DeleteGBL_GRANTOBJECT(GBL_GRANTOBJECT instance);
        partial void InsertGBL_GRANTROLE(GBL_GRANTROLE instance);
        partial void UpdateGBL_GRANTROLE(GBL_GRANTROLE instance);
        partial void DeleteGBL_GRANTROLE(GBL_GRANTROLE instance);
        partial void InsertGBL_GROUP(GBL_GROUP instance);
        partial void UpdateGBL_GROUP(GBL_GROUP instance);
        partial void DeleteGBL_GROUP(GBL_GROUP instance);
        partial void InsertGBL_GROUPDTL(GBL_GROUPDTL instance);
        partial void UpdateGBL_GROUPDTL(GBL_GROUPDTL instance);
        partial void DeleteGBL_GROUPDTL(GBL_GROUPDTL instance);
        partial void InsertGBL_HOSPITAL(GBL_HOSPITAL instance);
        partial void UpdateGBL_HOSPITAL(GBL_HOSPITAL instance);
        partial void DeleteGBL_HOSPITAL(GBL_HOSPITAL instance);
        partial void InsertGBL_LANGUAGE(GBL_LANGUAGE instance);
        partial void UpdateGBL_LANGUAGE(GBL_LANGUAGE instance);
        partial void DeleteGBL_LANGUAGE(GBL_LANGUAGE instance);
        partial void InsertGBL_MENU(GBL_MENU instance);
        partial void UpdateGBL_MENU(GBL_MENU instance);
        partial void DeleteGBL_MENU(GBL_MENU instance);
        partial void InsertGBL_MYMENU(GBL_MYMENU instance);
        partial void UpdateGBL_MYMENU(GBL_MYMENU instance);
        partial void DeleteGBL_MYMENU(GBL_MYMENU instance);
        partial void InsertGBL_PRODUCT(GBL_PRODUCT instance);
        partial void UpdateGBL_PRODUCT(GBL_PRODUCT instance);
        partial void DeleteGBL_PRODUCT(GBL_PRODUCT instance);
        partial void InsertGBL_RADEXPERIENCE(GBL_RADEXPERIENCE instance);
        partial void UpdateGBL_RADEXPERIENCE(GBL_RADEXPERIENCE instance);
        partial void DeleteGBL_RADEXPERIENCE(GBL_RADEXPERIENCE instance);
        partial void InsertGBL_ROLE(GBL_ROLE instance);
        partial void UpdateGBL_ROLE(GBL_ROLE instance);
        partial void DeleteGBL_ROLE(GBL_ROLE instance);
        partial void InsertGBL_ROLEDTL(GBL_ROLEDTL instance);
        partial void UpdateGBL_ROLEDTL(GBL_ROLEDTL instance);
        partial void DeleteGBL_ROLEDTL(GBL_ROLEDTL instance);
        partial void InsertGBL_SEQUENCE(GBL_SEQUENCE instance);
        partial void UpdateGBL_SEQUENCE(GBL_SEQUENCE instance);
        partial void DeleteGBL_SEQUENCE(GBL_SEQUENCE instance);
        partial void InsertGBL_SESSION(GBL_SESSION instance);
        partial void UpdateGBL_SESSION(GBL_SESSION instance);
        partial void DeleteGBL_SESSION(GBL_SESSION instance);
        partial void InsertGBL_SESSIONLOG(GBL_SESSIONLOG instance);
        partial void UpdateGBL_SESSIONLOG(GBL_SESSIONLOG instance);
        partial void DeleteGBL_SESSIONLOG(GBL_SESSIONLOG instance);
        partial void InsertGBL_SUBMENU(GBL_SUBMENU instance);
        partial void UpdateGBL_SUBMENU(GBL_SUBMENU instance);
        partial void DeleteGBL_SUBMENU(GBL_SUBMENU instance);
        partial void InsertGBL_SUBMENUOBJECTLABEL(GBL_SUBMENUOBJECTLABEL instance);
        partial void UpdateGBL_SUBMENUOBJECTLABEL(GBL_SUBMENUOBJECTLABEL instance);
        partial void DeleteGBL_SUBMENUOBJECTLABEL(GBL_SUBMENUOBJECTLABEL instance);
        partial void InsertGBL_SUBMENUOBJECT(GBL_SUBMENUOBJECT instance);
        partial void UpdateGBL_SUBMENUOBJECT(GBL_SUBMENUOBJECT instance);
        partial void DeleteGBL_SUBMENUOBJECT(GBL_SUBMENUOBJECT instance);
        partial void InsertGBL_USERGROUP(GBL_USERGROUP instance);
        partial void UpdateGBL_USERGROUP(GBL_USERGROUP instance);
        partial void DeleteGBL_USERGROUP(GBL_USERGROUP instance);
        partial void InsertGBL_USERGROUPDTL(GBL_USERGROUPDTL instance);
        partial void UpdateGBL_USERGROUPDTL(GBL_USERGROUPDTL instance);
        partial void DeleteGBL_USERGROUPDTL(GBL_USERGROUPDTL instance);
        partial void InsertHIS_ICD(HIS_ICD instance);
        partial void UpdateHIS_ICD(HIS_ICD instance);
        partial void DeleteHIS_ICD(HIS_ICD instance);
        partial void InsertHIS_REGISTRATION(HIS_REGISTRATION instance);
        partial void UpdateHIS_REGISTRATION(HIS_REGISTRATION instance);
        partial void DeleteHIS_REGISTRATION(HIS_REGISTRATION instance);
        partial void InsertHR_EMP(HR_EMP instance);
        partial void UpdateHR_EMP(HR_EMP instance);
        partial void DeleteHR_EMP(HR_EMP instance);
        partial void InsertHR_JOBTITLE(HR_JOBTITLE instance);
        partial void UpdateHR_JOBTITLE(HR_JOBTITLE instance);
        partial void DeleteHR_JOBTITLE(HR_JOBTITLE instance);
        partial void InsertHR_OCCUPATION(HR_OCCUPATION instance);
        partial void UpdateHR_OCCUPATION(HR_OCCUPATION instance);
        partial void DeleteHR_OCCUPATION(HR_OCCUPATION instance);
        partial void InsertHR_ROOM(HR_ROOM instance);
        partial void UpdateHR_ROOM(HR_ROOM instance);
        partial void DeleteHR_ROOM(HR_ROOM instance);
        partial void InsertHR_UNIT(HR_UNIT instance);
        partial void UpdateHR_UNIT(HR_UNIT instance);
        partial void DeleteHR_UNIT(HR_UNIT instance);
        partial void InsertINV_AUTHORISER(INV_AUTHORISER instance);
        partial void UpdateINV_AUTHORISER(INV_AUTHORISER instance);
        partial void DeleteINV_AUTHORISER(INV_AUTHORISER instance);
        partial void InsertINV_AUTHORIZATION(INV_AUTHORIZATION instance);
        partial void UpdateINV_AUTHORIZATION(INV_AUTHORIZATION instance);
        partial void DeleteINV_AUTHORIZATION(INV_AUTHORIZATION instance);
        partial void InsertINV_CATEGORY(INV_CATEGORY instance);
        partial void UpdateINV_CATEGORY(INV_CATEGORY instance);
        partial void DeleteINV_CATEGORY(INV_CATEGORY instance);
        partial void InsertINV_ITEM(INV_ITEM instance);
        partial void UpdateINV_ITEM(INV_ITEM instance);
        partial void DeleteINV_ITEM(INV_ITEM instance);
        partial void InsertINV_ITEMSTATUS(INV_ITEMSTATUS instance);
        partial void UpdateINV_ITEMSTATUS(INV_ITEMSTATUS instance);
        partial void DeleteINV_ITEMSTATUS(INV_ITEMSTATUS instance);
        partial void InsertINV_ITEMSTOCK(INV_ITEMSTOCK instance);
        partial void UpdateINV_ITEMSTOCK(INV_ITEMSTOCK instance);
        partial void DeleteINV_ITEMSTOCK(INV_ITEMSTOCK instance);
        partial void InsertINV_ITEMTYPE(INV_ITEMTYPE instance);
        partial void UpdateINV_ITEMTYPE(INV_ITEMTYPE instance);
        partial void DeleteINV_ITEMTYPE(INV_ITEMTYPE instance);
        partial void InsertINV_PO(INV_PO instance);
        partial void UpdateINV_PO(INV_PO instance);
        partial void DeleteINV_PO(INV_PO instance);
        partial void InsertINV_PODTL(INV_PODTL instance);
        partial void UpdateINV_PODTL(INV_PODTL instance);
        partial void DeleteINV_PODTL(INV_PODTL instance);
        partial void InsertINV_PR(INV_PR instance);
        partial void UpdateINV_PR(INV_PR instance);
        partial void DeleteINV_PR(INV_PR instance);
        partial void InsertINV_PRDTL(INV_PRDTL instance);
        partial void UpdateINV_PRDTL(INV_PRDTL instance);
        partial void DeleteINV_PRDTL(INV_PRDTL instance);
        partial void InsertINV_REQUISITION(INV_REQUISITION instance);
        partial void UpdateINV_REQUISITION(INV_REQUISITION instance);
        partial void DeleteINV_REQUISITION(INV_REQUISITION instance);
        partial void InsertINV_REQUISITIONDTL(INV_REQUISITIONDTL instance);
        partial void UpdateINV_REQUISITIONDTL(INV_REQUISITIONDTL instance);
        partial void DeleteINV_REQUISITIONDTL(INV_REQUISITIONDTL instance);
        partial void InsertINV_ROOMSTOCKREDUCE(INV_ROOMSTOCKREDUCE instance);
        partial void UpdateINV_ROOMSTOCKREDUCE(INV_ROOMSTOCKREDUCE instance);
        partial void DeleteINV_ROOMSTOCKREDUCE(INV_ROOMSTOCKREDUCE instance);
        partial void InsertINV_SETTING(INV_SETTING instance);
        partial void UpdateINV_SETTING(INV_SETTING instance);
        partial void DeleteINV_SETTING(INV_SETTING instance);
        partial void InsertINV_TRANSACTION(INV_TRANSACTION instance);
        partial void UpdateINV_TRANSACTION(INV_TRANSACTION instance);
        partial void DeleteINV_TRANSACTION(INV_TRANSACTION instance);
        partial void InsertINV_TRANSACTIONDTL(INV_TRANSACTIONDTL instance);
        partial void UpdateINV_TRANSACTIONDTL(INV_TRANSACTIONDTL instance);
        partial void DeleteINV_TRANSACTIONDTL(INV_TRANSACTIONDTL instance);
        partial void InsertINV_TRANSACTIONTYPE(INV_TRANSACTIONTYPE instance);
        partial void UpdateINV_TRANSACTIONTYPE(INV_TRANSACTIONTYPE instance);
        partial void DeleteINV_TRANSACTIONTYPE(INV_TRANSACTIONTYPE instance);
        partial void InsertINV_TXNUNIT(INV_TXNUNIT instance);
        partial void UpdateINV_TXNUNIT(INV_TXNUNIT instance);
        partial void DeleteINV_TXNUNIT(INV_TXNUNIT instance);
        partial void InsertINV_UNIT(INV_UNIT instance);
        partial void UpdateINV_UNIT(INV_UNIT instance);
        partial void DeleteINV_UNIT(INV_UNIT instance);
        partial void InsertINV_UNITREORDERLEVEL(INV_UNITREORDERLEVEL instance);
        partial void UpdateINV_UNITREORDERLEVEL(INV_UNITREORDERLEVEL instance);
        partial void DeleteINV_UNITREORDERLEVEL(INV_UNITREORDERLEVEL instance);
        partial void InsertINV_VENDOR(INV_VENDOR instance);
        partial void UpdateINV_VENDOR(INV_VENDOR instance);
        partial void DeleteINV_VENDOR(INV_VENDOR instance);
        partial void InsertMIS_ASESSMENTTYPE(MIS_ASESSMENTTYPE instance);
        partial void UpdateMIS_ASESSMENTTYPE(MIS_ASESSMENTTYPE instance);
        partial void DeleteMIS_ASESSMENTTYPE(MIS_ASESSMENTTYPE instance);
        partial void InsertMIS_BIOPSYRESULT(MIS_BIOPSYRESULT instance);
        partial void UpdateMIS_BIOPSYRESULT(MIS_BIOPSYRESULT instance);
        partial void DeleteMIS_BIOPSYRESULT(MIS_BIOPSYRESULT instance);
        partial void InsertMIS_LESIONTYPE(MIS_LESIONTYPE instance);
        partial void UpdateMIS_LESIONTYPE(MIS_LESIONTYPE instance);
        partial void DeleteMIS_LESIONTYPE(MIS_LESIONTYPE instance);
        partial void InsertMIS_TECHNIQUETYPE(MIS_TECHNIQUETYPE instance);
        partial void UpdateMIS_TECHNIQUETYPE(MIS_TECHNIQUETYPE instance);
        partial void DeleteMIS_TECHNIQUETYPE(MIS_TECHNIQUETYPE instance);
        partial void InsertRIS_ACR(RIS_ACR instance);
        partial void UpdateRIS_ACR(RIS_ACR instance);
        partial void DeleteRIS_ACR(RIS_ACR instance);
        partial void InsertRIS_ASSESSMENT(RIS_ASSESSMENT instance);
        partial void UpdateRIS_ASSESSMENT(RIS_ASSESSMENT instance);
        partial void DeleteRIS_ASSESSMENT(RIS_ASSESSMENT instance);
        partial void InsertRIS_AUTHLEVEL(RIS_AUTHLEVEL instance);
        partial void UpdateRIS_AUTHLEVEL(RIS_AUTHLEVEL instance);
        partial void DeleteRIS_AUTHLEVEL(RIS_AUTHLEVEL instance);
        partial void InsertRIS_AUTOMERGECONFIG(RIS_AUTOMERGECONFIG instance);
        partial void UpdateRIS_AUTOMERGECONFIG(RIS_AUTOMERGECONFIG instance);
        partial void DeleteRIS_AUTOMERGECONFIG(RIS_AUTOMERGECONFIG instance);
        partial void InsertRIS_BILL(RIS_BILL instance);
        partial void UpdateRIS_BILL(RIS_BILL instance);
        partial void DeleteRIS_BILL(RIS_BILL instance);
        partial void InsertRIS_BODYPART(RIS_BODYPART instance);
        partial void UpdateRIS_BODYPART(RIS_BODYPART instance);
        partial void DeleteRIS_BODYPART(RIS_BODYPART instance);
        partial void InsertRIS_BPVIEW(RIS_BPVIEW instance);
        partial void UpdateRIS_BPVIEW(RIS_BPVIEW instance);
        partial void DeleteRIS_BPVIEW(RIS_BPVIEW instance);
        partial void InsertRIS_CLINICSESSION(RIS_CLINICSESSION instance);
        partial void UpdateRIS_CLINICSESSION(RIS_CLINICSESSION instance);
        partial void DeleteRIS_CLINICSESSION(RIS_CLINICSESSION instance);
        partial void InsertRIS_CLINICTYPE(RIS_CLINICTYPE instance);
        partial void UpdateRIS_CLINICTYPE(RIS_CLINICTYPE instance);
        partial void DeleteRIS_CLINICTYPE(RIS_CLINICTYPE instance);
        partial void InsertRIS_CONFLICTEXAMDTL(RIS_CONFLICTEXAMDTL instance);
        partial void UpdateRIS_CONFLICTEXAMDTL(RIS_CONFLICTEXAMDTL instance);
        partial void DeleteRIS_CONFLICTEXAMDTL(RIS_CONFLICTEXAMDTL instance);
        partial void InsertRIS_CONFLICTEXAMGROUP(RIS_CONFLICTEXAMGROUP instance);
        partial void UpdateRIS_CONFLICTEXAMGROUP(RIS_CONFLICTEXAMGROUP instance);
        partial void DeleteRIS_CONFLICTEXAMGROUP(RIS_CONFLICTEXAMGROUP instance);
        partial void InsertRIS_CONSUMABLETYPE(RIS_CONSUMABLETYPE instance);
        partial void UpdateRIS_CONSUMABLETYPE(RIS_CONSUMABLETYPE instance);
        partial void DeleteRIS_CONSUMABLETYPE(RIS_CONSUMABLETYPE instance);
        partial void InsertRIS_EXAM(RIS_EXAM instance);
        partial void UpdateRIS_EXAM(RIS_EXAM instance);
        partial void DeleteRIS_EXAM(RIS_EXAM instance);
        partial void InsertRIS_EXAMINSTRUCTION(RIS_EXAMINSTRUCTION instance);
        partial void UpdateRIS_EXAMINSTRUCTION(RIS_EXAMINSTRUCTION instance);
        partial void DeleteRIS_EXAMINSTRUCTION(RIS_EXAMINSTRUCTION instance);
        partial void InsertRIS_EXAMLOG(RIS_EXAMLOG instance);
        partial void UpdateRIS_EXAMLOG(RIS_EXAMLOG instance);
        partial void DeleteRIS_EXAMLOG(RIS_EXAMLOG instance);
        partial void InsertRIS_EXAMLOGCAPTURE(RIS_EXAMLOGCAPTURE instance);
        partial void UpdateRIS_EXAMLOGCAPTURE(RIS_EXAMLOGCAPTURE instance);
        partial void DeleteRIS_EXAMLOGCAPTURE(RIS_EXAMLOGCAPTURE instance);
        partial void InsertRIS_EXAMRESULT(RIS_EXAMRESULT instance);
        partial void UpdateRIS_EXAMRESULT(RIS_EXAMRESULT instance);
        partial void DeleteRIS_EXAMRESULT(RIS_EXAMRESULT instance);
        partial void InsertRIS_EXAMRESULTACCESS(RIS_EXAMRESULTACCESS instance);
        partial void UpdateRIS_EXAMRESULTACCESS(RIS_EXAMRESULTACCESS instance);
        partial void DeleteRIS_EXAMRESULTACCESS(RIS_EXAMRESULTACCESS instance);
        partial void InsertRIS_EXAMRESULTLEGACY(RIS_EXAMRESULTLEGACY instance);
        partial void UpdateRIS_EXAMRESULTLEGACY(RIS_EXAMRESULTLEGACY instance);
        partial void DeleteRIS_EXAMRESULTLEGACY(RIS_EXAMRESULTLEGACY instance);
        partial void InsertRIS_EXAMRESULTLOCK(RIS_EXAMRESULTLOCK instance);
        partial void UpdateRIS_EXAMRESULTLOCK(RIS_EXAMRESULTLOCK instance);
        partial void DeleteRIS_EXAMRESULTLOCK(RIS_EXAMRESULTLOCK instance);
        partial void InsertRIS_EXAMRESULTLOG(RIS_EXAMRESULTLOG instance);
        partial void UpdateRIS_EXAMRESULTLOG(RIS_EXAMRESULTLOG instance);
        partial void DeleteRIS_EXAMRESULTLOG(RIS_EXAMRESULTLOG instance);
        partial void InsertRIS_EXAMRESULTLOGCAPTURE(RIS_EXAMRESULTLOGCAPTURE instance);
        partial void UpdateRIS_EXAMRESULTLOGCAPTURE(RIS_EXAMRESULTLOGCAPTURE instance);
        partial void DeleteRIS_EXAMRESULTLOGCAPTURE(RIS_EXAMRESULTLOGCAPTURE instance);
        partial void InsertRIS_EXAMRESULTNOTE(RIS_EXAMRESULTNOTE instance);
        partial void UpdateRIS_EXAMRESULTNOTE(RIS_EXAMRESULTNOTE instance);
        partial void DeleteRIS_EXAMRESULTNOTE(RIS_EXAMRESULTNOTE instance);
        partial void InsertRIS_EXAMRESULTSEVERITY(RIS_EXAMRESULTSEVERITY instance);
        partial void UpdateRIS_EXAMRESULTSEVERITY(RIS_EXAMRESULTSEVERITY instance);
        partial void DeleteRIS_EXAMRESULTSEVERITY(RIS_EXAMRESULTSEVERITY instance);
        partial void InsertRIS_EXAMRESULTTEMPLATE(RIS_EXAMRESULTTEMPLATE instance);
        partial void UpdateRIS_EXAMRESULTTEMPLATE(RIS_EXAMRESULTTEMPLATE instance);
        partial void DeleteRIS_EXAMRESULTTEMPLATE(RIS_EXAMRESULTTEMPLATE instance);
        partial void InsertRIS_EXAMRESULTTEMPLATELOG(RIS_EXAMRESULTTEMPLATELOG instance);
        partial void UpdateRIS_EXAMRESULTTEMPLATELOG(RIS_EXAMRESULTTEMPLATELOG instance);
        partial void DeleteRIS_EXAMRESULTTEMPLATELOG(RIS_EXAMRESULTTEMPLATELOG instance);
        partial void InsertRIS_EXAMRESULTTEMPLATELOGCAPTURE(RIS_EXAMRESULTTEMPLATELOGCAPTURE instance);
        partial void UpdateRIS_EXAMRESULTTEMPLATELOGCAPTURE(RIS_EXAMRESULTTEMPLATELOGCAPTURE instance);
        partial void DeleteRIS_EXAMRESULTTEMPLATELOGCAPTURE(RIS_EXAMRESULTTEMPLATELOGCAPTURE instance);
        partial void InsertRIS_EXAMTEMPLATESHARE(RIS_EXAMTEMPLATESHARE instance);
        partial void UpdateRIS_EXAMTEMPLATESHARE(RIS_EXAMTEMPLATESHARE instance);
        partial void DeleteRIS_EXAMTEMPLATESHARE(RIS_EXAMTEMPLATESHARE instance);
        partial void InsertRIS_EXAMTRANSFERLOG(RIS_EXAMTRANSFERLOG instance);
        partial void UpdateRIS_EXAMTRANSFERLOG(RIS_EXAMTRANSFERLOG instance);
        partial void DeleteRIS_EXAMTRANSFERLOG(RIS_EXAMTRANSFERLOG instance);
        partial void InsertRIS_EXAMTYPE(RIS_EXAMTYPE instance);
        partial void UpdateRIS_EXAMTYPE(RIS_EXAMTYPE instance);
        partial void DeleteRIS_EXAMTYPE(RIS_EXAMTYPE instance);
        partial void InsertRIS_HOSPITAL_MAP_DOCTOR(RIS_HOSPITAL_MAP_DOCTOR instance);
        partial void UpdateRIS_HOSPITAL_MAP_DOCTOR(RIS_HOSPITAL_MAP_DOCTOR instance);
        partial void DeleteRIS_HOSPITAL_MAP_DOCTOR(RIS_HOSPITAL_MAP_DOCTOR instance);
        partial void InsertRIS_INSURANCETYPE(RIS_INSURANCETYPE instance);
        partial void UpdateRIS_INSURANCETYPE(RIS_INSURANCETYPE instance);
        partial void DeleteRIS_INSURANCETYPE(RIS_INSURANCETYPE instance);
        partial void InsertRIS_LOADMEDIA(RIS_LOADMEDIA instance);
        partial void UpdateRIS_LOADMEDIA(RIS_LOADMEDIA instance);
        partial void DeleteRIS_LOADMEDIA(RIS_LOADMEDIA instance);
        partial void InsertRIS_LOADMEDIADTL(RIS_LOADMEDIADTL instance);
        partial void UpdateRIS_LOADMEDIADTL(RIS_LOADMEDIADTL instance);
        partial void DeleteRIS_LOADMEDIADTL(RIS_LOADMEDIADTL instance);
        partial void InsertRIS_MODALITY(RIS_MODALITY instance);
        partial void UpdateRIS_MODALITY(RIS_MODALITY instance);
        partial void DeleteRIS_MODALITY(RIS_MODALITY instance);
        partial void InsertRIS_MODALITYCLINICTYPE(RIS_MODALITYCLINICTYPE instance);
        partial void UpdateRIS_MODALITYCLINICTYPE(RIS_MODALITYCLINICTYPE instance);
        partial void DeleteRIS_MODALITYCLINICTYPE(RIS_MODALITYCLINICTYPE instance);
        partial void InsertRIS_MODALITYEXAM(RIS_MODALITYEXAM instance);
        partial void UpdateRIS_MODALITYEXAM(RIS_MODALITYEXAM instance);
        partial void DeleteRIS_MODALITYEXAM(RIS_MODALITYEXAM instance);
        partial void InsertRIS_MODALITYTYPE(RIS_MODALITYTYPE instance);
        partial void UpdateRIS_MODALITYTYPE(RIS_MODALITYTYPE instance);
        partial void DeleteRIS_MODALITYTYPE(RIS_MODALITYTYPE instance);
        partial void InsertRIS_NURSESDATA(RIS_NURSESDATA instance);
        partial void UpdateRIS_NURSESDATA(RIS_NURSESDATA instance);
        partial void DeleteRIS_NURSESDATA(RIS_NURSESDATA instance);
        partial void InsertRIS_NURSESDATADTL(RIS_NURSESDATADTL instance);
        partial void UpdateRIS_NURSESDATADTL(RIS_NURSESDATADTL instance);
        partial void DeleteRIS_NURSESDATADTL(RIS_NURSESDATADTL instance);
        partial void InsertRIS_OPNOTEITEM(RIS_OPNOTEITEM instance);
        partial void UpdateRIS_OPNOTEITEM(RIS_OPNOTEITEM instance);
        partial void DeleteRIS_OPNOTEITEM(RIS_OPNOTEITEM instance);
        partial void InsertRIS_OPNOTEITEMTEMPLATE(RIS_OPNOTEITEMTEMPLATE instance);
        partial void UpdateRIS_OPNOTEITEMTEMPLATE(RIS_OPNOTEITEMTEMPLATE instance);
        partial void DeleteRIS_OPNOTEITEMTEMPLATE(RIS_OPNOTEITEMTEMPLATE instance);
        partial void InsertRIS_ORDER(RIS_ORDER instance);
        partial void UpdateRIS_ORDER(RIS_ORDER instance);
        partial void DeleteRIS_ORDER(RIS_ORDER instance);
        partial void InsertRIS_ORDERDTL(RIS_ORDERDTL instance);
        partial void UpdateRIS_ORDERDTL(RIS_ORDERDTL instance);
        partial void DeleteRIS_ORDERDTL(RIS_ORDERDTL instance);
        partial void InsertRIS_ORDERIMAGE(RIS_ORDERIMAGE instance);
        partial void UpdateRIS_ORDERIMAGE(RIS_ORDERIMAGE instance);
        partial void DeleteRIS_ORDERIMAGE(RIS_ORDERIMAGE instance);
        partial void InsertRIS_PATICD(RIS_PATICD instance);
        partial void UpdateRIS_PATICD(RIS_PATICD instance);
        partial void DeleteRIS_PATICD(RIS_PATICD instance);
        partial void InsertRIS_PATIENTPREPARATION(RIS_PATIENTPREPARATION instance);
        partial void UpdateRIS_PATIENTPREPARATION(RIS_PATIENTPREPARATION instance);
        partial void DeleteRIS_PATIENTPREPARATION(RIS_PATIENTPREPARATION instance);
        partial void InsertRIS_PATSTATUS(RIS_PATSTATUS instance);
        partial void UpdateRIS_PATSTATUS(RIS_PATSTATUS instance);
        partial void DeleteRIS_PATSTATUS(RIS_PATSTATUS instance);
        partial void InsertRIS_QAREASON(RIS_QAREASON instance);
        partial void UpdateRIS_QAREASON(RIS_QAREASON instance);
        partial void DeleteRIS_QAREASON(RIS_QAREASON instance);
        partial void InsertRIS_QAWORK(RIS_QAWORK instance);
        partial void UpdateRIS_QAWORK(RIS_QAWORK instance);
        partial void DeleteRIS_QAWORK(RIS_QAWORK instance);
        partial void InsertRIS_QUESTION(RIS_QUESTION instance);
        partial void UpdateRIS_QUESTION(RIS_QUESTION instance);
        partial void DeleteRIS_QUESTION(RIS_QUESTION instance);
        partial void InsertRIS_RADSTUDYGROUP(RIS_RADSTUDYGROUP instance);
        partial void UpdateRIS_RADSTUDYGROUP(RIS_RADSTUDYGROUP instance);
        partial void DeleteRIS_RADSTUDYGROUP(RIS_RADSTUDYGROUP instance);
        partial void InsertRIS_RELEASEMEDIA(RIS_RELEASEMEDIA instance);
        partial void UpdateRIS_RELEASEMEDIA(RIS_RELEASEMEDIA instance);
        partial void DeleteRIS_RELEASEMEDIA(RIS_RELEASEMEDIA instance);
        partial void InsertRIS_RESULTSTATUSCHANGELOG(RIS_RESULTSTATUSCHANGELOG instance);
        partial void UpdateRIS_RESULTSTATUSCHANGELOG(RIS_RESULTSTATUSCHANGELOG instance);
        partial void DeleteRIS_RESULTSTATUSCHANGELOG(RIS_RESULTSTATUSCHANGELOG instance);
        partial void InsertRIS_SCHEDULE(RIS_SCHEDULE instance);
        partial void UpdateRIS_SCHEDULE(RIS_SCHEDULE instance);
        partial void DeleteRIS_SCHEDULE(RIS_SCHEDULE instance);
        partial void InsertRIS_SCHEDULEDTL(RIS_SCHEDULEDTL instance);
        partial void UpdateRIS_SCHEDULEDTL(RIS_SCHEDULEDTL instance);
        partial void DeleteRIS_SCHEDULEDTL(RIS_SCHEDULEDTL instance);
        partial void InsertRIS_SCHEDULELOG(RIS_SCHEDULELOG instance);
        partial void UpdateRIS_SCHEDULELOG(RIS_SCHEDULELOG instance);
        partial void DeleteRIS_SCHEDULELOG(RIS_SCHEDULELOG instance);
        partial void InsertRIS_SCHEDULELOGCAPTURE(RIS_SCHEDULELOGCAPTURE instance);
        partial void UpdateRIS_SCHEDULELOGCAPTURE(RIS_SCHEDULELOGCAPTURE instance);
        partial void DeleteRIS_SCHEDULELOGCAPTURE(RIS_SCHEDULELOGCAPTURE instance);
        partial void InsertRIS_SEARCH(RIS_SEARCH instance);
        partial void UpdateRIS_SEARCH(RIS_SEARCH instance);
        partial void DeleteRIS_SEARCH(RIS_SEARCH instance);
        partial void InsertRIS_SEARCH_DTL(RIS_SEARCH_DTL instance);
        partial void UpdateRIS_SEARCH_DTL(RIS_SEARCH_DTL instance);
        partial void DeleteRIS_SEARCH_DTL(RIS_SEARCH_DTL instance);
        partial void InsertRIS_SERVICETYPE(RIS_SERVICETYPE instance);
        partial void UpdateRIS_SERVICETYPE(RIS_SERVICETYPE instance);
        partial void DeleteRIS_SERVICETYPE(RIS_SERVICETYPE instance);
        partial void InsertRIS_SESSIONMAXAPP(RIS_SESSIONMAXAPP instance);
        partial void UpdateRIS_SESSIONMAXAPP(RIS_SESSIONMAXAPP instance);
        partial void DeleteRIS_SESSIONMAXAPP(RIS_SESSIONMAXAPP instance);
        partial void InsertRIS_TECHCONSUMPTION(RIS_TECHCONSUMPTION instance);
        partial void UpdateRIS_TECHCONSUMPTION(RIS_TECHCONSUMPTION instance);
        partial void DeleteRIS_TECHCONSUMPTION(RIS_TECHCONSUMPTION instance);
        partial void InsertRIS_TECHWORK(RIS_TECHWORK instance);
        partial void UpdateRIS_TECHWORK(RIS_TECHWORK instance);
        partial void DeleteRIS_TECHWORK(RIS_TECHWORK instance);
        partial void InsertRIS_TIME(RIS_TIME instance);
        partial void UpdateRIS_TIME(RIS_TIME instance);
        partial void DeleteRIS_TIME(RIS_TIME instance);
        partial void InsertRIS_TIMELEVEL(RIS_TIMELEVEL instance);
        partial void UpdateRIS_TIMELEVEL(RIS_TIMELEVEL instance);
        partial void DeleteRIS_TIMELEVEL(RIS_TIMELEVEL instance);
        partial void InsertRIS_USERORGMAP(RIS_USERORGMAP instance);
        partial void UpdateRIS_USERORGMAP(RIS_USERORGMAP instance);
        partial void DeleteRIS_USERORGMAP(RIS_USERORGMAP instance);
        #endregion

        public EnvisionDataContext() :
            base(ConfigurationSettings.AppSettings["connStr"], mappingSource)
        {
            OnCreated();
        }

        public EnvisionDataContext(string connection) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public EnvisionDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public EnvisionDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public EnvisionDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<FIN_INVOICE> FIN_INVOICEs
        {
            get
            {
                return this.GetTable<FIN_INVOICE>();
            }
        }

        public System.Data.Linq.Table<TR_FINALIZED> TR_FINALIZEDs
        {
            get
            {
                return this.GetTable<TR_FINALIZED>();
            }
        }

        public System.Data.Linq.Table<FIN_INVOICEDTL> FIN_INVOICEDTLs
        {
            get
            {
                return this.GetTable<FIN_INVOICEDTL>();
            }
        }

        public System.Data.Linq.Table<FIN_PAYMENT> FIN_PAYMENTs
        {
            get
            {
                return this.GetTable<FIN_PAYMENT>();
            }
        }

        public System.Data.Linq.Table<FIN_PAYMENTDTL> FIN_PAYMENTDTLs
        {
            get
            {
                return this.GetTable<FIN_PAYMENTDTL>();
            }
        }

        public System.Data.Linq.Table<GBL_ALERT> GBL_ALERTs
        {
            get
            {
                return this.GetTable<GBL_ALERT>();
            }
        }

        public System.Data.Linq.Table<GBL_ALERTDTL> GBL_ALERTDTLs
        {
            get
            {
                return this.GetTable<GBL_ALERTDTL>();
            }
        }

        public System.Data.Linq.Table<GBL_EMPSCHEDULE> GBL_EMPSCHEDULEs
        {
            get
            {
                return this.GetTable<GBL_EMPSCHEDULE>();
            }
        }

        public System.Data.Linq.Table<GBL_EMPSCHEDULECATEGORY> GBL_EMPSCHEDULECATEGORies
        {
            get
            {
                return this.GetTable<GBL_EMPSCHEDULECATEGORY>();
            }
        }

        public System.Data.Linq.Table<GBL_ENV> GBL_ENVs
        {
            get
            {
                return this.GetTable<GBL_ENV>();
            }
        }

        public System.Data.Linq.Table<GBL_ENVLOG> GBL_ENVLOGs
        {
            get
            {
                return this.GetTable<GBL_ENVLOG>();
            }
        }

        public System.Data.Linq.Table<GBL_ENVLOGCAPTURE> GBL_ENVLOGCAPTUREs
        {
            get
            {
                return this.GetTable<GBL_ENVLOGCAPTURE>();
            }
        }

        public System.Data.Linq.Table<GBL_EXCEPTIONLOG> GBL_EXCEPTIONLOGs
        {
            get
            {
                return this.GetTable<GBL_EXCEPTIONLOG>();
            }
        }

        public System.Data.Linq.Table<GBL_GENERAL> GBL_GENERALs
        {
            get
            {
                return this.GetTable<GBL_GENERAL>();
            }
        }

        public System.Data.Linq.Table<GBL_GENERALDTL> GBL_GENERALDTLs
        {
            get
            {
                return this.GetTable<GBL_GENERALDTL>();
            }
        }

        public System.Data.Linq.Table<GBL_GRANTOBJECT> GBL_GRANTOBJECTs
        {
            get
            {
                return this.GetTable<GBL_GRANTOBJECT>();
            }
        }

        public System.Data.Linq.Table<GBL_GRANTROLE> GBL_GRANTROLEs
        {
            get
            {
                return this.GetTable<GBL_GRANTROLE>();
            }
        }

        public System.Data.Linq.Table<GBL_GROUP> GBL_GROUPs
        {
            get
            {
                return this.GetTable<GBL_GROUP>();
            }
        }

        public System.Data.Linq.Table<GBL_GROUPDTL> GBL_GROUPDTLs
        {
            get
            {
                return this.GetTable<GBL_GROUPDTL>();
            }
        }

        public System.Data.Linq.Table<GBL_HOSPITAL> GBL_HOSPITALs
        {
            get
            {
                return this.GetTable<GBL_HOSPITAL>();
            }
        }

        public System.Data.Linq.Table<GBL_LANGUAGE> GBL_LANGUAGEs
        {
            get
            {
                return this.GetTable<GBL_LANGUAGE>();
            }
        }

        public System.Data.Linq.Table<GBL_MENU> GBL_MENUs
        {
            get
            {
                return this.GetTable<GBL_MENU>();
            }
        }

        public System.Data.Linq.Table<GBL_MYMENU> GBL_MYMENUs
        {
            get
            {
                return this.GetTable<GBL_MYMENU>();
            }
        }

        public System.Data.Linq.Table<GBL_PRODUCT> GBL_PRODUCTs
        {
            get
            {
                return this.GetTable<GBL_PRODUCT>();
            }
        }

        public System.Data.Linq.Table<GBL_RADEXPERIENCE> GBL_RADEXPERIENCEs
        {
            get
            {
                return this.GetTable<GBL_RADEXPERIENCE>();
            }
        }

        public System.Data.Linq.Table<GBL_ROLE> GBL_ROLEs
        {
            get
            {
                return this.GetTable<GBL_ROLE>();
            }
        }

        public System.Data.Linq.Table<GBL_ROLEDTL> GBL_ROLEDTLs
        {
            get
            {
                return this.GetTable<GBL_ROLEDTL>();
            }
        }

        public System.Data.Linq.Table<GBL_SEQUENCE> GBL_SEQUENCEs
        {
            get
            {
                return this.GetTable<GBL_SEQUENCE>();
            }
        }

        public System.Data.Linq.Table<GBL_SESSION> GBL_SESSIONs
        {
            get
            {
                return this.GetTable<GBL_SESSION>();
            }
        }

        public System.Data.Linq.Table<GBL_SESSIONLOG> GBL_SESSIONLOGs
        {
            get
            {
                return this.GetTable<GBL_SESSIONLOG>();
            }
        }

        public System.Data.Linq.Table<GBL_SUBMENU> GBL_SUBMENUs
        {
            get
            {
                return this.GetTable<GBL_SUBMENU>();
            }
        }

        public System.Data.Linq.Table<GBL_SUBMENUOBJECTLABEL> GBL_SUBMENUOBJECTLABELs
        {
            get
            {
                return this.GetTable<GBL_SUBMENUOBJECTLABEL>();
            }
        }

        public System.Data.Linq.Table<GBL_SUBMENUOBJECT> GBL_SUBMENUOBJECTs
        {
            get
            {
                return this.GetTable<GBL_SUBMENUOBJECT>();
            }
        }

        public System.Data.Linq.Table<GBL_USERGROUP> GBL_USERGROUPs
        {
            get
            {
                return this.GetTable<GBL_USERGROUP>();
            }
        }

        public System.Data.Linq.Table<GBL_USERGROUPDTL> GBL_USERGROUPDTLs
        {
            get
            {
                return this.GetTable<GBL_USERGROUPDTL>();
            }
        }

        public System.Data.Linq.Table<HIS_ICD> HIS_ICDs
        {
            get
            {
                return this.GetTable<HIS_ICD>();
            }
        }

        public System.Data.Linq.Table<HIS_REGISTRATION> HIS_REGISTRATIONs
        {
            get
            {
                return this.GetTable<HIS_REGISTRATION>();
            }
        }

        public System.Data.Linq.Table<HR_EMP> HR_EMPs
        {
            get
            {
                return this.GetTable<HR_EMP>();
            }
        }

        public System.Data.Linq.Table<HR_JOBTITLE> HR_JOBTITLEs
        {
            get
            {
                return this.GetTable<HR_JOBTITLE>();
            }
        }

        public System.Data.Linq.Table<HR_OCCUPATION> HR_OCCUPATIONs
        {
            get
            {
                return this.GetTable<HR_OCCUPATION>();
            }
        }

        public System.Data.Linq.Table<HR_ROOM> HR_ROOMs
        {
            get
            {
                return this.GetTable<HR_ROOM>();
            }
        }

        public System.Data.Linq.Table<HR_UNIT> HR_UNITs
        {
            get
            {
                return this.GetTable<HR_UNIT>();
            }
        }

        public System.Data.Linq.Table<INV_AUTHORISER> INV_AUTHORISERs
        {
            get
            {
                return this.GetTable<INV_AUTHORISER>();
            }
        }

        public System.Data.Linq.Table<INV_AUTHORIZATION> INV_AUTHORIZATIONs
        {
            get
            {
                return this.GetTable<INV_AUTHORIZATION>();
            }
        }

        public System.Data.Linq.Table<INV_CATEGORY> INV_CATEGORies
        {
            get
            {
                return this.GetTable<INV_CATEGORY>();
            }
        }

        public System.Data.Linq.Table<INV_ITEM> INV_ITEMs
        {
            get
            {
                return this.GetTable<INV_ITEM>();
            }
        }

        public System.Data.Linq.Table<INV_ITEMSTATUS> INV_ITEMSTATUS
        {
            get
            {
                return this.GetTable<INV_ITEMSTATUS>();
            }
        }

        public System.Data.Linq.Table<INV_ITEMSTOCK> INV_ITEMSTOCKs
        {
            get
            {
                return this.GetTable<INV_ITEMSTOCK>();
            }
        }

        public System.Data.Linq.Table<INV_ITEMTYPE> INV_ITEMTYPEs
        {
            get
            {
                return this.GetTable<INV_ITEMTYPE>();
            }
        }

        public System.Data.Linq.Table<INV_PO> INV_POs
        {
            get
            {
                return this.GetTable<INV_PO>();
            }
        }

        public System.Data.Linq.Table<INV_PODTL> INV_PODTLs
        {
            get
            {
                return this.GetTable<INV_PODTL>();
            }
        }

        public System.Data.Linq.Table<INV_PR> INV_PRs
        {
            get
            {
                return this.GetTable<INV_PR>();
            }
        }

        public System.Data.Linq.Table<INV_PRDTL> INV_PRDTLs
        {
            get
            {
                return this.GetTable<INV_PRDTL>();
            }
        }

        public System.Data.Linq.Table<INV_REQUISITION> INV_REQUISITIONs
        {
            get
            {
                return this.GetTable<INV_REQUISITION>();
            }
        }

        public System.Data.Linq.Table<INV_REQUISITIONDTL> INV_REQUISITIONDTLs
        {
            get
            {
                return this.GetTable<INV_REQUISITIONDTL>();
            }
        }

        public System.Data.Linq.Table<INV_ROOMSTOCKREDUCE> INV_ROOMSTOCKREDUCEs
        {
            get
            {
                return this.GetTable<INV_ROOMSTOCKREDUCE>();
            }
        }

        public System.Data.Linq.Table<INV_SETTING> INV_SETTINGs
        {
            get
            {
                return this.GetTable<INV_SETTING>();
            }
        }

        public System.Data.Linq.Table<INV_TRANSACTION> INV_TRANSACTIONs
        {
            get
            {
                return this.GetTable<INV_TRANSACTION>();
            }
        }

        public System.Data.Linq.Table<INV_TRANSACTIONDTL> INV_TRANSACTIONDTLs
        {
            get
            {
                return this.GetTable<INV_TRANSACTIONDTL>();
            }
        }

        public System.Data.Linq.Table<INV_TRANSACTIONTYPE> INV_TRANSACTIONTYPEs
        {
            get
            {
                return this.GetTable<INV_TRANSACTIONTYPE>();
            }
        }

        public System.Data.Linq.Table<INV_TXNUNIT> INV_TXNUNITs
        {
            get
            {
                return this.GetTable<INV_TXNUNIT>();
            }
        }

        public System.Data.Linq.Table<INV_UNIT> INV_UNITs
        {
            get
            {
                return this.GetTable<INV_UNIT>();
            }
        }

        public System.Data.Linq.Table<INV_UNITREORDERLEVEL> INV_UNITREORDERLEVELs
        {
            get
            {
                return this.GetTable<INV_UNITREORDERLEVEL>();
            }
        }

        public System.Data.Linq.Table<INV_VENDOR> INV_VENDORs
        {
            get
            {
                return this.GetTable<INV_VENDOR>();
            }
        }

        public System.Data.Linq.Table<MIS_ASESSMENTTYPE> MIS_ASESSMENTTYPEs
        {
            get
            {
                return this.GetTable<MIS_ASESSMENTTYPE>();
            }
        }

        public System.Data.Linq.Table<MIS_BIOPSYRESULT> MIS_BIOPSYRESULTs
        {
            get
            {
                return this.GetTable<MIS_BIOPSYRESULT>();
            }
        }

        public System.Data.Linq.Table<MIS_LESIONTYPE> MIS_LESIONTYPEs
        {
            get
            {
                return this.GetTable<MIS_LESIONTYPE>();
            }
        }

        public System.Data.Linq.Table<MIS_TECHNIQUETYPE> MIS_TECHNIQUETYPEs
        {
            get
            {
                return this.GetTable<MIS_TECHNIQUETYPE>();
            }
        }

        public System.Data.Linq.Table<RIS_ACR> RIS_ACRs
        {
            get
            {
                return this.GetTable<RIS_ACR>();
            }
        }

        public System.Data.Linq.Table<RIS_ASSESSMENT> RIS_ASSESSMENTs
        {
            get
            {
                return this.GetTable<RIS_ASSESSMENT>();
            }
        }

        public System.Data.Linq.Table<RIS_AUTHLEVEL> RIS_AUTHLEVELs
        {
            get
            {
                return this.GetTable<RIS_AUTHLEVEL>();
            }
        }

        public System.Data.Linq.Table<RIS_AUTOMERGECONFIG> RIS_AUTOMERGECONFIGs
        {
            get
            {
                return this.GetTable<RIS_AUTOMERGECONFIG>();
            }
        }

        public System.Data.Linq.Table<RIS_BILL> RIS_BILLs
        {
            get
            {
                return this.GetTable<RIS_BILL>();
            }
        }

        public System.Data.Linq.Table<RIS_BODYPART> RIS_BODYPARTs
        {
            get
            {
                return this.GetTable<RIS_BODYPART>();
            }
        }

        public System.Data.Linq.Table<RIS_BPVIEW> RIS_BPVIEWs
        {
            get
            {
                return this.GetTable<RIS_BPVIEW>();
            }
        }

        public System.Data.Linq.Table<RIS_CLINICSESSION> RIS_CLINICSESSIONs
        {
            get
            {
                return this.GetTable<RIS_CLINICSESSION>();
            }
        }

        public System.Data.Linq.Table<RIS_CLINICTYPE> RIS_CLINICTYPEs
        {
            get
            {
                return this.GetTable<RIS_CLINICTYPE>();
            }
        }

        public System.Data.Linq.Table<RIS_CONFLICTEXAMDTL> RIS_CONFLICTEXAMDTLs
        {
            get
            {
                return this.GetTable<RIS_CONFLICTEXAMDTL>();
            }
        }

        public System.Data.Linq.Table<RIS_CONFLICTEXAMGROUP> RIS_CONFLICTEXAMGROUPs
        {
            get
            {
                return this.GetTable<RIS_CONFLICTEXAMGROUP>();
            }
        }

        public System.Data.Linq.Table<RIS_CONSUMABLETYPE> RIS_CONSUMABLETYPEs
        {
            get
            {
                return this.GetTable<RIS_CONSUMABLETYPE>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAM> RIS_EXAMs
        {
            get
            {
                return this.GetTable<RIS_EXAM>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMINSTRUCTION> RIS_EXAMINSTRUCTIONs
        {
            get
            {
                return this.GetTable<RIS_EXAMINSTRUCTION>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMLOG> RIS_EXAMLOGs
        {
            get
            {
                return this.GetTable<RIS_EXAMLOG>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMLOGCAPTURE> RIS_EXAMLOGCAPTUREs
        {
            get
            {
                return this.GetTable<RIS_EXAMLOGCAPTURE>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULT> RIS_EXAMRESULTs
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULT>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTACCESS> RIS_EXAMRESULTACCESSes
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTACCESS>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTLEGACY> RIS_EXAMRESULTLEGACies
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTLEGACY>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTLOCK> RIS_EXAMRESULTLOCKs
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTLOCK>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTLOG> RIS_EXAMRESULTLOGs
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTLOG>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTLOGCAPTURE> RIS_EXAMRESULTLOGCAPTUREs
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTLOGCAPTURE>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTNOTE> RIS_EXAMRESULTNOTEs
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTNOTE>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTSEVERITY> RIS_EXAMRESULTSEVERITies
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTSEVERITY>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTTEMPLATE> RIS_EXAMRESULTTEMPLATEs
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTTEMPLATE>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTTEMPLATELOG> RIS_EXAMRESULTTEMPLATELOGs
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTTEMPLATELOG>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMRESULTTEMPLATELOGCAPTURE> RIS_EXAMRESULTTEMPLATELOGCAPTUREs
        {
            get
            {
                return this.GetTable<RIS_EXAMRESULTTEMPLATELOGCAPTURE>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMTEMPLATESHARE> RIS_EXAMTEMPLATESHAREs
        {
            get
            {
                return this.GetTable<RIS_EXAMTEMPLATESHARE>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMTRANSFERLOG> RIS_EXAMTRANSFERLOGs
        {
            get
            {
                return this.GetTable<RIS_EXAMTRANSFERLOG>();
            }
        }

        public System.Data.Linq.Table<RIS_EXAMTYPE> RIS_EXAMTYPEs
        {
            get
            {
                return this.GetTable<RIS_EXAMTYPE>();
            }
        }

        public System.Data.Linq.Table<RIS_HOSPITAL_MAP_DOCTOR> RIS_HOSPITAL_MAP_DOCTORs
        {
            get
            {
                return this.GetTable<RIS_HOSPITAL_MAP_DOCTOR>();
            }
        }

        public System.Data.Linq.Table<RIS_INSURANCETYPE> RIS_INSURANCETYPEs
        {
            get
            {
                return this.GetTable<RIS_INSURANCETYPE>();
            }
        }

        public System.Data.Linq.Table<RIS_LOADMEDIA> RIS_LOADMEDIAs
        {
            get
            {
                return this.GetTable<RIS_LOADMEDIA>();
            }
        }

        public System.Data.Linq.Table<RIS_LOADMEDIADTL> RIS_LOADMEDIADTLs
        {
            get
            {
                return this.GetTable<RIS_LOADMEDIADTL>();
            }
        }

        public System.Data.Linq.Table<RIS_MODALITY> RIS_MODALITies
        {
            get
            {
                return this.GetTable<RIS_MODALITY>();
            }
        }

        public System.Data.Linq.Table<RIS_MODALITYCLINICTYPE> RIS_MODALITYCLINICTYPEs
        {
            get
            {
                return this.GetTable<RIS_MODALITYCLINICTYPE>();
            }
        }

        public System.Data.Linq.Table<RIS_MODALITYEXAM> RIS_MODALITYEXAMs
        {
            get
            {
                return this.GetTable<RIS_MODALITYEXAM>();
            }
        }

        public System.Data.Linq.Table<RIS_MODALITYTYPE> RIS_MODALITYTYPEs
        {
            get
            {
                return this.GetTable<RIS_MODALITYTYPE>();
            }
        }

        public System.Data.Linq.Table<RIS_NURSESDATA> RIS_NURSESDATAs
        {
            get
            {
                return this.GetTable<RIS_NURSESDATA>();
            }
        }

        public System.Data.Linq.Table<RIS_NURSESDATADTL> RIS_NURSESDATADTLs
        {
            get
            {
                return this.GetTable<RIS_NURSESDATADTL>();
            }
        }

        public System.Data.Linq.Table<RIS_OPNOTEITEM> RIS_OPNOTEITEMs
        {
            get
            {
                return this.GetTable<RIS_OPNOTEITEM>();
            }
        }

        public System.Data.Linq.Table<RIS_OPNOTEITEMTEMPLATE> RIS_OPNOTEITEMTEMPLATEs
        {
            get
            {
                return this.GetTable<RIS_OPNOTEITEMTEMPLATE>();
            }
        }

        public System.Data.Linq.Table<RIS_ORDER> RIS_ORDERs
        {
            get
            {
                return this.GetTable<RIS_ORDER>();
            }
        }

        public System.Data.Linq.Table<RIS_ORDERDTL> RIS_ORDERDTLs
        {
            get
            {
                return this.GetTable<RIS_ORDERDTL>();
            }
        }

        public System.Data.Linq.Table<RIS_ORDERIMAGE> RIS_ORDERIMAGEs
        {
            get
            {
                return this.GetTable<RIS_ORDERIMAGE>();
            }
        }

        public System.Data.Linq.Table<RIS_PATICD> RIS_PATICDs
        {
            get
            {
                return this.GetTable<RIS_PATICD>();
            }
        }

        public System.Data.Linq.Table<RIS_PATIENTPREPARATION> RIS_PATIENTPREPARATIONs
        {
            get
            {
                return this.GetTable<RIS_PATIENTPREPARATION>();
            }
        }

        public System.Data.Linq.Table<RIS_PATSTATUS> RIS_PATSTATUS
        {
            get
            {
                return this.GetTable<RIS_PATSTATUS>();
            }
        }

        public System.Data.Linq.Table<RIS_QAREASON> RIS_QAREASONs
        {
            get
            {
                return this.GetTable<RIS_QAREASON>();
            }
        }

        public System.Data.Linq.Table<RIS_QAWORK> RIS_QAWORKs
        {
            get
            {
                return this.GetTable<RIS_QAWORK>();
            }
        }

        public System.Data.Linq.Table<RIS_QUESTION> RIS_QUESTIONs
        {
            get
            {
                return this.GetTable<RIS_QUESTION>();
            }
        }

        public System.Data.Linq.Table<RIS_RADSTUDYGROUP> RIS_RADSTUDYGROUPs
        {
            get
            {
                return this.GetTable<RIS_RADSTUDYGROUP>();
            }
        }

        public System.Data.Linq.Table<RIS_RELEASEMEDIA> RIS_RELEASEMEDIAs
        {
            get
            {
                return this.GetTable<RIS_RELEASEMEDIA>();
            }
        }

        public System.Data.Linq.Table<RIS_RESULTSTATUSCHANGELOG> RIS_RESULTSTATUSCHANGELOGs
        {
            get
            {
                return this.GetTable<RIS_RESULTSTATUSCHANGELOG>();
            }
        }

        public System.Data.Linq.Table<RIS_SCHEDULE> RIS_SCHEDULEs
        {
            get
            {
                return this.GetTable<RIS_SCHEDULE>();
            }
        }

        public System.Data.Linq.Table<RIS_SCHEDULE_LOG> RIS_SCHEDULE_LOGs
        {
            get
            {
                return this.GetTable<RIS_SCHEDULE_LOG>();
            }
        }

        public System.Data.Linq.Table<RIS_SCHEDULEDTL> RIS_SCHEDULEDTLs
        {
            get
            {
                return this.GetTable<RIS_SCHEDULEDTL>();
            }
        }

        public System.Data.Linq.Table<RIS_SCHEDULELOG> RIS_SCHEDULELOGs
        {
            get
            {
                return this.GetTable<RIS_SCHEDULELOG>();
            }
        }

        public System.Data.Linq.Table<RIS_SCHEDULELOGCAPTURE> RIS_SCHEDULELOGCAPTUREs
        {
            get
            {
                return this.GetTable<RIS_SCHEDULELOGCAPTURE>();
            }
        }

        public System.Data.Linq.Table<RIS_SEARCH> RIS_SEARCHes
        {
            get
            {
                return this.GetTable<RIS_SEARCH>();
            }
        }

        public System.Data.Linq.Table<RIS_SEARCH_AUDIT> RIS_SEARCH_AUDITs
        {
            get
            {
                return this.GetTable<RIS_SEARCH_AUDIT>();
            }
        }

        public System.Data.Linq.Table<RIS_SEARCH_DTL> RIS_SEARCH_DTLs
        {
            get
            {
                return this.GetTable<RIS_SEARCH_DTL>();
            }
        }

        public System.Data.Linq.Table<RIS_SERVICETYPE> RIS_SERVICETYPEs
        {
            get
            {
                return this.GetTable<RIS_SERVICETYPE>();
            }
        }

        public System.Data.Linq.Table<RIS_SESSIONMAXAPP> RIS_SESSIONMAXAPPs
        {
            get
            {
                return this.GetTable<RIS_SESSIONMAXAPP>();
            }
        }

        public System.Data.Linq.Table<RIS_TECHCONSUMPTION> RIS_TECHCONSUMPTIONs
        {
            get
            {
                return this.GetTable<RIS_TECHCONSUMPTION>();
            }
        }

        public System.Data.Linq.Table<RIS_TECHWORK> RIS_TECHWORKs
        {
            get
            {
                return this.GetTable<RIS_TECHWORK>();
            }
        }

        public System.Data.Linq.Table<RIS_TIME> RIS_TIMEs
        {
            get
            {
                return this.GetTable<RIS_TIME>();
            }
        }

        public System.Data.Linq.Table<RIS_TIMELEVEL> RIS_TIMELEVELs
        {
            get
            {
                return this.GetTable<RIS_TIMELEVEL>();
            }
        }

        public System.Data.Linq.Table<RIS_USERORGMAP> RIS_USERORGMAPs
        {
            get
            {
                return this.GetTable<RIS_USERORGMAP>();
            }
        }

        public System.Data.Linq.Table<TR_EMP_MAPPING> TR_EMP_MAPPINGs
        {
            get
            {
                return this.GetTable<TR_EMP_MAPPING>();
            }
        }

        public System.Data.Linq.Table<GBLV_EXAMINSTRUCTION> GBLV_EXAMINSTRUCTIONs
        {
            get
            {
                return this.GetTable<GBLV_EXAMINSTRUCTION>();
            }
        }

        public System.Data.Linq.Table<View_Performance> View_Performances
        {
            get
            {
                return this.GetTable<View_Performance>();
            }
        }

        public System.Data.Linq.Table<GBLV_FormLanguage> GBLV_FormLanguages
        {
            get
            {
                return this.GetTable<GBLV_FormLanguage>();
            }
        }

        public System.Data.Linq.Table<GBLV_GRANTOBJECT> GBLV_GRANTOBJECTs
        {
            get
            {
                return this.GetTable<GBLV_GRANTOBJECT>();
            }
        }

        public System.Data.Linq.Table<GBLV_GRANTROLE_EMP> GBLV_GRANTROLE_EMPs
        {
            get
            {
                return this.GetTable<GBLV_GRANTROLE_EMP>();
            }
        }

        public System.Data.Linq.Table<GBLV_GRANTROLE_ROLE> GBLV_GRANTROLE_ROLEs
        {
            get
            {
                return this.GetTable<GBLV_GRANTROLE_ROLE>();
            }
        }

        public System.Data.Linq.Table<GBLV_HISTORY> GBLV_HISTORies
        {
            get
            {
                return this.GetTable<GBLV_HISTORY>();
            }
        }

        public System.Data.Linq.Table<GBLV_HL7MONITORING> GBLV_HL7MONITORINGs
        {
            get
            {
                return this.GetTable<GBLV_HL7MONITORING>();
            }
        }

        public System.Data.Linq.Table<GBLV_ORDERINGDEPARTMENT> GBLV_ORDERINGDEPARTMENTs
        {
            get
            {
                return this.GetTable<GBLV_ORDERINGDEPARTMENT>();
            }
        }

        public System.Data.Linq.Table<GBLV_PATIENTPOSITION> GBLV_PATIENTPOSITIONs
        {
            get
            {
                return this.GetTable<GBLV_PATIENTPOSITION>();
            }
        }

        public System.Data.Linq.Table<GBLV_RESULTREPRINT> GBLV_RESULTREPRINTs
        {
            get
            {
                return this.GetTable<GBLV_RESULTREPRINT>();
            }
        }

        public System.Data.Linq.Table<GBLV_SETALERT> GBLV_SETALERTs
        {
            get
            {
                return this.GetTable<GBLV_SETALERT>();
            }
        }

        public System.Data.Linq.Table<GBLV_SETMENU> GBLV_SETMENUs
        {
            get
            {
                return this.GetTable<GBLV_SETMENU>();
            }
        }

        public System.Data.Linq.Table<GBLV_SETMODALITYROOM> GBLV_SETMODALITYROOMs
        {
            get
            {
                return this.GetTable<GBLV_SETMODALITYROOM>();
            }
        }

        public System.Data.Linq.Table<GBLV_SETROLE> GBLV_SETROLEs
        {
            get
            {
                return this.GetTable<GBLV_SETROLE>();
            }
        }

        public System.Data.Linq.Table<GBLV_SETSUBMENU> GBLV_SETSUBMENUs
        {
            get
            {
                return this.GetTable<GBLV_SETSUBMENU>();
            }
        }

        public System.Data.Linq.Table<GBLV_SETSUBMENUOBJECTLABEL> GBLV_SETSUBMENUOBJECTLABELs
        {
            get
            {
                return this.GetTable<GBLV_SETSUBMENUOBJECTLABEL>();
            }
        }

        public System.Data.Linq.Table<GBLV_SETSUBMENUOBJECT> GBLV_SETSUBMENUOBJECTs
        {
            get
            {
                return this.GetTable<GBLV_SETSUBMENUOBJECT>();
            }
        }

        public System.Data.Linq.Table<GBLV_WORKLIST> GBLV_WORKLISTs
        {
            get
            {
                return this.GetTable<GBLV_WORKLIST>();
            }
        }

        public System.Data.Linq.Table<RISV_CLINIC> RISV_CLINICs
        {
            get
            {
                return this.GetTable<RISV_CLINIC>();
            }
        }

        public System.Data.Linq.Table<RISV_CLINICIAN> RISV_CLINICIANs
        {
            get
            {
                return this.GetTable<RISV_CLINICIAN>();
            }
        }

        public System.Data.Linq.Table<RISV_DOCTOR> RISV_DOCTORs
        {
            get
            {
                return this.GetTable<RISV_DOCTOR>();
            }
        }

        public System.Data.Linq.Table<RISV_EXAMRESULTLEGACY> RISV_EXAMRESULTLEGACies
        {
            get
            {
                return this.GetTable<RISV_EXAMRESULTLEGACY>();
            }
        }

        public System.Data.Linq.Table<RISV_FINALIZED> RISV_FINALIZEDs
        {
            get
            {
                return this.GetTable<RISV_FINALIZED>();
            }
        }

        public System.Data.Linq.Table<RISV_MODALITY> RISV_MODALITies
        {
            get
            {
                return this.GetTable<RISV_MODALITY>();
            }
        }

        public System.Data.Linq.Table<RISV_ORDERREPORTALL> RISV_ORDERREPORTALLs
        {
            get
            {
                return this.GetTable<RISV_ORDERREPORTALL>();
            }
        }

        public System.Data.Linq.Table<RISV_PATIENTFLOWDATA> RISV_PATIENTFLOWDATAs
        {
            get
            {
                return this.GetTable<RISV_PATIENTFLOWDATA>();
            }
        }

        public System.Data.Linq.Table<RISV_RADIOLOGIST> RISV_RADIOLOGISTs
        {
            get
            {
                return this.GetTable<RISV_RADIOLOGIST>();
            }
        }

        public System.Data.Linq.Table<RISV_RESULTENTRYREPORT> RISV_RESULTENTRYREPORTs
        {
            get
            {
                return this.GetTable<RISV_RESULTENTRYREPORT>();
            }
        }

        public System.Data.Linq.Table<RISV_SCHEDULEREPORT> RISV_SCHEDULEREPORTs
        {
            get
            {
                return this.GetTable<RISV_SCHEDULEREPORT>();
            }
        }

        public System.Data.Linq.Table<RISV_STUDY> RISV_STUDies
        {
            get
            {
                return this.GetTable<RISV_STUDY>();
            }
        }

        public System.Data.Linq.Table<View_ExamLV> View_ExamLVs
        {
            get
            {
                return this.GetTable<View_ExamLV>();
            }
        }

        public System.Data.Linq.Table<View_Exec> View_Execs
        {
            get
            {
                return this.GetTable<View_Exec>();
            }
        }
    }
}
