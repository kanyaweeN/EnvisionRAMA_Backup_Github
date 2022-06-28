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
    [Table(Name = "dbo.INV_TXNUNIT")]
    public partial class INV_TXNUNIT : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _TXN_UNIT_ID;

        private string _TXN_UNIT_UID;

        private string _TXN_UNIT_NAME;

        private string _TXN_UNIT_DESC;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<INV_TRANSACTIONDTL> _INV_TRANSACTIONDTLs;

        private EntityRef<INV_TXNUNIT> _INV_TXNUNIT2;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<INV_TXNUNIT> _INV_TXNUNIT1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnTXN_UNIT_IDChanging(int value);
        partial void OnTXN_UNIT_IDChanged();
        partial void OnTXN_UNIT_UIDChanging(string value);
        partial void OnTXN_UNIT_UIDChanged();
        partial void OnTXN_UNIT_NAMEChanging(string value);
        partial void OnTXN_UNIT_NAMEChanged();
        partial void OnTXN_UNIT_DESCChanging(string value);
        partial void OnTXN_UNIT_DESCChanged();
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

        public INV_TXNUNIT()
        {
            this._INV_TRANSACTIONDTLs = new EntitySet<INV_TRANSACTIONDTL>(new Action<INV_TRANSACTIONDTL>(this.attach_INV_TRANSACTIONDTLs), new Action<INV_TRANSACTIONDTL>(this.detach_INV_TRANSACTIONDTLs));
            this._INV_TXNUNIT2 = default(EntityRef<INV_TXNUNIT>);
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._INV_TXNUNIT1 = default(EntityRef<INV_TXNUNIT>);
            OnCreated();
        }

        [Column(Storage = "_TXN_UNIT_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int TXN_UNIT_ID
        {
            get
            {
                return this._TXN_UNIT_ID;
            }
            set
            {
                if ((this._TXN_UNIT_ID != value))
                {
                    if (this._INV_TXNUNIT1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTXN_UNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TXN_UNIT_ID = value;
                    this.SendPropertyChanged("TXN_UNIT_ID");
                    this.OnTXN_UNIT_IDChanged();
                }
            }
        }

        [Column(Storage = "_TXN_UNIT_UID", DbType = "NVarChar(30)")]
        public string TXN_UNIT_UID
        {
            get
            {
                return this._TXN_UNIT_UID;
            }
            set
            {
                if ((this._TXN_UNIT_UID != value))
                {
                    this.OnTXN_UNIT_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._TXN_UNIT_UID = value;
                    this.SendPropertyChanged("TXN_UNIT_UID");
                    this.OnTXN_UNIT_UIDChanged();
                }
            }
        }

        [Column(Storage = "_TXN_UNIT_NAME", DbType = "NVarChar(100)")]
        public string TXN_UNIT_NAME
        {
            get
            {
                return this._TXN_UNIT_NAME;
            }
            set
            {
                if ((this._TXN_UNIT_NAME != value))
                {
                    this.OnTXN_UNIT_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._TXN_UNIT_NAME = value;
                    this.SendPropertyChanged("TXN_UNIT_NAME");
                    this.OnTXN_UNIT_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_TXN_UNIT_DESC", DbType = "NVarChar(250)")]
        public string TXN_UNIT_DESC
        {
            get
            {
                return this._TXN_UNIT_DESC;
            }
            set
            {
                if ((this._TXN_UNIT_DESC != value))
                {
                    this.OnTXN_UNIT_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._TXN_UNIT_DESC = value;
                    this.SendPropertyChanged("TXN_UNIT_DESC");
                    this.OnTXN_UNIT_DESCChanged();
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

        [Association(Name = "INV_TXNUNIT_INV_TRANSACTIONDTL", Storage = "_INV_TRANSACTIONDTLs", ThisKey = "TXN_UNIT_ID", OtherKey = "TXN_ID")]
        public EntitySet<INV_TRANSACTIONDTL> INV_TRANSACTIONDTLs
        {
            get
            {
                return this._INV_TRANSACTIONDTLs;
            }
            set
            {
                this._INV_TRANSACTIONDTLs.Assign(value);
            }
        }

        [Association(Name = "INV_TXNUNIT_INV_TXNUNIT", Storage = "_INV_TXNUNIT2", ThisKey = "TXN_UNIT_ID", OtherKey = "TXN_UNIT_ID", IsUnique = true, IsForeignKey = false)]
        public INV_TXNUNIT INV_TXNUNIT2
        {
            get
            {
                return this._INV_TXNUNIT2.Entity;
            }
            set
            {
                INV_TXNUNIT previousValue = this._INV_TXNUNIT2.Entity;
                if (((previousValue != value)
                            || (this._INV_TXNUNIT2.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_TXNUNIT2.Entity = null;
                        previousValue.INV_TXNUNIT1 = null;
                    }
                    this._INV_TXNUNIT2.Entity = value;
                    if ((value != null))
                    {
                        value.INV_TXNUNIT1 = this;
                    }
                    this.SendPropertyChanged("INV_TXNUNIT2");
                }
            }
        }

        [Association(Name = "GBL_ENV_INV_TXNUNIT", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_TXNUNITs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_TXNUNITs.Add(this);
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

        [Association(Name = "INV_TXNUNIT_INV_TXNUNIT", Storage = "_INV_TXNUNIT1", ThisKey = "TXN_UNIT_ID", OtherKey = "TXN_UNIT_ID", IsForeignKey = true)]
        public INV_TXNUNIT INV_TXNUNIT1
        {
            get
            {
                return this._INV_TXNUNIT1.Entity;
            }
            set
            {
                INV_TXNUNIT previousValue = this._INV_TXNUNIT1.Entity;
                if (((previousValue != value)
                            || (this._INV_TXNUNIT1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_TXNUNIT1.Entity = null;
                        previousValue.INV_TXNUNIT2 = null;
                    }
                    this._INV_TXNUNIT1.Entity = value;
                    if ((value != null))
                    {
                        value.INV_TXNUNIT2 = this;
                        this._TXN_UNIT_ID = value.TXN_UNIT_ID;
                    }
                    else
                    {
                        this._TXN_UNIT_ID = default(int);
                    }
                    this.SendPropertyChanged("INV_TXNUNIT1");
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

        private void attach_INV_TRANSACTIONDTLs(INV_TRANSACTIONDTL entity)
        {
            this.SendPropertyChanging();
            entity.INV_TXNUNIT = this;
        }

        private void detach_INV_TRANSACTIONDTLs(INV_TRANSACTIONDTL entity)
        {
            this.SendPropertyChanging();
            entity.INV_TXNUNIT = null;
        }
    }
}
