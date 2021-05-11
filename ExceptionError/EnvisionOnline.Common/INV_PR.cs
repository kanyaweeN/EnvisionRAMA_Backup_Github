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
    [Table(Name = "dbo.INV_PR")]
    public partial class INV_PR : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _PR_ID;

        private string _PR_UID;

        private System.Nullable<char> _GENERATE_MODE;

        private System.Nullable<int> _GENERATED_BY;

        private System.Nullable<System.DateTime> _GENERATED_ON;

        private System.Nullable<char> _PR_STATUS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<INV_PRDTL> _INV_PRDTLs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnPR_IDChanging(int value);
        partial void OnPR_IDChanged();
        partial void OnPR_UIDChanging(string value);
        partial void OnPR_UIDChanged();
        partial void OnGENERATE_MODEChanging(System.Nullable<char> value);
        partial void OnGENERATE_MODEChanged();
        partial void OnGENERATED_BYChanging(System.Nullable<int> value);
        partial void OnGENERATED_BYChanged();
        partial void OnGENERATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnGENERATED_ONChanged();
        partial void OnPR_STATUSChanging(System.Nullable<char> value);
        partial void OnPR_STATUSChanged();
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

        public INV_PR()
        {
            this._INV_PRDTLs = new EntitySet<INV_PRDTL>(new Action<INV_PRDTL>(this.attach_INV_PRDTLs), new Action<INV_PRDTL>(this.detach_INV_PRDTLs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_PR_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int PR_ID
        {
            get
            {
                return this._PR_ID;
            }
            set
            {
                if ((this._PR_ID != value))
                {
                    this.OnPR_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PR_ID = value;
                    this.SendPropertyChanged("PR_ID");
                    this.OnPR_IDChanged();
                }
            }
        }

        [Column(Storage = "_PR_UID", DbType = "NVarChar(50)")]
        public string PR_UID
        {
            get
            {
                return this._PR_UID;
            }
            set
            {
                if ((this._PR_UID != value))
                {
                    this.OnPR_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._PR_UID = value;
                    this.SendPropertyChanged("PR_UID");
                    this.OnPR_UIDChanged();
                }
            }
        }

        [Column(Storage = "_GENERATE_MODE", DbType = "NVarChar(1)")]
        public System.Nullable<char> GENERATE_MODE
        {
            get
            {
                return this._GENERATE_MODE;
            }
            set
            {
                if ((this._GENERATE_MODE != value))
                {
                    this.OnGENERATE_MODEChanging(value);
                    this.SendPropertyChanging();
                    this._GENERATE_MODE = value;
                    this.SendPropertyChanged("GENERATE_MODE");
                    this.OnGENERATE_MODEChanged();
                }
            }
        }

        [Column(Storage = "_GENERATED_BY", DbType = "Int")]
        public System.Nullable<int> GENERATED_BY
        {
            get
            {
                return this._GENERATED_BY;
            }
            set
            {
                if ((this._GENERATED_BY != value))
                {
                    this.OnGENERATED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._GENERATED_BY = value;
                    this.SendPropertyChanged("GENERATED_BY");
                    this.OnGENERATED_BYChanged();
                }
            }
        }

        [Column(Storage = "_GENERATED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> GENERATED_ON
        {
            get
            {
                return this._GENERATED_ON;
            }
            set
            {
                if ((this._GENERATED_ON != value))
                {
                    this.OnGENERATED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._GENERATED_ON = value;
                    this.SendPropertyChanged("GENERATED_ON");
                    this.OnGENERATED_ONChanged();
                }
            }
        }

        [Column(Storage = "_PR_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> PR_STATUS
        {
            get
            {
                return this._PR_STATUS;
            }
            set
            {
                if ((this._PR_STATUS != value))
                {
                    this.OnPR_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._PR_STATUS = value;
                    this.SendPropertyChanged("PR_STATUS");
                    this.OnPR_STATUSChanged();
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

        [Association(Name = "INV_PR_INV_PRDTL", Storage = "_INV_PRDTLs", ThisKey = "PR_ID", OtherKey = "PR_ID")]
        public EntitySet<INV_PRDTL> INV_PRDTLs
        {
            get
            {
                return this._INV_PRDTLs;
            }
            set
            {
                this._INV_PRDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_PR", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_PRs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_PRs.Add(this);
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

        private void attach_INV_PRDTLs(INV_PRDTL entity)
        {
            this.SendPropertyChanging();
            entity.INV_PR = this;
        }

        private void detach_INV_PRDTLs(INV_PRDTL entity)
        {
            this.SendPropertyChanging();
            entity.INV_PR = null;
        }
    }
}
