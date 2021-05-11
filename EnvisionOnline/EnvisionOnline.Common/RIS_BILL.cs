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
    [Table(Name = "dbo.RIS_BILL")]
    public partial class RIS_BILL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _BILL_ID;

        private System.Nullable<int> _ORDER_ID;

        private string _HN;

        private System.Nullable<System.DateTime> _BILL_DT;

        private System.Nullable<int> _EXAM_ID;

        private System.Nullable<decimal> _RATE;

        private System.Nullable<decimal> _SPECIAL_RATE;

        private System.Nullable<decimal> _CLAIMABLE_AMT;

        private System.Nullable<char> _IS_PAID;

        private System.Nullable<char> _HIS_STATUS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_EXAM> _RIS_EXAM;

        private EntityRef<RIS_ORDER> _RIS_ORDER;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnBILL_IDChanging(int value);
        partial void OnBILL_IDChanged();
        partial void OnORDER_IDChanging(System.Nullable<int> value);
        partial void OnORDER_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnBILL_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnBILL_DTChanged();
        partial void OnEXAM_IDChanging(System.Nullable<int> value);
        partial void OnEXAM_IDChanged();
        partial void OnRATEChanging(System.Nullable<decimal> value);
        partial void OnRATEChanged();
        partial void OnSPECIAL_RATEChanging(System.Nullable<decimal> value);
        partial void OnSPECIAL_RATEChanged();
        partial void OnCLAIMABLE_AMTChanging(System.Nullable<decimal> value);
        partial void OnCLAIMABLE_AMTChanged();
        partial void OnIS_PAIDChanging(System.Nullable<char> value);
        partial void OnIS_PAIDChanged();
        partial void OnHIS_STATUSChanging(System.Nullable<char> value);
        partial void OnHIS_STATUSChanged();
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

        public RIS_BILL()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_EXAM = default(EntityRef<RIS_EXAM>);
            this._RIS_ORDER = default(EntityRef<RIS_ORDER>);
            OnCreated();
        }

        [Column(Storage = "_BILL_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int BILL_ID
        {
            get
            {
                return this._BILL_ID;
            }
            set
            {
                if ((this._BILL_ID != value))
                {
                    this.OnBILL_IDChanging(value);
                    this.SendPropertyChanging();
                    this._BILL_ID = value;
                    this.SendPropertyChanged("BILL_ID");
                    this.OnBILL_IDChanged();
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
                    if (this._RIS_ORDER.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnORDER_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_ID = value;
                    this.SendPropertyChanged("ORDER_ID");
                    this.OnORDER_IDChanged();
                }
            }
        }

        [Column(Storage = "_HN", DbType = "NVarChar(30)")]
        public string HN
        {
            get
            {
                return this._HN;
            }
            set
            {
                if ((this._HN != value))
                {
                    this.OnHNChanging(value);
                    this.SendPropertyChanging();
                    this._HN = value;
                    this.SendPropertyChanged("HN");
                    this.OnHNChanged();
                }
            }
        }

        [Column(Storage = "_BILL_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> BILL_DT
        {
            get
            {
                return this._BILL_DT;
            }
            set
            {
                if ((this._BILL_DT != value))
                {
                    this.OnBILL_DTChanging(value);
                    this.SendPropertyChanging();
                    this._BILL_DT = value;
                    this.SendPropertyChanged("BILL_DT");
                    this.OnBILL_DTChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int")]
        public System.Nullable<int> EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    if (this._RIS_EXAM.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_RATE", DbType = "Decimal(7,2)")]
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

        [Column(Storage = "_SPECIAL_RATE", DbType = "Decimal(18,2)")]
        public System.Nullable<decimal> SPECIAL_RATE
        {
            get
            {
                return this._SPECIAL_RATE;
            }
            set
            {
                if ((this._SPECIAL_RATE != value))
                {
                    this.OnSPECIAL_RATEChanging(value);
                    this.SendPropertyChanging();
                    this._SPECIAL_RATE = value;
                    this.SendPropertyChanged("SPECIAL_RATE");
                    this.OnSPECIAL_RATEChanged();
                }
            }
        }

        [Column(Storage = "_CLAIMABLE_AMT", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> CLAIMABLE_AMT
        {
            get
            {
                return this._CLAIMABLE_AMT;
            }
            set
            {
                if ((this._CLAIMABLE_AMT != value))
                {
                    this.OnCLAIMABLE_AMTChanging(value);
                    this.SendPropertyChanging();
                    this._CLAIMABLE_AMT = value;
                    this.SendPropertyChanged("CLAIMABLE_AMT");
                    this.OnCLAIMABLE_AMTChanged();
                }
            }
        }

        [Column(Storage = "_IS_PAID", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_PAID
        {
            get
            {
                return this._IS_PAID;
            }
            set
            {
                if ((this._IS_PAID != value))
                {
                    this.OnIS_PAIDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_PAID = value;
                    this.SendPropertyChanged("IS_PAID");
                    this.OnIS_PAIDChanged();
                }
            }
        }

        [Column(Storage = "_HIS_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> HIS_STATUS
        {
            get
            {
                return this._HIS_STATUS;
            }
            set
            {
                if ((this._HIS_STATUS != value))
                {
                    this.OnHIS_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_STATUS = value;
                    this.SendPropertyChanged("HIS_STATUS");
                    this.OnHIS_STATUSChanged();
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

        [Association(Name = "GBL_ENV_RIS_BILL", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_BILLs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_BILLs.Add(this);
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

        [Association(Name = "RIS_EXAM_RIS_BILL", Storage = "_RIS_EXAM", ThisKey = "EXAM_ID", OtherKey = "EXAM_ID", IsForeignKey = true)]
        public RIS_EXAM RIS_EXAM
        {
            get
            {
                return this._RIS_EXAM.Entity;
            }
            set
            {
                RIS_EXAM previousValue = this._RIS_EXAM.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAM.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAM.Entity = null;
                        previousValue.RIS_BILLs.Remove(this);
                    }
                    this._RIS_EXAM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_BILLs.Add(this);
                        this._EXAM_ID = value.EXAM_ID;
                    }
                    else
                    {
                        this._EXAM_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_EXAM");
                }
            }
        }

        [Association(Name = "RIS_ORDER_RIS_BILL", Storage = "_RIS_ORDER", ThisKey = "ORDER_ID", OtherKey = "ORDER_ID", IsForeignKey = true)]
        public RIS_ORDER RIS_ORDER
        {
            get
            {
                return this._RIS_ORDER.Entity;
            }
            set
            {
                RIS_ORDER previousValue = this._RIS_ORDER.Entity;
                if (((previousValue != value)
                            || (this._RIS_ORDER.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_ORDER.Entity = null;
                        previousValue.RIS_BILLs.Remove(this);
                    }
                    this._RIS_ORDER.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_BILLs.Add(this);
                        this._ORDER_ID = value.ORDER_ID;
                    }
                    else
                    {
                        this._ORDER_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_ORDER");
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
