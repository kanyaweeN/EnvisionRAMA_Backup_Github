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
    [Table(Name = "dbo.RIS_RESULTSTATUSCHANGELOG")]
    public partial class RIS_RESULTSTATUSCHANGELOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _STATUS_CHNAGE_ID;

        private string _HN;

        private System.Nullable<int> _ORDER_ID;

        private string _ACCESSION_NO;

        private System.Nullable<int> _EXAM_ID;

        private System.Nullable<char> _ORGINAL_STATUS;

        private System.Nullable<char> _CHANGED_STATUS;

        private System.Nullable<int> _REQUEST_BY;

        private string _CHNAGE_PC;

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
        partial void OnSTATUS_CHNAGE_IDChanging(int value);
        partial void OnSTATUS_CHNAGE_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnORDER_IDChanging(System.Nullable<int> value);
        partial void OnORDER_IDChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnEXAM_IDChanging(System.Nullable<int> value);
        partial void OnEXAM_IDChanged();
        partial void OnORGINAL_STATUSChanging(System.Nullable<char> value);
        partial void OnORGINAL_STATUSChanged();
        partial void OnCHANGED_STATUSChanging(System.Nullable<char> value);
        partial void OnCHANGED_STATUSChanged();
        partial void OnREQUEST_BYChanging(System.Nullable<int> value);
        partial void OnREQUEST_BYChanged();
        partial void OnCHNAGE_PCChanging(string value);
        partial void OnCHNAGE_PCChanged();
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

        public RIS_RESULTSTATUSCHANGELOG()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_STATUS_CHNAGE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int STATUS_CHNAGE_ID
        {
            get
            {
                return this._STATUS_CHNAGE_ID;
            }
            set
            {
                if ((this._STATUS_CHNAGE_ID != value))
                {
                    this.OnSTATUS_CHNAGE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS_CHNAGE_ID = value;
                    this.SendPropertyChanged("STATUS_CHNAGE_ID");
                    this.OnSTATUS_CHNAGE_IDChanged();
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

        [Column(Storage = "_ORDER_ID", DbType = "Int")]
        public System.Nullable<int> ORDER_ID
        {
            get
            {
                return this._ORDER_ID;
            }
            set
            {
                if ((this._ORDER_ID != value))
                {
                    this.OnORDER_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_ID = value;
                    this.SendPropertyChanged("ORDER_ID");
                    this.OnORDER_IDChanged();
                }
            }
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(100)")]
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

        [Column(Storage = "_EXAM_ID", DbType = "Int")]
        public System.Nullable<int> EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_ORGINAL_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> ORGINAL_STATUS
        {
            get
            {
                return this._ORGINAL_STATUS;
            }
            set
            {
                if ((this._ORGINAL_STATUS != value))
                {
                    this.OnORGINAL_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._ORGINAL_STATUS = value;
                    this.SendPropertyChanged("ORGINAL_STATUS");
                    this.OnORGINAL_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_CHANGED_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> CHANGED_STATUS
        {
            get
            {
                return this._CHANGED_STATUS;
            }
            set
            {
                if ((this._CHANGED_STATUS != value))
                {
                    this.OnCHANGED_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._CHANGED_STATUS = value;
                    this.SendPropertyChanged("CHANGED_STATUS");
                    this.OnCHANGED_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_REQUEST_BY", DbType = "Int")]
        public System.Nullable<int> REQUEST_BY
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

        [Column(Storage = "_CHNAGE_PC", DbType = "NVarChar(100)")]
        public string CHNAGE_PC
        {
            get
            {
                return this._CHNAGE_PC;
            }
            set
            {
                if ((this._CHNAGE_PC != value))
                {
                    this.OnCHNAGE_PCChanging(value);
                    this.SendPropertyChanging();
                    this._CHNAGE_PC = value;
                    this.SendPropertyChanged("CHNAGE_PC");
                    this.OnCHNAGE_PCChanged();
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

        [Association(Name = "GBL_ENV_RIS_RESULTSTATUSCHANGELOG", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_RESULTSTATUSCHANGELOGs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_RESULTSTATUSCHANGELOGs.Add(this);
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
