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
    [Table(Name = "dbo.RIS_EXAMRESULTTEMPLATELOG")]
    public partial class RIS_EXAMRESULTTEMPLATELOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _LOG_ID;

        private System.DateTime _EFFECTIVE_DT;

        private System.Data.Linq.Binary _START_LSN;

        private System.Data.Linq.Binary _SEQVAL;

        private int _OPERATION;

        private System.Data.Linq.Binary _UPDATE_MASK;

        private System.Nullable<int> _TEMPLATE_ID;

        private string _TEMPLATE_UID;

        private System.Nullable<int> _EXAM_ID;

        private string _TEMPLATE_NAME;

        private string _TEMPLATE_HEADER;

        private string _TEMPLATE_TEXT;

        private string _TEMPLATE_TEXT_RTF;

        private System.Data.Linq.Binary _TEMPLATE_BINARY;

        private System.Nullable<char> _TEMPLATE_TYPE;

        private System.Nullable<int> _SEVERITY_ID;

        private System.Nullable<char> _AUTO_APPLY;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

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
        partial void OnTEMPLATE_IDChanging(System.Nullable<int> value);
        partial void OnTEMPLATE_IDChanged();
        partial void OnTEMPLATE_UIDChanging(string value);
        partial void OnTEMPLATE_UIDChanged();
        partial void OnEXAM_IDChanging(System.Nullable<int> value);
        partial void OnEXAM_IDChanged();
        partial void OnTEMPLATE_NAMEChanging(string value);
        partial void OnTEMPLATE_NAMEChanged();
        partial void OnTEMPLATE_HEADERChanging(string value);
        partial void OnTEMPLATE_HEADERChanged();
        partial void OnTEMPLATE_TEXTChanging(string value);
        partial void OnTEMPLATE_TEXTChanged();
        partial void OnTEMPLATE_TEXT_RTFChanging(string value);
        partial void OnTEMPLATE_TEXT_RTFChanged();
        partial void OnTEMPLATE_BINARYChanging(System.Data.Linq.Binary value);
        partial void OnTEMPLATE_BINARYChanged();
        partial void OnTEMPLATE_TYPEChanging(System.Nullable<char> value);
        partial void OnTEMPLATE_TYPEChanged();
        partial void OnSEVERITY_IDChanging(System.Nullable<int> value);
        partial void OnSEVERITY_IDChanged();
        partial void OnAUTO_APPLYChanging(System.Nullable<char> value);
        partial void OnAUTO_APPLYChanged();
        partial void OnIS_UPDATEDChanging(System.Nullable<char> value);
        partial void OnIS_UPDATEDChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
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

        public RIS_EXAMRESULTTEMPLATELOG()
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

        [Column(Storage = "_TEMPLATE_ID", DbType = "Int")]
        public System.Nullable<int> TEMPLATE_ID
        {
            get
            {
                return this._TEMPLATE_ID;
            }
            set
            {
                if ((this._TEMPLATE_ID != value))
                {
                    this.OnTEMPLATE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TEMPLATE_ID = value;
                    this.SendPropertyChanged("TEMPLATE_ID");
                    this.OnTEMPLATE_IDChanged();
                }
            }
        }

        [Column(Storage = "_TEMPLATE_UID", DbType = "NVarChar(30)")]
        public string TEMPLATE_UID
        {
            get
            {
                return this._TEMPLATE_UID;
            }
            set
            {
                if ((this._TEMPLATE_UID != value))
                {
                    this.OnTEMPLATE_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._TEMPLATE_UID = value;
                    this.SendPropertyChanged("TEMPLATE_UID");
                    this.OnTEMPLATE_UIDChanged();
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

        [Column(Storage = "_TEMPLATE_NAME", DbType = "VarChar(100)")]
        public string TEMPLATE_NAME
        {
            get
            {
                return this._TEMPLATE_NAME;
            }
            set
            {
                if ((this._TEMPLATE_NAME != value))
                {
                    this.OnTEMPLATE_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._TEMPLATE_NAME = value;
                    this.SendPropertyChanged("TEMPLATE_NAME");
                    this.OnTEMPLATE_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_TEMPLATE_HEADER", DbType = "NVarChar(100)")]
        public string TEMPLATE_HEADER
        {
            get
            {
                return this._TEMPLATE_HEADER;
            }
            set
            {
                if ((this._TEMPLATE_HEADER != value))
                {
                    this.OnTEMPLATE_HEADERChanging(value);
                    this.SendPropertyChanging();
                    this._TEMPLATE_HEADER = value;
                    this.SendPropertyChanged("TEMPLATE_HEADER");
                    this.OnTEMPLATE_HEADERChanged();
                }
            }
        }

        [Column(Storage = "_TEMPLATE_TEXT", DbType = "NVarChar(MAX)")]
        public string TEMPLATE_TEXT
        {
            get
            {
                return this._TEMPLATE_TEXT;
            }
            set
            {
                if ((this._TEMPLATE_TEXT != value))
                {
                    this.OnTEMPLATE_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._TEMPLATE_TEXT = value;
                    this.SendPropertyChanged("TEMPLATE_TEXT");
                    this.OnTEMPLATE_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_TEMPLATE_TEXT_RTF", DbType = "NVarChar(MAX)")]
        public string TEMPLATE_TEXT_RTF
        {
            get
            {
                return this._TEMPLATE_TEXT_RTF;
            }
            set
            {
                if ((this._TEMPLATE_TEXT_RTF != value))
                {
                    this.OnTEMPLATE_TEXT_RTFChanging(value);
                    this.SendPropertyChanging();
                    this._TEMPLATE_TEXT_RTF = value;
                    this.SendPropertyChanged("TEMPLATE_TEXT_RTF");
                    this.OnTEMPLATE_TEXT_RTFChanged();
                }
            }
        }

        [Column(Storage = "_TEMPLATE_BINARY", DbType = "VarBinary(MAX)", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary TEMPLATE_BINARY
        {
            get
            {
                return this._TEMPLATE_BINARY;
            }
            set
            {
                if ((this._TEMPLATE_BINARY != value))
                {
                    this.OnTEMPLATE_BINARYChanging(value);
                    this.SendPropertyChanging();
                    this._TEMPLATE_BINARY = value;
                    this.SendPropertyChanged("TEMPLATE_BINARY");
                    this.OnTEMPLATE_BINARYChanged();
                }
            }
        }

        [Column(Storage = "_TEMPLATE_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> TEMPLATE_TYPE
        {
            get
            {
                return this._TEMPLATE_TYPE;
            }
            set
            {
                if ((this._TEMPLATE_TYPE != value))
                {
                    this.OnTEMPLATE_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._TEMPLATE_TYPE = value;
                    this.SendPropertyChanged("TEMPLATE_TYPE");
                    this.OnTEMPLATE_TYPEChanged();
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

        [Column(Storage = "_AUTO_APPLY", DbType = "NVarChar(1)")]
        public System.Nullable<char> AUTO_APPLY
        {
            get
            {
                return this._AUTO_APPLY;
            }
            set
            {
                if ((this._AUTO_APPLY != value))
                {
                    this.OnAUTO_APPLYChanging(value);
                    this.SendPropertyChanging();
                    this._AUTO_APPLY = value;
                    this.SendPropertyChanged("AUTO_APPLY");
                    this.OnAUTO_APPLYChanged();
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
        public DateTime FROMDATE { get; set; }
        public DateTime TODATE { get; set; }
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
