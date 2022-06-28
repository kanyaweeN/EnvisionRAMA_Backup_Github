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
    [Table(Name = "dbo.RIS_ORDERIMAGES")]
    public partial class RIS_ORDERIMAGE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ORDER_IMAGE_ID;

        private string _HN;

        private System.Nullable<int> _ORDER_ID;

        private System.Nullable<byte> _SL_NO;

        private string _IMAGE_NAME;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _SCHEDULE_ID;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HIS_REGISTRATION> _HIS_REGISTRATION;

        private EntityRef<RIS_ORDER> _RIS_ORDER;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnORDER_IMAGE_IDChanging(int value);
        partial void OnORDER_IMAGE_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnORDER_IDChanging(System.Nullable<int> value);
        partial void OnORDER_IDChanged();
        partial void OnSL_NOChanging(System.Nullable<byte> value);
        partial void OnSL_NOChanged();
        partial void OnIMAGE_NAMEChanging(string value);
        partial void OnIMAGE_NAMEChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        partial void OnSCHEDULE_IDChanging(System.Nullable<int> value);
        partial void OnSCHEDULE_IDChanged();
        #endregion

        public RIS_ORDERIMAGE()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HIS_REGISTRATION = default(EntityRef<HIS_REGISTRATION>);
            this._RIS_ORDER = default(EntityRef<RIS_ORDER>);
            OnCreated();
        }

        [Column(Storage = "_ORDER_IMAGE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ORDER_IMAGE_ID
        {
            get
            {
                return this._ORDER_IMAGE_ID;
            }
            set
            {
                if ((this._ORDER_IMAGE_ID != value))
                {
                    this.OnORDER_IMAGE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_IMAGE_ID = value;
                    this.SendPropertyChanged("ORDER_IMAGE_ID");
                    this.OnORDER_IMAGE_IDChanged();
                }
            }
        }

        [Column(Storage = "_HN", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
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

        [Column(Storage = "_SL_NO", DbType = "TinyInt")]
        public System.Nullable<byte> SL_NO
        {
            get
            {
                return this._SL_NO;
            }
            set
            {
                if ((this._SL_NO != value))
                {
                    this.OnSL_NOChanging(value);
                    this.SendPropertyChanging();
                    this._SL_NO = value;
                    this.SendPropertyChanged("SL_NO");
                    this.OnSL_NOChanged();
                }
            }
        }

        [Column(Storage = "_IMAGE_NAME", DbType = "NVarChar(200)")]
        public string IMAGE_NAME
        {
            get
            {
                return this._IMAGE_NAME;
            }
            set
            {
                if ((this._IMAGE_NAME != value))
                {
                    this.OnIMAGE_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._IMAGE_NAME = value;
                    this.SendPropertyChanged("IMAGE_NAME");
                    this.OnIMAGE_NAMEChanged();
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

        [Column(Storage = "_SCHEDULE_ID", DbType = "Int")]
        public System.Nullable<int> SCHEDULE_ID
        {
            get
            {
                return this._SCHEDULE_ID;
            }
            set
            {
                if ((this._SCHEDULE_ID != value))
                {
                    this.OnSCHEDULE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_ID = value;
                    this.SendPropertyChanged("SCHEDULE_ID");
                    this.OnSCHEDULE_IDChanged();
                }
            }
        }

        [Association(Name = "GBL_ENV_RIS_ORDERIMAGE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_ORDERIMAGEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERIMAGEs.Add(this);
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

        [Association(Name = "HIS_REGISTRATION_RIS_ORDERIMAGE", Storage = "_HIS_REGISTRATION", ThisKey = "HN", OtherKey = "HN", IsForeignKey = true)]
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
                        previousValue.RIS_ORDERIMAGEs.Remove(this);
                    }
                    this._HIS_REGISTRATION.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERIMAGEs.Add(this);
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

        [Association(Name = "RIS_ORDER_RIS_ORDERIMAGE", Storage = "_RIS_ORDER", ThisKey = "ORDER_ID", OtherKey = "ORDER_ID", IsForeignKey = true)]
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
                        previousValue.RIS_ORDERIMAGEs.Remove(this);
                    }
                    this._RIS_ORDER.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERIMAGEs.Add(this);
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

        public string PATIENT_ID { get; set; }

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
