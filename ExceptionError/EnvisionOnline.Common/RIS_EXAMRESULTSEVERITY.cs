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
    [Table(Name = "dbo.RIS_EXAMRESULTSEVERITY")]
    public partial class RIS_EXAMRESULTSEVERITY : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SEVERITY_ID;

        private string _SEVERITY_UID;

        private string _SEVERITY_NAME;

        private string _SEVERITY_LABEL;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _UNIT_ID;

        private EntitySet<RIS_EXAMRESULT> _RIS_EXAMRESULTs;

        private EntitySet<RIS_EXAMRESULTTEMPLATE> _RIS_EXAMRESULTTEMPLATEs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_UNIT> _HR_UNIT;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSEVERITY_IDChanging(int value);
        partial void OnSEVERITY_IDChanged();
        partial void OnSEVERITY_UIDChanging(string value);
        partial void OnSEVERITY_UIDChanged();
        partial void OnSEVERITY_NAMEChanging(string value);
        partial void OnSEVERITY_NAMEChanged();
        partial void OnSEVERITY_LABELChanging(string value);
        partial void OnSEVERITY_LABELChanged();
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
        partial void OnUNIT_IDChanging(System.Nullable<int> value);
        partial void OnUNIT_IDChanged();
        #endregion

        public RIS_EXAMRESULTSEVERITY()
        {
            this._RIS_EXAMRESULTs = new EntitySet<RIS_EXAMRESULT>(new Action<RIS_EXAMRESULT>(this.attach_RIS_EXAMRESULTs), new Action<RIS_EXAMRESULT>(this.detach_RIS_EXAMRESULTs));
            this._RIS_EXAMRESULTTEMPLATEs = new EntitySet<RIS_EXAMRESULTTEMPLATE>(new Action<RIS_EXAMRESULTTEMPLATE>(this.attach_RIS_EXAMRESULTTEMPLATEs), new Action<RIS_EXAMRESULTTEMPLATE>(this.detach_RIS_EXAMRESULTTEMPLATEs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_UNIT = default(EntityRef<HR_UNIT>);
            OnCreated();
        }

        [Column(Storage = "_SEVERITY_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SEVERITY_ID
        {
            get
            {
                return this._SEVERITY_ID;
            }
            set
            {
                if ((this._SEVERITY_ID != value))
                {
                    this.OnSEVERITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SEVERITY_ID = value;
                    this.SendPropertyChanged("SEVERITY_ID");
                    this.OnSEVERITY_IDChanged();
                }
            }
        }

        [Column(Storage = "_SEVERITY_UID", DbType = "NVarChar(30)")]
        public string SEVERITY_UID
        {
            get
            {
                return this._SEVERITY_UID;
            }
            set
            {
                if ((this._SEVERITY_UID != value))
                {
                    this.OnSEVERITY_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._SEVERITY_UID = value;
                    this.SendPropertyChanged("SEVERITY_UID");
                    this.OnSEVERITY_UIDChanged();
                }
            }
        }

        [Column(Storage = "_SEVERITY_NAME", DbType = "NVarChar(50)")]
        public string SEVERITY_NAME
        {
            get
            {
                return this._SEVERITY_NAME;
            }
            set
            {
                if ((this._SEVERITY_NAME != value))
                {
                    this.OnSEVERITY_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._SEVERITY_NAME = value;
                    this.SendPropertyChanged("SEVERITY_NAME");
                    this.OnSEVERITY_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_SEVERITY_LABEL", DbType = "NVarChar(100)")]
        public string SEVERITY_LABEL
        {
            get
            {
                return this._SEVERITY_LABEL;
            }
            set
            {
                if ((this._SEVERITY_LABEL != value))
                {
                    this.OnSEVERITY_LABELChanging(value);
                    this.SendPropertyChanging();
                    this._SEVERITY_LABEL = value;
                    this.SendPropertyChanged("SEVERITY_LABEL");
                    this.OnSEVERITY_LABELChanged();
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

        [Association(Name = "RIS_EXAMRESULTSEVERITY_RIS_EXAMRESULT", Storage = "_RIS_EXAMRESULTs", ThisKey = "SEVERITY_ID", OtherKey = "SEVERITY_ID")]
        public EntitySet<RIS_EXAMRESULT> RIS_EXAMRESULTs
        {
            get
            {
                return this._RIS_EXAMRESULTs;
            }
            set
            {
                this._RIS_EXAMRESULTs.Assign(value);
            }
        }

        [Association(Name = "RIS_EXAMRESULTSEVERITY_RIS_EXAMRESULTTEMPLATE", Storage = "_RIS_EXAMRESULTTEMPLATEs", ThisKey = "SEVERITY_ID", OtherKey = "SEVERITY_ID")]
        public EntitySet<RIS_EXAMRESULTTEMPLATE> RIS_EXAMRESULTTEMPLATEs
        {
            get
            {
                return this._RIS_EXAMRESULTTEMPLATEs;
            }
            set
            {
                this._RIS_EXAMRESULTTEMPLATEs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULTSEVERITY", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMRESULTSEVERITies.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTSEVERITies.Add(this);
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

        [Association(Name = "HR_UNIT_RIS_EXAMRESULTSEVERITY", Storage = "_HR_UNIT", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMRESULTSEVERITies.Remove(this);
                    }
                    this._HR_UNIT.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTSEVERITies.Add(this);
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

        private void attach_RIS_EXAMRESULTs(RIS_EXAMRESULT entity)
        {
            this.SendPropertyChanging();
            entity.RIS_EXAMRESULTSEVERITY = this;
        }

        private void detach_RIS_EXAMRESULTs(RIS_EXAMRESULT entity)
        {
            this.SendPropertyChanging();
            entity.RIS_EXAMRESULTSEVERITY = null;
        }

        private void attach_RIS_EXAMRESULTTEMPLATEs(RIS_EXAMRESULTTEMPLATE entity)
        {
            this.SendPropertyChanging();
            entity.RIS_EXAMRESULTSEVERITY = this;
        }

        private void detach_RIS_EXAMRESULTTEMPLATEs(RIS_EXAMRESULTTEMPLATE entity)
        {
            this.SendPropertyChanging();
            entity.RIS_EXAMRESULTSEVERITY = null;
        }
    }
}
