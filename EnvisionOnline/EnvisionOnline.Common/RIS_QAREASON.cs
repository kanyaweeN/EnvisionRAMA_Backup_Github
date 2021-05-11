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
    [Table(Name = "dbo.RIS_QAREASON")]
    public partial class RIS_QAREASON : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _REASON_ID;

        private string _REASON_UID;

        private string _REASON_TEXT;

        private string _REASON_ACTION;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnREASON_IDChanging(int value);
        partial void OnREASON_IDChanged();
        partial void OnREASON_UIDChanging(string value);
        partial void OnREASON_UIDChanged();
        partial void OnREASON_TEXTChanging(string value);
        partial void OnREASON_TEXTChanged();
        partial void OnREASON_ACTIONChanging(string value);
        partial void OnREASON_ACTIONChanged();
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

        public RIS_QAREASON()
        {
            OnCreated();
        }

        [Column(Storage = "_REASON_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int REASON_ID
        {
            get
            {
                return this._REASON_ID;
            }
            set
            {
                if ((this._REASON_ID != value))
                {
                    this.OnREASON_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REASON_ID = value;
                    this.SendPropertyChanged("REASON_ID");
                    this.OnREASON_IDChanged();
                }
            }
        }

        [Column(Storage = "_REASON_UID", DbType = "NVarChar(30)")]
        public string REASON_UID
        {
            get
            {
                return this._REASON_UID;
            }
            set
            {
                if ((this._REASON_UID != value))
                {
                    this.OnREASON_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._REASON_UID = value;
                    this.SendPropertyChanged("REASON_UID");
                    this.OnREASON_UIDChanged();
                }
            }
        }

        [Column(Storage = "_REASON_TEXT", DbType = "NVarChar(150)")]
        public string REASON_TEXT
        {
            get
            {
                return this._REASON_TEXT;
            }
            set
            {
                if ((this._REASON_TEXT != value))
                {
                    this.OnREASON_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._REASON_TEXT = value;
                    this.SendPropertyChanged("REASON_TEXT");
                    this.OnREASON_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_REASON_ACTION", DbType = "NVarChar(200)")]
        public string REASON_ACTION
        {
            get
            {
                return this._REASON_ACTION;
            }
            set
            {
                if ((this._REASON_ACTION != value))
                {
                    this.OnREASON_ACTIONChanging(value);
                    this.SendPropertyChanging();
                    this._REASON_ACTION = value;
                    this.SendPropertyChanged("REASON_ACTION");
                    this.OnREASON_ACTIONChanged();
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
