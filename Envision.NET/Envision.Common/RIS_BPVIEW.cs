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
    [Table(Name = "dbo.RIS_BPVIEW")]
    public partial class RIS_BPVIEW : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _BPVIEW_ID;

        private string _BPVIEW_UID;

        private string _BPVIEW_NAME;

        private string _BPVIEW_DESC;

        private System.Nullable<byte> _NO_OF_EXAM;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnBPVIEW_IDChanging(int value);
        partial void OnBPVIEW_IDChanged();
        partial void OnBPVIEW_UIDChanging(string value);
        partial void OnBPVIEW_UIDChanged();
        partial void OnBPVIEW_NAMEChanging(string value);
        partial void OnBPVIEW_NAMEChanged();
        partial void OnBPVIEW_DESCChanging(string value);
        partial void OnBPVIEW_DESCChanged();
        partial void OnNO_OF_EXAMChanging(System.Nullable<byte> value);
        partial void OnNO_OF_EXAMChanged();
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

        public RIS_BPVIEW()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_BPVIEW_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int BPVIEW_ID
        {
            get
            {
                return this._BPVIEW_ID;
            }
            set
            {
                if ((this._BPVIEW_ID != value))
                {
                    this.OnBPVIEW_IDChanging(value);
                    this.SendPropertyChanging();
                    this._BPVIEW_ID = value;
                    this.SendPropertyChanged("BPVIEW_ID");
                    this.OnBPVIEW_IDChanged();
                }
            }
        }

        [Column(Storage = "_BPVIEW_UID", DbType = "NVarChar(30)")]
        public string BPVIEW_UID
        {
            get
            {
                return this._BPVIEW_UID;
            }
            set
            {
                if ((this._BPVIEW_UID != value))
                {
                    this.OnBPVIEW_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._BPVIEW_UID = value;
                    this.SendPropertyChanged("BPVIEW_UID");
                    this.OnBPVIEW_UIDChanged();
                }
            }
        }

        [Column(Storage = "_BPVIEW_NAME", DbType = "NVarChar(6)")]
        public string BPVIEW_NAME
        {
            get
            {
                return this._BPVIEW_NAME;
            }
            set
            {
                if ((this._BPVIEW_NAME != value))
                {
                    this.OnBPVIEW_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._BPVIEW_NAME = value;
                    this.SendPropertyChanged("BPVIEW_NAME");
                    this.OnBPVIEW_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_BPVIEW_DESC", DbType = "NVarChar(50)")]
        public string BPVIEW_DESC
        {
            get
            {
                return this._BPVIEW_DESC;
            }
            set
            {
                if ((this._BPVIEW_DESC != value))
                {
                    this.OnBPVIEW_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._BPVIEW_DESC = value;
                    this.SendPropertyChanged("BPVIEW_DESC");
                    this.OnBPVIEW_DESCChanged();
                }
            }
        }

        [Column(Storage = "_NO_OF_EXAM", DbType = "TinyInt")]
        public System.Nullable<byte> NO_OF_EXAM
        {
            get
            {
                return this._NO_OF_EXAM;
            }
            set
            {
                if ((this._NO_OF_EXAM != value))
                {
                    this.OnNO_OF_EXAMChanging(value);
                    this.SendPropertyChanging();
                    this._NO_OF_EXAM = value;
                    this.SendPropertyChanged("NO_OF_EXAM");
                    this.OnNO_OF_EXAMChanged();
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

        [Association(Name = "GBL_ENV_RIS_BPVIEW", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_BPVIEWs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_BPVIEWs.Add(this);
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
    }
}
