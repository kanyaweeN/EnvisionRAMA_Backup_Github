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
    [Table(Name = "dbo.INV_REQUISITION")]
    public partial class INV_REQUISITION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _REQUISITION_ID;

        private string _REQUISITION_UID;

        private System.Nullable<char> _REQUISITION_TYPE;

        private System.Nullable<char> _GENERATE_MODE;

        private System.Nullable<int> _FROM_UNIT;

        private System.Nullable<int> _TO_UNIT;

        private System.Nullable<int> _GENERATED_BY;

        private System.Nullable<System.DateTime> _GENERATED_ON;

        private System.Nullable<char> _STATUS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<char> _IS_STAT;

        private EntitySet<INV_AUTHORIZATION> _INV_AUTHORIZATIONs;

        private EntitySet<INV_REQUISITIONDTL> _INV_REQUISITIONDTLs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_EMP> _HR_EMP;

        private EntityRef<INV_UNIT> _INV_UNIT;

        private EntityRef<INV_UNIT> _INV_UNIT1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnREQUISITION_IDChanging(int value);
        partial void OnREQUISITION_IDChanged();
        partial void OnREQUISITION_UIDChanging(string value);
        partial void OnREQUISITION_UIDChanged();
        partial void OnREQUISITION_TYPEChanging(System.Nullable<char> value);
        partial void OnREQUISITION_TYPEChanged();
        partial void OnGENERATE_MODEChanging(System.Nullable<char> value);
        partial void OnGENERATE_MODEChanged();
        partial void OnFROM_UNITChanging(System.Nullable<int> value);
        partial void OnFROM_UNITChanged();
        partial void OnTO_UNITChanging(System.Nullable<int> value);
        partial void OnTO_UNITChanged();
        partial void OnGENERATED_BYChanging(System.Nullable<int> value);
        partial void OnGENERATED_BYChanged();
        partial void OnGENERATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnGENERATED_ONChanged();
        partial void OnSTATUSChanging(System.Nullable<char> value);
        partial void OnSTATUSChanged();
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
        partial void OnIS_STATChanging(System.Nullable<char> value);
        partial void OnIS_STATChanged();
        #endregion

        public INV_REQUISITION()
        {
            this._INV_AUTHORIZATIONs = new EntitySet<INV_AUTHORIZATION>(new Action<INV_AUTHORIZATION>(this.attach_INV_AUTHORIZATIONs), new Action<INV_AUTHORIZATION>(this.detach_INV_AUTHORIZATIONs));
            this._INV_REQUISITIONDTLs = new EntitySet<INV_REQUISITIONDTL>(new Action<INV_REQUISITIONDTL>(this.attach_INV_REQUISITIONDTLs), new Action<INV_REQUISITIONDTL>(this.detach_INV_REQUISITIONDTLs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            this._INV_UNIT = default(EntityRef<INV_UNIT>);
            this._INV_UNIT1 = default(EntityRef<INV_UNIT>);
            OnCreated();
        }

        [Column(Storage = "_REQUISITION_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int REQUISITION_ID
        {
            get
            {
                return this._REQUISITION_ID;
            }
            set
            {
                if ((this._REQUISITION_ID != value))
                {
                    this.OnREQUISITION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REQUISITION_ID = value;
                    this.SendPropertyChanged("REQUISITION_ID");
                    this.OnREQUISITION_IDChanged();
                }
            }
        }

        [Column(Storage = "_REQUISITION_UID", DbType = "NVarChar(50)")]
        public string REQUISITION_UID
        {
            get
            {
                return this._REQUISITION_UID;
            }
            set
            {
                if ((this._REQUISITION_UID != value))
                {
                    this.OnREQUISITION_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._REQUISITION_UID = value;
                    this.SendPropertyChanged("REQUISITION_UID");
                    this.OnREQUISITION_UIDChanged();
                }
            }
        }

        [Column(Storage = "_REQUISITION_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> REQUISITION_TYPE
        {
            get
            {
                return this._REQUISITION_TYPE;
            }
            set
            {
                if ((this._REQUISITION_TYPE != value))
                {
                    this.OnREQUISITION_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._REQUISITION_TYPE = value;
                    this.SendPropertyChanged("REQUISITION_TYPE");
                    this.OnREQUISITION_TYPEChanged();
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

        [Column(Storage = "_FROM_UNIT", DbType = "Int")]
        public System.Nullable<int> FROM_UNIT
        {
            get
            {
                return this._FROM_UNIT;
            }
            set
            {
                if ((this._FROM_UNIT != value))
                {
                    if (this._INV_UNIT.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnFROM_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._FROM_UNIT = value;
                    this.SendPropertyChanged("FROM_UNIT");
                    this.OnFROM_UNITChanged();
                }
            }
        }

        [Column(Storage = "_TO_UNIT", DbType = "Int")]
        public System.Nullable<int> TO_UNIT
        {
            get
            {
                return this._TO_UNIT;
            }
            set
            {
                if ((this._TO_UNIT != value))
                {
                    if (this._INV_UNIT1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTO_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._TO_UNIT = value;
                    this.SendPropertyChanged("TO_UNIT");
                    this.OnTO_UNITChanged();
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
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
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

        [Column(Storage = "_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> STATUS
        {
            get
            {
                return this._STATUS;
            }
            set
            {
                if ((this._STATUS != value))
                {
                    this.OnSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS = value;
                    this.SendPropertyChanged("STATUS");
                    this.OnSTATUSChanged();
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

        [Column(Storage = "_IS_STAT", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_STAT
        {
            get
            {
                return this._IS_STAT;
            }
            set
            {
                if ((this._IS_STAT != value))
                {
                    this.OnIS_STATChanging(value);
                    this.SendPropertyChanging();
                    this._IS_STAT = value;
                    this.SendPropertyChanged("IS_STAT");
                    this.OnIS_STATChanged();
                }
            }
        }

        [Association(Name = "INV_REQUISITION_INV_AUTHORIZATION", Storage = "_INV_AUTHORIZATIONs", ThisKey = "REQUISITION_ID", OtherKey = "PR_ID")]
        public EntitySet<INV_AUTHORIZATION> INV_AUTHORIZATIONs
        {
            get
            {
                return this._INV_AUTHORIZATIONs;
            }
            set
            {
                this._INV_AUTHORIZATIONs.Assign(value);
            }
        }

        [Association(Name = "INV_REQUISITION_INV_REQUISITIONDTL", Storage = "_INV_REQUISITIONDTLs", ThisKey = "REQUISITION_ID", OtherKey = "REQUISITION_ID")]
        public EntitySet<INV_REQUISITIONDTL> INV_REQUISITIONDTLs
        {
            get
            {
                return this._INV_REQUISITIONDTLs;
            }
            set
            {
                this._INV_REQUISITIONDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_INV_REQUISITION", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_REQUISITIONs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_REQUISITIONs.Add(this);
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

        [Association(Name = "HR_EMP_INV_REQUISITION", Storage = "_HR_EMP", ThisKey = "GENERATED_BY", OtherKey = "EMP_ID", IsForeignKey = true)]
        public HR_EMP HR_EMP
        {
            get
            {
                return this._HR_EMP.Entity;
            }
            set
            {
                HR_EMP previousValue = this._HR_EMP.Entity;
                if (((previousValue != value)
                            || (this._HR_EMP.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_EMP.Entity = null;
                        previousValue.INV_REQUISITIONs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.INV_REQUISITIONs.Add(this);
                        this._GENERATED_BY = value.EMP_ID;
                    }
                    else
                    {
                        this._GENERATED_BY = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        [Association(Name = "INV_UNIT_INV_REQUISITION", Storage = "_INV_UNIT", ThisKey = "FROM_UNIT", OtherKey = "UNIT_ID", IsForeignKey = true)]
        public INV_UNIT INV_UNIT
        {
            get
            {
                return this._INV_UNIT.Entity;
            }
            set
            {
                INV_UNIT previousValue = this._INV_UNIT.Entity;
                if (((previousValue != value)
                            || (this._INV_UNIT.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_UNIT.Entity = null;
                        previousValue.INV_REQUISITIONs.Remove(this);
                    }
                    this._INV_UNIT.Entity = value;
                    if ((value != null))
                    {
                        value.INV_REQUISITIONs.Add(this);
                        this._FROM_UNIT = value.UNIT_ID;
                    }
                    else
                    {
                        this._FROM_UNIT = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("INV_UNIT");
                }
            }
        }

        [Association(Name = "INV_UNIT_INV_REQUISITION1", Storage = "_INV_UNIT1", ThisKey = "TO_UNIT", OtherKey = "UNIT_ID", IsForeignKey = true)]
        public INV_UNIT INV_UNIT1
        {
            get
            {
                return this._INV_UNIT1.Entity;
            }
            set
            {
                INV_UNIT previousValue = this._INV_UNIT1.Entity;
                if (((previousValue != value)
                            || (this._INV_UNIT1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_UNIT1.Entity = null;
                        previousValue.INV_REQUISITIONs1.Remove(this);
                    }
                    this._INV_UNIT1.Entity = value;
                    if ((value != null))
                    {
                        value.INV_REQUISITIONs1.Add(this);
                        this._TO_UNIT = value.UNIT_ID;
                    }
                    else
                    {
                        this._TO_UNIT = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("INV_UNIT1");
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

        private void attach_INV_AUTHORIZATIONs(INV_AUTHORIZATION entity)
        {
            this.SendPropertyChanging();
            entity.INV_REQUISITION = this;
        }

        private void detach_INV_AUTHORIZATIONs(INV_AUTHORIZATION entity)
        {
            this.SendPropertyChanging();
            entity.INV_REQUISITION = null;
        }

        private void attach_INV_REQUISITIONDTLs(INV_REQUISITIONDTL entity)
        {
            this.SendPropertyChanging();
            entity.INV_REQUISITION = this;
        }

        private void detach_INV_REQUISITIONDTLs(INV_REQUISITIONDTL entity)
        {
            this.SendPropertyChanging();
            entity.INV_REQUISITION = null;
        }
    }
}
