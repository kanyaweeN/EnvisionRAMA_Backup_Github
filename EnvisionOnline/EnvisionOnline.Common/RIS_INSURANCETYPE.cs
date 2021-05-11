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
    [Table(Name = "dbo.RIS_INSURANCETYPE")]
    public partial class RIS_INSURANCETYPE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _INSURANCE_TYPE_ID;

        private string _INSURANCE_TYPE_UID;

        private string _INSURANCE_TYPE_DESC;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<RIS_ORDER> _RIS_ORDERs;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnINSURANCE_TYPE_IDChanging(int value);
        partial void OnINSURANCE_TYPE_IDChanged();
        partial void OnINSURANCE_TYPE_UIDChanging(string value);
        partial void OnINSURANCE_TYPE_UIDChanged();
        partial void OnINSURANCE_TYPE_DESCChanging(string value);
        partial void OnINSURANCE_TYPE_DESCChanged();
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

        public RIS_INSURANCETYPE()
        {
            this._RIS_ORDERs = new EntitySet<RIS_ORDER>(new Action<RIS_ORDER>(this.attach_RIS_ORDERs), new Action<RIS_ORDER>(this.detach_RIS_ORDERs));
            OnCreated();
        }

        [Column(Storage = "_INSURANCE_TYPE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int INSURANCE_TYPE_ID
        {
            get
            {
                return this._INSURANCE_TYPE_ID;
            }
            set
            {
                if ((this._INSURANCE_TYPE_ID != value))
                {
                    this.OnINSURANCE_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._INSURANCE_TYPE_ID = value;
                    this.SendPropertyChanged("INSURANCE_TYPE_ID");
                    this.OnINSURANCE_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_INSURANCE_TYPE_UID", DbType = "NVarChar(30)")]
        public string INSURANCE_TYPE_UID
        {
            get
            {
                return this._INSURANCE_TYPE_UID;
            }
            set
            {
                if ((this._INSURANCE_TYPE_UID != value))
                {
                    this.OnINSURANCE_TYPE_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._INSURANCE_TYPE_UID = value;
                    this.SendPropertyChanged("INSURANCE_TYPE_UID");
                    this.OnINSURANCE_TYPE_UIDChanged();
                }
            }
        }

        [Column(Storage = "_INSURANCE_TYPE_DESC", DbType = "NVarChar(200)")]
        public string INSURANCE_TYPE_DESC
        {
            get
            {
                return this._INSURANCE_TYPE_DESC;
            }
            set
            {
                if ((this._INSURANCE_TYPE_DESC != value))
                {
                    this.OnINSURANCE_TYPE_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._INSURANCE_TYPE_DESC = value;
                    this.SendPropertyChanged("INSURANCE_TYPE_DESC");
                    this.OnINSURANCE_TYPE_DESCChanged();
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

        [Association(Name = "RIS_INSURANCETYPE_RIS_ORDER", Storage = "_RIS_ORDERs", ThisKey = "INSURANCE_TYPE_ID", OtherKey = "INSURANCE_TYPE_ID")]
        public EntitySet<RIS_ORDER> RIS_ORDERs
        {
            get
            {
                return this._RIS_ORDERs;
            }
            set
            {
                this._RIS_ORDERs.Assign(value);
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

        private void attach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.RIS_INSURANCETYPE = this;
        }

        private void detach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.RIS_INSURANCETYPE = null;
        }
    }
}
