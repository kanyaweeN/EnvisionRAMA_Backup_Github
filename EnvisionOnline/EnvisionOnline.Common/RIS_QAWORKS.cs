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
    [Table(Name = "dbo.RIS_QAWORKS")]
    public partial class RIS_QAWORK : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ACCESSION_NO;

        private byte _SL;

        private System.Nullable<int> _REASON_ID;

        private System.Nullable<char> _QA_RESULT;

        private string _COMMENTS;

        private System.Nullable<System.DateTime> _START_TIME;

        private System.Nullable<System.DateTime> _END_TIME;

        private System.Nullable<int> _NO_OF_IMAGES_PRINT;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<RIS_QAWORK> _RIS_QAWORK2;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_QAWORK> _RIS_QAWORK1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnSLChanging(byte value);
        partial void OnSLChanged();
        partial void OnREASON_IDChanging(System.Nullable<int> value);
        partial void OnREASON_IDChanged();
        partial void OnQA_RESULTChanging(System.Nullable<char> value);
        partial void OnQA_RESULTChanged();
        partial void OnCOMMENTSChanging(string value);
        partial void OnCOMMENTSChanged();
        partial void OnSTART_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnSTART_TIMEChanged();
        partial void OnEND_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnEND_TIMEChanged();
        partial void OnNO_OF_IMAGES_PRINTChanging(System.Nullable<int> value);
        partial void OnNO_OF_IMAGES_PRINTChanged();
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

        public RIS_QAWORK()
        {
            this._RIS_QAWORK2 = default(EntityRef<RIS_QAWORK>);
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_QAWORK1 = default(EntityRef<RIS_QAWORK>);
            OnCreated();
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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
                    if (this._RIS_QAWORK1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnACCESSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_NO = value;
                    this.SendPropertyChanged("ACCESSION_NO");
                    this.OnACCESSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_SL", DbType = "TinyInt NOT NULL", IsPrimaryKey = true)]
        public byte SL
        {
            get
            {
                return this._SL;
            }
            set
            {
                if ((this._SL != value))
                {
                    if (this._RIS_QAWORK1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSLChanging(value);
                    this.SendPropertyChanging();
                    this._SL = value;
                    this.SendPropertyChanged("SL");
                    this.OnSLChanged();
                }
            }
        }

        [Column(Storage = "_REASON_ID", DbType = "Int")]
        public System.Nullable<int> REASON_ID
        {
            get
            {
                return this._REASON_ID;
            }
            set
            {
                if ((this._REASON_ID != value))
                {
                    this.OnREASON_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REASON_ID = value;
                    this.SendPropertyChanged("REASON_ID");
                    this.OnREASON_IDChanged();
                }
            }
        }

        [Column(Storage = "_QA_RESULT", DbType = "NVarChar(1)")]
        public System.Nullable<char> QA_RESULT
        {
            get
            {
                return this._QA_RESULT;
            }
            set
            {
                if ((this._QA_RESULT != value))
                {
                    this.OnQA_RESULTChanging(value);
                    this.SendPropertyChanging();
                    this._QA_RESULT = value;
                    this.SendPropertyChanged("QA_RESULT");
                    this.OnQA_RESULTChanged();
                }
            }
        }

        [Column(Storage = "_COMMENTS", DbType = "NVarChar(250)")]
        public string COMMENTS
        {
            get
            {
                return this._COMMENTS;
            }
            set
            {
                if ((this._COMMENTS != value))
                {
                    this.OnCOMMENTSChanging(value);
                    this.SendPropertyChanging();
                    this._COMMENTS = value;
                    this.SendPropertyChanged("COMMENTS");
                    this.OnCOMMENTSChanged();
                }
            }
        }

        [Column(Storage = "_START_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> START_TIME
        {
            get
            {
                return this._START_TIME;
            }
            set
            {
                if ((this._START_TIME != value))
                {
                    this.OnSTART_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._START_TIME = value;
                    this.SendPropertyChanged("START_TIME");
                    this.OnSTART_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_END_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> END_TIME
        {
            get
            {
                return this._END_TIME;
            }
            set
            {
                if ((this._END_TIME != value))
                {
                    this.OnEND_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._END_TIME = value;
                    this.SendPropertyChanged("END_TIME");
                    this.OnEND_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_NO_OF_IMAGES_PRINT", DbType = "Int")]
        public System.Nullable<int> NO_OF_IMAGES_PRINT
        {
            get
            {
                return this._NO_OF_IMAGES_PRINT;
            }
            set
            {
                if ((this._NO_OF_IMAGES_PRINT != value))
                {
                    this.OnNO_OF_IMAGES_PRINTChanging(value);
                    this.SendPropertyChanging();
                    this._NO_OF_IMAGES_PRINT = value;
                    this.SendPropertyChanged("NO_OF_IMAGES_PRINT");
                    this.OnNO_OF_IMAGES_PRINTChanged();
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
                    if (this._GBL_ENV.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
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

        [Association(Name = "RIS_QAWORK_RIS_QAWORK", Storage = "_RIS_QAWORK2", ThisKey = "ACCESSION_NO,SL", OtherKey = "ACCESSION_NO,SL", IsUnique = true, IsForeignKey = false)]
        public RIS_QAWORK RIS_QAWORK2
        {
            get
            {
                return this._RIS_QAWORK2.Entity;
            }
            set
            {
                RIS_QAWORK previousValue = this._RIS_QAWORK2.Entity;
                if (((previousValue != value)
                            || (this._RIS_QAWORK2.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_QAWORK2.Entity = null;
                        previousValue.RIS_QAWORK1 = null;
                    }
                    this._RIS_QAWORK2.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_QAWORK1 = this;
                    }
                    this.SendPropertyChanged("RIS_QAWORK2");
                }
            }
        }

        [Association(Name = "GBL_ENV_RIS_QAWORK", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
        public GBL_ENV GBL_ENV
        {
            get
            {
                return this._GBL_ENV.Entity;
            }
            set
            {
                GBL_ENV previousValue = this._GBL_ENV.Entity;
                if (((previousValue != value)
                            || (this._GBL_ENV.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_ENV.Entity = null;
                        previousValue.RIS_QAWORKs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_QAWORKs.Add(this);
                        this._ORG_ID = value.ORG_ID;
                    }
                    else
                    {
                        this._ORG_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_ENV");
                }
            }
        }

        [Association(Name = "RIS_QAWORK_RIS_QAWORK", Storage = "_RIS_QAWORK1", ThisKey = "ACCESSION_NO,SL", OtherKey = "ACCESSION_NO,SL", IsForeignKey = true)]
        public RIS_QAWORK RIS_QAWORK1
        {
            get
            {
                return this._RIS_QAWORK1.Entity;
            }
            set
            {
                RIS_QAWORK previousValue = this._RIS_QAWORK1.Entity;
                if (((previousValue != value)
                            || (this._RIS_QAWORK1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_QAWORK1.Entity = null;
                        previousValue.RIS_QAWORK2 = null;
                    }
                    this._RIS_QAWORK1.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_QAWORK2 = this;
                        this._ACCESSION_NO = value.ACCESSION_NO;
                        this._SL = value.SL;
                    }
                    else
                    {
                        this._ACCESSION_NO = default(string);
                        this._SL = default(byte);
                    }
                    this.SendPropertyChanged("RIS_QAWORK1");
                }
            }
        }
        public int MODE { get; set; }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }

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
