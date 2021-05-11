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
    [Table(Name = "dbo.RIS_EXAMRESULTTEMPLATE")]
    public partial class RIS_EXAMRESULTTEMPLATE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _TEMPLATE_ID;

        private string _TEMPLATE_UID;

        private int _EXAM_ID;

        private string _TEMPLATE_NAME;

        private string _TEMPLATE_HEADER;

        private string _TEMPLATE_TEXT;

        private string _TEMPLATE_TEXT_RTF;

        private System.Nullable<char> _TEMPLATE_TYPE;

        private System.Nullable<int> _SEVERITY_ID;

        private System.Nullable<int> _SHARE_WITH;

        private System.Nullable<char> _AUTO_APPLY;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_EXAM> _RIS_EXAM;

        private EntityRef<RIS_EXAMRESULTSEVERITY> _RIS_EXAMRESULTSEVERITY;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnTEMPLATE_IDChanging(int value);
        partial void OnTEMPLATE_IDChanged();
        partial void OnTEMPLATE_UIDChanging(string value);
        partial void OnTEMPLATE_UIDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnTEMPLATE_NAMEChanging(string value);
        partial void OnTEMPLATE_NAMEChanged();
        partial void OnTEMPLATE_HEADERChanging(string value);
        partial void OnTEMPLATE_HEADERChanged();
        partial void OnTEMPLATE_TEXTChanging(string value);
        partial void OnTEMPLATE_TEXTChanged();
        partial void OnTEMPLATE_TEXT_RTFChanging(string value);
        partial void OnTEMPLATE_TEXT_RTFChanged();
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

        public RIS_EXAMRESULTTEMPLATE()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_EXAM = default(EntityRef<RIS_EXAM>);
            this._RIS_EXAMRESULTSEVERITY = default(EntityRef<RIS_EXAMRESULTSEVERITY>);
            OnCreated();
        }

        [Column(Storage = "_TEMPLATE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int TEMPLATE_ID
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

        [Column(Storage = "_EXAM_ID", DbType = "Int NOT NULL")]
        public int EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    if (this._RIS_EXAM.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
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
                    if (this._RIS_EXAMRESULTSEVERITY.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
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

        [Association(Name = "GBL_ENV_RIS_EXAMRESULTTEMPLATE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMRESULTTEMPLATEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTTEMPLATEs.Add(this);
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

        [Association(Name = "RIS_EXAM_RIS_EXAMRESULTTEMPLATE", Storage = "_RIS_EXAM", ThisKey = "EXAM_ID", OtherKey = "EXAM_ID", IsForeignKey = true)]
        public RIS_EXAM RIS_EXAM
        {
            get
            {
                return this._RIS_EXAM.Entity;
            }
            set
            {
                RIS_EXAM previousValue = this._RIS_EXAM.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAM.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAM.Entity = null;
                        previousValue.RIS_EXAMRESULTTEMPLATEs.Remove(this);
                    }
                    this._RIS_EXAM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTTEMPLATEs.Add(this);
                        this._EXAM_ID = value.EXAM_ID;
                    }
                    else
                    {
                        this._EXAM_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_EXAM");
                }
            }
        }

        [Association(Name = "RIS_EXAMRESULTSEVERITY_RIS_EXAMRESULTTEMPLATE", Storage = "_RIS_EXAMRESULTSEVERITY", ThisKey = "SEVERITY_ID", OtherKey = "SEVERITY_ID", IsForeignKey = true)]
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY
        {
            get
            {
                return this._RIS_EXAMRESULTSEVERITY.Entity;
            }
            set
            {
                RIS_EXAMRESULTSEVERITY previousValue = this._RIS_EXAMRESULTSEVERITY.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAMRESULTSEVERITY.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAMRESULTSEVERITY.Entity = null;
                        previousValue.RIS_EXAMRESULTTEMPLATEs.Remove(this);
                    }
                    this._RIS_EXAMRESULTSEVERITY.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTTEMPLATEs.Add(this);
                        this._SEVERITY_ID = value.SEVERITY_ID;
                    }
                    else
                    {
                        this._SEVERITY_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_EXAMRESULTSEVERITY");
                }
            }
        }

        public System.Nullable<int> SHARE_WITH
        {
            get { return _SHARE_WITH; }
            set { _SHARE_WITH = value; }
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
