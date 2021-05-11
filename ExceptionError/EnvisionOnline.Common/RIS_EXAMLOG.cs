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
    [Table(Name = "dbo.RIS_EXAMLOG")]
    public partial class RIS_EXAMLOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _LOG_ID;

        private System.DateTime _EFFECTIVE_DT;

        private System.Data.Linq.Binary _START_LSN;

        private System.Data.Linq.Binary _SEQVAL;

        private int _OPERATION;

        private System.Data.Linq.Binary _UPDATE_MASK;

        private System.Nullable<int> _EXAM_ID;

        private string _EXAM_UID;

        private string _GOVT_ID;

        private string _EXAM_NAME;

        private string _REPORT_HEADER;

        private string _REQ_SAMPLE;

        private System.Nullable<decimal> _RATE;

        private System.Nullable<decimal> _GOVT_RATE;

        private System.Nullable<int> _EXAM_TYPE;

        private string _SERVICE_TYPE;

        private System.Nullable<decimal> _CLAIMABLE_AMT;

        private System.Nullable<decimal> _NONCLAIMABLE_AMT;

        private System.Nullable<decimal> _FREE_AMT;

        private System.Nullable<char> _SPECIAL_CLINIC;

        private System.Nullable<decimal> _SPECIAL_RATE;

        private System.Nullable<char> _VAT_APPLICABLE;

        private System.Nullable<decimal> _VAT_RATE;

        private System.Nullable<int> _UNIT_ID;

        private System.Nullable<int> _REV_HEAD_ID;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<decimal> _AVG_REQ_HRS;

        private System.Nullable<decimal> _MIN_REQ_HRS;

        private System.Nullable<decimal> _COST_PRICE;

        private System.Nullable<byte> _RELEASE_AUTH_LEVEL;

        private System.Nullable<byte> _FINALIZE_AUTH_LEVEL;

        private System.Nullable<char> _PREPARATION_FLAG;

        private System.Nullable<decimal> _PREPARATION_TAT;

        private System.Nullable<char> _REPEAT_FLAG;

        private System.Nullable<int> _ICD_ID;

        private System.Nullable<int> _ACR_ID;

        private System.Nullable<int> _CPT_ID;

        private System.Nullable<byte> _DEF_CAPTURE;

        private System.Nullable<byte> _DEF_IMAGES;

        private System.Nullable<char> _IS_STRUCTURED_REPORT;

        private System.Nullable<char> _QA_REQUIRED;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ORG_ID;

        private string _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private string _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _BP_ID;

        private System.Nullable<bool> _STAT_POSSIBLE;

        private System.Nullable<byte> _STAT_TAT_MIN;

        private System.Nullable<bool> _URGENT_POSSIBLE;

        private System.Nullable<byte> _URGENT_TAT_MIN;

        private System.Nullable<char> _DEFER_HIS_RECONCILE;

        private System.Nullable<char> _IS_CHECKUP;

        private System.Nullable<decimal> _VIP_RATE;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnLOG_IDChanging(int value);
        partial void OnLOG_IDChanged();
        partial void OnEFFECTIVE_DTChanging(System.DateTime value);
        partial void OnEFFECTIVE_DTChanged();
        partial void OnSTART_LSNChanging(System.Data.Linq.Binary value);
        partial void OnSTART_LSNChanged();
        partial void OnSEQVALChanging(System.Data.Linq.Binary value);
        partial void OnSEQVALChanged();
        partial void OnOPERATIONChanging(int value);
        partial void OnOPERATIONChanged();
        partial void OnUPDATE_MASKChanging(System.Data.Linq.Binary value);
        partial void OnUPDATE_MASKChanged();
        partial void OnEXAM_IDChanging(System.Nullable<int> value);
        partial void OnEXAM_IDChanged();
        partial void OnEXAM_UIDChanging(string value);
        partial void OnEXAM_UIDChanged();
        partial void OnGOVT_IDChanging(string value);
        partial void OnGOVT_IDChanged();
        partial void OnEXAM_NAMEChanging(string value);
        partial void OnEXAM_NAMEChanged();
        partial void OnREPORT_HEADERChanging(string value);
        partial void OnREPORT_HEADERChanged();
        partial void OnREQ_SAMPLEChanging(string value);
        partial void OnREQ_SAMPLEChanged();
        partial void OnRATEChanging(System.Nullable<decimal> value);
        partial void OnRATEChanged();
        partial void OnGOVT_RATEChanging(System.Nullable<decimal> value);
        partial void OnGOVT_RATEChanged();
        partial void OnEXAM_TYPEChanging(System.Nullable<int> value);
        partial void OnEXAM_TYPEChanged();
        partial void OnSERVICE_TYPEChanging(string value);
        partial void OnSERVICE_TYPEChanged();
        partial void OnCLAIMABLE_AMTChanging(System.Nullable<decimal> value);
        partial void OnCLAIMABLE_AMTChanged();
        partial void OnNONCLAIMABLE_AMTChanging(System.Nullable<decimal> value);
        partial void OnNONCLAIMABLE_AMTChanged();
        partial void OnFREE_AMTChanging(System.Nullable<decimal> value);
        partial void OnFREE_AMTChanged();
        partial void OnSPECIAL_CLINICChanging(System.Nullable<char> value);
        partial void OnSPECIAL_CLINICChanged();
        partial void OnSPECIAL_RATEChanging(System.Nullable<decimal> value);
        partial void OnSPECIAL_RATEChanged();
        partial void OnVAT_APPLICABLEChanging(System.Nullable<char> value);
        partial void OnVAT_APPLICABLEChanged();
        partial void OnVAT_RATEChanging(System.Nullable<decimal> value);
        partial void OnVAT_RATEChanged();
        partial void OnUNIT_IDChanging(System.Nullable<int> value);
        partial void OnUNIT_IDChanged();
        partial void OnREV_HEAD_IDChanging(System.Nullable<int> value);
        partial void OnREV_HEAD_IDChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
        partial void OnAVG_REQ_HRSChanging(System.Nullable<decimal> value);
        partial void OnAVG_REQ_HRSChanged();
        partial void OnMIN_REQ_HRSChanging(System.Nullable<decimal> value);
        partial void OnMIN_REQ_HRSChanged();
        partial void OnCOST_PRICEChanging(System.Nullable<decimal> value);
        partial void OnCOST_PRICEChanged();
        partial void OnRELEASE_AUTH_LEVELChanging(System.Nullable<byte> value);
        partial void OnRELEASE_AUTH_LEVELChanged();
        partial void OnFINALIZE_AUTH_LEVELChanging(System.Nullable<byte> value);
        partial void OnFINALIZE_AUTH_LEVELChanged();
        partial void OnPREPARATION_FLAGChanging(System.Nullable<char> value);
        partial void OnPREPARATION_FLAGChanged();
        partial void OnPREPARATION_TATChanging(System.Nullable<decimal> value);
        partial void OnPREPARATION_TATChanged();
        partial void OnREPEAT_FLAGChanging(System.Nullable<char> value);
        partial void OnREPEAT_FLAGChanged();
        partial void OnICD_IDChanging(System.Nullable<int> value);
        partial void OnICD_IDChanged();
        partial void OnACR_IDChanging(System.Nullable<int> value);
        partial void OnACR_IDChanged();
        partial void OnCPT_IDChanging(System.Nullable<int> value);
        partial void OnCPT_IDChanged();
        partial void OnDEF_CAPTUREChanging(System.Nullable<byte> value);
        partial void OnDEF_CAPTUREChanged();
        partial void OnDEF_IMAGESChanging(System.Nullable<byte> value);
        partial void OnDEF_IMAGESChanged();
        partial void OnIS_STRUCTURED_REPORTChanging(System.Nullable<char> value);
        partial void OnIS_STRUCTURED_REPORTChanged();
        partial void OnQA_REQUIREDChanging(System.Nullable<char> value);
        partial void OnQA_REQUIREDChanged();
        partial void OnIS_UPDATEDChanging(System.Nullable<char> value);
        partial void OnIS_UPDATEDChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnCREATED_BYChanging(string value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(string value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        partial void OnBP_IDChanging(System.Nullable<int> value);
        partial void OnBP_IDChanged();
        partial void OnSTAT_POSSIBLEChanging(System.Nullable<bool> value);
        partial void OnSTAT_POSSIBLEChanged();
        partial void OnSTAT_TAT_MINChanging(System.Nullable<byte> value);
        partial void OnSTAT_TAT_MINChanged();
        partial void OnURGENT_POSSIBLEChanging(System.Nullable<bool> value);
        partial void OnURGENT_POSSIBLEChanged();
        partial void OnURGENT_TAT_MINChanging(System.Nullable<byte> value);
        partial void OnURGENT_TAT_MINChanged();
        partial void OnDEFER_HIS_RECONCILEChanging(System.Nullable<char> value);
        partial void OnDEFER_HIS_RECONCILEChanged();
        partial void OnIS_CHECKUPChanging(System.Nullable<char> value);
        partial void OnIS_CHECKUPChanged();
        partial void OnVIP_RATEChanging(System.Nullable<decimal> value);
        partial void OnVIP_RATEChanged();
        #endregion

        public RIS_EXAMLOG()
        {
            OnCreated();
        }

        [Column(Storage = "_LOG_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int LOG_ID
        {
            get
            {
                return this._LOG_ID;
            }
            set
            {
                if ((this._LOG_ID != value))
                {
                    this.OnLOG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._LOG_ID = value;
                    this.SendPropertyChanged("LOG_ID");
                    this.OnLOG_IDChanged();
                }
            }
        }

        [Column(Storage = "_EFFECTIVE_DT", DbType = "DateTime NOT NULL")]
        public System.DateTime EFFECTIVE_DT
        {
            get
            {
                return this._EFFECTIVE_DT;
            }
            set
            {
                if ((this._EFFECTIVE_DT != value))
                {
                    this.OnEFFECTIVE_DTChanging(value);
                    this.SendPropertyChanging();
                    this._EFFECTIVE_DT = value;
                    this.SendPropertyChanged("EFFECTIVE_DT");
                    this.OnEFFECTIVE_DTChanged();
                }
            }
        }

        [Column(Storage = "_START_LSN", DbType = "Binary(10) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary START_LSN
        {
            get
            {
                return this._START_LSN;
            }
            set
            {
                if ((this._START_LSN != value))
                {
                    this.OnSTART_LSNChanging(value);
                    this.SendPropertyChanging();
                    this._START_LSN = value;
                    this.SendPropertyChanged("START_LSN");
                    this.OnSTART_LSNChanged();
                }
            }
        }

        [Column(Storage = "_SEQVAL", DbType = "Binary(10) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary SEQVAL
        {
            get
            {
                return this._SEQVAL;
            }
            set
            {
                if ((this._SEQVAL != value))
                {
                    this.OnSEQVALChanging(value);
                    this.SendPropertyChanging();
                    this._SEQVAL = value;
                    this.SendPropertyChanged("SEQVAL");
                    this.OnSEQVALChanged();
                }
            }
        }

        [Column(Storage = "_OPERATION", DbType = "Int NOT NULL")]
        public int OPERATION
        {
            get
            {
                return this._OPERATION;
            }
            set
            {
                if ((this._OPERATION != value))
                {
                    this.OnOPERATIONChanging(value);
                    this.SendPropertyChanging();
                    this._OPERATION = value;
                    this.SendPropertyChanged("OPERATION");
                    this.OnOPERATIONChanged();
                }
            }
        }

        [Column(Storage = "_UPDATE_MASK", DbType = "VarBinary(128) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary UPDATE_MASK
        {
            get
            {
                return this._UPDATE_MASK;
            }
            set
            {
                if ((this._UPDATE_MASK != value))
                {
                    this.OnUPDATE_MASKChanging(value);
                    this.SendPropertyChanging();
                    this._UPDATE_MASK = value;
                    this.SendPropertyChanged("UPDATE_MASK");
                    this.OnUPDATE_MASKChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int")]
        public System.Nullable<int> EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_UID", DbType = "NVarChar(30)")]
        public string EXAM_UID
        {
            get
            {
                return this._EXAM_UID;
            }
            set
            {
                if ((this._EXAM_UID != value))
                {
                    this.OnEXAM_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_UID = value;
                    this.SendPropertyChanged("EXAM_UID");
                    this.OnEXAM_UIDChanged();
                }
            }
        }

        [Column(Storage = "_GOVT_ID", DbType = "NVarChar(30)")]
        public string GOVT_ID
        {
            get
            {
                return this._GOVT_ID;
            }
            set
            {
                if ((this._GOVT_ID != value))
                {
                    this.OnGOVT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._GOVT_ID = value;
                    this.SendPropertyChanged("GOVT_ID");
                    this.OnGOVT_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_NAME", DbType = "NVarChar(300)")]
        public string EXAM_NAME
        {
            get
            {
                return this._EXAM_NAME;
            }
            set
            {
                if ((this._EXAM_NAME != value))
                {
                    this.OnEXAM_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_NAME = value;
                    this.SendPropertyChanged("EXAM_NAME");
                    this.OnEXAM_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_REPORT_HEADER", DbType = "NVarChar(300)")]
        public string REPORT_HEADER
        {
            get
            {
                return this._REPORT_HEADER;
            }
            set
            {
                if ((this._REPORT_HEADER != value))
                {
                    this.OnREPORT_HEADERChanging(value);
                    this.SendPropertyChanging();
                    this._REPORT_HEADER = value;
                    this.SendPropertyChanged("REPORT_HEADER");
                    this.OnREPORT_HEADERChanged();
                }
            }
        }

        [Column(Storage = "_REQ_SAMPLE", DbType = "NVarChar(20)")]
        public string REQ_SAMPLE
        {
            get
            {
                return this._REQ_SAMPLE;
            }
            set
            {
                if ((this._REQ_SAMPLE != value))
                {
                    this.OnREQ_SAMPLEChanging(value);
                    this.SendPropertyChanging();
                    this._REQ_SAMPLE = value;
                    this.SendPropertyChanged("REQ_SAMPLE");
                    this.OnREQ_SAMPLEChanged();
                }
            }
        }

        [Column(Storage = "_RATE", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> RATE
        {
            get
            {
                return this._RATE;
            }
            set
            {
                if ((this._RATE != value))
                {
                    this.OnRATEChanging(value);
                    this.SendPropertyChanging();
                    this._RATE = value;
                    this.SendPropertyChanged("RATE");
                    this.OnRATEChanged();
                }
            }
        }

        [Column(Storage = "_GOVT_RATE", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> GOVT_RATE
        {
            get
            {
                return this._GOVT_RATE;
            }
            set
            {
                if ((this._GOVT_RATE != value))
                {
                    this.OnGOVT_RATEChanging(value);
                    this.SendPropertyChanging();
                    this._GOVT_RATE = value;
                    this.SendPropertyChanged("GOVT_RATE");
                    this.OnGOVT_RATEChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_TYPE", DbType = "Int")]
        public System.Nullable<int> EXAM_TYPE
        {
            get
            {
                return this._EXAM_TYPE;
            }
            set
            {
                if ((this._EXAM_TYPE != value))
                {
                    this.OnEXAM_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_TYPE = value;
                    this.SendPropertyChanged("EXAM_TYPE");
                    this.OnEXAM_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_SERVICE_TYPE", DbType = "NVarChar(2)")]
        public string SERVICE_TYPE
        {
            get
            {
                return this._SERVICE_TYPE;
            }
            set
            {
                if ((this._SERVICE_TYPE != value))
                {
                    this.OnSERVICE_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._SERVICE_TYPE = value;
                    this.SendPropertyChanged("SERVICE_TYPE");
                    this.OnSERVICE_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_CLAIMABLE_AMT", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> CLAIMABLE_AMT
        {
            get
            {
                return this._CLAIMABLE_AMT;
            }
            set
            {
                if ((this._CLAIMABLE_AMT != value))
                {
                    this.OnCLAIMABLE_AMTChanging(value);
                    this.SendPropertyChanging();
                    this._CLAIMABLE_AMT = value;
                    this.SendPropertyChanged("CLAIMABLE_AMT");
                    this.OnCLAIMABLE_AMTChanged();
                }
            }
        }

        [Column(Storage = "_NONCLAIMABLE_AMT", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> NONCLAIMABLE_AMT
        {
            get
            {
                return this._NONCLAIMABLE_AMT;
            }
            set
            {
                if ((this._NONCLAIMABLE_AMT != value))
                {
                    this.OnNONCLAIMABLE_AMTChanging(value);
                    this.SendPropertyChanging();
                    this._NONCLAIMABLE_AMT = value;
                    this.SendPropertyChanged("NONCLAIMABLE_AMT");
                    this.OnNONCLAIMABLE_AMTChanged();
                }
            }
        }

        [Column(Storage = "_FREE_AMT", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> FREE_AMT
        {
            get
            {
                return this._FREE_AMT;
            }
            set
            {
                if ((this._FREE_AMT != value))
                {
                    this.OnFREE_AMTChanging(value);
                    this.SendPropertyChanging();
                    this._FREE_AMT = value;
                    this.SendPropertyChanged("FREE_AMT");
                    this.OnFREE_AMTChanged();
                }
            }
        }

        [Column(Storage = "_SPECIAL_CLINIC", DbType = "NVarChar(1)")]
        public System.Nullable<char> SPECIAL_CLINIC
        {
            get
            {
                return this._SPECIAL_CLINIC;
            }
            set
            {
                if ((this._SPECIAL_CLINIC != value))
                {
                    this.OnSPECIAL_CLINICChanging(value);
                    this.SendPropertyChanging();
                    this._SPECIAL_CLINIC = value;
                    this.SendPropertyChanged("SPECIAL_CLINIC");
                    this.OnSPECIAL_CLINICChanged();
                }
            }
        }

        [Column(Storage = "_SPECIAL_RATE", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> SPECIAL_RATE
        {
            get
            {
                return this._SPECIAL_RATE;
            }
            set
            {
                if ((this._SPECIAL_RATE != value))
                {
                    this.OnSPECIAL_RATEChanging(value);
                    this.SendPropertyChanging();
                    this._SPECIAL_RATE = value;
                    this.SendPropertyChanged("SPECIAL_RATE");
                    this.OnSPECIAL_RATEChanged();
                }
            }
        }

        [Column(Storage = "_VAT_APPLICABLE", DbType = "NVarChar(1)")]
        public System.Nullable<char> VAT_APPLICABLE
        {
            get
            {
                return this._VAT_APPLICABLE;
            }
            set
            {
                if ((this._VAT_APPLICABLE != value))
                {
                    this.OnVAT_APPLICABLEChanging(value);
                    this.SendPropertyChanging();
                    this._VAT_APPLICABLE = value;
                    this.SendPropertyChanged("VAT_APPLICABLE");
                    this.OnVAT_APPLICABLEChanged();
                }
            }
        }

        [Column(Storage = "_VAT_RATE", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> VAT_RATE
        {
            get
            {
                return this._VAT_RATE;
            }
            set
            {
                if ((this._VAT_RATE != value))
                {
                    this.OnVAT_RATEChanging(value);
                    this.SendPropertyChanging();
                    this._VAT_RATE = value;
                    this.SendPropertyChanged("VAT_RATE");
                    this.OnVAT_RATEChanged();
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

        [Column(Storage = "_REV_HEAD_ID", DbType = "Int")]
        public System.Nullable<int> REV_HEAD_ID
        {
            get
            {
                return this._REV_HEAD_ID;
            }
            set
            {
                if ((this._REV_HEAD_ID != value))
                {
                    this.OnREV_HEAD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REV_HEAD_ID = value;
                    this.SendPropertyChanged("REV_HEAD_ID");
                    this.OnREV_HEAD_IDChanged();
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

        [Column(Storage = "_AVG_REQ_HRS", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> AVG_REQ_HRS
        {
            get
            {
                return this._AVG_REQ_HRS;
            }
            set
            {
                if ((this._AVG_REQ_HRS != value))
                {
                    this.OnAVG_REQ_HRSChanging(value);
                    this.SendPropertyChanging();
                    this._AVG_REQ_HRS = value;
                    this.SendPropertyChanged("AVG_REQ_HRS");
                    this.OnAVG_REQ_HRSChanged();
                }
            }
        }

        [Column(Storage = "_MIN_REQ_HRS", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> MIN_REQ_HRS
        {
            get
            {
                return this._MIN_REQ_HRS;
            }
            set
            {
                if ((this._MIN_REQ_HRS != value))
                {
                    this.OnMIN_REQ_HRSChanging(value);
                    this.SendPropertyChanging();
                    this._MIN_REQ_HRS = value;
                    this.SendPropertyChanged("MIN_REQ_HRS");
                    this.OnMIN_REQ_HRSChanged();
                }
            }
        }

        [Column(Storage = "_COST_PRICE", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> COST_PRICE
        {
            get
            {
                return this._COST_PRICE;
            }
            set
            {
                if ((this._COST_PRICE != value))
                {
                    this.OnCOST_PRICEChanging(value);
                    this.SendPropertyChanging();
                    this._COST_PRICE = value;
                    this.SendPropertyChanged("COST_PRICE");
                    this.OnCOST_PRICEChanged();
                }
            }
        }

        [Column(Storage = "_RELEASE_AUTH_LEVEL", DbType = "TinyInt")]
        public System.Nullable<byte> RELEASE_AUTH_LEVEL
        {
            get
            {
                return this._RELEASE_AUTH_LEVEL;
            }
            set
            {
                if ((this._RELEASE_AUTH_LEVEL != value))
                {
                    this.OnRELEASE_AUTH_LEVELChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASE_AUTH_LEVEL = value;
                    this.SendPropertyChanged("RELEASE_AUTH_LEVEL");
                    this.OnRELEASE_AUTH_LEVELChanged();
                }
            }
        }

        [Column(Storage = "_FINALIZE_AUTH_LEVEL", DbType = "TinyInt")]
        public System.Nullable<byte> FINALIZE_AUTH_LEVEL
        {
            get
            {
                return this._FINALIZE_AUTH_LEVEL;
            }
            set
            {
                if ((this._FINALIZE_AUTH_LEVEL != value))
                {
                    this.OnFINALIZE_AUTH_LEVELChanging(value);
                    this.SendPropertyChanging();
                    this._FINALIZE_AUTH_LEVEL = value;
                    this.SendPropertyChanged("FINALIZE_AUTH_LEVEL");
                    this.OnFINALIZE_AUTH_LEVELChanged();
                }
            }
        }

        [Column(Storage = "_PREPARATION_FLAG", DbType = "NVarChar(1)")]
        public System.Nullable<char> PREPARATION_FLAG
        {
            get
            {
                return this._PREPARATION_FLAG;
            }
            set
            {
                if ((this._PREPARATION_FLAG != value))
                {
                    this.OnPREPARATION_FLAGChanging(value);
                    this.SendPropertyChanging();
                    this._PREPARATION_FLAG = value;
                    this.SendPropertyChanged("PREPARATION_FLAG");
                    this.OnPREPARATION_FLAGChanged();
                }
            }
        }

        [Column(Storage = "_PREPARATION_TAT", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> PREPARATION_TAT
        {
            get
            {
                return this._PREPARATION_TAT;
            }
            set
            {
                if ((this._PREPARATION_TAT != value))
                {
                    this.OnPREPARATION_TATChanging(value);
                    this.SendPropertyChanging();
                    this._PREPARATION_TAT = value;
                    this.SendPropertyChanged("PREPARATION_TAT");
                    this.OnPREPARATION_TATChanged();
                }
            }
        }

        [Column(Storage = "_REPEAT_FLAG", DbType = "NVarChar(1)")]
        public System.Nullable<char> REPEAT_FLAG
        {
            get
            {
                return this._REPEAT_FLAG;
            }
            set
            {
                if ((this._REPEAT_FLAG != value))
                {
                    this.OnREPEAT_FLAGChanging(value);
                    this.SendPropertyChanging();
                    this._REPEAT_FLAG = value;
                    this.SendPropertyChanged("REPEAT_FLAG");
                    this.OnREPEAT_FLAGChanged();
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

        [Column(Storage = "_ACR_ID", DbType = "Int")]
        public System.Nullable<int> ACR_ID
        {
            get
            {
                return this._ACR_ID;
            }
            set
            {
                if ((this._ACR_ID != value))
                {
                    this.OnACR_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ACR_ID = value;
                    this.SendPropertyChanged("ACR_ID");
                    this.OnACR_IDChanged();
                }
            }
        }

        [Column(Storage = "_CPT_ID", DbType = "Int")]
        public System.Nullable<int> CPT_ID
        {
            get
            {
                return this._CPT_ID;
            }
            set
            {
                if ((this._CPT_ID != value))
                {
                    this.OnCPT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CPT_ID = value;
                    this.SendPropertyChanged("CPT_ID");
                    this.OnCPT_IDChanged();
                }
            }
        }

        [Column(Storage = "_DEF_CAPTURE", DbType = "TinyInt")]
        public System.Nullable<byte> DEF_CAPTURE
        {
            get
            {
                return this._DEF_CAPTURE;
            }
            set
            {
                if ((this._DEF_CAPTURE != value))
                {
                    this.OnDEF_CAPTUREChanging(value);
                    this.SendPropertyChanging();
                    this._DEF_CAPTURE = value;
                    this.SendPropertyChanged("DEF_CAPTURE");
                    this.OnDEF_CAPTUREChanged();
                }
            }
        }

        [Column(Storage = "_DEF_IMAGES", DbType = "TinyInt")]
        public System.Nullable<byte> DEF_IMAGES
        {
            get
            {
                return this._DEF_IMAGES;
            }
            set
            {
                if ((this._DEF_IMAGES != value))
                {
                    this.OnDEF_IMAGESChanging(value);
                    this.SendPropertyChanging();
                    this._DEF_IMAGES = value;
                    this.SendPropertyChanged("DEF_IMAGES");
                    this.OnDEF_IMAGESChanged();
                }
            }
        }

        [Column(Storage = "_IS_STRUCTURED_REPORT", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_STRUCTURED_REPORT
        {
            get
            {
                return this._IS_STRUCTURED_REPORT;
            }
            set
            {
                if ((this._IS_STRUCTURED_REPORT != value))
                {
                    this.OnIS_STRUCTURED_REPORTChanging(value);
                    this.SendPropertyChanging();
                    this._IS_STRUCTURED_REPORT = value;
                    this.SendPropertyChanged("IS_STRUCTURED_REPORT");
                    this.OnIS_STRUCTURED_REPORTChanged();
                }
            }
        }

        [Column(Storage = "_QA_REQUIRED", DbType = "NVarChar(1)")]
        public System.Nullable<char> QA_REQUIRED
        {
            get
            {
                return this._QA_REQUIRED;
            }
            set
            {
                if ((this._QA_REQUIRED != value))
                {
                    this.OnQA_REQUIREDChanging(value);
                    this.SendPropertyChanging();
                    this._QA_REQUIRED = value;
                    this.SendPropertyChanged("QA_REQUIRED");
                    this.OnQA_REQUIREDChanged();
                }
            }
        }

        [Column(Storage = "_IS_UPDATED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_UPDATED
        {
            get
            {
                return this._IS_UPDATED;
            }
            set
            {
                if ((this._IS_UPDATED != value))
                {
                    this.OnIS_UPDATEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_UPDATED = value;
                    this.SendPropertyChanged("IS_UPDATED");
                    this.OnIS_UPDATEDChanged();
                }
            }
        }

        [Column(Storage = "_IS_DELETED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_DELETED
        {
            get
            {
                return this._IS_DELETED;
            }
            set
            {
                if ((this._IS_DELETED != value))
                {
                    this.OnIS_DELETEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_DELETED = value;
                    this.SendPropertyChanged("IS_DELETED");
                    this.OnIS_DELETEDChanged();
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

        [Column(Storage = "_CREATED_BY", DbType = "NVarChar(30)")]
        public string CREATED_BY
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

        [Column(Storage = "_LAST_MODIFIED_BY", DbType = "NVarChar(30)")]
        public string LAST_MODIFIED_BY
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

        [Column(Storage = "_BP_ID", DbType = "Int")]
        public System.Nullable<int> BP_ID
        {
            get
            {
                return this._BP_ID;
            }
            set
            {
                if ((this._BP_ID != value))
                {
                    this.OnBP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._BP_ID = value;
                    this.SendPropertyChanged("BP_ID");
                    this.OnBP_IDChanged();
                }
            }
        }

        [Column(Storage = "_STAT_POSSIBLE", DbType = "Bit")]
        public System.Nullable<bool> STAT_POSSIBLE
        {
            get
            {
                return this._STAT_POSSIBLE;
            }
            set
            {
                if ((this._STAT_POSSIBLE != value))
                {
                    this.OnSTAT_POSSIBLEChanging(value);
                    this.SendPropertyChanging();
                    this._STAT_POSSIBLE = value;
                    this.SendPropertyChanged("STAT_POSSIBLE");
                    this.OnSTAT_POSSIBLEChanged();
                }
            }
        }

        [Column(Storage = "_STAT_TAT_MIN", DbType = "TinyInt")]
        public System.Nullable<byte> STAT_TAT_MIN
        {
            get
            {
                return this._STAT_TAT_MIN;
            }
            set
            {
                if ((this._STAT_TAT_MIN != value))
                {
                    this.OnSTAT_TAT_MINChanging(value);
                    this.SendPropertyChanging();
                    this._STAT_TAT_MIN = value;
                    this.SendPropertyChanged("STAT_TAT_MIN");
                    this.OnSTAT_TAT_MINChanged();
                }
            }
        }

        [Column(Storage = "_URGENT_POSSIBLE", DbType = "Bit")]
        public System.Nullable<bool> URGENT_POSSIBLE
        {
            get
            {
                return this._URGENT_POSSIBLE;
            }
            set
            {
                if ((this._URGENT_POSSIBLE != value))
                {
                    this.OnURGENT_POSSIBLEChanging(value);
                    this.SendPropertyChanging();
                    this._URGENT_POSSIBLE = value;
                    this.SendPropertyChanged("URGENT_POSSIBLE");
                    this.OnURGENT_POSSIBLEChanged();
                }
            }
        }

        [Column(Storage = "_URGENT_TAT_MIN", DbType = "TinyInt")]
        public System.Nullable<byte> URGENT_TAT_MIN
        {
            get
            {
                return this._URGENT_TAT_MIN;
            }
            set
            {
                if ((this._URGENT_TAT_MIN != value))
                {
                    this.OnURGENT_TAT_MINChanging(value);
                    this.SendPropertyChanging();
                    this._URGENT_TAT_MIN = value;
                    this.SendPropertyChanged("URGENT_TAT_MIN");
                    this.OnURGENT_TAT_MINChanged();
                }
            }
        }

        [Column(Storage = "_DEFER_HIS_RECONCILE", DbType = "NVarChar(1)")]
        public System.Nullable<char> DEFER_HIS_RECONCILE
        {
            get
            {
                return this._DEFER_HIS_RECONCILE;
            }
            set
            {
                if ((this._DEFER_HIS_RECONCILE != value))
                {
                    this.OnDEFER_HIS_RECONCILEChanging(value);
                    this.SendPropertyChanging();
                    this._DEFER_HIS_RECONCILE = value;
                    this.SendPropertyChanged("DEFER_HIS_RECONCILE");
                    this.OnDEFER_HIS_RECONCILEChanged();
                }
            }
        }

        [Column(Storage = "_IS_CHECKUP", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_CHECKUP
        {
            get
            {
                return this._IS_CHECKUP;
            }
            set
            {
                if ((this._IS_CHECKUP != value))
                {
                    this.OnIS_CHECKUPChanging(value);
                    this.SendPropertyChanging();
                    this._IS_CHECKUP = value;
                    this.SendPropertyChanged("IS_CHECKUP");
                    this.OnIS_CHECKUPChanged();
                }
            }
        }

        [Column(Storage = "_VIP_RATE", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> VIP_RATE
        {
            get
            {
                return this._VIP_RATE;
            }
            set
            {
                if ((this._VIP_RATE != value))
                {
                    this.OnVIP_RATEChanging(value);
                    this.SendPropertyChanging();
                    this._VIP_RATE = value;
                    this.SendPropertyChanged("VIP_RATE");
                    this.OnVIP_RATEChanged();
                }
            }
        }

        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }

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
    }
}
