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
    [Table(Name = "dbo.RIS_MODALITYTYPE")]
    public partial class RIS_MODALITYTYPE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _TYPE_ID;

        private string _TYPE_UID;

        private string _TYPE_NAME;

        private string _TYPE_NAME_ALIAS;

        private string _DESCR;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _ORG_ID;

        private EntitySet<RIS_MODALITY> _RIS_MODALITies;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnTYPE_IDChanging(int value);
        partial void OnTYPE_IDChanged();
        partial void OnTYPE_UIDChanging(string value);
        partial void OnTYPE_UIDChanged();
        partial void OnTYPE_NAMEChanging(string value);
        partial void OnTYPE_NAMEChanged();
        partial void OnTYPE_NAME_ALIASChanging(string value);
        partial void OnTYPE_NAME_ALIASChanged();
        partial void OnDESCRChanging(string value);
        partial void OnDESCRChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        #endregion

        public RIS_MODALITYTYPE()
        {
            this._RIS_MODALITies = new EntitySet<RIS_MODALITY>(new Action<RIS_MODALITY>(this.attach_RIS_MODALITies), new Action<RIS_MODALITY>(this.detach_RIS_MODALITies));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_TYPE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int TYPE_ID
        {
            get
            {
                return this._TYPE_ID;
            }
            set
            {
                if ((this._TYPE_ID != value))
                {
                    this.OnTYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TYPE_ID = value;
                    this.SendPropertyChanged("TYPE_ID");
                    this.OnTYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_TYPE_UID", DbType = "NVarChar(30)")]
        public string TYPE_UID
        {
            get
            {
                return this._TYPE_UID;
            }
            set
            {
                if ((this._TYPE_UID != value))
                {
                    this.OnTYPE_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._TYPE_UID = value;
                    this.SendPropertyChanged("TYPE_UID");
                    this.OnTYPE_UIDChanged();
                }
            }
        }

        [Column(Storage = "_TYPE_NAME", DbType = "NVarChar(100)")]
        public string TYPE_NAME
        {
            get
            {
                return this._TYPE_NAME;
            }
            set
            {
                if ((this._TYPE_NAME != value))
                {
                    this.OnTYPE_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._TYPE_NAME = value;
                    this.SendPropertyChanged("TYPE_NAME");
                    this.OnTYPE_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_TYPE_NAME_ALIAS", DbType = "NVarChar(100)")]
        public string TYPE_NAME_ALIAS
        {
            get
            {
                return this._TYPE_NAME_ALIAS;
            }
            set
            {
                if ((this._TYPE_NAME_ALIAS != value))
                {
                    this.OnTYPE_NAME_ALIASChanging(value);
                    this.SendPropertyChanging();
                    this._TYPE_NAME_ALIAS = value;
                    this.SendPropertyChanged("TYPE_NAME_ALIAS");
                    this.OnTYPE_NAME_ALIASChanged();
                }
            }
        }

        [Column(Storage = "_DESCR", DbType = "NVarChar(500)")]
        public string DESCR
        {
            get
            {
                return this._DESCR;
            }
            set
            {
                if ((this._DESCR != value))
                {
                    this.OnDESCRChanging(value);
                    this.SendPropertyChanging();
                    this._DESCR = value;
                    this.SendPropertyChanged("DESCR");
                    this.OnDESCRChanged();
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

        [Association(Name = "RIS_MODALITYTYPE_RIS_MODALITY", Storage = "_RIS_MODALITies", ThisKey = "TYPE_ID", OtherKey = "MODALITY_TYPE")]
        public EntitySet<RIS_MODALITY> RIS_MODALITies
        {
            get
            {
                return this._RIS_MODALITies;
            }
            set
            {
                this._RIS_MODALITies.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_MODALITYTYPE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_MODALITYTYPEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_MODALITYTYPEs.Add(this);
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

        private void attach_RIS_MODALITies(RIS_MODALITY entity)
        {
            this.SendPropertyChanging();
            entity.RIS_MODALITYTYPE = this;
        }

        private void detach_RIS_MODALITies(RIS_MODALITY entity)
        {
            this.SendPropertyChanging();
            entity.RIS_MODALITYTYPE = null;
        }
    }
}
