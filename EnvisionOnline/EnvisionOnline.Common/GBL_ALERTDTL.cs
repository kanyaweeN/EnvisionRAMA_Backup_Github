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
    [Table(Name = "dbo.GBL_ALERTDTL")]
    public partial class GBL_ALERTDTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ALT_DTL_ID;

        private int _ALT_ID;

        private int _LANG_ID;

        private string _ALT_TEXT;

        private System.Nullable<char> _ALT_TYPE;

        private string _ALT_TITLE;

        private System.Nullable<int> _ALT_BUTTON;

        private string _CAPTION_BTN1;

        private string _CAPTION_BTN2;

        private string _CAPTION_BTN3;

        private System.Nullable<byte> _DEFAULT_BTN;

        private System.Nullable<byte> _TIME_SEC;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

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
        partial void OnALT_DTL_IDChanging(int value);
        partial void OnALT_DTL_IDChanged();
        partial void OnALT_IDChanging(int value);
        partial void OnALT_IDChanged();
        partial void OnLANG_IDChanging(int value);
        partial void OnLANG_IDChanged();
        partial void OnALT_TEXTChanging(string value);
        partial void OnALT_TEXTChanged();
        partial void OnALT_TYPEChanging(System.Nullable<char> value);
        partial void OnALT_TYPEChanged();
        partial void OnALT_TITLEChanging(string value);
        partial void OnALT_TITLEChanged();
        partial void OnALT_BUTTONChanging(System.Nullable<int> value);
        partial void OnALT_BUTTONChanged();
        partial void OnCAPTION_BTN1Changing(string value);
        partial void OnCAPTION_BTN1Changed();
        partial void OnCAPTION_BTN2Changing(string value);
        partial void OnCAPTION_BTN2Changed();
        partial void OnCAPTION_BTN3Changing(string value);
        partial void OnCAPTION_BTN3Changed();
        partial void OnDEFAULT_BTNChanging(System.Nullable<byte> value);
        partial void OnDEFAULT_BTNChanged();
        partial void OnTIME_SECChanging(System.Nullable<byte> value);
        partial void OnTIME_SECChanged();
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

        public GBL_ALERTDTL()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._GBL_LANGUAGE = default(EntityRef<GBL_LANGUAGE>);
            OnCreated();
        }

        [Column(Storage = "_ALT_DTL_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ALT_DTL_ID
        {
            get
            {
                return this._ALT_DTL_ID;
            }
            set
            {
                if ((this._ALT_DTL_ID != value))
                {
                    this.OnALT_DTL_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ALT_DTL_ID = value;
                    this.SendPropertyChanged("ALT_DTL_ID");
                    this.OnALT_DTL_IDChanged();
                }
            }
        }

        [Column(Storage = "_ALT_ID", DbType = "Int NOT NULL")]
        public int ALT_ID
        {
            get
            {
                return this._ALT_ID;
            }
            set
            {
                if ((this._ALT_ID != value))
                {
                    this.OnALT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ALT_ID = value;
                    this.SendPropertyChanged("ALT_ID");
                    this.OnALT_IDChanged();
                }
            }
        }

        [Column(Storage = "_LANG_ID", DbType = "Int NOT NULL")]
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

        [Column(Storage = "_ALT_TEXT", DbType = "NVarChar(300)")]
        public string ALT_TEXT
        {
            get
            {
                return this._ALT_TEXT;
            }
            set
            {
                if ((this._ALT_TEXT != value))
                {
                    this.OnALT_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._ALT_TEXT = value;
                    this.SendPropertyChanged("ALT_TEXT");
                    this.OnALT_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_ALT_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> ALT_TYPE
        {
            get
            {
                return this._ALT_TYPE;
            }
            set
            {
                if ((this._ALT_TYPE != value))
                {
                    this.OnALT_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._ALT_TYPE = value;
                    this.SendPropertyChanged("ALT_TYPE");
                    this.OnALT_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_ALT_TITLE", DbType = "NVarChar(50)")]
        public string ALT_TITLE
        {
            get
            {
                return this._ALT_TITLE;
            }
            set
            {
                if ((this._ALT_TITLE != value))
                {
                    this.OnALT_TITLEChanging(value);
                    this.SendPropertyChanging();
                    this._ALT_TITLE = value;
                    this.SendPropertyChanged("ALT_TITLE");
                    this.OnALT_TITLEChanged();
                }
            }
        }

        [Column(Storage = "_ALT_BUTTON", DbType = "Int")]
        public System.Nullable<int> ALT_BUTTON
        {
            get
            {
                return this._ALT_BUTTON;
            }
            set
            {
                if ((this._ALT_BUTTON != value))
                {
                    this.OnALT_BUTTONChanging(value);
                    this.SendPropertyChanging();
                    this._ALT_BUTTON = value;
                    this.SendPropertyChanged("ALT_BUTTON");
                    this.OnALT_BUTTONChanged();
                }
            }
        }

        [Column(Storage = "_CAPTION_BTN1", DbType = "NVarChar(25)")]
        public string CAPTION_BTN1
        {
            get
            {
                return this._CAPTION_BTN1;
            }
            set
            {
                if ((this._CAPTION_BTN1 != value))
                {
                    this.OnCAPTION_BTN1Changing(value);
                    this.SendPropertyChanging();
                    this._CAPTION_BTN1 = value;
                    this.SendPropertyChanged("CAPTION_BTN1");
                    this.OnCAPTION_BTN1Changed();
                }
            }
        }

        [Column(Storage = "_CAPTION_BTN2", DbType = "NVarChar(25)")]
        public string CAPTION_BTN2
        {
            get
            {
                return this._CAPTION_BTN2;
            }
            set
            {
                if ((this._CAPTION_BTN2 != value))
                {
                    this.OnCAPTION_BTN2Changing(value);
                    this.SendPropertyChanging();
                    this._CAPTION_BTN2 = value;
                    this.SendPropertyChanged("CAPTION_BTN2");
                    this.OnCAPTION_BTN2Changed();
                }
            }
        }

        [Column(Storage = "_CAPTION_BTN3", DbType = "NVarChar(25)")]
        public string CAPTION_BTN3
        {
            get
            {
                return this._CAPTION_BTN3;
            }
            set
            {
                if ((this._CAPTION_BTN3 != value))
                {
                    this.OnCAPTION_BTN3Changing(value);
                    this.SendPropertyChanging();
                    this._CAPTION_BTN3 = value;
                    this.SendPropertyChanged("CAPTION_BTN3");
                    this.OnCAPTION_BTN3Changed();
                }
            }
        }

        [Column(Storage = "_DEFAULT_BTN", DbType = "TinyInt")]
        public System.Nullable<byte> DEFAULT_BTN
        {
            get
            {
                return this._DEFAULT_BTN;
            }
            set
            {
                if ((this._DEFAULT_BTN != value))
                {
                    this.OnDEFAULT_BTNChanging(value);
                    this.SendPropertyChanging();
                    this._DEFAULT_BTN = value;
                    this.SendPropertyChanged("DEFAULT_BTN");
                    this.OnDEFAULT_BTNChanged();
                }
            }
        }

        [Column(Storage = "_TIME_SEC", DbType = "TinyInt")]
        public System.Nullable<byte> TIME_SEC
        {
            get
            {
                return this._TIME_SEC;
            }
            set
            {
                if ((this._TIME_SEC != value))
                {
                    this.OnTIME_SECChanging(value);
                    this.SendPropertyChanging();
                    this._TIME_SEC = value;
                    this.SendPropertyChanged("TIME_SEC");
                    this.OnTIME_SECChanged();
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

        [Association(Name = "GBL_ENV_GBL_ALERTDTL", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_ALERTDTLs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_ALERTDTLs.Add(this);
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

        [Association(Name = "GBL_LANGUAGE_GBL_ALERTDTL", Storage = "_GBL_LANGUAGE", ThisKey = "LANG_ID", OtherKey = "LANG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_ALERTDTLs.Remove(this);
                    }
                    this._GBL_LANGUAGE.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_ALERTDTLs.Add(this);
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
