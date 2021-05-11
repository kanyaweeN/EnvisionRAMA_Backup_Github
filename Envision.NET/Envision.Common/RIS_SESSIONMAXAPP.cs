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
    [Table(Name = "dbo.RIS_SESSIONMAXAPP")]
    public partial class RIS_SESSIONMAXAPP : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _MODALITY_ID;

        private int _SESSION_ID;

        private byte _WEEKDAY;

        private byte _MAX_APP;

        private int _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_CLINICSESSION> _RIS_CLINICSESSION;

        private EntityRef<RIS_MODALITY> _RIS_MODALITY;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnMODALITY_IDChanging(int value);
        partial void OnMODALITY_IDChanged();
        partial void OnSESSION_IDChanging(int value);
        partial void OnSESSION_IDChanged();
        partial void OnWEEKDAYChanging(byte value);
        partial void OnWEEKDAYChanged();
        partial void OnMAX_APPChanging(byte value);
        partial void OnMAX_APPChanged();
        partial void OnORG_IDChanging(int value);
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

        public RIS_SESSIONMAXAPP()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_CLINICSESSION = default(EntityRef<RIS_CLINICSESSION>);
            this._RIS_MODALITY = default(EntityRef<RIS_MODALITY>);
            OnCreated();
        }

        [Column(Storage = "_MODALITY_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int MODALITY_ID
        {
            get
            {
                return this._MODALITY_ID;
            }
            set
            {
                if ((this._MODALITY_ID != value))
                {
                    if (this._RIS_MODALITY.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMODALITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_ID = value;
                    this.SendPropertyChanged("MODALITY_ID");
                    this.OnMODALITY_IDChanged();
                }
            }
        }

        [Column(Storage = "_SESSION_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int SESSION_ID
        {
            get
            {
                return this._SESSION_ID;
            }
            set
            {
                if ((this._SESSION_ID != value))
                {
                    if (this._RIS_CLINICSESSION.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSESSION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SESSION_ID = value;
                    this.SendPropertyChanged("SESSION_ID");
                    this.OnSESSION_IDChanged();
                }
            }
        }

        [Column(Storage = "_WEEKDAY", DbType = "TinyInt NOT NULL", IsPrimaryKey = true)]
        public byte WEEKDAY
        {
            get
            {
                return this._WEEKDAY;
            }
            set
            {
                if ((this._WEEKDAY != value))
                {
                    this.OnWEEKDAYChanging(value);
                    this.SendPropertyChanging();
                    this._WEEKDAY = value;
                    this.SendPropertyChanged("WEEKDAY");
                    this.OnWEEKDAYChanged();
                }
            }
        }

        [Column(Storage = "_MAX_APP", DbType = "TinyInt NOT NULL")]
        public byte MAX_APP
        {
            get
            {
                return this._MAX_APP;
            }
            set
            {
                if ((this._MAX_APP != value))
                {
                    this.OnMAX_APPChanging(value);
                    this.SendPropertyChanging();
                    this._MAX_APP = value;
                    this.SendPropertyChanged("MAX_APP");
                    this.OnMAX_APPChanged();
                }
            }
        }

        [Column(Storage = "_ORG_ID", DbType = "Int NOT NULL")]
        public int ORG_ID
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

        [Association(Name = "GBL_ENV_RIS_SESSIONMAXAPP", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_SESSIONMAXAPPs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_SESSIONMAXAPPs.Add(this);
                        this._ORG_ID = value.ORG_ID;
                    }
                    else
                    {
                        this._ORG_ID = default(int);
                    }
                    this.SendPropertyChanged("GBL_ENV");
                }
            }
        }

        [Association(Name = "RIS_CLINICSESSION_RIS_SESSIONMAXAPP", Storage = "_RIS_CLINICSESSION", ThisKey = "SESSION_ID", OtherKey = "SESSION_ID", IsForeignKey = true)]
        public RIS_CLINICSESSION RIS_CLINICSESSION
        {
            get
            {
                return this._RIS_CLINICSESSION.Entity;
            }
            set
            {
                RIS_CLINICSESSION previousValue = this._RIS_CLINICSESSION.Entity;
                if (((previousValue != value)
                            || (this._RIS_CLINICSESSION.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_CLINICSESSION.Entity = null;
                        previousValue.RIS_SESSIONMAXAPPs.Remove(this);
                    }
                    this._RIS_CLINICSESSION.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_SESSIONMAXAPPs.Add(this);
                        this._SESSION_ID = value.SESSION_ID;
                    }
                    else
                    {
                        this._SESSION_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_CLINICSESSION");
                }
            }
        }

        [Association(Name = "RIS_MODALITY_RIS_SESSIONMAXAPP", Storage = "_RIS_MODALITY", ThisKey = "MODALITY_ID", OtherKey = "MODALITY_ID", IsForeignKey = true)]
        public RIS_MODALITY RIS_MODALITY
        {
            get
            {
                return this._RIS_MODALITY.Entity;
            }
            set
            {
                RIS_MODALITY previousValue = this._RIS_MODALITY.Entity;
                if (((previousValue != value)
                            || (this._RIS_MODALITY.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_MODALITY.Entity = null;
                        previousValue.RIS_SESSIONMAXAPPs.Remove(this);
                    }
                    this._RIS_MODALITY.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_SESSIONMAXAPPs.Add(this);
                        this._MODALITY_ID = value.MODALITY_ID;
                    }
                    else
                    {
                        this._MODALITY_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_MODALITY");
                }
            }
        }

        public int MAX_IPD_APP { get; set; }
        public int MAX_ONLINE_APP { get; set; }

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
