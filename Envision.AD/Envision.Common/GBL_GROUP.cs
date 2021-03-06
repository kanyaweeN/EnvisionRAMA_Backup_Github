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
    [Table(Name = "dbo.GBL_GROUP")]
    public partial class GBL_GROUP : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _GROUP_ID;

        private string _GROUP_UID;

        private string _GROUP_NAME;

        private string _GROUP_USER_NAME;

        private string _GROUP_PASS;

        private string _GROUP_TYPE;

        private System.Nullable<int> _GROUP_HEAD;

        private string _GROUP_HEAD_NAME;

        private System.Nullable<int> _GROUP_CONTACT_NO;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_EMP> _HR_EMP;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnGROUP_IDChanging(int value);
        partial void OnGROUP_IDChanged();
        partial void OnGROUP_UIDChanging(string value);
        partial void OnGROUP_UIDChanged();
        partial void OnGROUP_NAMEChanging(string value);
        partial void OnGROUP_NAMEChanged();
        partial void OnGROUP_USER_NAMEChanging(string value);
        partial void OnGROUP_USER_NAMEChanged();
        partial void OnGROUP_PASSChanging(string value);
        partial void OnGROUP_PASSChanged();
        partial void OnGROUP_TYPEChanging(string value);
        partial void OnGROUP_TYPEChanged();
        partial void OnGROUP_HEADChanging(System.Nullable<int> value);
        partial void OnGROUP_HEADChanged();
        partial void OnGROUP_HEAD_NAMEChanging(string value);
        partial void OnGROUP_HEAD_NAMEChanged();
        partial void OnGROUP_CONTACT_NOChanging(System.Nullable<int> value);
        partial void OnGROUP_CONTACT_NOChanged();
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

        public GBL_GROUP()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            OnCreated();
        }

        [Column(Storage = "_GROUP_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int GROUP_ID
        {
            get
            {
                return this._GROUP_ID;
            }
            set
            {
                if ((this._GROUP_ID != value))
                {
                    this.OnGROUP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_ID = value;
                    this.SendPropertyChanged("GROUP_ID");
                    this.OnGROUP_IDChanged();
                }
            }
        }

        [Column(Storage = "_GROUP_UID", DbType = "NVarChar(30)")]
        public string GROUP_UID
        {
            get
            {
                return this._GROUP_UID;
            }
            set
            {
                if ((this._GROUP_UID != value))
                {
                    this.OnGROUP_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_UID = value;
                    this.SendPropertyChanged("GROUP_UID");
                    this.OnGROUP_UIDChanged();
                }
            }
        }

        [Column(Storage = "_GROUP_NAME", DbType = "NVarChar(50)")]
        public string GROUP_NAME
        {
            get
            {
                return this._GROUP_NAME;
            }
            set
            {
                if ((this._GROUP_NAME != value))
                {
                    this.OnGROUP_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_NAME = value;
                    this.SendPropertyChanged("GROUP_NAME");
                    this.OnGROUP_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_GROUP_USER_NAME", DbType = "NVarChar(50)")]
        public string GROUP_USER_NAME
        {
            get
            {
                return this._GROUP_USER_NAME;
            }
            set
            {
                if ((this._GROUP_USER_NAME != value))
                {
                    this.OnGROUP_USER_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_USER_NAME = value;
                    this.SendPropertyChanged("GROUP_USER_NAME");
                    this.OnGROUP_USER_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_GROUP_PASS", DbType = "NVarChar(50)")]
        public string GROUP_PASS
        {
            get
            {
                return this._GROUP_PASS;
            }
            set
            {
                if ((this._GROUP_PASS != value))
                {
                    this.OnGROUP_PASSChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_PASS = value;
                    this.SendPropertyChanged("GROUP_PASS");
                    this.OnGROUP_PASSChanged();
                }
            }
        }

        [Column(Storage = "_GROUP_TYPE", DbType = "NVarChar(5)")]
        public string GROUP_TYPE
        {
            get
            {
                return this._GROUP_TYPE;
            }
            set
            {
                if ((this._GROUP_TYPE != value))
                {
                    this.OnGROUP_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_TYPE = value;
                    this.SendPropertyChanged("GROUP_TYPE");
                    this.OnGROUP_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_GROUP_HEAD", DbType = "Int")]
        public System.Nullable<int> GROUP_HEAD
        {
            get
            {
                return this._GROUP_HEAD;
            }
            set
            {
                if ((this._GROUP_HEAD != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnGROUP_HEADChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_HEAD = value;
                    this.SendPropertyChanged("GROUP_HEAD");
                    this.OnGROUP_HEADChanged();
                }
            }
        }

        [Column(Storage = "_GROUP_HEAD_NAME", DbType = "NVarChar(50)")]
        public string GROUP_HEAD_NAME
        {
            get
            {
                return this._GROUP_HEAD_NAME;
            }
            set
            {
                if ((this._GROUP_HEAD_NAME != value))
                {
                    this.OnGROUP_HEAD_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_HEAD_NAME = value;
                    this.SendPropertyChanged("GROUP_HEAD_NAME");
                    this.OnGROUP_HEAD_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_GROUP_CONTACT_NO", DbType = "Int")]
        public System.Nullable<int> GROUP_CONTACT_NO
        {
            get
            {
                return this._GROUP_CONTACT_NO;
            }
            set
            {
                if ((this._GROUP_CONTACT_NO != value))
                {
                    this.OnGROUP_CONTACT_NOChanging(value);
                    this.SendPropertyChanging();
                    this._GROUP_CONTACT_NO = value;
                    this.SendPropertyChanged("GROUP_CONTACT_NO");
                    this.OnGROUP_CONTACT_NOChanged();
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

        [Association(Name = "GBL_ENV_GBL_GROUP", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_GROUPs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_GROUPs.Add(this);
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

        [Association(Name = "HR_EMP_GBL_GROUP", Storage = "_HR_EMP", ThisKey = "GROUP_HEAD", OtherKey = "EMP_ID", IsForeignKey = true)]
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
                        previousValue.GBL_GROUPs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_GROUPs.Add(this);
                        this._GROUP_HEAD = value.EMP_ID;
                    }
                    else
                    {
                        this._GROUP_HEAD = default(Nullable<int>);
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
