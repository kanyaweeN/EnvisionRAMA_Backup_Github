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
    [Table(Name = "dbo.INV_TRANSACTIONTYPE")]
    public partial class INV_TRANSACTIONTYPE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _TRANSACTIONTYPE_ID;

        private string _TRANSACTIONTYPE_UID;

        private string _TRANSACTIONTYPE_NAME;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnTRANSACTIONTYPE_IDChanging(int value);
        partial void OnTRANSACTIONTYPE_IDChanged();
        partial void OnTRANSACTIONTYPE_UIDChanging(string value);
        partial void OnTRANSACTIONTYPE_UIDChanged();
        partial void OnTRANSACTIONTYPE_NAMEChanging(string value);
        partial void OnTRANSACTIONTYPE_NAMEChanged();
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

        public INV_TRANSACTIONTYPE()
        {
            OnCreated();
        }

        [Column(Storage = "_TRANSACTIONTYPE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int TRANSACTIONTYPE_ID
        {
            get
            {
                return this._TRANSACTIONTYPE_ID;
            }
            set
            {
                if ((this._TRANSACTIONTYPE_ID != value))
                {
                    this.OnTRANSACTIONTYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TRANSACTIONTYPE_ID = value;
                    this.SendPropertyChanged("TRANSACTIONTYPE_ID");
                    this.OnTRANSACTIONTYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_TRANSACTIONTYPE_UID", DbType = "NVarChar(30)")]
        public string TRANSACTIONTYPE_UID
        {
            get
            {
                return this._TRANSACTIONTYPE_UID;
            }
            set
            {
                if ((this._TRANSACTIONTYPE_UID != value))
                {
                    this.OnTRANSACTIONTYPE_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._TRANSACTIONTYPE_UID = value;
                    this.SendPropertyChanged("TRANSACTIONTYPE_UID");
                    this.OnTRANSACTIONTYPE_UIDChanged();
                }
            }
        }

        [Column(Storage = "_TRANSACTIONTYPE_NAME", DbType = "NVarChar(250)")]
        public string TRANSACTIONTYPE_NAME
        {
            get
            {
                return this._TRANSACTIONTYPE_NAME;
            }
            set
            {
                if ((this._TRANSACTIONTYPE_NAME != value))
                {
                    this.OnTRANSACTIONTYPE_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._TRANSACTIONTYPE_NAME = value;
                    this.SendPropertyChanged("TRANSACTIONTYPE_NAME");
                    this.OnTRANSACTIONTYPE_NAMEChanged();
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
