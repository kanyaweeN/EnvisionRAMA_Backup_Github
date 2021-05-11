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
    [Table(Name = "dbo.RIS_RELEASEMEDIA")]
    public partial class RIS_RELEASEMEDIA : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _RELEASE_ID;

        private int _ORDER_ID;

        private int _EXAM_ID;

        private string _HN;

        private System.DateTime _RELEASE_DATE;

        private char _REQUEST_BY;

        private int _REQUEST_BY_ID;

        private char _MEDIA_TYPE;

        private string _RECEIVED_BY;

        private char _REASON;

        private string _COMMENT;

        private System.Nullable<int> _UNIT_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<RIS_EXAM> _RIS_EXAM;

        private EntityRef<RIS_ORDER> _RIS_ORDER;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnRELEASE_IDChanging(int value);
        partial void OnRELEASE_IDChanged();
        partial void OnORDER_IDChanging(int value);
        partial void OnORDER_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnRELEASE_DATEChanging(System.DateTime value);
        partial void OnRELEASE_DATEChanged();
        partial void OnREQUEST_BYChanging(char value);
        partial void OnREQUEST_BYChanged();
        partial void OnREQUEST_BY_IDChanging(int value);
        partial void OnREQUEST_BY_IDChanged();
        partial void OnMEDIA_TYPEChanging(char value);
        partial void OnMEDIA_TYPEChanged();
        partial void OnRECEIVED_BYChanging(string value);
        partial void OnRECEIVED_BYChanged();
        partial void OnREASONChanging(char value);
        partial void OnREASONChanged();
        partial void OnCOMMENTChanging(string value);
        partial void OnCOMMENTChanged();
        partial void OnUNIT_IDChanging(System.Nullable<int> value);
        partial void OnUNIT_IDChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public RIS_RELEASEMEDIA()
        {
            this._RIS_EXAM = default(EntityRef<RIS_EXAM>);
            this._RIS_ORDER = default(EntityRef<RIS_ORDER>);
            OnCreated();
        }

        [Column(Storage = "_RELEASE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int RELEASE_ID
        {
            get
            {
                return this._RELEASE_ID;
            }
            set
            {
                if ((this._RELEASE_ID != value))
                {
                    this.OnRELEASE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASE_ID = value;
                    this.SendPropertyChanged("RELEASE_ID");
                    this.OnRELEASE_IDChanged();
                }
            }
        }

        [Column(Storage = "_ORDER_ID", DbType = "Int NOT NULL")]
        public int ORDER_ID
        {
            get
            {
                return this._ORDER_ID;
            }
            set
            {
                if ((this._ORDER_ID != value))
                {
                    if (this._RIS_ORDER.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnORDER_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_ID = value;
                    this.SendPropertyChanged("ORDER_ID");
                    this.OnORDER_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int NOT NULL")]
        public int EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    if (this._RIS_EXAM.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
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

        [Column(Storage = "_RELEASE_DATE", DbType = "DateTime NOT NULL")]
        public System.DateTime RELEASE_DATE
        {
            get
            {
                return this._RELEASE_DATE;
            }
            set
            {
                if ((this._RELEASE_DATE != value))
                {
                    this.OnRELEASE_DATEChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASE_DATE = value;
                    this.SendPropertyChanged("RELEASE_DATE");
                    this.OnRELEASE_DATEChanged();
                }
            }
        }

        [Column(Storage = "_REQUEST_BY", DbType = "NVarChar(1) NOT NULL")]
        public char REQUEST_BY
        {
            get
            {
                return this._REQUEST_BY;
            }
            set
            {
                if ((this._REQUEST_BY != value))
                {
                    this.OnREQUEST_BYChanging(value);
                    this.SendPropertyChanging();
                    this._REQUEST_BY = value;
                    this.SendPropertyChanged("REQUEST_BY");
                    this.OnREQUEST_BYChanged();
                }
            }
        }

        [Column(Storage = "_REQUEST_BY_ID", DbType = "Int NOT NULL")]
        public int REQUEST_BY_ID
        {
            get
            {
                return this._REQUEST_BY_ID;
            }
            set
            {
                if ((this._REQUEST_BY_ID != value))
                {
                    this.OnREQUEST_BY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REQUEST_BY_ID = value;
                    this.SendPropertyChanged("REQUEST_BY_ID");
                    this.OnREQUEST_BY_IDChanged();
                }
            }
        }

        [Column(Storage = "_MEDIA_TYPE", DbType = "NVarChar(1) NOT NULL")]
        public char MEDIA_TYPE
        {
            get
            {
                return this._MEDIA_TYPE;
            }
            set
            {
                if ((this._MEDIA_TYPE != value))
                {
                    this.OnMEDIA_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._MEDIA_TYPE = value;
                    this.SendPropertyChanged("MEDIA_TYPE");
                    this.OnMEDIA_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_RECEIVED_BY", DbType = "NVarChar(50)")]
        public string RECEIVED_BY
        {
            get
            {
                return this._RECEIVED_BY;
            }
            set
            {
                if ((this._RECEIVED_BY != value))
                {
                    this.OnRECEIVED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._RECEIVED_BY = value;
                    this.SendPropertyChanged("RECEIVED_BY");
                    this.OnRECEIVED_BYChanged();
                }
            }
        }

        [Column(Storage = "_REASON", DbType = "NVarChar(1) NOT NULL")]
        public char REASON
        {
            get
            {
                return this._REASON;
            }
            set
            {
                if ((this._REASON != value))
                {
                    this.OnREASONChanging(value);
                    this.SendPropertyChanging();
                    this._REASON = value;
                    this.SendPropertyChanged("REASON");
                    this.OnREASONChanged();
                }
            }
        }

        [Column(Storage = "_COMMENT", DbType = "NVarChar(1000)")]
        public string COMMENT
        {
            get
            {
                return this._COMMENT;
            }
            set
            {
                if ((this._COMMENT != value))
                {
                    this.OnCOMMENTChanging(value);
                    this.SendPropertyChanging();
                    this._COMMENT = value;
                    this.SendPropertyChanged("COMMENT");
                    this.OnCOMMENTChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_ID", DbType = "Int")]
        public System.Nullable<int> UNIT_ID
        {
            get
            {
                return this._UNIT_ID;
            }
            set
            {
                if ((this._UNIT_ID != value))
                {
                    this.OnUNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID = value;
                    this.SendPropertyChanged("UNIT_ID");
                    this.OnUNIT_IDChanged();
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

        [Association(Name = "RIS_EXAM_RIS_RELEASEMEDIA", Storage = "_RIS_EXAM", ThisKey = "EXAM_ID", OtherKey = "EXAM_ID", IsForeignKey = true)]
        public RIS_EXAM RIS_EXAM
        {
            get
            {
                return this._RIS_EXAM.Entity;
            }
            set
            {
                RIS_EXAM previousValue = this._RIS_EXAM.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAM.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAM.Entity = null;
                        previousValue.RIS_RELEASEMEDIAs.Remove(this);
                    }
                    this._RIS_EXAM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_RELEASEMEDIAs.Add(this);
                        this._EXAM_ID = value.EXAM_ID;
                    }
                    else
                    {
                        this._EXAM_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_EXAM");
                }
            }
        }

        [Association(Name = "RIS_ORDER_RIS_RELEASEMEDIA", Storage = "_RIS_ORDER", ThisKey = "ORDER_ID", OtherKey = "ORDER_ID", IsForeignKey = true)]
        public RIS_ORDER RIS_ORDER
        {
            get
            {
                return this._RIS_ORDER.Entity;
            }
            set
            {
                RIS_ORDER previousValue = this._RIS_ORDER.Entity;
                if (((previousValue != value)
                            || (this._RIS_ORDER.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_ORDER.Entity = null;
                        previousValue.RIS_RELEASEMEDIAs.Remove(this);
                    }
                    this._RIS_ORDER.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_RELEASEMEDIAs.Add(this);
                        this._ORDER_ID = value.ORDER_ID;
                    }
                    else
                    {
                        this._ORDER_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_ORDER");
                }
            }
        }
        public int SELECTCASE { get; set; }
        public DateTime FROMDATE { get; set; }
        public DateTime TODATE { get; set; }
        public string ACCESSION_NO { get; set; }
        public byte QTY { get; set; }

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
