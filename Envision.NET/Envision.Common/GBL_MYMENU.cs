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
    [Table(Name = "dbo.GBL_MYMENU")]
    public partial class GBL_MYMENU : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _MYMENU_ID;

        private System.Nullable<int> _MYMENU_UID;

        private System.Nullable<int> _EMP_ID;

        private System.Nullable<int> _SL_NO;

        private System.Nullable<int> _SUBMENU_ID;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<GBL_ENV> _GBL_ENV1;

        private EntityRef<GBL_ENV> _GBL_ENV2;

        private EntityRef<GBL_SUBMENU> _GBL_SUBMENU;

        private EntityRef<HR_EMP> _HR_EMP;

        private EntityRef<HR_EMP> _HR_EMP1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnMYMENU_IDChanging(int value);
        partial void OnMYMENU_IDChanged();
        partial void OnMYMENU_UIDChanging(System.Nullable<int> value);
        partial void OnMYMENU_UIDChanged();
        partial void OnEMP_IDChanging(System.Nullable<int> value);
        partial void OnEMP_IDChanged();
        partial void OnSL_NOChanging(System.Nullable<int> value);
        partial void OnSL_NOChanged();
        partial void OnSUBMENU_IDChanging(System.Nullable<int> value);
        partial void OnSUBMENU_IDChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public GBL_MYMENU()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._GBL_ENV1 = default(EntityRef<GBL_ENV>);
            this._GBL_ENV2 = default(EntityRef<GBL_ENV>);
            this._GBL_SUBMENU = default(EntityRef<GBL_SUBMENU>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            this._HR_EMP1 = default(EntityRef<HR_EMP>);
            OnCreated();
        }

        [Column(Storage = "_MYMENU_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int MYMENU_ID
        {
            get
            {
                return this._MYMENU_ID;
            }
            set
            {
                if ((this._MYMENU_ID != value))
                {
                    this.OnMYMENU_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MYMENU_ID = value;
                    this.SendPropertyChanged("MYMENU_ID");
                    this.OnMYMENU_IDChanged();
                }
            }
        }

        [Column(Storage = "_MYMENU_UID", DbType = "Int")]
        public System.Nullable<int> MYMENU_UID
        {
            get
            {
                return this._MYMENU_UID;
            }
            set
            {
                if ((this._MYMENU_UID != value))
                {
                    this.OnMYMENU_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._MYMENU_UID = value;
                    this.SendPropertyChanged("MYMENU_UID");
                    this.OnMYMENU_UIDChanged();
                }
            }
        }

        [Column(Storage = "_EMP_ID", DbType = "Int")]
        public System.Nullable<int> EMP_ID
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

        [Column(Storage = "_SL_NO", DbType = "Int")]
        public System.Nullable<int> SL_NO
        {
            get
            {
                return this._SL_NO;
            }
            set
            {
                if ((this._SL_NO != value))
                {
                    this.OnSL_NOChanging(value);
                    this.SendPropertyChanging();
                    this._SL_NO = value;
                    this.SendPropertyChanged("SL_NO");
                    this.OnSL_NOChanged();
                }
            }
        }

        [Column(Storage = "_SUBMENU_ID", DbType = "Int")]
        public System.Nullable<int> SUBMENU_ID
        {
            get
            {
                return this._SUBMENU_ID;
            }
            set
            {
                if ((this._SUBMENU_ID != value))
                {
                    if (this._GBL_SUBMENU.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSUBMENU_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SUBMENU_ID = value;
                    this.SendPropertyChanged("SUBMENU_ID");
                    this.OnSUBMENU_IDChanged();
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

        [Association(Name = "GBL_ENV_GBL_MYMENU", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_MYMENUs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_MYMENUs.Add(this);
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

        [Association(Name = "GBL_ENV_GBL_MYMENU1", Storage = "_GBL_ENV1", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
        public GBL_ENV GBL_ENV1
        {
            get
            {
                return this._GBL_ENV1.Entity;
            }
            set
            {
                GBL_ENV previousValue = this._GBL_ENV1.Entity;
                if (((previousValue != value)
                            || (this._GBL_ENV1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_ENV1.Entity = null;
                        previousValue.GBL_MYMENUs1.Remove(this);
                    }
                    this._GBL_ENV1.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_MYMENUs1.Add(this);
                        this._ORG_ID = value.ORG_ID;
                    }
                    else
                    {
                        this._ORG_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_ENV1");
                }
            }
        }

        [Association(Name = "GBL_ENV_GBL_MYMENU2", Storage = "_GBL_ENV2", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
        public GBL_ENV GBL_ENV2
        {
            get
            {
                return this._GBL_ENV2.Entity;
            }
            set
            {
                GBL_ENV previousValue = this._GBL_ENV2.Entity;
                if (((previousValue != value)
                            || (this._GBL_ENV2.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_ENV2.Entity = null;
                        previousValue.GBL_MYMENUs2.Remove(this);
                    }
                    this._GBL_ENV2.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_MYMENUs2.Add(this);
                        this._ORG_ID = value.ORG_ID;
                    }
                    else
                    {
                        this._ORG_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_ENV2");
                }
            }
        }

        [Association(Name = "GBL_SUBMENU_GBL_MYMENU", Storage = "_GBL_SUBMENU", ThisKey = "SUBMENU_ID", OtherKey = "SUBMENU_ID", IsForeignKey = true)]
        public GBL_SUBMENU GBL_SUBMENU
        {
            get
            {
                return this._GBL_SUBMENU.Entity;
            }
            set
            {
                GBL_SUBMENU previousValue = this._GBL_SUBMENU.Entity;
                if (((previousValue != value)
                            || (this._GBL_SUBMENU.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_SUBMENU.Entity = null;
                        previousValue.GBL_MYMENUs.Remove(this);
                    }
                    this._GBL_SUBMENU.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_MYMENUs.Add(this);
                        this._SUBMENU_ID = value.SUBMENU_ID;
                    }
                    else
                    {
                        this._SUBMENU_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_SUBMENU");
                }
            }
        }

        [Association(Name = "HR_EMP_GBL_MYMENU", Storage = "_HR_EMP", ThisKey = "EMP_ID", OtherKey = "EMP_ID", IsForeignKey = true)]
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
                        previousValue.GBL_MYMENUs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_MYMENUs.Add(this);
                        this._EMP_ID = value.EMP_ID;
                    }
                    else
                    {
                        this._EMP_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        [Association(Name = "HR_EMP_GBL_MYMENU1", Storage = "_HR_EMP1", ThisKey = "EMP_ID", OtherKey = "EMP_ID", IsForeignKey = true)]
        public HR_EMP HR_EMP1
        {
            get
            {
                return this._HR_EMP1.Entity;
            }
            set
            {
                HR_EMP previousValue = this._HR_EMP1.Entity;
                if (((previousValue != value)
                            || (this._HR_EMP1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_EMP1.Entity = null;
                        previousValue.GBL_MYMENUs1.Remove(this);
                    }
                    this._HR_EMP1.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_MYMENUs1.Add(this);
                        this._EMP_ID = value.EMP_ID;
                    }
                    else
                    {
                        this._EMP_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP1");
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
