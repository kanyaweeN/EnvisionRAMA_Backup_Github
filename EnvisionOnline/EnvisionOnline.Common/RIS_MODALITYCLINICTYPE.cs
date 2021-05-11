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
    [Table(Name = "dbo.RIS_MODALITYCLINICTYPE")]
    public partial class RIS_MODALITYCLINICTYPE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _MODALITY_CLINICTYPE_ID;

        private System.Nullable<int> _CLINIC_TYPE_ID;

        private System.Nullable<int> _MODALITY_ID;

        private System.Nullable<System.DateTime> _START_DATETIME;

        private System.Nullable<System.DateTime> _END_DATETIME;

        private System.Nullable<int> _MAX_APP;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnMODALITY_CLINICTYPE_IDChanging(int value);
        partial void OnMODALITY_CLINICTYPE_IDChanged();
        partial void OnCLINIC_TYPE_IDChanging(System.Nullable<int> value);
        partial void OnCLINIC_TYPE_IDChanged();
        partial void OnMODALITY_IDChanging(System.Nullable<int> value);
        partial void OnMODALITY_IDChanged();
        partial void OnSTART_DATETIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnSTART_DATETIMEChanged();
        partial void OnEND_DATETIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnEND_DATETIMEChanged();
        partial void OnMAX_APPChanging(System.Nullable<int> value);
        partial void OnMAX_APPChanged();
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

        public RIS_MODALITYCLINICTYPE()
        {
            OnCreated();
        }

        [Column(Storage = "_MODALITY_CLINICTYPE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int MODALITY_CLINICTYPE_ID
        {
            get
            {
                return this._MODALITY_CLINICTYPE_ID;
            }
            set
            {
                if ((this._MODALITY_CLINICTYPE_ID != value))
                {
                    this.OnMODALITY_CLINICTYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_CLINICTYPE_ID = value;
                    this.SendPropertyChanged("MODALITY_CLINICTYPE_ID");
                    this.OnMODALITY_CLINICTYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_CLINIC_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> CLINIC_TYPE_ID
        {
            get
            {
                return this._CLINIC_TYPE_ID;
            }
            set
            {
                if ((this._CLINIC_TYPE_ID != value))
                {
                    this.OnCLINIC_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CLINIC_TYPE_ID = value;
                    this.SendPropertyChanged("CLINIC_TYPE_ID");
                    this.OnCLINIC_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_MODALITY_ID", DbType = "Int")]
        public System.Nullable<int> MODALITY_ID
        {
            get
            {
                return this._MODALITY_ID;
            }
            set
            {
                if ((this._MODALITY_ID != value))
                {
                    this.OnMODALITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_ID = value;
                    this.SendPropertyChanged("MODALITY_ID");
                    this.OnMODALITY_IDChanged();
                }
            }
        }

        [Column(Storage = "_START_DATETIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> START_DATETIME
        {
            get
            {
                return this._START_DATETIME;
            }
            set
            {
                if ((this._START_DATETIME != value))
                {
                    this.OnSTART_DATETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._START_DATETIME = value;
                    this.SendPropertyChanged("START_DATETIME");
                    this.OnSTART_DATETIMEChanged();
                }
            }
        }

        [Column(Storage = "_END_DATETIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> END_DATETIME
        {
            get
            {
                return this._END_DATETIME;
            }
            set
            {
                if ((this._END_DATETIME != value))
                {
                    this.OnEND_DATETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._END_DATETIME = value;
                    this.SendPropertyChanged("END_DATETIME");
                    this.OnEND_DATETIMEChanged();
                }
            }
        }

        [Column(Storage = "_MAX_APP", DbType = "Int")]
        public System.Nullable<int> MAX_APP
        {
            get
            {
                return this._MAX_APP;
            }
            set
            {
                if ((this._MAX_APP != value))
                {
                    this.OnMAX_APPChanging(value);
                    this.SendPropertyChanging();
                    this._MAX_APP = value;
                    this.SendPropertyChanged("MAX_APP");
                    this.OnMAX_APPChanged();
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
        public int MODE { get; set; }
        public int CLINIC_TYPE_ID_OLD { get; set; }
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
