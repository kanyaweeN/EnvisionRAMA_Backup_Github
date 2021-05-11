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
    [Table(Name = "dbo.INV_TRANSACTIONDTL")]
    public partial class INV_TRANSACTIONDTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _TXNDTL_ID;

        private int _TXN_ID;

        private int _ITEM_ID;

        private System.Nullable<int> _TXN_UNIT;

        private int _BATCH;

        private System.Nullable<System.DateTime> _EXPIRY_DT;

        private System.Nullable<decimal> _QTY;

        private System.Nullable<decimal> _PRICE;

        private string _COMMENTS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<INV_TXNUNIT> _INV_TXNUNIT;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnTXNDTL_IDChanging(int value);
        partial void OnTXNDTL_IDChanged();
        partial void OnTXN_IDChanging(int value);
        partial void OnTXN_IDChanged();
        partial void OnITEM_IDChanging(int value);
        partial void OnITEM_IDChanged();
        partial void OnTXN_UNITChanging(System.Nullable<int> value);
        partial void OnTXN_UNITChanged();
        partial void OnBATCHChanging(int value);
        partial void OnBATCHChanged();
        partial void OnEXPIRY_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnEXPIRY_DTChanged();
        partial void OnQTYChanging(System.Nullable<decimal> value);
        partial void OnQTYChanged();
        partial void OnPRICEChanging(System.Nullable<decimal> value);
        partial void OnPRICEChanged();
        partial void OnCOMMENTSChanging(string value);
        partial void OnCOMMENTSChanged();
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

        public INV_TRANSACTIONDTL()
        {
            this._INV_TXNUNIT = default(EntityRef<INV_TXNUNIT>);
            OnCreated();
        }

        [Column(Storage = "_TXNDTL_ID", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int TXNDTL_ID
        {
            get
            {
                return this._TXNDTL_ID;
            }
            set
            {
                if ((this._TXNDTL_ID != value))
                {
                    this.OnTXNDTL_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TXNDTL_ID = value;
                    this.SendPropertyChanged("TXNDTL_ID");
                    this.OnTXNDTL_IDChanged();
                }
            }
        }

        [Column(Storage = "_TXN_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int TXN_ID
        {
            get
            {
                return this._TXN_ID;
            }
            set
            {
                if ((this._TXN_ID != value))
                {
                    if (this._INV_TXNUNIT.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTXN_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TXN_ID = value;
                    this.SendPropertyChanged("TXN_ID");
                    this.OnTXN_IDChanged();
                }
            }
        }

        [Column(Storage = "_ITEM_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int ITEM_ID
        {
            get
            {
                return this._ITEM_ID;
            }
            set
            {
                if ((this._ITEM_ID != value))
                {
                    this.OnITEM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_ID = value;
                    this.SendPropertyChanged("ITEM_ID");
                    this.OnITEM_IDChanged();
                }
            }
        }

        [Column(Storage = "_TXN_UNIT", DbType = "Int")]
        public System.Nullable<int> TXN_UNIT
        {
            get
            {
                return this._TXN_UNIT;
            }
            set
            {
                if ((this._TXN_UNIT != value))
                {
                    this.OnTXN_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._TXN_UNIT = value;
                    this.SendPropertyChanged("TXN_UNIT");
                    this.OnTXN_UNITChanged();
                }
            }
        }

        [Column(Storage = "_BATCH", DbType = "int")]
        public int BATCH
        {
            get
            {
                return this._BATCH;
            }
            set
            {
                if ((this._BATCH != value))
                {
                    this.OnBATCHChanging(value);
                    this.SendPropertyChanging();
                    this._BATCH = value;
                    this.SendPropertyChanged("BATCH");
                    this.OnBATCHChanged();
                }
            }
        }

        [Column(Storage = "_EXPIRY_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EXPIRY_DT
        {
            get
            {
                return this._EXPIRY_DT;
            }
            set
            {
                if ((this._EXPIRY_DT != value))
                {
                    this.OnEXPIRY_DTChanging(value);
                    this.SendPropertyChanging();
                    this._EXPIRY_DT = value;
                    this.SendPropertyChanged("EXPIRY_DT");
                    this.OnEXPIRY_DTChanged();
                }
            }
        }

        [Column(Storage = "_QTY", DbType = "Decimal(9,2)")]
        public System.Nullable<decimal> QTY
        {
            get
            {
                return this._QTY;
            }
            set
            {
                if ((this._QTY != value))
                {
                    this.OnQTYChanging(value);
                    this.SendPropertyChanging();
                    this._QTY = value;
                    this.SendPropertyChanged("QTY");
                    this.OnQTYChanged();
                }
            }
        }

        [Column(Storage = "_PRICE", DbType = "Decimal(9,2)")]
        public System.Nullable<decimal> PRICE
        {
            get
            {
                return this._PRICE;
            }
            set
            {
                if ((this._PRICE != value))
                {
                    this.OnPRICEChanging(value);
                    this.SendPropertyChanging();
                    this._PRICE = value;
                    this.SendPropertyChanged("PRICE");
                    this.OnPRICEChanged();
                }
            }
        }

        [Column(Storage = "_COMMENTS", DbType = "NVarChar(200)")]
        public string COMMENTS
        {
            get
            {
                return this._COMMENTS;
            }
            set
            {
                if ((this._COMMENTS != value))
                {
                    this.OnCOMMENTSChanging(value);
                    this.SendPropertyChanging();
                    this._COMMENTS = value;
                    this.SendPropertyChanged("COMMENTS");
                    this.OnCOMMENTSChanged();
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

        [Association(Name = "INV_TXNUNIT_INV_TRANSACTIONDTL", Storage = "_INV_TXNUNIT", ThisKey = "TXN_ID", OtherKey = "TXN_UNIT_ID", IsForeignKey = true)]
        public INV_TXNUNIT INV_TXNUNIT
        {
            get
            {
                return this._INV_TXNUNIT.Entity;
            }
            set
            {
                INV_TXNUNIT previousValue = this._INV_TXNUNIT.Entity;
                if (((previousValue != value)
                            || (this._INV_TXNUNIT.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_TXNUNIT.Entity = null;
                        previousValue.INV_TRANSACTIONDTLs.Remove(this);
                    }
                    this._INV_TXNUNIT.Entity = value;
                    if ((value != null))
                    {
                        value.INV_TRANSACTIONDTLs.Add(this);
                        this._TXN_ID = value.TXN_UNIT_ID;
                    }
                    else
                    {
                        this._TXN_ID = default(int);
                    }
                    this.SendPropertyChanged("INV_TXNUNIT");
                }
            }
        }
        public int REF_ITEM_ID { get; set; }
        public int ITEMSTOCK_ID { get; set; }

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
