using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace Envision.Common
{
    [Table(Name = "dbo.GBL_ENV")]
    public partial class GBL_ENV : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ORG_ID;

        private string _ORG_UID;

        private string _ORG_NAME;

        private string _ORG_ALIAS;

        private string _ORG_SLOGAN1;

        private string _ORG_SLOGAN2;

        private string _ORG_ADDR1;

        private string _ORG_ADDR2;

        private string _ORG_ADDR3;

        private string _ORG_ADDR4;

        private string _ORG_TEL1;

        private string _ORG_TEL2;

        private string _ORG_TEL3;

        private string _ORG_FAX;

        private string _ORG_EMAIL1;

        private string _ORG_EMAIL2;

        private string _ORG_EMAIL3;

        private string _ORG_WEBSITE;

        private System.Data.Linq.Binary _ORG_IMG;

        private string _WELCOME_DIALOG1;

        private string _WELCOME_DIALOG2;

        private string _DEFAULT_FONT_FACE;

        private System.Nullable<byte> _DEFAULT_FONT_SIZE;

        private string _REP_SERVER;

        private string _REP_FORMAT;

        private string _REP_FOOTER1;

        private string _REP_FOOTER2;

        private string _EMP_IMG_TYPE;

        private string _EMP_IMG_MAX_SIZE;

        private System.Nullable<int> _OTHER_MAX_FILE_SIZE;

        private string _DT_FMT;

        private string _TIME_FMT;

        private string _LOCAL_CURRENCY_NAME;

        private string _LOCAL_CURRENCY_SYMBOL;

        private string _CURRENCY_FMT;

        private string _RESOURCE_IMAGE_PATH;

        private string _SCANNED_IMAGE_PATH;

        private string _DOCUMENT_PATH;

        private string _BACKUP_PATH;

        private string _OTHER_FILE_PATH;

        private string _EMP_IMG_PATH;

        private string _LAB_DATA_PATH;

        private string _USER_DISPLAY_FMT;

        private string _VENDOR_H1;

        private string _VENDOR_H2;

        private string _VENDOR_LOGO_PATH;

        private string _PARTNER1_H1;

        private string _PARTNER1_H2;

        private string _PARTNER1_LOGO_PATH;

        private string _PARTNER2_H1;

        private string _PARTNER2_H2;

        private string _PARTNER2_LOGO_PATH;

        private string _RIS_IP;

        private string _RIS_PORT;

        private string _RIS_USER;

        private string _RIS_PASS;

        private string _RIS_URL;

        private string _PACS_IP;

        private string _PACS_PORT;

        private string _PACS_URL1;

        private string _PACS_URL2;

        private string _PACS_URL3;

        private string _PACS_DOMAIN;

        private string _HIS_IP;

        private string _HIS_PORT;

        private string _HIS_DB_NAME;

        private string _HIS_USER_NAME;

        private string _HIS_USER_PASS;

        private string _HIS_FIN_FLAG;

        private string _WS_IP;

        private string _WS_IP_PICTURE;

        private string _WS_VERSION;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<FIN_INVOICE> _FIN_INVOICEs;

        private EntitySet<FIN_INVOICEDTL> _FIN_INVOICEDTLs;

        private EntitySet<FIN_PAYMENT> _FIN_PAYMENTs;

        private EntitySet<FIN_PAYMENTDTL> _FIN_PAYMENTDTLs;

        private EntitySet<GBL_ALERT> _GBL_ALERTs;

        private EntitySet<GBL_ALERTDTL> _GBL_ALERTDTLs;

        //private EntitySet<GBL_EMPSCHEDULE> _GBL_EMPSCHEDULEs;

        private EntitySet<GBL_EMPSCHEDULECATEGORY> _GBL_EMPSCHEDULECATEGORies;

        private EntitySet<GBL_EXCEPTIONLOG> _GBL_EXCEPTIONLOGs;

        private EntitySet<GBL_GENERAL> _GBL_GENERALs;

        private EntitySet<GBL_GENERALDTL> _GBL_GENERALDTLs;

        private EntitySet<GBL_GRANTOBJECT> _GBL_GRANTOBJECTs;

        private EntitySet<GBL_GRANTROLE> _GBL_GRANTROLEs;

        private EntitySet<GBL_GROUP> _GBL_GROUPs;

        private EntitySet<GBL_GROUPDTL> _GBL_GROUPDTLs;

        private EntitySet<GBL_HOSPITAL> _GBL_HOSPITALs;

        private EntitySet<GBL_LANGUAGE> _GBL_LANGUAGEs;

        private EntitySet<GBL_MENU> _GBL_MENUs;

        private EntitySet<GBL_MYMENU> _GBL_MYMENUs;

        private EntitySet<GBL_MYMENU> _GBL_MYMENUs1;

        private EntitySet<GBL_MYMENU> _GBL_MYMENUs2;

        private EntitySet<GBL_PRODUCT> _GBL_PRODUCTs;

        private EntitySet<GBL_ROLE> _GBL_ROLEs;

        private EntitySet<GBL_ROLEDTL> _GBL_ROLEDTLs;

        private EntitySet<GBL_SEQUENCE> _GBL_SEQUENCEs;

        private EntitySet<GBL_SESSION> _GBL_SESSIONs;

        private EntitySet<GBL_SESSIONLOG> _GBL_SESSIONLOGs;

        private EntitySet<GBL_SUBMENU> _GBL_SUBMENUs;

        private EntitySet<GBL_SUBMENUOBJECTLABEL> _GBL_SUBMENUOBJECTLABELs;

        private EntitySet<GBL_SUBMENUOBJECT> _GBL_SUBMENUOBJECTs;

        private EntitySet<GBL_USERGROUP> _GBL_USERGROUPs;

        private EntitySet<GBL_USERGROUPDTL> _GBL_USERGROUPDTLs;

        private EntitySet<HR_EMP> _HR_EMPs;

        private EntitySet<HR_ROOM> _HR_ROOMs;

        private EntitySet<HR_UNIT> _HR_UNITs;

        private EntitySet<INV_AUTHORISER> _INV_AUTHORISERs;

        private EntitySet<INV_AUTHORIZATION> _INV_AUTHORIZATIONs;

        private EntitySet<INV_CATEGORY> _INV_CATEGORies;

        private EntitySet<INV_ITEM> _INV_ITEMs;

        private EntitySet<INV_ITEMSTATUS> _INV_ITEMSTATUS;

        private EntitySet<INV_ITEMTYPE> _INV_ITEMTYPEs;

        private EntitySet<INV_PO> _INV_POs;

        private EntitySet<INV_PODTL> _INV_PODTLs;

        private EntitySet<INV_PR> _INV_PRs;

        private EntitySet<INV_REQUISITION> _INV_REQUISITIONs;

        private EntitySet<INV_REQUISITIONDTL> _INV_REQUISITIONDTLs;

        private EntitySet<INV_ROOMSTOCKREDUCE> _INV_ROOMSTOCKREDUCEs;

        private EntitySet<INV_SETTING> _INV_SETTINGs;

        private EntitySet<INV_TXNUNIT> _INV_TXNUNITs;

        private EntitySet<INV_UNIT> _INV_UNITs;

        private EntitySet<INV_UNITREORDERLEVEL> _INV_UNITREORDERLEVELs;

        private EntitySet<INV_VENDOR> _INV_VENDORs;

        private EntitySet<MIS_ASESSMENTTYPE> _MIS_ASESSMENTTYPEs;

        private EntitySet<MIS_BIOPSYRESULT> _MIS_BIOPSYRESULTs;

        private EntitySet<MIS_LESIONTYPE> _MIS_LESIONTYPEs;

        private EntitySet<MIS_TECHNIQUETYPE> _MIS_TECHNIQUETYPEs;

        private EntitySet<RIS_ACR> _RIS_ACRs;

        private EntitySet<RIS_ASSESSMENT> _RIS_ASSESSMENTs;

        private EntitySet<RIS_BILL> _RIS_BILLs;

        private EntitySet<RIS_BODYPART> _RIS_BODYPARTs;

        private EntitySet<RIS_BPVIEW> _RIS_BPVIEWs;

        private EntitySet<RIS_CLINICSESSION> _RIS_CLINICSESSIONs;

        private EntitySet<RIS_CLINICTYPE> _RIS_CLINICTYPEs;

        private EntitySet<RIS_CONFLICTEXAMDTL> _RIS_CONFLICTEXAMDTLs;

        private EntitySet<RIS_CONFLICTEXAMGROUP> _RIS_CONFLICTEXAMGROUPs;

        private EntitySet<RIS_CONSUMABLETYPE> _RIS_CONSUMABLETYPEs;

        private EntitySet<RIS_EXAMINSTRUCTION> _RIS_EXAMINSTRUCTIONs;

        private EntitySet<RIS_EXAMRESULT> _RIS_EXAMRESULTs;

        private EntitySet<RIS_EXAMRESULTACCESS> _RIS_EXAMRESULTACCESSes;

        private EntitySet<RIS_EXAMRESULTNOTE> _RIS_EXAMRESULTNOTEs;

        private EntitySet<RIS_EXAMRESULTSEVERITY> _RIS_EXAMRESULTSEVERITies;

        private EntitySet<RIS_EXAMRESULTTEMPLATE> _RIS_EXAMRESULTTEMPLATEs;

        private EntitySet<RIS_EXAMTEMPLATESHARE> _RIS_EXAMTEMPLATESHAREs;

        private EntitySet<RIS_EXAMTYPE> _RIS_EXAMTYPEs;

        private EntitySet<RIS_HOSPITAL_MAP_DOCTOR> _RIS_HOSPITAL_MAP_DOCTORs;

        private EntitySet<RIS_MODALITY> _RIS_MODALITies;

        private EntitySet<RIS_MODALITYEXAM> _RIS_MODALITYEXAMs;

        private EntitySet<RIS_MODALITYTYPE> _RIS_MODALITYTYPEs;

        private EntitySet<RIS_ORDER> _RIS_ORDERs;

        private EntitySet<RIS_ORDERDTL> _RIS_ORDERDTLs;

        private EntitySet<RIS_ORDERIMAGE> _RIS_ORDERIMAGEs;

        private EntitySet<RIS_PATICD> _RIS_PATICDs;

        private EntitySet<RIS_PATSTATUS> _RIS_PATSTATUS;

        private EntitySet<RIS_PATSTATUS> _RIS_PATSTATUS1;

        private EntitySet<RIS_QAWORK> _RIS_QAWORKs;

        private EntitySet<RIS_QUESTION> _RIS_QUESTIONs;

        private EntitySet<RIS_RADSTUDYGROUP> _RIS_RADSTUDYGROUPs;

        private EntitySet<RIS_RESULTSTATUSCHANGELOG> _RIS_RESULTSTATUSCHANGELOGs;

        private EntitySet<RIS_SCHEDULE> _RIS_SCHEDULEs;

        private EntitySet<RIS_SERVICETYPE> _RIS_SERVICETYPEs;

        private EntitySet<RIS_SESSIONMAXAPP> _RIS_SESSIONMAXAPPs;

        private EntitySet<RIS_TECHCONSUMPTION> _RIS_TECHCONSUMPTIONs;

        private EntitySet<RIS_TECHWORK> _RIS_TECHWORKs;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnORG_IDChanging(int value);
        partial void OnORG_IDChanged();
        partial void OnORG_UIDChanging(string value);
        partial void OnORG_UIDChanged();
        partial void OnORG_NAMEChanging(string value);
        partial void OnORG_NAMEChanged();
        partial void OnORG_ALIASChanging(string value);
        partial void OnORG_ALIASChanged();
        partial void OnORG_SLOGAN1Changing(string value);
        partial void OnORG_SLOGAN1Changed();
        partial void OnORG_SLOGAN2Changing(string value);
        partial void OnORG_SLOGAN2Changed();
        partial void OnORG_ADDR1Changing(string value);
        partial void OnORG_ADDR1Changed();
        partial void OnORG_ADDR2Changing(string value);
        partial void OnORG_ADDR2Changed();
        partial void OnORG_ADDR3Changing(string value);
        partial void OnORG_ADDR3Changed();
        partial void OnORG_ADDR4Changing(string value);
        partial void OnORG_ADDR4Changed();
        partial void OnORG_TEL1Changing(string value);
        partial void OnORG_TEL1Changed();
        partial void OnORG_TEL2Changing(string value);
        partial void OnORG_TEL2Changed();
        partial void OnORG_TEL3Changing(string value);
        partial void OnORG_TEL3Changed();
        partial void OnORG_FAXChanging(string value);
        partial void OnORG_FAXChanged();
        partial void OnORG_EMAIL1Changing(string value);
        partial void OnORG_EMAIL1Changed();
        partial void OnORG_EMAIL2Changing(string value);
        partial void OnORG_EMAIL2Changed();
        partial void OnORG_EMAIL3Changing(string value);
        partial void OnORG_EMAIL3Changed();
        partial void OnORG_WEBSITEChanging(string value);
        partial void OnORG_WEBSITEChanged();
        partial void OnORG_IMGChanging(System.Data.Linq.Binary value);
        partial void OnORG_IMGChanged();
        partial void OnWELCOME_DIALOG1Changing(string value);
        partial void OnWELCOME_DIALOG1Changed();
        partial void OnWELCOME_DIALOG2Changing(string value);
        partial void OnWELCOME_DIALOG2Changed();
        partial void OnDEFAULT_FONT_FACEChanging(string value);
        partial void OnDEFAULT_FONT_FACEChanged();
        partial void OnDEFAULT_FONT_SIZEChanging(System.Nullable<byte> value);
        partial void OnDEFAULT_FONT_SIZEChanged();
        partial void OnREP_SERVERChanging(string value);
        partial void OnREP_SERVERChanged();
        partial void OnREP_FORMATChanging(string value);
        partial void OnREP_FORMATChanged();
        partial void OnREP_FOOTER1Changing(string value);
        partial void OnREP_FOOTER1Changed();
        partial void OnREP_FOOTER2Changing(string value);
        partial void OnREP_FOOTER2Changed();
        partial void OnEMP_IMG_TYPEChanging(string value);
        partial void OnEMP_IMG_TYPEChanged();
        partial void OnEMP_IMG_MAX_SIZEChanging(string value);
        partial void OnEMP_IMG_MAX_SIZEChanged();
        partial void OnOTHER_MAX_FILE_SIZEChanging(System.Nullable<int> value);
        partial void OnOTHER_MAX_FILE_SIZEChanged();
        partial void OnDT_FMTChanging(string value);
        partial void OnDT_FMTChanged();
        partial void OnTIME_FMTChanging(string value);
        partial void OnTIME_FMTChanged();
        partial void OnLOCAL_CURRENCY_NAMEChanging(string value);
        partial void OnLOCAL_CURRENCY_NAMEChanged();
        partial void OnLOCAL_CURRENCY_SYMBOLChanging(string value);
        partial void OnLOCAL_CURRENCY_SYMBOLChanged();
        partial void OnCURRENCY_FMTChanging(string value);
        partial void OnCURRENCY_FMTChanged();
        partial void OnRESOURCE_IMAGE_PATHChanging(string value);
        partial void OnRESOURCE_IMAGE_PATHChanged();
        partial void OnSCANNED_IMAGE_PATHChanging(string value);
        partial void OnSCANNED_IMAGE_PATHChanged();
        partial void OnDOCUMENT_PATHChanging(string value);
        partial void OnDOCUMENT_PATHChanged();
        partial void OnBACKUP_PATHChanging(string value);
        partial void OnBACKUP_PATHChanged();
        partial void OnOTHER_FILE_PATHChanging(string value);
        partial void OnOTHER_FILE_PATHChanged();
        partial void OnEMP_IMG_PATHChanging(string value);
        partial void OnEMP_IMG_PATHChanged();
        partial void OnLAB_DATA_PATHChanging(string value);
        partial void OnLAB_DATA_PATHChanged();
        partial void OnUSER_DISPLAY_FMTChanging(string value);
        partial void OnUSER_DISPLAY_FMTChanged();
        partial void OnVENDOR_H1Changing(string value);
        partial void OnVENDOR_H1Changed();
        partial void OnVENDOR_H2Changing(string value);
        partial void OnVENDOR_H2Changed();
        partial void OnVENDOR_LOGO_PATHChanging(string value);
        partial void OnVENDOR_LOGO_PATHChanged();
        partial void OnPARTNER1_H1Changing(string value);
        partial void OnPARTNER1_H1Changed();
        partial void OnPARTNER1_H2Changing(string value);
        partial void OnPARTNER1_H2Changed();
        partial void OnPARTNER1_LOGO_PATHChanging(string value);
        partial void OnPARTNER1_LOGO_PATHChanged();
        partial void OnPARTNER2_H1Changing(string value);
        partial void OnPARTNER2_H1Changed();
        partial void OnPARTNER2_H2Changing(string value);
        partial void OnPARTNER2_H2Changed();
        partial void OnPARTNER2_LOGO_PATHChanging(string value);
        partial void OnPARTNER2_LOGO_PATHChanged();
        partial void OnRIS_IPChanging(string value);
        partial void OnRIS_IPChanged();
        partial void OnRIS_PORTChanging(string value);
        partial void OnRIS_PORTChanged();
        partial void OnRIS_USERChanging(string value);
        partial void OnRIS_USERChanged();
        partial void OnRIS_PASSChanging(string value);
        partial void OnRIS_PASSChanged();
        partial void OnRIS_URLChanging(string value);
        partial void OnRIS_URLChanged();
        partial void OnPACS_IPChanging(string value);
        partial void OnPACS_IPChanged();
        partial void OnPACS_PORTChanging(string value);
        partial void OnPACS_PORTChanged();
        partial void OnPACS_URL1Changing(string value);
        partial void OnPACS_URL1Changed();
        partial void OnPACS_URL2Changing(string value);
        partial void OnPACS_URL2Changed();
        partial void OnPACS_URL3Changing(string value);
        partial void OnPACS_URL3Changed();
        partial void OnPACS_DOMAINChanging(string value);
        partial void OnPACS_DOMAINChanged();
        partial void OnHIS_IPChanging(string value);
        partial void OnHIS_IPChanged();
        partial void OnHIS_PORTChanging(string value);
        partial void OnHIS_PORTChanged();
        partial void OnHIS_DB_NAMEChanging(string value);
        partial void OnHIS_DB_NAMEChanged();
        partial void OnHIS_USER_NAMEChanging(string value);
        partial void OnHIS_USER_NAMEChanged();
        partial void OnHIS_USER_PASSChanging(string value);
        partial void OnHIS_USER_PASSChanged();
        partial void OnHIS_FIN_FLAGChanging(string value);
        partial void OnHIS_FIN_FLAGChanged();
        partial void OnWS_IPChanging(string value);
        partial void OnWS_IPChanged();
        partial void OnWS_IP_PICTUREChanging(string value);
        partial void OnWS_IP_PICTUREChanged();
        partial void OnWS_VERSIONChanging(string value);
        partial void OnWS_VERSIONChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public GBL_ENV()
        {
            this._FIN_INVOICEs = new EntitySet<FIN_INVOICE>(new Action<FIN_INVOICE>(this.attach_FIN_INVOICEs), new Action<FIN_INVOICE>(this.detach_FIN_INVOICEs));
            this._FIN_INVOICEDTLs = new EntitySet<FIN_INVOICEDTL>(new Action<FIN_INVOICEDTL>(this.attach_FIN_INVOICEDTLs), new Action<FIN_INVOICEDTL>(this.detach_FIN_INVOICEDTLs));
            this._FIN_PAYMENTs = new EntitySet<FIN_PAYMENT>(new Action<FIN_PAYMENT>(this.attach_FIN_PAYMENTs), new Action<FIN_PAYMENT>(this.detach_FIN_PAYMENTs));
            this._FIN_PAYMENTDTLs = new EntitySet<FIN_PAYMENTDTL>(new Action<FIN_PAYMENTDTL>(this.attach_FIN_PAYMENTDTLs), new Action<FIN_PAYMENTDTL>(this.detach_FIN_PAYMENTDTLs));
            this._GBL_ALERTs = new EntitySet<GBL_ALERT>(new Action<GBL_ALERT>(this.attach_GBL_ALERTs), new Action<GBL_ALERT>(this.detach_GBL_ALERTs));
            this._GBL_ALERTDTLs = new EntitySet<GBL_ALERTDTL>(new Action<GBL_ALERTDTL>(this.attach_GBL_ALERTDTLs), new Action<GBL_ALERTDTL>(this.detach_GBL_ALERTDTLs));
            //this._GBL_EMPSCHEDULEs = new EntitySet<GBL_EMPSCHEDULE>(new Action<GBL_EMPSCHEDULE>(this.attach_GBL_EMPSCHEDULEs), new Action<GBL_EMPSCHEDULE>(this.detach_GBL_EMPSCHEDULEs));
            this._GBL_EMPSCHEDULECATEGORies = new EntitySet<GBL_EMPSCHEDULECATEGORY>(new Action<GBL_EMPSCHEDULECATEGORY>(this.attach_GBL_EMPSCHEDULECATEGORies), new Action<GBL_EMPSCHEDULECATEGORY>(this.detach_GBL_EMPSCHEDULECATEGORies));
            this._GBL_EXCEPTIONLOGs = new EntitySet<GBL_EXCEPTIONLOG>(new Action<GBL_EXCEPTIONLOG>(this.attach_GBL_EXCEPTIONLOGs), new Action<GBL_EXCEPTIONLOG>(this.detach_GBL_EXCEPTIONLOGs));
            this._GBL_GENERALs = new EntitySet<GBL_GENERAL>(new Action<GBL_GENERAL>(this.attach_GBL_GENERALs), new Action<GBL_GENERAL>(this.detach_GBL_GENERALs));
            this._GBL_GENERALDTLs = new EntitySet<GBL_GENERALDTL>(new Action<GBL_GENERALDTL>(this.attach_GBL_GENERALDTLs), new Action<GBL_GENERALDTL>(this.detach_GBL_GENERALDTLs));
            this._GBL_GRANTOBJECTs = new EntitySet<GBL_GRANTOBJECT>(new Action<GBL_GRANTOBJECT>(this.attach_GBL_GRANTOBJECTs), new Action<GBL_GRANTOBJECT>(this.detach_GBL_GRANTOBJECTs));
            this._GBL_GRANTROLEs = new EntitySet<GBL_GRANTROLE>(new Action<GBL_GRANTROLE>(this.attach_GBL_GRANTROLEs), new Action<GBL_GRANTROLE>(this.detach_GBL_GRANTROLEs));
            this._GBL_GROUPs = new EntitySet<GBL_GROUP>(new Action<GBL_GROUP>(this.attach_GBL_GROUPs), new Action<GBL_GROUP>(this.detach_GBL_GROUPs));
            this._GBL_GROUPDTLs = new EntitySet<GBL_GROUPDTL>(new Action<GBL_GROUPDTL>(this.attach_GBL_GROUPDTLs), new Action<GBL_GROUPDTL>(this.detach_GBL_GROUPDTLs));
            this._GBL_HOSPITALs = new EntitySet<GBL_HOSPITAL>(new Action<GBL_HOSPITAL>(this.attach_GBL_HOSPITALs), new Action<GBL_HOSPITAL>(this.detach_GBL_HOSPITALs));
            this._GBL_LANGUAGEs = new EntitySet<GBL_LANGUAGE>(new Action<GBL_LANGUAGE>(this.attach_GBL_LANGUAGEs), new Action<GBL_LANGUAGE>(this.detach_GBL_LANGUAGEs));
            this._GBL_MENUs = new EntitySet<GBL_MENU>(new Action<GBL_MENU>(this.attach_GBL_MENUs), new Action<GBL_MENU>(this.detach_GBL_MENUs));
            this._GBL_MYMENUs = new EntitySet<GBL_MYMENU>(new Action<GBL_MYMENU>(this.attach_GBL_MYMENUs), new Action<GBL_MYMENU>(this.detach_GBL_MYMENUs));
            this._GBL_MYMENUs1 = new EntitySet<GBL_MYMENU>(new Action<GBL_MYMENU>(this.attach_GBL_MYMENUs1), new Action<GBL_MYMENU>(this.detach_GBL_MYMENUs1));
            this._GBL_MYMENUs2 = new EntitySet<GBL_MYMENU>(new Action<GBL_MYMENU>(this.attach_GBL_MYMENUs2), new Action<GBL_MYMENU>(this.detach_GBL_MYMENUs2));
            this._GBL_PRODUCTs = new EntitySet<GBL_PRODUCT>(new Action<GBL_PRODUCT>(this.attach_GBL_PRODUCTs), new Action<GBL_PRODUCT>(this.detach_GBL_PRODUCTs));
            this._GBL_ROLEs = new EntitySet<GBL_ROLE>(new Action<GBL_ROLE>(this.attach_GBL_ROLEs), new Action<GBL_ROLE>(this.detach_GBL_ROLEs));
            this._GBL_ROLEDTLs = new EntitySet<GBL_ROLEDTL>(new Action<GBL_ROLEDTL>(this.attach_GBL_ROLEDTLs), new Action<GBL_ROLEDTL>(this.detach_GBL_ROLEDTLs));
            this._GBL_SEQUENCEs = new EntitySet<GBL_SEQUENCE>(new Action<GBL_SEQUENCE>(this.attach_GBL_SEQUENCEs), new Action<GBL_SEQUENCE>(this.detach_GBL_SEQUENCEs));
            this._GBL_SESSIONs = new EntitySet<GBL_SESSION>(new Action<GBL_SESSION>(this.attach_GBL_SESSIONs), new Action<GBL_SESSION>(this.detach_GBL_SESSIONs));
            this._GBL_SESSIONLOGs = new EntitySet<GBL_SESSIONLOG>(new Action<GBL_SESSIONLOG>(this.attach_GBL_SESSIONLOGs), new Action<GBL_SESSIONLOG>(this.detach_GBL_SESSIONLOGs));
            this._GBL_SUBMENUs = new EntitySet<GBL_SUBMENU>(new Action<GBL_SUBMENU>(this.attach_GBL_SUBMENUs), new Action<GBL_SUBMENU>(this.detach_GBL_SUBMENUs));
            this._GBL_SUBMENUOBJECTLABELs = new EntitySet<GBL_SUBMENUOBJECTLABEL>(new Action<GBL_SUBMENUOBJECTLABEL>(this.attach_GBL_SUBMENUOBJECTLABELs), new Action<GBL_SUBMENUOBJECTLABEL>(this.detach_GBL_SUBMENUOBJECTLABELs));
            this._GBL_SUBMENUOBJECTs = new EntitySet<GBL_SUBMENUOBJECT>(new Action<GBL_SUBMENUOBJECT>(this.attach_GBL_SUBMENUOBJECTs), new Action<GBL_SUBMENUOBJECT>(this.detach_GBL_SUBMENUOBJECTs));
            this._GBL_USERGROUPs = new EntitySet<GBL_USERGROUP>(new Action<GBL_USERGROUP>(this.attach_GBL_USERGROUPs), new Action<GBL_USERGROUP>(this.detach_GBL_USERGROUPs));
            this._GBL_USERGROUPDTLs = new EntitySet<GBL_USERGROUPDTL>(new Action<GBL_USERGROUPDTL>(this.attach_GBL_USERGROUPDTLs), new Action<GBL_USERGROUPDTL>(this.detach_GBL_USERGROUPDTLs));
            this._HR_EMPs = new EntitySet<HR_EMP>(new Action<HR_EMP>(this.attach_HR_EMPs), new Action<HR_EMP>(this.detach_HR_EMPs));
            this._HR_ROOMs = new EntitySet<HR_ROOM>(new Action<HR_ROOM>(this.attach_HR_ROOMs), new Action<HR_ROOM>(this.detach_HR_ROOMs));
            this._HR_UNITs = new EntitySet<HR_UNIT>(new Action<HR_UNIT>(this.attach_HR_UNITs), new Action<HR_UNIT>(this.detach_HR_UNITs));
            this._INV_AUTHORISERs = new EntitySet<INV_AUTHORISER>(new Action<INV_AUTHORISER>(this.attach_INV_AUTHORISERs), new Action<INV_AUTHORISER>(this.detach_INV_AUTHORISERs));
            this._INV_AUTHORIZATIONs = new EntitySet<INV_AUTHORIZATION>(new Action<INV_AUTHORIZATION>(this.attach_INV_AUTHORIZATIONs), new Action<INV_AUTHORIZATION>(this.detach_INV_AUTHORIZATIONs));
            this._INV_CATEGORies = new EntitySet<INV_CATEGORY>(new Action<INV_CATEGORY>(this.attach_INV_CATEGORies), new Action<INV_CATEGORY>(this.detach_INV_CATEGORies));
            this._INV_ITEMs = new EntitySet<INV_ITEM>(new Action<INV_ITEM>(this.attach_INV_ITEMs), new Action<INV_ITEM>(this.detach_INV_ITEMs));
            this._INV_ITEMSTATUS = new EntitySet<INV_ITEMSTATUS>(new Action<INV_ITEMSTATUS>(this.attach_INV_ITEMSTATUS), new Action<INV_ITEMSTATUS>(this.detach_INV_ITEMSTATUS));
            this._INV_ITEMTYPEs = new EntitySet<INV_ITEMTYPE>(new Action<INV_ITEMTYPE>(this.attach_INV_ITEMTYPEs), new Action<INV_ITEMTYPE>(this.detach_INV_ITEMTYPEs));
            this._INV_POs = new EntitySet<INV_PO>(new Action<INV_PO>(this.attach_INV_POs), new Action<INV_PO>(this.detach_INV_POs));
            this._INV_PODTLs = new EntitySet<INV_PODTL>(new Action<INV_PODTL>(this.attach_INV_PODTLs), new Action<INV_PODTL>(this.detach_INV_PODTLs));
            this._INV_PRs = new EntitySet<INV_PR>(new Action<INV_PR>(this.attach_INV_PRs), new Action<INV_PR>(this.detach_INV_PRs));
            this._INV_REQUISITIONs = new EntitySet<INV_REQUISITION>(new Action<INV_REQUISITION>(this.attach_INV_REQUISITIONs), new Action<INV_REQUISITION>(this.detach_INV_REQUISITIONs));
            this._INV_REQUISITIONDTLs = new EntitySet<INV_REQUISITIONDTL>(new Action<INV_REQUISITIONDTL>(this.attach_INV_REQUISITIONDTLs), new Action<INV_REQUISITIONDTL>(this.detach_INV_REQUISITIONDTLs));
            this._INV_ROOMSTOCKREDUCEs = new EntitySet<INV_ROOMSTOCKREDUCE>(new Action<INV_ROOMSTOCKREDUCE>(this.attach_INV_ROOMSTOCKREDUCEs), new Action<INV_ROOMSTOCKREDUCE>(this.detach_INV_ROOMSTOCKREDUCEs));
            this._INV_SETTINGs = new EntitySet<INV_SETTING>(new Action<INV_SETTING>(this.attach_INV_SETTINGs), new Action<INV_SETTING>(this.detach_INV_SETTINGs));
            this._INV_TXNUNITs = new EntitySet<INV_TXNUNIT>(new Action<INV_TXNUNIT>(this.attach_INV_TXNUNITs), new Action<INV_TXNUNIT>(this.detach_INV_TXNUNITs));
            this._INV_UNITs = new EntitySet<INV_UNIT>(new Action<INV_UNIT>(this.attach_INV_UNITs), new Action<INV_UNIT>(this.detach_INV_UNITs));
            this._INV_UNITREORDERLEVELs = new EntitySet<INV_UNITREORDERLEVEL>(new Action<INV_UNITREORDERLEVEL>(this.attach_INV_UNITREORDERLEVELs), new Action<INV_UNITREORDERLEVEL>(this.detach_INV_UNITREORDERLEVELs));
            this._INV_VENDORs = new EntitySet<INV_VENDOR>(new Action<INV_VENDOR>(this.attach_INV_VENDORs), new Action<INV_VENDOR>(this.detach_INV_VENDORs));
            this._MIS_ASESSMENTTYPEs = new EntitySet<MIS_ASESSMENTTYPE>(new Action<MIS_ASESSMENTTYPE>(this.attach_MIS_ASESSMENTTYPEs), new Action<MIS_ASESSMENTTYPE>(this.detach_MIS_ASESSMENTTYPEs));
            this._MIS_BIOPSYRESULTs = new EntitySet<MIS_BIOPSYRESULT>(new Action<MIS_BIOPSYRESULT>(this.attach_MIS_BIOPSYRESULTs), new Action<MIS_BIOPSYRESULT>(this.detach_MIS_BIOPSYRESULTs));
            this._MIS_LESIONTYPEs = new EntitySet<MIS_LESIONTYPE>(new Action<MIS_LESIONTYPE>(this.attach_MIS_LESIONTYPEs), new Action<MIS_LESIONTYPE>(this.detach_MIS_LESIONTYPEs));
            this._MIS_TECHNIQUETYPEs = new EntitySet<MIS_TECHNIQUETYPE>(new Action<MIS_TECHNIQUETYPE>(this.attach_MIS_TECHNIQUETYPEs), new Action<MIS_TECHNIQUETYPE>(this.detach_MIS_TECHNIQUETYPEs));
            this._RIS_ACRs = new EntitySet<RIS_ACR>(new Action<RIS_ACR>(this.attach_RIS_ACRs), new Action<RIS_ACR>(this.detach_RIS_ACRs));
            this._RIS_ASSESSMENTs = new EntitySet<RIS_ASSESSMENT>(new Action<RIS_ASSESSMENT>(this.attach_RIS_ASSESSMENTs), new Action<RIS_ASSESSMENT>(this.detach_RIS_ASSESSMENTs));
            this._RIS_BILLs = new EntitySet<RIS_BILL>(new Action<RIS_BILL>(this.attach_RIS_BILLs), new Action<RIS_BILL>(this.detach_RIS_BILLs));
            this._RIS_BODYPARTs = new EntitySet<RIS_BODYPART>(new Action<RIS_BODYPART>(this.attach_RIS_BODYPARTs), new Action<RIS_BODYPART>(this.detach_RIS_BODYPARTs));
            this._RIS_BPVIEWs = new EntitySet<RIS_BPVIEW>(new Action<RIS_BPVIEW>(this.attach_RIS_BPVIEWs), new Action<RIS_BPVIEW>(this.detach_RIS_BPVIEWs));
            this._RIS_CLINICSESSIONs = new EntitySet<RIS_CLINICSESSION>(new Action<RIS_CLINICSESSION>(this.attach_RIS_CLINICSESSIONs), new Action<RIS_CLINICSESSION>(this.detach_RIS_CLINICSESSIONs));
            this._RIS_CLINICTYPEs = new EntitySet<RIS_CLINICTYPE>(new Action<RIS_CLINICTYPE>(this.attach_RIS_CLINICTYPEs), new Action<RIS_CLINICTYPE>(this.detach_RIS_CLINICTYPEs));
            this._RIS_CONFLICTEXAMDTLs = new EntitySet<RIS_CONFLICTEXAMDTL>(new Action<RIS_CONFLICTEXAMDTL>(this.attach_RIS_CONFLICTEXAMDTLs), new Action<RIS_CONFLICTEXAMDTL>(this.detach_RIS_CONFLICTEXAMDTLs));
            this._RIS_CONFLICTEXAMGROUPs = new EntitySet<RIS_CONFLICTEXAMGROUP>(new Action<RIS_CONFLICTEXAMGROUP>(this.attach_RIS_CONFLICTEXAMGROUPs), new Action<RIS_CONFLICTEXAMGROUP>(this.detach_RIS_CONFLICTEXAMGROUPs));
            this._RIS_CONSUMABLETYPEs = new EntitySet<RIS_CONSUMABLETYPE>(new Action<RIS_CONSUMABLETYPE>(this.attach_RIS_CONSUMABLETYPEs), new Action<RIS_CONSUMABLETYPE>(this.detach_RIS_CONSUMABLETYPEs));
            this._RIS_EXAMINSTRUCTIONs = new EntitySet<RIS_EXAMINSTRUCTION>(new Action<RIS_EXAMINSTRUCTION>(this.attach_RIS_EXAMINSTRUCTIONs), new Action<RIS_EXAMINSTRUCTION>(this.detach_RIS_EXAMINSTRUCTIONs));
            this._RIS_EXAMRESULTs = new EntitySet<RIS_EXAMRESULT>(new Action<RIS_EXAMRESULT>(this.attach_RIS_EXAMRESULTs), new Action<RIS_EXAMRESULT>(this.detach_RIS_EXAMRESULTs));
            this._RIS_EXAMRESULTACCESSes = new EntitySet<RIS_EXAMRESULTACCESS>(new Action<RIS_EXAMRESULTACCESS>(this.attach_RIS_EXAMRESULTACCESSes), new Action<RIS_EXAMRESULTACCESS>(this.detach_RIS_EXAMRESULTACCESSes));
            this._RIS_EXAMRESULTNOTEs = new EntitySet<RIS_EXAMRESULTNOTE>(new Action<RIS_EXAMRESULTNOTE>(this.attach_RIS_EXAMRESULTNOTEs), new Action<RIS_EXAMRESULTNOTE>(this.detach_RIS_EXAMRESULTNOTEs));
            this._RIS_EXAMRESULTSEVERITies = new EntitySet<RIS_EXAMRESULTSEVERITY>(new Action<RIS_EXAMRESULTSEVERITY>(this.attach_RIS_EXAMRESULTSEVERITies), new Action<RIS_EXAMRESULTSEVERITY>(this.detach_RIS_EXAMRESULTSEVERITies));
            this._RIS_EXAMRESULTTEMPLATEs = new EntitySet<RIS_EXAMRESULTTEMPLATE>(new Action<RIS_EXAMRESULTTEMPLATE>(this.attach_RIS_EXAMRESULTTEMPLATEs), new Action<RIS_EXAMRESULTTEMPLATE>(this.detach_RIS_EXAMRESULTTEMPLATEs));
            this._RIS_EXAMTEMPLATESHAREs = new EntitySet<RIS_EXAMTEMPLATESHARE>(new Action<RIS_EXAMTEMPLATESHARE>(this.attach_RIS_EXAMTEMPLATESHAREs), new Action<RIS_EXAMTEMPLATESHARE>(this.detach_RIS_EXAMTEMPLATESHAREs));
            this._RIS_EXAMTYPEs = new EntitySet<RIS_EXAMTYPE>(new Action<RIS_EXAMTYPE>(this.attach_RIS_EXAMTYPEs), new Action<RIS_EXAMTYPE>(this.detach_RIS_EXAMTYPEs));
            this._RIS_HOSPITAL_MAP_DOCTORs = new EntitySet<RIS_HOSPITAL_MAP_DOCTOR>(new Action<RIS_HOSPITAL_MAP_DOCTOR>(this.attach_RIS_HOSPITAL_MAP_DOCTORs), new Action<RIS_HOSPITAL_MAP_DOCTOR>(this.detach_RIS_HOSPITAL_MAP_DOCTORs));
            this._RIS_MODALITies = new EntitySet<RIS_MODALITY>(new Action<RIS_MODALITY>(this.attach_RIS_MODALITies), new Action<RIS_MODALITY>(this.detach_RIS_MODALITies));
            this._RIS_MODALITYEXAMs = new EntitySet<RIS_MODALITYEXAM>(new Action<RIS_MODALITYEXAM>(this.attach_RIS_MODALITYEXAMs), new Action<RIS_MODALITYEXAM>(this.detach_RIS_MODALITYEXAMs));
            this._RIS_MODALITYTYPEs = new EntitySet<RIS_MODALITYTYPE>(new Action<RIS_MODALITYTYPE>(this.attach_RIS_MODALITYTYPEs), new Action<RIS_MODALITYTYPE>(this.detach_RIS_MODALITYTYPEs));
            this._RIS_ORDERs = new EntitySet<RIS_ORDER>(new Action<RIS_ORDER>(this.attach_RIS_ORDERs), new Action<RIS_ORDER>(this.detach_RIS_ORDERs));
            this._RIS_ORDERDTLs = new EntitySet<RIS_ORDERDTL>(new Action<RIS_ORDERDTL>(this.attach_RIS_ORDERDTLs), new Action<RIS_ORDERDTL>(this.detach_RIS_ORDERDTLs));
            this._RIS_ORDERIMAGEs = new EntitySet<RIS_ORDERIMAGE>(new Action<RIS_ORDERIMAGE>(this.attach_RIS_ORDERIMAGEs), new Action<RIS_ORDERIMAGE>(this.detach_RIS_ORDERIMAGEs));
            this._RIS_PATICDs = new EntitySet<RIS_PATICD>(new Action<RIS_PATICD>(this.attach_RIS_PATICDs), new Action<RIS_PATICD>(this.detach_RIS_PATICDs));
            this._RIS_PATSTATUS = new EntitySet<RIS_PATSTATUS>(new Action<RIS_PATSTATUS>(this.attach_RIS_PATSTATUS), new Action<RIS_PATSTATUS>(this.detach_RIS_PATSTATUS));
            this._RIS_PATSTATUS1 = new EntitySet<RIS_PATSTATUS>(new Action<RIS_PATSTATUS>(this.attach_RIS_PATSTATUS1), new Action<RIS_PATSTATUS>(this.detach_RIS_PATSTATUS1));
            this._RIS_QAWORKs = new EntitySet<RIS_QAWORK>(new Action<RIS_QAWORK>(this.attach_RIS_QAWORKs), new Action<RIS_QAWORK>(this.detach_RIS_QAWORKs));
            this._RIS_QUESTIONs = new EntitySet<RIS_QUESTION>(new Action<RIS_QUESTION>(this.attach_RIS_QUESTIONs), new Action<RIS_QUESTION>(this.detach_RIS_QUESTIONs));
            this._RIS_RADSTUDYGROUPs = new EntitySet<RIS_RADSTUDYGROUP>(new Action<RIS_RADSTUDYGROUP>(this.attach_RIS_RADSTUDYGROUPs), new Action<RIS_RADSTUDYGROUP>(this.detach_RIS_RADSTUDYGROUPs));
            this._RIS_RESULTSTATUSCHANGELOGs = new EntitySet<RIS_RESULTSTATUSCHANGELOG>(new Action<RIS_RESULTSTATUSCHANGELOG>(this.attach_RIS_RESULTSTATUSCHANGELOGs), new Action<RIS_RESULTSTATUSCHANGELOG>(this.detach_RIS_RESULTSTATUSCHANGELOGs));
            this._RIS_SCHEDULEs = new EntitySet<RIS_SCHEDULE>(new Action<RIS_SCHEDULE>(this.attach_RIS_SCHEDULEs), new Action<RIS_SCHEDULE>(this.detach_RIS_SCHEDULEs));
            this._RIS_SERVICETYPEs = new EntitySet<RIS_SERVICETYPE>(new Action<RIS_SERVICETYPE>(this.attach_RIS_SERVICETYPEs), new Action<RIS_SERVICETYPE>(this.detach_RIS_SERVICETYPEs));
            this._RIS_SESSIONMAXAPPs = new EntitySet<RIS_SESSIONMAXAPP>(new Action<RIS_SESSIONMAXAPP>(this.attach_RIS_SESSIONMAXAPPs), new Action<RIS_SESSIONMAXAPP>(this.detach_RIS_SESSIONMAXAPPs));
            this._RIS_TECHCONSUMPTIONs = new EntitySet<RIS_TECHCONSUMPTION>(new Action<RIS_TECHCONSUMPTION>(this.attach_RIS_TECHCONSUMPTIONs), new Action<RIS_TECHCONSUMPTION>(this.detach_RIS_TECHCONSUMPTIONs));
            this._RIS_TECHWORKs = new EntitySet<RIS_TECHWORK>(new Action<RIS_TECHWORK>(this.attach_RIS_TECHWORKs), new Action<RIS_TECHWORK>(this.detach_RIS_TECHWORKs));
            OnCreated();
        }

        [Column(Storage = "_ORG_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int ORG_ID
        {
            get
            {
                return this._ORG_ID;
            }
            set
            {
                if ((this._ORG_ID != value))
                {
                    this.OnORG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_ID = value;
                    this.SendPropertyChanged("ORG_ID");
                    this.OnORG_IDChanged();
                }
            }
        }

        [Column(Storage = "_ORG_UID", DbType = "NVarChar(30)")]
        public string ORG_UID
        {
            get
            {
                return this._ORG_UID;
            }
            set
            {
                if ((this._ORG_UID != value))
                {
                    this.OnORG_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_UID = value;
                    this.SendPropertyChanged("ORG_UID");
                    this.OnORG_UIDChanged();
                }
            }
        }

        [Column(Storage = "_ORG_NAME", DbType = "NVarChar(100)")]
        public string ORG_NAME
        {
            get
            {
                return this._ORG_NAME;
            }
            set
            {
                if ((this._ORG_NAME != value))
                {
                    this.OnORG_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_NAME = value;
                    this.SendPropertyChanged("ORG_NAME");
                    this.OnORG_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_ORG_ALIAS", DbType = "NVarChar(30)")]
        public string ORG_ALIAS
        {
            get
            {
                return this._ORG_ALIAS;
            }
            set
            {
                if ((this._ORG_ALIAS != value))
                {
                    this.OnORG_ALIASChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_ALIAS = value;
                    this.SendPropertyChanged("ORG_ALIAS");
                    this.OnORG_ALIASChanged();
                }
            }
        }

        [Column(Storage = "_ORG_SLOGAN1", DbType = "NVarChar(100)")]
        public string ORG_SLOGAN1
        {
            get
            {
                return this._ORG_SLOGAN1;
            }
            set
            {
                if ((this._ORG_SLOGAN1 != value))
                {
                    this.OnORG_SLOGAN1Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_SLOGAN1 = value;
                    this.SendPropertyChanged("ORG_SLOGAN1");
                    this.OnORG_SLOGAN1Changed();
                }
            }
        }

        [Column(Storage = "_ORG_SLOGAN2", DbType = "NVarChar(100)")]
        public string ORG_SLOGAN2
        {
            get
            {
                return this._ORG_SLOGAN2;
            }
            set
            {
                if ((this._ORG_SLOGAN2 != value))
                {
                    this.OnORG_SLOGAN2Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_SLOGAN2 = value;
                    this.SendPropertyChanged("ORG_SLOGAN2");
                    this.OnORG_SLOGAN2Changed();
                }
            }
        }

        [Column(Storage = "_ORG_ADDR1", DbType = "NVarChar(100)")]
        public string ORG_ADDR1
        {
            get
            {
                return this._ORG_ADDR1;
            }
            set
            {
                if ((this._ORG_ADDR1 != value))
                {
                    this.OnORG_ADDR1Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_ADDR1 = value;
                    this.SendPropertyChanged("ORG_ADDR1");
                    this.OnORG_ADDR1Changed();
                }
            }
        }

        [Column(Storage = "_ORG_ADDR2", DbType = "NVarChar(100)")]
        public string ORG_ADDR2
        {
            get
            {
                return this._ORG_ADDR2;
            }
            set
            {
                if ((this._ORG_ADDR2 != value))
                {
                    this.OnORG_ADDR2Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_ADDR2 = value;
                    this.SendPropertyChanged("ORG_ADDR2");
                    this.OnORG_ADDR2Changed();
                }
            }
        }

        [Column(Storage = "_ORG_ADDR3", DbType = "NVarChar(100)")]
        public string ORG_ADDR3
        {
            get
            {
                return this._ORG_ADDR3;
            }
            set
            {
                if ((this._ORG_ADDR3 != value))
                {
                    this.OnORG_ADDR3Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_ADDR3 = value;
                    this.SendPropertyChanged("ORG_ADDR3");
                    this.OnORG_ADDR3Changed();
                }
            }
        }

        [Column(Storage = "_ORG_ADDR4", DbType = "NVarChar(100)")]
        public string ORG_ADDR4
        {
            get
            {
                return this._ORG_ADDR4;
            }
            set
            {
                if ((this._ORG_ADDR4 != value))
                {
                    this.OnORG_ADDR4Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_ADDR4 = value;
                    this.SendPropertyChanged("ORG_ADDR4");
                    this.OnORG_ADDR4Changed();
                }
            }
        }

        [Column(Storage = "_ORG_TEL1", DbType = "NVarChar(100)")]
        public string ORG_TEL1
        {
            get
            {
                return this._ORG_TEL1;
            }
            set
            {
                if ((this._ORG_TEL1 != value))
                {
                    this.OnORG_TEL1Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_TEL1 = value;
                    this.SendPropertyChanged("ORG_TEL1");
                    this.OnORG_TEL1Changed();
                }
            }
        }

        [Column(Storage = "_ORG_TEL2", DbType = "NVarChar(100)")]
        public string ORG_TEL2
        {
            get
            {
                return this._ORG_TEL2;
            }
            set
            {
                if ((this._ORG_TEL2 != value))
                {
                    this.OnORG_TEL2Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_TEL2 = value;
                    this.SendPropertyChanged("ORG_TEL2");
                    this.OnORG_TEL2Changed();
                }
            }
        }

        [Column(Storage = "_ORG_TEL3", DbType = "NVarChar(100)")]
        public string ORG_TEL3
        {
            get
            {
                return this._ORG_TEL3;
            }
            set
            {
                if ((this._ORG_TEL3 != value))
                {
                    this.OnORG_TEL3Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_TEL3 = value;
                    this.SendPropertyChanged("ORG_TEL3");
                    this.OnORG_TEL3Changed();
                }
            }
        }

        [Column(Storage = "_ORG_FAX", DbType = "NVarChar(100)")]
        public string ORG_FAX
        {
            get
            {
                return this._ORG_FAX;
            }
            set
            {
                if ((this._ORG_FAX != value))
                {
                    this.OnORG_FAXChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_FAX = value;
                    this.SendPropertyChanged("ORG_FAX");
                    this.OnORG_FAXChanged();
                }
            }
        }

        [Column(Storage = "_ORG_EMAIL1", DbType = "NVarChar(100)")]
        public string ORG_EMAIL1
        {
            get
            {
                return this._ORG_EMAIL1;
            }
            set
            {
                if ((this._ORG_EMAIL1 != value))
                {
                    this.OnORG_EMAIL1Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_EMAIL1 = value;
                    this.SendPropertyChanged("ORG_EMAIL1");
                    this.OnORG_EMAIL1Changed();
                }
            }
        }

        [Column(Storage = "_ORG_EMAIL2", DbType = "NVarChar(100)")]
        public string ORG_EMAIL2
        {
            get
            {
                return this._ORG_EMAIL2;
            }
            set
            {
                if ((this._ORG_EMAIL2 != value))
                {
                    this.OnORG_EMAIL2Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_EMAIL2 = value;
                    this.SendPropertyChanged("ORG_EMAIL2");
                    this.OnORG_EMAIL2Changed();
                }
            }
        }

        [Column(Storage = "_ORG_EMAIL3", DbType = "NVarChar(100)")]
        public string ORG_EMAIL3
        {
            get
            {
                return this._ORG_EMAIL3;
            }
            set
            {
                if ((this._ORG_EMAIL3 != value))
                {
                    this.OnORG_EMAIL3Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_EMAIL3 = value;
                    this.SendPropertyChanged("ORG_EMAIL3");
                    this.OnORG_EMAIL3Changed();
                }
            }
        }

        [Column(Storage = "_ORG_WEBSITE", DbType = "NVarChar(100)")]
        public string ORG_WEBSITE
        {
            get
            {
                return this._ORG_WEBSITE;
            }
            set
            {
                if ((this._ORG_WEBSITE != value))
                {
                    this.OnORG_WEBSITEChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_WEBSITE = value;
                    this.SendPropertyChanged("ORG_WEBSITE");
                    this.OnORG_WEBSITEChanged();
                }
            }
        }

        [Column(Storage = "_ORG_IMG", DbType = "Image", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary ORG_IMG
        {
            get
            {
                return this._ORG_IMG;
            }
            set
            {
                if ((this._ORG_IMG != value))
                {
                    this.OnORG_IMGChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_IMG = value;
                    this.SendPropertyChanged("ORG_IMG");
                    this.OnORG_IMGChanged();
                }
            }
        }

        [Column(Storage = "_WELCOME_DIALOG1", DbType = "NVarChar(500)")]
        public string WELCOME_DIALOG1
        {
            get
            {
                return this._WELCOME_DIALOG1;
            }
            set
            {
                if ((this._WELCOME_DIALOG1 != value))
                {
                    this.OnWELCOME_DIALOG1Changing(value);
                    this.SendPropertyChanging();
                    this._WELCOME_DIALOG1 = value;
                    this.SendPropertyChanged("WELCOME_DIALOG1");
                    this.OnWELCOME_DIALOG1Changed();
                }
            }
        }

        [Column(Storage = "_WELCOME_DIALOG2", DbType = "NVarChar(500)")]
        public string WELCOME_DIALOG2
        {
            get
            {
                return this._WELCOME_DIALOG2;
            }
            set
            {
                if ((this._WELCOME_DIALOG2 != value))
                {
                    this.OnWELCOME_DIALOG2Changing(value);
                    this.SendPropertyChanging();
                    this._WELCOME_DIALOG2 = value;
                    this.SendPropertyChanged("WELCOME_DIALOG2");
                    this.OnWELCOME_DIALOG2Changed();
                }
            }
        }

        [Column(Storage = "_DEFAULT_FONT_FACE", DbType = "NVarChar(200)")]
        public string DEFAULT_FONT_FACE
        {
            get
            {
                return this._DEFAULT_FONT_FACE;
            }
            set
            {
                if ((this._DEFAULT_FONT_FACE != value))
                {
                    this.OnDEFAULT_FONT_FACEChanging(value);
                    this.SendPropertyChanging();
                    this._DEFAULT_FONT_FACE = value;
                    this.SendPropertyChanged("DEFAULT_FONT_FACE");
                    this.OnDEFAULT_FONT_FACEChanged();
                }
            }
        }

        [Column(Storage = "_DEFAULT_FONT_SIZE", DbType = "TinyInt")]
        public System.Nullable<byte> DEFAULT_FONT_SIZE
        {
            get
            {
                return this._DEFAULT_FONT_SIZE;
            }
            set
            {
                if ((this._DEFAULT_FONT_SIZE != value))
                {
                    this.OnDEFAULT_FONT_SIZEChanging(value);
                    this.SendPropertyChanging();
                    this._DEFAULT_FONT_SIZE = value;
                    this.SendPropertyChanged("DEFAULT_FONT_SIZE");
                    this.OnDEFAULT_FONT_SIZEChanged();
                }
            }
        }

        [Column(Storage = "_REP_SERVER", DbType = "NVarChar(50)")]
        public string REP_SERVER
        {
            get
            {
                return this._REP_SERVER;
            }
            set
            {
                if ((this._REP_SERVER != value))
                {
                    this.OnREP_SERVERChanging(value);
                    this.SendPropertyChanging();
                    this._REP_SERVER = value;
                    this.SendPropertyChanged("REP_SERVER");
                    this.OnREP_SERVERChanged();
                }
            }
        }

        [Column(Storage = "_REP_FORMAT", DbType = "NVarChar(30)")]
        public string REP_FORMAT
        {
            get
            {
                return this._REP_FORMAT;
            }
            set
            {
                if ((this._REP_FORMAT != value))
                {
                    this.OnREP_FORMATChanging(value);
                    this.SendPropertyChanging();
                    this._REP_FORMAT = value;
                    this.SendPropertyChanged("REP_FORMAT");
                    this.OnREP_FORMATChanged();
                }
            }
        }

        [Column(Storage = "_REP_FOOTER1", DbType = "NVarChar(500)")]
        public string REP_FOOTER1
        {
            get
            {
                return this._REP_FOOTER1;
            }
            set
            {
                if ((this._REP_FOOTER1 != value))
                {
                    this.OnREP_FOOTER1Changing(value);
                    this.SendPropertyChanging();
                    this._REP_FOOTER1 = value;
                    this.SendPropertyChanged("REP_FOOTER1");
                    this.OnREP_FOOTER1Changed();
                }
            }
        }

        [Column(Storage = "_REP_FOOTER2", DbType = "NVarChar(500)")]
        public string REP_FOOTER2
        {
            get
            {
                return this._REP_FOOTER2;
            }
            set
            {
                if ((this._REP_FOOTER2 != value))
                {
                    this.OnREP_FOOTER2Changing(value);
                    this.SendPropertyChanging();
                    this._REP_FOOTER2 = value;
                    this.SendPropertyChanged("REP_FOOTER2");
                    this.OnREP_FOOTER2Changed();
                }
            }
        }

        [Column(Storage = "_EMP_IMG_TYPE", DbType = "NVarChar(4)")]
        public string EMP_IMG_TYPE
        {
            get
            {
                return this._EMP_IMG_TYPE;
            }
            set
            {
                if ((this._EMP_IMG_TYPE != value))
                {
                    this.OnEMP_IMG_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_IMG_TYPE = value;
                    this.SendPropertyChanged("EMP_IMG_TYPE");
                    this.OnEMP_IMG_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_EMP_IMG_MAX_SIZE", DbType = "NVarChar(4)")]
        public string EMP_IMG_MAX_SIZE
        {
            get
            {
                return this._EMP_IMG_MAX_SIZE;
            }
            set
            {
                if ((this._EMP_IMG_MAX_SIZE != value))
                {
                    this.OnEMP_IMG_MAX_SIZEChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_IMG_MAX_SIZE = value;
                    this.SendPropertyChanged("EMP_IMG_MAX_SIZE");
                    this.OnEMP_IMG_MAX_SIZEChanged();
                }
            }
        }

        [Column(Storage = "_OTHER_MAX_FILE_SIZE", DbType = "Int")]
        public System.Nullable<int> OTHER_MAX_FILE_SIZE
        {
            get
            {
                return this._OTHER_MAX_FILE_SIZE;
            }
            set
            {
                if ((this._OTHER_MAX_FILE_SIZE != value))
                {
                    this.OnOTHER_MAX_FILE_SIZEChanging(value);
                    this.SendPropertyChanging();
                    this._OTHER_MAX_FILE_SIZE = value;
                    this.SendPropertyChanged("OTHER_MAX_FILE_SIZE");
                    this.OnOTHER_MAX_FILE_SIZEChanged();
                }
            }
        }

        [Column(Storage = "_DT_FMT", DbType = "NVarChar(30)")]
        public string DT_FMT
        {
            get
            {
                return this._DT_FMT;
            }
            set
            {
                if ((this._DT_FMT != value))
                {
                    this.OnDT_FMTChanging(value);
                    this.SendPropertyChanging();
                    this._DT_FMT = value;
                    this.SendPropertyChanged("DT_FMT");
                    this.OnDT_FMTChanged();
                }
            }
        }

        [Column(Storage = "_TIME_FMT", DbType = "NVarChar(30)")]
        public string TIME_FMT
        {
            get
            {
                return this._TIME_FMT;
            }
            set
            {
                if ((this._TIME_FMT != value))
                {
                    this.OnTIME_FMTChanging(value);
                    this.SendPropertyChanging();
                    this._TIME_FMT = value;
                    this.SendPropertyChanged("TIME_FMT");
                    this.OnTIME_FMTChanged();
                }
            }
        }

        [Column(Storage = "_LOCAL_CURRENCY_NAME", DbType = "NVarChar(15)")]
        public string LOCAL_CURRENCY_NAME
        {
            get
            {
                return this._LOCAL_CURRENCY_NAME;
            }
            set
            {
                if ((this._LOCAL_CURRENCY_NAME != value))
                {
                    this.OnLOCAL_CURRENCY_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._LOCAL_CURRENCY_NAME = value;
                    this.SendPropertyChanged("LOCAL_CURRENCY_NAME");
                    this.OnLOCAL_CURRENCY_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_LOCAL_CURRENCY_SYMBOL", DbType = "NVarChar(2)")]
        public string LOCAL_CURRENCY_SYMBOL
        {
            get
            {
                return this._LOCAL_CURRENCY_SYMBOL;
            }
            set
            {
                if ((this._LOCAL_CURRENCY_SYMBOL != value))
                {
                    this.OnLOCAL_CURRENCY_SYMBOLChanging(value);
                    this.SendPropertyChanging();
                    this._LOCAL_CURRENCY_SYMBOL = value;
                    this.SendPropertyChanged("LOCAL_CURRENCY_SYMBOL");
                    this.OnLOCAL_CURRENCY_SYMBOLChanged();
                }
            }
        }

        [Column(Storage = "_CURRENCY_FMT", DbType = "NVarChar(30)")]
        public string CURRENCY_FMT
        {
            get
            {
                return this._CURRENCY_FMT;
            }
            set
            {
                if ((this._CURRENCY_FMT != value))
                {
                    this.OnCURRENCY_FMTChanging(value);
                    this.SendPropertyChanging();
                    this._CURRENCY_FMT = value;
                    this.SendPropertyChanged("CURRENCY_FMT");
                    this.OnCURRENCY_FMTChanged();
                }
            }
        }

        [Column(Storage = "_RESOURCE_IMAGE_PATH", DbType = "NVarChar(300)")]
        public string RESOURCE_IMAGE_PATH
        {
            get
            {
                return this._RESOURCE_IMAGE_PATH;
            }
            set
            {
                if ((this._RESOURCE_IMAGE_PATH != value))
                {
                    this.OnRESOURCE_IMAGE_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._RESOURCE_IMAGE_PATH = value;
                    this.SendPropertyChanged("RESOURCE_IMAGE_PATH");
                    this.OnRESOURCE_IMAGE_PATHChanged();
                }
            }
        }

        [Column(Storage = "_SCANNED_IMAGE_PATH", DbType = "NVarChar(300)")]
        public string SCANNED_IMAGE_PATH
        {
            get
            {
                return this._SCANNED_IMAGE_PATH;
            }
            set
            {
                if ((this._SCANNED_IMAGE_PATH != value))
                {
                    this.OnSCANNED_IMAGE_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._SCANNED_IMAGE_PATH = value;
                    this.SendPropertyChanged("SCANNED_IMAGE_PATH");
                    this.OnSCANNED_IMAGE_PATHChanged();
                }
            }
        }

        [Column(Storage = "_DOCUMENT_PATH", DbType = "NVarChar(500)")]
        public string DOCUMENT_PATH
        {
            get
            {
                return this._DOCUMENT_PATH;
            }
            set
            {
                if ((this._DOCUMENT_PATH != value))
                {
                    this.OnDOCUMENT_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._DOCUMENT_PATH = value;
                    this.SendPropertyChanged("DOCUMENT_PATH");
                    this.OnDOCUMENT_PATHChanged();
                }
            }
        }

        [Column(Storage = "_BACKUP_PATH", DbType = "NVarChar(500)")]
        public string BACKUP_PATH
        {
            get
            {
                return this._BACKUP_PATH;
            }
            set
            {
                if ((this._BACKUP_PATH != value))
                {
                    this.OnBACKUP_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._BACKUP_PATH = value;
                    this.SendPropertyChanged("BACKUP_PATH");
                    this.OnBACKUP_PATHChanged();
                }
            }
        }

        [Column(Storage = "_OTHER_FILE_PATH", DbType = "NVarChar(300)")]
        public string OTHER_FILE_PATH
        {
            get
            {
                return this._OTHER_FILE_PATH;
            }
            set
            {
                if ((this._OTHER_FILE_PATH != value))
                {
                    this.OnOTHER_FILE_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._OTHER_FILE_PATH = value;
                    this.SendPropertyChanged("OTHER_FILE_PATH");
                    this.OnOTHER_FILE_PATHChanged();
                }
            }
        }

        [Column(Storage = "_EMP_IMG_PATH", DbType = "NVarChar(300)")]
        public string EMP_IMG_PATH
        {
            get
            {
                return this._EMP_IMG_PATH;
            }
            set
            {
                if ((this._EMP_IMG_PATH != value))
                {
                    this.OnEMP_IMG_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_IMG_PATH = value;
                    this.SendPropertyChanged("EMP_IMG_PATH");
                    this.OnEMP_IMG_PATHChanged();
                }
            }
        }

        [Column(Storage = "_LAB_DATA_PATH", DbType = "NVarChar(300)")]
        public string LAB_DATA_PATH
        {
            get
            {
                return this._LAB_DATA_PATH;
            }
            set
            {
                if ((this._LAB_DATA_PATH != value))
                {
                    this.OnLAB_DATA_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._LAB_DATA_PATH = value;
                    this.SendPropertyChanged("LAB_DATA_PATH");
                    this.OnLAB_DATA_PATHChanged();
                }
            }
        }

        [Column(Storage = "_USER_DISPLAY_FMT", DbType = "NVarChar(10)")]
        public string USER_DISPLAY_FMT
        {
            get
            {
                return this._USER_DISPLAY_FMT;
            }
            set
            {
                if ((this._USER_DISPLAY_FMT != value))
                {
                    this.OnUSER_DISPLAY_FMTChanging(value);
                    this.SendPropertyChanging();
                    this._USER_DISPLAY_FMT = value;
                    this.SendPropertyChanged("USER_DISPLAY_FMT");
                    this.OnUSER_DISPLAY_FMTChanged();
                }
            }
        }

        [Column(Storage = "_VENDOR_H1", DbType = "NVarChar(300)")]
        public string VENDOR_H1
        {
            get
            {
                return this._VENDOR_H1;
            }
            set
            {
                if ((this._VENDOR_H1 != value))
                {
                    this.OnVENDOR_H1Changing(value);
                    this.SendPropertyChanging();
                    this._VENDOR_H1 = value;
                    this.SendPropertyChanged("VENDOR_H1");
                    this.OnVENDOR_H1Changed();
                }
            }
        }

        [Column(Storage = "_VENDOR_H2", DbType = "NVarChar(300)")]
        public string VENDOR_H2
        {
            get
            {
                return this._VENDOR_H2;
            }
            set
            {
                if ((this._VENDOR_H2 != value))
                {
                    this.OnVENDOR_H2Changing(value);
                    this.SendPropertyChanging();
                    this._VENDOR_H2 = value;
                    this.SendPropertyChanged("VENDOR_H2");
                    this.OnVENDOR_H2Changed();
                }
            }
        }

        [Column(Storage = "_VENDOR_LOGO_PATH", DbType = "NVarChar(300)")]
        public string VENDOR_LOGO_PATH
        {
            get
            {
                return this._VENDOR_LOGO_PATH;
            }
            set
            {
                if ((this._VENDOR_LOGO_PATH != value))
                {
                    this.OnVENDOR_LOGO_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._VENDOR_LOGO_PATH = value;
                    this.SendPropertyChanged("VENDOR_LOGO_PATH");
                    this.OnVENDOR_LOGO_PATHChanged();
                }
            }
        }

        [Column(Storage = "_PARTNER1_H1", DbType = "NVarChar(300)")]
        public string PARTNER1_H1
        {
            get
            {
                return this._PARTNER1_H1;
            }
            set
            {
                if ((this._PARTNER1_H1 != value))
                {
                    this.OnPARTNER1_H1Changing(value);
                    this.SendPropertyChanging();
                    this._PARTNER1_H1 = value;
                    this.SendPropertyChanged("PARTNER1_H1");
                    this.OnPARTNER1_H1Changed();
                }
            }
        }

        [Column(Storage = "_PARTNER1_H2", DbType = "NVarChar(300)")]
        public string PARTNER1_H2
        {
            get
            {
                return this._PARTNER1_H2;
            }
            set
            {
                if ((this._PARTNER1_H2 != value))
                {
                    this.OnPARTNER1_H2Changing(value);
                    this.SendPropertyChanging();
                    this._PARTNER1_H2 = value;
                    this.SendPropertyChanged("PARTNER1_H2");
                    this.OnPARTNER1_H2Changed();
                }
            }
        }

        [Column(Storage = "_PARTNER1_LOGO_PATH", DbType = "NVarChar(300)")]
        public string PARTNER1_LOGO_PATH
        {
            get
            {
                return this._PARTNER1_LOGO_PATH;
            }
            set
            {
                if ((this._PARTNER1_LOGO_PATH != value))
                {
                    this.OnPARTNER1_LOGO_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._PARTNER1_LOGO_PATH = value;
                    this.SendPropertyChanged("PARTNER1_LOGO_PATH");
                    this.OnPARTNER1_LOGO_PATHChanged();
                }
            }
        }

        [Column(Storage = "_PARTNER2_H1", DbType = "NVarChar(300)")]
        public string PARTNER2_H1
        {
            get
            {
                return this._PARTNER2_H1;
            }
            set
            {
                if ((this._PARTNER2_H1 != value))
                {
                    this.OnPARTNER2_H1Changing(value);
                    this.SendPropertyChanging();
                    this._PARTNER2_H1 = value;
                    this.SendPropertyChanged("PARTNER2_H1");
                    this.OnPARTNER2_H1Changed();
                }
            }
        }

        [Column(Storage = "_PARTNER2_H2", DbType = "NVarChar(300)")]
        public string PARTNER2_H2
        {
            get
            {
                return this._PARTNER2_H2;
            }
            set
            {
                if ((this._PARTNER2_H2 != value))
                {
                    this.OnPARTNER2_H2Changing(value);
                    this.SendPropertyChanging();
                    this._PARTNER2_H2 = value;
                    this.SendPropertyChanged("PARTNER2_H2");
                    this.OnPARTNER2_H2Changed();
                }
            }
        }

        [Column(Storage = "_PARTNER2_LOGO_PATH", DbType = "NVarChar(300)")]
        public string PARTNER2_LOGO_PATH
        {
            get
            {
                return this._PARTNER2_LOGO_PATH;
            }
            set
            {
                if ((this._PARTNER2_LOGO_PATH != value))
                {
                    this.OnPARTNER2_LOGO_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._PARTNER2_LOGO_PATH = value;
                    this.SendPropertyChanged("PARTNER2_LOGO_PATH");
                    this.OnPARTNER2_LOGO_PATHChanged();
                }
            }
        }

        [Column(Storage = "_RIS_IP", DbType = "NVarChar(300)")]
        public string RIS_IP
        {
            get
            {
                return this._RIS_IP;
            }
            set
            {
                if ((this._RIS_IP != value))
                {
                    this.OnRIS_IPChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_IP = value;
                    this.SendPropertyChanged("RIS_IP");
                    this.OnRIS_IPChanged();
                }
            }
        }

        [Column(Storage = "_RIS_PORT", DbType = "NVarChar(300)")]
        public string RIS_PORT
        {
            get
            {
                return this._RIS_PORT;
            }
            set
            {
                if ((this._RIS_PORT != value))
                {
                    this.OnRIS_PORTChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_PORT = value;
                    this.SendPropertyChanged("RIS_PORT");
                    this.OnRIS_PORTChanged();
                }
            }
        }

        [Column(Storage = "_RIS_USER", DbType = "NVarChar(300)")]
        public string RIS_USER
        {
            get
            {
                return this._RIS_USER;
            }
            set
            {
                if ((this._RIS_USER != value))
                {
                    this.OnRIS_USERChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_USER = value;
                    this.SendPropertyChanged("RIS_USER");
                    this.OnRIS_USERChanged();
                }
            }
        }

        [Column(Storage = "_RIS_PASS", DbType = "NVarChar(300)")]
        public string RIS_PASS
        {
            get
            {
                return this._RIS_PASS;
            }
            set
            {
                if ((this._RIS_PASS != value))
                {
                    this.OnRIS_PASSChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_PASS = value;
                    this.SendPropertyChanged("RIS_PASS");
                    this.OnRIS_PASSChanged();
                }
            }
        }

        [Column(Storage = "_RIS_URL", DbType = "NVarChar(300)")]
        public string RIS_URL
        {
            get
            {
                return this._RIS_URL;
            }
            set
            {
                if ((this._RIS_URL != value))
                {
                    this.OnRIS_URLChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_URL = value;
                    this.SendPropertyChanged("RIS_URL");
                    this.OnRIS_URLChanged();
                }
            }
        }

        [Column(Storage = "_PACS_IP", DbType = "NVarChar(300)")]
        public string PACS_IP
        {
            get
            {
                return this._PACS_IP;
            }
            set
            {
                if ((this._PACS_IP != value))
                {
                    this.OnPACS_IPChanging(value);
                    this.SendPropertyChanging();
                    this._PACS_IP = value;
                    this.SendPropertyChanged("PACS_IP");
                    this.OnPACS_IPChanged();
                }
            }
        }

        [Column(Storage = "_PACS_PORT", DbType = "NVarChar(300)")]
        public string PACS_PORT
        {
            get
            {
                return this._PACS_PORT;
            }
            set
            {
                if ((this._PACS_PORT != value))
                {
                    this.OnPACS_PORTChanging(value);
                    this.SendPropertyChanging();
                    this._PACS_PORT = value;
                    this.SendPropertyChanged("PACS_PORT");
                    this.OnPACS_PORTChanged();
                }
            }
        }

        [Column(Storage = "_PACS_URL1", DbType = "NVarChar(300)")]
        public string PACS_URL1
        {
            get
            {
                return this._PACS_URL1;
            }
            set
            {
                if ((this._PACS_URL1 != value))
                {
                    this.OnPACS_URL1Changing(value);
                    this.SendPropertyChanging();
                    this._PACS_URL1 = value;
                    this.SendPropertyChanged("PACS_URL1");
                    this.OnPACS_URL1Changed();
                }
            }
        }

        [Column(Storage = "_PACS_URL2", DbType = "NVarChar(300)")]
        public string PACS_URL2
        {
            get
            {
                return this._PACS_URL2;
            }
            set
            {
                if ((this._PACS_URL2 != value))
                {
                    this.OnPACS_URL2Changing(value);
                    this.SendPropertyChanging();
                    this._PACS_URL2 = value;
                    this.SendPropertyChanged("PACS_URL2");
                    this.OnPACS_URL2Changed();
                }
            }
        }

        [Column(Storage = "_PACS_URL3", DbType = "NVarChar(300)")]
        public string PACS_URL3
        {
            get
            {
                return this._PACS_URL3;
            }
            set
            {
                if ((this._PACS_URL3 != value))
                {
                    this.OnPACS_URL3Changing(value);
                    this.SendPropertyChanging();
                    this._PACS_URL3 = value;
                    this.SendPropertyChanged("PACS_URL3");
                    this.OnPACS_URL3Changed();
                }
            }
        }

        [Column(Storage = "_PACS_DOMAIN", DbType = "NVarChar(300)")]
        public string PACS_DOMAIN
        {
            get
            {
                return this._PACS_DOMAIN;
            }
            set
            {
                if ((this._PACS_DOMAIN != value))
                {
                    this.OnPACS_DOMAINChanging(value);
                    this.SendPropertyChanging();
                    this._PACS_DOMAIN = value;
                    this.SendPropertyChanged("PACS_DOMAIN");
                    this.OnPACS_DOMAINChanged();
                }
            }
        }

        [Column(Storage = "_HIS_IP", DbType = "NVarChar(300)")]
        public string HIS_IP
        {
            get
            {
                return this._HIS_IP;
            }
            set
            {
                if ((this._HIS_IP != value))
                {
                    this.OnHIS_IPChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_IP = value;
                    this.SendPropertyChanged("HIS_IP");
                    this.OnHIS_IPChanged();
                }
            }
        }

        [Column(Storage = "_HIS_PORT", DbType = "NVarChar(300)")]
        public string HIS_PORT
        {
            get
            {
                return this._HIS_PORT;
            }
            set
            {
                if ((this._HIS_PORT != value))
                {
                    this.OnHIS_PORTChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_PORT = value;
                    this.SendPropertyChanged("HIS_PORT");
                    this.OnHIS_PORTChanged();
                }
            }
        }

        [Column(Storage = "_HIS_DB_NAME", DbType = "NVarChar(300)")]
        public string HIS_DB_NAME
        {
            get
            {
                return this._HIS_DB_NAME;
            }
            set
            {
                if ((this._HIS_DB_NAME != value))
                {
                    this.OnHIS_DB_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_DB_NAME = value;
                    this.SendPropertyChanged("HIS_DB_NAME");
                    this.OnHIS_DB_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_HIS_USER_NAME", DbType = "NVarChar(300)")]
        public string HIS_USER_NAME
        {
            get
            {
                return this._HIS_USER_NAME;
            }
            set
            {
                if ((this._HIS_USER_NAME != value))
                {
                    this.OnHIS_USER_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_USER_NAME = value;
                    this.SendPropertyChanged("HIS_USER_NAME");
                    this.OnHIS_USER_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_HIS_USER_PASS", DbType = "NVarChar(300)")]
        public string HIS_USER_PASS
        {
            get
            {
                return this._HIS_USER_PASS;
            }
            set
            {
                if ((this._HIS_USER_PASS != value))
                {
                    this.OnHIS_USER_PASSChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_USER_PASS = value;
                    this.SendPropertyChanged("HIS_USER_PASS");
                    this.OnHIS_USER_PASSChanged();
                }
            }
        }

        [Column(Storage = "_HIS_FIN_FLAG", DbType = "NVarChar(300)")]
        public string HIS_FIN_FLAG
        {
            get
            {
                return this._HIS_FIN_FLAG;
            }
            set
            {
                if ((this._HIS_FIN_FLAG != value))
                {
                    this.OnHIS_FIN_FLAGChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_FIN_FLAG = value;
                    this.SendPropertyChanged("HIS_FIN_FLAG");
                    this.OnHIS_FIN_FLAGChanged();
                }
            }
        }

        [Column(Storage = "_WS_IP", DbType = "NVarChar(300)")]
        public string WS_IP
        {
            get
            {
                return this._WS_IP;
            }
            set
            {
                if ((this._WS_IP != value))
                {
                    this.OnWS_IPChanging(value);
                    this.SendPropertyChanging();
                    this._WS_IP = value;
                    this.SendPropertyChanged("WS_IP");
                    this.OnWS_IPChanged();
                }
            }
        }

        [Column(Storage = "_WS_IP_PICTURE", DbType = "NVarChar(300)")]
        public string WS_IP_PICTURE
        {
            get
            {
                return this._WS_IP_PICTURE;
            }
            set
            {
                if ((this._WS_IP_PICTURE != value))
                {
                    this.OnWS_IP_PICTUREChanging(value);
                    this.SendPropertyChanging();
                    this._WS_IP_PICTURE = value;
                    this.SendPropertyChanged("WS_IP_PICTURE");
                    this.OnWS_IP_PICTUREChanged();
                }
            }
        }

        [Column(Storage = "_WS_VERSION", DbType = "NVarChar(300)")]
        public string WS_VERSION
        {
            get
            {
                return this._WS_VERSION;
            }
            set
            {
                if ((this._WS_VERSION != value))
                {
                    this.OnWS_VERSIONChanging(value);
                    this.SendPropertyChanging();
                    this._WS_VERSION = value;
                    this.SendPropertyChanged("WS_VERSION");
                    this.OnWS_VERSIONChanged();
                }
            }
        }

        [Column(Storage = "_CREATED_BY", DbType = "Int")]
        public System.Nullable<int> CREATED_BY
        {
            get
            {
                return this._CREATED_BY;
            }
            set
            {
                if ((this._CREATED_BY != value))
                {
                    this.OnCREATED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._CREATED_BY = value;
                    this.SendPropertyChanged("CREATED_BY");
                    this.OnCREATED_BYChanged();
                }
            }
        }

        [Column(Storage = "_CREATED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CREATED_ON
        {
            get
            {
                return this._CREATED_ON;
            }
            set
            {
                if ((this._CREATED_ON != value))
                {
                    this.OnCREATED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._CREATED_ON = value;
                    this.SendPropertyChanged("CREATED_ON");
                    this.OnCREATED_ONChanged();
                }
            }
        }

        [Column(Storage = "_LAST_MODIFIED_BY", DbType = "Int")]
        public System.Nullable<int> LAST_MODIFIED_BY
        {
            get
            {
                return this._LAST_MODIFIED_BY;
            }
            set
            {
                if ((this._LAST_MODIFIED_BY != value))
                {
                    this.OnLAST_MODIFIED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._LAST_MODIFIED_BY = value;
                    this.SendPropertyChanged("LAST_MODIFIED_BY");
                    this.OnLAST_MODIFIED_BYChanged();
                }
            }
        }

        [Column(Storage = "_LAST_MODIFIED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LAST_MODIFIED_ON
        {
            get
            {
                return this._LAST_MODIFIED_ON;
            }
            set
            {
                if ((this._LAST_MODIFIED_ON != value))
                {
                    this.OnLAST_MODIFIED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._LAST_MODIFIED_ON = value;
                    this.SendPropertyChanged("LAST_MODIFIED_ON");
                    this.OnLAST_MODIFIED_ONChanged();
                }
            }
        }

        public Byte[] PICTURE_FORSAVE { get; set; }

        [Association(Name = "GBL_ENV_FIN_INVOICE", Storage = "_FIN_INVOICEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<FIN_INVOICE> FIN_INVOICEs
        {
            get
            {
                return this._FIN_INVOICEs;
            }
            set
            {
                this._FIN_INVOICEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_FIN_INVOICEDTL", Storage = "_FIN_INVOICEDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<FIN_INVOICEDTL> FIN_INVOICEDTLs
        {
            get
            {
                return this._FIN_INVOICEDTLs;
            }
            set
            {
                this._FIN_INVOICEDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_FIN_PAYMENT", Storage = "_FIN_PAYMENTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<FIN_PAYMENT> FIN_PAYMENTs
        {
            get
            {
                return this._FIN_PAYMENTs;
            }
            set
            {
                this._FIN_PAYMENTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_FIN_PAYMENTDTL", Storage = "_FIN_PAYMENTDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<FIN_PAYMENTDTL> FIN_PAYMENTDTLs
        {
            get
            {
                return this._FIN_PAYMENTDTLs;
            }
            set
            {
                this._FIN_PAYMENTDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_ALERT", Storage = "_GBL_ALERTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_ALERT> GBL_ALERTs
        {
            get
            {
                return this._GBL_ALERTs;
            }
            set
            {
                this._GBL_ALERTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_ALERTDTL", Storage = "_GBL_ALERTDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_ALERTDTL> GBL_ALERTDTLs
        {
            get
            {
                return this._GBL_ALERTDTLs;
            }
            set
            {
                this._GBL_ALERTDTLs.Assign(value);
            }
        }
        [Association(Name = "GBL_ENV_GBL_EMPSCHEDULECATEGORY", Storage = "_GBL_EMPSCHEDULECATEGORies", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_EMPSCHEDULECATEGORY> GBL_EMPSCHEDULECATEGORies
        {
            get
            {
                return this._GBL_EMPSCHEDULECATEGORies;
            }
            set
            {
                this._GBL_EMPSCHEDULECATEGORies.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_EXCEPTIONLOG", Storage = "_GBL_EXCEPTIONLOGs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_EXCEPTIONLOG> GBL_EXCEPTIONLOGs
        {
            get
            {
                return this._GBL_EXCEPTIONLOGs;
            }
            set
            {
                this._GBL_EXCEPTIONLOGs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_GENERAL", Storage = "_GBL_GENERALs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_GENERAL> GBL_GENERALs
        {
            get
            {
                return this._GBL_GENERALs;
            }
            set
            {
                this._GBL_GENERALs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_GENERALDTL", Storage = "_GBL_GENERALDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_GENERALDTL> GBL_GENERALDTLs
        {
            get
            {
                return this._GBL_GENERALDTLs;
            }
            set
            {
                this._GBL_GENERALDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_GRANTOBJECT", Storage = "_GBL_GRANTOBJECTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_GRANTOBJECT> GBL_GRANTOBJECTs
        {
            get
            {
                return this._GBL_GRANTOBJECTs;
            }
            set
            {
                this._GBL_GRANTOBJECTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_GRANTROLE", Storage = "_GBL_GRANTROLEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_GRANTROLE> GBL_GRANTROLEs
        {
            get
            {
                return this._GBL_GRANTROLEs;
            }
            set
            {
                this._GBL_GRANTROLEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_GROUP", Storage = "_GBL_GROUPs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_GROUP> GBL_GROUPs
        {
            get
            {
                return this._GBL_GROUPs;
            }
            set
            {
                this._GBL_GROUPs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_GROUPDTL", Storage = "_GBL_GROUPDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_GROUPDTL> GBL_GROUPDTLs
        {
            get
            {
                return this._GBL_GROUPDTLs;
            }
            set
            {
                this._GBL_GROUPDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_HOSPITAL", Storage = "_GBL_HOSPITALs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_HOSPITAL> GBL_HOSPITALs
        {
            get
            {
                return this._GBL_HOSPITALs;
            }
            set
            {
                this._GBL_HOSPITALs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_LANGUAGE", Storage = "_GBL_LANGUAGEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_LANGUAGE> GBL_LANGUAGEs
        {
            get
            {
                return this._GBL_LANGUAGEs;
            }
            set
            {
                this._GBL_LANGUAGEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_MENU", Storage = "_GBL_MENUs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_MENU> GBL_MENUs
        {
            get
            {
                return this._GBL_MENUs;
            }
            set
            {
                this._GBL_MENUs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_MYMENU", Storage = "_GBL_MYMENUs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_MYMENU> GBL_MYMENUs
        {
            get
            {
                return this._GBL_MYMENUs;
            }
            set
            {
                this._GBL_MYMENUs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_MYMENU1", Storage = "_GBL_MYMENUs1", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_MYMENU> GBL_MYMENUs1
        {
            get
            {
                return this._GBL_MYMENUs1;
            }
            set
            {
                this._GBL_MYMENUs1.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_MYMENU2", Storage = "_GBL_MYMENUs2", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_MYMENU> GBL_MYMENUs2
        {
            get
            {
                return this._GBL_MYMENUs2;
            }
            set
            {
                this._GBL_MYMENUs2.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_PRODUCT", Storage = "_GBL_PRODUCTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_PRODUCT> GBL_PRODUCTs
        {
            get
            {
                return this._GBL_PRODUCTs;
            }
            set
            {
                this._GBL_PRODUCTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_ROLE", Storage = "_GBL_ROLEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_ROLE> GBL_ROLEs
        {
            get
            {
                return this._GBL_ROLEs;
            }
            set
            {
                this._GBL_ROLEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_ROLEDTL", Storage = "_GBL_ROLEDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_ROLEDTL> GBL_ROLEDTLs
        {
            get
            {
                return this._GBL_ROLEDTLs;
            }
            set
            {
                this._GBL_ROLEDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_SEQUENCE", Storage = "_GBL_SEQUENCEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_SEQUENCE> GBL_SEQUENCEs
        {
            get
            {
                return this._GBL_SEQUENCEs;
            }
            set
            {
                this._GBL_SEQUENCEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_SESSION", Storage = "_GBL_SESSIONs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_SESSION> GBL_SESSIONs
        {
            get
            {
                return this._GBL_SESSIONs;
            }
            set
            {
                this._GBL_SESSIONs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_SESSIONLOG", Storage = "_GBL_SESSIONLOGs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_SESSIONLOG> GBL_SESSIONLOGs
        {
            get
            {
                return this._GBL_SESSIONLOGs;
            }
            set
            {
                this._GBL_SESSIONLOGs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_SUBMENU", Storage = "_GBL_SUBMENUs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_SUBMENU> GBL_SUBMENUs
        {
            get
            {
                return this._GBL_SUBMENUs;
            }
            set
            {
                this._GBL_SUBMENUs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_SUBMENUOBJECTLABEL", Storage = "_GBL_SUBMENUOBJECTLABELs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_SUBMENUOBJECTLABEL> GBL_SUBMENUOBJECTLABELs
        {
            get
            {
                return this._GBL_SUBMENUOBJECTLABELs;
            }
            set
            {
                this._GBL_SUBMENUOBJECTLABELs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_SUBMENUOBJECT", Storage = "_GBL_SUBMENUOBJECTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_SUBMENUOBJECT> GBL_SUBMENUOBJECTs
        {
            get
            {
                return this._GBL_SUBMENUOBJECTs;
            }
            set
            {
                this._GBL_SUBMENUOBJECTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_USERGROUP", Storage = "_GBL_USERGROUPs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_USERGROUP> GBL_USERGROUPs
        {
            get
            {
                return this._GBL_USERGROUPs;
            }
            set
            {
                this._GBL_USERGROUPs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_USERGROUPDTL", Storage = "_GBL_USERGROUPDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<GBL_USERGROUPDTL> GBL_USERGROUPDTLs
        {
            get
            {
                return this._GBL_USERGROUPDTLs;
            }
            set
            {
                this._GBL_USERGROUPDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_HR_EMP", Storage = "_HR_EMPs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<HR_EMP> HR_EMPs
        {
            get
            {
                return this._HR_EMPs;
            }
            set
            {
                this._HR_EMPs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_HR_ROOM", Storage = "_HR_ROOMs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<HR_ROOM> HR_ROOMs
        {
            get
            {
                return this._HR_ROOMs;
            }
            set
            {
                this._HR_ROOMs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_HR_UNIT", Storage = "_HR_UNITs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<HR_UNIT> HR_UNITs
        {
            get
            {
                return this._HR_UNITs;
            }
            set
            {
                this._HR_UNITs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_AUTHORISER", Storage = "_INV_AUTHORISERs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_AUTHORISER> INV_AUTHORISERs
        {
            get
            {
                return this._INV_AUTHORISERs;
            }
            set
            {
                this._INV_AUTHORISERs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_AUTHORIZATION", Storage = "_INV_AUTHORIZATIONs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_AUTHORIZATION> INV_AUTHORIZATIONs
        {
            get
            {
                return this._INV_AUTHORIZATIONs;
            }
            set
            {
                this._INV_AUTHORIZATIONs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_CATEGORY", Storage = "_INV_CATEGORies", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_CATEGORY> INV_CATEGORies
        {
            get
            {
                return this._INV_CATEGORies;
            }
            set
            {
                this._INV_CATEGORies.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_ITEM", Storage = "_INV_ITEMs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_ITEM> INV_ITEMs
        {
            get
            {
                return this._INV_ITEMs;
            }
            set
            {
                this._INV_ITEMs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_ITEMSTATUS", Storage = "_INV_ITEMSTATUS", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_ITEMSTATUS> INV_ITEMSTATUS
        {
            get
            {
                return this._INV_ITEMSTATUS;
            }
            set
            {
                this._INV_ITEMSTATUS.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_ITEMTYPE", Storage = "_INV_ITEMTYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_ITEMTYPE> INV_ITEMTYPEs
        {
            get
            {
                return this._INV_ITEMTYPEs;
            }
            set
            {
                this._INV_ITEMTYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_PO", Storage = "_INV_POs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_PO> INV_POs
        {
            get
            {
                return this._INV_POs;
            }
            set
            {
                this._INV_POs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_PODTL", Storage = "_INV_PODTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_PODTL> INV_PODTLs
        {
            get
            {
                return this._INV_PODTLs;
            }
            set
            {
                this._INV_PODTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_PR", Storage = "_INV_PRs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_PR> INV_PRs
        {
            get
            {
                return this._INV_PRs;
            }
            set
            {
                this._INV_PRs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_REQUISITION", Storage = "_INV_REQUISITIONs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_REQUISITION> INV_REQUISITIONs
        {
            get
            {
                return this._INV_REQUISITIONs;
            }
            set
            {
                this._INV_REQUISITIONs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_REQUISITIONDTL", Storage = "_INV_REQUISITIONDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_REQUISITIONDTL> INV_REQUISITIONDTLs
        {
            get
            {
                return this._INV_REQUISITIONDTLs;
            }
            set
            {
                this._INV_REQUISITIONDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_ROOMSTOCKREDUCE", Storage = "_INV_ROOMSTOCKREDUCEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_ROOMSTOCKREDUCE> INV_ROOMSTOCKREDUCEs
        {
            get
            {
                return this._INV_ROOMSTOCKREDUCEs;
            }
            set
            {
                this._INV_ROOMSTOCKREDUCEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_SETTING", Storage = "_INV_SETTINGs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_SETTING> INV_SETTINGs
        {
            get
            {
                return this._INV_SETTINGs;
            }
            set
            {
                this._INV_SETTINGs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_TXNUNIT", Storage = "_INV_TXNUNITs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_TXNUNIT> INV_TXNUNITs
        {
            get
            {
                return this._INV_TXNUNITs;
            }
            set
            {
                this._INV_TXNUNITs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_UNIT", Storage = "_INV_UNITs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_UNIT> INV_UNITs
        {
            get
            {
                return this._INV_UNITs;
            }
            set
            {
                this._INV_UNITs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_UNITREORDERLEVEL", Storage = "_INV_UNITREORDERLEVELs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_UNITREORDERLEVEL> INV_UNITREORDERLEVELs
        {
            get
            {
                return this._INV_UNITREORDERLEVELs;
            }
            set
            {
                this._INV_UNITREORDERLEVELs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_VENDOR", Storage = "_INV_VENDORs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<INV_VENDOR> INV_VENDORs
        {
            get
            {
                return this._INV_VENDORs;
            }
            set
            {
                this._INV_VENDORs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_MIS_ASESSMENTTYPE", Storage = "_MIS_ASESSMENTTYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<MIS_ASESSMENTTYPE> MIS_ASESSMENTTYPEs
        {
            get
            {
                return this._MIS_ASESSMENTTYPEs;
            }
            set
            {
                this._MIS_ASESSMENTTYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_MIS_BIOPSYRESULT", Storage = "_MIS_BIOPSYRESULTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<MIS_BIOPSYRESULT> MIS_BIOPSYRESULTs
        {
            get
            {
                return this._MIS_BIOPSYRESULTs;
            }
            set
            {
                this._MIS_BIOPSYRESULTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_MIS_LESIONTYPE", Storage = "_MIS_LESIONTYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<MIS_LESIONTYPE> MIS_LESIONTYPEs
        {
            get
            {
                return this._MIS_LESIONTYPEs;
            }
            set
            {
                this._MIS_LESIONTYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_MIS_TECHNIQUETYPE", Storage = "_MIS_TECHNIQUETYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<MIS_TECHNIQUETYPE> MIS_TECHNIQUETYPEs
        {
            get
            {
                return this._MIS_TECHNIQUETYPEs;
            }
            set
            {
                this._MIS_TECHNIQUETYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_ACR", Storage = "_RIS_ACRs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_ACR> RIS_ACRs
        {
            get
            {
                return this._RIS_ACRs;
            }
            set
            {
                this._RIS_ACRs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_ASSESSMENT", Storage = "_RIS_ASSESSMENTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_ASSESSMENT> RIS_ASSESSMENTs
        {
            get
            {
                return this._RIS_ASSESSMENTs;
            }
            set
            {
                this._RIS_ASSESSMENTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_BILL", Storage = "_RIS_BILLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_BILL> RIS_BILLs
        {
            get
            {
                return this._RIS_BILLs;
            }
            set
            {
                this._RIS_BILLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_BODYPART", Storage = "_RIS_BODYPARTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_BODYPART> RIS_BODYPARTs
        {
            get
            {
                return this._RIS_BODYPARTs;
            }
            set
            {
                this._RIS_BODYPARTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_BPVIEW", Storage = "_RIS_BPVIEWs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_BPVIEW> RIS_BPVIEWs
        {
            get
            {
                return this._RIS_BPVIEWs;
            }
            set
            {
                this._RIS_BPVIEWs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_CLINICSESSION", Storage = "_RIS_CLINICSESSIONs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_CLINICSESSION> RIS_CLINICSESSIONs
        {
            get
            {
                return this._RIS_CLINICSESSIONs;
            }
            set
            {
                this._RIS_CLINICSESSIONs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_CLINICTYPE", Storage = "_RIS_CLINICTYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_CLINICTYPE> RIS_CLINICTYPEs
        {
            get
            {
                return this._RIS_CLINICTYPEs;
            }
            set
            {
                this._RIS_CLINICTYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_CONFLICTEXAMDTL", Storage = "_RIS_CONFLICTEXAMDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_CONFLICTEXAMDTL> RIS_CONFLICTEXAMDTLs
        {
            get
            {
                return this._RIS_CONFLICTEXAMDTLs;
            }
            set
            {
                this._RIS_CONFLICTEXAMDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_CONFLICTEXAMGROUP", Storage = "_RIS_CONFLICTEXAMGROUPs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_CONFLICTEXAMGROUP> RIS_CONFLICTEXAMGROUPs
        {
            get
            {
                return this._RIS_CONFLICTEXAMGROUPs;
            }
            set
            {
                this._RIS_CONFLICTEXAMGROUPs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_CONSUMABLETYPE", Storage = "_RIS_CONSUMABLETYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_CONSUMABLETYPE> RIS_CONSUMABLETYPEs
        {
            get
            {
                return this._RIS_CONSUMABLETYPEs;
            }
            set
            {
                this._RIS_CONSUMABLETYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMINSTRUCTION", Storage = "_RIS_EXAMINSTRUCTIONs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_EXAMINSTRUCTION> RIS_EXAMINSTRUCTIONs
        {
            get
            {
                return this._RIS_EXAMINSTRUCTIONs;
            }
            set
            {
                this._RIS_EXAMINSTRUCTIONs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULT", Storage = "_RIS_EXAMRESULTs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_EXAMRESULT> RIS_EXAMRESULTs
        {
            get
            {
                return this._RIS_EXAMRESULTs;
            }
            set
            {
                this._RIS_EXAMRESULTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULTACCESS", Storage = "_RIS_EXAMRESULTACCESSes", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_EXAMRESULTACCESS> RIS_EXAMRESULTACCESSes
        {
            get
            {
                return this._RIS_EXAMRESULTACCESSes;
            }
            set
            {
                this._RIS_EXAMRESULTACCESSes.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULTNOTE", Storage = "_RIS_EXAMRESULTNOTEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_EXAMRESULTNOTE> RIS_EXAMRESULTNOTEs
        {
            get
            {
                return this._RIS_EXAMRESULTNOTEs;
            }
            set
            {
                this._RIS_EXAMRESULTNOTEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULTSEVERITY", Storage = "_RIS_EXAMRESULTSEVERITies", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_EXAMRESULTSEVERITY> RIS_EXAMRESULTSEVERITies
        {
            get
            {
                return this._RIS_EXAMRESULTSEVERITies;
            }
            set
            {
                this._RIS_EXAMRESULTSEVERITies.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULTTEMPLATE", Storage = "_RIS_EXAMRESULTTEMPLATEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_EXAMRESULTTEMPLATE> RIS_EXAMRESULTTEMPLATEs
        {
            get
            {
                return this._RIS_EXAMRESULTTEMPLATEs;
            }
            set
            {
                this._RIS_EXAMRESULTTEMPLATEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMTEMPLATESHARE", Storage = "_RIS_EXAMTEMPLATESHAREs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_EXAMTEMPLATESHARE> RIS_EXAMTEMPLATESHAREs
        {
            get
            {
                return this._RIS_EXAMTEMPLATESHAREs;
            }
            set
            {
                this._RIS_EXAMTEMPLATESHAREs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMTYPE", Storage = "_RIS_EXAMTYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_EXAMTYPE> RIS_EXAMTYPEs
        {
            get
            {
                return this._RIS_EXAMTYPEs;
            }
            set
            {
                this._RIS_EXAMTYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_HOSPITAL_MAP_DOCTOR", Storage = "_RIS_HOSPITAL_MAP_DOCTORs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_HOSPITAL_MAP_DOCTOR> RIS_HOSPITAL_MAP_DOCTORs
        {
            get
            {
                return this._RIS_HOSPITAL_MAP_DOCTORs;
            }
            set
            {
                this._RIS_HOSPITAL_MAP_DOCTORs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_MODALITY", Storage = "_RIS_MODALITies", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_MODALITY> RIS_MODALITies
        {
            get
            {
                return this._RIS_MODALITies;
            }
            set
            {
                this._RIS_MODALITies.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_MODALITYEXAM", Storage = "_RIS_MODALITYEXAMs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_MODALITYEXAM> RIS_MODALITYEXAMs
        {
            get
            {
                return this._RIS_MODALITYEXAMs;
            }
            set
            {
                this._RIS_MODALITYEXAMs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_MODALITYTYPE", Storage = "_RIS_MODALITYTYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_MODALITYTYPE> RIS_MODALITYTYPEs
        {
            get
            {
                return this._RIS_MODALITYTYPEs;
            }
            set
            {
                this._RIS_MODALITYTYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_ORDER", Storage = "_RIS_ORDERs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_ORDER> RIS_ORDERs
        {
            get
            {
                return this._RIS_ORDERs;
            }
            set
            {
                this._RIS_ORDERs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_ORDERDTL", Storage = "_RIS_ORDERDTLs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_ORDERDTL> RIS_ORDERDTLs
        {
            get
            {
                return this._RIS_ORDERDTLs;
            }
            set
            {
                this._RIS_ORDERDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_ORDERIMAGE", Storage = "_RIS_ORDERIMAGEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_ORDERIMAGE> RIS_ORDERIMAGEs
        {
            get
            {
                return this._RIS_ORDERIMAGEs;
            }
            set
            {
                this._RIS_ORDERIMAGEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_PATICD", Storage = "_RIS_PATICDs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_PATICD> RIS_PATICDs
        {
            get
            {
                return this._RIS_PATICDs;
            }
            set
            {
                this._RIS_PATICDs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_PATSTATUS", Storage = "_RIS_PATSTATUS", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_PATSTATUS> RIS_PATSTATUS
        {
            get
            {
                return this._RIS_PATSTATUS;
            }
            set
            {
                this._RIS_PATSTATUS.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_PATSTATUS1", Storage = "_RIS_PATSTATUS1", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_PATSTATUS> RIS_PATSTATUS1
        {
            get
            {
                return this._RIS_PATSTATUS1;
            }
            set
            {
                this._RIS_PATSTATUS1.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_QAWORK", Storage = "_RIS_QAWORKs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_QAWORK> RIS_QAWORKs
        {
            get
            {
                return this._RIS_QAWORKs;
            }
            set
            {
                this._RIS_QAWORKs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_QUESTION", Storage = "_RIS_QUESTIONs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_QUESTION> RIS_QUESTIONs
        {
            get
            {
                return this._RIS_QUESTIONs;
            }
            set
            {
                this._RIS_QUESTIONs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_RADSTUDYGROUP", Storage = "_RIS_RADSTUDYGROUPs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_RADSTUDYGROUP> RIS_RADSTUDYGROUPs
        {
            get
            {
                return this._RIS_RADSTUDYGROUPs;
            }
            set
            {
                this._RIS_RADSTUDYGROUPs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_RESULTSTATUSCHANGELOG", Storage = "_RIS_RESULTSTATUSCHANGELOGs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_RESULTSTATUSCHANGELOG> RIS_RESULTSTATUSCHANGELOGs
        {
            get
            {
                return this._RIS_RESULTSTATUSCHANGELOGs;
            }
            set
            {
                this._RIS_RESULTSTATUSCHANGELOGs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_SCHEDULE", Storage = "_RIS_SCHEDULEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_SCHEDULE> RIS_SCHEDULEs
        {
            get
            {
                return this._RIS_SCHEDULEs;
            }
            set
            {
                this._RIS_SCHEDULEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_SERVICETYPE", Storage = "_RIS_SERVICETYPEs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_SERVICETYPE> RIS_SERVICETYPEs
        {
            get
            {
                return this._RIS_SERVICETYPEs;
            }
            set
            {
                this._RIS_SERVICETYPEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_SESSIONMAXAPP", Storage = "_RIS_SESSIONMAXAPPs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_SESSIONMAXAPP> RIS_SESSIONMAXAPPs
        {
            get
            {
                return this._RIS_SESSIONMAXAPPs;
            }
            set
            {
                this._RIS_SESSIONMAXAPPs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_TECHCONSUMPTION", Storage = "_RIS_TECHCONSUMPTIONs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_TECHCONSUMPTION> RIS_TECHCONSUMPTIONs
        {
            get
            {
                return this._RIS_TECHCONSUMPTIONs;
            }
            set
            {
                this._RIS_TECHCONSUMPTIONs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_TECHWORK", Storage = "_RIS_TECHWORKs", ThisKey = "ORG_ID", OtherKey = "ORG_ID")]
        public EntitySet<RIS_TECHWORK> RIS_TECHWORKs
        {
            get
            {
                return this._RIS_TECHWORKs;
            }
            set
            {
                this._RIS_TECHWORKs.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_FIN_INVOICEs(FIN_INVOICE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_FIN_INVOICEs(FIN_INVOICE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_FIN_INVOICEDTLs(FIN_INVOICEDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_FIN_INVOICEDTLs(FIN_INVOICEDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_FIN_PAYMENTs(FIN_PAYMENT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_FIN_PAYMENTs(FIN_PAYMENT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_FIN_PAYMENTDTLs(FIN_PAYMENTDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_FIN_PAYMENTDTLs(FIN_PAYMENTDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_ALERTs(GBL_ALERT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_ALERTs(GBL_ALERT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_ALERTDTLs(GBL_ALERTDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_ALERTDTLs(GBL_ALERTDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        //private void attach_GBL_EMPSCHEDULEs(GBL_EMPSCHEDULE entity)
        //{
        //    this.SendPropertyChanging();
        //    entity.GBL_ENV = this;
        //}
        //private void detach_GBL_EMPSCHEDULEs(GBL_EMPSCHEDULE entity)
        //{
        //    this.SendPropertyChanging();
        //    entity.GBL_ENV = null;
        //}

        private void attach_GBL_EMPSCHEDULECATEGORies(GBL_EMPSCHEDULECATEGORY entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_EMPSCHEDULECATEGORies(GBL_EMPSCHEDULECATEGORY entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_EXCEPTIONLOGs(GBL_EXCEPTIONLOG entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_EXCEPTIONLOGs(GBL_EXCEPTIONLOG entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_GENERALs(GBL_GENERAL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_GENERALs(GBL_GENERAL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_GENERALDTLs(GBL_GENERALDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_GENERALDTLs(GBL_GENERALDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_GRANTOBJECTs(GBL_GRANTOBJECT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_GRANTOBJECTs(GBL_GRANTOBJECT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_GRANTROLEs(GBL_GRANTROLE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_GRANTROLEs(GBL_GRANTROLE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_GROUPs(GBL_GROUP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_GROUPs(GBL_GROUP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_GROUPDTLs(GBL_GROUPDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_GROUPDTLs(GBL_GROUPDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_HOSPITALs(GBL_HOSPITAL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_HOSPITALs(GBL_HOSPITAL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_LANGUAGEs(GBL_LANGUAGE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_LANGUAGEs(GBL_LANGUAGE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_MENUs(GBL_MENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_MENUs(GBL_MENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_MYMENUs(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_MYMENUs(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_MYMENUs1(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV1 = this;
        }

        private void detach_GBL_MYMENUs1(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV1 = null;
        }

        private void attach_GBL_MYMENUs2(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV2 = this;
        }

        private void detach_GBL_MYMENUs2(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV2 = null;
        }

        private void attach_GBL_PRODUCTs(GBL_PRODUCT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_PRODUCTs(GBL_PRODUCT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_ROLEs(GBL_ROLE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_ROLEs(GBL_ROLE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_ROLEDTLs(GBL_ROLEDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_ROLEDTLs(GBL_ROLEDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_SEQUENCEs(GBL_SEQUENCE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_SEQUENCEs(GBL_SEQUENCE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_SESSIONs(GBL_SESSION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_SESSIONs(GBL_SESSION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_SESSIONLOGs(GBL_SESSIONLOG entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_SESSIONLOGs(GBL_SESSIONLOG entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_SUBMENUs(GBL_SUBMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_SUBMENUs(GBL_SUBMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_SUBMENUOBJECTLABELs(GBL_SUBMENUOBJECTLABEL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_SUBMENUOBJECTLABELs(GBL_SUBMENUOBJECTLABEL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_SUBMENUOBJECTs(GBL_SUBMENUOBJECT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_SUBMENUOBJECTs(GBL_SUBMENUOBJECT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_USERGROUPs(GBL_USERGROUP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_USERGROUPs(GBL_USERGROUP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_GBL_USERGROUPDTLs(GBL_USERGROUPDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_GBL_USERGROUPDTLs(GBL_USERGROUPDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_HR_EMPs(HR_EMP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_HR_EMPs(HR_EMP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_HR_ROOMs(HR_ROOM entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_HR_ROOMs(HR_ROOM entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_HR_UNITs(HR_UNIT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_HR_UNITs(HR_UNIT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_AUTHORISERs(INV_AUTHORISER entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_AUTHORISERs(INV_AUTHORISER entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_AUTHORIZATIONs(INV_AUTHORIZATION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_AUTHORIZATIONs(INV_AUTHORIZATION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_CATEGORies(INV_CATEGORY entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_CATEGORies(INV_CATEGORY entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_ITEMs(INV_ITEM entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_ITEMs(INV_ITEM entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_ITEMSTATUS(INV_ITEMSTATUS entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_ITEMSTATUS(INV_ITEMSTATUS entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_ITEMTYPEs(INV_ITEMTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_ITEMTYPEs(INV_ITEMTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_POs(INV_PO entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_POs(INV_PO entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_PODTLs(INV_PODTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_PODTLs(INV_PODTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_PRs(INV_PR entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_PRs(INV_PR entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_REQUISITIONs(INV_REQUISITION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_REQUISITIONs(INV_REQUISITION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_REQUISITIONDTLs(INV_REQUISITIONDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_REQUISITIONDTLs(INV_REQUISITIONDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_ROOMSTOCKREDUCEs(INV_ROOMSTOCKREDUCE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_ROOMSTOCKREDUCEs(INV_ROOMSTOCKREDUCE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_SETTINGs(INV_SETTING entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_SETTINGs(INV_SETTING entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_TXNUNITs(INV_TXNUNIT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_TXNUNITs(INV_TXNUNIT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_UNITs(INV_UNIT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_UNITs(INV_UNIT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_UNITREORDERLEVELs(INV_UNITREORDERLEVEL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_UNITREORDERLEVELs(INV_UNITREORDERLEVEL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_INV_VENDORs(INV_VENDOR entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_INV_VENDORs(INV_VENDOR entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_MIS_ASESSMENTTYPEs(MIS_ASESSMENTTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_MIS_ASESSMENTTYPEs(MIS_ASESSMENTTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_MIS_BIOPSYRESULTs(MIS_BIOPSYRESULT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_MIS_BIOPSYRESULTs(MIS_BIOPSYRESULT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_MIS_LESIONTYPEs(MIS_LESIONTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_MIS_LESIONTYPEs(MIS_LESIONTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_MIS_TECHNIQUETYPEs(MIS_TECHNIQUETYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_MIS_TECHNIQUETYPEs(MIS_TECHNIQUETYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_ACRs(RIS_ACR entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_ACRs(RIS_ACR entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_ASSESSMENTs(RIS_ASSESSMENT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_ASSESSMENTs(RIS_ASSESSMENT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_BILLs(RIS_BILL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_BILLs(RIS_BILL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_BODYPARTs(RIS_BODYPART entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_BODYPARTs(RIS_BODYPART entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_BPVIEWs(RIS_BPVIEW entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_BPVIEWs(RIS_BPVIEW entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_CLINICSESSIONs(RIS_CLINICSESSION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_CLINICSESSIONs(RIS_CLINICSESSION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_CLINICTYPEs(RIS_CLINICTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_CLINICTYPEs(RIS_CLINICTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_CONFLICTEXAMDTLs(RIS_CONFLICTEXAMDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_CONFLICTEXAMDTLs(RIS_CONFLICTEXAMDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_CONFLICTEXAMGROUPs(RIS_CONFLICTEXAMGROUP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_CONFLICTEXAMGROUPs(RIS_CONFLICTEXAMGROUP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_CONSUMABLETYPEs(RIS_CONSUMABLETYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_CONSUMABLETYPEs(RIS_CONSUMABLETYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_EXAMINSTRUCTIONs(RIS_EXAMINSTRUCTION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_EXAMINSTRUCTIONs(RIS_EXAMINSTRUCTION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_EXAMRESULTs(RIS_EXAMRESULT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_EXAMRESULTs(RIS_EXAMRESULT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_EXAMRESULTACCESSes(RIS_EXAMRESULTACCESS entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_EXAMRESULTACCESSes(RIS_EXAMRESULTACCESS entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_EXAMRESULTNOTEs(RIS_EXAMRESULTNOTE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_EXAMRESULTNOTEs(RIS_EXAMRESULTNOTE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_EXAMRESULTSEVERITies(RIS_EXAMRESULTSEVERITY entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_EXAMRESULTSEVERITies(RIS_EXAMRESULTSEVERITY entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_EXAMRESULTTEMPLATEs(RIS_EXAMRESULTTEMPLATE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_EXAMRESULTTEMPLATEs(RIS_EXAMRESULTTEMPLATE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_EXAMTEMPLATESHAREs(RIS_EXAMTEMPLATESHARE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_EXAMTEMPLATESHAREs(RIS_EXAMTEMPLATESHARE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_EXAMTYPEs(RIS_EXAMTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_EXAMTYPEs(RIS_EXAMTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_HOSPITAL_MAP_DOCTORs(RIS_HOSPITAL_MAP_DOCTOR entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_HOSPITAL_MAP_DOCTORs(RIS_HOSPITAL_MAP_DOCTOR entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_MODALITies(RIS_MODALITY entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_MODALITies(RIS_MODALITY entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_MODALITYEXAMs(RIS_MODALITYEXAM entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_MODALITYEXAMs(RIS_MODALITYEXAM entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_MODALITYTYPEs(RIS_MODALITYTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_MODALITYTYPEs(RIS_MODALITYTYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_ORDERDTLs(RIS_ORDERDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_ORDERDTLs(RIS_ORDERDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_ORDERIMAGEs(RIS_ORDERIMAGE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_ORDERIMAGEs(RIS_ORDERIMAGE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_PATICDs(RIS_PATICD entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_PATICDs(RIS_PATICD entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_PATSTATUS(RIS_PATSTATUS entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_PATSTATUS(RIS_PATSTATUS entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_PATSTATUS1(RIS_PATSTATUS entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV1 = this;
        }

        private void detach_RIS_PATSTATUS1(RIS_PATSTATUS entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV1 = null;
        }

        private void attach_RIS_QAWORKs(RIS_QAWORK entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_QAWORKs(RIS_QAWORK entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_QUESTIONs(RIS_QUESTION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_QUESTIONs(RIS_QUESTION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_RADSTUDYGROUPs(RIS_RADSTUDYGROUP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_RADSTUDYGROUPs(RIS_RADSTUDYGROUP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_RESULTSTATUSCHANGELOGs(RIS_RESULTSTATUSCHANGELOG entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_RESULTSTATUSCHANGELOGs(RIS_RESULTSTATUSCHANGELOG entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_SCHEDULEs(RIS_SCHEDULE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_SCHEDULEs(RIS_SCHEDULE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_SERVICETYPEs(RIS_SERVICETYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_SERVICETYPEs(RIS_SERVICETYPE entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_SESSIONMAXAPPs(RIS_SESSIONMAXAPP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_SESSIONMAXAPPs(RIS_SESSIONMAXAPP entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_TECHCONSUMPTIONs(RIS_TECHCONSUMPTION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_TECHCONSUMPTIONs(RIS_TECHCONSUMPTION entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }

        private void attach_RIS_TECHWORKs(RIS_TECHWORK entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = this;
        }

        private void detach_RIS_TECHWORKs(RIS_TECHWORK entity)
        {
            this.SendPropertyChanging();
            entity.GBL_ENV = null;
        }
    }
}
