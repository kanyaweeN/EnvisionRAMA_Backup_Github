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
    [Table(Name = "dbo.FIN_INVOICEDTL")]
    public partial class FIN_INVOICEDTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _INV_ID;

        private int _EXAM_ID;

        private int _ITEM_ID;

        private System.Nullable<byte> _QTY;

        private System.Nullable<decimal> _RATE;

        private System.Nullable<decimal> _DISCOUNT;

        private System.Nullable<decimal> _PAYABLE;

        private System.Nullable<char> _STATUS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _ORDER_ID;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnINV_IDChanging(long value);
        partial void OnINV_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnITEM_IDChanging(int value);
        partial void OnITEM_IDChanged();
        partial void OnQTYChanging(System.Nullable<byte> value);
        partial void OnQTYChanged();
        partial void OnRATEChanging(System.Nullable<decimal> value);
        partial void OnRATEChanged();
        partial void OnDISCOUNTChanging(System.Nullable<decimal> value);
        partial void OnDISCOUNTChanged();
        partial void OnPAYABLEChanging(System.Nullable<decimal> value);
        partial void OnPAYABLEChanged();
        partial void OnSTATUSChanging(System.Nullable<char> value);
        partial void OnSTATUSChanged();
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
        partial void OnORDER_IDChanging(System.Nullable<int> value);
        partial void OnORDER_IDChanged();
        #endregion

        public FIN_INVOICEDTL()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_INV_ID", DbType = "BigInt NOT NULL", IsPrimaryKey = true)]
        public long INV_ID
        {
            get
            {
                return this._INV_ID;
            }
            set
            {
                if ((this._INV_ID != value))
                {
                    this.OnINV_IDChanging(value);
                    this.SendPropertyChanging();
                    this._INV_ID = value;
                    this.SendPropertyChanged("INV_ID");
                    this.OnINV_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_ITEM_ID", DbType = "Int NOT NULL")]
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

        [Column(Storage = "_QTY", DbType = "TinyInt")]
        public System.Nullable<byte> QTY
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

        [Column(Storage = "_RATE", DbType = "Decimal(11,2)")]
        public System.Nullable<decimal> RATE
        {
            get
            {
                return this._RATE;
            }
            set
            {
                if ((this._RATE != value))
                {
                    this.OnRATEChanging(value);
                    this.SendPropertyChanging();
                    this._RATE = value;
                    this.SendPropertyChanged("RATE");
                    this.OnRATEChanged();
                }
            }
        }

        [Column(Storage = "_DISCOUNT", DbType = "Decimal(11,2)")]
        public System.Nullable<decimal> DISCOUNT
        {
            get
            {
                return this._DISCOUNT;
            }
            set
            {
                if ((this._DISCOUNT != value))
                {
                    this.OnDISCOUNTChanging(value);
                    this.SendPropertyChanging();
                    this._DISCOUNT = value;
                    this.SendPropertyChanged("DISCOUNT");
                    this.OnDISCOUNTChanged();
                }
            }
        }

        [Column(Storage = "_PAYABLE", DbType = "Decimal(11,2)")]
        public System.Nullable<decimal> PAYABLE
        {
            get
            {
                return this._PAYABLE;
            }
            set
            {
                if ((this._PAYABLE != value))
                {
                    this.OnPAYABLEChanging(value);
                    this.SendPropertyChanging();
                    this._PAYABLE = value;
                    this.SendPropertyChanged("PAYABLE");
                    this.OnPAYABLEChanged();
                }
            }
        }

        [Column(Storage = "_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> STATUS
        {
            get
            {
                return this._STATUS;
            }
            set
            {
                if ((this._STATUS != value))
                {
                    this.OnSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS = value;
                    this.SendPropertyChanged("STATUS");
                    this.OnSTATUSChanged();
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

        [Column(Storage = "_ORDER_ID", DbType = "Int")]
        public System.Nullable<int> ORDER_ID
        {
            get
            {
                return this._ORDER_ID;
            }
            set
            {
                if ((this._ORDER_ID != value))
                {
                    this.OnORDER_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_ID = value;
                    this.SendPropertyChanged("ORDER_ID");
                    this.OnORDER_IDChanged();
                }
            }
        }

        [Association(Name = "GBL_ENV_FIN_INVOICEDTL", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.FIN_INVOICEDTLs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.FIN_INVOICEDTLs.Add(this);
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
