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
    [Table(Name = "dbo.INV_ITEM")]
    public partial class INV_ITEM : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ITEM_ID;

        private string _ITEM_UID;

        private string _ITEM_NAME;

        private string _ITEM_DESC;

        private string _ITEM_BARCODE;

        private System.Nullable<int> _CATEGORY_ID;

        private System.Nullable<int> _TYPE_ID;

        private System.Nullable<int> _TXN_UNIT;

        private System.Nullable<byte> _RE_ORDER_DAYS;

        private System.Nullable<decimal> _RE_ORDER_QTY;

        private System.Nullable<byte> _ORDER_LEAD_TIME;

        private System.Nullable<char> _IS_FOREIGN;

        private System.Nullable<char> _INCLUDE_IN_AUTO_PR;

        private System.Nullable<int> _GL_CODE;

        private System.Nullable<char> _IS_FA;

        private System.Nullable<char> _IS_REUSABLE;

        private System.Nullable<decimal> _REUSE_PRICE_PERC;

        private System.Nullable<int> _VENDOR_ID;

        private System.Nullable<decimal> _PURCHASE_PRICE;

        private System.Nullable<decimal> _SELLING_PRICE;

        private System.Nullable<char> _ALLOW_PARTIAL_DELIVERY;

        private System.Nullable<char> _ALLOW_PARTIAL_RECIEVE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<INV_CATEGORY> _INV_CATEGORY;

        private EntityRef<INV_ITEMTYPE> _INV_ITEMTYPE;

        private EntityRef<INV_VENDOR> _INV_VENDOR;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnITEM_IDChanging(int value);
        partial void OnITEM_IDChanged();
        partial void OnITEM_UIDChanging(string value);
        partial void OnITEM_UIDChanged();
        partial void OnITEM_NAMEChanging(string value);
        partial void OnITEM_NAMEChanged();
        partial void OnITEM_DESCChanging(string value);
        partial void OnITEM_DESCChanged();
        partial void OnITEM_BARCODEChanging(string value);
        partial void OnITEM_BARCODEChanged();
        partial void OnCATEGORY_IDChanging(System.Nullable<int> value);
        partial void OnCATEGORY_IDChanged();
        partial void OnTYPE_IDChanging(System.Nullable<int> value);
        partial void OnTYPE_IDChanged();
        partial void OnTXN_UNITChanging(System.Nullable<int> value);
        partial void OnTXN_UNITChanged();
        partial void OnRE_ORDER_DAYSChanging(System.Nullable<byte> value);
        partial void OnRE_ORDER_DAYSChanged();
        partial void OnRE_ORDER_QTYChanging(System.Nullable<decimal> value);
        partial void OnRE_ORDER_QTYChanged();
        partial void OnORDER_LEAD_TIMEChanging(System.Nullable<byte> value);
        partial void OnORDER_LEAD_TIMEChanged();
        partial void OnIS_FOREIGNChanging(System.Nullable<char> value);
        partial void OnIS_FOREIGNChanged();
        partial void OnINCLUDE_IN_AUTO_PRChanging(System.Nullable<char> value);
        partial void OnINCLUDE_IN_AUTO_PRChanged();
        partial void OnGL_CODEChanging(System.Nullable<int> value);
        partial void OnGL_CODEChanged();
        partial void OnIS_FAChanging(System.Nullable<char> value);
        partial void OnIS_FAChanged();
        partial void OnIS_REUSABLEChanging(System.Nullable<char> value);
        partial void OnIS_REUSABLEChanged();
        partial void OnREUSE_PRICE_PERCChanging(System.Nullable<decimal> value);
        partial void OnREUSE_PRICE_PERCChanged();
        partial void OnVENDOR_IDChanging(System.Nullable<int> value);
        partial void OnVENDOR_IDChanged();
        partial void OnPURCHASE_PRICEChanging(System.Nullable<decimal> value);
        partial void OnPURCHASE_PRICEChanged();
        partial void OnSELLING_PRICEChanging(System.Nullable<decimal> value);
        partial void OnSELLING_PRICEChanged();
        partial void OnALLOW_PARTIAL_DELIVERYChanging(System.Nullable<char> value);
        partial void OnALLOW_PARTIAL_DELIVERYChanged();
        partial void OnALLOW_PARTIAL_RECIEVEChanging(System.Nullable<char> value);
        partial void OnALLOW_PARTIAL_RECIEVEChanged();
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

        public INV_ITEM()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._INV_CATEGORY = default(EntityRef<INV_CATEGORY>);
            this._INV_ITEMTYPE = default(EntityRef<INV_ITEMTYPE>);
            this._INV_VENDOR = default(EntityRef<INV_VENDOR>);
            OnCreated();
        }

        [Column(Storage = "_ITEM_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_ITEM_UID", DbType = "NVarChar(30)")]
        public string ITEM_UID
        {
            get
            {
                return this._ITEM_UID;
            }
            set
            {
                if ((this._ITEM_UID != value))
                {
                    this.OnITEM_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_UID = value;
                    this.SendPropertyChanged("ITEM_UID");
                    this.OnITEM_UIDChanged();
                }
            }
        }

        [Column(Storage = "_ITEM_NAME", DbType = "NVarChar(100)")]
        public string ITEM_NAME
        {
            get
            {
                return this._ITEM_NAME;
            }
            set
            {
                if ((this._ITEM_NAME != value))
                {
                    this.OnITEM_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_NAME = value;
                    this.SendPropertyChanged("ITEM_NAME");
                    this.OnITEM_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_ITEM_DESC", DbType = "NVarChar(250)")]
        public string ITEM_DESC
        {
            get
            {
                return this._ITEM_DESC;
            }
            set
            {
                if ((this._ITEM_DESC != value))
                {
                    this.OnITEM_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_DESC = value;
                    this.SendPropertyChanged("ITEM_DESC");
                    this.OnITEM_DESCChanged();
                }
            }
        }

        [Column(Storage = "_ITEM_BARCODE", DbType = "NVarChar(100)")]
        public string ITEM_BARCODE
        {
            get
            {
                return this._ITEM_BARCODE;
            }
            set
            {
                if ((this._ITEM_BARCODE != value))
                {
                    this.OnITEM_BARCODEChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_BARCODE = value;
                    this.SendPropertyChanged("ITEM_BARCODE");
                    this.OnITEM_BARCODEChanged();
                }
            }
        }

        [Column(Storage = "_CATEGORY_ID", DbType = "Int")]
        public System.Nullable<int> CATEGORY_ID
        {
            get
            {
                return this._CATEGORY_ID;
            }
            set
            {
                if ((this._CATEGORY_ID != value))
                {
                    if (this._INV_CATEGORY.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCATEGORY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CATEGORY_ID = value;
                    this.SendPropertyChanged("CATEGORY_ID");
                    this.OnCATEGORY_IDChanged();
                }
            }
        }

        [Column(Storage = "_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> TYPE_ID
        {
            get
            {
                return this._TYPE_ID;
            }
            set
            {
                if ((this._TYPE_ID != value))
                {
                    if (this._INV_ITEMTYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TYPE_ID = value;
                    this.SendPropertyChanged("TYPE_ID");
                    this.OnTYPE_IDChanged();
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

        [Column(Storage = "_RE_ORDER_DAYS", DbType = "TinyInt")]
        public System.Nullable<byte> RE_ORDER_DAYS
        {
            get
            {
                return this._RE_ORDER_DAYS;
            }
            set
            {
                if ((this._RE_ORDER_DAYS != value))
                {
                    this.OnRE_ORDER_DAYSChanging(value);
                    this.SendPropertyChanging();
                    this._RE_ORDER_DAYS = value;
                    this.SendPropertyChanged("RE_ORDER_DAYS");
                    this.OnRE_ORDER_DAYSChanged();
                }
            }
        }

        [Column(Storage = "_RE_ORDER_QTY", DbType = "Decimal(9,2)")]
        public System.Nullable<decimal> RE_ORDER_QTY
        {
            get
            {
                return this._RE_ORDER_QTY;
            }
            set
            {
                if ((this._RE_ORDER_QTY != value))
                {
                    this.OnRE_ORDER_QTYChanging(value);
                    this.SendPropertyChanging();
                    this._RE_ORDER_QTY = value;
                    this.SendPropertyChanged("RE_ORDER_QTY");
                    this.OnRE_ORDER_QTYChanged();
                }
            }
        }

        [Column(Storage = "_ORDER_LEAD_TIME", DbType = "TinyInt")]
        public System.Nullable<byte> ORDER_LEAD_TIME
        {
            get
            {
                return this._ORDER_LEAD_TIME;
            }
            set
            {
                if ((this._ORDER_LEAD_TIME != value))
                {
                    this.OnORDER_LEAD_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_LEAD_TIME = value;
                    this.SendPropertyChanged("ORDER_LEAD_TIME");
                    this.OnORDER_LEAD_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_IS_FOREIGN", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_FOREIGN
        {
            get
            {
                return this._IS_FOREIGN;
            }
            set
            {
                if ((this._IS_FOREIGN != value))
                {
                    this.OnIS_FOREIGNChanging(value);
                    this.SendPropertyChanging();
                    this._IS_FOREIGN = value;
                    this.SendPropertyChanged("IS_FOREIGN");
                    this.OnIS_FOREIGNChanged();
                }
            }
        }

        [Column(Storage = "_INCLUDE_IN_AUTO_PR", DbType = "NVarChar(1)")]
        public System.Nullable<char> INCLUDE_IN_AUTO_PR
        {
            get
            {
                return this._INCLUDE_IN_AUTO_PR;
            }
            set
            {
                if ((this._INCLUDE_IN_AUTO_PR != value))
                {
                    this.OnINCLUDE_IN_AUTO_PRChanging(value);
                    this.SendPropertyChanging();
                    this._INCLUDE_IN_AUTO_PR = value;
                    this.SendPropertyChanged("INCLUDE_IN_AUTO_PR");
                    this.OnINCLUDE_IN_AUTO_PRChanged();
                }
            }
        }

        [Column(Storage = "_GL_CODE", DbType = "Int")]
        public System.Nullable<int> GL_CODE
        {
            get
            {
                return this._GL_CODE;
            }
            set
            {
                if ((this._GL_CODE != value))
                {
                    this.OnGL_CODEChanging(value);
                    this.SendPropertyChanging();
                    this._GL_CODE = value;
                    this.SendPropertyChanged("GL_CODE");
                    this.OnGL_CODEChanged();
                }
            }
        }

        [Column(Storage = "_IS_FA", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_FA
        {
            get
            {
                return this._IS_FA;
            }
            set
            {
                if ((this._IS_FA != value))
                {
                    this.OnIS_FAChanging(value);
                    this.SendPropertyChanging();
                    this._IS_FA = value;
                    this.SendPropertyChanged("IS_FA");
                    this.OnIS_FAChanged();
                }
            }
        }

        [Column(Storage = "_IS_REUSABLE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_REUSABLE
        {
            get
            {
                return this._IS_REUSABLE;
            }
            set
            {
                if ((this._IS_REUSABLE != value))
                {
                    this.OnIS_REUSABLEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_REUSABLE = value;
                    this.SendPropertyChanged("IS_REUSABLE");
                    this.OnIS_REUSABLEChanged();
                }
            }
        }

        [Column(Storage = "_REUSE_PRICE_PERC", DbType = "Decimal(5,2)")]
        public System.Nullable<decimal> REUSE_PRICE_PERC
        {
            get
            {
                return this._REUSE_PRICE_PERC;
            }
            set
            {
                if ((this._REUSE_PRICE_PERC != value))
                {
                    this.OnREUSE_PRICE_PERCChanging(value);
                    this.SendPropertyChanging();
                    this._REUSE_PRICE_PERC = value;
                    this.SendPropertyChanged("REUSE_PRICE_PERC");
                    this.OnREUSE_PRICE_PERCChanged();
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

        [Column(Storage = "_PURCHASE_PRICE", DbType = "Decimal(9,2)")]
        public System.Nullable<decimal> PURCHASE_PRICE
        {
            get
            {
                return this._PURCHASE_PRICE;
            }
            set
            {
                if ((this._PURCHASE_PRICE != value))
                {
                    this.OnPURCHASE_PRICEChanging(value);
                    this.SendPropertyChanging();
                    this._PURCHASE_PRICE = value;
                    this.SendPropertyChanged("PURCHASE_PRICE");
                    this.OnPURCHASE_PRICEChanged();
                }
            }
        }

        [Column(Storage = "_SELLING_PRICE", DbType = "Decimal(9,2)")]
        public System.Nullable<decimal> SELLING_PRICE
        {
            get
            {
                return this._SELLING_PRICE;
            }
            set
            {
                if ((this._SELLING_PRICE != value))
                {
                    this.OnSELLING_PRICEChanging(value);
                    this.SendPropertyChanging();
                    this._SELLING_PRICE = value;
                    this.SendPropertyChanged("SELLING_PRICE");
                    this.OnSELLING_PRICEChanged();
                }
            }
        }

        [Column(Storage = "_ALLOW_PARTIAL_DELIVERY", DbType = "NVarChar(1)")]
        public System.Nullable<char> ALLOW_PARTIAL_DELIVERY
        {
            get
            {
                return this._ALLOW_PARTIAL_DELIVERY;
            }
            set
            {
                if ((this._ALLOW_PARTIAL_DELIVERY != value))
                {
                    this.OnALLOW_PARTIAL_DELIVERYChanging(value);
                    this.SendPropertyChanging();
                    this._ALLOW_PARTIAL_DELIVERY = value;
                    this.SendPropertyChanged("ALLOW_PARTIAL_DELIVERY");
                    this.OnALLOW_PARTIAL_DELIVERYChanged();
                }
            }
        }

        [Column(Storage = "_ALLOW_PARTIAL_RECIEVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> ALLOW_PARTIAL_RECIEVE
        {
            get
            {
                return this._ALLOW_PARTIAL_RECIEVE;
            }
            set
            {
                if ((this._ALLOW_PARTIAL_RECIEVE != value))
                {
                    this.OnALLOW_PARTIAL_RECIEVEChanging(value);
                    this.SendPropertyChanging();
                    this._ALLOW_PARTIAL_RECIEVE = value;
                    this.SendPropertyChanged("ALLOW_PARTIAL_RECIEVE");
                    this.OnALLOW_PARTIAL_RECIEVEChanged();
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

        [Association(Name = "GBL_ENV_INV_ITEM", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_ITEMs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_ITEMs.Add(this);
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

        [Association(Name = "INV_CATEGORY_INV_ITEM", Storage = "_INV_CATEGORY", ThisKey = "CATEGORY_ID", OtherKey = "CATEGORY_ID", IsForeignKey = true)]
        public INV_CATEGORY INV_CATEGORY
        {
            get
            {
                return this._INV_CATEGORY.Entity;
            }
            set
            {
                INV_CATEGORY previousValue = this._INV_CATEGORY.Entity;
                if (((previousValue != value)
                            || (this._INV_CATEGORY.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_CATEGORY.Entity = null;
                        previousValue.INV_ITEMs.Remove(this);
                    }
                    this._INV_CATEGORY.Entity = value;
                    if ((value != null))
                    {
                        value.INV_ITEMs.Add(this);
                        this._CATEGORY_ID = value.CATEGORY_ID;
                    }
                    else
                    {
                        this._CATEGORY_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("INV_CATEGORY");
                }
            }
        }

        [Association(Name = "INV_ITEMTYPE_INV_ITEM", Storage = "_INV_ITEMTYPE", ThisKey = "TYPE_ID", OtherKey = "ITEMTYPE_ID", IsForeignKey = true)]
        public INV_ITEMTYPE INV_ITEMTYPE
        {
            get
            {
                return this._INV_ITEMTYPE.Entity;
            }
            set
            {
                INV_ITEMTYPE previousValue = this._INV_ITEMTYPE.Entity;
                if (((previousValue != value)
                            || (this._INV_ITEMTYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_ITEMTYPE.Entity = null;
                        previousValue.INV_ITEMs.Remove(this);
                    }
                    this._INV_ITEMTYPE.Entity = value;
                    if ((value != null))
                    {
                        value.INV_ITEMs.Add(this);
                        this._TYPE_ID = value.ITEMTYPE_ID;
                    }
                    else
                    {
                        this._TYPE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("INV_ITEMTYPE");
                }
            }
        }

        [Association(Name = "INV_VENDOR_INV_ITEM", Storage = "_INV_VENDOR", ThisKey = "VENDOR_ID", OtherKey = "VENDOR_ID", IsForeignKey = true)]
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
                        previousValue.INV_ITEMs.Remove(this);
                    }
                    this._INV_VENDOR.Entity = value;
                    if ((value != null))
                    {
                        value.INV_ITEMs.Add(this);
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
    }
}
