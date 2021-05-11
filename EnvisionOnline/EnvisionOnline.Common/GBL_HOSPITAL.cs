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
    [Table(Name = "dbo.GBL_HOSPITAL")]
    public partial class GBL_HOSPITAL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _HOS_ID;

        private string _HOS_UID;

        private string _HOS_NAME;

        private string _HOS_NAME_ALIAS;

        private string _PHONE_NO;

        private string _DESCR;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _ORG_ID;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnHOS_IDChanging(int value);
        partial void OnHOS_IDChanged();
        partial void OnHOS_UIDChanging(string value);
        partial void OnHOS_UIDChanged();
        partial void OnHOS_NAMEChanging(string value);
        partial void OnHOS_NAMEChanged();
        partial void OnHOS_NAME_ALIASChanging(string value);
        partial void OnHOS_NAME_ALIASChanged();
        partial void OnPHONE_NOChanging(string value);
        partial void OnPHONE_NOChanged();
        partial void OnDESCRChanging(string value);
        partial void OnDESCRChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        #endregion

        public GBL_HOSPITAL()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_HOS_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int HOS_ID
        {
            get
            {
                return this._HOS_ID;
            }
            set
            {
                if ((this._HOS_ID != value))
                {
                    this.OnHOS_IDChanging(value);
                    this.SendPropertyChanging();
                    this._HOS_ID = value;
                    this.SendPropertyChanged("HOS_ID");
                    this.OnHOS_IDChanged();
                }
            }
        }

        [Column(Storage = "_HOS_UID", DbType = "NVarChar(30)")]
        public string HOS_UID
        {
            get
            {
                return this._HOS_UID;
            }
            set
            {
                if ((this._HOS_UID != value))
                {
                    this.OnHOS_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._HOS_UID = value;
                    this.SendPropertyChanged("HOS_UID");
                    this.OnHOS_UIDChanged();
                }
            }
        }

        [Column(Storage = "_HOS_NAME", DbType = "NVarChar(500)")]
        public string HOS_NAME
        {
            get
            {
                return this._HOS_NAME;
            }
            set
            {
                if ((this._HOS_NAME != value))
                {
                    this.OnHOS_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._HOS_NAME = value;
                    this.SendPropertyChanged("HOS_NAME");
                    this.OnHOS_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_HOS_NAME_ALIAS", DbType = "NVarChar(100)")]
        public string HOS_NAME_ALIAS
        {
            get
            {
                return this._HOS_NAME_ALIAS;
            }
            set
            {
                if ((this._HOS_NAME_ALIAS != value))
                {
                    this.OnHOS_NAME_ALIASChanging(value);
                    this.SendPropertyChanging();
                    this._HOS_NAME_ALIAS = value;
                    this.SendPropertyChanged("HOS_NAME_ALIAS");
                    this.OnHOS_NAME_ALIASChanged();
                }
            }
        }

        [Column(Storage = "_PHONE_NO", DbType = "NVarChar(50)")]
        public string PHONE_NO
        {
            get
            {
                return this._PHONE_NO;
            }
            set
            {
                if ((this._PHONE_NO != value))
                {
                    this.OnPHONE_NOChanging(value);
                    this.SendPropertyChanging();
                    this._PHONE_NO = value;
                    this.SendPropertyChanged("PHONE_NO");
                    this.OnPHONE_NOChanged();
                }
            }
        }

        [Column(Storage = "_DESCR", DbType = "NVarChar(500)")]
        public string DESCR
        {
            get
            {
                return this._DESCR;
            }
            set
            {
                if ((this._DESCR != value))
                {
                    this.OnDESCRChanging(value);
                    this.SendPropertyChanging();
                    this._DESCR = value;
                    this.SendPropertyChanged("DESCR");
                    this.OnDESCRChanged();
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

        [Association(Name = "GBL_ENV_GBL_HOSPITAL", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_HOSPITALs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_HOSPITALs.Add(this);
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

        public int PERCENT_DISCOUNT { get; set; }
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
