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
    [Table(Name = "dbo.INV_ITEMSTOCK")]
    public partial class INV_ITEMSTOCK : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ITEM_STOCK_ID;

        private System.Nullable<int> _UNIT_ID;

        private System.Nullable<int> _ITEM_ID;

        private string _BATCH;

        private System.Nullable<System.DateTime> _EXPIRY_DT;

        private System.Nullable<decimal> _QTY;

        private System.Nullable<decimal> _PRICE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnITEM_STOCK_IDChanging(int value);
        partial void OnITEM_STOCK_IDChanged();
        partial void OnUNIT_IDChanging(System.Nullable<int> value);
        partial void OnUNIT_IDChanged();
        partial void OnITEM_IDChanging(System.Nullable<int> value);
        partial void OnITEM_IDChanged();
        partial void OnBATCHChanging(string value);
        partial void OnBATCHChanged();
        partial void OnEXPIRY_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnEXPIRY_DTChanged();
        partial void OnQTYChanging(System.Nullable<decimal> value);
        partial void OnQTYChanged();
        partial void OnPRICEChanging(System.Nullable<decimal> value);
        partial void OnPRICEChanged();
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

        public INV_ITEMSTOCK()
        {
            OnCreated();
        }

        [Column(Storage = "_ITEM_STOCK_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ITEM_STOCK_ID
        {
            get
            {
                return this._ITEM_STOCK_ID;
            }
            set
            {
                if ((this._ITEM_STOCK_ID != value))
                {
                    this.OnITEM_STOCK_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_STOCK_ID = value;
                    this.SendPropertyChanged("ITEM_STOCK_ID");
                    this.OnITEM_STOCK_IDChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_ID", DbType = "Int")]
        public System.Nullable<int> UNIT_ID
        {
            get
            {
                return this._UNIT_ID;
            }
            set
            {
                if ((this._UNIT_ID != value))
                {
                    this.OnUNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID = value;
                    this.SendPropertyChanged("UNIT_ID");
                    this.OnUNIT_IDChanged();
                }
            }
        }

        [Column(Storage = "_ITEM_ID", DbType = "Int")]
        public System.Nullable<int> ITEM_ID
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

        [Column(Storage = "_BATCH", DbType = "NVarChar(50)")]
        public string BATCH
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

        [Column(Storage = "_QTY", DbType = "Decimal(11,2)")]
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

        [Column(Storage = "_PRICE", DbType = "Decimal(11,2)")]
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
