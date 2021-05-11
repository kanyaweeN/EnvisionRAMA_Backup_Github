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
    [Table(Name = "dbo.GBL_GRANTROLE")]
    public partial class GBL_GRANTROLE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _GRANTROLE_ID;

        private int _ROLE_ID;

        private int _EMP_ID;

        private System.Nullable<int> _CAN_GRANT;

        private System.Nullable<int> _GRANTOR;

        private System.Nullable<System.DateTime> _GRANT_DT;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<GBL_ROLE> _GBL_ROLE;

        private EntityRef<HR_EMP> _HR_EMP;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnGRANTROLE_IDChanging(int value);
        partial void OnGRANTROLE_IDChanged();
        partial void OnROLE_IDChanging(int value);
        partial void OnROLE_IDChanged();
        partial void OnEMP_IDChanging(int value);
        partial void OnEMP_IDChanged();
        partial void OnCAN_GRANTChanging(System.Nullable<int> value);
        partial void OnCAN_GRANTChanged();
        partial void OnGRANTORChanging(System.Nullable<int> value);
        partial void OnGRANTORChanged();
        partial void OnGRANT_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnGRANT_DTChanged();
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
        #endregion

        public GBL_GRANTROLE()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._GBL_ROLE = default(EntityRef<GBL_ROLE>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            OnCreated();
        }

        [Column(Storage = "_GRANTROLE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int GRANTROLE_ID
        {
            get
            {
                return this._GRANTROLE_ID;
            }
            set
            {
                if ((this._GRANTROLE_ID != value))
                {
                    this.OnGRANTROLE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._GRANTROLE_ID = value;
                    this.SendPropertyChanged("GRANTROLE_ID");
                    this.OnGRANTROLE_IDChanged();
                }
            }
        }

        [Column(Storage = "_ROLE_ID", DbType = "Int NOT NULL")]
        public int ROLE_ID
        {
            get
            {
                return this._ROLE_ID;
            }
            set
            {
                if ((this._ROLE_ID != value))
                {
                    if (this._GBL_ROLE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnROLE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ROLE_ID = value;
                    this.SendPropertyChanged("ROLE_ID");
                    this.OnROLE_IDChanged();
                }
            }
        }

        [Column(Storage = "_EMP_ID", DbType = "Int NOT NULL")]
        public int EMP_ID
        {
            get
            {
                return this._EMP_ID;
            }
            set
            {
                if ((this._EMP_ID != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEMP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_ID = value;
                    this.SendPropertyChanged("EMP_ID");
                    this.OnEMP_IDChanged();
                }
            }
        }

        [Column(Storage = "_CAN_GRANT", DbType = "Int")]
        public System.Nullable<int> CAN_GRANT
        {
            get
            {
                return this._CAN_GRANT;
            }
            set
            {
                if ((this._CAN_GRANT != value))
                {
                    this.OnCAN_GRANTChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_GRANT = value;
                    this.SendPropertyChanged("CAN_GRANT");
                    this.OnCAN_GRANTChanged();
                }
            }
        }

        [Column(Storage = "_GRANTOR", DbType = "Int")]
        public System.Nullable<int> GRANTOR
        {
            get
            {
                return this._GRANTOR;
            }
            set
            {
                if ((this._GRANTOR != value))
                {
                    this.OnGRANTORChanging(value);
                    this.SendPropertyChanging();
                    this._GRANTOR = value;
                    this.SendPropertyChanged("GRANTOR");
                    this.OnGRANTORChanged();
                }
            }
        }

        [Column(Storage = "_GRANT_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> GRANT_DT
        {
            get
            {
                return this._GRANT_DT;
            }
            set
            {
                if ((this._GRANT_DT != value))
                {
                    this.OnGRANT_DTChanging(value);
                    this.SendPropertyChanging();
                    this._GRANT_DT = value;
                    this.SendPropertyChanged("GRANT_DT");
                    this.OnGRANT_DTChanged();
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

        [Association(Name = "GBL_ENV_GBL_GRANTROLE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_GRANTROLEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_GRANTROLEs.Add(this);
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

        [Association(Name = "GBL_ROLE_GBL_GRANTROLE", Storage = "_GBL_ROLE", ThisKey = "ROLE_ID", OtherKey = "ROLE_ID", IsForeignKey = true)]
        public GBL_ROLE GBL_ROLE
        {
            get
            {
                return this._GBL_ROLE.Entity;
            }
            set
            {
                GBL_ROLE previousValue = this._GBL_ROLE.Entity;
                if (((previousValue != value)
                            || (this._GBL_ROLE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_ROLE.Entity = null;
                        previousValue.GBL_GRANTROLEs.Remove(this);
                    }
                    this._GBL_ROLE.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_GRANTROLEs.Add(this);
                        this._ROLE_ID = value.ROLE_ID;
                    }
                    else
                    {
                        this._ROLE_ID = default(int);
                    }
                    this.SendPropertyChanged("GBL_ROLE");
                }
            }
        }

        [Association(Name = "HR_EMP_GBL_GRANTROLE", Storage = "_HR_EMP", ThisKey = "EMP_ID", OtherKey = "EMP_ID", IsForeignKey = true)]
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
                        previousValue.GBL_GRANTROLEs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_GRANTROLEs.Add(this);
                        this._EMP_ID = value.EMP_ID;
                    }
                    else
                    {
                        this._EMP_ID = default(int);
                    }
                    this.SendPropertyChanged("HR_EMP");
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
    }
}
