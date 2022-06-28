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
    [Table(Name = "dbo.RIS_AUTHLEVEL")]
    public partial class RIS_AUTHLEVEL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _AUTH_LEVEL_ID;

        private string _AUTH_LEVEL_UID;

        private string _AUTH_LEVEL_DESC;

        private System.Nullable<byte> _AUTH_LEVEL_SL;

        private string _AUTH_LEVEL_TEXT;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<HR_EMP> _HR_EMPs;

        private EntitySet<HR_EMP> _HR_EMPs1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnAUTH_LEVEL_IDChanging(int value);
        partial void OnAUTH_LEVEL_IDChanged();
        partial void OnAUTH_LEVEL_UIDChanging(string value);
        partial void OnAUTH_LEVEL_UIDChanged();
        partial void OnAUTH_LEVEL_DESCChanging(string value);
        partial void OnAUTH_LEVEL_DESCChanged();
        partial void OnAUTH_LEVEL_SLChanging(System.Nullable<byte> value);
        partial void OnAUTH_LEVEL_SLChanged();
        partial void OnAUTH_LEVEL_TEXTChanging(string value);
        partial void OnAUTH_LEVEL_TEXTChanged();
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

        public RIS_AUTHLEVEL()
        {
            this._HR_EMPs = new EntitySet<HR_EMP>(new Action<HR_EMP>(this.attach_HR_EMPs), new Action<HR_EMP>(this.detach_HR_EMPs));
            this._HR_EMPs1 = new EntitySet<HR_EMP>(new Action<HR_EMP>(this.attach_HR_EMPs1), new Action<HR_EMP>(this.detach_HR_EMPs1));
            OnCreated();
        }

        [Column(Storage = "_AUTH_LEVEL_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int AUTH_LEVEL_ID
        {
            get
            {
                return this._AUTH_LEVEL_ID;
            }
            set
            {
                if ((this._AUTH_LEVEL_ID != value))
                {
                    this.OnAUTH_LEVEL_IDChanging(value);
                    this.SendPropertyChanging();
                    this._AUTH_LEVEL_ID = value;
                    this.SendPropertyChanged("AUTH_LEVEL_ID");
                    this.OnAUTH_LEVEL_IDChanged();
                }
            }
        }

        [Column(Storage = "_AUTH_LEVEL_UID", DbType = "NVarChar(30)")]
        public string AUTH_LEVEL_UID
        {
            get
            {
                return this._AUTH_LEVEL_UID;
            }
            set
            {
                if ((this._AUTH_LEVEL_UID != value))
                {
                    this.OnAUTH_LEVEL_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._AUTH_LEVEL_UID = value;
                    this.SendPropertyChanged("AUTH_LEVEL_UID");
                    this.OnAUTH_LEVEL_UIDChanged();
                }
            }
        }

        [Column(Storage = "_AUTH_LEVEL_DESC", DbType = "NVarChar(300)")]
        public string AUTH_LEVEL_DESC
        {
            get
            {
                return this._AUTH_LEVEL_DESC;
            }
            set
            {
                if ((this._AUTH_LEVEL_DESC != value))
                {
                    this.OnAUTH_LEVEL_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._AUTH_LEVEL_DESC = value;
                    this.SendPropertyChanged("AUTH_LEVEL_DESC");
                    this.OnAUTH_LEVEL_DESCChanged();
                }
            }
        }

        [Column(Storage = "_AUTH_LEVEL_SL", DbType = "TinyInt")]
        public System.Nullable<byte> AUTH_LEVEL_SL
        {
            get
            {
                return this._AUTH_LEVEL_SL;
            }
            set
            {
                if ((this._AUTH_LEVEL_SL != value))
                {
                    this.OnAUTH_LEVEL_SLChanging(value);
                    this.SendPropertyChanging();
                    this._AUTH_LEVEL_SL = value;
                    this.SendPropertyChanged("AUTH_LEVEL_SL");
                    this.OnAUTH_LEVEL_SLChanged();
                }
            }
        }

        [Column(Storage = "_AUTH_LEVEL_TEXT", DbType = "NVarChar(500)")]
        public string AUTH_LEVEL_TEXT
        {
            get
            {
                return this._AUTH_LEVEL_TEXT;
            }
            set
            {
                if ((this._AUTH_LEVEL_TEXT != value))
                {
                    this.OnAUTH_LEVEL_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._AUTH_LEVEL_TEXT = value;
                    this.SendPropertyChanged("AUTH_LEVEL_TEXT");
                    this.OnAUTH_LEVEL_TEXTChanged();
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

        [Association(Name = "RIS_AUTHLEVEL_HR_EMP", Storage = "_HR_EMPs", ThisKey = "AUTH_LEVEL_ID", OtherKey = "AUTH_LEVEL_ID")]
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

        [Association(Name = "RIS_AUTHLEVEL_HR_EMP1", Storage = "_HR_EMPs1", ThisKey = "AUTH_LEVEL_ID", OtherKey = "AUTH_LEVEL_ID")]
        public EntitySet<HR_EMP> HR_EMPs1
        {
            get
            {
                return this._HR_EMPs1;
            }
            set
            {
                this._HR_EMPs1.Assign(value);
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
            entity.RIS_AUTHLEVEL = this;
        }

        private void detach_HR_EMPs(HR_EMP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_AUTHLEVEL = null;
        }

        private void attach_HR_EMPs1(HR_EMP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_AUTHLEVEL1 = this;
        }

        private void detach_HR_EMPs1(HR_EMP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_AUTHLEVEL1 = null;
        }
    }
}
