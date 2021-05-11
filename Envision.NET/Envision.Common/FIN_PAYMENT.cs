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
    [Table(Name = "dbo.FIN_PAYMENT")]
    public partial class FIN_PAYMENT : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _PAY_ID;

        private System.Nullable<System.DateTime> _PAY_DT;

        private System.Nullable<long> _INV_ID;

        private string _HN;

        private System.Nullable<int> _UNIT_ID;

        private System.Nullable<int> _EMP_ID;

        private System.Nullable<char> _STATUS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _ORDER_ID;

        private System.Nullable<int> _REG_ID;

        private string _PAY_UID;

        private string _REF_NAME;

        private string _REF_ADR;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HIS_REGISTRATION> _HIS_REGISTRATION;

        private EntityRef<HR_UNIT> _HR_UNIT;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnPAY_IDChanging(int value);
        partial void OnPAY_IDChanged();
        partial void OnPAY_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnPAY_DTChanged();
        partial void OnINV_IDChanging(System.Nullable<long> value);
        partial void OnINV_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnUNIT_IDChanging(System.Nullable<int> value);
        partial void OnUNIT_IDChanged();
        partial void OnEMP_IDChanging(System.Nullable<int> value);
        partial void OnEMP_IDChanged();
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
        partial void OnREG_IDChanging(System.Nullable<int> value);
        partial void OnREG_IDChanged();
        partial void OnPAY_UIDChanging(string value);
        partial void OnPAY_UIDChanged();
        partial void OnREF_NAMEChanging(string value);
        partial void OnREF_NAMEChanged();
        partial void OnREF_ADRChanging(string value);
        partial void OnREF_ADRChanged();
        #endregion

        public FIN_PAYMENT()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HIS_REGISTRATION = default(EntityRef<HIS_REGISTRATION>);
            this._HR_UNIT = default(EntityRef<HR_UNIT>);
            OnCreated();
        }

        [Column(Storage = "_PAY_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int PAY_ID
        {
            get
            {
                return this._PAY_ID;
            }
            set
            {
                if ((this._PAY_ID != value))
                {
                    this.OnPAY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PAY_ID = value;
                    this.SendPropertyChanged("PAY_ID");
                    this.OnPAY_IDChanged();
                }
            }
        }

        [Column(Storage = "_PAY_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> PAY_DT
        {
            get
            {
                return this._PAY_DT;
            }
            set
            {
                if ((this._PAY_DT != value))
                {
                    this.OnPAY_DTChanging(value);
                    this.SendPropertyChanging();
                    this._PAY_DT = value;
                    this.SendPropertyChanged("PAY_DT");
                    this.OnPAY_DTChanged();
                }
            }
        }

        [Column(Storage = "_INV_ID", DbType = "BigInt")]
        public System.Nullable<long> INV_ID
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
                    if (this._HIS_REGISTRATION.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnHNChanging(value);
                    this.SendPropertyChanging();
                    this._HN = value;
                    this.SendPropertyChanged("HN");
                    this.OnHNChanged();
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
                    if (this._HR_UNIT.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnUNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID = value;
                    this.SendPropertyChanged("UNIT_ID");
                    this.OnUNIT_IDChanged();
                }
            }
        }

        [Column(Storage = "_EMP_ID", DbType = "Int")]
        public System.Nullable<int> EMP_ID
        {
            get
            {
                return this._EMP_ID;
            }
            set
            {
                if ((this._EMP_ID != value))
                {
                    this.OnEMP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_ID = value;
                    this.SendPropertyChanged("EMP_ID");
                    this.OnEMP_IDChanged();
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

        [Column(Storage = "_REG_ID", DbType = "Int")]
        public System.Nullable<int> REG_ID
        {
            get
            {
                return this._REG_ID;
            }
            set
            {
                if ((this._REG_ID != value))
                {
                    this.OnREG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REG_ID = value;
                    this.SendPropertyChanged("REG_ID");
                    this.OnREG_IDChanged();
                }
            }
        }

        [Column(Storage = "_PAY_UID", DbType = "NVarChar(30)")]
        public string PAY_UID
        {
            get
            {
                return this._PAY_UID;
            }
            set
            {
                if ((this._PAY_UID != value))
                {
                    this.OnPAY_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._PAY_UID = value;
                    this.SendPropertyChanged("PAY_UID");
                    this.OnPAY_UIDChanged();
                }
            }
        }

        [Column(Storage = "_REF_NAME", DbType = "NVarChar(200)")]
        public string REF_NAME
        {
            get
            {
                return this._REF_NAME;
            }
            set
            {
                if ((this._REF_NAME != value))
                {
                    this.OnREF_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._REF_NAME = value;
                    this.SendPropertyChanged("REF_NAME");
                    this.OnREF_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_REF_ADR", DbType = "NVarChar(1000)")]
        public string REF_ADR
        {
            get
            {
                return this._REF_ADR;
            }
            set
            {
                if ((this._REF_ADR != value))
                {
                    this.OnREF_ADRChanging(value);
                    this.SendPropertyChanging();
                    this._REF_ADR = value;
                    this.SendPropertyChanged("REF_ADR");
                    this.OnREF_ADRChanged();
                }
            }
        }

        [Association(Name = "GBL_ENV_FIN_PAYMENT", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.FIN_PAYMENTs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.FIN_PAYMENTs.Add(this);
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

        [Association(Name = "HIS_REGISTRATION_FIN_PAYMENT", Storage = "_HIS_REGISTRATION", ThisKey = "HN", OtherKey = "HN", IsForeignKey = true)]
        public HIS_REGISTRATION HIS_REGISTRATION
        {
            get
            {
                return this._HIS_REGISTRATION.Entity;
            }
            set
            {
                HIS_REGISTRATION previousValue = this._HIS_REGISTRATION.Entity;
                if (((previousValue != value)
                            || (this._HIS_REGISTRATION.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HIS_REGISTRATION.Entity = null;
                        previousValue.FIN_PAYMENTs.Remove(this);
                    }
                    this._HIS_REGISTRATION.Entity = value;
                    if ((value != null))
                    {
                        value.FIN_PAYMENTs.Add(this);
                        this._HN = value.HN;
                    }
                    else
                    {
                        this._HN = default(string);
                    }
                    this.SendPropertyChanged("HIS_REGISTRATION");
                }
            }
        }

        [Association(Name = "HR_UNIT_FIN_PAYMENT", Storage = "_HR_UNIT", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID", IsForeignKey = true)]
        public HR_UNIT HR_UNIT
        {
            get
            {
                return this._HR_UNIT.Entity;
            }
            set
            {
                HR_UNIT previousValue = this._HR_UNIT.Entity;
                if (((previousValue != value)
                            || (this._HR_UNIT.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_UNIT.Entity = null;
                        previousValue.FIN_PAYMENTs.Remove(this);
                    }
                    this._HR_UNIT.Entity = value;
                    if ((value != null))
                    {
                        value.FIN_PAYMENTs.Add(this);
                        this._UNIT_ID = value.UNIT_ID;
                    }
                    else
                    {
                        this._UNIT_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_UNIT");
                }
            }
        }

        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }

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
