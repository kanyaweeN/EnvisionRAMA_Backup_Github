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
    [Table(Name = "dbo.RIS_EXAMRESULTLOG")]
    public partial class RIS_EXAMRESULTLOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _LOG_ID;

        private System.DateTime _EFFECTIVE_DT;

        private System.Data.Linq.Binary _START_LSN;

        private System.Data.Linq.Binary _SEQVAL;

        private int _OPERATION;

        private System.Data.Linq.Binary _UPDATE_MASK;

        private string _ACCESSION_NO;

        private System.Nullable<int> _ORDER_ID;

        private System.Nullable<int> _EXAM_ID;

        private string _RESULT_TEXT_HTML;

        private string _RESULT_TEXT_PLAIN;

        private string _RESULT_TEXT_RTF;

        private System.Data.Linq.Binary _RESULT_BINARY;

        private System.Nullable<char> _RESULT_STATUS;

        private System.Nullable<int> _ICD_ID;

        private System.Nullable<int> _SEVERITY_ID;

        private string _HL7_TEXT;

        private System.Nullable<char> _HL7_SEND;

        private System.Nullable<int> _RELEASED_BY;

        private System.Nullable<System.DateTime> _RELEASED_ON;

        private System.Nullable<int> _FINALIZED_BY;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

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
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnORDER_IDChanging(System.Nullable<int> value);
        partial void OnORDER_IDChanged();
        partial void OnEXAM_IDChanging(System.Nullable<int> value);
        partial void OnEXAM_IDChanged();
        partial void OnRESULT_TEXT_HTMLChanging(string value);
        partial void OnRESULT_TEXT_HTMLChanged();
        partial void OnRESULT_TEXT_PLAINChanging(string value);
        partial void OnRESULT_TEXT_PLAINChanged();
        partial void OnRESULT_TEXT_RTFChanging(string value);
        partial void OnRESULT_TEXT_RTFChanged();
        partial void OnRESULT_BINARYChanging(System.Data.Linq.Binary value);
        partial void OnRESULT_BINARYChanged();
        partial void OnRESULT_STATUSChanging(System.Nullable<char> value);
        partial void OnRESULT_STATUSChanged();
        partial void OnICD_IDChanging(System.Nullable<int> value);
        partial void OnICD_IDChanged();
        partial void OnSEVERITY_IDChanging(System.Nullable<int> value);
        partial void OnSEVERITY_IDChanged();
        partial void OnHL7_TEXTChanging(string value);
        partial void OnHL7_TEXTChanged();
        partial void OnHL7_SENDChanging(System.Nullable<char> value);
        partial void OnHL7_SENDChanged();
        partial void OnRELEASED_BYChanging(System.Nullable<int> value);
        partial void OnRELEASED_BYChanged();
        partial void OnRELEASED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnRELEASED_ONChanged();
        partial void OnFINALIZED_BYChanging(System.Nullable<int> value);
        partial void OnFINALIZED_BYChanged();
        partial void OnFINALIZED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnFINALIZED_ONChanged();
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

        public RIS_EXAMRESULTLOG()
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

        [Column(Storage = "_UPDATE_MASK", DbType = "VarBinary(10) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
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

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30)")]
        public string ACCESSION_NO
        {
            get
            {
                return this._ACCESSION_NO;
            }
            set
            {
                if ((this._ACCESSION_NO != value))
                {
                    this.OnACCESSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_NO = value;
                    this.SendPropertyChanged("ACCESSION_NO");
                    this.OnACCESSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_ORDER_ID", DbType = "Int")]
        public System.Nullable<int> ORDER_ID
        {
            get
            {
                return this._ORDER_ID;
            }
            set
            {
                if ((this._ORDER_ID != value))
                {
                    this.OnORDER_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_ID = value;
                    this.SendPropertyChanged("ORDER_ID");
                    this.OnORDER_IDChanged();
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

        [Column(Storage = "_RESULT_TEXT_HTML", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_HTML
        {
            get
            {
                return this._RESULT_TEXT_HTML;
            }
            set
            {
                if ((this._RESULT_TEXT_HTML != value))
                {
                    this.OnRESULT_TEXT_HTMLChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_TEXT_HTML = value;
                    this.SendPropertyChanged("RESULT_TEXT_HTML");
                    this.OnRESULT_TEXT_HTMLChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_PLAIN", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_PLAIN
        {
            get
            {
                return this._RESULT_TEXT_PLAIN;
            }
            set
            {
                if ((this._RESULT_TEXT_PLAIN != value))
                {
                    this.OnRESULT_TEXT_PLAINChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_TEXT_PLAIN = value;
                    this.SendPropertyChanged("RESULT_TEXT_PLAIN");
                    this.OnRESULT_TEXT_PLAINChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_RTF", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_RTF
        {
            get
            {
                return this._RESULT_TEXT_RTF;
            }
            set
            {
                if ((this._RESULT_TEXT_RTF != value))
                {
                    this.OnRESULT_TEXT_RTFChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_TEXT_RTF = value;
                    this.SendPropertyChanged("RESULT_TEXT_RTF");
                    this.OnRESULT_TEXT_RTFChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_BINARY", DbType = "Binary(1)", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary RESULT_BINARY
        {
            get
            {
                return this._RESULT_BINARY;
            }
            set
            {
                if ((this._RESULT_BINARY != value))
                {
                    this.OnRESULT_BINARYChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_BINARY = value;
                    this.SendPropertyChanged("RESULT_BINARY");
                    this.OnRESULT_BINARYChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> RESULT_STATUS
        {
            get
            {
                return this._RESULT_STATUS;
            }
            set
            {
                if ((this._RESULT_STATUS != value))
                {
                    this.OnRESULT_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_STATUS = value;
                    this.SendPropertyChanged("RESULT_STATUS");
                    this.OnRESULT_STATUSChanged();
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

        [Column(Storage = "_SEVERITY_ID", DbType = "Int")]
        public System.Nullable<int> SEVERITY_ID
        {
            get
            {
                return this._SEVERITY_ID;
            }
            set
            {
                if ((this._SEVERITY_ID != value))
                {
                    this.OnSEVERITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SEVERITY_ID = value;
                    this.SendPropertyChanged("SEVERITY_ID");
                    this.OnSEVERITY_IDChanged();
                }
            }
        }

        [Column(Storage = "_HL7_TEXT", DbType = "NVarChar(MAX)")]
        public string HL7_TEXT
        {
            get
            {
                return this._HL7_TEXT;
            }
            set
            {
                if ((this._HL7_TEXT != value))
                {
                    this.OnHL7_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._HL7_TEXT = value;
                    this.SendPropertyChanged("HL7_TEXT");
                    this.OnHL7_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_HL7_SEND", DbType = "NVarChar(1)")]
        public System.Nullable<char> HL7_SEND
        {
            get
            {
                return this._HL7_SEND;
            }
            set
            {
                if ((this._HL7_SEND != value))
                {
                    this.OnHL7_SENDChanging(value);
                    this.SendPropertyChanging();
                    this._HL7_SEND = value;
                    this.SendPropertyChanged("HL7_SEND");
                    this.OnHL7_SENDChanged();
                }
            }
        }

        [Column(Storage = "_RELEASED_BY", DbType = "Int")]
        public System.Nullable<int> RELEASED_BY
        {
            get
            {
                return this._RELEASED_BY;
            }
            set
            {
                if ((this._RELEASED_BY != value))
                {
                    this.OnRELEASED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASED_BY = value;
                    this.SendPropertyChanged("RELEASED_BY");
                    this.OnRELEASED_BYChanged();
                }
            }
        }

        [Column(Storage = "_RELEASED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> RELEASED_ON
        {
            get
            {
                return this._RELEASED_ON;
            }
            set
            {
                if ((this._RELEASED_ON != value))
                {
                    this.OnRELEASED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASED_ON = value;
                    this.SendPropertyChanged("RELEASED_ON");
                    this.OnRELEASED_ONChanged();
                }
            }
        }

        [Column(Storage = "_FINALIZED_BY", DbType = "Int")]
        public System.Nullable<int> FINALIZED_BY
        {
            get
            {
                return this._FINALIZED_BY;
            }
            set
            {
                if ((this._FINALIZED_BY != value))
                {
                    this.OnFINALIZED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._FINALIZED_BY = value;
                    this.SendPropertyChanged("FINALIZED_BY");
                    this.OnFINALIZED_BYChanged();
                }
            }
        }

        [Column(Storage = "_FINALIZED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> FINALIZED_ON
        {
            get
            {
                return this._FINALIZED_ON;
            }
            set
            {
                if ((this._FINALIZED_ON != value))
                {
                    this.OnFINALIZED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._FINALIZED_ON = value;
                    this.SendPropertyChanged("FINALIZED_ON");
                    this.OnFINALIZED_ONChanged();
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
