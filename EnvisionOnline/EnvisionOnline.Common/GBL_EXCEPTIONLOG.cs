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
    [Table(Name = "dbo.GBL_EXCEPTIONLOG")]
    public partial class GBL_EXCEPTIONLOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _EXC_ID;

        private string _EXC_UID;

        private System.Nullable<char> _EXC_TYPE;

        private string _EXC_TEXT;

        private string _EXC_IP;

        private string _EXC_PC_NAME;

        private System.Nullable<int> _CURRENT_FORM_ID;

        private System.Nullable<int> _CURRENT_LANG_ID;

        private System.Nullable<int> _CONNECTED_EMP_ID;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnEXC_IDChanging(int value);
        partial void OnEXC_IDChanged();
        partial void OnEXC_UIDChanging(string value);
        partial void OnEXC_UIDChanged();
        partial void OnEXC_TYPEChanging(System.Nullable<char> value);
        partial void OnEXC_TYPEChanged();
        partial void OnEXC_TEXTChanging(string value);
        partial void OnEXC_TEXTChanged();
        partial void OnEXC_IPChanging(string value);
        partial void OnEXC_IPChanged();
        partial void OnEXC_PC_NAMEChanging(string value);
        partial void OnEXC_PC_NAMEChanged();
        partial void OnCURRENT_FORM_IDChanging(System.Nullable<int> value);
        partial void OnCURRENT_FORM_IDChanged();
        partial void OnCURRENT_LANG_IDChanging(System.Nullable<int> value);
        partial void OnCURRENT_LANG_IDChanged();
        partial void OnCONNECTED_EMP_IDChanging(System.Nullable<int> value);
        partial void OnCONNECTED_EMP_IDChanged();
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

        public GBL_EXCEPTIONLOG()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_EXC_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int EXC_ID
        {
            get
            {
                return this._EXC_ID;
            }
            set
            {
                if ((this._EXC_ID != value))
                {
                    this.OnEXC_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXC_ID = value;
                    this.SendPropertyChanged("EXC_ID");
                    this.OnEXC_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXC_UID", DbType = "NVarChar(30)")]
        public string EXC_UID
        {
            get
            {
                return this._EXC_UID;
            }
            set
            {
                if ((this._EXC_UID != value))
                {
                    this.OnEXC_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._EXC_UID = value;
                    this.SendPropertyChanged("EXC_UID");
                    this.OnEXC_UIDChanged();
                }
            }
        }

        [Column(Storage = "_EXC_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> EXC_TYPE
        {
            get
            {
                return this._EXC_TYPE;
            }
            set
            {
                if ((this._EXC_TYPE != value))
                {
                    this.OnEXC_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._EXC_TYPE = value;
                    this.SendPropertyChanged("EXC_TYPE");
                    this.OnEXC_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_EXC_TEXT", DbType = "NVarChar(300)")]
        public string EXC_TEXT
        {
            get
            {
                return this._EXC_TEXT;
            }
            set
            {
                if ((this._EXC_TEXT != value))
                {
                    this.OnEXC_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._EXC_TEXT = value;
                    this.SendPropertyChanged("EXC_TEXT");
                    this.OnEXC_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_EXC_IP", DbType = "NVarChar(30)")]
        public string EXC_IP
        {
            get
            {
                return this._EXC_IP;
            }
            set
            {
                if ((this._EXC_IP != value))
                {
                    this.OnEXC_IPChanging(value);
                    this.SendPropertyChanging();
                    this._EXC_IP = value;
                    this.SendPropertyChanged("EXC_IP");
                    this.OnEXC_IPChanged();
                }
            }
        }

        [Column(Storage = "_EXC_PC_NAME", DbType = "NVarChar(100)")]
        public string EXC_PC_NAME
        {
            get
            {
                return this._EXC_PC_NAME;
            }
            set
            {
                if ((this._EXC_PC_NAME != value))
                {
                    this.OnEXC_PC_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._EXC_PC_NAME = value;
                    this.SendPropertyChanged("EXC_PC_NAME");
                    this.OnEXC_PC_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_CURRENT_FORM_ID", DbType = "Int")]
        public System.Nullable<int> CURRENT_FORM_ID
        {
            get
            {
                return this._CURRENT_FORM_ID;
            }
            set
            {
                if ((this._CURRENT_FORM_ID != value))
                {
                    this.OnCURRENT_FORM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CURRENT_FORM_ID = value;
                    this.SendPropertyChanged("CURRENT_FORM_ID");
                    this.OnCURRENT_FORM_IDChanged();
                }
            }
        }

        [Column(Storage = "_CURRENT_LANG_ID", DbType = "Int")]
        public System.Nullable<int> CURRENT_LANG_ID
        {
            get
            {
                return this._CURRENT_LANG_ID;
            }
            set
            {
                if ((this._CURRENT_LANG_ID != value))
                {
                    this.OnCURRENT_LANG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CURRENT_LANG_ID = value;
                    this.SendPropertyChanged("CURRENT_LANG_ID");
                    this.OnCURRENT_LANG_IDChanged();
                }
            }
        }

        [Column(Storage = "_CONNECTED_EMP_ID", DbType = "Int")]
        public System.Nullable<int> CONNECTED_EMP_ID
        {
            get
            {
                return this._CONNECTED_EMP_ID;
            }
            set
            {
                if ((this._CONNECTED_EMP_ID != value))
                {
                    this.OnCONNECTED_EMP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CONNECTED_EMP_ID = value;
                    this.SendPropertyChanged("CONNECTED_EMP_ID");
                    this.OnCONNECTED_EMP_IDChanged();
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

        [Association(Name = "GBL_ENV_GBL_EXCEPTIONLOG", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_EXCEPTIONLOGs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_EXCEPTIONLOGs.Add(this);
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
