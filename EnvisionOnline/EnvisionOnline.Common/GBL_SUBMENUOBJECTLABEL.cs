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

namespace EnvisionOnline.Common
{
    [Table(Name = "dbo.GBL_SUBMENUOBJECTLABEL")]
    public partial class GBL_SUBMENUOBJECTLABEL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SUBMENU_ID;

        private int _OBJECT_ID;

        private int _LANG_ID;

        private string _LABEL;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<GBL_LANGUAGE> _GBL_LANGUAGE;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSUBMENU_IDChanging(int value);
        partial void OnSUBMENU_IDChanged();
        partial void OnOBJECT_IDChanging(int value);
        partial void OnOBJECT_IDChanged();
        partial void OnLANG_IDChanging(int value);
        partial void OnLANG_IDChanged();
        partial void OnLABELChanging(string value);
        partial void OnLABELChanged();
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

        public GBL_SUBMENUOBJECTLABEL()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._GBL_LANGUAGE = default(EntityRef<GBL_LANGUAGE>);
            OnCreated();
        }

        [Column(Storage = "_SUBMENU_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
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

        [Column(Storage = "_OBJECT_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int OBJECT_ID
        {
            get
            {
                return this._OBJECT_ID;
            }
            set
            {
                if ((this._OBJECT_ID != value))
                {
                    this.OnOBJECT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._OBJECT_ID = value;
                    this.SendPropertyChanged("OBJECT_ID");
                    this.OnOBJECT_IDChanged();
                }
            }
        }

        [Column(Storage = "_LANG_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int LANG_ID
        {
            get
            {
                return this._LANG_ID;
            }
            set
            {
                if ((this._LANG_ID != value))
                {
                    if (this._GBL_LANGUAGE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnLANG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._LANG_ID = value;
                    this.SendPropertyChanged("LANG_ID");
                    this.OnLANG_IDChanged();
                }
            }
        }

        [Column(Storage = "_LABEL", DbType = "NChar(300)")]
        public string LABEL
        {
            get
            {
                return this._LABEL;
            }
            set
            {
                if ((this._LABEL != value))
                {
                    this.OnLABELChanging(value);
                    this.SendPropertyChanging();
                    this._LABEL = value;
                    this.SendPropertyChanged("LABEL");
                    this.OnLABELChanged();
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

        [Association(Name = "GBL_ENV_GBL_SUBMENUOBJECTLABEL", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_SUBMENUOBJECTLABELs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SUBMENUOBJECTLABELs.Add(this);
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

        [Association(Name = "GBL_LANGUAGE_GBL_SUBMENUOBJECTLABEL", Storage = "_GBL_LANGUAGE", ThisKey = "LANG_ID", OtherKey = "LANG_ID", IsForeignKey = true)]
        public GBL_LANGUAGE GBL_LANGUAGE
        {
            get
            {
                return this._GBL_LANGUAGE.Entity;
            }
            set
            {
                GBL_LANGUAGE previousValue = this._GBL_LANGUAGE.Entity;
                if (((previousValue != value)
                            || (this._GBL_LANGUAGE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_LANGUAGE.Entity = null;
                        previousValue.GBL_SUBMENUOBJECTLABELs.Remove(this);
                    }
                    this._GBL_LANGUAGE.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SUBMENUOBJECTLABELs.Add(this);
                        this._LANG_ID = value.LANG_ID;
                    }
                    else
                    {
                        this._LANG_ID = default(int);
                    }
                    this.SendPropertyChanged("GBL_LANGUAGE");
                }
            }
        }

        public string SubMenuUID { get; set; }
        public string ObjectName { get; set; }
        
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

    public class submenuobjectlabelObjectCollection : CollectionBase
    {
        public void Add(GBL_SUBMENUOBJECTLABEL _menuObject)
        {
            this.List.Add(_menuObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBL_SUBMENUOBJECTLABEL this[int index]
        {
            get
            {
                return (GBL_SUBMENUOBJECTLABEL)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
