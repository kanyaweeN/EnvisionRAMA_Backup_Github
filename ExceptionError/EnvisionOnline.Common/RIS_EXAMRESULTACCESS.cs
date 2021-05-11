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
    [Table(Name = "dbo.RIS_EXAMRESULTACCESS")]
    public partial class RIS_EXAMRESULTACCESS : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ACCESS_NO;

        private string _ACCESSION_NO;

        private System.Nullable<int> _ACCESS_BY;

        private System.Nullable<System.DateTime> _ACCESS_ON;

        private System.Nullable<char> _ACCESS_STATUS;

        private string _ACCESS_TEXT;

        private System.Nullable<System.DateTime> _EXIT_ON;

        private System.Nullable<char> _EXIT_STATUS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private string _ACCESS_TEXT_RTF;

        private System.Nullable<char> _ACCESS_TYPE;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_EMP> _HR_EMP;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnACCESS_NOChanging(int value);
        partial void OnACCESS_NOChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnACCESS_BYChanging(System.Nullable<int> value);
        partial void OnACCESS_BYChanged();
        partial void OnACCESS_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnACCESS_ONChanged();
        partial void OnACCESS_STATUSChanging(System.Nullable<char> value);
        partial void OnACCESS_STATUSChanged();
        partial void OnACCESS_TEXTChanging(string value);
        partial void OnACCESS_TEXTChanged();
        partial void OnEXIT_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnEXIT_ONChanged();
        partial void OnEXIT_STATUSChanging(System.Nullable<char> value);
        partial void OnEXIT_STATUSChanged();
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
        partial void OnACCESS_TEXT_RTFChanging(string value);
        partial void OnACCESS_TEXT_RTFChanged();
        partial void OnACCESS_TYPEChanging(System.Nullable<char> value);
        partial void OnACCESS_TYPEChanged();
        #endregion

        public RIS_EXAMRESULTACCESS()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            OnCreated();
        }

        [Column(Storage = "_ACCESS_NO", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ACCESS_NO
        {
            get
            {
                return this._ACCESS_NO;
            }
            set
            {
                if ((this._ACCESS_NO != value))
                {
                    this.OnACCESS_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESS_NO = value;
                    this.SendPropertyChanged("ACCESS_NO");
                    this.OnACCESS_NOChanged();
                }
            }
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30)")]
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

        [Column(Storage = "_ACCESS_BY", DbType = "Int")]
        public System.Nullable<int> ACCESS_BY
        {
            get
            {
                return this._ACCESS_BY;
            }
            set
            {
                if ((this._ACCESS_BY != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnACCESS_BYChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESS_BY = value;
                    this.SendPropertyChanged("ACCESS_BY");
                    this.OnACCESS_BYChanged();
                }
            }
        }

        [Column(Storage = "_ACCESS_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ACCESS_ON
        {
            get
            {
                return this._ACCESS_ON;
            }
            set
            {
                if ((this._ACCESS_ON != value))
                {
                    this.OnACCESS_ONChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESS_ON = value;
                    this.SendPropertyChanged("ACCESS_ON");
                    this.OnACCESS_ONChanged();
                }
            }
        }

        [Column(Storage = "_ACCESS_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> ACCESS_STATUS
        {
            get
            {
                return this._ACCESS_STATUS;
            }
            set
            {
                if ((this._ACCESS_STATUS != value))
                {
                    this.OnACCESS_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESS_STATUS = value;
                    this.SendPropertyChanged("ACCESS_STATUS");
                    this.OnACCESS_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_ACCESS_TEXT", DbType = "NVarChar(MAX)")]
        public string ACCESS_TEXT
        {
            get
            {
                return this._ACCESS_TEXT;
            }
            set
            {
                if ((this._ACCESS_TEXT != value))
                {
                    this.OnACCESS_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESS_TEXT = value;
                    this.SendPropertyChanged("ACCESS_TEXT");
                    this.OnACCESS_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_EXIT_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EXIT_ON
        {
            get
            {
                return this._EXIT_ON;
            }
            set
            {
                if ((this._EXIT_ON != value))
                {
                    this.OnEXIT_ONChanging(value);
                    this.SendPropertyChanging();
                    this._EXIT_ON = value;
                    this.SendPropertyChanged("EXIT_ON");
                    this.OnEXIT_ONChanged();
                }
            }
        }

        [Column(Storage = "_EXIT_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> EXIT_STATUS
        {
            get
            {
                return this._EXIT_STATUS;
            }
            set
            {
                if ((this._EXIT_STATUS != value))
                {
                    this.OnEXIT_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._EXIT_STATUS = value;
                    this.SendPropertyChanged("EXIT_STATUS");
                    this.OnEXIT_STATUSChanged();
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

        [Column(Storage = "_ACCESS_TEXT_RTF", DbType = "NVarChar(MAX)")]
        public string ACCESS_TEXT_RTF
        {
            get
            {
                return this._ACCESS_TEXT_RTF;
            }
            set
            {
                if ((this._ACCESS_TEXT_RTF != value))
                {
                    this.OnACCESS_TEXT_RTFChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESS_TEXT_RTF = value;
                    this.SendPropertyChanged("ACCESS_TEXT_RTF");
                    this.OnACCESS_TEXT_RTFChanged();
                }
            }
        }

        [Column(Storage = "_ACCESS_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> ACCESS_TYPE
        {
            get
            {
                return this._ACCESS_TYPE;
            }
            set
            {
                if ((this._ACCESS_TYPE != value))
                {
                    this.OnACCESS_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESS_TYPE = value;
                    this.SendPropertyChanged("ACCESS_TYPE");
                    this.OnACCESS_TYPEChanged();
                }
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULTACCESS", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMRESULTACCESSes.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTACCESSes.Add(this);
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

        [Association(Name = "HR_EMP_RIS_EXAMRESULTACCESS", Storage = "_HR_EMP", ThisKey = "ACCESS_BY", OtherKey = "EMP_ID", IsForeignKey = true)]
        public HR_EMP HR_EMP
        {
            get
            {
                return this._HR_EMP.Entity;
            }
            set
            {
                HR_EMP previousValue = this._HR_EMP.Entity;
                if (((previousValue != value)
                            || (this._HR_EMP.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_EMP.Entity = null;
                        previousValue.RIS_EXAMRESULTACCESSes.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTACCESSes.Add(this);
                        this._ACCESS_BY = value.EMP_ID;
                    }
                    else
                    {
                        this._ACCESS_BY = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP");
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
