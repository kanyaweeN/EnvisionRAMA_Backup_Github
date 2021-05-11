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
    [Table(Name = "dbo.GBL_SESSIONLOG")]
    public partial class GBL_SESSIONLOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
      
        private int _SESSIONLOG_ID;

        private int _SP_TYPE;

        private System.Nullable<int> _SESSION_ID;

        private string _SESSION_GUID;

        private System.Nullable<int> _SUBMENU_ID;

        private System.Nullable<System.DateTime> _ACCESSED_ON;

        private System.Nullable<System.DateTime> _ACCESSED_OUT;

        private string _ACTIVITY_DESC;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<GBL_SESSION> _GBL_SESSION;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSESSIONLOG_IDChanging(int value);
        partial void OnSESSIONLOG_IDChanged();
        partial void OnSESSION_IDChanging(System.Nullable<int> value);
        partial void OnSESSION_IDChanged();
        partial void OnSESSION_GUIDChanging(string value);
        partial void OnSESSION_GUIDChanged();
        partial void OnSUBMENU_IDChanging(System.Nullable<int> value);
        partial void OnSUBMENU_IDChanged();
        partial void OnACCESSED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnACCESSED_ONChanged();
        partial void OnACCESSED_OUTChanging(System.Nullable<System.DateTime> value);
        partial void OnACCESSED_OUTChanged();
        partial void OnACTIVITY_DESCChanging(string value);
        partial void OnACTIVITY_DESCChanged();
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

        public GBL_SESSIONLOG()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._GBL_SESSION = default(EntityRef<GBL_SESSION>);
            OnCreated();
        }

        [Column(Storage = "_SESSIONLOG_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SESSIONLOG_ID
        {
            get
            {
                return this._SESSIONLOG_ID;
            }
            set
            {
                if ((this._SESSIONLOG_ID != value))
                {
                    this.OnSESSIONLOG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SESSIONLOG_ID = value;
                    this.SendPropertyChanged("SESSIONLOG_ID");
                    this.OnSESSIONLOG_IDChanged();
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
                    if (this._GBL_SESSION.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSESSION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SESSION_ID = value;
                    this.SendPropertyChanged("SESSION_ID");
                    this.OnSESSION_IDChanged();
                }
            }
        }

        [Column(Storage = "_SESSION_GUID", DbType = "NVarChar(50)")]
        public string SESSION_GUID
        {
            get
            {
                return this._SESSION_GUID;
            }
            set
            {
                if ((this._SESSION_GUID != value))
                {
                    this.OnSESSION_GUIDChanging(value);
                    this.SendPropertyChanging();
                    this._SESSION_GUID = value;
                    this.SendPropertyChanged("SESSION_GUID");
                    this.OnSESSION_GUIDChanged();
                }
            }
        }

        [Column(Storage = "_SUBMENU_ID", DbType = "Int")]
        public System.Nullable<int> SUBMENU_ID
        {
            get
            {
                return this._SUBMENU_ID;
            }
            set
            {
                if ((this._SUBMENU_ID != value))
                {
                    this.OnSUBMENU_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SUBMENU_ID = value;
                    this.SendPropertyChanged("SUBMENU_ID");
                    this.OnSUBMENU_IDChanged();
                }
            }
        }

        [Column(Storage = "_ACCESSED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ACCESSED_ON
        {
            get
            {
                return this._ACCESSED_ON;
            }
            set
            {
                if ((this._ACCESSED_ON != value))
                {
                    this.OnACCESSED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSED_ON = value;
                    this.SendPropertyChanged("ACCESSED_ON");
                    this.OnACCESSED_ONChanged();
                }
            }
        }

        [Column(Storage = "_ACCESSED_OUT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ACCESSED_OUT
        {
            get
            {
                return this._ACCESSED_OUT;
            }
            set
            {
                if ((this._ACCESSED_OUT != value))
                {
                    this.OnACCESSED_OUTChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSED_OUT = value;
                    this.SendPropertyChanged("ACCESSED_OUT");
                    this.OnACCESSED_OUTChanged();
                }
            }
        }

        [Column(Storage = "_ACTIVITY_DESC", DbType = "NVarChar(300)")]
        public string ACTIVITY_DESC
        {
            get
            {
                return this._ACTIVITY_DESC;
            }
            set
            {
                if ((this._ACTIVITY_DESC != value))
                {
                    this.OnACTIVITY_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._ACTIVITY_DESC = value;
                    this.SendPropertyChanged("ACTIVITY_DESC");
                    this.OnACTIVITY_DESCChanged();
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

        [Association(Name = "GBL_ENV_GBL_SESSIONLOG", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_SESSIONLOGs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SESSIONLOGs.Add(this);
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

        [Association(Name = "GBL_SESSION_GBL_SESSIONLOG", Storage = "_GBL_SESSION", ThisKey = "SESSION_ID", OtherKey = "SESSION_ID", IsForeignKey = true)]
        public GBL_SESSION GBL_SESSION
        {
            get
            {
                return this._GBL_SESSION.Entity;
            }
            set
            {
                GBL_SESSION previousValue = this._GBL_SESSION.Entity;
                if (((previousValue != value)
                            || (this._GBL_SESSION.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_SESSION.Entity = null;
                        previousValue.GBL_SESSIONLOGs.Remove(this);
                    }
                    this._GBL_SESSION.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SESSIONLOGs.Add(this);
                        this._SESSION_ID = value.SESSION_ID;
                    }
                    else
                    {
                        this._SESSION_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_SESSION");
                }
            }
        }

        public int SP_TYPE {
            get { return this._SP_TYPE; }
            set { _SP_TYPE = value; }
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
