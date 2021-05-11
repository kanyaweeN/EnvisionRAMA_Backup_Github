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
    [Table(Name = "dbo.INV_VENDOR")]
    public partial class INV_VENDOR : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _VENDOR_ID;

        private string _VENDOR_UID;

        private string _VENDOR_NAME;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<INV_ITEM> _INV_ITEMs;

        private EntitySet<INV_PO> _INV_POs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnVENDOR_IDChanging(int value);
        partial void OnVENDOR_IDChanged();
        partial void OnVENDOR_UIDChanging(string value);
        partial void OnVENDOR_UIDChanged();
        partial void OnVENDOR_NAMEChanging(string value);
        partial void OnVENDOR_NAMEChanged();
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

        public INV_VENDOR()
        {
            this._INV_ITEMs = new EntitySet<INV_ITEM>(new Action<INV_ITEM>(this.attach_INV_ITEMs), new Action<INV_ITEM>(this.detach_INV_ITEMs));
            this._INV_POs = new EntitySet<INV_PO>(new Action<INV_PO>(this.attach_INV_POs), new Action<INV_PO>(this.detach_INV_POs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_VENDOR_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int VENDOR_ID
        {
            get
            {
                return this._VENDOR_ID;
            }
            set
            {
                if ((this._VENDOR_ID != value))
                {
                    this.OnVENDOR_IDChanging(value);
                    this.SendPropertyChanging();
                    this._VENDOR_ID = value;
                    this.SendPropertyChanged("VENDOR_ID");
                    this.OnVENDOR_IDChanged();
                }
            }
        }

        [Column(Storage = "_VENDOR_UID", DbType = "NVarChar(30)")]
        public string VENDOR_UID
        {
            get
            {
                return this._VENDOR_UID;
            }
            set
            {
                if ((this._VENDOR_UID != value))
                {
                    this.OnVENDOR_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._VENDOR_UID = value;
                    this.SendPropertyChanged("VENDOR_UID");
                    this.OnVENDOR_UIDChanged();
                }
            }
        }

        [Column(Storage = "_VENDOR_NAME", DbType = "NVarChar(250)")]
        public string VENDOR_NAME
        {
            get
            {
                return this._VENDOR_NAME;
            }
            set
            {
                if ((this._VENDOR_NAME != value))
                {
                    this.OnVENDOR_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._VENDOR_NAME = value;
                    this.SendPropertyChanged("VENDOR_NAME");
                    this.OnVENDOR_NAMEChanged();
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

        [Association(Name = "INV_VENDOR_INV_ITEM", Storage = "_INV_ITEMs", ThisKey = "VENDOR_ID", OtherKey = "VENDOR_ID")]
        public EntitySet<INV_ITEM> INV_ITEMs
        {
            get
            {
                return this._INV_ITEMs;
            }
            set
            {
                this._INV_ITEMs.Assign(value);
            }
        }

        [Association(Name = "INV_VENDOR_INV_PO", Storage = "_INV_POs", ThisKey = "VENDOR_ID", OtherKey = "VENDOR_ID")]
        public EntitySet<INV_PO> INV_POs
        {
            get
            {
                return this._INV_POs;
            }
            set
            {
                this._INV_POs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_VENDOR", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_VENDORs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_VENDORs.Add(this);
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

        private void attach_INV_ITEMs(INV_ITEM entity)
        {
            this.SendPropertyChanging();
            entity.INV_VENDOR = this;
        }

        private void detach_INV_ITEMs(INV_ITEM entity)
        {
            this.SendPropertyChanging();
            entity.INV_VENDOR = null;
        }

        private void attach_INV_POs(INV_PO entity)
        {
            this.SendPropertyChanging();
            entity.INV_VENDOR = this;
        }

        private void detach_INV_POs(INV_PO entity)
        {
            this.SendPropertyChanging();
            entity.INV_VENDOR = null;
        }
    }
}
