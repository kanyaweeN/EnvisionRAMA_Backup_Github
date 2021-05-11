using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;

namespace EnvisionOnline.Common
{
    [Table(Name = "dbo.GBL_MENU")]
    public partial class GBL_MENU : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _MENU_ID;

        private string _MENU_UID;

        private string _MENU_NAME;

        private string _MENU_NAMESPACE;

        private string _DESCR;

        private System.Nullable<int> _PARENT;

        private System.Nullable<int> _SL_NO;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<GBL_SUBMENU> _GBL_SUBMENUs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnMENU_IDChanging(int value);
        partial void OnMENU_IDChanged();
        partial void OnMENU_UIDChanging(string value);
        partial void OnMENU_UIDChanged();
        partial void OnMENU_NAMEChanging(string value);
        partial void OnMENU_NAMEChanged();
        partial void OnMENU_NAMESPACEChanging(string value);
        partial void OnMENU_NAMESPACEChanged();
        partial void OnDESCRChanging(string value);
        partial void OnDESCRChanged();
        partial void OnPARENTChanging(System.Nullable<int> value);
        partial void OnPARENTChanged();
        partial void OnSL_NOChanging(System.Nullable<int> value);
        partial void OnSL_NOChanged();
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

        public GBL_MENU()
        {
            this._GBL_SUBMENUs = new EntitySet<GBL_SUBMENU>(new Action<GBL_SUBMENU>(this.attach_GBL_SUBMENUs), new Action<GBL_SUBMENU>(this.detach_GBL_SUBMENUs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_MENU_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int MENU_ID
        {
            get
            {
                return this._MENU_ID;
            }
            set
            {
                if ((this._MENU_ID != value))
                {
                    this.OnMENU_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MENU_ID = value;
                    this.SendPropertyChanged("MENU_ID");
                    this.OnMENU_IDChanged();
                }
            }
        }

        [Column(Storage = "_MENU_UID", DbType = "NVarChar(30)")]
        public string MENU_UID
        {
            get
            {
                return this._MENU_UID;
            }
            set
            {
                if ((this._MENU_UID != value))
                {
                    this.OnMENU_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._MENU_UID = value;
                    this.SendPropertyChanged("MENU_UID");
                    this.OnMENU_UIDChanged();
                }
            }
        }

        [Column(Storage = "_MENU_NAME", DbType = "NVarChar(50)")]
        public string MENU_NAME
        {
            get
            {
                return this._MENU_NAME;
            }
            set
            {
                if ((this._MENU_NAME != value))
                {
                    this.OnMENU_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._MENU_NAME = value;
                    this.SendPropertyChanged("MENU_NAME");
                    this.OnMENU_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_MENU_NAMESPACE", DbType = "NVarChar(100)")]
        public string MENU_NAMESPACE
        {
            get
            {
                return this._MENU_NAMESPACE;
            }
            set
            {
                if ((this._MENU_NAMESPACE != value))
                {
                    this.OnMENU_NAMESPACEChanging(value);
                    this.SendPropertyChanging();
                    this._MENU_NAMESPACE = value;
                    this.SendPropertyChanged("MENU_NAMESPACE");
                    this.OnMENU_NAMESPACEChanged();
                }
            }
        }

        [Column(Storage = "_DESCR", DbType = "NVarChar(100)")]
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

        [Column(Storage = "_PARENT", DbType = "Int")]
        public System.Nullable<int> PARENT
        {
            get
            {
                return this._PARENT;
            }
            set
            {
                if ((this._PARENT != value))
                {
                    this.OnPARENTChanging(value);
                    this.SendPropertyChanging();
                    this._PARENT = value;
                    this.SendPropertyChanged("PARENT");
                    this.OnPARENTChanged();
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

        [Association(Name = "GBL_MENU_GBL_SUBMENU", Storage = "_GBL_SUBMENUs", ThisKey = "MENU_ID", OtherKey = "MENU_ID")]
        public EntitySet<GBL_SUBMENU> GBL_SUBMENUs
        {
            get
            {
                return this._GBL_SUBMENUs;
            }
            set
            {
                this._GBL_SUBMENUs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_MENU", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_MENUs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_MENUs.Add(this);
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
        public int MenuID
        {
            get;
            set;
        }

        public string MenuUID
        {
            get;
            set;
        }

        public string MenuName
        {
            get;
            set;
        }

        public string MenuNameSpace
        {
            get;
            set;
        }

        public string MenuDesc
        {
            get;
            set;
        }

        public int MenuParent
        {
            get;
            set;
        }

        public int MenuSLNo
        {
            get;
            set;
        }

        public string MenuIsActive
        {
            get;
            set;
        }

        public int OrgID
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public string CreatedOn
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public string ModifiedOn
        {
            get;
            set;
        }

        public byte[] MenuICon
        {
            get;
            set;
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

        private void attach_GBL_SUBMENUs(GBL_SUBMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_MENU = this;
        }

        private void detach_GBL_SUBMENUs(GBL_SUBMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_MENU = null;
        }
    }

    public class menuObjectCollection : CollectionBase
    {
        public void Add(GBL_MENU _menuObject)
        {
            this.List.Add(_menuObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBL_MENU this[int index]
        {
            get
            {
                return (GBL_MENU)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
