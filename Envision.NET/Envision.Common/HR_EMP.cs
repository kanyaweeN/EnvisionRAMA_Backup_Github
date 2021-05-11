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
    [Table(Name = "dbo.HR_EMP")]
    public partial class HR_EMP : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _EMP_ID;

        private string _EMP_UID;

        private string _USER_NAME;

        private string _SECURITY_QUESTION;

        private string _SECURITY_ANSWER;

        private string _PWD;

        private System.Nullable<int> _UNIT_ID;

        private System.Nullable<int> _JOBTITLE_ID;

        private System.Nullable<char> _JOB_TYPE;

        private System.Nullable<char> _IS_RADIOLOGIST;

        private string _SALUTATION;

        private string _FNAME;

        private string _MNAME;

        private string _LNAME;

        private string _TITLE_ENG;

        private string _FNAME_ENG;

        private string _MNAME_ENG;

        private string _LNAME_ENG;

        private System.Nullable<char> _GENDER;

        private string _EMAIL_PERSONAL;

        private string _EMAIL_OFFICIAL;

        private string _PHONE_HOME;

        private string _PHONE_MOBILE;

        private string _PHONE_OFFICE;

        private System.Nullable<char> _PREFERRED_PHONE;

        private System.Nullable<int> _PABX_EXT;

        private string _FAX_NO;

        private System.Nullable<System.DateTime> _DOB;

        private string _BLOOD_GROUP;

        private System.Nullable<int> _DEFAULT_LANG;

        private System.Nullable<int> _RELIGION;

        private string _PE_ADDR1;

        private string _PE_ADDR2;

        private string _PE_ADDR3;

        private string _PE_ADDR4;

        private System.Nullable<int> _AUTH_LEVEL_ID;

        private System.Nullable<int> _REPORTING_TO;

        private System.Nullable<char> _ALLOW_OTHERS_TO_FINALIZE;

        private System.Nullable<System.DateTime> _LAST_PWD_MODIFIED;

        private System.Nullable<System.DateTime> _LAST_LOGIN;

        private string _CARD_NO;

        private string _PLACE_OF_BIRTH;

        private string _NATIONALITY;

        private System.Nullable<char> _M_STATUS;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<char> _SUPPORT_USER;

        private System.Nullable<char> _CAN_KILL_SESSION;

        private System.Nullable<int> _DEFAULT_SHIFT_NO;

        private string _IMG_FILE_NAME;

        private string _EMP_REPORT_FOOTER1;

        private string _EMP_REPORT_FOOTER2;

        private System.Data.Linq.Binary _ALLPROPERTIES;

        private System.Nullable<bool> _VISIBLE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;


        private EntitySet<GBL_GRANTOBJECT> _GBL_GRANTOBJECTs;

        private EntitySet<GBL_GRANTROLE> _GBL_GRANTROLEs;

        private EntitySet<GBL_GROUP> _GBL_GROUPs;

        private EntitySet<GBL_GROUPDTL> _GBL_GROUPDTLs;

        private EntitySet<GBL_MYMENU> _GBL_MYMENUs;

        private EntitySet<GBL_MYMENU> _GBL_MYMENUs1;

        private EntityRef<GBL_RADEXPERIENCE> _GBL_RADEXPERIENCE;

        private EntitySet<GBL_SESSION> _GBL_SESSIONs;

        private EntitySet<GBL_USERGROUP> _GBL_USERGROUPs;

        private EntitySet<GBL_USERGROUPDTL> _GBL_USERGROUPDTLs;

        private EntitySet<INV_AUTHORISER> _INV_AUTHORISERs;

        private EntitySet<INV_AUTHORIZATION> _INV_AUTHORIZATIONs;

        private EntitySet<INV_REQUISITION> _INV_REQUISITIONs;

        private EntitySet<MIS_BIOPSYRESULT> _MIS_BIOPSYRESULTs;

        private EntitySet<RIS_EXAMRESULT> _RIS_EXAMRESULTs;

        private EntitySet<RIS_EXAMRESULT> _RIS_EXAMRESULTs1;

        private EntitySet<RIS_EXAMRESULTACCESS> _RIS_EXAMRESULTACCESSes;

        private EntitySet<RIS_EXAMRESULTNOTE> _RIS_EXAMRESULTNOTEs;

        private EntitySet<RIS_EXAMTEMPLATESHARE> _RIS_EXAMTEMPLATESHAREs;

        private EntitySet<RIS_NURSESDATA> _RIS_NURSESDATAs;

        private EntitySet<RIS_ORDER> _RIS_ORDERs;

        private EntitySet<RIS_RADSTUDYGROUP> _RIS_RADSTUDYGROUPs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_JOBTITLE> _HR_JOBTITLE;

        private EntityRef<RIS_AUTHLEVEL> _RIS_AUTHLEVEL;

        private EntityRef<RIS_AUTHLEVEL> _RIS_AUTHLEVEL1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnEMP_IDChanging(int value);
        partial void OnEMP_IDChanged();
        partial void OnEMP_UIDChanging(string value);
        partial void OnEMP_UIDChanged();
        partial void OnUSER_NAMEChanging(string value);
        partial void OnUSER_NAMEChanged();
        partial void OnSECURITY_QUESTIONChanging(string value);
        partial void OnSECURITY_QUESTIONChanged();
        partial void OnSECURITY_ANSWERChanging(string value);
        partial void OnSECURITY_ANSWERChanged();
        partial void OnPWDChanging(string value);
        partial void OnPWDChanged();
        partial void OnUNIT_IDChanging(System.Nullable<int> value);
        partial void OnUNIT_IDChanged();
        partial void OnJOBTITLE_IDChanging(System.Nullable<int> value);
        partial void OnJOBTITLE_IDChanged();
        partial void OnJOB_TYPEChanging(System.Nullable<char> value);
        partial void OnJOB_TYPEChanged();
        partial void OnIS_RADIOLOGISTChanging(System.Nullable<char> value);
        partial void OnIS_RADIOLOGISTChanged();
        partial void OnSALUTATIONChanging(string value);
        partial void OnSALUTATIONChanged();
        partial void OnFNAMEChanging(string value);
        partial void OnFNAMEChanged();
        partial void OnMNAMEChanging(string value);
        partial void OnMNAMEChanged();
        partial void OnLNAMEChanging(string value);
        partial void OnLNAMEChanged();
        partial void OnTITLE_ENGChanging(string value);
        partial void OnTITLE_ENGChanged();
        partial void OnFNAME_ENGChanging(string value);
        partial void OnFNAME_ENGChanged();
        partial void OnMNAME_ENGChanging(string value);
        partial void OnMNAME_ENGChanged();
        partial void OnLNAME_ENGChanging(string value);
        partial void OnLNAME_ENGChanged();
        partial void OnGENDERChanging(System.Nullable<char> value);
        partial void OnGENDERChanged();
        partial void OnEMAIL_PERSONALChanging(string value);
        partial void OnEMAIL_PERSONALChanged();
        partial void OnEMAIL_OFFICIALChanging(string value);
        partial void OnEMAIL_OFFICIALChanged();
        partial void OnPHONE_HOMEChanging(string value);
        partial void OnPHONE_HOMEChanged();
        partial void OnPHONE_MOBILEChanging(string value);
        partial void OnPHONE_MOBILEChanged();
        partial void OnPHONE_OFFICEChanging(string value);
        partial void OnPHONE_OFFICEChanged();
        partial void OnPREFERRED_PHONEChanging(System.Nullable<char> value);
        partial void OnPREFERRED_PHONEChanged();
        partial void OnPABX_EXTChanging(System.Nullable<int> value);
        partial void OnPABX_EXTChanged();
        partial void OnFAX_NOChanging(string value);
        partial void OnFAX_NOChanged();
        partial void OnDOBChanging(System.Nullable<System.DateTime> value);
        partial void OnDOBChanged();
        partial void OnBLOOD_GROUPChanging(string value);
        partial void OnBLOOD_GROUPChanged();
        partial void OnDEFAULT_LANGChanging(System.Nullable<int> value);
        partial void OnDEFAULT_LANGChanged();
        partial void OnRELIGIONChanging(System.Nullable<int> value);
        partial void OnRELIGIONChanged();
        partial void OnPE_ADDR1Changing(string value);
        partial void OnPE_ADDR1Changed();
        partial void OnPE_ADDR2Changing(string value);
        partial void OnPE_ADDR2Changed();
        partial void OnPE_ADDR3Changing(string value);
        partial void OnPE_ADDR3Changed();
        partial void OnPE_ADDR4Changing(string value);
        partial void OnPE_ADDR4Changed();
        partial void OnAUTH_LEVEL_IDChanging(System.Nullable<int> value);
        partial void OnAUTH_LEVEL_IDChanged();
        partial void OnREPORTING_TOChanging(System.Nullable<int> value);
        partial void OnREPORTING_TOChanged();
        partial void OnALLOW_OTHERS_TO_FINALIZEChanging(System.Nullable<char> value);
        partial void OnALLOW_OTHERS_TO_FINALIZEChanged();
        partial void OnLAST_PWD_MODIFIEDChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_PWD_MODIFIEDChanged();
        partial void OnLAST_LOGINChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_LOGINChanged();
        partial void OnCARD_NOChanging(string value);
        partial void OnCARD_NOChanged();
        partial void OnPLACE_OF_BIRTHChanging(string value);
        partial void OnPLACE_OF_BIRTHChanged();
        partial void OnNATIONALITYChanging(string value);
        partial void OnNATIONALITYChanged();
        partial void OnM_STATUSChanging(System.Nullable<char> value);
        partial void OnM_STATUSChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
        partial void OnSUPPORT_USERChanging(System.Nullable<char> value);
        partial void OnSUPPORT_USERChanged();
        partial void OnCAN_KILL_SESSIONChanging(System.Nullable<char> value);
        partial void OnCAN_KILL_SESSIONChanged();
        partial void OnDEFAULT_SHIFT_NOChanging(System.Nullable<int> value);
        partial void OnDEFAULT_SHIFT_NOChanged();
        partial void OnIMG_FILE_NAMEChanging(string value);
        partial void OnIMG_FILE_NAMEChanged();
        partial void OnEMP_REPORT_FOOTER1Changing(string value);
        partial void OnEMP_REPORT_FOOTER1Changed();
        partial void OnEMP_REPORT_FOOTER2Changing(string value);
        partial void OnEMP_REPORT_FOOTER2Changed();
        partial void OnALLPROPERTIESChanging(System.Data.Linq.Binary value);
        partial void OnALLPROPERTIESChanged();
        partial void OnVISIBLEChanging(System.Nullable<bool> value);
        partial void OnVISIBLEChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public HR_EMP()
        {
            this._GBL_GRANTOBJECTs = new EntitySet<GBL_GRANTOBJECT>(new Action<GBL_GRANTOBJECT>(this.attach_GBL_GRANTOBJECTs), new Action<GBL_GRANTOBJECT>(this.detach_GBL_GRANTOBJECTs));
            this._GBL_GRANTROLEs = new EntitySet<GBL_GRANTROLE>(new Action<GBL_GRANTROLE>(this.attach_GBL_GRANTROLEs), new Action<GBL_GRANTROLE>(this.detach_GBL_GRANTROLEs));
            this._GBL_GROUPs = new EntitySet<GBL_GROUP>(new Action<GBL_GROUP>(this.attach_GBL_GROUPs), new Action<GBL_GROUP>(this.detach_GBL_GROUPs));
            this._GBL_GROUPDTLs = new EntitySet<GBL_GROUPDTL>(new Action<GBL_GROUPDTL>(this.attach_GBL_GROUPDTLs), new Action<GBL_GROUPDTL>(this.detach_GBL_GROUPDTLs));
            this._GBL_MYMENUs = new EntitySet<GBL_MYMENU>(new Action<GBL_MYMENU>(this.attach_GBL_MYMENUs), new Action<GBL_MYMENU>(this.detach_GBL_MYMENUs));
            this._GBL_MYMENUs1 = new EntitySet<GBL_MYMENU>(new Action<GBL_MYMENU>(this.attach_GBL_MYMENUs1), new Action<GBL_MYMENU>(this.detach_GBL_MYMENUs1));
            this._GBL_RADEXPERIENCE = default(EntityRef<GBL_RADEXPERIENCE>);
            this._GBL_SESSIONs = new EntitySet<GBL_SESSION>(new Action<GBL_SESSION>(this.attach_GBL_SESSIONs), new Action<GBL_SESSION>(this.detach_GBL_SESSIONs));
            this._GBL_USERGROUPs = new EntitySet<GBL_USERGROUP>(new Action<GBL_USERGROUP>(this.attach_GBL_USERGROUPs), new Action<GBL_USERGROUP>(this.detach_GBL_USERGROUPs));
            this._GBL_USERGROUPDTLs = new EntitySet<GBL_USERGROUPDTL>(new Action<GBL_USERGROUPDTL>(this.attach_GBL_USERGROUPDTLs), new Action<GBL_USERGROUPDTL>(this.detach_GBL_USERGROUPDTLs));
            this._INV_AUTHORISERs = new EntitySet<INV_AUTHORISER>(new Action<INV_AUTHORISER>(this.attach_INV_AUTHORISERs), new Action<INV_AUTHORISER>(this.detach_INV_AUTHORISERs));
            this._INV_AUTHORIZATIONs = new EntitySet<INV_AUTHORIZATION>(new Action<INV_AUTHORIZATION>(this.attach_INV_AUTHORIZATIONs), new Action<INV_AUTHORIZATION>(this.detach_INV_AUTHORIZATIONs));
            this._INV_REQUISITIONs = new EntitySet<INV_REQUISITION>(new Action<INV_REQUISITION>(this.attach_INV_REQUISITIONs), new Action<INV_REQUISITION>(this.detach_INV_REQUISITIONs));
            this._MIS_BIOPSYRESULTs = new EntitySet<MIS_BIOPSYRESULT>(new Action<MIS_BIOPSYRESULT>(this.attach_MIS_BIOPSYRESULTs), new Action<MIS_BIOPSYRESULT>(this.detach_MIS_BIOPSYRESULTs));
            this._RIS_EXAMRESULTs = new EntitySet<RIS_EXAMRESULT>(new Action<RIS_EXAMRESULT>(this.attach_RIS_EXAMRESULTs), new Action<RIS_EXAMRESULT>(this.detach_RIS_EXAMRESULTs));
            this._RIS_EXAMRESULTs1 = new EntitySet<RIS_EXAMRESULT>(new Action<RIS_EXAMRESULT>(this.attach_RIS_EXAMRESULTs1), new Action<RIS_EXAMRESULT>(this.detach_RIS_EXAMRESULTs1));
            this._RIS_EXAMRESULTACCESSes = new EntitySet<RIS_EXAMRESULTACCESS>(new Action<RIS_EXAMRESULTACCESS>(this.attach_RIS_EXAMRESULTACCESSes), new Action<RIS_EXAMRESULTACCESS>(this.detach_RIS_EXAMRESULTACCESSes));
            this._RIS_EXAMRESULTNOTEs = new EntitySet<RIS_EXAMRESULTNOTE>(new Action<RIS_EXAMRESULTNOTE>(this.attach_RIS_EXAMRESULTNOTEs), new Action<RIS_EXAMRESULTNOTE>(this.detach_RIS_EXAMRESULTNOTEs));
            this._RIS_EXAMTEMPLATESHAREs = new EntitySet<RIS_EXAMTEMPLATESHARE>(new Action<RIS_EXAMTEMPLATESHARE>(this.attach_RIS_EXAMTEMPLATESHAREs), new Action<RIS_EXAMTEMPLATESHARE>(this.detach_RIS_EXAMTEMPLATESHAREs));
            this._RIS_NURSESDATAs = new EntitySet<RIS_NURSESDATA>(new Action<RIS_NURSESDATA>(this.attach_RIS_NURSESDATAs), new Action<RIS_NURSESDATA>(this.detach_RIS_NURSESDATAs));
            this._RIS_ORDERs = new EntitySet<RIS_ORDER>(new Action<RIS_ORDER>(this.attach_RIS_ORDERs), new Action<RIS_ORDER>(this.detach_RIS_ORDERs));
            this._RIS_RADSTUDYGROUPs = new EntitySet<RIS_RADSTUDYGROUP>(new Action<RIS_RADSTUDYGROUP>(this.attach_RIS_RADSTUDYGROUPs), new Action<RIS_RADSTUDYGROUP>(this.detach_RIS_RADSTUDYGROUPs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_JOBTITLE = default(EntityRef<HR_JOBTITLE>);
            this._RIS_AUTHLEVEL = default(EntityRef<RIS_AUTHLEVEL>);
            this._RIS_AUTHLEVEL1 = default(EntityRef<RIS_AUTHLEVEL>);
            OnCreated();
        }

        [Column(Storage = "_EMP_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int EMP_ID
        {
            get
            {
                return this._EMP_ID;
            }
            set
            {
                if ((this._EMP_ID != value))
                {
                    this.OnEMP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_ID = value;
                    this.SendPropertyChanged("EMP_ID");
                    this.OnEMP_IDChanged();
                }
            }
        }

        [Column(Storage = "_EMP_UID", DbType = "NVarChar(50)")]
        public string EMP_UID
        {
            get
            {
                return this._EMP_UID;
            }
            set
            {
                if ((this._EMP_UID != value))
                {
                    this.OnEMP_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_UID = value;
                    this.SendPropertyChanged("EMP_UID");
                    this.OnEMP_UIDChanged();
                }
            }
        }

        [Column(Storage = "_USER_NAME", DbType = "NVarChar(50)")]
        public string USER_NAME
        {
            get
            {
                return this._USER_NAME;
            }
            set
            {
                if ((this._USER_NAME != value))
                {
                    this.OnUSER_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._USER_NAME = value;
                    this.SendPropertyChanged("USER_NAME");
                    this.OnUSER_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_SECURITY_QUESTION", DbType = "NVarChar(300)")]
        public string SECURITY_QUESTION
        {
            get
            {
                return this._SECURITY_QUESTION;
            }
            set
            {
                if ((this._SECURITY_QUESTION != value))
                {
                    this.OnSECURITY_QUESTIONChanging(value);
                    this.SendPropertyChanging();
                    this._SECURITY_QUESTION = value;
                    this.SendPropertyChanged("SECURITY_QUESTION");
                    this.OnSECURITY_QUESTIONChanged();
                }
            }
        }

        [Column(Storage = "_SECURITY_ANSWER", DbType = "NVarChar(300)")]
        public string SECURITY_ANSWER
        {
            get
            {
                return this._SECURITY_ANSWER;
            }
            set
            {
                if ((this._SECURITY_ANSWER != value))
                {
                    this.OnSECURITY_ANSWERChanging(value);
                    this.SendPropertyChanging();
                    this._SECURITY_ANSWER = value;
                    this.SendPropertyChanged("SECURITY_ANSWER");
                    this.OnSECURITY_ANSWERChanged();
                }
            }
        }

        [Column(Storage = "_PWD", DbType = "NVarChar(40)")]
        public string PWD
        {
            get
            {
                return this._PWD;
            }
            set
            {
                if ((this._PWD != value))
                {
                    this.OnPWDChanging(value);
                    this.SendPropertyChanging();
                    this._PWD = value;
                    this.SendPropertyChanged("PWD");
                    this.OnPWDChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_ID", DbType = "Int")]
        public System.Nullable<int> UNIT_ID
        {
            get
            {
                return this._UNIT_ID;
            }
            set
            {
                if ((this._UNIT_ID != value))
                {
                    this.OnUNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID = value;
                    this.SendPropertyChanged("UNIT_ID");
                    this.OnUNIT_IDChanged();
                }
            }
        }

        [Column(Storage = "_JOBTITLE_ID", DbType = "Int")]
        public System.Nullable<int> JOBTITLE_ID
        {
            get
            {
                return this._JOBTITLE_ID;
            }
            set
            {
                if ((this._JOBTITLE_ID != value))
                {
                    if (this._HR_JOBTITLE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnJOBTITLE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._JOBTITLE_ID = value;
                    this.SendPropertyChanged("JOBTITLE_ID");
                    this.OnJOBTITLE_IDChanged();
                }
            }
        }

        [Column(Storage = "_JOB_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> JOB_TYPE
        {
            get
            {
                return this._JOB_TYPE;
            }
            set
            {
                if ((this._JOB_TYPE != value))
                {
                    this.OnJOB_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._JOB_TYPE = value;
                    this.SendPropertyChanged("JOB_TYPE");
                    this.OnJOB_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_IS_RADIOLOGIST", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_RADIOLOGIST
        {
            get
            {
                return this._IS_RADIOLOGIST;
            }
            set
            {
                if ((this._IS_RADIOLOGIST != value))
                {
                    this.OnIS_RADIOLOGISTChanging(value);
                    this.SendPropertyChanging();
                    this._IS_RADIOLOGIST = value;
                    this.SendPropertyChanged("IS_RADIOLOGIST");
                    this.OnIS_RADIOLOGISTChanged();
                }
            }
        }

        [Column(Storage = "_SALUTATION", DbType = "NVarChar(20)")]
        public string SALUTATION
        {
            get
            {
                return this._SALUTATION;
            }
            set
            {
                if ((this._SALUTATION != value))
                {
                    this.OnSALUTATIONChanging(value);
                    this.SendPropertyChanging();
                    this._SALUTATION = value;
                    this.SendPropertyChanged("SALUTATION");
                    this.OnSALUTATIONChanged();
                }
            }
        }

        [Column(Storage = "_FNAME", DbType = "NVarChar(50)")]
        public string FNAME
        {
            get
            {
                return this._FNAME;
            }
            set
            {
                if ((this._FNAME != value))
                {
                    this.OnFNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._FNAME = value;
                    this.SendPropertyChanged("FNAME");
                    this.OnFNAMEChanged();
                }
            }
        }

        [Column(Storage = "_MNAME", DbType = "NVarChar(50)")]
        public string MNAME
        {
            get
            {
                return this._MNAME;
            }
            set
            {
                if ((this._MNAME != value))
                {
                    this.OnMNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._MNAME = value;
                    this.SendPropertyChanged("MNAME");
                    this.OnMNAMEChanged();
                }
            }
        }

        [Column(Storage = "_LNAME", DbType = "NVarChar(50)")]
        public string LNAME
        {
            get
            {
                return this._LNAME;
            }
            set
            {
                if ((this._LNAME != value))
                {
                    this.OnLNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._LNAME = value;
                    this.SendPropertyChanged("LNAME");
                    this.OnLNAMEChanged();
                }
            }
        }

        [Column(Storage = "_TITLE_ENG", DbType = "NVarChar(20)")]
        public string TITLE_ENG
        {
            get
            {
                return this._TITLE_ENG;
            }
            set
            {
                if ((this._TITLE_ENG != value))
                {
                    this.OnTITLE_ENGChanging(value);
                    this.SendPropertyChanging();
                    this._TITLE_ENG = value;
                    this.SendPropertyChanged("TITLE_ENG");
                    this.OnTITLE_ENGChanged();
                }
            }
        }

        [Column(Storage = "_FNAME_ENG", DbType = "NVarChar(50)")]
        public string FNAME_ENG
        {
            get
            {
                return this._FNAME_ENG;
            }
            set
            {
                if ((this._FNAME_ENG != value))
                {
                    this.OnFNAME_ENGChanging(value);
                    this.SendPropertyChanging();
                    this._FNAME_ENG = value;
                    this.SendPropertyChanged("FNAME_ENG");
                    this.OnFNAME_ENGChanged();
                }
            }
        }

        [Column(Storage = "_MNAME_ENG", DbType = "NVarChar(50)")]
        public string MNAME_ENG
        {
            get
            {
                return this._MNAME_ENG;
            }
            set
            {
                if ((this._MNAME_ENG != value))
                {
                    this.OnMNAME_ENGChanging(value);
                    this.SendPropertyChanging();
                    this._MNAME_ENG = value;
                    this.SendPropertyChanged("MNAME_ENG");
                    this.OnMNAME_ENGChanged();
                }
            }
        }

        [Column(Storage = "_LNAME_ENG", DbType = "NVarChar(50)")]
        public string LNAME_ENG
        {
            get
            {
                return this._LNAME_ENG;
            }
            set
            {
                if ((this._LNAME_ENG != value))
                {
                    this.OnLNAME_ENGChanging(value);
                    this.SendPropertyChanging();
                    this._LNAME_ENG = value;
                    this.SendPropertyChanged("LNAME_ENG");
                    this.OnLNAME_ENGChanged();
                }
            }
        }

        [Column(Storage = "_GENDER", DbType = "NVarChar(1)")]
        public System.Nullable<char> GENDER
        {
            get
            {
                return this._GENDER;
            }
            set
            {
                if ((this._GENDER != value))
                {
                    this.OnGENDERChanging(value);
                    this.SendPropertyChanging();
                    this._GENDER = value;
                    this.SendPropertyChanged("GENDER");
                    this.OnGENDERChanged();
                }
            }
        }

        [Column(Storage = "_EMAIL_PERSONAL", DbType = "NVarChar(100)")]
        public string EMAIL_PERSONAL
        {
            get
            {
                return this._EMAIL_PERSONAL;
            }
            set
            {
                if ((this._EMAIL_PERSONAL != value))
                {
                    this.OnEMAIL_PERSONALChanging(value);
                    this.SendPropertyChanging();
                    this._EMAIL_PERSONAL = value;
                    this.SendPropertyChanged("EMAIL_PERSONAL");
                    this.OnEMAIL_PERSONALChanged();
                }
            }
        }

        [Column(Storage = "_EMAIL_OFFICIAL", DbType = "NVarChar(100)")]
        public string EMAIL_OFFICIAL
        {
            get
            {
                return this._EMAIL_OFFICIAL;
            }
            set
            {
                if ((this._EMAIL_OFFICIAL != value))
                {
                    this.OnEMAIL_OFFICIALChanging(value);
                    this.SendPropertyChanging();
                    this._EMAIL_OFFICIAL = value;
                    this.SendPropertyChanged("EMAIL_OFFICIAL");
                    this.OnEMAIL_OFFICIALChanged();
                }
            }
        }

        [Column(Storage = "_PHONE_HOME", DbType = "NVarChar(30)")]
        public string PHONE_HOME
        {
            get
            {
                return this._PHONE_HOME;
            }
            set
            {
                if ((this._PHONE_HOME != value))
                {
                    this.OnPHONE_HOMEChanging(value);
                    this.SendPropertyChanging();
                    this._PHONE_HOME = value;
                    this.SendPropertyChanged("PHONE_HOME");
                    this.OnPHONE_HOMEChanged();
                }
            }
        }

        [Column(Storage = "_PHONE_MOBILE", DbType = "NVarChar(30)")]
        public string PHONE_MOBILE
        {
            get
            {
                return this._PHONE_MOBILE;
            }
            set
            {
                if ((this._PHONE_MOBILE != value))
                {
                    this.OnPHONE_MOBILEChanging(value);
                    this.SendPropertyChanging();
                    this._PHONE_MOBILE = value;
                    this.SendPropertyChanged("PHONE_MOBILE");
                    this.OnPHONE_MOBILEChanged();
                }
            }
        }

        [Column(Storage = "_PHONE_OFFICE", DbType = "NVarChar(30)")]
        public string PHONE_OFFICE
        {
            get
            {
                return this._PHONE_OFFICE;
            }
            set
            {
                if ((this._PHONE_OFFICE != value))
                {
                    this.OnPHONE_OFFICEChanging(value);
                    this.SendPropertyChanging();
                    this._PHONE_OFFICE = value;
                    this.SendPropertyChanged("PHONE_OFFICE");
                    this.OnPHONE_OFFICEChanged();
                }
            }
        }

        [Column(Storage = "_PREFERRED_PHONE", DbType = "NVarChar(1)")]
        public System.Nullable<char> PREFERRED_PHONE
        {
            get
            {
                return this._PREFERRED_PHONE;
            }
            set
            {
                if ((this._PREFERRED_PHONE != value))
                {
                    this.OnPREFERRED_PHONEChanging(value);
                    this.SendPropertyChanging();
                    this._PREFERRED_PHONE = value;
                    this.SendPropertyChanged("PREFERRED_PHONE");
                    this.OnPREFERRED_PHONEChanged();
                }
            }
        }

        [Column(Storage = "_PABX_EXT", DbType = "Int")]
        public System.Nullable<int> PABX_EXT
        {
            get
            {
                return this._PABX_EXT;
            }
            set
            {
                if ((this._PABX_EXT != value))
                {
                    this.OnPABX_EXTChanging(value);
                    this.SendPropertyChanging();
                    this._PABX_EXT = value;
                    this.SendPropertyChanged("PABX_EXT");
                    this.OnPABX_EXTChanged();
                }
            }
        }

        [Column(Storage = "_FAX_NO", DbType = "NVarChar(25)")]
        public string FAX_NO
        {
            get
            {
                return this._FAX_NO;
            }
            set
            {
                if ((this._FAX_NO != value))
                {
                    this.OnFAX_NOChanging(value);
                    this.SendPropertyChanging();
                    this._FAX_NO = value;
                    this.SendPropertyChanged("FAX_NO");
                    this.OnFAX_NOChanged();
                }
            }
        }

        [Column(Storage = "_DOB", DbType = "DateTime")]
        public System.Nullable<System.DateTime> DOB
        {
            get
            {
                return this._DOB;
            }
            set
            {
                if ((this._DOB != value))
                {
                    this.OnDOBChanging(value);
                    this.SendPropertyChanging();
                    this._DOB = value;
                    this.SendPropertyChanged("DOB");
                    this.OnDOBChanged();
                }
            }
        }

        [Column(Storage = "_BLOOD_GROUP", DbType = "NVarChar(3)")]
        public string BLOOD_GROUP
        {
            get
            {
                return this._BLOOD_GROUP;
            }
            set
            {
                if ((this._BLOOD_GROUP != value))
                {
                    this.OnBLOOD_GROUPChanging(value);
                    this.SendPropertyChanging();
                    this._BLOOD_GROUP = value;
                    this.SendPropertyChanged("BLOOD_GROUP");
                    this.OnBLOOD_GROUPChanged();
                }
            }
        }

        [Column(Storage = "_DEFAULT_LANG", DbType = "Int")]
        public System.Nullable<int> DEFAULT_LANG
        {
            get
            {
                return this._DEFAULT_LANG;
            }
            set
            {
                if ((this._DEFAULT_LANG != value))
                {
                    this.OnDEFAULT_LANGChanging(value);
                    this.SendPropertyChanging();
                    this._DEFAULT_LANG = value;
                    this.SendPropertyChanged("DEFAULT_LANG");
                    this.OnDEFAULT_LANGChanged();
                }
            }
        }

        [Column(Storage = "_RELIGION", DbType = "Int")]
        public System.Nullable<int> RELIGION
        {
            get
            {
                return this._RELIGION;
            }
            set
            {
                if ((this._RELIGION != value))
                {
                    this.OnRELIGIONChanging(value);
                    this.SendPropertyChanging();
                    this._RELIGION = value;
                    this.SendPropertyChanged("RELIGION");
                    this.OnRELIGIONChanged();
                }
            }
        }

        [Column(Storage = "_PE_ADDR1", DbType = "NVarChar(100)")]
        public string PE_ADDR1
        {
            get
            {
                return this._PE_ADDR1;
            }
            set
            {
                if ((this._PE_ADDR1 != value))
                {
                    this.OnPE_ADDR1Changing(value);
                    this.SendPropertyChanging();
                    this._PE_ADDR1 = value;
                    this.SendPropertyChanged("PE_ADDR1");
                    this.OnPE_ADDR1Changed();
                }
            }
        }

        [Column(Storage = "_PE_ADDR2", DbType = "NVarChar(100)")]
        public string PE_ADDR2
        {
            get
            {
                return this._PE_ADDR2;
            }
            set
            {
                if ((this._PE_ADDR2 != value))
                {
                    this.OnPE_ADDR2Changing(value);
                    this.SendPropertyChanging();
                    this._PE_ADDR2 = value;
                    this.SendPropertyChanged("PE_ADDR2");
                    this.OnPE_ADDR2Changed();
                }
            }
        }

        [Column(Storage = "_PE_ADDR3", DbType = "NVarChar(100)")]
        public string PE_ADDR3
        {
            get
            {
                return this._PE_ADDR3;
            }
            set
            {
                if ((this._PE_ADDR3 != value))
                {
                    this.OnPE_ADDR3Changing(value);
                    this.SendPropertyChanging();
                    this._PE_ADDR3 = value;
                    this.SendPropertyChanged("PE_ADDR3");
                    this.OnPE_ADDR3Changed();
                }
            }
        }

        [Column(Storage = "_PE_ADDR4", DbType = "NVarChar(100)")]
        public string PE_ADDR4
        {
            get
            {
                return this._PE_ADDR4;
            }
            set
            {
                if ((this._PE_ADDR4 != value))
                {
                    this.OnPE_ADDR4Changing(value);
                    this.SendPropertyChanging();
                    this._PE_ADDR4 = value;
                    this.SendPropertyChanged("PE_ADDR4");
                    this.OnPE_ADDR4Changed();
                }
            }
        }

        [Column(Storage = "_AUTH_LEVEL_ID", DbType = "Int")]
        public System.Nullable<int> AUTH_LEVEL_ID
        {
            get
            {
                return this._AUTH_LEVEL_ID;
            }
            set
            {
                if ((this._AUTH_LEVEL_ID != value))
                {
                    if (this._RIS_AUTHLEVEL.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAUTH_LEVEL_IDChanging(value);
                    this.SendPropertyChanging();
                    this._AUTH_LEVEL_ID = value;
                    this.SendPropertyChanged("AUTH_LEVEL_ID");
                    this.OnAUTH_LEVEL_IDChanged();
                }
            }
        }

        [Column(Storage = "_REPORTING_TO", DbType = "Int")]
        public System.Nullable<int> REPORTING_TO
        {
            get
            {
                return this._REPORTING_TO;
            }
            set
            {
                if ((this._REPORTING_TO != value))
                {
                    this.OnREPORTING_TOChanging(value);
                    this.SendPropertyChanging();
                    this._REPORTING_TO = value;
                    this.SendPropertyChanged("REPORTING_TO");
                    this.OnREPORTING_TOChanged();
                }
            }
        }

        [Column(Storage = "_ALLOW_OTHERS_TO_FINALIZE", DbType = "NVarChar(1)")]
        public System.Nullable<char> ALLOW_OTHERS_TO_FINALIZE
        {
            get
            {
                return this._ALLOW_OTHERS_TO_FINALIZE;
            }
            set
            {
                if ((this._ALLOW_OTHERS_TO_FINALIZE != value))
                {
                    this.OnALLOW_OTHERS_TO_FINALIZEChanging(value);
                    this.SendPropertyChanging();
                    this._ALLOW_OTHERS_TO_FINALIZE = value;
                    this.SendPropertyChanged("ALLOW_OTHERS_TO_FINALIZE");
                    this.OnALLOW_OTHERS_TO_FINALIZEChanged();
                }
            }
        }

        [Column(Storage = "_LAST_PWD_MODIFIED", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LAST_PWD_MODIFIED
        {
            get
            {
                return this._LAST_PWD_MODIFIED;
            }
            set
            {
                if ((this._LAST_PWD_MODIFIED != value))
                {
                    this.OnLAST_PWD_MODIFIEDChanging(value);
                    this.SendPropertyChanging();
                    this._LAST_PWD_MODIFIED = value;
                    this.SendPropertyChanged("LAST_PWD_MODIFIED");
                    this.OnLAST_PWD_MODIFIEDChanged();
                }
            }
        }

        [Column(Storage = "_LAST_LOGIN", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LAST_LOGIN
        {
            get
            {
                return this._LAST_LOGIN;
            }
            set
            {
                if ((this._LAST_LOGIN != value))
                {
                    this.OnLAST_LOGINChanging(value);
                    this.SendPropertyChanging();
                    this._LAST_LOGIN = value;
                    this.SendPropertyChanged("LAST_LOGIN");
                    this.OnLAST_LOGINChanged();
                }
            }
        }

        [Column(Storage = "_CARD_NO", DbType = "NVarChar(50)")]
        public string CARD_NO
        {
            get
            {
                return this._CARD_NO;
            }
            set
            {
                if ((this._CARD_NO != value))
                {
                    this.OnCARD_NOChanging(value);
                    this.SendPropertyChanging();
                    this._CARD_NO = value;
                    this.SendPropertyChanged("CARD_NO");
                    this.OnCARD_NOChanged();
                }
            }
        }

        [Column(Storage = "_PLACE_OF_BIRTH", DbType = "NVarChar(10)")]
        public string PLACE_OF_BIRTH
        {
            get
            {
                return this._PLACE_OF_BIRTH;
            }
            set
            {
                if ((this._PLACE_OF_BIRTH != value))
                {
                    this.OnPLACE_OF_BIRTHChanging(value);
                    this.SendPropertyChanging();
                    this._PLACE_OF_BIRTH = value;
                    this.SendPropertyChanged("PLACE_OF_BIRTH");
                    this.OnPLACE_OF_BIRTHChanged();
                }
            }
        }

        [Column(Storage = "_NATIONALITY", DbType = "NVarChar(50)")]
        public string NATIONALITY
        {
            get
            {
                return this._NATIONALITY;
            }
            set
            {
                if ((this._NATIONALITY != value))
                {
                    this.OnNATIONALITYChanging(value);
                    this.SendPropertyChanging();
                    this._NATIONALITY = value;
                    this.SendPropertyChanged("NATIONALITY");
                    this.OnNATIONALITYChanged();
                }
            }
        }

        [Column(Storage = "_M_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> M_STATUS
        {
            get
            {
                return this._M_STATUS;
            }
            set
            {
                if ((this._M_STATUS != value))
                {
                    this.OnM_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._M_STATUS = value;
                    this.SendPropertyChanged("M_STATUS");
                    this.OnM_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_ACTIVE
        {
            get
            {
                return this._IS_ACTIVE;
            }
            set
            {
                if ((this._IS_ACTIVE != value))
                {
                    this.OnIS_ACTIVEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_ACTIVE = value;
                    this.SendPropertyChanged("IS_ACTIVE");
                    this.OnIS_ACTIVEChanged();
                }
            }
        }

        [Column(Storage = "_SUPPORT_USER", DbType = "NVarChar(1)")]
        public System.Nullable<char> SUPPORT_USER
        {
            get
            {
                return this._SUPPORT_USER;
            }
            set
            {
                if ((this._SUPPORT_USER != value))
                {
                    this.OnSUPPORT_USERChanging(value);
                    this.SendPropertyChanging();
                    this._SUPPORT_USER = value;
                    this.SendPropertyChanged("SUPPORT_USER");
                    this.OnSUPPORT_USERChanged();
                }
            }
        }

        [Column(Storage = "_CAN_KILL_SESSION", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_KILL_SESSION
        {
            get
            {
                return this._CAN_KILL_SESSION;
            }
            set
            {
                if ((this._CAN_KILL_SESSION != value))
                {
                    this.OnCAN_KILL_SESSIONChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_KILL_SESSION = value;
                    this.SendPropertyChanged("CAN_KILL_SESSION");
                    this.OnCAN_KILL_SESSIONChanged();
                }
            }
        }

        [Column(Storage = "_DEFAULT_SHIFT_NO", DbType = "Int")]
        public System.Nullable<int> DEFAULT_SHIFT_NO
        {
            get
            {
                return this._DEFAULT_SHIFT_NO;
            }
            set
            {
                if ((this._DEFAULT_SHIFT_NO != value))
                {
                    this.OnDEFAULT_SHIFT_NOChanging(value);
                    this.SendPropertyChanging();
                    this._DEFAULT_SHIFT_NO = value;
                    this.SendPropertyChanged("DEFAULT_SHIFT_NO");
                    this.OnDEFAULT_SHIFT_NOChanged();
                }
            }
        }

        [Column(Storage = "_IMG_FILE_NAME", DbType = "NVarChar(100)")]
        public string IMG_FILE_NAME
        {
            get
            {
                return this._IMG_FILE_NAME;
            }
            set
            {
                if ((this._IMG_FILE_NAME != value))
                {
                    this.OnIMG_FILE_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._IMG_FILE_NAME = value;
                    this.SendPropertyChanged("IMG_FILE_NAME");
                    this.OnIMG_FILE_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_EMP_REPORT_FOOTER1", DbType = "NVarChar(100)")]
        public string EMP_REPORT_FOOTER1
        {
            get
            {
                return this._EMP_REPORT_FOOTER1;
            }
            set
            {
                if ((this._EMP_REPORT_FOOTER1 != value))
                {
                    this.OnEMP_REPORT_FOOTER1Changing(value);
                    this.SendPropertyChanging();
                    this._EMP_REPORT_FOOTER1 = value;
                    this.SendPropertyChanged("EMP_REPORT_FOOTER1");
                    this.OnEMP_REPORT_FOOTER1Changed();
                }
            }
        }

        [Column(Storage = "_EMP_REPORT_FOOTER2", DbType = "NVarChar(100)")]
        public string EMP_REPORT_FOOTER2
        {
            get
            {
                return this._EMP_REPORT_FOOTER2;
            }
            set
            {
                if ((this._EMP_REPORT_FOOTER2 != value))
                {
                    this.OnEMP_REPORT_FOOTER2Changing(value);
                    this.SendPropertyChanging();
                    this._EMP_REPORT_FOOTER2 = value;
                    this.SendPropertyChanged("EMP_REPORT_FOOTER2");
                    this.OnEMP_REPORT_FOOTER2Changed();
                }
            }
        }

        [Column(Storage = "_ALLPROPERTIES", DbType = "VarBinary(256)", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary ALLPROPERTIES
        {
            get
            {
                return this._ALLPROPERTIES;
            }
            set
            {
                if ((this._ALLPROPERTIES != value))
                {
                    this.OnALLPROPERTIESChanging(value);
                    this.SendPropertyChanging();
                    this._ALLPROPERTIES = value;
                    this.SendPropertyChanged("ALLPROPERTIES");
                    this.OnALLPROPERTIESChanged();
                }
            }
        }

        [Column(Storage = "_VISIBLE", DbType = "Bit")]
        public System.Nullable<bool> VISIBLE
        {
            get
            {
                return this._VISIBLE;
            }
            set
            {
                if ((this._VISIBLE != value))
                {
                    this.OnVISIBLEChanging(value);
                    this.SendPropertyChanging();
                    this._VISIBLE = value;
                    this.SendPropertyChanged("VISIBLE");
                    this.OnVISIBLEChanged();
                }
            }
        }

        [Column(Storage = "_ORG_ID", DbType = "Int")]
        public System.Nullable<int> ORG_ID
        {
            get
            {
                return this._ORG_ID;
            }
            set
            {
                if ((this._ORG_ID != value))
                {
                    if (this._GBL_ENV.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnORG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_ID = value;
                    this.SendPropertyChanged("ORG_ID");
                    this.OnORG_IDChanged();
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

      

        [Association(Name = "HR_EMP_GBL_GRANTOBJECT", Storage = "_GBL_GRANTOBJECTs", ThisKey = "EMP_ID", OtherKey = "EMP_ID")]
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

        [Association(Name = "HR_EMP_GBL_GRANTROLE", Storage = "_GBL_GRANTROLEs", ThisKey = "EMP_ID", OtherKey = "EMP_ID")]
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

        [Association(Name = "HR_EMP_GBL_GROUP", Storage = "_GBL_GROUPs", ThisKey = "EMP_ID", OtherKey = "GROUP_HEAD")]
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

        [Association(Name = "HR_EMP_GBL_GROUPDTL", Storage = "_GBL_GROUPDTLs", ThisKey = "EMP_ID", OtherKey = "MEMBER_ID")]
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

        [Association(Name = "HR_EMP_GBL_MYMENU", Storage = "_GBL_MYMENUs", ThisKey = "EMP_ID", OtherKey = "EMP_ID")]
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

        [Association(Name = "HR_EMP_GBL_MYMENU1", Storage = "_GBL_MYMENUs1", ThisKey = "EMP_ID", OtherKey = "EMP_ID")]
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

        [Association(Name = "HR_EMP_GBL_RADEXPERIENCE", Storage = "_GBL_RADEXPERIENCE", ThisKey = "EMP_ID", OtherKey = "RADIOLOGIST_ID", IsUnique = true, IsForeignKey = false)]
        public GBL_RADEXPERIENCE GBL_RADEXPERIENCE
        {
            get
            {
                return this._GBL_RADEXPERIENCE.Entity;
            }
            set
            {
                GBL_RADEXPERIENCE previousValue = this._GBL_RADEXPERIENCE.Entity;
                if (((previousValue != value)
                            || (this._GBL_RADEXPERIENCE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_RADEXPERIENCE.Entity = null;
                        previousValue.HR_EMP = null;
                    }
                    this._GBL_RADEXPERIENCE.Entity = value;
                    if ((value != null))
                    {
                        value.HR_EMP = this;
                    }
                    this.SendPropertyChanged("GBL_RADEXPERIENCE");
                }
            }
        }

        [Association(Name = "HR_EMP_GBL_SESSION", Storage = "_GBL_SESSIONs", ThisKey = "EMP_ID", OtherKey = "EMP_ID")]
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

        [Association(Name = "HR_EMP_GBL_USERGROUP", Storage = "_GBL_USERGROUPs", ThisKey = "EMP_ID", OtherKey = "GROUP_HEAD")]
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

        [Association(Name = "HR_EMP_GBL_USERGROUPDTL", Storage = "_GBL_USERGROUPDTLs", ThisKey = "EMP_ID", OtherKey = "MEMBER_ID")]
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

        [Association(Name = "HR_EMP_INV_AUTHORISER", Storage = "_INV_AUTHORISERs", ThisKey = "EMP_ID", OtherKey = "EMP_ID")]
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

        [Association(Name = "HR_EMP_INV_AUTHORIZATION", Storage = "_INV_AUTHORIZATIONs", ThisKey = "EMP_ID", OtherKey = "EMP_ID")]
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

        [Association(Name = "HR_EMP_INV_REQUISITION", Storage = "_INV_REQUISITIONs", ThisKey = "EMP_ID", OtherKey = "GENERATED_BY")]
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

        [Association(Name = "HR_EMP_MIS_BIOPSYRESULT", Storage = "_MIS_BIOPSYRESULTs", ThisKey = "EMP_ID", OtherKey = "RADIOLOGIST_ID")]
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

        [Association(Name = "HR_EMP_RIS_EXAMRESULT", Storage = "_RIS_EXAMRESULTs", ThisKey = "EMP_ID", OtherKey = "RELEASED_BY")]
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

        [Association(Name = "HR_EMP_RIS_EXAMRESULT1", Storage = "_RIS_EXAMRESULTs1", ThisKey = "EMP_ID", OtherKey = "FINALIZED_BY")]
        public EntitySet<RIS_EXAMRESULT> RIS_EXAMRESULTs1
        {
            get
            {
                return this._RIS_EXAMRESULTs1;
            }
            set
            {
                this._RIS_EXAMRESULTs1.Assign(value);
            }
        }

        [Association(Name = "HR_EMP_RIS_EXAMRESULTACCESS", Storage = "_RIS_EXAMRESULTACCESSes", ThisKey = "EMP_ID", OtherKey = "ACCESS_BY")]
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

        [Association(Name = "HR_EMP_RIS_EXAMRESULTNOTE", Storage = "_RIS_EXAMRESULTNOTEs", ThisKey = "EMP_ID", OtherKey = "NOTE_BY")]
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

        [Association(Name = "HR_EMP_RIS_EXAMTEMPLATESHARE", Storage = "_RIS_EXAMTEMPLATESHAREs", ThisKey = "EMP_ID", OtherKey = "SHARE_WITH")]
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

        [Association(Name = "HR_EMP_RIS_NURSESDATA", Storage = "_RIS_NURSESDATAs", ThisKey = "EMP_ID", OtherKey = "NURSE_ID")]
        public EntitySet<RIS_NURSESDATA> RIS_NURSESDATAs
        {
            get
            {
                return this._RIS_NURSESDATAs;
            }
            set
            {
                this._RIS_NURSESDATAs.Assign(value);
            }
        }

        [Association(Name = "HR_EMP_RIS_ORDER", Storage = "_RIS_ORDERs", ThisKey = "EMP_ID", OtherKey = "REF_DOC")]
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

        [Association(Name = "HR_EMP_RIS_RADSTUDYGROUP", Storage = "_RIS_RADSTUDYGROUPs", ThisKey = "EMP_ID", OtherKey = "RADIOLOGIST_ID")]
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

        [Association(Name = "GBL_ENV_HR_EMP", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
        public GBL_ENV GBL_ENV
        {
            get
            {
                return this._GBL_ENV.Entity;
            }
            set
            {
                GBL_ENV previousValue = this._GBL_ENV.Entity;
                if (((previousValue != value)
                            || (this._GBL_ENV.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_ENV.Entity = null;
                        previousValue.HR_EMPs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.HR_EMPs.Add(this);
                        this._ORG_ID = value.ORG_ID;
                    }
                    else
                    {
                        this._ORG_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_ENV");
                }
            }
        }

        [Association(Name = "HR_JOBTITLE_HR_EMP", Storage = "_HR_JOBTITLE", ThisKey = "JOBTITLE_ID", OtherKey = "JOB_TITLE_ID", IsForeignKey = true)]
        public HR_JOBTITLE HR_JOBTITLE
        {
            get
            {
                return this._HR_JOBTITLE.Entity;
            }
            set
            {
                HR_JOBTITLE previousValue = this._HR_JOBTITLE.Entity;
                if (((previousValue != value)
                            || (this._HR_JOBTITLE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_JOBTITLE.Entity = null;
                        previousValue.HR_EMPs.Remove(this);
                    }
                    this._HR_JOBTITLE.Entity = value;
                    if ((value != null))
                    {
                        value.HR_EMPs.Add(this);
                        this._JOBTITLE_ID = value.JOB_TITLE_ID;
                    }
                    else
                    {
                        this._JOBTITLE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_JOBTITLE");
                }
            }
        }

        [Association(Name = "RIS_AUTHLEVEL_HR_EMP", Storage = "_RIS_AUTHLEVEL", ThisKey = "AUTH_LEVEL_ID", OtherKey = "AUTH_LEVEL_ID", IsForeignKey = true)]
        public RIS_AUTHLEVEL RIS_AUTHLEVEL
        {
            get
            {
                return this._RIS_AUTHLEVEL.Entity;
            }
            set
            {
                RIS_AUTHLEVEL previousValue = this._RIS_AUTHLEVEL.Entity;
                if (((previousValue != value)
                            || (this._RIS_AUTHLEVEL.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_AUTHLEVEL.Entity = null;
                        previousValue.HR_EMPs.Remove(this);
                    }
                    this._RIS_AUTHLEVEL.Entity = value;
                    if ((value != null))
                    {
                        value.HR_EMPs.Add(this);
                        this._AUTH_LEVEL_ID = value.AUTH_LEVEL_ID;
                    }
                    else
                    {
                        this._AUTH_LEVEL_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_AUTHLEVEL");
                }
            }
        }

        [Association(Name = "RIS_AUTHLEVEL_HR_EMP1", Storage = "_RIS_AUTHLEVEL1", ThisKey = "AUTH_LEVEL_ID", OtherKey = "AUTH_LEVEL_ID", IsForeignKey = true)]
        public RIS_AUTHLEVEL RIS_AUTHLEVEL1
        {
            get
            {
                return this._RIS_AUTHLEVEL1.Entity;
            }
            set
            {
                RIS_AUTHLEVEL previousValue = this._RIS_AUTHLEVEL1.Entity;
                if (((previousValue != value)
                            || (this._RIS_AUTHLEVEL1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_AUTHLEVEL1.Entity = null;
                        previousValue.HR_EMPs1.Remove(this);
                    }
                    this._RIS_AUTHLEVEL1.Entity = value;
                    if ((value != null))
                    {
                        value.HR_EMPs1.Add(this);
                        this._AUTH_LEVEL_ID = value.AUTH_LEVEL_ID;
                    }
                    else
                    {
                        this._AUTH_LEVEL_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_AUTHLEVEL1");
                }
            }
        }
        public string MODE { get; set; }
        public string Username
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string PasswordEncrypt
        {
            get;
            set;
        }
        public string SecurityQuestion
        {
            get;
            set;
        }
        public string SecurityAnswer
        {
            get;
            set;
        }
        public char IS_FELLOW
        {
            get;
            set;
        }
        public char CAN_EXCEED_SCHEDULE { get; set; }
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

        //private void attach_GBL_EMPSCHEDULEs(GBL_EMPSCHEDULE entity)
        //{
        //    this.SendPropertyChanging();
        //    entity.HR_EMP = this;
        //}
        //private void detach_GBL_EMPSCHEDULEs(GBL_EMPSCHEDULE entity)
        //{
        //    this.SendPropertyChanging();
        //    entity.HR_EMP = null;
        //}

        private void attach_GBL_GRANTOBJECTs(GBL_GRANTOBJECT entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }
        private void detach_GBL_GRANTOBJECTs(GBL_GRANTOBJECT entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_GBL_GRANTROLEs(GBL_GRANTROLE entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }
        private void detach_GBL_GRANTROLEs(GBL_GRANTROLE entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_GBL_GROUPs(GBL_GROUP entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }
        private void detach_GBL_GROUPs(GBL_GROUP entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_GBL_GROUPDTLs(GBL_GROUPDTL entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }
        private void detach_GBL_GROUPDTLs(GBL_GROUPDTL entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_GBL_MYMENUs(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }
        private void detach_GBL_MYMENUs(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_GBL_MYMENUs1(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP1 = this;
        }

        private void detach_GBL_MYMENUs1(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP1 = null;
        }

        private void attach_GBL_SESSIONs(GBL_SESSION entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_GBL_SESSIONs(GBL_SESSION entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_GBL_USERGROUPs(GBL_USERGROUP entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_GBL_USERGROUPs(GBL_USERGROUP entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_GBL_USERGROUPDTLs(GBL_USERGROUPDTL entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_GBL_USERGROUPDTLs(GBL_USERGROUPDTL entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_INV_AUTHORISERs(INV_AUTHORISER entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_INV_AUTHORISERs(INV_AUTHORISER entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_INV_AUTHORIZATIONs(INV_AUTHORIZATION entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_INV_AUTHORIZATIONs(INV_AUTHORIZATION entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_INV_REQUISITIONs(INV_REQUISITION entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_INV_REQUISITIONs(INV_REQUISITION entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_MIS_BIOPSYRESULTs(MIS_BIOPSYRESULT entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_MIS_BIOPSYRESULTs(MIS_BIOPSYRESULT entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_RIS_EXAMRESULTs(RIS_EXAMRESULT entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_RIS_EXAMRESULTs(RIS_EXAMRESULT entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_RIS_EXAMRESULTs1(RIS_EXAMRESULT entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP1 = this;
        }

        private void detach_RIS_EXAMRESULTs1(RIS_EXAMRESULT entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP1 = null;
        }

        private void attach_RIS_EXAMRESULTACCESSes(RIS_EXAMRESULTACCESS entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_RIS_EXAMRESULTACCESSes(RIS_EXAMRESULTACCESS entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_RIS_EXAMRESULTNOTEs(RIS_EXAMRESULTNOTE entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_RIS_EXAMRESULTNOTEs(RIS_EXAMRESULTNOTE entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_RIS_EXAMTEMPLATESHAREs(RIS_EXAMTEMPLATESHARE entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_RIS_EXAMTEMPLATESHAREs(RIS_EXAMTEMPLATESHARE entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_RIS_NURSESDATAs(RIS_NURSESDATA entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_RIS_NURSESDATAs(RIS_NURSESDATA entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private void attach_RIS_RADSTUDYGROUPs(RIS_RADSTUDYGROUP entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = this;
        }

        private void detach_RIS_RADSTUDYGROUPs(RIS_RADSTUDYGROUP entity)
        {
            this.SendPropertyChanging();
            entity.HR_EMP = null;
        }

        private char _IS_RESIDENT;

        public char IS_RESIDENT
        {
            get { return _IS_RESIDENT; }
            set { _IS_RESIDENT = value; }
        }
    }
}
