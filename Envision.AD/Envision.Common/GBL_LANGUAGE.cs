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
    [Table(Name = "dbo.GBL_LANGUAGE")]
    public partial class GBL_LANGUAGE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _LANG_ID;

        private string _LANG_UID;

        private string _LANG_NAME;

        private System.Nullable<char> _IS_DEFAULT;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<GBL_ALERTDTL> _GBL_ALERTDTLs;

        private EntitySet<GBL_GENERALDTL> _GBL_GENERALDTLs;

        private EntitySet<GBL_SUBMENUOBJECTLABEL> _GBL_SUBMENUOBJECTLABELs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnLANG_IDChanging(int value);
        partial void OnLANG_IDChanged();
        partial void OnLANG_UIDChanging(string value);
        partial void OnLANG_UIDChanged();
        partial void OnLANG_NAMEChanging(string value);
        partial void OnLANG_NAMEChanged();
        partial void OnIS_DEFAULTChanging(System.Nullable<char> value);
        partial void OnIS_DEFAULTChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
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

        public GBL_LANGUAGE()
        {
            this._GBL_ALERTDTLs = new EntitySet<GBL_ALERTDTL>(new Action<GBL_ALERTDTL>(this.attach_GBL_ALERTDTLs), new Action<GBL_ALERTDTL>(this.detach_GBL_ALERTDTLs));
            this._GBL_GENERALDTLs = new EntitySet<GBL_GENERALDTL>(new Action<GBL_GENERALDTL>(this.attach_GBL_GENERALDTLs), new Action<GBL_GENERALDTL>(this.detach_GBL_GENERALDTLs));
            this._GBL_SUBMENUOBJECTLABELs = new EntitySet<GBL_SUBMENUOBJECTLABEL>(new Action<GBL_SUBMENUOBJECTLABEL>(this.attach_GBL_SUBMENUOBJECTLABELs), new Action<GBL_SUBMENUOBJECTLABEL>(this.detach_GBL_SUBMENUOBJECTLABELs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_LANG_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
                    this.OnLANG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._LANG_ID = value;
                    this.SendPropertyChanged("LANG_ID");
                    this.OnLANG_IDChanged();
                }
            }
        }

        [Column(Storage = "_LANG_UID", DbType = "NVarChar(30)")]
        public string LANG_UID
        {
            get
            {
                return this._LANG_UID;
            }
            set
            {
                if ((this._LANG_UID != value))
                {
                    this.OnLANG_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._LANG_UID = value;
                    this.SendPropertyChanged("LANG_UID");
                    this.OnLANG_UIDChanged();
                }
            }
        }

        [Column(Storage = "_LANG_NAME", DbType = "NVarChar(100)")]
        public string LANG_NAME
        {
            get
            {
                return this._LANG_NAME;
            }
            set
            {
                if ((this._LANG_NAME != value))
                {
                    this.OnLANG_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._LANG_NAME = value;
                    this.SendPropertyChanged("LANG_NAME");
                    this.OnLANG_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_IS_DEFAULT", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_DEFAULT
        {
            get
            {
                return this._IS_DEFAULT;
            }
            set
            {
                if ((this._IS_DEFAULT != value))
                {
                    this.OnIS_DEFAULTChanging(value);
                    this.SendPropertyChanging();
                    this._IS_DEFAULT = value;
                    this.SendPropertyChanged("IS_DEFAULT");
                    this.OnIS_DEFAULTChanged();
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

        [Association(Name = "GBL_LANGUAGE_GBL_ALERTDTL", Storage = "_GBL_ALERTDTLs", ThisKey = "LANG_ID", OtherKey = "LANG_ID")]
        public EntitySet<GBL_ALERTDTL> GBL_ALERTDTLs
        {
            get
            {
                return this._GBL_ALERTDTLs;
            }
            set
            {
                this._GBL_ALERTDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_LANGUAGE_GBL_GENERALDTL", Storage = "_GBL_GENERALDTLs", ThisKey = "LANG_ID", OtherKey = "LANG_ID")]
        public EntitySet<GBL_GENERALDTL> GBL_GENERALDTLs
        {
            get
            {
                return this._GBL_GENERALDTLs;
            }
            set
            {
                this._GBL_GENERALDTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_LANGUAGE_GBL_SUBMENUOBJECTLABEL", Storage = "_GBL_SUBMENUOBJECTLABELs", ThisKey = "LANG_ID", OtherKey = "LANG_ID")]
        public EntitySet<GBL_SUBMENUOBJECTLABEL> GBL_SUBMENUOBJECTLABELs
        {
            get
            {
                return this._GBL_SUBMENUOBJECTLABELs;
            }
            set
            {
                this._GBL_SUBMENUOBJECTLABELs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_GBL_LANGUAGE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_LANGUAGEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_LANGUAGEs.Add(this);
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

        private void attach_GBL_ALERTDTLs(GBL_ALERTDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_LANGUAGE = this;
        }

        private void detach_GBL_ALERTDTLs(GBL_ALERTDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_LANGUAGE = null;
        }

        private void attach_GBL_GENERALDTLs(GBL_GENERALDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_LANGUAGE = this;
        }

        private void detach_GBL_GENERALDTLs(GBL_GENERALDTL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_LANGUAGE = null;
        }

        private void attach_GBL_SUBMENUOBJECTLABELs(GBL_SUBMENUOBJECTLABEL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_LANGUAGE = this;
        }

        private void detach_GBL_SUBMENUOBJECTLABELs(GBL_SUBMENUOBJECTLABEL entity)
        {
            this.SendPropertyChanging();
            entity.GBL_LANGUAGE = null;
        }
    }
}
