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
    [Table(Name = "dbo.RIS_PATSTATUS")]
    public partial class RIS_PATSTATUS : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _STATUS_ID;

        private string _STATUS_UID;

        private string _STATUS_TEXT;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<char> _IS_DEFAULT;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<GBL_ENV> _GBL_ENV1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSTATUS_IDChanging(int value);
        partial void OnSTATUS_IDChanged();
        partial void OnSTATUS_UIDChanging(string value);
        partial void OnSTATUS_UIDChanged();
        partial void OnSTATUS_TEXTChanging(string value);
        partial void OnSTATUS_TEXTChanged();
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
        partial void OnIS_DEFAULTChanging(System.Nullable<char> value);
        partial void OnIS_DEFAULTChanged();
        #endregion

        public RIS_PATSTATUS()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._GBL_ENV1 = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_STATUS_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int STATUS_ID
        {
            get
            {
                return this._STATUS_ID;
            }
            set
            {
                if ((this._STATUS_ID != value))
                {
                    this.OnSTATUS_IDChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS_ID = value;
                    this.SendPropertyChanged("STATUS_ID");
                    this.OnSTATUS_IDChanged();
                }
            }
        }

        [Column(Storage = "_STATUS_UID", DbType = "NVarChar(30)")]
        public string STATUS_UID
        {
            get
            {
                return this._STATUS_UID;
            }
            set
            {
                if ((this._STATUS_UID != value))
                {
                    this.OnSTATUS_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS_UID = value;
                    this.SendPropertyChanged("STATUS_UID");
                    this.OnSTATUS_UIDChanged();
                }
            }
        }

        [Column(Storage = "_STATUS_TEXT", DbType = "NVarChar(100)")]
        public string STATUS_TEXT
        {
            get
            {
                return this._STATUS_TEXT;
            }
            set
            {
                if ((this._STATUS_TEXT != value))
                {
                    this.OnSTATUS_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS_TEXT = value;
                    this.SendPropertyChanged("STATUS_TEXT");
                    this.OnSTATUS_TEXTChanged();
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

        [Association(Name = "GBL_ENV_RIS_PATSTATUS", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_PATSTATUS.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_PATSTATUS.Add(this);
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

        [Association(Name = "GBL_ENV_RIS_PATSTATUS1", Storage = "_GBL_ENV1", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_PATSTATUS1.Remove(this);
                    }
                    this._GBL_ENV1.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_PATSTATUS1.Add(this);
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
        public int SELECTCASE { get; set; }

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
