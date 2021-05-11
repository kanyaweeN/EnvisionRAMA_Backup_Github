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
    [Table(Name = "dbo.RIS_LOADMEDIA")]
    public partial class RIS_LOADMEDIA : INotifyPropertyChanging, INotifyPropertyChanged
    {
       
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _LOAD_ID;

        private string _HN;

        private string _VISIT_NO;

        private string _ADMISSION_NO;

        private System.DateTime _LOAD_DT;

        private System.Nullable<System.DateTime> _LOAD_START_TIME;

        private char _REQ_BY;

        private System.Nullable<int> _REQ_UNIT;

        private System.Nullable<int> _REQ_DOC;

        private char _MEDIA_TYPE;

        private char _REASON;

        private string _COMMENT;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<RIS_LOADMEDIADTL> _RIS_LOADMEDIADTLs;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnLOAD_IDChanging(int value);
        partial void OnLOAD_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnVISIT_NOChanging(string value);
        partial void OnVISIT_NOChanged();
        partial void OnADMISSION_NOChanging(string value);
        partial void OnADMISSION_NOChanged();
        partial void OnLOAD_DTChanging(System.DateTime value);
        partial void OnLOAD_DTChanged();
        partial void OnLOAD_START_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnLOAD_START_TIMEChanged();
        partial void OnREQ_BYChanging(char value);
        partial void OnREQ_BYChanged();
        partial void OnREQ_UNITChanging(System.Nullable<int> value);
        partial void OnREQ_UNITChanged();
        partial void OnREQ_DOCChanging(System.Nullable<int> value);
        partial void OnREQ_DOCChanged();
        partial void OnMEDIA_TYPEChanging(char value);
        partial void OnMEDIA_TYPEChanged();
        partial void OnREASONChanging(char value);
        partial void OnREASONChanged();
        partial void OnCOMMENTChanging(string value);
        partial void OnCOMMENTChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public RIS_LOADMEDIA()
        {
            this._RIS_LOADMEDIADTLs = new EntitySet<RIS_LOADMEDIADTL>(new Action<RIS_LOADMEDIADTL>(this.attach_RIS_LOADMEDIADTLs), new Action<RIS_LOADMEDIADTL>(this.detach_RIS_LOADMEDIADTLs));
            OnCreated();
        }

        [Column(Storage = "_LOAD_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int LOAD_ID
        {
            get
            {
                return this._LOAD_ID;
            }
            set
            {
                if ((this._LOAD_ID != value))
                {
                    this.OnLOAD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._LOAD_ID = value;
                    this.SendPropertyChanged("LOAD_ID");
                    this.OnLOAD_IDChanged();
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

        [Column(Storage = "_VISIT_NO", DbType = "NVarChar(30)")]
        public string VISIT_NO
        {
            get
            {
                return this._VISIT_NO;
            }
            set
            {
                if ((this._VISIT_NO != value))
                {
                    this.OnVISIT_NOChanging(value);
                    this.SendPropertyChanging();
                    this._VISIT_NO = value;
                    this.SendPropertyChanged("VISIT_NO");
                    this.OnVISIT_NOChanged();
                }
            }
        }

        [Column(Storage = "_ADMISSION_NO", DbType = "NVarChar(30)")]
        public string ADMISSION_NO
        {
            get
            {
                return this._ADMISSION_NO;
            }
            set
            {
                if ((this._ADMISSION_NO != value))
                {
                    this.OnADMISSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ADMISSION_NO = value;
                    this.SendPropertyChanged("ADMISSION_NO");
                    this.OnADMISSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_LOAD_DT", DbType = "DateTime NOT NULL")]
        public System.DateTime LOAD_DT
        {
            get
            {
                return this._LOAD_DT;
            }
            set
            {
                if ((this._LOAD_DT != value))
                {
                    this.OnLOAD_DTChanging(value);
                    this.SendPropertyChanging();
                    this._LOAD_DT = value;
                    this.SendPropertyChanged("LOAD_DT");
                    this.OnLOAD_DTChanged();
                }
            }
        }

        [Column(Storage = "_LOAD_START_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LOAD_START_TIME
        {
            get
            {
                return this._LOAD_START_TIME;
            }
            set
            {
                if ((this._LOAD_START_TIME != value))
                {
                    this.OnLOAD_START_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._LOAD_START_TIME = value;
                    this.SendPropertyChanged("LOAD_START_TIME");
                    this.OnLOAD_START_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_REQ_BY", DbType = "NVarChar(1) NOT NULL")]
        public char REQ_BY
        {
            get
            {
                return this._REQ_BY;
            }
            set
            {
                if ((this._REQ_BY != value))
                {
                    this.OnREQ_BYChanging(value);
                    this.SendPropertyChanging();
                    this._REQ_BY = value;
                    this.SendPropertyChanged("REQ_BY");
                    this.OnREQ_BYChanged();
                }
            }
        }

        [Column(Storage = "_REQ_UNIT", DbType = "Int")]
        public System.Nullable<int> REQ_UNIT
        {
            get
            {
                return this._REQ_UNIT;
            }
            set
            {
                if ((this._REQ_UNIT != value))
                {
                    this.OnREQ_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._REQ_UNIT = value;
                    this.SendPropertyChanged("REQ_UNIT");
                    this.OnREQ_UNITChanged();
                }
            }
        }

        [Column(Storage = "_REQ_DOC", DbType = "Int")]
        public System.Nullable<int> REQ_DOC
        {
            get
            {
                return this._REQ_DOC;
            }
            set
            {
                if ((this._REQ_DOC != value))
                {
                    this.OnREQ_DOCChanging(value);
                    this.SendPropertyChanging();
                    this._REQ_DOC = value;
                    this.SendPropertyChanged("REQ_DOC");
                    this.OnREQ_DOCChanged();
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

        [Association(Name = "RIS_LOADMEDIA_RIS_LOADMEDIADTL", Storage = "_RIS_LOADMEDIADTLs", ThisKey = "LOAD_ID", OtherKey = "LOAD_ID")]
        public EntitySet<RIS_LOADMEDIADTL> RIS_LOADMEDIADTLs
        {
            get
            {
                return this._RIS_LOADMEDIADTLs;
            }
            set
            {
                this._RIS_LOADMEDIADTLs.Assign(value);
            }
        }
        public DateTime FROM_DATE { get; set; }

        public DateTime TO_DATE { get; set; }

        public int SELECTCASE { get; set; }

        public int EMP_ID { get; set; }

        public string ACCESSION_NO { get; set; }

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

        private void attach_RIS_LOADMEDIADTLs(RIS_LOADMEDIADTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_LOADMEDIA = this;
        }

        private void detach_RIS_LOADMEDIADTLs(RIS_LOADMEDIADTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_LOADMEDIA = null;
        }
    }
}
