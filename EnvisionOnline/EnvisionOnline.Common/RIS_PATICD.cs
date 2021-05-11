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
    [Table(Name = "dbo.RIS_PATICD")]
    public partial class RIS_PATICD : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _PAT_ICD_ID;

        private System.Nullable<int> _ICD_ID;

        private string _HN;

        private System.Nullable<int> _ORDER_NO;

        private string _ACCESSION_NO;

        private System.Nullable<char> _ORDER_RESULT_FLAG;

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
        partial void OnPAT_ICD_IDChanging(int value);
        partial void OnPAT_ICD_IDChanged();
        partial void OnICD_IDChanging(System.Nullable<int> value);
        partial void OnICD_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnORDER_NOChanging(System.Nullable<int> value);
        partial void OnORDER_NOChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnORDER_RESULT_FLAGChanging(System.Nullable<char> value);
        partial void OnORDER_RESULT_FLAGChanged();
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

        public RIS_PATICD()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_PAT_ICD_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int PAT_ICD_ID
        {
            get
            {
                return this._PAT_ICD_ID;
            }
            set
            {
                if ((this._PAT_ICD_ID != value))
                {
                    this.OnPAT_ICD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PAT_ICD_ID = value;
                    this.SendPropertyChanged("PAT_ICD_ID");
                    this.OnPAT_ICD_IDChanged();
                }
            }
        }

        [Column(Storage = "_ICD_ID", DbType = "Int")]
        public System.Nullable<int> ICD_ID
        {
            get
            {
                return this._ICD_ID;
            }
            set
            {
                if ((this._ICD_ID != value))
                {
                    this.OnICD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ICD_ID = value;
                    this.SendPropertyChanged("ICD_ID");
                    this.OnICD_IDChanged();
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

        [Column(Storage = "_ORDER_NO", DbType = "Int")]
        public System.Nullable<int> ORDER_NO
        {
            get
            {
                return this._ORDER_NO;
            }
            set
            {
                if ((this._ORDER_NO != value))
                {
                    this.OnORDER_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_NO = value;
                    this.SendPropertyChanged("ORDER_NO");
                    this.OnORDER_NOChanged();
                }
            }
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(50)")]
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

        [Column(Storage = "_ORDER_RESULT_FLAG", DbType = "NVarChar(1)")]
        public System.Nullable<char> ORDER_RESULT_FLAG
        {
            get
            {
                return this._ORDER_RESULT_FLAG;
            }
            set
            {
                if ((this._ORDER_RESULT_FLAG != value))
                {
                    this.OnORDER_RESULT_FLAGChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_RESULT_FLAG = value;
                    this.SendPropertyChanged("ORDER_RESULT_FLAG");
                    this.OnORDER_RESULT_FLAGChanged();
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

        [Association(Name = "GBL_ENV_RIS_PATICD", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_PATICDs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_PATICDs.Add(this);
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
