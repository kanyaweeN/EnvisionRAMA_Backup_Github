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
    [Table(Name = "dbo.INV_SETTINGS")]
    public partial class INV_SETTING : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SETTINGS_ID;

        private string _SETTINGS_UID;

        private System.Nullable<char> _INV_METHOD;

        private System.Nullable<char> _FREE_PROD_PRICING;

        private System.Nullable<char> _DISCOUNT_EFFECT;

        private System.Nullable<byte> _PO_AUTH_LEVEL;

        private System.Nullable<char> _GENERATE_AUTO_PR;

        private System.Nullable<byte> _AUTO_PR_FREQ_DAYS;

        private System.Nullable<decimal> _GLOBAL_SELLING_MARKUP;

        private System.Nullable<char> _ALLOW_NEW_IF_PENDING;

        private System.Nullable<char> _OVERRIDE_IF_EMERGENCY;

        private System.Nullable<char> _SELL_REUSED_WO_RENTRY;

        private System.Nullable<char> _REORDER_CALC_METHOD;

        private System.Nullable<char> _CENTRAL_STOCK_UNIT;

        private System.Nullable<char> _DEPT_STOCK_UNIT;

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
        partial void OnSETTINGS_IDChanging(int value);
        partial void OnSETTINGS_IDChanged();
        partial void OnSETTINGS_UIDChanging(string value);
        partial void OnSETTINGS_UIDChanged();
        partial void OnINV_METHODChanging(System.Nullable<char> value);
        partial void OnINV_METHODChanged();
        partial void OnFREE_PROD_PRICINGChanging(System.Nullable<char> value);
        partial void OnFREE_PROD_PRICINGChanged();
        partial void OnDISCOUNT_EFFECTChanging(System.Nullable<char> value);
        partial void OnDISCOUNT_EFFECTChanged();
        partial void OnPO_AUTH_LEVELChanging(System.Nullable<byte> value);
        partial void OnPO_AUTH_LEVELChanged();
        partial void OnGENERATE_AUTO_PRChanging(System.Nullable<char> value);
        partial void OnGENERATE_AUTO_PRChanged();
        partial void OnAUTO_PR_FREQ_DAYSChanging(System.Nullable<byte> value);
        partial void OnAUTO_PR_FREQ_DAYSChanged();
        partial void OnGLOBAL_SELLING_MARKUPChanging(System.Nullable<decimal> value);
        partial void OnGLOBAL_SELLING_MARKUPChanged();
        partial void OnALLOW_NEW_IF_PENDINGChanging(System.Nullable<char> value);
        partial void OnALLOW_NEW_IF_PENDINGChanged();
        partial void OnOVERRIDE_IF_EMERGENCYChanging(System.Nullable<char> value);
        partial void OnOVERRIDE_IF_EMERGENCYChanged();
        partial void OnSELL_REUSED_WO_RENTRYChanging(System.Nullable<char> value);
        partial void OnSELL_REUSED_WO_RENTRYChanged();
        partial void OnREORDER_CALC_METHODChanging(System.Nullable<char> value);
        partial void OnREORDER_CALC_METHODChanged();
        partial void OnCENTRAL_STOCK_UNITChanging(System.Nullable<char> value);
        partial void OnCENTRAL_STOCK_UNITChanged();
        partial void OnDEPT_STOCK_UNITChanging(System.Nullable<char> value);
        partial void OnDEPT_STOCK_UNITChanged();
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

        public INV_SETTING()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_SETTINGS_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SETTINGS_ID
        {
            get
            {
                return this._SETTINGS_ID;
            }
            set
            {
                if ((this._SETTINGS_ID != value))
                {
                    this.OnSETTINGS_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SETTINGS_ID = value;
                    this.SendPropertyChanged("SETTINGS_ID");
                    this.OnSETTINGS_IDChanged();
                }
            }
        }

        [Column(Storage = "_SETTINGS_UID", DbType = "NVarChar(30)")]
        public string SETTINGS_UID
        {
            get
            {
                return this._SETTINGS_UID;
            }
            set
            {
                if ((this._SETTINGS_UID != value))
                {
                    this.OnSETTINGS_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._SETTINGS_UID = value;
                    this.SendPropertyChanged("SETTINGS_UID");
                    this.OnSETTINGS_UIDChanged();
                }
            }
        }

        [Column(Storage = "_INV_METHOD", DbType = "NVarChar(1)")]
        public System.Nullable<char> INV_METHOD
        {
            get
            {
                return this._INV_METHOD;
            }
            set
            {
                if ((this._INV_METHOD != value))
                {
                    this.OnINV_METHODChanging(value);
                    this.SendPropertyChanging();
                    this._INV_METHOD = value;
                    this.SendPropertyChanged("INV_METHOD");
                    this.OnINV_METHODChanged();
                }
            }
        }

        [Column(Storage = "_FREE_PROD_PRICING", DbType = "NVarChar(1)")]
        public System.Nullable<char> FREE_PROD_PRICING
        {
            get
            {
                return this._FREE_PROD_PRICING;
            }
            set
            {
                if ((this._FREE_PROD_PRICING != value))
                {
                    this.OnFREE_PROD_PRICINGChanging(value);
                    this.SendPropertyChanging();
                    this._FREE_PROD_PRICING = value;
                    this.SendPropertyChanged("FREE_PROD_PRICING");
                    this.OnFREE_PROD_PRICINGChanged();
                }
            }
        }

        [Column(Storage = "_DISCOUNT_EFFECT", DbType = "NVarChar(1)")]
        public System.Nullable<char> DISCOUNT_EFFECT
        {
            get
            {
                return this._DISCOUNT_EFFECT;
            }
            set
            {
                if ((this._DISCOUNT_EFFECT != value))
                {
                    this.OnDISCOUNT_EFFECTChanging(value);
                    this.SendPropertyChanging();
                    this._DISCOUNT_EFFECT = value;
                    this.SendPropertyChanged("DISCOUNT_EFFECT");
                    this.OnDISCOUNT_EFFECTChanged();
                }
            }
        }

        [Column(Storage = "_PO_AUTH_LEVEL", DbType = "TinyInt")]
        public System.Nullable<byte> PO_AUTH_LEVEL
        {
            get
            {
                return this._PO_AUTH_LEVEL;
            }
            set
            {
                if ((this._PO_AUTH_LEVEL != value))
                {
                    this.OnPO_AUTH_LEVELChanging(value);
                    this.SendPropertyChanging();
                    this._PO_AUTH_LEVEL = value;
                    this.SendPropertyChanged("PO_AUTH_LEVEL");
                    this.OnPO_AUTH_LEVELChanged();
                }
            }
        }

        [Column(Storage = "_GENERATE_AUTO_PR", DbType = "NVarChar(1)")]
        public System.Nullable<char> GENERATE_AUTO_PR
        {
            get
            {
                return this._GENERATE_AUTO_PR;
            }
            set
            {
                if ((this._GENERATE_AUTO_PR != value))
                {
                    this.OnGENERATE_AUTO_PRChanging(value);
                    this.SendPropertyChanging();
                    this._GENERATE_AUTO_PR = value;
                    this.SendPropertyChanged("GENERATE_AUTO_PR");
                    this.OnGENERATE_AUTO_PRChanged();
                }
            }
        }

        [Column(Storage = "_AUTO_PR_FREQ_DAYS", DbType = "TinyInt")]
        public System.Nullable<byte> AUTO_PR_FREQ_DAYS
        {
            get
            {
                return this._AUTO_PR_FREQ_DAYS;
            }
            set
            {
                if ((this._AUTO_PR_FREQ_DAYS != value))
                {
                    this.OnAUTO_PR_FREQ_DAYSChanging(value);
                    this.SendPropertyChanging();
                    this._AUTO_PR_FREQ_DAYS = value;
                    this.SendPropertyChanged("AUTO_PR_FREQ_DAYS");
                    this.OnAUTO_PR_FREQ_DAYSChanged();
                }
            }
        }

        [Column(Storage = "_GLOBAL_SELLING_MARKUP", DbType = "Decimal(5,2)")]
        public System.Nullable<decimal> GLOBAL_SELLING_MARKUP
        {
            get
            {
                return this._GLOBAL_SELLING_MARKUP;
            }
            set
            {
                if ((this._GLOBAL_SELLING_MARKUP != value))
                {
                    this.OnGLOBAL_SELLING_MARKUPChanging(value);
                    this.SendPropertyChanging();
                    this._GLOBAL_SELLING_MARKUP = value;
                    this.SendPropertyChanged("GLOBAL_SELLING_MARKUP");
                    this.OnGLOBAL_SELLING_MARKUPChanged();
                }
            }
        }

        [Column(Storage = "_ALLOW_NEW_IF_PENDING", DbType = "NVarChar(1)")]
        public System.Nullable<char> ALLOW_NEW_IF_PENDING
        {
            get
            {
                return this._ALLOW_NEW_IF_PENDING;
            }
            set
            {
                if ((this._ALLOW_NEW_IF_PENDING != value))
                {
                    this.OnALLOW_NEW_IF_PENDINGChanging(value);
                    this.SendPropertyChanging();
                    this._ALLOW_NEW_IF_PENDING = value;
                    this.SendPropertyChanged("ALLOW_NEW_IF_PENDING");
                    this.OnALLOW_NEW_IF_PENDINGChanged();
                }
            }
        }

        [Column(Storage = "_OVERRIDE_IF_EMERGENCY", DbType = "NVarChar(1)")]
        public System.Nullable<char> OVERRIDE_IF_EMERGENCY
        {
            get
            {
                return this._OVERRIDE_IF_EMERGENCY;
            }
            set
            {
                if ((this._OVERRIDE_IF_EMERGENCY != value))
                {
                    this.OnOVERRIDE_IF_EMERGENCYChanging(value);
                    this.SendPropertyChanging();
                    this._OVERRIDE_IF_EMERGENCY = value;
                    this.SendPropertyChanged("OVERRIDE_IF_EMERGENCY");
                    this.OnOVERRIDE_IF_EMERGENCYChanged();
                }
            }
        }

        [Column(Storage = "_SELL_REUSED_WO_RENTRY", DbType = "NVarChar(1)")]
        public System.Nullable<char> SELL_REUSED_WO_RENTRY
        {
            get
            {
                return this._SELL_REUSED_WO_RENTRY;
            }
            set
            {
                if ((this._SELL_REUSED_WO_RENTRY != value))
                {
                    this.OnSELL_REUSED_WO_RENTRYChanging(value);
                    this.SendPropertyChanging();
                    this._SELL_REUSED_WO_RENTRY = value;
                    this.SendPropertyChanged("SELL_REUSED_WO_RENTRY");
                    this.OnSELL_REUSED_WO_RENTRYChanged();
                }
            }
        }

        [Column(Storage = "_REORDER_CALC_METHOD", DbType = "NVarChar(1)")]
        public System.Nullable<char> REORDER_CALC_METHOD
        {
            get
            {
                return this._REORDER_CALC_METHOD;
            }
            set
            {
                if ((this._REORDER_CALC_METHOD != value))
                {
                    this.OnREORDER_CALC_METHODChanging(value);
                    this.SendPropertyChanging();
                    this._REORDER_CALC_METHOD = value;
                    this.SendPropertyChanged("REORDER_CALC_METHOD");
                    this.OnREORDER_CALC_METHODChanged();
                }
            }
        }

        [Column(Storage = "_CENTRAL_STOCK_UNIT", DbType = "NVarChar(1)")]
        public System.Nullable<char> CENTRAL_STOCK_UNIT
        {
            get
            {
                return this._CENTRAL_STOCK_UNIT;
            }
            set
            {
                if ((this._CENTRAL_STOCK_UNIT != value))
                {
                    this.OnCENTRAL_STOCK_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._CENTRAL_STOCK_UNIT = value;
                    this.SendPropertyChanged("CENTRAL_STOCK_UNIT");
                    this.OnCENTRAL_STOCK_UNITChanged();
                }
            }
        }

        [Column(Storage = "_DEPT_STOCK_UNIT", DbType = "NVarChar(1)")]
        public System.Nullable<char> DEPT_STOCK_UNIT
        {
            get
            {
                return this._DEPT_STOCK_UNIT;
            }
            set
            {
                if ((this._DEPT_STOCK_UNIT != value))
                {
                    this.OnDEPT_STOCK_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._DEPT_STOCK_UNIT = value;
                    this.SendPropertyChanged("DEPT_STOCK_UNIT");
                    this.OnDEPT_STOCK_UNITChanged();
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

        [Association(Name = "GBL_ENV_INV_SETTING", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_SETTINGs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_SETTINGs.Add(this);
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
