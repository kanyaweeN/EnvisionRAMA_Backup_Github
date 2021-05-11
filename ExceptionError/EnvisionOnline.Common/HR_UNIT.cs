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
    [Table(Name = "dbo.HR_UNIT")]
    public partial class HR_UNIT : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _UNIT_ID;

        private string _UNIT_UID;

        private System.Nullable<int> _UNIT_ID_PARENT;

        private string _UNIT_NAME;

        private string _UNIT_NAME_ALIAS;

        private string _PHONE_NO;

        private string _DESCR;

        private string _UNIT_ALIAS;

        private System.Nullable<char> _UNIT_TYPE;

        private string _UNIT_INS;

        private System.Nullable<char> _IS_EXTERNAL;

        private string _LOC;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _ORG_ID;

        private EntitySet<FIN_INVOICE> _FIN_INVOICEs;

        private EntitySet<FIN_PAYMENT> _FIN_PAYMENTs;

        private EntitySet<INV_UNIT> _INV_UNITs;

        private EntitySet<RIS_EXAMRESULTSEVERITY> _RIS_EXAMRESULTSEVERITies;

        private EntitySet<RIS_OPNOTEITEM> _RIS_OPNOTEITEMs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnUNIT_IDChanging(int value);
        partial void OnUNIT_IDChanged();
        partial void OnUNIT_UIDChanging(string value);
        partial void OnUNIT_UIDChanged();
        partial void OnUNIT_ID_PARENTChanging(System.Nullable<int> value);
        partial void OnUNIT_ID_PARENTChanged();
        partial void OnUNIT_NAMEChanging(string value);
        partial void OnUNIT_NAMEChanged();
        partial void OnUNIT_NAME_ALIASChanging(string value);
        partial void OnUNIT_NAME_ALIASChanged();
        partial void OnPHONE_NOChanging(string value);
        partial void OnPHONE_NOChanged();
        partial void OnDESCRChanging(string value);
        partial void OnDESCRChanged();
        partial void OnUNIT_ALIASChanging(string value);
        partial void OnUNIT_ALIASChanged();
        partial void OnUNIT_TYPEChanging(System.Nullable<char> value);
        partial void OnUNIT_TYPEChanged();
        partial void OnUNIT_INSChanging(string value);
        partial void OnUNIT_INSChanged();
        partial void OnIS_EXTERNALChanging(System.Nullable<char> value);
        partial void OnIS_EXTERNALChanged();
        partial void OnLOCChanging(string value);
        partial void OnLOCChanged();
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

        public HR_UNIT()
        {
            this._FIN_INVOICEs = new EntitySet<FIN_INVOICE>(new Action<FIN_INVOICE>(this.attach_FIN_INVOICEs), new Action<FIN_INVOICE>(this.detach_FIN_INVOICEs));
            this._FIN_PAYMENTs = new EntitySet<FIN_PAYMENT>(new Action<FIN_PAYMENT>(this.attach_FIN_PAYMENTs), new Action<FIN_PAYMENT>(this.detach_FIN_PAYMENTs));
            this._INV_UNITs = new EntitySet<INV_UNIT>(new Action<INV_UNIT>(this.attach_INV_UNITs), new Action<INV_UNIT>(this.detach_INV_UNITs));
            this._RIS_EXAMRESULTSEVERITies = new EntitySet<RIS_EXAMRESULTSEVERITY>(new Action<RIS_EXAMRESULTSEVERITY>(this.attach_RIS_EXAMRESULTSEVERITies), new Action<RIS_EXAMRESULTSEVERITY>(this.detach_RIS_EXAMRESULTSEVERITies));
            this._RIS_OPNOTEITEMs = new EntitySet<RIS_OPNOTEITEM>(new Action<RIS_OPNOTEITEM>(this.attach_RIS_OPNOTEITEMs), new Action<RIS_OPNOTEITEM>(this.detach_RIS_OPNOTEITEMs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_UNIT_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int UNIT_ID
        {
            get
            {
                return this._UNIT_ID;
            }
            set
            {
                if ((this._UNIT_ID != value))
                {
                    this.OnUNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID = value;
                    this.SendPropertyChanged("UNIT_ID");
                    this.OnUNIT_IDChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_UID", DbType = "NVarChar(30)")]
        public string UNIT_UID
        {
            get
            {
                return this._UNIT_UID;
            }
            set
            {
                if ((this._UNIT_UID != value))
                {
                    this.OnUNIT_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_UID = value;
                    this.SendPropertyChanged("UNIT_UID");
                    this.OnUNIT_UIDChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_ID_PARENT", DbType = "Int")]
        public System.Nullable<int> UNIT_ID_PARENT
        {
            get
            {
                return this._UNIT_ID_PARENT;
            }
            set
            {
                if ((this._UNIT_ID_PARENT != value))
                {
                    this.OnUNIT_ID_PARENTChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID_PARENT = value;
                    this.SendPropertyChanged("UNIT_ID_PARENT");
                    this.OnUNIT_ID_PARENTChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_NAME", DbType = "NVarChar(100)")]
        public string UNIT_NAME
        {
            get
            {
                return this._UNIT_NAME;
            }
            set
            {
                if ((this._UNIT_NAME != value))
                {
                    this.OnUNIT_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_NAME = value;
                    this.SendPropertyChanged("UNIT_NAME");
                    this.OnUNIT_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_NAME_ALIAS", DbType = "NVarChar(100)")]
        public string UNIT_NAME_ALIAS
        {
            get
            {
                return this._UNIT_NAME_ALIAS;
            }
            set
            {
                if ((this._UNIT_NAME_ALIAS != value))
                {
                    this.OnUNIT_NAME_ALIASChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_NAME_ALIAS = value;
                    this.SendPropertyChanged("UNIT_NAME_ALIAS");
                    this.OnUNIT_NAME_ALIASChanged();
                }
            }
        }

        [Column(Storage = "_PHONE_NO", DbType = "NVarChar(50)")]
        public string PHONE_NO
        {
            get
            {
                return this._PHONE_NO;
            }
            set
            {
                if ((this._PHONE_NO != value))
                {
                    this.OnPHONE_NOChanging(value);
                    this.SendPropertyChanging();
                    this._PHONE_NO = value;
                    this.SendPropertyChanged("PHONE_NO");
                    this.OnPHONE_NOChanged();
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

        [Column(Storage = "_UNIT_ALIAS", DbType = "NVarChar(30)")]
        public string UNIT_ALIAS
        {
            get
            {
                return this._UNIT_ALIAS;
            }
            set
            {
                if ((this._UNIT_ALIAS != value))
                {
                    this.OnUNIT_ALIASChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ALIAS = value;
                    this.SendPropertyChanged("UNIT_ALIAS");
                    this.OnUNIT_ALIASChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> UNIT_TYPE
        {
            get
            {
                return this._UNIT_TYPE;
            }
            set
            {
                if ((this._UNIT_TYPE != value))
                {
                    this.OnUNIT_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_TYPE = value;
                    this.SendPropertyChanged("UNIT_TYPE");
                    this.OnUNIT_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_INS", DbType = "NVarChar(4000)")]
        public string UNIT_INS
        {
            get
            {
                return this._UNIT_INS;
            }
            set
            {
                if ((this._UNIT_INS != value))
                {
                    this.OnUNIT_INSChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_INS = value;
                    this.SendPropertyChanged("UNIT_INS");
                    this.OnUNIT_INSChanged();
                }
            }
        }

        [Column(Storage = "_IS_EXTERNAL", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_EXTERNAL
        {
            get
            {
                return this._IS_EXTERNAL;
            }
            set
            {
                if ((this._IS_EXTERNAL != value))
                {
                    this.OnIS_EXTERNALChanging(value);
                    this.SendPropertyChanging();
                    this._IS_EXTERNAL = value;
                    this.SendPropertyChanged("IS_EXTERNAL");
                    this.OnIS_EXTERNALChanged();
                }
            }
        }

        [Column(Storage = "_LOC", DbType = "NVarChar(100)")]
        public string LOC
        {
            get
            {
                return this._LOC;
            }
            set
            {
                if ((this._LOC != value))
                {
                    this.OnLOCChanging(value);
                    this.SendPropertyChanging();
                    this._LOC = value;
                    this.SendPropertyChanged("LOC");
                    this.OnLOCChanged();
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

        [Association(Name = "HR_UNIT_FIN_INVOICE", Storage = "_FIN_INVOICEs", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID")]
        public EntitySet<FIN_INVOICE> FIN_INVOICEs
        {
            get
            {
                return this._FIN_INVOICEs;
            }
            set
            {
                this._FIN_INVOICEs.Assign(value);
            }
        }

        [Association(Name = "HR_UNIT_FIN_PAYMENT", Storage = "_FIN_PAYMENTs", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID")]
        public EntitySet<FIN_PAYMENT> FIN_PAYMENTs
        {
            get
            {
                return this._FIN_PAYMENTs;
            }
            set
            {
                this._FIN_PAYMENTs.Assign(value);
            }
        }

        [Association(Name = "HR_UNIT_INV_UNIT", Storage = "_INV_UNITs", ThisKey = "UNIT_ID", OtherKey = "EXTERNAL_UNIT")]
        public EntitySet<INV_UNIT> INV_UNITs
        {
            get
            {
                return this._INV_UNITs;
            }
            set
            {
                this._INV_UNITs.Assign(value);
            }
        }

        [Association(Name = "HR_UNIT_RIS_EXAMRESULTSEVERITY", Storage = "_RIS_EXAMRESULTSEVERITies", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID")]
        public EntitySet<RIS_EXAMRESULTSEVERITY> RIS_EXAMRESULTSEVERITies
        {
            get
            {
                return this._RIS_EXAMRESULTSEVERITies;
            }
            set
            {
                this._RIS_EXAMRESULTSEVERITies.Assign(value);
            }
        }

        [Association(Name = "HR_UNIT_RIS_OPNOTEITEM", Storage = "_RIS_OPNOTEITEMs", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID")]
        public EntitySet<RIS_OPNOTEITEM> RIS_OPNOTEITEMs
        {
            get
            {
                return this._RIS_OPNOTEITEMs;
            }
            set
            {
                this._RIS_OPNOTEITEMs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_HR_UNIT", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.HR_UNITs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.HR_UNITs.Add(this);
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

        private void attach_FIN_INVOICEs(FIN_INVOICE entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = this;
        }

        private void detach_FIN_INVOICEs(FIN_INVOICE entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = null;
        }

        private void attach_FIN_PAYMENTs(FIN_PAYMENT entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = this;
        }

        private void detach_FIN_PAYMENTs(FIN_PAYMENT entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = null;
        }

        private void attach_INV_UNITs(INV_UNIT entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = this;
        }

        private void detach_INV_UNITs(INV_UNIT entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = null;
        }

        private void attach_RIS_EXAMRESULTSEVERITies(RIS_EXAMRESULTSEVERITY entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = this;
        }

        private void detach_RIS_EXAMRESULTSEVERITies(RIS_EXAMRESULTSEVERITY entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = null;
        }

        private void attach_RIS_OPNOTEITEMs(RIS_OPNOTEITEM entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = this;
        }

        private void detach_RIS_OPNOTEITEMs(RIS_OPNOTEITEM entity)
        {
            this.SendPropertyChanging();
            entity.HR_UNIT = null;
        }
    }
}
