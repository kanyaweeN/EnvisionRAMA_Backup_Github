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
    [Table(Name = "dbo.INV_PO")]
    public partial class INV_PO : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _PO_ID;

        private string _PO_UID;

        private System.Nullable<int> _PR_ID;

        private System.Nullable<System.DateTime> _GENERATED_ON;

        private System.Nullable<int> _VENDOR_ID;

        private string _TOC;

        private System.Nullable<char> _PO_STATUS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<INV_PODTL> _INV_PODTLs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<INV_VENDOR> _INV_VENDOR;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnPO_IDChanging(int value);
        partial void OnPO_IDChanged();
        partial void OnPO_UIDChanging(string value);
        partial void OnPO_UIDChanged();
        partial void OnPR_IDChanging(System.Nullable<int> value);
        partial void OnPR_IDChanged();
        partial void OnGENERATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnGENERATED_ONChanged();
        partial void OnVENDOR_IDChanging(System.Nullable<int> value);
        partial void OnVENDOR_IDChanged();
        partial void OnTOCChanging(string value);
        partial void OnTOCChanged();
        partial void OnPO_STATUSChanging(System.Nullable<char> value);
        partial void OnPO_STATUSChanged();
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

        public INV_PO()
        {
            this._INV_PODTLs = new EntitySet<INV_PODTL>(new Action<INV_PODTL>(this.attach_INV_PODTLs), new Action<INV_PODTL>(this.detach_INV_PODTLs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._INV_VENDOR = default(EntityRef<INV_VENDOR>);
            OnCreated();
        }

        [Column(Storage = "_PO_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int PO_ID
        {
            get
            {
                return this._PO_ID;
            }
            set
            {
                if ((this._PO_ID != value))
                {
                    this.OnPO_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PO_ID = value;
                    this.SendPropertyChanged("PO_ID");
                    this.OnPO_IDChanged();
                }
            }
        }

        [Column(Storage = "_PO_UID", DbType = "NVarChar(50)")]
        public string PO_UID
        {
            get
            {
                return this._PO_UID;
            }
            set
            {
                if ((this._PO_UID != value))
                {
                    this.OnPO_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._PO_UID = value;
                    this.SendPropertyChanged("PO_UID");
                    this.OnPO_UIDChanged();
                }
            }
        }

        [Column(Storage = "_PR_ID", DbType = "Int")]
        public System.Nullable<int> PR_ID
        {
            get
            {
                return this._PR_ID;
            }
            set
            {
                if ((this._PR_ID != value))
                {
                    this.OnPR_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PR_ID = value;
                    this.SendPropertyChanged("PR_ID");
                    this.OnPR_IDChanged();
                }
            }
        }

        [Column(Storage = "_GENERATED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> GENERATED_ON
        {
            get
            {
                return this._GENERATED_ON;
            }
            set
            {
                if ((this._GENERATED_ON != value))
                {
                    this.OnGENERATED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._GENERATED_ON = value;
                    this.SendPropertyChanged("GENERATED_ON");
                    this.OnGENERATED_ONChanged();
                }
            }
        }

        [Column(Storage = "_VENDOR_ID", DbType = "Int")]
        public System.Nullable<int> VENDOR_ID
        {
            get
            {
                return this._VENDOR_ID;
            }
            set
            {
                if ((this._VENDOR_ID != value))
                {
                    if (this._INV_VENDOR.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnVENDOR_IDChanging(value);
                    this.SendPropertyChanging();
                    this._VENDOR_ID = value;
                    this.SendPropertyChanged("VENDOR_ID");
                    this.OnVENDOR_IDChanged();
                }
            }
        }

        [Column(Storage = "_TOC", DbType = "NVarChar(4000)")]
        public string TOC
        {
            get
            {
                return this._TOC;
            }
            set
            {
                if ((this._TOC != value))
                {
                    this.OnTOCChanging(value);
                    this.SendPropertyChanging();
                    this._TOC = value;
                    this.SendPropertyChanged("TOC");
                    this.OnTOCChanged();
                }
            }
        }

        [Column(Storage = "_PO_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> PO_STATUS
        {
            get
            {
                return this._PO_STATUS;
            }
            set
            {
                if ((this._PO_STATUS != value))
                {
                    this.OnPO_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._PO_STATUS = value;
                    this.SendPropertyChanged("PO_STATUS");
                    this.OnPO_STATUSChanged();
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

        [Association(Name = "INV_PO_INV_PODTL", Storage = "_INV_PODTLs", ThisKey = "PO_ID", OtherKey = "PO_ID")]
        public EntitySet<INV_PODTL> INV_PODTLs
        {
            get
            {
                return this._INV_PODTLs;
            }
            set
            {
                this._INV_PODTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_PO", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_POs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_POs.Add(this);
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

        [Association(Name = "INV_VENDOR_INV_PO", Storage = "_INV_VENDOR", ThisKey = "VENDOR_ID", OtherKey = "VENDOR_ID", IsForeignKey = true)]
        public INV_VENDOR INV_VENDOR
        {
            get
            {
                return this._INV_VENDOR.Entity;
            }
            set
            {
                INV_VENDOR previousValue = this._INV_VENDOR.Entity;
                if (((previousValue != value)
                            || (this._INV_VENDOR.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_VENDOR.Entity = null;
                        previousValue.INV_POs.Remove(this);
                    }
                    this._INV_VENDOR.Entity = value;
                    if ((value != null))
                    {
                        value.INV_POs.Add(this);
                        this._VENDOR_ID = value.VENDOR_ID;
                    }
                    else
                    {
                        this._VENDOR_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("INV_VENDOR");
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

        private void attach_INV_PODTLs(INV_PODTL entity)
        {
            this.SendPropertyChanging();
            entity.INV_PO = this;
        }

        private void detach_INV_PODTLs(INV_PODTL entity)
        {
            this.SendPropertyChanging();
            entity.INV_PO = null;
        }
    }
}
