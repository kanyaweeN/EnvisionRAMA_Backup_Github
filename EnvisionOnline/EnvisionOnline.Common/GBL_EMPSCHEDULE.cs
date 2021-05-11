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
    //[Table(Name = "dbo.GBL_EMPSCHEDULE")]
    //public partial class GBL_EMPSCHEDULE : INotifyPropertyChanging, INotifyPropertyChanged
    //{

    //    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

    //    private int _SCHEDULE_ID;

    //    private System.Nullable<int> _EMP_ID;

    //    private System.Nullable<bool> _ALLDAY;

    //    private string _SUBJECT;

    //    private System.Nullable<System.DateTime> _STARTDATETIME;

    //    private System.Nullable<System.DateTime> _ENDDATETIME;

    //    private string _STATUS;

    //    private string _LABEL;

    //    private string _LOCATION;

    //    private string _DESCRIPTION;

    //    private string _TYPE;

    //    private string _RECURRENCEINFO;

    //    private string _REMINDERINFO;

    //    private string _RESOURCEINFO;

    //    private System.Nullable<int> _ORG_ID;

    //    private System.Nullable<int> _CREATED_BY;

    //    private System.Nullable<System.DateTime> _CREATED_ON;

    //    private System.Nullable<int> _LAST_MODIFIED_BY;

    //    private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

    //    #region Extensibility Method Definitions
    //    partial void OnLoaded();
    //    partial void OnValidate(System.Data.Linq.ChangeAction action);
    //    partial void OnCreated();
    //    partial void OnSCHEDULE_IDChanging(int value);
    //    partial void OnSCHEDULE_IDChanged();
    //    partial void OnEMP_IDChanging(System.Nullable<int> value);
    //    partial void OnEMP_IDChanged();
    //    partial void OnALLDAYChanging(System.Nullable<bool> value);
    //    partial void OnALLDAYChanged();
    //    partial void OnSUBJECTChanging(string value);
    //    partial void OnSUBJECTChanged();
    //    partial void OnSTARTDATETIMEChanging(System.Nullable<System.DateTime> value);
    //    partial void OnSTARTDATETIMEChanged();
    //    partial void OnENDDATETIMEChanging(System.Nullable<System.DateTime> value);
    //    partial void OnENDDATETIMEChanged();
    //    partial void OnSTATUSChanging(string value);
    //    partial void OnSTATUSChanged();
    //    partial void OnLABELChanging(string value);
    //    partial void OnLABELChanged();
    //    partial void OnLOCATIONChanging(string value);
    //    partial void OnLOCATIONChanged();
    //    partial void OnTYPEChanging(string value);
    //    partial void OnTYPEChanged();
    //    partial void OnRECURRENCEINFOChanging(string value);
    //    partial void OnRECURRENCEINFOChanged();
    //    partial void OnREMINDERINFOChanging(string value);
    //    partial void OnREMINDERINFOChanged();
    //    partial void OnRESOURCEINFOChanging(string value);
    //    partial void OnRESOURCEINFOChanged();

    //    partial void OnDESCRIPTIONChanging(string value);
    //    partial void OnDESCRIPTIONChanged();

    //    partial void OnORG_IDChanging(System.Nullable<int> value);
    //    partial void OnORG_IDChanged();
    //    partial void OnCREATED_BYChanging(System.Nullable<int> value);
    //    partial void OnCREATED_BYChanged();
    //    partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
    //    partial void OnCREATED_ONChanged();
    //    partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
    //    partial void OnLAST_MODIFIED_BYChanged();
    //    partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
    //    partial void OnLAST_MODIFIED_ONChanged();
    //    #endregion

    //    public GBL_EMPSCHEDULE()
    //    {
    //        OnCreated();
    //    }

    //    [Column(Storage = "_SCHEDULE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
    //    public int SCHEDULE_ID
    //    {
    //        get
    //        {
    //            return this._SCHEDULE_ID;
    //        }
    //        set
    //        {
    //            if ((this._SCHEDULE_ID != value))
    //            {
    //                this.OnSCHEDULE_IDChanging(value);
    //                this.SendPropertyChanging();
    //                this._SCHEDULE_ID = value;
    //                this.SendPropertyChanged("SCHEDULE_ID");
    //                this.OnSCHEDULE_IDChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_EMP_ID", DbType = "Int")]
    //    public System.Nullable<int> EMP_ID
    //    {
    //        get
    //        {
    //            return this._EMP_ID;
    //        }
    //        set
    //        {
    //            if ((this._EMP_ID != value))
    //            {
    //                this.OnEMP_IDChanging(value);
    //                this.SendPropertyChanging();
    //                this._EMP_ID = value;
    //                this.SendPropertyChanged("EMP_ID");
    //                this.OnEMP_IDChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_ALLDAY", DbType = "Bit")]
    //    public System.Nullable<bool> ALLDAY
    //    {
    //        get
    //        {
    //            return this._ALLDAY;
    //        }
    //        set
    //        {
    //            if ((this._ALLDAY != value))
    //            {
    //                this.OnALLDAYChanging(value);
    //                this.SendPropertyChanging();
    //                this._ALLDAY = value;
    //                this.SendPropertyChanged("ALLDAY");
    //                this.OnALLDAYChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_SUBJECT", DbType = "NVarChar(500)")]
    //    public string SUBJECT
    //    {
    //        get
    //        {
    //            return this._SUBJECT;
    //        }
    //        set
    //        {
    //            if ((this._SUBJECT != value))
    //            {
    //                this.OnSUBJECTChanging(value);
    //                this.SendPropertyChanging();
    //                this._SUBJECT = value;
    //                this.SendPropertyChanged("SUBJECT");
    //                this.OnSUBJECTChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_STARTDATETIME", DbType = "Date")]
    //    public System.Nullable<System.DateTime> STARTDATETIME
    //    {
    //        get
    //        {
    //            return this._STARTDATETIME;
    //        }
    //        set
    //        {
    //            if ((this._STARTDATETIME != value))
    //            {
    //                this.OnSTARTDATETIMEChanging(value);
    //                this.SendPropertyChanging();
    //                this._STARTDATETIME = value;
    //                this.SendPropertyChanged("STARTDATETIME");
    //                this.OnSTARTDATETIMEChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_ENDDATETIME", DbType = "Date")]
    //    public System.Nullable<System.DateTime> ENDDATETIME
    //    {
    //        get
    //        {
    //            return this._ENDDATETIME;
    //        }
    //        set
    //        {
    //            if ((this._ENDDATETIME != value))
    //            {
    //                this.OnENDDATETIMEChanging(value);
    //                this.SendPropertyChanging();
    //                this._ENDDATETIME = value;
    //                this.SendPropertyChanged("ENDDATETIME");
    //                this.OnENDDATETIMEChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_STATUS", DbType = "NVarChar(10)")]
    //    public string STATUS
    //    {
    //        get
    //        {
    //            return this._STATUS;
    //        }
    //        set
    //        {
    //            if ((this._STATUS != value))
    //            {
    //                this.OnSTATUSChanging(value);
    //                this.SendPropertyChanging();
    //                this._STATUS = value;
    //                this.SendPropertyChanged("STATUS");
    //                this.OnSTATUSChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_LABEL", DbType = "NVarChar(500)")]
    //    public string LABEL
    //    {
    //        get
    //        {
    //            return this._LABEL;
    //        }
    //        set
    //        {
    //            if ((this._LABEL != value))
    //            {
    //                this.OnLABELChanging(value);
    //                this.SendPropertyChanging();
    //                this._LABEL = value;
    //                this.SendPropertyChanged("LABEL");
    //                this.OnLABELChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_LOCATION", DbType = "NVarChar(500)")]
    //    public string LOCATION
    //    {
    //        get
    //        {
    //            return this._LOCATION;
    //        }
    //        set
    //        {
    //            if ((this._LOCATION != value))
    //            {
    //                this.OnLOCATIONChanging(value);
    //                this.SendPropertyChanging();
    //                this._LOCATION = value;
    //                this.SendPropertyChanged("LOCATION");
    //                this.OnLOCATIONChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_TYPE", DbType = "NVarChar(500)")]
    //    public string TYPE
    //    {
    //        get
    //        {
    //            return this._TYPE;
    //        }
    //        set
    //        {
    //            if ((this._TYPE != value))
    //            {
    //                this.OnTYPEChanging(value);
    //                this.SendPropertyChanging();
    //                this._TYPE = value;
    //                this.SendPropertyChanged("TYPE");
    //                this.OnTYPEChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_RECURRENCEINFO", DbType = "NVarChar(MAX)")]
    //    public string RECURRENCEINFO
    //    {
    //        get
    //        {
    //            return this._RECURRENCEINFO;
    //        }
    //        set
    //        {
    //            if ((this._RECURRENCEINFO != value))
    //            {
    //                this.OnRECURRENCEINFOChanging(value);
    //                this.SendPropertyChanging();
    //                this._RECURRENCEINFO = value;
    //                this.SendPropertyChanged("RECURRENCEINFO");
    //                this.OnRECURRENCEINFOChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_REMINDERINFO", DbType = "NVarChar(MAX)")]
    //    public string REMINDERINFO
    //    {
    //        get
    //        {
    //            return this._REMINDERINFO;
    //        }
    //        set
    //        {
    //            if ((this._REMINDERINFO != value))
    //            {
    //                this.OnREMINDERINFOChanging(value);
    //                this.SendPropertyChanging();
    //                this._REMINDERINFO = value;
    //                this.SendPropertyChanged("REMINDERINFO");
    //                this.OnREMINDERINFOChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_RESOURCEINFO", DbType = "NVarChar(MAX)")]
    //    public string RESOURCEINFO
    //    {
    //        get
    //        {
    //            return this._RESOURCEINFO;
    //        }
    //        set
    //        {
    //            if ((this._RESOURCEINFO != value))
    //            {
    //                this.OnRESOURCEINFOChanging(value);
    //                this.SendPropertyChanging();
    //                this._RESOURCEINFO = value;
    //                this.SendPropertyChanged("RESOURCEINFO");
    //                this.OnRESOURCEINFOChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_ORG_ID", DbType = "Int")]
    //    public System.Nullable<int> ORG_ID
    //    {
    //        get
    //        {
    //            return this._ORG_ID;
    //        }
    //        set
    //        {
    //            if ((this._ORG_ID != value))
    //            {
    //                this.OnORG_IDChanging(value);
    //                this.SendPropertyChanging();
    //                this._ORG_ID = value;
    //                this.SendPropertyChanged("ORG_ID");
    //                this.OnORG_IDChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_CREATED_BY", DbType = "Int")]
    //    public System.Nullable<int> CREATED_BY
    //    {
    //        get
    //        {
    //            return this._CREATED_BY;
    //        }
    //        set
    //        {
    //            if ((this._CREATED_BY != value))
    //            {
    //                this.OnCREATED_BYChanging(value);
    //                this.SendPropertyChanging();
    //                this._CREATED_BY = value;
    //                this.SendPropertyChanged("CREATED_BY");
    //                this.OnCREATED_BYChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_CREATED_ON", DbType = "Date")]
    //    public System.Nullable<System.DateTime> CREATED_ON
    //    {
    //        get
    //        {
    //            return this._CREATED_ON;
    //        }
    //        set
    //        {
    //            if ((this._CREATED_ON != value))
    //            {
    //                this.OnCREATED_ONChanging(value);
    //                this.SendPropertyChanging();
    //                this._CREATED_ON = value;
    //                this.SendPropertyChanged("CREATED_ON");
    //                this.OnCREATED_ONChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_LAST_MODIFIED_BY", DbType = "Int")]
    //    public System.Nullable<int> LAST_MODIFIED_BY
    //    {
    //        get
    //        {
    //            return this._LAST_MODIFIED_BY;
    //        }
    //        set
    //        {
    //            if ((this._LAST_MODIFIED_BY != value))
    //            {
    //                this.OnLAST_MODIFIED_BYChanging(value);
    //                this.SendPropertyChanging();
    //                this._LAST_MODIFIED_BY = value;
    //                this.SendPropertyChanged("LAST_MODIFIED_BY");
    //                this.OnLAST_MODIFIED_BYChanged();
    //            }
    //        }
    //    }

    //    [Column(Storage = "_LAST_MODIFIED_ON", DbType = "Date")]
    //    public System.Nullable<System.DateTime> LAST_MODIFIED_ON
    //    {
    //        get
    //        {
    //            return this._LAST_MODIFIED_ON;
    //        }
    //        set
    //        {
    //            if ((this._LAST_MODIFIED_ON != value))
    //            {
    //                this.OnLAST_MODIFIED_ONChanging(value);
    //                this.SendPropertyChanging();
    //                this._LAST_MODIFIED_ON = value;
    //                this.SendPropertyChanged("LAST_MODIFIED_ON");
    //                this.OnLAST_MODIFIED_ONChanged();
    //            }
    //        }
    //    }


    //    [Column(Storage = "_DESCRIPTION", DbType = "NVarChar(MAX)")]
    //    public string DESCRIPTION
    //    {
    //        get
    //        {
    //            return this._DESCRIPTION;
    //        }
    //        set
    //        {
    //            if ((this._DESCRIPTION != value))
    //            {
    //                this.OnDESCRIPTIONChanging(value);
                   
    //                this.SendPropertyChanging();
    //                this._DESCRIPTION = value;
    //                this.SendPropertyChanged("DESCRIPTION");

    //                this.OnDESCRIPTIONChanged();
    //            }
    //        }
    //    }

    //    public event PropertyChangingEventHandler PropertyChanging;

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected virtual void SendPropertyChanging()
    //    {
    //        if ((this.PropertyChanging != null))
    //        {
    //            this.PropertyChanging(this, emptyChangingEventArgs);
    //        }
    //    }

    //    protected virtual void SendPropertyChanged(String propertyName)
    //    {
    //        if ((this.PropertyChanged != null))
    //        {
    //            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}

    [Table(Name = "dbo.GBL_EMPSCHEDULE")]
    public partial class GBL_EMPSCHEDULE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SCHEDULE_ID;

        private System.Nullable<int> _EMP_ID;

        private System.Nullable<bool> _ALLDAY;

        private string _SUBJECT;

        private System.Nullable<System.DateTime> _STARTDATETIME;

        private System.Nullable<System.DateTime> _ENDDATETIME;

        private System.Nullable<int> _STATUS;

        private System.Nullable<int> _LABEL;

        private string _LOCATION;

        private System.Nullable<int> _EVENTTYPE;

        private string _DESCRIPTION;

        private string _RECURRENCEINFO;

        private string _REMINDERINFO;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _SCHEDULE_ID_PARENT;


        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSCHEDULE_IDChanging(int value);
        partial void OnSCHEDULE_IDChanged();
        partial void OnEMP_IDChanging(System.Nullable<int> value);
        partial void OnEMP_IDChanged();
        partial void OnALLDAYChanging(System.Nullable<bool> value);
        partial void OnALLDAYChanged();
        partial void OnSUBJECTChanging(string value);
        partial void OnSUBJECTChanged();
        partial void OnSTARTDATETIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnSTARTDATETIMEChanged();
        partial void OnENDDATETIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnENDDATETIMEChanged();
        partial void OnSTATUSChanging(System.Nullable<int> value);
        partial void OnSTATUSChanged();
        partial void OnLABELChanging(System.Nullable<int> value);
        partial void OnLABELChanged();
        partial void OnLOCATIONChanging(string value);
        partial void OnLOCATIONChanged();
        partial void OnEVENTTYPEChanging(System.Nullable<int> value);
        partial void OnEVENTTYPEChanged();
        partial void OnDESCRIPTIONChanging(string value);
        partial void OnDESCRIPTIONChanged();
        partial void OnRECURRENCEINFOChanging(string value);
        partial void OnRECURRENCEINFOChanged();
        partial void OnREMINDERINFOChanging(string value);
        partial void OnREMINDERINFOChanged();
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

        partial void OnSCHEDULE_ID_PARENTChanging(System.Nullable<int> value);
        partial void OnSCHEDULE_ID_PARENTChanged();

        #endregion

        public GBL_EMPSCHEDULE()
        {
            OnCreated();
        }

        [Column(Storage = "_SCHEDULE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SCHEDULE_ID
        {
            get
            {
                return this._SCHEDULE_ID;
            }
            set
            {
                if ((this._SCHEDULE_ID != value))
                {
                    this.OnSCHEDULE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_ID = value;
                    this.SendPropertyChanged("SCHEDULE_ID");
                    this.OnSCHEDULE_IDChanged();
                }
            }
        }

        [Column(Storage = "_EMP_ID", DbType = "Int")]
        public System.Nullable<int> EMP_ID
        {
            get
            {
                return this._EMP_ID;
            }
            set
            {
                if ((this._EMP_ID != value))
                {
                    this.OnEMP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_ID = value;
                    this.SendPropertyChanged("EMP_ID");
                    this.OnEMP_IDChanged();
                }
            }
        }

        [Column(Storage = "_ALLDAY", DbType = "Bit")]
        public System.Nullable<bool> ALLDAY
        {
            get
            {
                return this._ALLDAY;
            }
            set
            {
                if ((this._ALLDAY != value))
                {
                    this.OnALLDAYChanging(value);
                    this.SendPropertyChanging();
                    this._ALLDAY = value;
                    this.SendPropertyChanged("ALLDAY");
                    this.OnALLDAYChanged();
                }
            }
        }

        [Column(Storage = "_SUBJECT", DbType = "NVarChar(50)")]
        public string SUBJECT
        {
            get
            {
                return this._SUBJECT;
            }
            set
            {
                if ((this._SUBJECT != value))
                {
                    this.OnSUBJECTChanging(value);
                    this.SendPropertyChanging();
                    this._SUBJECT = value;
                    this.SendPropertyChanged("SUBJECT");
                    this.OnSUBJECTChanged();
                }
            }
        }

        [Column(Storage = "_STARTDATETIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> STARTDATETIME
        {
            get
            {
                return this._STARTDATETIME;
            }
            set
            {
                if ((this._STARTDATETIME != value))
                {
                    this.OnSTARTDATETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._STARTDATETIME = value;
                    this.SendPropertyChanged("STARTDATETIME");
                    this.OnSTARTDATETIMEChanged();
                }
            }
        }

        [Column(Storage = "_ENDDATETIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ENDDATETIME
        {
            get
            {
                return this._ENDDATETIME;
            }
            set
            {
                if ((this._ENDDATETIME != value))
                {
                    this.OnENDDATETIMEChanging(value);
                    this.SendPropertyChanging();
                    this._ENDDATETIME = value;
                    this.SendPropertyChanged("ENDDATETIME");
                    this.OnENDDATETIMEChanged();
                }
            }
        }

        [Column(Storage = "_STATUS", DbType = "Int")]
        public System.Nullable<int> STATUS
        {
            get
            {
                return this._STATUS;
            }
            set
            {
                if ((this._STATUS != value))
                {
                    this.OnSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS = value;
                    this.SendPropertyChanged("STATUS");
                    this.OnSTATUSChanged();
                }
            }
        }

        [Column(Storage = "_LABEL", DbType = "Int")]
        public System.Nullable<int> LABEL
        {
            get
            {
                return this._LABEL;
            }
            set
            {
                if ((this._LABEL != value))
                {
                    this.OnLABELChanging(value);
                    this.SendPropertyChanging();
                    this._LABEL = value;
                    this.SendPropertyChanged("LABEL");
                    this.OnLABELChanged();
                }
            }
        }

        [Column(Storage = "_LOCATION", DbType = "NVarChar(50)")]
        public string LOCATION
        {
            get
            {
                return this._LOCATION;
            }
            set
            {
                if ((this._LOCATION != value))
                {
                    this.OnLOCATIONChanging(value);
                    this.SendPropertyChanging();
                    this._LOCATION = value;
                    this.SendPropertyChanged("LOCATION");
                    this.OnLOCATIONChanged();
                }
            }
        }

        [Column(Storage = "_EVENTTYPE", DbType = "Int")]
        public System.Nullable<int> EVENTTYPE
        {
            get
            {
                return this._EVENTTYPE;
            }
            set
            {
                if ((this._EVENTTYPE != value))
                {
                    this.OnEVENTTYPEChanging(value);
                    this.SendPropertyChanging();
                    this._EVENTTYPE = value;
                    this.SendPropertyChanged("EVENTTYPE");
                    this.OnEVENTTYPEChanged();
                }
            }
        }

        [Column(Storage = "_DESCRIPTION", DbType = "NVarChar(MAX)")]
        public string DESCRIPTION
        {
            get
            {
                return this._DESCRIPTION;
            }
            set
            {
                if ((this._DESCRIPTION != value))
                {
                    this.OnDESCRIPTIONChanging(value);
                    this.SendPropertyChanging();
                    this._DESCRIPTION = value;
                    this.SendPropertyChanged("DESCRIPTION");
                    this.OnDESCRIPTIONChanged();
                }
            }
        }

        [Column(Storage = "_RECURRENCEINFO", DbType = "NVarChar(MAX)")]
        public string RECURRENCEINFO
        {
            get
            {
                return this._RECURRENCEINFO;
            }
            set
            {
                if ((this._RECURRENCEINFO != value))
                {
                    this.OnRECURRENCEINFOChanging(value);
                    this.SendPropertyChanging();
                    this._RECURRENCEINFO = value;
                    this.SendPropertyChanged("RECURRENCEINFO");
                    this.OnRECURRENCEINFOChanged();
                }
            }
        }

        [Column(Storage = "_REMINDERINFO", DbType = "NVarChar(MAX)")]
        public string REMINDERINFO
        {
            get
            {
                return this._REMINDERINFO;
            }
            set
            {
                if ((this._REMINDERINFO != value))
                {
                    this.OnREMINDERINFOChanging(value);
                    this.SendPropertyChanging();
                    this._REMINDERINFO = value;
                    this.SendPropertyChanged("REMINDERINFO");
                    this.OnREMINDERINFOChanged();
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

        [Column(Storage = "_SCHEDULE_ID_PARENT", DbType = "Int")]
        public System.Nullable<int> SCHEDULE_ID_PARENT
        {
            get
            {
                return this._SCHEDULE_ID_PARENT;
            }
            set
            {
                if ((this._SCHEDULE_ID_PARENT != value))
                {
                    this.OnSCHEDULE_ID_PARENTChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_ID_PARENT = value;
                    this.SendPropertyChanged("SCHEDULE_ID_PARENT");
                    this.OnSCHEDULE_ID_PARENTChanged();
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
