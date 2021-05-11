using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace EnvisionOnline.Common
{
    [Table(Name = "dbo.RIS_SCHEDULE")]
    public partial class RIS_SCHEDULE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SCHEDULE_ID;

        private int _REG_ID;

        private System.DateTime _SCHEDULE_DT;

        private System.Nullable<int> _MODALITY_ID;

        private string _SCHEDULE_DATA;

        private System.Nullable<int> _LABEL;

        private string _LOCATION;

        private System.Nullable<int> _EVENTTYPE;

        private System.Nullable<int> _SESSION_ID;

        private System.DateTime _START_DATETIME;

        private System.DateTime _END_DATETIME;

        private System.Nullable<int> _REF_UNIT;

        private System.Nullable<int> _REF_DOC;

        private string _REF_DOC_INSTRUCTION;

        private string _CLINICAL_INSTRUCTION;

        private string _REASON;

        private string _DIAGNOSIS;

        private System.Nullable<int> _PAT_STATUS;

        private System.Nullable<System.DateTime> _LMP_DT;

        private System.Nullable<int> _ICD_ID;

        private System.Nullable<char> _SCHEDULE_STATUS;

        private System.Nullable<int> _CONFIRMED_BY;

        private System.Nullable<System.DateTime> _CONFIRMED_ON;

        private System.Nullable<char> _IS_BLOCKED;

        private string _BLOCK_REASON;

        private string _COMMENTS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<RIS_ORDER> _RIS_ORDERs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HIS_REGISTRATION> _HIS_REGISTRATION;

        private EntityRef<RIS_PATIENTPREPARATION> _RIS_PATIENTPREPARATION;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSCHEDULE_IDChanging(int value);
        partial void OnSCHEDULE_IDChanged();
        partial void OnREG_IDChanging(System.Nullable<int> value);
        partial void OnREG_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnMODALITY_IDChanging(System.Nullable<int> value);
        partial void OnMODALITY_IDChanged();
        partial void OnEXAM_IDChanging(System.Nullable<int> value);
        partial void OnEXAM_IDChanged();
        partial void OnVISIT_NOChanging(string value);
        partial void OnVISIT_NOChanged();
        partial void OnAPPOINT_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnAPPOINT_DTChanged();
        partial void OnQTYChanging(System.Nullable<byte> value);
        partial void OnQTYChanged();
        partial void OnCOMMENTSChanging(string value);
        partial void OnCOMMENTSChanged();
        partial void OnSPECIAL_CLINICChanging(System.Nullable<char> value);
        partial void OnSPECIAL_CLINICChanged();
        partial void OnALLPROPERTIESChanging(System.Data.Linq.Binary value);
        partial void OnALLPROPERTIESChanged();
        partial void OnSCHEDULE_DATAChanging(string value);
        partial void OnSCHEDULE_DATAChanged();
        partial void OnBLOCK_REASONChanging(string value);
        partial void OnBLOCK_REASONChanged();
        partial void OnADMISSION_NOChanging(string value);
        partial void OnADMISSION_NOChanged();
        partial void OnSCHEDULE_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnSCHEDULE_DTChanged();
        partial void OnSTART_DATETIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnSTART_DATETIMEChanged();
        partial void OnEND_DATETIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnEND_DATETIMEChanged();
        partial void OnREF_UNITChanging(System.Nullable<int> value);
        partial void OnREF_UNITChanged();
        partial void OnREF_DOCChanging(System.Nullable<int> value);
        partial void OnREF_DOCChanged();
        partial void OnREF_DOC_INSTRUCTIONChanging(string value);
        partial void OnREF_DOC_INSTRUCTIONChanged();
        partial void OnCLINICAL_INSTRUCTIONChanging(string value);
        partial void OnCLINICAL_INSTRUCTIONChanged();
        partial void OnREASONChanging(string value);
        partial void OnREASONChanged();
        partial void OnDIAGNOSISChanging(string value);
        partial void OnDIAGNOSISChanged();
        partial void OnICD_IDChanging(System.Nullable<int> value);
        partial void OnICD_IDChanged();
        partial void OnSCHEDULE_STATUSChanging(System.Nullable<char> value);
        partial void OnSCHEDULE_STATUSChanged();
        partial void OnCONFIRMED_BYChanging(System.Nullable<int> value);
        partial void OnCONFIRMED_BYChanged();
        partial void OnCONFIRMED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCONFIRMED_ONChanged();
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
        partial void OnCLINIC_TYPEChanging(System.Nullable<int> value);
        partial void OnCLINIC_TYPEChanged();
        partial void OnRATEChanging(System.Nullable<decimal> value);
        partial void OnRATEChanged();
        partial void OnIS_BLOCKChanging(System.Nullable<char> value);
        partial void OnIS_BLOCKChanged();
        partial void OnGEN_DTL_IDChanging(System.Nullable<int> value);
        partial void OnGEN_DTL_IDChanged();
        partial void OnRAD_IDChanging(System.Nullable<int> value);
        partial void OnRAD_IDChanged();
        partial void OnPAT_STATUSChanging(System.Nullable<int> value);
        partial void OnPAT_STATUSChanged();
        partial void OnLMP_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnLMP_DTChanged();
        partial void OnSESSION_IDChanging(System.Nullable<int> value);
        partial void OnSESSION_IDChanged();
        partial void OnPREPARATION_IDChanging(System.Nullable<int> value);
        partial void OnPREPARATION_IDChanged();
        partial void OnLABELChanging(System.Nullable<int> value);
        partial void OnLABELChanged();
        partial void OnLOCATIONChanging(string value);
        partial void OnLOCATIONChanged();
        partial void OnEVENTTYPEChanging(System.Nullable<int> value);
        partial void OnEVENTTYPEChanged();
        partial void OnIS_BLOCKEDChanging(System.Nullable<char> value);
        partial void OnIS_BLOCKEDChanged();
        #endregion

        public RIS_SCHEDULE()
        {
            this._RIS_ORDERs = new EntitySet<RIS_ORDER>(new Action<RIS_ORDER>(this.attach_RIS_ORDERs), new Action<RIS_ORDER>(this.detach_RIS_ORDERs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HIS_REGISTRATION = default(EntityRef<HIS_REGISTRATION>);
            this._RIS_PATIENTPREPARATION = default(EntityRef<RIS_PATIENTPREPARATION>);
            OnCreated();
        }

       

        [Column(Storage = "_SCHEDULE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SCHEDULE_ID
        {
            get
            {
                return this._SCHEDULE_ID;
            }
            set
            {
                if ((this._SCHEDULE_ID != value))
                {
                    this.OnSCHEDULE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_ID = value;
                    this.SendPropertyChanged("SCHEDULE_ID");
                    this.OnSCHEDULE_IDChanged();
                }
            }
        }

        [Column(Storage = "_REG_ID", DbType = "Int NOT NULL")]
        public int REG_ID
        {
            get
            {
                return this._REG_ID;
            }
            set
            {
                if ((this._REG_ID != value))
                {
                    if (this._HIS_REGISTRATION.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnREG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REG_ID = value;
                    this.SendPropertyChanged("REG_ID");
                    this.OnREG_IDChanged();
                }
            }
        }

        [Column(Storage = "_SCHEDULE_DT", DbType = "DateTime NOT NULL")]
        public System.DateTime SCHEDULE_DT
        {
            get
            {
                return this._SCHEDULE_DT;
            }
            set
            {
                if ((this._SCHEDULE_DT != value))
                {
                    this.OnSCHEDULE_DTChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_DT = value;
                    this.SendPropertyChanged("SCHEDULE_DT");
                    this.OnSCHEDULE_DTChanged();
                }
            }
        }

        [Column(Storage = "_MODALITY_ID", DbType = "Int")]
        public System.Nullable<int> MODALITY_ID
        {
            get
            {
                return this._MODALITY_ID;
            }
            set
            {
                if ((this._MODALITY_ID != value))
                {
                    this.OnMODALITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_ID = value;
                    this.SendPropertyChanged("MODALITY_ID");
                    this.OnMODALITY_IDChanged();
                }
            }
        }

        [Column(Storage = "_SCHEDULE_DATA", DbType = "NVarChar(MAX)")]
        public string SCHEDULE_DATA
        {
            get
            {
                return this._SCHEDULE_DATA;
            }
            set
            {
                if ((this._SCHEDULE_DATA != value))
                {
                    this.OnSCHEDULE_DATAChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_DATA = value;
                    this.SendPropertyChanged("SCHEDULE_DATA");
                    this.OnSCHEDULE_DATAChanged();
                }
            }
        }

        [Column(Storage = "_LABEL", DbType = "Int")]
        public System.Nullable<int> LABEL
        {
            get
            {
                return this._LABEL;
            }
            set
            {
                if ((this._LABEL != value))
                {
                    this.OnLABELChanging(value);
                    this.SendPropertyChanging();
                    this._LABEL = value;
                    this.SendPropertyChanged("LABEL");
                    this.OnLABELChanged();
                }
            }
        }

        [Column(Storage = "_LOCATION", DbType = "NVarChar(50)")]
        public string LOCATION
        {
            get
            {
                return this._LOCATION;
            }
            set
            {
                if ((this._LOCATION != value))
                {
                    this.OnLOCATIONChanging(value);
                    this.SendPropertyChanging();
                    this._LOCATION = value;
                    this.SendPropertyChanged("LOCATION");
                    this.OnLOCATIONChanged();
                }
            }
        }

        [Column(Storage = "_EVENTTYPE", DbType = "Int")]
        public System.Nullable<int> EVENTTYPE
        {
            get
            {
                return this._EVENTTYPE;
            }
            set
            {
                if ((this._EVENTTYPE != value))
                {
                    this.OnEVENTTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._EVENTTYPE = value;
                    this.SendPropertyChanged("EVENTTYPE");
                    this.OnEVENTTYPEChanged();
                }
            }
        }

        [Column(Storage = "_SESSION_ID", DbType = "Int")]
        public System.Nullable<int> SESSION_ID
        {
            get
            {
                return this._SESSION_ID;
            }
            set
            {
                if ((this._SESSION_ID != value))
                {
                    this.OnSESSION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SESSION_ID = value;
                    this.SendPropertyChanged("SESSION_ID");
                    this.OnSESSION_IDChanged();
                }
            }
        }

        [Column(Storage = "_START_DATETIME", DbType = "DateTime NOT NULL")]
        public System.DateTime START_DATETIME
        {
            get
            {
                return this._START_DATETIME;
            }
            set
            {
                if ((this._START_DATETIME != value))
                {
                    this.OnSTART_DATETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._START_DATETIME = value;
                    this.SendPropertyChanged("START_DATETIME");
                    this.OnSTART_DATETIMEChanged();
                }
            }
        }

        [Column(Storage = "_END_DATETIME", DbType = "DateTime NOT NULL")]
        public System.DateTime END_DATETIME
        {
            get
            {
                return this._END_DATETIME;
            }
            set
            {
                if ((this._END_DATETIME != value))
                {
                    this.OnEND_DATETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._END_DATETIME = value;
                    this.SendPropertyChanged("END_DATETIME");
                    this.OnEND_DATETIMEChanged();
                }
            }
        }

        [Column(Storage = "_REF_UNIT", DbType = "Int")]
        public System.Nullable<int> REF_UNIT
        {
            get
            {
                return this._REF_UNIT;
            }
            set
            {
                if ((this._REF_UNIT != value))
                {
                    this.OnREF_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._REF_UNIT = value;
                    this.SendPropertyChanged("REF_UNIT");
                    this.OnREF_UNITChanged();
                }
            }
        }

        [Column(Storage = "_REF_DOC", DbType = "Int")]
        public System.Nullable<int> REF_DOC
        {
            get
            {
                return this._REF_DOC;
            }
            set
            {
                if ((this._REF_DOC != value))
                {
                    this.OnREF_DOCChanging(value);
                    this.SendPropertyChanging();
                    this._REF_DOC = value;
                    this.SendPropertyChanged("REF_DOC");
                    this.OnREF_DOCChanged();
                }
            }
        }

        [Column(Storage = "_REF_DOC_INSTRUCTION", DbType = "NVarChar(300)")]
        public string REF_DOC_INSTRUCTION
        {
            get
            {
                return this._REF_DOC_INSTRUCTION;
            }
            set
            {
                if ((this._REF_DOC_INSTRUCTION != value))
                {
                    this.OnREF_DOC_INSTRUCTIONChanging(value);
                    this.SendPropertyChanging();
                    this._REF_DOC_INSTRUCTION = value;
                    this.SendPropertyChanged("REF_DOC_INSTRUCTION");
                    this.OnREF_DOC_INSTRUCTIONChanged();
                }
            }
        }

        [Column(Storage = "_CLINICAL_INSTRUCTION", DbType = "NVarChar(300)")]
        public string CLINICAL_INSTRUCTION
        {
            get
            {
                return this._CLINICAL_INSTRUCTION;
            }
            set
            {
                if ((this._CLINICAL_INSTRUCTION != value))
                {
                    this.OnCLINICAL_INSTRUCTIONChanging(value);
                    this.SendPropertyChanging();
                    this._CLINICAL_INSTRUCTION = value;
                    this.SendPropertyChanged("CLINICAL_INSTRUCTION");
                    this.OnCLINICAL_INSTRUCTIONChanged();
                }
            }
        }

        [Column(Storage = "_REASON", DbType = "NVarChar(300)")]
        public string REASON
        {
            get
            {
                return this._REASON;
            }
            set
            {
                if ((this._REASON != value))
                {
                    this.OnREASONChanging(value);
                    this.SendPropertyChanging();
                    this._REASON = value;
                    this.SendPropertyChanged("REASON");
                    this.OnREASONChanged();
                }
            }
        }

        [Column(Storage = "_DIAGNOSIS", DbType = "NVarChar(300)")]
        public string DIAGNOSIS
        {
            get
            {
                return this._DIAGNOSIS;
            }
            set
            {
                if ((this._DIAGNOSIS != value))
                {
                    this.OnDIAGNOSISChanging(value);
                    this.SendPropertyChanging();
                    this._DIAGNOSIS = value;
                    this.SendPropertyChanged("DIAGNOSIS");
                    this.OnDIAGNOSISChanged();
                }
            }
        }

        [Column(Storage = "_PAT_STATUS", DbType = "Int")]
        public System.Nullable<int> PAT_STATUS
        {
            get
            {
                return this._PAT_STATUS;
            }
            set
            {
                if ((this._PAT_STATUS != value))
                {
                    this.OnPAT_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._PAT_STATUS = value;
                    this.SendPropertyChanged("PAT_STATUS");
                    this.OnPAT_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_LMP_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LMP_DT
        {
            get
            {
                return this._LMP_DT;
            }
            set
            {
                if ((this._LMP_DT != value))
                {
                    this.OnLMP_DTChanging(value);
                    this.SendPropertyChanging();
                    this._LMP_DT = value;
                    this.SendPropertyChanged("LMP_DT");
                    this.OnLMP_DTChanged();
                }
            }
        }

        [Column(Storage = "_ICD_ID", DbType = "Int")]
        public System.Nullable<int> ICD_ID
        {
            get
            {
                return this._ICD_ID;
            }
            set
            {
                if ((this._ICD_ID != value))
                {
                    this.OnICD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ICD_ID = value;
                    this.SendPropertyChanged("ICD_ID");
                    this.OnICD_IDChanged();
                }
            }
        }

        [Column(Storage = "_SCHEDULE_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> SCHEDULE_STATUS
        {
            get
            {
                return this._SCHEDULE_STATUS;
            }
            set
            {
                if ((this._SCHEDULE_STATUS != value))
                {
                    this.OnSCHEDULE_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_STATUS = value;
                    this.SendPropertyChanged("SCHEDULE_STATUS");
                    this.OnSCHEDULE_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_CONFIRMED_BY", DbType = "Int")]
        public System.Nullable<int> CONFIRMED_BY
        {
            get
            {
                return this._CONFIRMED_BY;
            }
            set
            {
                if ((this._CONFIRMED_BY != value))
                {
                    this.OnCONFIRMED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._CONFIRMED_BY = value;
                    this.SendPropertyChanged("CONFIRMED_BY");
                    this.OnCONFIRMED_BYChanged();
                }
            }
        }

        [Column(Storage = "_CONFIRMED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CONFIRMED_ON
        {
            get
            {
                return this._CONFIRMED_ON;
            }
            set
            {
                if ((this._CONFIRMED_ON != value))
                {
                    this.OnCONFIRMED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._CONFIRMED_ON = value;
                    this.SendPropertyChanged("CONFIRMED_ON");
                    this.OnCONFIRMED_ONChanged();
                }
            }
        }

        [Column(Storage = "_IS_BLOCKED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_BLOCKED
        {
            get
            {
                return this._IS_BLOCKED;
            }
            set
            {
                if ((this._IS_BLOCKED != value))
                {
                    this.OnIS_BLOCKEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_BLOCKED = value;
                    this.SendPropertyChanged("IS_BLOCKED");
                    this.OnIS_BLOCKEDChanged();
                }
            }
        }

        [Column(Storage = "_BLOCK_REASON", DbType = "NVarChar(300)")]
        public string BLOCK_REASON
        {
            get
            {
                return this._BLOCK_REASON;
            }
            set
            {
                if ((this._BLOCK_REASON != value))
                {
                    this.OnBLOCK_REASONChanging(value);
                    this.SendPropertyChanging();
                    this._BLOCK_REASON = value;
                    this.SendPropertyChanged("BLOCK_REASON");
                    this.OnBLOCK_REASONChanged();
                }
            }
        }

        [Column(Storage = "_COMMENTS", DbType = "NVarChar(500)")]
        public string COMMENTS
        {
            get
            {
                return this._COMMENTS;
            }
            set
            {
                if ((this._COMMENTS != value))
                {
                    this.OnCOMMENTSChanging(value);
                    this.SendPropertyChanging();
                    this._COMMENTS = value;
                    this.SendPropertyChanged("COMMENTS");
                    this.OnCOMMENTSChanged();
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

        public int INSURANCE_TYPE_ID { get; set; }

        public string HN { get; set; }

        public string RECURRENCEINFO { get; set; }

        public bool ALLDAY { get; set; }
        public int STATUS { get; set; }
        public int RAD_ID { get; set; }
        public int ENC_ID { get; set; }
        public string ENC_TYPE { get; set; }
        public string ENC_CLINIC { get; set; }
        public int TYPE { get; set; }
        public string IS_BUSY { get; set; }
        public int WL_CONFIRMED_BY { get; set; }
        public int SCHEDULE_EXCEED_BY { get; set; }
        public string IS_ALERT_CLINICAL_INSTRUCTION { get; set; }
        public string CLINICAL_INSTRUCTION_TAG { get; set; }
        public string IS_TELEMED { get; set; }

        [Association(Name = "RIS_SCHEDULE_RIS_ORDER", Storage = "_RIS_ORDERs", ThisKey = "SCHEDULE_ID", OtherKey = "SCHEDULE_ID")]
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

        [Association(Name = "GBL_ENV_RIS_SCHEDULE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_SCHEDULEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_SCHEDULEs.Add(this);
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

        [Association(Name = "HIS_REGISTRATION_RIS_SCHEDULE", Storage = "_HIS_REGISTRATION", ThisKey = "REG_ID", OtherKey = "REG_ID", IsForeignKey = true)]
        public HIS_REGISTRATION HIS_REGISTRATION
        {
            get
            {
                return this._HIS_REGISTRATION.Entity;
            }
            set
            {
                HIS_REGISTRATION previousValue = this._HIS_REGISTRATION.Entity;
                if (((previousValue != value)
                            || (this._HIS_REGISTRATION.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HIS_REGISTRATION.Entity = null;
                        previousValue.RIS_SCHEDULEs.Remove(this);
                    }
                    this._HIS_REGISTRATION.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_SCHEDULEs.Add(this);
                        this._REG_ID = value.REG_ID;
                    }
                    else
                    {
                        this._REG_ID = default(int);
                    }
                    this.SendPropertyChanged("HIS_REGISTRATION");
                }
            }
        }

        

        public string REASON_CHANGE { get; set; }

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

        private void attach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.RIS_SCHEDULE = this;
        }

        private void detach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.RIS_SCHEDULE = null;
        }
    }
}
