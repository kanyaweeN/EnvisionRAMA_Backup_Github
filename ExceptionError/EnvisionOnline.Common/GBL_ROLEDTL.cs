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
    [Table(Name = "dbo.GBL_ROLEDTL")]
    public partial class GBL_ROLEDTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ROLEDTL_ID;

        private string _ROLEDTL_UID;

        private System.Nullable<int> _ROLE_ID;

        private System.Nullable<int> _SUBMENU_ID;

        private System.Nullable<char> _CAN_VIEW;

        private System.Nullable<char> _CAN_MODIFY;

        private System.Nullable<char> _CAN_REMOVE;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<char> _CAN_CREATE;

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
        partial void OnROLEDTL_IDChanging(int value);
        partial void OnROLEDTL_IDChanged();
        partial void OnROLEDTL_UIDChanging(string value);
        partial void OnROLEDTL_UIDChanged();
        partial void OnROLE_IDChanging(System.Nullable<int> value);
        partial void OnROLE_IDChanged();
        partial void OnSUBMENU_IDChanging(System.Nullable<int> value);
        partial void OnSUBMENU_IDChanged();
        partial void OnCAN_VIEWChanging(System.Nullable<char> value);
        partial void OnCAN_VIEWChanged();
        partial void OnCAN_MODIFYChanging(System.Nullable<char> value);
        partial void OnCAN_MODIFYChanged();
        partial void OnCAN_REMOVEChanging(System.Nullable<char> value);
        partial void OnCAN_REMOVEChanged();
        partial void OnIS_UPDATEDChanging(System.Nullable<char> value);
        partial void OnIS_UPDATEDChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
        partial void OnCAN_CREATEChanging(System.Nullable<char> value);
        partial void OnCAN_CREATEChanged();
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

        public GBL_ROLEDTL()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_ROLEDTL_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ROLEDTL_ID
        {
            get
            {
                return this._ROLEDTL_ID;
            }
            set
            {
                if ((this._ROLEDTL_ID != value))
                {
                    this.OnROLEDTL_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ROLEDTL_ID = value;
                    this.SendPropertyChanged("ROLEDTL_ID");
                    this.OnROLEDTL_IDChanged();
                }
            }
        }

        [Column(Storage = "_ROLEDTL_UID", DbType = "NVarChar(30)")]
        public string ROLEDTL_UID
        {
            get
            {
                return this._ROLEDTL_UID;
            }
            set
            {
                if ((this._ROLEDTL_UID != value))
                {
                    this.OnROLEDTL_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._ROLEDTL_UID = value;
                    this.SendPropertyChanged("ROLEDTL_UID");
                    this.OnROLEDTL_UIDChanged();
                }
            }
        }

        [Column(Storage = "_ROLE_ID", DbType = "Int")]
        public System.Nullable<int> ROLE_ID
        {
            get
            {
                return this._ROLE_ID;
            }
            set
            {
                if ((this._ROLE_ID != value))
                {
                    this.OnROLE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ROLE_ID = value;
                    this.SendPropertyChanged("ROLE_ID");
                    this.OnROLE_IDChanged();
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

        [Column(Storage = "_CAN_VIEW", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_VIEW
        {
            get
            {
                return this._CAN_VIEW;
            }
            set
            {
                if ((this._CAN_VIEW != value))
                {
                    this.OnCAN_VIEWChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_VIEW = value;
                    this.SendPropertyChanged("CAN_VIEW");
                    this.OnCAN_VIEWChanged();
                }
            }
        }

        [Column(Storage = "_CAN_MODIFY", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_MODIFY
        {
            get
            {
                return this._CAN_MODIFY;
            }
            set
            {
                if ((this._CAN_MODIFY != value))
                {
                    this.OnCAN_MODIFYChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_MODIFY = value;
                    this.SendPropertyChanged("CAN_MODIFY");
                    this.OnCAN_MODIFYChanged();
                }
            }
        }

        [Column(Storage = "_CAN_REMOVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_REMOVE
        {
            get
            {
                return this._CAN_REMOVE;
            }
            set
            {
                if ((this._CAN_REMOVE != value))
                {
                    this.OnCAN_REMOVEChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_REMOVE = value;
                    this.SendPropertyChanged("CAN_REMOVE");
                    this.OnCAN_REMOVEChanged();
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

        [Column(Storage = "_CAN_CREATE", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_CREATE
        {
            get
            {
                return this._CAN_CREATE;
            }
            set
            {
                if ((this._CAN_CREATE != value))
                {
                    this.OnCAN_CREATEChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_CREATE = value;
                    this.SendPropertyChanged("CAN_CREATE");
                    this.OnCAN_CREATEChanged();
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

        [Association(Name = "GBL_ENV_GBL_ROLEDTL", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_ROLEDTLs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_ROLEDTLs.Add(this);
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
