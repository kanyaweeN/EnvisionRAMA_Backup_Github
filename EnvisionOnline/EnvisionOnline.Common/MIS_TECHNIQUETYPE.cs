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
    [Table(Name = "dbo.MIS_TECHNIQUETYPE")]
    public partial class MIS_TECHNIQUETYPE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _TECHNIQUE_TYPE_ID;

        private string _TECHNIQUE_TYPE_UID;

        private string _TECHNIQUE_TYPE_DESC;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<MIS_BIOPSYRESULT> _MIS_BIOPSYRESULTs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnTECHNIQUE_TYPE_IDChanging(int value);
        partial void OnTECHNIQUE_TYPE_IDChanged();
        partial void OnTECHNIQUE_TYPE_UIDChanging(string value);
        partial void OnTECHNIQUE_TYPE_UIDChanged();
        partial void OnTECHNIQUE_TYPE_DESCChanging(string value);
        partial void OnTECHNIQUE_TYPE_DESCChanged();
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

        public MIS_TECHNIQUETYPE()
        {
            this._MIS_BIOPSYRESULTs = new EntitySet<MIS_BIOPSYRESULT>(new Action<MIS_BIOPSYRESULT>(this.attach_MIS_BIOPSYRESULTs), new Action<MIS_BIOPSYRESULT>(this.detach_MIS_BIOPSYRESULTs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_TECHNIQUE_TYPE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int TECHNIQUE_TYPE_ID
        {
            get
            {
                return this._TECHNIQUE_TYPE_ID;
            }
            set
            {
                if ((this._TECHNIQUE_TYPE_ID != value))
                {
                    this.OnTECHNIQUE_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TECHNIQUE_TYPE_ID = value;
                    this.SendPropertyChanged("TECHNIQUE_TYPE_ID");
                    this.OnTECHNIQUE_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_TECHNIQUE_TYPE_UID", DbType = "NVarChar(30)")]
        public string TECHNIQUE_TYPE_UID
        {
            get
            {
                return this._TECHNIQUE_TYPE_UID;
            }
            set
            {
                if ((this._TECHNIQUE_TYPE_UID != value))
                {
                    this.OnTECHNIQUE_TYPE_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._TECHNIQUE_TYPE_UID = value;
                    this.SendPropertyChanged("TECHNIQUE_TYPE_UID");
                    this.OnTECHNIQUE_TYPE_UIDChanged();
                }
            }
        }

        [Column(Storage = "_TECHNIQUE_TYPE_DESC", DbType = "NVarChar(300)")]
        public string TECHNIQUE_TYPE_DESC
        {
            get
            {
                return this._TECHNIQUE_TYPE_DESC;
            }
            set
            {
                if ((this._TECHNIQUE_TYPE_DESC != value))
                {
                    this.OnTECHNIQUE_TYPE_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._TECHNIQUE_TYPE_DESC = value;
                    this.SendPropertyChanged("TECHNIQUE_TYPE_DESC");
                    this.OnTECHNIQUE_TYPE_DESCChanged();
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

        [Association(Name = "MIS_TECHNIQUETYPE_MIS_BIOPSYRESULT", Storage = "_MIS_BIOPSYRESULTs", ThisKey = "TECHNIQUE_TYPE_ID", OtherKey = "TECHNIQUE_TYPE_ID")]
        public EntitySet<MIS_BIOPSYRESULT> MIS_BIOPSYRESULTs
        {
            get
            {
                return this._MIS_BIOPSYRESULTs;
            }
            set
            {
                this._MIS_BIOPSYRESULTs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_MIS_TECHNIQUETYPE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.MIS_TECHNIQUETYPEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.MIS_TECHNIQUETYPEs.Add(this);
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

        private void attach_MIS_BIOPSYRESULTs(MIS_BIOPSYRESULT entity)
        {
            this.SendPropertyChanging();
            entity.MIS_TECHNIQUETYPE = this;
        }

        private void detach_MIS_BIOPSYRESULTs(MIS_BIOPSYRESULT entity)
        {
            this.SendPropertyChanging();
            entity.MIS_TECHNIQUETYPE = null;
        }
    }
}
