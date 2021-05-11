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
    [Table(Name = "dbo.RIS_MODALITY")]
    public partial class RIS_MODALITY : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _MODALITY_ID;

        private string _MODALITY_UID;

        private string _MODALITY_NAME;

        private System.Nullable<int> _MODALITY_TYPE;


        private System.Nullable<int> _UNIT_ID;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<System.DateTime> _START_TIME;

        private System.Nullable<System.DateTime> _END_TIME;

        private System.Nullable<byte> _AVG_INV_TIME;

        private System.Nullable<int> _ROOM_ID;

        private System.Nullable<short> _CASE_PER_DAY;

        private System.Nullable<char> _RESTRICT_LEVEL;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<char> _IS_VISIBLE;

        private EntitySet<RIS_MODALITYEXAM> _RIS_MODALITYEXAMs;

        private EntitySet<RIS_ORDERDTL> _RIS_ORDERDTLs;

        private EntitySet<RIS_SESSIONMAXAPP> _RIS_SESSIONMAXAPPs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_ROOM> _HR_ROOM;

        private EntityRef<RIS_MODALITYTYPE> _RIS_MODALITYTYPE;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnMODALITY_IDChanging(int value);
        partial void OnMODALITY_IDChanged();
        partial void OnMODALITY_UIDChanging(string value);
        partial void OnMODALITY_UIDChanged();
        partial void OnMODALITY_NAMEChanging(string value);
        partial void OnMODALITY_NAMEChanged();
        partial void OnMODALITY_TYPEChanging(System.Nullable<int> value);
        partial void OnMODALITY_TYPEChanged();
        partial void OnUNIT_IDChanging(System.Nullable<int> value);
        partial void OnUNIT_IDChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
        partial void OnSTART_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnSTART_TIMEChanged();
        partial void OnEND_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnEND_TIMEChanged();
        partial void OnAVG_INV_TIMEChanging(System.Nullable<byte> value);
        partial void OnAVG_INV_TIMEChanged();
        partial void OnROOM_IDChanging(System.Nullable<int> value);
        partial void OnROOM_IDChanged();
        partial void OnCASE_PER_DAYChanging(System.Nullable<short> value);
        partial void OnCASE_PER_DAYChanged();
        partial void OnRESTRICT_LEVELChanging(System.Nullable<char> value);
        partial void OnRESTRICT_LEVELChanged();
        partial void OnIS_UPDATEDChanging(System.Nullable<char> value);
        partial void OnIS_UPDATEDChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
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
        partial void OnIS_VISIBLEChanging(System.Nullable<char> value);
        partial void OnIS_VISIBLEChanged();
        #endregion

        public RIS_MODALITY()
        {
            this._RIS_MODALITYEXAMs = new EntitySet<RIS_MODALITYEXAM>(new Action<RIS_MODALITYEXAM>(this.attach_RIS_MODALITYEXAMs), new Action<RIS_MODALITYEXAM>(this.detach_RIS_MODALITYEXAMs));
            this._RIS_ORDERDTLs = new EntitySet<RIS_ORDERDTL>(new Action<RIS_ORDERDTL>(this.attach_RIS_ORDERDTLs), new Action<RIS_ORDERDTL>(this.detach_RIS_ORDERDTLs));
            this._RIS_SESSIONMAXAPPs = new EntitySet<RIS_SESSIONMAXAPP>(new Action<RIS_SESSIONMAXAPP>(this.attach_RIS_SESSIONMAXAPPs), new Action<RIS_SESSIONMAXAPP>(this.detach_RIS_SESSIONMAXAPPs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_ROOM = default(EntityRef<HR_ROOM>);
            this._RIS_MODALITYTYPE = default(EntityRef<RIS_MODALITYTYPE>);
            OnCreated();
        }

        [Column(Storage = "_MODALITY_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
                    this.OnMODALITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_ID = value;
                    this.SendPropertyChanged("MODALITY_ID");
                    this.OnMODALITY_IDChanged();
                }
            }
        }

        [Column(Storage = "_MODALITY_UID", DbType = "NVarChar(50)")]
        public string MODALITY_UID
        {
            get
            {
                return this._MODALITY_UID;
            }
            set
            {
                if ((this._MODALITY_UID != value))
                {
                    this.OnMODALITY_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_UID = value;
                    this.SendPropertyChanged("MODALITY_UID");
                    this.OnMODALITY_UIDChanged();
                }
            }
        }

        [Column(Storage = "_MODALITY_NAME", DbType = "NVarChar(100)")]
        public string MODALITY_NAME
        {
            get
            {
                return this._MODALITY_NAME;
            }
            set
            {
                if ((this._MODALITY_NAME != value))
                {
                    this.OnMODALITY_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_NAME = value;
                    this.SendPropertyChanged("MODALITY_NAME");
                    this.OnMODALITY_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_MODALITY_TYPE", DbType = "Int")]
        public System.Nullable<int> MODALITY_TYPE
        {
            get
            {
                return this._MODALITY_TYPE;
            }
            set
            {
                if ((this._MODALITY_TYPE != value))
                {
                    if (this._RIS_MODALITYTYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMODALITY_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_TYPE = value;
                    this.SendPropertyChanged("MODALITY_TYPE");
                    this.OnMODALITY_TYPEChanged();
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
                    this.OnUNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID = value;
                    this.SendPropertyChanged("UNIT_ID");
                    this.OnUNIT_IDChanged();
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

        [Column(Storage = "_AVG_INV_TIME", DbType = "TinyInt")]
        public System.Nullable<byte> AVG_INV_TIME
        {
            get
            {
                return this._AVG_INV_TIME;
            }
            set
            {
                if ((this._AVG_INV_TIME != value))
                {
                    this.OnAVG_INV_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._AVG_INV_TIME = value;
                    this.SendPropertyChanged("AVG_INV_TIME");
                    this.OnAVG_INV_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_ROOM_ID", DbType = "Int")]
        public System.Nullable<int> ROOM_ID
        {
            get
            {
                return this._ROOM_ID;
            }
            set
            {
                if ((this._ROOM_ID != value))
                {
                    if (this._HR_ROOM.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnROOM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ROOM_ID = value;
                    this.SendPropertyChanged("ROOM_ID");
                    this.OnROOM_IDChanged();
                }
            }
        }

        [Column(Storage = "_CASE_PER_DAY", DbType = "SmallInt")]
        public System.Nullable<short> CASE_PER_DAY
        {
            get
            {
                return this._CASE_PER_DAY;
            }
            set
            {
                if ((this._CASE_PER_DAY != value))
                {
                    this.OnCASE_PER_DAYChanging(value);
                    this.SendPropertyChanging();
                    this._CASE_PER_DAY = value;
                    this.SendPropertyChanged("CASE_PER_DAY");
                    this.OnCASE_PER_DAYChanged();
                }
            }
        }

        [Column(Storage = "_RESTRICT_LEVEL", DbType = "NVarChar(1)")]
        public System.Nullable<char> RESTRICT_LEVEL
        {
            get
            {
                return this._RESTRICT_LEVEL;
            }
            set
            {
                if ((this._RESTRICT_LEVEL != value))
                {
                    this.OnRESTRICT_LEVELChanging(value);
                    this.SendPropertyChanging();
                    this._RESTRICT_LEVEL = value;
                    this.SendPropertyChanged("RESTRICT_LEVEL");
                    this.OnRESTRICT_LEVELChanged();
                }
            }
        }

        [Column(Storage = "_IS_UPDATED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_UPDATED
        {
            get
            {
                return this._IS_UPDATED;
            }
            set
            {
                if ((this._IS_UPDATED != value))
                {
                    this.OnIS_UPDATEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_UPDATED = value;
                    this.SendPropertyChanged("IS_UPDATED");
                    this.OnIS_UPDATEDChanged();
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

        [Column(Storage = "_IS_VISIBLE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_VISIBLE
        {
            get
            {
                return this._IS_VISIBLE;
            }
            set
            {
                if ((this._IS_VISIBLE != value))
                {
                    this.OnIS_VISIBLEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_VISIBLE = value;
                    this.SendPropertyChanged("IS_VISIBLE");
                    this.OnIS_VISIBLEChanged();
                }
            }
        }

        [Association(Name = "RIS_MODALITY_RIS_MODALITYEXAM", Storage = "_RIS_MODALITYEXAMs", ThisKey = "MODALITY_ID", OtherKey = "MODALITY_ID")]
        public EntitySet<RIS_MODALITYEXAM> RIS_MODALITYEXAMs
        {
            get
            {
                return this._RIS_MODALITYEXAMs;
            }
            set
            {
                this._RIS_MODALITYEXAMs.Assign(value);
            }
        }

        [Association(Name = "RIS_MODALITY_RIS_ORDERDTL", Storage = "_RIS_ORDERDTLs", ThisKey = "MODALITY_ID", OtherKey = "MODALITY_ID")]
        public EntitySet<RIS_ORDERDTL> RIS_ORDERDTLs
        {
            get
            {
                return this._RIS_ORDERDTLs;
            }
            set
            {
                this._RIS_ORDERDTLs.Assign(value);
            }
        }

        [Association(Name = "RIS_MODALITY_RIS_SESSIONMAXAPP", Storage = "_RIS_SESSIONMAXAPPs", ThisKey = "MODALITY_ID", OtherKey = "MODALITY_ID")]
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

        [Association(Name = "GBL_ENV_RIS_MODALITY", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_MODALITies.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_MODALITies.Add(this);
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

        [Association(Name = "HR_ROOM_RIS_MODALITY", Storage = "_HR_ROOM", ThisKey = "ROOM_ID", OtherKey = "ROOM_ID", IsForeignKey = true)]
        public HR_ROOM HR_ROOM
        {
            get
            {
                return this._HR_ROOM.Entity;
            }
            set
            {
                HR_ROOM previousValue = this._HR_ROOM.Entity;
                if (((previousValue != value)
                            || (this._HR_ROOM.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_ROOM.Entity = null;
                        previousValue.RIS_MODALITies.Remove(this);
                    }
                    this._HR_ROOM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_MODALITies.Add(this);
                        this._ROOM_ID = value.ROOM_ID;
                    }
                    else
                    {
                        this._ROOM_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_ROOM");
                }
            }
        }

        [Association(Name = "RIS_MODALITYTYPE_RIS_MODALITY", Storage = "_RIS_MODALITYTYPE", ThisKey = "MODALITY_TYPE", OtherKey = "TYPE_ID", IsForeignKey = true)]
        public RIS_MODALITYTYPE RIS_MODALITYTYPE
        {
            get
            {
                return this._RIS_MODALITYTYPE.Entity;
            }
            set
            {
                RIS_MODALITYTYPE previousValue = this._RIS_MODALITYTYPE.Entity;
                if (((previousValue != value)
                            || (this._RIS_MODALITYTYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_MODALITYTYPE.Entity = null;
                        previousValue.RIS_MODALITies.Remove(this);
                    }
                    this._RIS_MODALITYTYPE.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_MODALITies.Add(this);
                        this._MODALITY_TYPE = value.TYPE_ID;
                    }
                    else
                    {
                        this._MODALITY_TYPE = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_MODALITYTYPE");
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

        private void attach_RIS_MODALITYEXAMs(RIS_MODALITYEXAM entity)
        {
            this.SendPropertyChanging();
            entity.RIS_MODALITY = this;
        }

        private void detach_RIS_MODALITYEXAMs(RIS_MODALITYEXAM entity)
        {
            this.SendPropertyChanging();
            entity.RIS_MODALITY = null;
        }

        private void attach_RIS_ORDERDTLs(RIS_ORDERDTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_MODALITY = this;
        }

        private void detach_RIS_ORDERDTLs(RIS_ORDERDTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_MODALITY = null;
        }

        private void attach_RIS_SESSIONMAXAPPs(RIS_SESSIONMAXAPP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_MODALITY = this;
        }

        private void detach_RIS_SESSIONMAXAPPs(RIS_SESSIONMAXAPP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_MODALITY = null;
        }
    }
}
