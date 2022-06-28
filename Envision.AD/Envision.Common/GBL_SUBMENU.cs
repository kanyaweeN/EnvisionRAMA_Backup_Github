using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Envision.Common
{
    [Table(Name = "dbo.GBL_SUBMENU")]
    public partial class GBL_SUBMENU : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SUBMENU_ID;

        private string _SUBMENU_UID;

        private System.Nullable<int> _MENU_ID;

        private System.Nullable<char> _SUBMENU_TYPE;

        private string _SUBMENU_CLASS_NAME;

        private string _SUBMENU_NAME_SYS;

        private string _SUBMENU_NAME_USER;

        private System.Nullable<int> _PARENT;

        private string _DESCR;

        private System.Nullable<int> _SL_NO;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<char> _ADD_TO_HOME;

        private System.Nullable<char> _CAN_VIEW;

        private System.Nullable<char> _CAN_MODIFY;

        private System.Nullable<char> _CAN_REMOVE;

        private System.Nullable<char> _CAN_CREATE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<GBL_GRANTOBJECT> _GBL_GRANTOBJECTs;

        private EntitySet<GBL_MYMENU> _GBL_MYMENUs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<GBL_MENU> _GBL_MENU;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSUBMENU_IDChanging(int value);
        partial void OnSUBMENU_IDChanged();
        partial void OnSUBMENU_UIDChanging(string value);
        partial void OnSUBMENU_UIDChanged();
        partial void OnMENU_IDChanging(System.Nullable<int> value);
        partial void OnMENU_IDChanged();
        partial void OnSUBMENU_TYPEChanging(System.Nullable<char> value);
        partial void OnSUBMENU_TYPEChanged();
        partial void OnSUBMENU_CLASS_NAMEChanging(string value);
        partial void OnSUBMENU_CLASS_NAMEChanged();
        partial void OnSUBMENU_NAME_SYSChanging(string value);
        partial void OnSUBMENU_NAME_SYSChanged();
        partial void OnSUBMENU_NAME_USERChanging(string value);
        partial void OnSUBMENU_NAME_USERChanged();
        partial void OnPARENTChanging(System.Nullable<int> value);
        partial void OnPARENTChanged();
        partial void OnDESCRChanging(string value);
        partial void OnDESCRChanged();
        partial void OnSL_NOChanging(System.Nullable<int> value);
        partial void OnSL_NOChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
        partial void OnADD_TO_HOMEChanging(System.Nullable<char> value);
        partial void OnADD_TO_HOMEChanged();
        partial void OnCAN_VIEWChanging(System.Nullable<char> value);
        partial void OnCAN_VIEWChanged();
        partial void OnCAN_MODIFYChanging(System.Nullable<char> value);
        partial void OnCAN_MODIFYChanged();
        partial void OnCAN_REMOVEChanging(System.Nullable<char> value);
        partial void OnCAN_REMOVEChanged();
        partial void OnCAN_CREATEChanging(System.Nullable<char> value);
        partial void OnCAN_CREATEChanged();
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

        public GBL_SUBMENU()
        {
            this._GBL_GRANTOBJECTs = new EntitySet<GBL_GRANTOBJECT>(new Action<GBL_GRANTOBJECT>(this.attach_GBL_GRANTOBJECTs), new Action<GBL_GRANTOBJECT>(this.detach_GBL_GRANTOBJECTs));
            this._GBL_MYMENUs = new EntitySet<GBL_MYMENU>(new Action<GBL_MYMENU>(this.attach_GBL_MYMENUs), new Action<GBL_MYMENU>(this.detach_GBL_MYMENUs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._GBL_MENU = default(EntityRef<GBL_MENU>);
            OnCreated();
        }

        [Column(Storage = "_SUBMENU_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SUBMENU_ID
        {
            get
            {
                return this._SUBMENU_ID;
            }
            set
            {
                if ((this._SUBMENU_ID != value))
                {
                    this.OnSUBMENU_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SUBMENU_ID = value;
                    this.SendPropertyChanged("SUBMENU_ID");
                    this.OnSUBMENU_IDChanged();
                }
            }
        }

        [Column(Storage = "_SUBMENU_UID", DbType = "NVarChar(30)")]
        public string SUBMENU_UID
        {
            get
            {
                return this._SUBMENU_UID;
            }
            set
            {
                if ((this._SUBMENU_UID != value))
                {
                    this.OnSUBMENU_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._SUBMENU_UID = value;
                    this.SendPropertyChanged("SUBMENU_UID");
                    this.OnSUBMENU_UIDChanged();
                }
            }
        }

        [Column(Storage = "_MENU_ID", DbType = "Int")]
        public System.Nullable<int> MENU_ID
        {
            get
            {
                return this._MENU_ID;
            }
            set
            {
                if ((this._MENU_ID != value))
                {
                    if (this._GBL_MENU.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMENU_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MENU_ID = value;
                    this.SendPropertyChanged("MENU_ID");
                    this.OnMENU_IDChanged();
                }
            }
        }

        [Column(Storage = "_SUBMENU_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> SUBMENU_TYPE
        {
            get
            {
                return this._SUBMENU_TYPE;
            }
            set
            {
                if ((this._SUBMENU_TYPE != value))
                {
                    this.OnSUBMENU_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._SUBMENU_TYPE = value;
                    this.SendPropertyChanged("SUBMENU_TYPE");
                    this.OnSUBMENU_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_SUBMENU_CLASS_NAME", DbType = "NVarChar(50)")]
        public string SUBMENU_CLASS_NAME
        {
            get
            {
                return this._SUBMENU_CLASS_NAME;
            }
            set
            {
                if ((this._SUBMENU_CLASS_NAME != value))
                {
                    this.OnSUBMENU_CLASS_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._SUBMENU_CLASS_NAME = value;
                    this.SendPropertyChanged("SUBMENU_CLASS_NAME");
                    this.OnSUBMENU_CLASS_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_SUBMENU_NAME_SYS", DbType = "NVarChar(50)")]
        public string SUBMENU_NAME_SYS
        {
            get
            {
                return this._SUBMENU_NAME_SYS;
            }
            set
            {
                if ((this._SUBMENU_NAME_SYS != value))
                {
                    this.OnSUBMENU_NAME_SYSChanging(value);
                    this.SendPropertyChanging();
                    this._SUBMENU_NAME_SYS = value;
                    this.SendPropertyChanged("SUBMENU_NAME_SYS");
                    this.OnSUBMENU_NAME_SYSChanged();
                }
            }
        }

        [Column(Storage = "_SUBMENU_NAME_USER", DbType = "NVarChar(50)")]
        public string SUBMENU_NAME_USER
        {
            get
            {
                return this._SUBMENU_NAME_USER;
            }
            set
            {
                if ((this._SUBMENU_NAME_USER != value))
                {
                    this.OnSUBMENU_NAME_USERChanging(value);
                    this.SendPropertyChanging();
                    this._SUBMENU_NAME_USER = value;
                    this.SendPropertyChanged("SUBMENU_NAME_USER");
                    this.OnSUBMENU_NAME_USERChanged();
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

        [Column(Storage = "_ADD_TO_HOME", DbType = "NVarChar(1)")]
        public System.Nullable<char> ADD_TO_HOME
        {
            get
            {
                return this._ADD_TO_HOME;
            }
            set
            {
                if ((this._ADD_TO_HOME != value))
                {
                    this.OnADD_TO_HOMEChanging(value);
                    this.SendPropertyChanging();
                    this._ADD_TO_HOME = value;
                    this.SendPropertyChanged("ADD_TO_HOME");
                    this.OnADD_TO_HOMEChanged();
                }
            }
        }

        [Column(Storage = "_CAN_VIEW", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_VIEW
        {
            get
            {
                return this._CAN_VIEW;
            }
            set
            {
                if ((this._CAN_VIEW != value))
                {
                    this.OnCAN_VIEWChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_VIEW = value;
                    this.SendPropertyChanged("CAN_VIEW");
                    this.OnCAN_VIEWChanged();
                }
            }
        }

        [Column(Storage = "_CAN_MODIFY", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_MODIFY
        {
            get
            {
                return this._CAN_MODIFY;
            }
            set
            {
                if ((this._CAN_MODIFY != value))
                {
                    this.OnCAN_MODIFYChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_MODIFY = value;
                    this.SendPropertyChanged("CAN_MODIFY");
                    this.OnCAN_MODIFYChanged();
                }
            }
        }

        [Column(Storage = "_CAN_REMOVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_REMOVE
        {
            get
            {
                return this._CAN_REMOVE;
            }
            set
            {
                if ((this._CAN_REMOVE != value))
                {
                    this.OnCAN_REMOVEChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_REMOVE = value;
                    this.SendPropertyChanged("CAN_REMOVE");
                    this.OnCAN_REMOVEChanged();
                }
            }
        }

        [Column(Storage = "_CAN_CREATE", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_CREATE
        {
            get
            {
                return this._CAN_CREATE;
            }
            set
            {
                if ((this._CAN_CREATE != value))
                {
                    this.OnCAN_CREATEChanging(value);
                    this.SendPropertyChanging();
                    this._CAN_CREATE = value;
                    this.SendPropertyChanged("CAN_CREATE");
                    this.OnCAN_CREATEChanged();
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

        [Association(Name = "GBL_SUBMENU_GBL_GRANTOBJECT", Storage = "_GBL_GRANTOBJECTs", ThisKey = "SUBMENU_ID", OtherKey = "SUBMENU_ID")]
        public EntitySet<GBL_GRANTOBJECT> GBL_GRANTOBJECTs
        {
            get
            {
                return this._GBL_GRANTOBJECTs;
            }
            set
            {
                this._GBL_GRANTOBJECTs.Assign(value);
            }
        }

        [Association(Name = "GBL_SUBMENU_GBL_MYMENU", Storage = "_GBL_MYMENUs", ThisKey = "SUBMENU_ID", OtherKey = "SUBMENU_ID")]
        public EntitySet<GBL_MYMENU> GBL_MYMENUs
        {
            get
            {
                return this._GBL_MYMENUs;
            }
            set
            {
                this._GBL_MYMENUs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_SUBMENU", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_SUBMENUs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SUBMENUs.Add(this);
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

        [Association(Name = "GBL_MENU_GBL_SUBMENU", Storage = "_GBL_MENU", ThisKey = "MENU_ID", OtherKey = "MENU_ID", IsForeignKey = true)]
        public GBL_MENU GBL_MENU
        {
            get
            {
                return this._GBL_MENU.Entity;
            }
            set
            {
                GBL_MENU previousValue = this._GBL_MENU.Entity;
                if (((previousValue != value)
                            || (this._GBL_MENU.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_MENU.Entity = null;
                        previousValue.GBL_SUBMENUs.Remove(this);
                    }
                    this._GBL_MENU.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SUBMENUs.Add(this);
                        this._MENU_ID = value.MENU_ID;
                    }
                    else
                    {
                        this._MENU_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_MENU");
                }
            }
        }



        public string MenuUID { get; set; }
        public string SubMenuAddToHome { get; set; }
        public int    SubMenuParent { get; set; }
        public int    SubMenuSlNo { get; set; }
        public string SubMenuType { get; set; }
        public string SubMenuClassName { get; set; }
        public string SubMenuNameSys { get; set; }
        public string SubMenuDesc { get; set; }
        public string SubMenuIsActive { get; set; }
        public string SubMenuCanView { get; set; }
        public string SubMenuCanModify { get; set; }
        public string SubMenuCanCreate { get; set; }
        public string SubMenuCanRemove { get; set; }


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

        private void attach_GBL_GRANTOBJECTs(GBL_GRANTOBJECT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_SUBMENU = this;
        }

        private void detach_GBL_GRANTOBJECTs(GBL_GRANTOBJECT entity)
        {
            this.SendPropertyChanging();
            entity.GBL_SUBMENU = null;
        }

        private void attach_GBL_MYMENUs(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_SUBMENU = this;
        }

        private void detach_GBL_MYMENUs(GBL_MYMENU entity)
        {
            this.SendPropertyChanging();
            entity.GBL_SUBMENU = null;
        }
    }

    public class submenuObjectCollection : CollectionBase
    {
        public void Add(GBL_SUBMENU _menuObject)
        {
            this.List.Add(_menuObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBL_SUBMENU this[int index]
        {
            get
            {
                return (GBL_SUBMENU)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
