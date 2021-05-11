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
    [Table(Name = "dbo.RIS_EXAMRESULTLEGACY")]
    public partial class RIS_EXAMRESULTLEGACY : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _EXAMRESULTLEGACY_ID;

        private string _HN;

        private string _ACCESSION_NO;

        private string _ORDER_UID;

        private string _EXAM_UID;

        private string _RESULT_TEXT_HTML;

        private System.Nullable<char> _RESULT_STATUS;

        private System.Nullable<int> _RELEASED_BY;

        private System.Nullable<System.DateTime> _RELEASED_ON;

        private System.Nullable<int> _FINALIZED_BY;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private string _USER_NAME;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnEXAMRESULTLEGACY_IDChanging(int value);
        partial void OnEXAMRESULTLEGACY_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnORDER_UIDChanging(string value);
        partial void OnORDER_UIDChanged();
        partial void OnEXAM_UIDChanging(string value);
        partial void OnEXAM_UIDChanged();
        partial void OnRESULT_TEXT_HTMLChanging(string value);
        partial void OnRESULT_TEXT_HTMLChanged();
        partial void OnRESULT_STATUSChanging(System.Nullable<char> value);
        partial void OnRESULT_STATUSChanged();
        partial void OnRELEASED_BYChanging(System.Nullable<int> value);
        partial void OnRELEASED_BYChanged();
        partial void OnRELEASED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnRELEASED_ONChanged();
        partial void OnFINALIZED_BYChanging(System.Nullable<int> value);
        partial void OnFINALIZED_BYChanged();
        partial void OnFINALIZED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnFINALIZED_ONChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnUSER_NAMEChanging(string value);
        partial void OnUSER_NAMEChanged();
        #endregion

        public RIS_EXAMRESULTLEGACY()
        {
            OnCreated();
        }

        [Column(Storage = "_EXAMRESULTLEGACY_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int EXAMRESULTLEGACY_ID
        {
            get
            {
                return this._EXAMRESULTLEGACY_ID;
            }
            set
            {
                if ((this._EXAMRESULTLEGACY_ID != value))
                {
                    this.OnEXAMRESULTLEGACY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAMRESULTLEGACY_ID = value;
                    this.SendPropertyChanged("EXAMRESULTLEGACY_ID");
                    this.OnEXAMRESULTLEGACY_IDChanged();
                }
            }
        }

        [Column(Storage = "_HN", DbType = "NVarChar(30)")]
        public string HN
        {
            get
            {
                return this._HN;
            }
            set
            {
                if ((this._HN != value))
                {
                    this.OnHNChanging(value);
                    this.SendPropertyChanging();
                    this._HN = value;
                    this.SendPropertyChanged("HN");
                    this.OnHNChanged();
                }
            }
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
        public string ACCESSION_NO
        {
            get
            {
                return this._ACCESSION_NO;
            }
            set
            {
                if ((this._ACCESSION_NO != value))
                {
                    this.OnACCESSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_NO = value;
                    this.SendPropertyChanged("ACCESSION_NO");
                    this.OnACCESSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_ORDER_UID", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
        public string ORDER_UID
        {
            get
            {
                return this._ORDER_UID;
            }
            set
            {
                if ((this._ORDER_UID != value))
                {
                    this.OnORDER_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_UID = value;
                    this.SendPropertyChanged("ORDER_UID");
                    this.OnORDER_UIDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_UID", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
        public string EXAM_UID
        {
            get
            {
                return this._EXAM_UID;
            }
            set
            {
                if ((this._EXAM_UID != value))
                {
                    this.OnEXAM_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_UID = value;
                    this.SendPropertyChanged("EXAM_UID");
                    this.OnEXAM_UIDChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_HTML", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_HTML
        {
            get
            {
                return this._RESULT_TEXT_HTML;
            }
            set
            {
                if ((this._RESULT_TEXT_HTML != value))
                {
                    this.OnRESULT_TEXT_HTMLChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_TEXT_HTML = value;
                    this.SendPropertyChanged("RESULT_TEXT_HTML");
                    this.OnRESULT_TEXT_HTMLChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> RESULT_STATUS
        {
            get
            {
                return this._RESULT_STATUS;
            }
            set
            {
                if ((this._RESULT_STATUS != value))
                {
                    this.OnRESULT_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_STATUS = value;
                    this.SendPropertyChanged("RESULT_STATUS");
                    this.OnRESULT_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_RELEASED_BY", DbType = "Int")]
        public System.Nullable<int> RELEASED_BY
        {
            get
            {
                return this._RELEASED_BY;
            }
            set
            {
                if ((this._RELEASED_BY != value))
                {
                    this.OnRELEASED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASED_BY = value;
                    this.SendPropertyChanged("RELEASED_BY");
                    this.OnRELEASED_BYChanged();
                }
            }
        }

        [Column(Storage = "_RELEASED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> RELEASED_ON
        {
            get
            {
                return this._RELEASED_ON;
            }
            set
            {
                if ((this._RELEASED_ON != value))
                {
                    this.OnRELEASED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASED_ON = value;
                    this.SendPropertyChanged("RELEASED_ON");
                    this.OnRELEASED_ONChanged();
                }
            }
        }

        [Column(Storage = "_FINALIZED_BY", DbType = "Int")]
        public System.Nullable<int> FINALIZED_BY
        {
            get
            {
                return this._FINALIZED_BY;
            }
            set
            {
                if ((this._FINALIZED_BY != value))
                {
                    this.OnFINALIZED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._FINALIZED_BY = value;
                    this.SendPropertyChanged("FINALIZED_BY");
                    this.OnFINALIZED_BYChanged();
                }
            }
        }

        [Column(Storage = "_FINALIZED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> FINALIZED_ON
        {
            get
            {
                return this._FINALIZED_ON;
            }
            set
            {
                if ((this._FINALIZED_ON != value))
                {
                    this.OnFINALIZED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._FINALIZED_ON = value;
                    this.SendPropertyChanged("FINALIZED_ON");
                    this.OnFINALIZED_ONChanged();
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

        [Column(Storage = "_USER_NAME", DbType = "NVarChar(30)")]
        public string USER_NAME
        {
            get
            {
                return this._USER_NAME;
            }
            set
            {
                if ((this._USER_NAME != value))
                {
                    this.OnUSER_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._USER_NAME = value;
                    this.SendPropertyChanged("USER_NAME");
                    this.OnUSER_NAMEChanged();
                }
            }
        }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }
        public int MODE { get; set; }


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
