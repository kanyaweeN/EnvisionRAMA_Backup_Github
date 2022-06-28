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
    [Table(Name = "dbo.INV_CATEGORY")]
    public partial class INV_CATEGORY : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _CATEGORY_ID;

        private string _CATEGORY_UID;

        private string _CATEGORY_NAME;

        private string _CATEGORY_DESC;

        private System.Nullable<int> _PARENT;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<INV_ITEM> _INV_ITEMs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnCATEGORY_IDChanging(int value);
        partial void OnCATEGORY_IDChanged();
        partial void OnCATEGORY_UIDChanging(string value);
        partial void OnCATEGORY_UIDChanged();
        partial void OnCATEGORY_NAMEChanging(string value);
        partial void OnCATEGORY_NAMEChanged();
        partial void OnCATEGORY_DESCChanging(string value);
        partial void OnCATEGORY_DESCChanged();
        partial void OnPARENTChanging(System.Nullable<int> value);
        partial void OnPARENTChanged();
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

        public INV_CATEGORY()
        {
            this._INV_ITEMs = new EntitySet<INV_ITEM>(new Action<INV_ITEM>(this.attach_INV_ITEMs), new Action<INV_ITEM>(this.detach_INV_ITEMs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_CATEGORY_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int CATEGORY_ID
        {
            get
            {
                return this._CATEGORY_ID;
            }
            set
            {
                if ((this._CATEGORY_ID != value))
                {
                    this.OnCATEGORY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CATEGORY_ID = value;
                    this.SendPropertyChanged("CATEGORY_ID");
                    this.OnCATEGORY_IDChanged();
                }
            }
        }

        [Column(Storage = "_CATEGORY_UID", DbType = "NVarChar(30)")]
        public string CATEGORY_UID
        {
            get
            {
                return this._CATEGORY_UID;
            }
            set
            {
                if ((this._CATEGORY_UID != value))
                {
                    this.OnCATEGORY_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._CATEGORY_UID = value;
                    this.SendPropertyChanged("CATEGORY_UID");
                    this.OnCATEGORY_UIDChanged();
                }
            }
        }

        [Column(Storage = "_CATEGORY_NAME", DbType = "NVarChar(100)")]
        public string CATEGORY_NAME
        {
            get
            {
                return this._CATEGORY_NAME;
            }
            set
            {
                if ((this._CATEGORY_NAME != value))
                {
                    this.OnCATEGORY_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._CATEGORY_NAME = value;
                    this.SendPropertyChanged("CATEGORY_NAME");
                    this.OnCATEGORY_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_CATEGORY_DESC", DbType = "NVarChar(250)")]
        public string CATEGORY_DESC
        {
            get
            {
                return this._CATEGORY_DESC;
            }
            set
            {
                if ((this._CATEGORY_DESC != value))
                {
                    this.OnCATEGORY_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._CATEGORY_DESC = value;
                    this.SendPropertyChanged("CATEGORY_DESC");
                    this.OnCATEGORY_DESCChanged();
                }
            }
        }

        [Column(Storage = "_PARENT", DbType = "Int")]
        public System.Nullable<int> PARENT
        {
            get
            {
                return this._PARENT;
            }
            set
            {
                if ((this._PARENT != value))
                {
                    this.OnPARENTChanging(value);
                    this.SendPropertyChanging();
                    this._PARENT = value;
                    this.SendPropertyChanged("PARENT");
                    this.OnPARENTChanged();
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

        [Association(Name = "INV_CATEGORY_INV_ITEM", Storage = "_INV_ITEMs", ThisKey = "CATEGORY_ID", OtherKey = "CATEGORY_ID")]
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

        [Association(Name = "GBL_ENV_INV_CATEGORY", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_CATEGORies.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_CATEGORies.Add(this);
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
            entity.INV_CATEGORY = this;
        }

        private void detach_INV_ITEMs(INV_ITEM entity)
        {
            this.SendPropertyChanging();
            entity.INV_CATEGORY = null;
        }
    }
}
