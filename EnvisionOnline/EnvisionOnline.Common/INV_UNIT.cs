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
    [Table(Name = "dbo.INV_UNIT")]
    public partial class INV_UNIT : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _UNIT_ID;

        private string _UNIT_UID;

        private string _UNIT_NAME;

        private string _UNIT_DESC;

        private System.Nullable<int> _EXTERNAL_UNIT;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<INV_REQUISITION> _INV_REQUISITIONs;

        private EntitySet<INV_REQUISITION> _INV_REQUISITIONs1;

        private EntitySet<INV_ROOMSTOCKREDUCE> _INV_ROOMSTOCKREDUCEs;

        private EntitySet<INV_TRANSACTION> _INV_TRANSACTIONs;

        private EntitySet<INV_TRANSACTION> _INV_TRANSACTIONs1;

        private EntitySet<INV_UNITREORDERLEVEL> _INV_UNITREORDERLEVELs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_UNIT> _HR_UNIT;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnUNIT_IDChanging(int value);
        partial void OnUNIT_IDChanged();
        partial void OnUNIT_UIDChanging(string value);
        partial void OnUNIT_UIDChanged();
        partial void OnUNIT_NAMEChanging(string value);
        partial void OnUNIT_NAMEChanged();
        partial void OnUNIT_DESCChanging(string value);
        partial void OnUNIT_DESCChanged();
        partial void OnEXTERNAL_UNITChanging(System.Nullable<int> value);
        partial void OnEXTERNAL_UNITChanged();
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

        public INV_UNIT()
        {
            this._INV_REQUISITIONs = new EntitySet<INV_REQUISITION>(new Action<INV_REQUISITION>(this.attach_INV_REQUISITIONs), new Action<INV_REQUISITION>(this.detach_INV_REQUISITIONs));
            this._INV_REQUISITIONs1 = new EntitySet<INV_REQUISITION>(new Action<INV_REQUISITION>(this.attach_INV_REQUISITIONs1), new Action<INV_REQUISITION>(this.detach_INV_REQUISITIONs1));
            this._INV_ROOMSTOCKREDUCEs = new EntitySet<INV_ROOMSTOCKREDUCE>(new Action<INV_ROOMSTOCKREDUCE>(this.attach_INV_ROOMSTOCKREDUCEs), new Action<INV_ROOMSTOCKREDUCE>(this.detach_INV_ROOMSTOCKREDUCEs));
            this._INV_TRANSACTIONs = new EntitySet<INV_TRANSACTION>(new Action<INV_TRANSACTION>(this.attach_INV_TRANSACTIONs), new Action<INV_TRANSACTION>(this.detach_INV_TRANSACTIONs));
            this._INV_TRANSACTIONs1 = new EntitySet<INV_TRANSACTION>(new Action<INV_TRANSACTION>(this.attach_INV_TRANSACTIONs1), new Action<INV_TRANSACTION>(this.detach_INV_TRANSACTIONs1));
            this._INV_UNITREORDERLEVELs = new EntitySet<INV_UNITREORDERLEVEL>(new Action<INV_UNITREORDERLEVEL>(this.attach_INV_UNITREORDERLEVELs), new Action<INV_UNITREORDERLEVEL>(this.detach_INV_UNITREORDERLEVELs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_UNIT = default(EntityRef<HR_UNIT>);
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

        [Column(Storage = "_UNIT_DESC", DbType = "NVarChar(250)")]
        public string UNIT_DESC
        {
            get
            {
                return this._UNIT_DESC;
            }
            set
            {
                if ((this._UNIT_DESC != value))
                {
                    this.OnUNIT_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_DESC = value;
                    this.SendPropertyChanged("UNIT_DESC");
                    this.OnUNIT_DESCChanged();
                }
            }
        }

        [Column(Storage = "_EXTERNAL_UNIT", DbType = "Int")]
        public System.Nullable<int> EXTERNAL_UNIT
        {
            get
            {
                return this._EXTERNAL_UNIT;
            }
            set
            {
                if ((this._EXTERNAL_UNIT != value))
                {
                    if (this._HR_UNIT.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEXTERNAL_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._EXTERNAL_UNIT = value;
                    this.SendPropertyChanged("EXTERNAL_UNIT");
                    this.OnEXTERNAL_UNITChanged();
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

        [Association(Name = "INV_UNIT_INV_REQUISITION", Storage = "_INV_REQUISITIONs", ThisKey = "UNIT_ID", OtherKey = "FROM_UNIT")]
        public EntitySet<INV_REQUISITION> INV_REQUISITIONs
        {
            get
            {
                return this._INV_REQUISITIONs;
            }
            set
            {
                this._INV_REQUISITIONs.Assign(value);
            }
        }

        [Association(Name = "INV_UNIT_INV_REQUISITION1", Storage = "_INV_REQUISITIONs1", ThisKey = "UNIT_ID", OtherKey = "TO_UNIT")]
        public EntitySet<INV_REQUISITION> INV_REQUISITIONs1
        {
            get
            {
                return this._INV_REQUISITIONs1;
            }
            set
            {
                this._INV_REQUISITIONs1.Assign(value);
            }
        }

        [Association(Name = "INV_UNIT_INV_ROOMSTOCKREDUCE", Storage = "_INV_ROOMSTOCKREDUCEs", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID")]
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

        [Association(Name = "INV_UNIT_INV_TRANSACTION", Storage = "_INV_TRANSACTIONs", ThisKey = "UNIT_ID", OtherKey = "TO_UNIT")]
        public EntitySet<INV_TRANSACTION> INV_TRANSACTIONs
        {
            get
            {
                return this._INV_TRANSACTIONs;
            }
            set
            {
                this._INV_TRANSACTIONs.Assign(value);
            }
        }

        [Association(Name = "INV_UNIT_INV_TRANSACTION1", Storage = "_INV_TRANSACTIONs1", ThisKey = "UNIT_ID", OtherKey = "FROM_UNIT")]
        public EntitySet<INV_TRANSACTION> INV_TRANSACTIONs1
        {
            get
            {
                return this._INV_TRANSACTIONs1;
            }
            set
            {
                this._INV_TRANSACTIONs1.Assign(value);
            }
        }

        [Association(Name = "INV_UNIT_INV_UNITREORDERLEVEL", Storage = "_INV_UNITREORDERLEVELs", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID")]
        public EntitySet<INV_UNITREORDERLEVEL> INV_UNITREORDERLEVELs
        {
            get
            {
                return this._INV_UNITREORDERLEVELs;
            }
            set
            {
                this._INV_UNITREORDERLEVELs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_UNIT", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_UNITs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_UNITs.Add(this);
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

        [Association(Name = "HR_UNIT_INV_UNIT", Storage = "_HR_UNIT", ThisKey = "EXTERNAL_UNIT", OtherKey = "UNIT_ID", IsForeignKey = true)]
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
                        previousValue.INV_UNITs.Remove(this);
                    }
                    this._HR_UNIT.Entity = value;
                    if ((value != null))
                    {
                        value.INV_UNITs.Add(this);
                        this._EXTERNAL_UNIT = value.UNIT_ID;
                    }
                    else
                    {
                        this._EXTERNAL_UNIT = default(Nullable<int>);
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

        private void attach_INV_REQUISITIONs(INV_REQUISITION entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT = this;
        }

        private void detach_INV_REQUISITIONs(INV_REQUISITION entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT = null;
        }

        private void attach_INV_REQUISITIONs1(INV_REQUISITION entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT1 = this;
        }

        private void detach_INV_REQUISITIONs1(INV_REQUISITION entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT1 = null;
        }

        private void attach_INV_ROOMSTOCKREDUCEs(INV_ROOMSTOCKREDUCE entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT = this;
        }

        private void detach_INV_ROOMSTOCKREDUCEs(INV_ROOMSTOCKREDUCE entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT = null;
        }

        private void attach_INV_TRANSACTIONs(INV_TRANSACTION entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT = this;
        }

        private void detach_INV_TRANSACTIONs(INV_TRANSACTION entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT = null;
        }

        private void attach_INV_TRANSACTIONs1(INV_TRANSACTION entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT1 = this;
        }

        private void detach_INV_TRANSACTIONs1(INV_TRANSACTION entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT1 = null;
        }

        private void attach_INV_UNITREORDERLEVELs(INV_UNITREORDERLEVEL entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT = this;
        }

        private void detach_INV_UNITREORDERLEVELs(INV_UNITREORDERLEVEL entity)
        {
            this.SendPropertyChanging();
            entity.INV_UNIT = null;
        }
    }
}
