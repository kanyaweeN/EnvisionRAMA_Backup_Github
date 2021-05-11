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
    [Table(Name = "dbo.RIS_NURSESDATADTL")]
    public partial class RIS_NURSESDATADTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _NURSE_DATA_UK_ID;

        private int _DETAIL_DATA_ID;

        private System.Nullable<System.DateTime> _DETAIL_TIME;

        private string _HR_MIN;

        private string _RR_MIN;

        private string _BP_MMHG;

        private string _O2_SAT;

        private string _CONCSIOUS;

        private string _PROGRESS_NOTE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<RIS_NURSESDATA> _RIS_NURSESDATA;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnNURSE_DATA_UK_IDChanging(int value);
        partial void OnNURSE_DATA_UK_IDChanged();
        partial void OnDETAIL_DATA_IDChanging(int value);
        partial void OnDETAIL_DATA_IDChanged();
        partial void OnDETAIL_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnDETAIL_TIMEChanged();
        partial void OnHR_MINChanging(string value);
        partial void OnHR_MINChanged();
        partial void OnRR_MINChanging(string value);
        partial void OnRR_MINChanged();
        partial void OnBP_MMHGChanging(string value);
        partial void OnBP_MMHGChanged();
        partial void OnO2_SATChanging(string value);
        partial void OnO2_SATChanged();
        partial void OnCONCSIOUSChanging(string value);
        partial void OnCONCSIOUSChanged();
        partial void OnPROGRESS_NOTEChanging(string value);
        partial void OnPROGRESS_NOTEChanged();
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

        public RIS_NURSESDATADTL()
        {
            this._RIS_NURSESDATA = default(EntityRef<RIS_NURSESDATA>);
            OnCreated();
        }

        [Column(Storage = "_NURSE_DATA_UK_ID", DbType = "Int NOT NULL")]
        public int NURSE_DATA_UK_ID
        {
            get
            {
                return this._NURSE_DATA_UK_ID;
            }
            set
            {
                if ((this._NURSE_DATA_UK_ID != value))
                {
                    if (this._RIS_NURSESDATA.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnNURSE_DATA_UK_IDChanging(value);
                    this.SendPropertyChanging();
                    this._NURSE_DATA_UK_ID = value;
                    this.SendPropertyChanged("NURSE_DATA_UK_ID");
                    this.OnNURSE_DATA_UK_IDChanged();
                }
            }
        }

        [Column(Storage = "_DETAIL_DATA_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int DETAIL_DATA_ID
        {
            get
            {
                return this._DETAIL_DATA_ID;
            }
            set
            {
                if ((this._DETAIL_DATA_ID != value))
                {
                    this.OnDETAIL_DATA_IDChanging(value);
                    this.SendPropertyChanging();
                    this._DETAIL_DATA_ID = value;
                    this.SendPropertyChanged("DETAIL_DATA_ID");
                    this.OnDETAIL_DATA_IDChanged();
                }
            }
        }

        [Column(Storage = "_DETAIL_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> DETAIL_TIME
        {
            get
            {
                return this._DETAIL_TIME;
            }
            set
            {
                if ((this._DETAIL_TIME != value))
                {
                    this.OnDETAIL_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._DETAIL_TIME = value;
                    this.SendPropertyChanged("DETAIL_TIME");
                    this.OnDETAIL_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_HR_MIN", DbType = "NVarChar(30)")]
        public string HR_MIN
        {
            get
            {
                return this._HR_MIN;
            }
            set
            {
                if ((this._HR_MIN != value))
                {
                    this.OnHR_MINChanging(value);
                    this.SendPropertyChanging();
                    this._HR_MIN = value;
                    this.SendPropertyChanged("HR_MIN");
                    this.OnHR_MINChanged();
                }
            }
        }

        [Column(Storage = "_RR_MIN", DbType = "NVarChar(30)")]
        public string RR_MIN
        {
            get
            {
                return this._RR_MIN;
            }
            set
            {
                if ((this._RR_MIN != value))
                {
                    this.OnRR_MINChanging(value);
                    this.SendPropertyChanging();
                    this._RR_MIN = value;
                    this.SendPropertyChanged("RR_MIN");
                    this.OnRR_MINChanged();
                }
            }
        }

        [Column(Storage = "_BP_MMHG", DbType = "NVarChar(30)")]
        public string BP_MMHG
        {
            get
            {
                return this._BP_MMHG;
            }
            set
            {
                if ((this._BP_MMHG != value))
                {
                    this.OnBP_MMHGChanging(value);
                    this.SendPropertyChanging();
                    this._BP_MMHG = value;
                    this.SendPropertyChanged("BP_MMHG");
                    this.OnBP_MMHGChanged();
                }
            }
        }

        [Column(Storage = "_O2_SAT", DbType = "NVarChar(30)")]
        public string O2_SAT
        {
            get
            {
                return this._O2_SAT;
            }
            set
            {
                if ((this._O2_SAT != value))
                {
                    this.OnO2_SATChanging(value);
                    this.SendPropertyChanging();
                    this._O2_SAT = value;
                    this.SendPropertyChanged("O2_SAT");
                    this.OnO2_SATChanged();
                }
            }
        }

        [Column(Storage = "_CONCSIOUS", DbType = "NVarChar(30)")]
        public string CONCSIOUS
        {
            get
            {
                return this._CONCSIOUS;
            }
            set
            {
                if ((this._CONCSIOUS != value))
                {
                    this.OnCONCSIOUSChanging(value);
                    this.SendPropertyChanging();
                    this._CONCSIOUS = value;
                    this.SendPropertyChanged("CONCSIOUS");
                    this.OnCONCSIOUSChanged();
                }
            }
        }

        [Column(Storage = "_PROGRESS_NOTE", DbType = "NVarChar(100)")]
        public string PROGRESS_NOTE
        {
            get
            {
                return this._PROGRESS_NOTE;
            }
            set
            {
                if ((this._PROGRESS_NOTE != value))
                {
                    this.OnPROGRESS_NOTEChanging(value);
                    this.SendPropertyChanging();
                    this._PROGRESS_NOTE = value;
                    this.SendPropertyChanged("PROGRESS_NOTE");
                    this.OnPROGRESS_NOTEChanged();
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

        [Association(Name = "RIS_NURSESDATA_RIS_NURSESDATADTL", Storage = "_RIS_NURSESDATA", ThisKey = "NURSE_DATA_UK_ID", OtherKey = "NURSE_DATA_UK_ID", IsForeignKey = true)]
        public RIS_NURSESDATA RIS_NURSESDATA
        {
            get
            {
                return this._RIS_NURSESDATA.Entity;
            }
            set
            {
                RIS_NURSESDATA previousValue = this._RIS_NURSESDATA.Entity;
                if (((previousValue != value)
                            || (this._RIS_NURSESDATA.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_NURSESDATA.Entity = null;
                        previousValue.RIS_NURSESDATADTLs.Remove(this);
                    }
                    this._RIS_NURSESDATA.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_NURSESDATADTLs.Add(this);
                        this._NURSE_DATA_UK_ID = value.NURSE_DATA_UK_ID;
                    }
                    else
                    {
                        this._NURSE_DATA_UK_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_NURSESDATA");
                }
            }
        }
        public int SELECTCASE { get; set; }

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
