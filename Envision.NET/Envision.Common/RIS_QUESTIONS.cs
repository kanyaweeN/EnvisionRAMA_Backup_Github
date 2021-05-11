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
    [Table(Name = "dbo.RIS_QUESTIONS")]
    public partial class RIS_QUESTION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _QUES_ID;

        private string _QUES_UID;

        private string _QUES_TEXT;

        private System.Nullable<char> _ANSWER_TYPE;

        private string _DEFAULT_ANSWER;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnQUES_IDChanging(int value);
        partial void OnQUES_IDChanged();
        partial void OnQUES_UIDChanging(string value);
        partial void OnQUES_UIDChanged();
        partial void OnQUES_TEXTChanging(string value);
        partial void OnQUES_TEXTChanged();
        partial void OnANSWER_TYPEChanging(System.Nullable<char> value);
        partial void OnANSWER_TYPEChanged();
        partial void OnDEFAULT_ANSWERChanging(string value);
        partial void OnDEFAULT_ANSWERChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
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

        public RIS_QUESTION()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_QUES_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int QUES_ID
        {
            get
            {
                return this._QUES_ID;
            }
            set
            {
                if ((this._QUES_ID != value))
                {
                    this.OnQUES_IDChanging(value);
                    this.SendPropertyChanging();
                    this._QUES_ID = value;
                    this.SendPropertyChanged("QUES_ID");
                    this.OnQUES_IDChanged();
                }
            }
        }

        [Column(Storage = "_QUES_UID", DbType = "NVarChar(30)")]
        public string QUES_UID
        {
            get
            {
                return this._QUES_UID;
            }
            set
            {
                if ((this._QUES_UID != value))
                {
                    this.OnQUES_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._QUES_UID = value;
                    this.SendPropertyChanged("QUES_UID");
                    this.OnQUES_UIDChanged();
                }
            }
        }

        [Column(Storage = "_QUES_TEXT", DbType = "NVarChar(200)")]
        public string QUES_TEXT
        {
            get
            {
                return this._QUES_TEXT;
            }
            set
            {
                if ((this._QUES_TEXT != value))
                {
                    this.OnQUES_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._QUES_TEXT = value;
                    this.SendPropertyChanged("QUES_TEXT");
                    this.OnQUES_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_ANSWER_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> ANSWER_TYPE
        {
            get
            {
                return this._ANSWER_TYPE;
            }
            set
            {
                if ((this._ANSWER_TYPE != value))
                {
                    this.OnANSWER_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._ANSWER_TYPE = value;
                    this.SendPropertyChanged("ANSWER_TYPE");
                    this.OnANSWER_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_DEFAULT_ANSWER", DbType = "NVarChar(300)")]
        public string DEFAULT_ANSWER
        {
            get
            {
                return this._DEFAULT_ANSWER;
            }
            set
            {
                if ((this._DEFAULT_ANSWER != value))
                {
                    this.OnDEFAULT_ANSWERChanging(value);
                    this.SendPropertyChanging();
                    this._DEFAULT_ANSWER = value;
                    this.SendPropertyChanged("DEFAULT_ANSWER");
                    this.OnDEFAULT_ANSWERChanged();
                }
            }
        }

        [Column(Storage = "_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_ACTIVE
        {
            get
            {
                return this._IS_ACTIVE;
            }
            set
            {
                if ((this._IS_ACTIVE != value))
                {
                    this.OnIS_ACTIVEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_ACTIVE = value;
                    this.SendPropertyChanged("IS_ACTIVE");
                    this.OnIS_ACTIVEChanged();
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

        [Association(Name = "GBL_ENV_RIS_QUESTION", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_QUESTIONs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_QUESTIONs.Add(this);
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
