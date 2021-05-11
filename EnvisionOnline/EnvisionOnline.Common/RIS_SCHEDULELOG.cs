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
    [Table(Name = "dbo.RIS_SCHEDULELOG")]
    public partial class RIS_SCHEDULELOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _LOG_ID;

        private System.DateTime _EFFECTIVE_DT;

        private System.Data.Linq.Binary _START_LSN;

        private System.Data.Linq.Binary _SEQVAL;

        private int _OPERATION;

        private System.Data.Linq.Binary _UPDATE_MASK;

        private System.Nullable<int> _SCHEDULE_ID;

        private System.Nullable<int> _REG_ID;

        private string _HN;

        private System.Nullable<int> _MODALITY_ID;

        private System.Nullable<int> _EXAM_ID;

        private string _VISIT_NO;

        private System.Nullable<System.DateTime> _APPOINT_DT;

        private System.Nullable<byte> _QTY;

        private string _COMMENTS;

        private System.Nullable<char> _SPECIAL_CLINIC;

        private System.Data.Linq.Binary _ALLPROPERTIES;

        private string _SCHEDULE_DATA;

        private string _BLOCK_REASON;

        private string _ADMISSION_NO;

        private System.Nullable<System.DateTime> _SCHEDULE_DT;

        private System.Nullable<System.DateTime> _START_DATETIME;

        private System.Nullable<System.DateTime> _END_DATETIME;

        private System.Nullable<int> _REF_UNIT;

        private System.Nullable<int> _REF_DOC;

        private string _REF_DOC_INSTRUCTION;

        private string _CLINICAL_INSTRUCTION;

        private string _REASON;

        private string _DIAGNOSIS;

        private System.Nullable<int> _ICD_ID;

        private System.Nullable<char> _SCHEDULE_STATUS;

        private System.Nullable<int> _CONFIRMED_BY;

        private System.Nullable<System.DateTime> _CONFIRMED_ON;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _CLINIC_TYPE;

        private System.Nullable<decimal> _RATE;

        private System.Nullable<char> _IS_BLOCK;

        private System.Nullable<int> _GEN_DTL_ID;

        private System.Nullable<int> _RAD_ID;

        private System.Nullable<int> _PAT_STATUS;

        private System.Nullable<System.DateTime> _LMP_DT;

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
        partial void OnSCHEDULE_IDChanging(System.Nullable<int> value);
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
        #endregion

        public RIS_SCHEDULELOG()
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

        [Column(Storage = "_SCHEDULE_ID", DbType = "Int")]
        public System.Nullable<int> SCHEDULE_ID
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

        [Column(Storage = "_REG_ID", DbType = "Int")]
        public System.Nullable<int> REG_ID
        {
            get
            {
                return this._REG_ID;
            }
            set
            {
                if ((this._REG_ID != value))
                {
                    this.OnREG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REG_ID = value;
                    this.SendPropertyChanged("REG_ID");
                    this.OnREG_IDChanged();
                }
            }
        }

        [Column(Storage = "_HN", DbType = "NVarChar(30)")]
        public string HN
        {
            get
            {
                return this._HN;
            }
            set
            {
                if ((this._HN != value))
                {
                    this.OnHNChanging(value);
                    this.SendPropertyChanging();
                    this._HN = value;
                    this.SendPropertyChanged("HN");
                    this.OnHNChanged();
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

        [Column(Storage = "_VISIT_NO", DbType = "NVarChar(30)")]
        public string VISIT_NO
        {
            get
            {
                return this._VISIT_NO;
            }
            set
            {
                if ((this._VISIT_NO != value))
                {
                    this.OnVISIT_NOChanging(value);
                    this.SendPropertyChanging();
                    this._VISIT_NO = value;
                    this.SendPropertyChanged("VISIT_NO");
                    this.OnVISIT_NOChanged();
                }
            }
        }

        [Column(Storage = "_APPOINT_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> APPOINT_DT
        {
            get
            {
                return this._APPOINT_DT;
            }
            set
            {
                if ((this._APPOINT_DT != value))
                {
                    this.OnAPPOINT_DTChanging(value);
                    this.SendPropertyChanging();
                    this._APPOINT_DT = value;
                    this.SendPropertyChanged("APPOINT_DT");
                    this.OnAPPOINT_DTChanged();
                }
            }
        }

        [Column(Storage = "_QTY", DbType = "TinyInt")]
        public System.Nullable<byte> QTY
        {
            get
            {
                return this._QTY;
            }
            set
            {
                if ((this._QTY != value))
                {
                    this.OnQTYChanging(value);
                    this.SendPropertyChanging();
                    this._QTY = value;
                    this.SendPropertyChanged("QTY");
                    this.OnQTYChanged();
                }
            }
        }

        [Column(Storage = "_COMMENTS", DbType = "NVarChar(200)")]
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

        [Column(Storage = "_ALLPROPERTIES", DbType = "VarBinary(2048)", UpdateCheck = UpdateCheck.Never)]
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

        [Column(Storage = "_SCHEDULE_DATA", DbType = "NVarChar(1000)")]
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

        [Column(Storage = "_BLOCK_REASON", DbType = "NVarChar(200)")]
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

        [Column(Storage = "_ADMISSION_NO", DbType = "NVarChar(30)")]
        public string ADMISSION_NO
        {
            get
            {
                return this._ADMISSION_NO;
            }
            set
            {
                if ((this._ADMISSION_NO != value))
                {
                    this.OnADMISSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ADMISSION_NO = value;
                    this.SendPropertyChanged("ADMISSION_NO");
                    this.OnADMISSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_SCHEDULE_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> SCHEDULE_DT
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

        [Column(Storage = "_START_DATETIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> START_DATETIME
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

        [Column(Storage = "_END_DATETIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> END_DATETIME
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

        [Column(Storage = "_REF_DOC_INSTRUCTION", DbType = "NVarChar(500)")]
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

        [Column(Storage = "_CLINICAL_INSTRUCTION", DbType = "NVarChar(2000)")]
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

        [Column(Storage = "_REASON", DbType = "NVarChar(1000)")]
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

        [Column(Storage = "_DIAGNOSIS", DbType = "NVarChar(1000)")]
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

        [Column(Storage = "_CLINIC_TYPE", DbType = "Int")]
        public System.Nullable<int> CLINIC_TYPE
        {
            get
            {
                return this._CLINIC_TYPE;
            }
            set
            {
                if ((this._CLINIC_TYPE != value))
                {
                    this.OnCLINIC_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._CLINIC_TYPE = value;
                    this.SendPropertyChanged("CLINIC_TYPE");
                    this.OnCLINIC_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_RATE", DbType = "Decimal(7,2)")]
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

        [Column(Storage = "_IS_BLOCK", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_BLOCK
        {
            get
            {
                return this._IS_BLOCK;
            }
            set
            {
                if ((this._IS_BLOCK != value))
                {
                    this.OnIS_BLOCKChanging(value);
                    this.SendPropertyChanging();
                    this._IS_BLOCK = value;
                    this.SendPropertyChanged("IS_BLOCK");
                    this.OnIS_BLOCKChanged();
                }
            }
        }

        [Column(Storage = "_GEN_DTL_ID", DbType = "Int")]
        public System.Nullable<int> GEN_DTL_ID
        {
            get
            {
                return this._GEN_DTL_ID;
            }
            set
            {
                if ((this._GEN_DTL_ID != value))
                {
                    this.OnGEN_DTL_IDChanging(value);
                    this.SendPropertyChanging();
                    this._GEN_DTL_ID = value;
                    this.SendPropertyChanged("GEN_DTL_ID");
                    this.OnGEN_DTL_IDChanged();
                }
            }
        }

        [Column(Storage = "_RAD_ID", DbType = "Int")]
        public System.Nullable<int> RAD_ID
        {
            get
            {
                return this._RAD_ID;
            }
            set
            {
                if ((this._RAD_ID != value))
                {
                    this.OnRAD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._RAD_ID = value;
                    this.SendPropertyChanged("RAD_ID");
                    this.OnRAD_IDChanged();
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
