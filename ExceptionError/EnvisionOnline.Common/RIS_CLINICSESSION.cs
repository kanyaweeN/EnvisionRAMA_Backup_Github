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
    [Table(Name = "dbo.RIS_CLINICSESSION")]
    public partial class RIS_CLINICSESSION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SESSION_ID;

        private string _SESSION_UID;

        private string _SESSION_NAME;

        private System.Nullable<int> _CLINIC_TYPE_ID;

        private System.Nullable<System.DateTime> _START_TIME;

        private System.Nullable<System.DateTime> _END_TIME;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<byte> _SL_NO;

        private System.Nullable<char> _IS_ACTIVE;

        private EntitySet<RIS_SESSIONMAXAPP> _RIS_SESSIONMAXAPPs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_CLINICTYPE> _RIS_CLINICTYPE;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSESSION_IDChanging(int value);
        partial void OnSESSION_IDChanged();
        partial void OnSESSION_UIDChanging(string value);
        partial void OnSESSION_UIDChanged();
        partial void OnSESSION_NAMEChanging(string value);
        partial void OnSESSION_NAMEChanged();
        partial void OnCLINIC_TYPE_IDChanging(System.Nullable<int> value);
        partial void OnCLINIC_TYPE_IDChanged();
        partial void OnSTART_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnSTART_TIMEChanged();
        partial void OnEND_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnEND_TIMEChanged();
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
        partial void OnSL_NOChanging(System.Nullable<byte> value);
        partial void OnSL_NOChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
        #endregion

        public RIS_CLINICSESSION()
        {
            this._RIS_SESSIONMAXAPPs = new EntitySet<RIS_SESSIONMAXAPP>(new Action<RIS_SESSIONMAXAPP>(this.attach_RIS_SESSIONMAXAPPs), new Action<RIS_SESSIONMAXAPP>(this.detach_RIS_SESSIONMAXAPPs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_CLINICTYPE = default(EntityRef<RIS_CLINICTYPE>);
            OnCreated();
        }

        [Column(Storage = "_SESSION_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
                    this.OnSESSION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SESSION_ID = value;
                    this.SendPropertyChanged("SESSION_ID");
                    this.OnSESSION_IDChanged();
                }
            }
        }

        [Column(Storage = "_SESSION_UID", DbType = "NVarChar(30)")]
        public string SESSION_UID
        {
            get
            {
                return this._SESSION_UID;
            }
            set
            {
                if ((this._SESSION_UID != value))
                {
                    this.OnSESSION_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._SESSION_UID = value;
                    this.SendPropertyChanged("SESSION_UID");
                    this.OnSESSION_UIDChanged();
                }
            }
        }

        [Column(Storage = "_SESSION_NAME", DbType = "NVarChar(300)")]
        public string SESSION_NAME
        {
            get
            {
                return this._SESSION_NAME;
            }
            set
            {
                if ((this._SESSION_NAME != value))
                {
                    this.OnSESSION_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._SESSION_NAME = value;
                    this.SendPropertyChanged("SESSION_NAME");
                    this.OnSESSION_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_CLINIC_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> CLINIC_TYPE_ID
        {
            get
            {
                return this._CLINIC_TYPE_ID;
            }
            set
            {
                if ((this._CLINIC_TYPE_ID != value))
                {
                    if (this._RIS_CLINICTYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCLINIC_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CLINIC_TYPE_ID = value;
                    this.SendPropertyChanged("CLINIC_TYPE_ID");
                    this.OnCLINIC_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_START_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> START_TIME
        {
            get
            {
                return this._START_TIME;
            }
            set
            {
                if ((this._START_TIME != value))
                {
                    this.OnSTART_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._START_TIME = value;
                    this.SendPropertyChanged("START_TIME");
                    this.OnSTART_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_END_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> END_TIME
        {
            get
            {
                return this._END_TIME;
            }
            set
            {
                if ((this._END_TIME != value))
                {
                    this.OnEND_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._END_TIME = value;
                    this.SendPropertyChanged("END_TIME");
                    this.OnEND_TIMEChanged();
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

        [Column(Storage = "_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_ACTIVE
        {
            get
            {
                return this._IS_ACTIVE;
            }
            set
            {
                if ((this._IS_ACTIVE != value))
                {
                    this.OnIS_ACTIVEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_ACTIVE = value;
                    this.SendPropertyChanged("IS_ACTIVE");
                    this.OnIS_ACTIVEChanged();
                }
            }
        }

        [Association(Name = "RIS_CLINICSESSION_RIS_SESSIONMAXAPP", Storage = "_RIS_SESSIONMAXAPPs", ThisKey = "SESSION_ID", OtherKey = "SESSION_ID")]
        public EntitySet<RIS_SESSIONMAXAPP> RIS_SESSIONMAXAPPs
        {
            get
            {
                return this._RIS_SESSIONMAXAPPs;
            }
            set
            {
                this._RIS_SESSIONMAXAPPs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_CLINICSESSION", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_CLINICSESSIONs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_CLINICSESSIONs.Add(this);
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

        [Association(Name = "RIS_CLINICTYPE_RIS_CLINICSESSION", Storage = "_RIS_CLINICTYPE", ThisKey = "CLINIC_TYPE_ID", OtherKey = "CLINIC_TYPE_ID", IsForeignKey = true)]
        public RIS_CLINICTYPE RIS_CLINICTYPE
        {
            get
            {
                return this._RIS_CLINICTYPE.Entity;
            }
            set
            {
                RIS_CLINICTYPE previousValue = this._RIS_CLINICTYPE.Entity;
                if (((previousValue != value)
                            || (this._RIS_CLINICTYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_CLINICTYPE.Entity = null;
                        previousValue.RIS_CLINICSESSIONs.Remove(this);
                    }
                    this._RIS_CLINICTYPE.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_CLINICSESSIONs.Add(this);
                        this._CLINIC_TYPE_ID = value.CLINIC_TYPE_ID;
                    }
                    else
                    {
                        this._CLINIC_TYPE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_CLINICTYPE");
                }
            }
        }

        public int MODALITY_ID { get; set; }
        public int WEEKDAYS { get; set; }


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

        private void attach_RIS_SESSIONMAXAPPs(RIS_SESSIONMAXAPP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_CLINICSESSION = this;
        }

        private void detach_RIS_SESSIONMAXAPPs(RIS_SESSIONMAXAPP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_CLINICSESSION = null;
        }
    }
}
