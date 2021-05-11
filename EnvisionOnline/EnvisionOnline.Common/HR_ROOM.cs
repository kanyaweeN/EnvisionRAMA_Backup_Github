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
    [Table(Name = "dbo.HR_ROOM")]
    public partial class HR_ROOM : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ROOM_ID;

        private string _ROOM_UID;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<INV_ROOMSTOCKREDUCE> _INV_ROOMSTOCKREDUCEs;

        private EntitySet<RIS_MODALITY> _RIS_MODALITies;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnROOM_IDChanging(int value);
        partial void OnROOM_IDChanged();
        partial void OnROOM_UIDChanging(string value);
        partial void OnROOM_UIDChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
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

        public HR_ROOM()
        {
            this._INV_ROOMSTOCKREDUCEs = new EntitySet<INV_ROOMSTOCKREDUCE>(new Action<INV_ROOMSTOCKREDUCE>(this.attach_INV_ROOMSTOCKREDUCEs), new Action<INV_ROOMSTOCKREDUCE>(this.detach_INV_ROOMSTOCKREDUCEs));
            this._RIS_MODALITies = new EntitySet<RIS_MODALITY>(new Action<RIS_MODALITY>(this.attach_RIS_MODALITies), new Action<RIS_MODALITY>(this.detach_RIS_MODALITies));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_ROOM_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ROOM_ID
        {
            get
            {
                return this._ROOM_ID;
            }
            set
            {
                if ((this._ROOM_ID != value))
                {
                    this.OnROOM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ROOM_ID = value;
                    this.SendPropertyChanged("ROOM_ID");
                    this.OnROOM_IDChanged();
                }
            }
        }

        [Column(Storage = "_ROOM_UID", DbType = "NVarChar(30)")]
        public string ROOM_UID
        {
            get
            {
                return this._ROOM_UID;
            }
            set
            {
                if ((this._ROOM_UID != value))
                {
                    this.OnROOM_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._ROOM_UID = value;
                    this.SendPropertyChanged("ROOM_UID");
                    this.OnROOM_UIDChanged();
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

        [Association(Name = "HR_ROOM_INV_ROOMSTOCKREDUCE", Storage = "_INV_ROOMSTOCKREDUCEs", ThisKey = "ROOM_ID", OtherKey = "ROOM_ID")]
        public EntitySet<INV_ROOMSTOCKREDUCE> INV_ROOMSTOCKREDUCEs
        {
            get
            {
                return this._INV_ROOMSTOCKREDUCEs;
            }
            set
            {
                this._INV_ROOMSTOCKREDUCEs.Assign(value);
            }
        }

        [Association(Name = "HR_ROOM_RIS_MODALITY", Storage = "_RIS_MODALITies", ThisKey = "ROOM_ID", OtherKey = "ROOM_ID")]
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

        [Association(Name = "GBL_ENV_HR_ROOM", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.HR_ROOMs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.HR_ROOMs.Add(this);
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

        private void attach_INV_ROOMSTOCKREDUCEs(INV_ROOMSTOCKREDUCE entity)
        {
            this.SendPropertyChanging();
            entity.HR_ROOM = this;
        }

        private void detach_INV_ROOMSTOCKREDUCEs(INV_ROOMSTOCKREDUCE entity)
        {
            this.SendPropertyChanging();
            entity.HR_ROOM = null;
        }

        private void attach_RIS_MODALITies(RIS_MODALITY entity)
        {
            this.SendPropertyChanging();
            entity.HR_ROOM = this;
        }

        private void detach_RIS_MODALITies(RIS_MODALITY entity)
        {
            this.SendPropertyChanging();
            entity.HR_ROOM = null;
        }
    }
}
