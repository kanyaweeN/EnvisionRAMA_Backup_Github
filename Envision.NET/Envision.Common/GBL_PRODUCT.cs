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
    [Table(Name = "dbo.GBL_PRODUCT")]
    public partial class GBL_PRODUCT : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _PROD_ID;

        private string _PROD_UID;

        private string _PROD_NAME;

        private string _PROD_DESCR;

        private string _PROD_VERSION;

        private System.Nullable<System.DateTime> _RELEASE_DT;

        private System.Nullable<char> _PROD_TYPE;

        private string _LICENSED_TO;

        private System.Nullable<char> _LICENSE_TYPE;

        private System.Nullable<System.DateTime> _VALID_UNTIL;

        private System.Nullable<char> _FORCE_LICENSE;

        private string _COPY_RIGHT;

        private System.Nullable<int> _ORG_ID;

        private string _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private string _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnPROD_IDChanging(int value);
        partial void OnPROD_IDChanged();
        partial void OnPROD_UIDChanging(string value);
        partial void OnPROD_UIDChanged();
        partial void OnPROD_NAMEChanging(string value);
        partial void OnPROD_NAMEChanged();
        partial void OnPROD_DESCRChanging(string value);
        partial void OnPROD_DESCRChanged();
        partial void OnPROD_VERSIONChanging(string value);
        partial void OnPROD_VERSIONChanged();
        partial void OnRELEASE_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnRELEASE_DTChanged();
        partial void OnPROD_TYPEChanging(System.Nullable<char> value);
        partial void OnPROD_TYPEChanged();
        partial void OnLICENSED_TOChanging(string value);
        partial void OnLICENSED_TOChanged();
        partial void OnLICENSE_TYPEChanging(System.Nullable<char> value);
        partial void OnLICENSE_TYPEChanged();
        partial void OnVALID_UNTILChanging(System.Nullable<System.DateTime> value);
        partial void OnVALID_UNTILChanged();
        partial void OnFORCE_LICENSEChanging(System.Nullable<char> value);
        partial void OnFORCE_LICENSEChanged();
        partial void OnCOPY_RIGHTChanging(string value);
        partial void OnCOPY_RIGHTChanged();
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
        #endregion

        public GBL_PRODUCT()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_PROD_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int PROD_ID
        {
            get
            {
                return this._PROD_ID;
            }
            set
            {
                if ((this._PROD_ID != value))
                {
                    this.OnPROD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PROD_ID = value;
                    this.SendPropertyChanged("PROD_ID");
                    this.OnPROD_IDChanged();
                }
            }
        }

        [Column(Storage = "_PROD_UID", DbType = "NVarChar(30)")]
        public string PROD_UID
        {
            get
            {
                return this._PROD_UID;
            }
            set
            {
                if ((this._PROD_UID != value))
                {
                    this.OnPROD_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._PROD_UID = value;
                    this.SendPropertyChanged("PROD_UID");
                    this.OnPROD_UIDChanged();
                }
            }
        }

        [Column(Storage = "_PROD_NAME", DbType = "NVarChar(200)")]
        public string PROD_NAME
        {
            get
            {
                return this._PROD_NAME;
            }
            set
            {
                if ((this._PROD_NAME != value))
                {
                    this.OnPROD_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._PROD_NAME = value;
                    this.SendPropertyChanged("PROD_NAME");
                    this.OnPROD_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_PROD_DESCR", DbType = "NVarChar(2000)")]
        public string PROD_DESCR
        {
            get
            {
                return this._PROD_DESCR;
            }
            set
            {
                if ((this._PROD_DESCR != value))
                {
                    this.OnPROD_DESCRChanging(value);
                    this.SendPropertyChanging();
                    this._PROD_DESCR = value;
                    this.SendPropertyChanged("PROD_DESCR");
                    this.OnPROD_DESCRChanged();
                }
            }
        }

        [Column(Storage = "_PROD_VERSION", DbType = "NVarChar(50)")]
        public string PROD_VERSION
        {
            get
            {
                return this._PROD_VERSION;
            }
            set
            {
                if ((this._PROD_VERSION != value))
                {
                    this.OnPROD_VERSIONChanging(value);
                    this.SendPropertyChanging();
                    this._PROD_VERSION = value;
                    this.SendPropertyChanged("PROD_VERSION");
                    this.OnPROD_VERSIONChanged();
                }
            }
        }

        [Column(Storage = "_RELEASE_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> RELEASE_DT
        {
            get
            {
                return this._RELEASE_DT;
            }
            set
            {
                if ((this._RELEASE_DT != value))
                {
                    this.OnRELEASE_DTChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASE_DT = value;
                    this.SendPropertyChanged("RELEASE_DT");
                    this.OnRELEASE_DTChanged();
                }
            }
        }

        [Column(Storage = "_PROD_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> PROD_TYPE
        {
            get
            {
                return this._PROD_TYPE;
            }
            set
            {
                if ((this._PROD_TYPE != value))
                {
                    this.OnPROD_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._PROD_TYPE = value;
                    this.SendPropertyChanged("PROD_TYPE");
                    this.OnPROD_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_LICENSED_TO", DbType = "NVarChar(100)")]
        public string LICENSED_TO
        {
            get
            {
                return this._LICENSED_TO;
            }
            set
            {
                if ((this._LICENSED_TO != value))
                {
                    this.OnLICENSED_TOChanging(value);
                    this.SendPropertyChanging();
                    this._LICENSED_TO = value;
                    this.SendPropertyChanged("LICENSED_TO");
                    this.OnLICENSED_TOChanged();
                }
            }
        }

        [Column(Storage = "_LICENSE_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> LICENSE_TYPE
        {
            get
            {
                return this._LICENSE_TYPE;
            }
            set
            {
                if ((this._LICENSE_TYPE != value))
                {
                    this.OnLICENSE_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._LICENSE_TYPE = value;
                    this.SendPropertyChanged("LICENSE_TYPE");
                    this.OnLICENSE_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_VALID_UNTIL", DbType = "DateTime")]
        public System.Nullable<System.DateTime> VALID_UNTIL
        {
            get
            {
                return this._VALID_UNTIL;
            }
            set
            {
                if ((this._VALID_UNTIL != value))
                {
                    this.OnVALID_UNTILChanging(value);
                    this.SendPropertyChanging();
                    this._VALID_UNTIL = value;
                    this.SendPropertyChanged("VALID_UNTIL");
                    this.OnVALID_UNTILChanged();
                }
            }
        }

        [Column(Storage = "_FORCE_LICENSE", DbType = "NVarChar(1)")]
        public System.Nullable<char> FORCE_LICENSE
        {
            get
            {
                return this._FORCE_LICENSE;
            }
            set
            {
                if ((this._FORCE_LICENSE != value))
                {
                    this.OnFORCE_LICENSEChanging(value);
                    this.SendPropertyChanging();
                    this._FORCE_LICENSE = value;
                    this.SendPropertyChanged("FORCE_LICENSE");
                    this.OnFORCE_LICENSEChanged();
                }
            }
        }

        [Column(Storage = "_COPY_RIGHT", DbType = "NVarChar(1000)")]
        public string COPY_RIGHT
        {
            get
            {
                return this._COPY_RIGHT;
            }
            set
            {
                if ((this._COPY_RIGHT != value))
                {
                    this.OnCOPY_RIGHTChanging(value);
                    this.SendPropertyChanging();
                    this._COPY_RIGHT = value;
                    this.SendPropertyChanged("COPY_RIGHT");
                    this.OnCOPY_RIGHTChanged();
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

        [Association(Name = "GBL_ENV_GBL_PRODUCT", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_PRODUCTs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_PRODUCTs.Add(this);
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
