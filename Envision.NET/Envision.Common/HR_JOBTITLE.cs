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
    [Table(Name = "dbo.HR_JOBTITLE")]
    public partial class HR_JOBTITLE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _JOB_TITLE_ID;

        private string _JOB_TITLE_UID;

        private string _JOB_TITLE_DESC;

        private string _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<HR_EMP> _HR_EMPs;

        public string MODE { get; set; }

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnJOB_TITLE_IDChanging(int value);
        partial void OnJOB_TITLE_IDChanged();
        partial void OnJOB_TITLE_UIDChanging(string value);
        partial void OnJOB_TITLE_UIDChanged();
        partial void OnJOB_TITLE_DESCChanging(string value);
        partial void OnJOB_TITLE_DESCChanged();
        partial void OnIS_ACTIVEChanging(string value);
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

        public HR_JOBTITLE()
        {
            this._HR_EMPs = new EntitySet<HR_EMP>(new Action<HR_EMP>(this.attach_HR_EMPs), new Action<HR_EMP>(this.detach_HR_EMPs));
            OnCreated();
        }

        [Column(Storage = "_JOB_TITLE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int JOB_TITLE_ID
        {
            get
            {
                return this._JOB_TITLE_ID;
            }
            set
            {
                if ((this._JOB_TITLE_ID != value))
                {
                    this.OnJOB_TITLE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._JOB_TITLE_ID = value;
                    this.SendPropertyChanged("JOB_TITLE_ID");
                    this.OnJOB_TITLE_IDChanged();
                }
            }
        }

        [Column(Storage = "_JOB_TITLE_UID", DbType = "NVarChar(30)")]
        public string JOB_TITLE_UID
        {
            get
            {
                return this._JOB_TITLE_UID;
            }
            set
            {
                if ((this._JOB_TITLE_UID != value))
                {
                    this.OnJOB_TITLE_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._JOB_TITLE_UID = value;
                    this.SendPropertyChanged("JOB_TITLE_UID");
                    this.OnJOB_TITLE_UIDChanged();
                }
            }
        }

        [Column(Storage = "_JOB_TITLE_DESC", DbType = "NVarChar(300)")]
        public string JOB_TITLE_DESC
        {
            get
            {
                return this._JOB_TITLE_DESC;
            }
            set
            {
                if ((this._JOB_TITLE_DESC != value))
                {
                    this.OnJOB_TITLE_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._JOB_TITLE_DESC = value;
                    this.SendPropertyChanged("JOB_TITLE_DESC");
                    this.OnJOB_TITLE_DESCChanged();
                }
            }
        }

        [Column(Storage = "_IS_ACTIVE", DbType = "NChar(10)")]
        public string IS_ACTIVE
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

        [Association(Name = "HR_JOBTITLE_HR_EMP", Storage = "_HR_EMPs", ThisKey = "JOB_TITLE_ID", OtherKey = "JOBTITLE_ID")]
        public EntitySet<HR_EMP> HR_EMPs
        {
            get
            {
                return this._HR_EMPs;
            }
            set
            {
                this._HR_EMPs.Assign(value);
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

        private void attach_HR_EMPs(HR_EMP entity)
        {
            this.SendPropertyChanging();
            entity.HR_JOBTITLE = this;
        }

        private void detach_HR_EMPs(HR_EMP entity)
        {
            this.SendPropertyChanging();
            entity.HR_JOBTITLE = null;
        }
    }
}
