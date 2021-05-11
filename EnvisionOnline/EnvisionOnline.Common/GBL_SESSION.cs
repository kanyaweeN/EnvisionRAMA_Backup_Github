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
    [Table(Name = "dbo.GBL_SESSION")]
    public partial class GBL_SESSION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SESSION_ID;

        private System.Nullable<char> _SESSION_STAT;

        private System.Nullable<int> _EMP_ID;

        private string _SESSION_GUID;

        private string _SID;

        private string _SERIAL_;

        private System.Nullable<char> _LOGON_TYPE;

        private System.Nullable<System.DateTime> _LOGON_DT;

        private System.Nullable<System.DateTime> _LOGOUT_DT;

        private System.Nullable<char> _LOGOUT_TYPE;

        private System.Nullable<int> _KILLED_BY;

        private string _KILL_REASON;

        private string _OS_USER_NAME;

        private string _OS_NAME;

        private string _OS_TIMEZONE;

        private string _OS_REGION;

        private string _IP_ADDR_OWN;

        private string _IP_ADDR_CURR;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<GBL_SESSIONLOG> _GBL_SESSIONLOGs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_EMP> _HR_EMP;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSESSION_IDChanging(int value);
        partial void OnSESSION_IDChanged();
        partial void OnSESSION_STATChanging(System.Nullable<char> value);
        partial void OnSESSION_STATChanged();
        partial void OnEMP_IDChanging(System.Nullable<int> value);
        partial void OnEMP_IDChanged();
        partial void OnSESSION_GUIDChanging(string value);
        partial void OnSESSION_GUIDChanged();
        partial void OnSIDChanging(string value);
        partial void OnSIDChanged();
        partial void OnSERIAL_Changing(string value);
        partial void OnSERIAL_Changed();
        partial void OnLOGON_TYPEChanging(System.Nullable<char> value);
        partial void OnLOGON_TYPEChanged();
        partial void OnLOGON_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnLOGON_DTChanged();
        partial void OnLOGOUT_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnLOGOUT_DTChanged();
        partial void OnLOGOUT_TYPEChanging(System.Nullable<char> value);
        partial void OnLOGOUT_TYPEChanged();
        partial void OnKILLED_BYChanging(System.Nullable<int> value);
        partial void OnKILLED_BYChanged();
        partial void OnKILL_REASONChanging(string value);
        partial void OnKILL_REASONChanged();
        partial void OnOS_USER_NAMEChanging(string value);
        partial void OnOS_USER_NAMEChanged();
        partial void OnOS_NAMEChanging(string value);
        partial void OnOS_NAMEChanged();
        partial void OnOS_TIMEZONEChanging(string value);
        partial void OnOS_TIMEZONEChanged();
        partial void OnOS_REGIONChanging(string value);
        partial void OnOS_REGIONChanged();
        partial void OnIP_ADDR_OWNChanging(string value);
        partial void OnIP_ADDR_OWNChanged();
        partial void OnIP_ADDR_CURRChanging(string value);
        partial void OnIP_ADDR_CURRChanged();
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

        public GBL_SESSION()
        {
            this._GBL_SESSIONLOGs = new EntitySet<GBL_SESSIONLOG>(new Action<GBL_SESSIONLOG>(this.attach_GBL_SESSIONLOGs), new Action<GBL_SESSIONLOG>(this.detach_GBL_SESSIONLOGs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            OnCreated();
        }

        [Column(Storage = "_SESSION_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SESSION_ID
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

        [Column(Storage = "_SESSION_STAT", DbType = "NVarChar(1)")]
        public System.Nullable<char> SESSION_STAT
        {
            get
            {
                return this._SESSION_STAT;
            }
            set
            {
                if ((this._SESSION_STAT != value))
                {
                    this.OnSESSION_STATChanging(value);
                    this.SendPropertyChanging();
                    this._SESSION_STAT = value;
                    this.SendPropertyChanged("SESSION_STAT");
                    this.OnSESSION_STATChanged();
                }
            }
        }

        [Column(Storage = "_EMP_ID", DbType = "Int")]
        public System.Nullable<int> EMP_ID
        {
            get
            {
                return this._EMP_ID;
            }
            set
            {
                if ((this._EMP_ID != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEMP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_ID = value;
                    this.SendPropertyChanged("EMP_ID");
                    this.OnEMP_IDChanged();
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

        [Column(Storage = "_SID", DbType = "NVarChar(13)")]
        public string SID
        {
            get
            {
                return this._SID;
            }
            set
            {
                if ((this._SID != value))
                {
                    this.OnSIDChanging(value);
                    this.SendPropertyChanging();
                    this._SID = value;
                    this.SendPropertyChanged("SID");
                    this.OnSIDChanged();
                }
            }
        }

        [Column(Name = "SERIAL#", Storage = "_SERIAL_", DbType = "NVarChar(13)")]
        public string SERIAL_
        {
            get
            {
                return this._SERIAL_;
            }
            set
            {
                if ((this._SERIAL_ != value))
                {
                    this.OnSERIAL_Changing(value);
                    this.SendPropertyChanging();
                    this._SERIAL_ = value;
                    this.SendPropertyChanged("SERIAL_");
                    this.OnSERIAL_Changed();
                }
            }
        }

        [Column(Storage = "_LOGON_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> LOGON_TYPE
        {
            get
            {
                return this._LOGON_TYPE;
            }
            set
            {
                if ((this._LOGON_TYPE != value))
                {
                    this.OnLOGON_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._LOGON_TYPE = value;
                    this.SendPropertyChanged("LOGON_TYPE");
                    this.OnLOGON_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_LOGON_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LOGON_DT
        {
            get
            {
                return this._LOGON_DT;
            }
            set
            {
                if ((this._LOGON_DT != value))
                {
                    this.OnLOGON_DTChanging(value);
                    this.SendPropertyChanging();
                    this._LOGON_DT = value;
                    this.SendPropertyChanged("LOGON_DT");
                    this.OnLOGON_DTChanged();
                }
            }
        }

        [Column(Storage = "_LOGOUT_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LOGOUT_DT
        {
            get
            {
                return this._LOGOUT_DT;
            }
            set
            {
                if ((this._LOGOUT_DT != value))
                {
                    this.OnLOGOUT_DTChanging(value);
                    this.SendPropertyChanging();
                    this._LOGOUT_DT = value;
                    this.SendPropertyChanged("LOGOUT_DT");
                    this.OnLOGOUT_DTChanged();
                }
            }
        }

        [Column(Storage = "_LOGOUT_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> LOGOUT_TYPE
        {
            get
            {
                return this._LOGOUT_TYPE;
            }
            set
            {
                if ((this._LOGOUT_TYPE != value))
                {
                    this.OnLOGOUT_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._LOGOUT_TYPE = value;
                    this.SendPropertyChanged("LOGOUT_TYPE");
                    this.OnLOGOUT_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_KILLED_BY", DbType = "Int")]
        public System.Nullable<int> KILLED_BY
        {
            get
            {
                return this._KILLED_BY;
            }
            set
            {
                if ((this._KILLED_BY != value))
                {
                    this.OnKILLED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._KILLED_BY = value;
                    this.SendPropertyChanged("KILLED_BY");
                    this.OnKILLED_BYChanged();
                }
            }
        }

        [Column(Storage = "_KILL_REASON", DbType = "NVarChar(500)")]
        public string KILL_REASON
        {
            get
            {
                return this._KILL_REASON;
            }
            set
            {
                if ((this._KILL_REASON != value))
                {
                    this.OnKILL_REASONChanging(value);
                    this.SendPropertyChanging();
                    this._KILL_REASON = value;
                    this.SendPropertyChanged("KILL_REASON");
                    this.OnKILL_REASONChanged();
                }
            }
        }

        [Column(Storage = "_OS_USER_NAME", DbType = "NVarChar(100)")]
        public string OS_USER_NAME
        {
            get
            {
                return this._OS_USER_NAME;
            }
            set
            {
                if ((this._OS_USER_NAME != value))
                {
                    this.OnOS_USER_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._OS_USER_NAME = value;
                    this.SendPropertyChanged("OS_USER_NAME");
                    this.OnOS_USER_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_OS_NAME", DbType = "NVarChar(100)")]
        public string OS_NAME
        {
            get
            {
                return this._OS_NAME;
            }
            set
            {
                if ((this._OS_NAME != value))
                {
                    this.OnOS_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._OS_NAME = value;
                    this.SendPropertyChanged("OS_NAME");
                    this.OnOS_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_OS_TIMEZONE", DbType = "NVarChar(100)")]
        public string OS_TIMEZONE
        {
            get
            {
                return this._OS_TIMEZONE;
            }
            set
            {
                if ((this._OS_TIMEZONE != value))
                {
                    this.OnOS_TIMEZONEChanging(value);
                    this.SendPropertyChanging();
                    this._OS_TIMEZONE = value;
                    this.SendPropertyChanged("OS_TIMEZONE");
                    this.OnOS_TIMEZONEChanged();
                }
            }
        }

        [Column(Storage = "_OS_REGION", DbType = "NVarChar(100)")]
        public string OS_REGION
        {
            get
            {
                return this._OS_REGION;
            }
            set
            {
                if ((this._OS_REGION != value))
                {
                    this.OnOS_REGIONChanging(value);
                    this.SendPropertyChanging();
                    this._OS_REGION = value;
                    this.SendPropertyChanged("OS_REGION");
                    this.OnOS_REGIONChanged();
                }
            }
        }

        [Column(Storage = "_IP_ADDR_OWN", DbType = "NVarChar(20)")]
        public string IP_ADDR_OWN
        {
            get
            {
                return this._IP_ADDR_OWN;
            }
            set
            {
                if ((this._IP_ADDR_OWN != value))
                {
                    this.OnIP_ADDR_OWNChanging(value);
                    this.SendPropertyChanging();
                    this._IP_ADDR_OWN = value;
                    this.SendPropertyChanged("IP_ADDR_OWN");
                    this.OnIP_ADDR_OWNChanged();
                }
            }
        }

        [Column(Storage = "_IP_ADDR_CURR", DbType = "NVarChar(20)")]
        public string IP_ADDR_CURR
        {
            get
            {
                return this._IP_ADDR_CURR;
            }
            set
            {
                if ((this._IP_ADDR_CURR != value))
                {
                    this.OnIP_ADDR_CURRChanging(value);
                    this.SendPropertyChanging();
                    this._IP_ADDR_CURR = value;
                    this.SendPropertyChanged("IP_ADDR_CURR");
                    this.OnIP_ADDR_CURRChanged();
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

        [Association(Name = "GBL_SESSION_GBL_SESSIONLOG", Storage = "_GBL_SESSIONLOGs", ThisKey = "SESSION_ID", OtherKey = "SESSION_ID")]
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

        [Association(Name = "GBL_ENV_GBL_SESSION", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_SESSIONs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SESSIONs.Add(this);
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

        [Association(Name = "HR_EMP_GBL_SESSION", Storage = "_HR_EMP", ThisKey = "EMP_ID", OtherKey = "EMP_ID", IsForeignKey = true)]
        public HR_EMP HR_EMP
        {
            get
            {
                return this._HR_EMP.Entity;
            }
            set
            {
                HR_EMP previousValue = this._HR_EMP.Entity;
                if (((previousValue != value)
                            || (this._HR_EMP.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_EMP.Entity = null;
                        previousValue.GBL_SESSIONs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SESSIONs.Add(this);
                        this._EMP_ID = value.EMP_ID;
                    }
                    else
                    {
                        this._EMP_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP");
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

        private void attach_GBL_SESSIONLOGs(GBL_SESSIONLOG entity)
        {
            this.SendPropertyChanging();
            entity.GBL_SESSION = this;
        }

        private void detach_GBL_SESSIONLOGs(GBL_SESSIONLOG entity)
        {
            this.SendPropertyChanging();
            entity.GBL_SESSION = null;
        }
    }
}
