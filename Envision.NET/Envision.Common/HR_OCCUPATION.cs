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
    [Table(Name = "dbo.HR_OCCUPATION")]
    public partial class HR_OCCUPATION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _OCCUPATION_ID;

        private string _OCCUPATION_UID;

        private string _OCCUPATION_DESC;

        private System.Nullable<int> _ORG_ID;

        private string _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private string _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<HIS_REGISTRATION> _HIS_REGISTRATIONs;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnOCCUPATION_IDChanging(int value);
        partial void OnOCCUPATION_IDChanged();
        partial void OnOCCUPATION_UIDChanging(string value);
        partial void OnOCCUPATION_UIDChanged();
        partial void OnOCCUPATION_DESCChanging(string value);
        partial void OnOCCUPATION_DESCChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnCREATED_BYChanging(string value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(string value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public HR_OCCUPATION()
        {
            this._HIS_REGISTRATIONs = new EntitySet<HIS_REGISTRATION>(new Action<HIS_REGISTRATION>(this.attach_HIS_REGISTRATIONs), new Action<HIS_REGISTRATION>(this.detach_HIS_REGISTRATIONs));
            OnCreated();
        }

        [Column(Storage = "_OCCUPATION_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int OCCUPATION_ID
        {
            get
            {
                return this._OCCUPATION_ID;
            }
            set
            {
                if ((this._OCCUPATION_ID != value))
                {
                    this.OnOCCUPATION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._OCCUPATION_ID = value;
                    this.SendPropertyChanged("OCCUPATION_ID");
                    this.OnOCCUPATION_IDChanged();
                }
            }
        }

        [Column(Storage = "_OCCUPATION_UID", DbType = "NVarChar(50)")]
        public string OCCUPATION_UID
        {
            get
            {
                return this._OCCUPATION_UID;
            }
            set
            {
                if ((this._OCCUPATION_UID != value))
                {
                    this.OnOCCUPATION_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._OCCUPATION_UID = value;
                    this.SendPropertyChanged("OCCUPATION_UID");
                    this.OnOCCUPATION_UIDChanged();
                }
            }
        }

        [Column(Storage = "_OCCUPATION_DESC", DbType = "NVarChar(200)")]
        public string OCCUPATION_DESC
        {
            get
            {
                return this._OCCUPATION_DESC;
            }
            set
            {
                if ((this._OCCUPATION_DESC != value))
                {
                    this.OnOCCUPATION_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._OCCUPATION_DESC = value;
                    this.SendPropertyChanged("OCCUPATION_DESC");
                    this.OnOCCUPATION_DESCChanged();
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

        [Column(Storage = "_CREATED_BY", DbType = "NVarChar(30)")]
        public string CREATED_BY
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

        [Column(Storage = "_LAST_MODIFIED_BY", DbType = "NVarChar(30)")]
        public string LAST_MODIFIED_BY
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

        [Association(Name = "HR_OCCUPATION_HIS_REGISTRATION", Storage = "_HIS_REGISTRATIONs", ThisKey = "OCCUPATION_ID", OtherKey = "OCCUPATION_ID")]
        public EntitySet<HIS_REGISTRATION> HIS_REGISTRATIONs
        {
            get
            {
                return this._HIS_REGISTRATIONs;
            }
            set
            {
                this._HIS_REGISTRATIONs.Assign(value);
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

        private void attach_HIS_REGISTRATIONs(HIS_REGISTRATION entity)
        {
            this.SendPropertyChanging();
            entity.HR_OCCUPATION = this;
        }

        private void detach_HIS_REGISTRATIONs(HIS_REGISTRATION entity)
        {
            this.SendPropertyChanging();
            entity.HR_OCCUPATION = null;
        }
    }
}
